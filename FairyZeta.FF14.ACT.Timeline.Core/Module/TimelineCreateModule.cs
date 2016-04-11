﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyZeta.Core.Process;
using FairyZeta.FF14.ACT.Timeline.Core.Data;
using FairyZeta.FF14.ACT.Timeline.Core.DataModel;
using FairyZeta.FF14.ACT.Timeline.Core.Process;

namespace FairyZeta.FF14.ACT.Timeline.Core.Module
{
    /// <summary> タイムライン／タイムラインデータ生成モジュール
    /// </summary>
    public class TimelineCreateModule : _Module
    {
      /*--- Property/Field Definitions ------------------------------------------------------------------------------------------------------------------------------*/

        #region --- Proccess ---

        /// <summary> [Util] double処理用プロセス
        /// </summary>
        private DoubleToAdjustProcess doubleToAdjustProcess;
        /// <summary> タイムラインアイテム解析プロセス
        /// </summary>
        private TimelineItemAnalyzProcess timelineItemAnalyzProcess;

        #endregion

      /*--- Constructers --------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムライン／タイムラインデータ生成モジュール／コンストラクタ
        /// </summary>
        public TimelineCreateModule()
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
            this.doubleToAdjustProcess = new DoubleToAdjustProcess();
            this.timelineItemAnalyzProcess = new TimelineItemAnalyzProcess();

            return true;
        }

      /*--- Method: public ------------------------------------------------------------------------------------------------------------------------------------------*/

        /// <summary> タイムラインデータモデルを生成します。
        /// </summary>
        /// <param name="pCommonDM"> 共通データモデル </param>
        /// <param name="pTimelineDM"> 作成データを格納するタイムラインデータモデル </param>
        public void CreateTimelineDataModel(CommonDataModel pCommonDM, TimelineDataModel pTimelineDM, TimerDataModel pTimerDM)
        {
            this.TimelineDataClear(pCommonDM, pTimelineDM);
            pCommonDM.AppStatusData.TimelineLoadStatus = TimelineLoadStatus.NowLoading;

            if (pCommonDM.SelectedTimelineFileData == null)
            {
                pCommonDM.AppStatusData.TimelineLoadStatus = TimelineLoadStatus.Failure;
                return;
            }

            try
            {
                pTimelineDM.Timeline = TimelineLoader.LoadFromFile(pCommonDM.SelectedTimelineFileData.TimelineFileFullPath);
            }
            catch
            {
                pCommonDM.AppStatusData.TimelineLoadStatus = TimelineLoadStatus.Failure;
                return;
            }

            var baseData = pTimelineDM.Timeline;

            if (baseData.Items.Count() == 0) return;

            // アンカーコレクション
            foreach (var anc in pTimelineDM.Timeline.Anchors)
            {
                pTimelineDM.TimelineAnchorDataCollection.Add(anc);
            }

            // タイムラインアイテムコレクションの生成
            foreach (var data in baseData.Items)
            {
                TimelineItemData target = new TimelineItemData(pTimerDM.TimerDeta);

                target.ActivityNo = this.doubleToAdjustProcess.ToHalfAdjust(data.TimeFromStart, 1);
                target.ActivityIndex = Convert.ToInt32(target.ActivityNo * 10);
                target.Duration = data.Duration;
                target.ActivityName = data.Name;
                target.ActivityTime = new TimeSpan(0, 0, Convert.ToInt32(target.EndTime));

                target.ActiveIndicatorStartTime = target.ActiveTime - target.ActiveIndicatorMaxValue;
                if(target.DurationIndicatorMaxValue > 0)
                {
                    target.DurationIndicatorVisibility = true;
                }

                // タイムラインタイプとジョブを設定
                this.timelineItemAnalyzProcess.SetTimelineType(target);
                this.timelineItemAnalyzProcess.SetTimelineJob(target);

                // ジャンプとシンクの設定
                target.JumpItemData = pTimelineDM.TimelineAnchorDataCollection
                    .FirstOrDefault(s => s.Jump >= 0 && s.TimeFromStart == target.ActivityNo);
                target.SyncItemData = pTimelineDM.TimelineAnchorDataCollection
                    .FirstOrDefault(s => s.Jump == -1.0 && s.TimeFromStart == target.ActivityNo);

                // add
                pTimelineDM.TimelineItemCollection.Add(target);
                
            }

            // アラートコレクションの生成
            foreach (var data in baseData.Alerts)
            {
                pTimelineDM.AlertStartTimeList.Add(data.TimeFromStart);
                pTimelineDM.TimelineAlertCollection.Add(data);
            }


            pCommonDM.AppStatusData.TimelineLoadStatus = TimelineLoadStatus.Success;
        }

        /// <summary> タイムラインデータのクリアを実行し、ステータスを変更します。
        /// </summary>
        /// <param name="pCommonDM"></param>
        /// <param name="pTimelineDM"></param>
        public void TimelineDataClear(CommonDataModel pCommonDM, TimelineDataModel pTimelineDM)
        {
            pTimelineDM.Clear();
            pCommonDM.AppStatusData.TimelineLoadStatus = TimelineLoadStatus.NonLoad;

            return;
        }

      /*--- Method: private -----------------------------------------------------------------------------------------------------------------------------------------*/

    }
}