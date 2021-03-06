﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Diagnostics;
using FairyZeta.Framework.ObjectModel;
using FairyZeta.FF14.ACT.DataModel;
using FairyZeta.FF14.ACT.Process;
using FairyZeta.FF14.ACT.Timeline.Core.ObjectModel;
using FairyZeta.FF14.ACT.Timeline.Core.DataModel;
using FairyZeta.FF14.ACT.Timeline.Core.Process;

namespace FairyZeta.FF14.ACT.Timeline.Core.Module
{
    /// <summary> タイムライン／タイムライン操作モジュール
    /// </summary>
    public class TimelineControlModule : _Module
    {
        /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> 戦闘用メインタイマー
        /// </summary>
        public DispatcherTimer CurrentCombatTimer { get; set; }

        /// <summary> オートロード用タイマー
        /// </summary>
        public DispatcherTimer AutoLoadTimer { get; set; }

        /// <summary> 戦闘用メイン計測時計
        /// </summary>
        public RelativeClock CurrentCombatRelativeClock { get; private set; }

        /// <summary> ACTサウンド再生プロセス
        /// </summary>
        private SoundPlayProcess soundPlayProcess;

        /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／タイムライン操作モジュール
        /// </summary>
        public TimelineControlModule()
            : base()
        {
            this.initModule();
        }

        /*--- Method: Initialization ----------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> モジュールの初期化を実行します。
        /// </summary>
        /// <returns> 正常終了時 True </returns> 
        private bool initModule()
        {
            this.CurrentCombatTimer = new DispatcherTimer(DispatcherPriority.Render);
            this.AutoLoadTimer = new DispatcherTimer();
            this.CurrentCombatRelativeClock = new RelativeClock(false);
            this.soundPlayProcess = new SoundPlayProcess();

            return true;
        }

        /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイマーのセットアップを実行します。
        /// </summary>
        public void TimerSetup()
        {
            this.CurrentCombatTimer.Interval = TimeSpan.FromMilliseconds(33);
            this.AutoLoadTimer.Interval = TimeSpan.FromMilliseconds(3000);
        }

        /// <summary> タイマー処理を開始します。
        /// </summary>
        public void TimerStart(CommonDataModel pCommonDM, TimelineObjectModel pTimelineOM)
        {
            switch (pCommonDM.AppStatusData.CurrentCombatTimerStatus)
            {
                case TimerStatus.Init:
                case TimerStatus.Stop:
                case TimerStatus.Pause:
                    break;
                case TimerStatus.Run:
                    return;
            }

            var artList = pTimelineOM.AlertList.Where(a => a.TimeFromStart >= pTimelineOM.TimerData.CurrentCombatTime);
            foreach (var art in artList)
            {
                art.Processed = false;
            }

            this.CurrentCombatRelativeClock.CurrentTime = pTimelineOM.TimerData.CurrentCombatTime;

            this.CurrentCombatTimer.Start();
            pCommonDM.AppStatusData.CurrentCombatTimerStatus = TimerStatus.Run;
            this.TimerFunctionEnabledChange(pCommonDM);
        }

        /// <summary> タイマー処理を停止します。
        /// </summary>
        public void TimerStop(CommonDataModel pCommonDM, TimelineObjectModel pTimelineOM)
        {
            switch (pCommonDM.AppStatusData.CurrentCombatTimerStatus)
            {
                case TimerStatus.Init:
                case TimerStatus.Stop:
                case TimerStatus.Pause:
                case TimerStatus.Run:
                    break;
            }

            pCommonDM.AppStatusData.CurrentCombatTimerStatus = TimerStatus.Stop;
            this.TimerFunctionEnabledChange(pCommonDM);
            this.CurrentCombatTimer.Stop();
            this.CurrentCombatRelativeClock.CurrentTime = 0;

            pTimelineOM.TimerData.CurrentCombatTime = pTimelineOM.TimerData.CurrentCombatStartTime;

            foreach (var item in pTimelineOM.ActivityCollection)
            {
                item.ViewRefresh();
            }
        }

        /// <summary> タイマーを一時停止します。
        /// </summary>
        public void TimerPause(CommonDataModel pCommonDM)
        {
            switch (pCommonDM.AppStatusData.CurrentCombatTimerStatus)
            {
                case TimerStatus.Init:
                case TimerStatus.Stop:
                case TimerStatus.Pause:
                    return;
                case TimerStatus.Run:
                    break;
            }

            this.CurrentCombatTimer.Stop();
            pCommonDM.AppStatusData.CurrentCombatTimerStatus = TimerStatus.Pause;
            this.TimerFunctionEnabledChange(pCommonDM);
        }

        /// <summary> タイマーをリブートします。
        /// </summary>
        public void TimerReboot(CommonDataModel pCommonDM, TimelineObjectModel pTimelineOM)
        {
            switch (pCommonDM.AppStatusData.CurrentCombatTimerStatus)
            {
                case TimerStatus.Init:
                case TimerStatus.Stop:
                case TimerStatus.Pause:
                case TimerStatus.Run:
                    break;
            }

            this.TimerStop(pCommonDM, pTimelineOM);

            this.TimerStart(pCommonDM, pTimelineOM);
        }

        /// <summary> タイマーを0に巻き戻し、ステータスがRunの場合は再スタートさせます。
        /// </summary>
        public void TimerRewind(CommonDataModel pCommonDM, TimelineObjectModel pTimelineOM)
        {
            switch (pCommonDM.AppStatusData.CurrentCombatTimerStatus)
            {
                case TimerStatus.Init:
                case TimerStatus.Stop:
                case TimerStatus.Pause:
                case TimerStatus.Run:
                    break;
            }

            var status = pCommonDM.AppStatusData.CurrentCombatTimerStatus;

            this.TimerStop(pCommonDM, pTimelineOM);

            if (status == TimerStatus.Run)
            {
                this.TimerStart(pCommonDM, pTimelineOM);
            }
        }

        /// <summary> 戦闘時間が進む時の処理を実行します。
        /// </summary>
        /// <param name="pTimerDataModel"></param>
        /// <param name="pTimelineDataModel"></param>
        public void CombatTimeTick(CommonDataModel pCommonDM, TimelineObjectModel pTimelineOM)
        {
            if (pCommonDM.AppStatusData.CurrentCombatTimerStatus != TimerStatus.Run) return;

            pTimelineOM.TimerData.CurrentCombatTime = this.CurrentCombatRelativeClock.CurrentTime;

            // アラート再生
            var pendingAlerts = pTimelineOM.PendingAlertsAt(pTimelineOM.TimerData.CurrentCombatTime, AppConst.TooOldThreshold);
            foreach (var pendingAlert in pendingAlerts)
            {
                if (pendingAlert.AlertSoundData != null)
                {
                    pendingAlert.Processed = soundPlayProcess.PlayAlert(pendingAlert, pCommonDM.PluginSettingsData.PlaySoundByACT);
                    pCommonDM.TimelineLogCollection.Add(
                        Globals.TimelineLogger.WriteSystemLog.Success.INFO.Write(string.Format("PendingAlerts: {0}", pendingAlert.AlertSoundData.Filename), Globals.ProjectName));
                }
                else
                {
                    pendingAlert.Processed = pendingAlert.TtsSpeaker.Synthesizer.SpeakAsync(pendingAlert.TtsSentence);
                    //pCommonDM.TimelineLogCollection.Add(
                    //    Globals.TimelineLogger.WriteSystemLog.Success.INFO.Write(string.Format("PendingAlerts: {0}", pendingAlert.TtsSentenc), Globals.ProjectName));
                }
                //pCommonDM.TimelineLogCollection.Add(
                //    Globals.TimelineLogger.WriteSystemLog.Success.INFO.Write(string.Format("PendingAlerts: {0}", pendingAlert.AlertSoundData.Filename), Globals.ProjectName));
            }
        }

        /// <summary> タイマーステータスを参照し、機能の有効状態を更新します。
        /// </summary>
        /// <param name="pCommonDM"></param>
        public void TimerFunctionEnabledChange(CommonDataModel pCommonDM)
        {
            switch (pCommonDM.AppStatusData.CurrentCombatTimerStatus)
            {
                case TimerStatus.Pause:
                    pCommonDM.AppEnableManageData.TimelineFileLoadEnabled = true;
                    if (pCommonDM.SelectedTimelineFileData == null)
                    {
                        pCommonDM.AppEnableManageData.TimelineFileLoadEnabled = false;
                    }
                    pCommonDM.AppEnableManageData.RefreshTimelineListEnabled = true;

                    pCommonDM.AppEnableManageData.TimelinePlayEnabled = true;
                    pCommonDM.AppEnableManageData.TimelinePauseEnabled = false;
                    pCommonDM.AppEnableManageData.TimelineRewindEnabled = true;
                    pCommonDM.AppEnableManageData.TimelineTrackerEnabled = true;
                    pCommonDM.AppEnableManageData.TimelineUnloadEnabled = true;
                    break;

                case TimerStatus.Run:

                    pCommonDM.AppEnableManageData.TimelineFileLoadEnabled = false;
                    pCommonDM.AppEnableManageData.RefreshTimelineListEnabled = true;

                    pCommonDM.AppEnableManageData.TimelinePlayEnabled = false;
                    pCommonDM.AppEnableManageData.TimelinePauseEnabled = true;
                    pCommonDM.AppEnableManageData.TimelineRewindEnabled = true;
                    pCommonDM.AppEnableManageData.TimelineTrackerEnabled = false;
                    pCommonDM.AppEnableManageData.TimelineUnloadEnabled = false;

                    break;

                case TimerStatus.Init:
                case TimerStatus.Stop:

                    pCommonDM.AppEnableManageData.TimelineFileLoadEnabled = true;
                    if (pCommonDM.SelectedTimelineFileData == null)
                    {
                        pCommonDM.AppEnableManageData.TimelineFileLoadEnabled = false;
                    }
                    pCommonDM.AppEnableManageData.RefreshTimelineListEnabled = true;

                    pCommonDM.AppEnableManageData.TimelinePlayEnabled = true;
                    pCommonDM.AppEnableManageData.TimelinePauseEnabled = false;
                    pCommonDM.AppEnableManageData.TimelineRewindEnabled = true;
                    pCommonDM.AppEnableManageData.TimelineTrackerEnabled = true;
                    pCommonDM.AppEnableManageData.TimelineUnloadEnabled = true;

                    break;
            }

        }

        /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/


    }
}
