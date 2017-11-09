namespace ACT.TTSYukkuri
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ACT.TTSYukkuri.Config;

    /// <summary>
    /// FF14を監視する パーティメンバ監視部分
    /// </summary>
    public partial class FF14Watcher
    {
        /// <summary>
        /// 直前のパーティメンバ情報
        /// </summary>
        private List<PreviousPartyMemberStatus> previouseParyMemberList = new List<PreviousPartyMemberStatus>();

        /// <summary>
        /// 最後のHP通知日時
        /// </summary>
        private DateTime lastHPNotice = DateTime.MinValue;

        /// <summary>
        /// 最後のMP通知日時
        /// </summary>
        private DateTime lastMPNotice = DateTime.MinValue;

        /// <summary>
        /// 最後のMP通知日時
        /// </summary>
        private DateTime lastTPNotice = DateTime.MinValue;

        /// <summary>
        /// パーティを監視する
        /// </summary>
        public void WatchParty()
        {
            // パーティメンバの情報を取得する
            var player = this.GetPlayer();
            var partyList = this.GetCombatantListParty();

            // パーティリストに存在しないメンバの前回の状態を消去する
            var removeList = new List<PreviousPartyMemberStatus>();
            foreach (var previouseMember in previouseParyMemberList)
            {
                if (!partyList.Any(x => x.ID == previouseMember.ID))
                {
                    removeList.Add(previouseMember);
                }
            }

            foreach (var removeMember in removeList)
            {
                this.previouseParyMemberList.Remove(removeMember);
            }

            foreach (var partyMember in partyList)
            {
                // このPTメンバの現在の状態を取得する
                var hp = partyMember.CurrentHP;
                var hpp =
                    partyMember.MaxHP != 0 ?
                    ((decimal)partyMember.CurrentHP / (decimal)partyMember.MaxHP) * 100m :
                    0m;

                var mp = partyMember.CurrentMP;
                var mpp =
                    partyMember.MaxMP != 0 ?
                    ((decimal)partyMember.CurrentMP / (decimal)partyMember.MaxMP) * 100m :
                    0m;

                var tp = partyMember.CurrentTP;
                var tpp = ((decimal)partyMember.CurrentTP / 1000m) * 100m;

                // このPTメンバの直前の情報を取得する
                var previousePartyMember = (
                    from x in this.previouseParyMemberList
                    where
                    x.ID == partyMember.ID
                    select
                    x).FirstOrDefault();

                if (previousePartyMember == null)
                {
                    previousePartyMember = new PreviousPartyMemberStatus()
                    {
                        ID = partyMember.ID,
                        Name = partyMember.Name,
                        HPRate = hpp,
                        MPRate = mpp,
                        TPRate = tpp
                    };

                    this.previouseParyMemberList.Add(previousePartyMember);
                }

                // 読上げ用の名前「ジョブ名＋イニシャル」とする
                var pcname =
                    GetJobNameToSpeak(partyMember.Job) +
                    partyMember.Name.Trim().Substring(0, 1);

                // 読上げ用のテキストを編集する
                var hpTextToSpeak = TTSYukkuriConfig.Default.OptionSettings.HPTextToSpeack;
                var mpTextToSpeak = TTSYukkuriConfig.Default.OptionSettings.MPTextToSpeack;
                var tpTextToSpeak = TTSYukkuriConfig.Default.OptionSettings.TPTextToSpeack;

                hpTextToSpeak = hpTextToSpeak.Replace("<pcname>", pcname);
                hpTextToSpeak = hpTextToSpeak.Replace("<hp>", hp.ToString());
                hpTextToSpeak = hpTextToSpeak.Replace("<hpp>", decimal.ToInt32(hpp).ToString());
                hpTextToSpeak = hpTextToSpeak.Replace("<mp>", mp.ToString());
                hpTextToSpeak = hpTextToSpeak.Replace("<mpp>", decimal.ToInt32(mpp).ToString());
                hpTextToSpeak = hpTextToSpeak.Replace("<tp>", tp.ToString());
                hpTextToSpeak = hpTextToSpeak.Replace("<tpp>", decimal.ToInt32(tpp).ToString());

                mpTextToSpeak = mpTextToSpeak.Replace("<pcname>", pcname);
                mpTextToSpeak = mpTextToSpeak.Replace("<hp>", hp.ToString());
                mpTextToSpeak = mpTextToSpeak.Replace("<hpp>", decimal.ToInt32(hpp).ToString());
                mpTextToSpeak = mpTextToSpeak.Replace("<mp>", mp.ToString());
                mpTextToSpeak = mpTextToSpeak.Replace("<mpp>", decimal.ToInt32(mpp).ToString());
                mpTextToSpeak = mpTextToSpeak.Replace("<tp>", tp.ToString());
                mpTextToSpeak = mpTextToSpeak.Replace("<tpp>", decimal.ToInt32(tpp).ToString());

                tpTextToSpeak = tpTextToSpeak.Replace("<pcname>", pcname);
                tpTextToSpeak = tpTextToSpeak.Replace("<hp>", hp.ToString());
                tpTextToSpeak = tpTextToSpeak.Replace("<hpp>", decimal.ToInt32(hpp).ToString());
                tpTextToSpeak = tpTextToSpeak.Replace("<mp>", mp.ToString());
                tpTextToSpeak = tpTextToSpeak.Replace("<mpp>", decimal.ToInt32(mpp).ToString());
                tpTextToSpeak = tpTextToSpeak.Replace("<tp>", tp.ToString());
                tpTextToSpeak = tpTextToSpeak.Replace("<tpp>", decimal.ToInt32(tpp).ToString());

                // HPをチェックして読上げる
                if (TTSYukkuriConfig.Default.OptionSettings.EnabledHPWatch &&
                    !string.IsNullOrWhiteSpace(hpTextToSpeak))
                {
                    if (this.IsWatchTarget(partyMember, player, "HP"))
                    {
                        if (hpp <= (decimal)TTSYukkuriConfig.Default.OptionSettings.HPThreshold &&
                            previousePartyMember.HPRate > (decimal)TTSYukkuriConfig.Default.OptionSettings.HPThreshold)
                        {
                            if ((DateTime.Now - this.lastHPNotice).TotalSeconds >= 6.0d)
                            {
                                this.Speak(hpTextToSpeak);
                                this.lastHPNotice = DateTime.Now;
                            }
                        }
                        else
                        {
                            if (hpp <= decimal.Zero && previousePartyMember.HPRate != decimal.Zero)
                            {
                                this.Speak(pcname + "、せんとうふのう。");
                                this.lastHPNotice = DateTime.Now;
                            }
                        }
                    }
                }

                // MPをチェックして読上げる
                if (hp > 0)
                {
                    if (TTSYukkuriConfig.Default.OptionSettings.EnabledMPWatch &&
                        !string.IsNullOrWhiteSpace(mpTextToSpeak))
                    {
                        if (this.IsWatchTarget(partyMember, player, "MP"))
                        {
                            if (mpp <= (decimal)TTSYukkuriConfig.Default.OptionSettings.MPThreshold &&
                                previousePartyMember.MPRate > (decimal)TTSYukkuriConfig.Default.OptionSettings.MPThreshold)
                            {
                                if ((DateTime.Now - this.lastMPNotice).TotalSeconds >= 6.0d)
                                {
                                    this.Speak(mpTextToSpeak);
                                    this.lastMPNotice = DateTime.Now;
                                }
                            }
                            else
                            {
                                if (mpp <= decimal.Zero && previousePartyMember.MPRate != decimal.Zero)
                                {
                                    this.Speak(pcname + "、MPなし。");
                                    this.lastMPNotice = DateTime.Now;
                                }
                            }
                        }
                    }
                }

                // TPをチェックして読上げる
                if (hp > 0)
                {
                    if (TTSYukkuriConfig.Default.OptionSettings.EnabledTPWatch &&
                        !string.IsNullOrWhiteSpace(tpTextToSpeak))
                    {
                        if (this.IsWatchTarget(partyMember, player, "TP"))
                        {
                            if (tpp <= (decimal)TTSYukkuriConfig.Default.OptionSettings.TPThreshold &&
                                previousePartyMember.TPRate > (decimal)TTSYukkuriConfig.Default.OptionSettings.TPThreshold)
                            {
                                if ((DateTime.Now - this.lastTPNotice).TotalSeconds >= 6.0d)
                                {
                                    this.Speak(tpTextToSpeak);
                                    this.lastTPNotice = DateTime.Now;
                                }
                            }
                            else
                            {
                                if (tpp <= decimal.Zero && previousePartyMember.TPRate != decimal.Zero)
                                {
                                    this.Speak(pcname + "、TPなし。");
                                    this.lastTPNotice = DateTime.Now;
                                }
                            }
                        }
                    }
                }

                // 今回の状態を保存する
                previousePartyMember.HPRate = hpp;
                previousePartyMember.MPRate = mpp;
                previousePartyMember.TPRate = tpp;
            }
        }

        /// <summary>
        /// 監視対象か？
        /// </summary>
        /// <param name="targetInfo">監視候補の情報</param>
        /// <param name="playerInfo">プレイヤの情報</param>
        /// <param name="targetParameter">対象とするParameter</param>
        /// <returns>監視対象か？</returns>
        private bool IsWatchTarget(
            Combatant targetInfo,
            Combatant playerInfo,
            string targetParameter)
        {
            var r = false;

            var watchTarget = default(WatchTargets);
            switch (targetParameter.ToUpper())
            {
                case "HP": watchTarget = TTSYukkuriConfig.Default.OptionSettings.WatchTargetsHP; break;
                case "MP": watchTarget = TTSYukkuriConfig.Default.OptionSettings.WatchTargetsMP; break;
                case "TP": watchTarget = TTSYukkuriConfig.Default.OptionSettings.WatchTargetsTP; break;
                default:
                    return r;
            }

            switch (targetInfo.Job)
            {
                case 0: r = false; break;
                case 1: r = watchTarget.EnabledKnight; break;
                case 2: r = watchTarget.EnabledMonk; break;
                case 3: r = watchTarget.EnabledSenshi; break;
                case 4: r = watchTarget.EnabledRyukishi; break;
                case 5: r = watchTarget.EnabledGinyushijin; break;
                case 6: r = watchTarget.EnabledShiromadoshi; break;
                case 7: r = watchTarget.EnabledKuromadoshi; break;

                case 8: r = watchTarget.EnabledGathererAndCrafter; break;
                case 9: r = watchTarget.EnabledGathererAndCrafter; break;
                case 10: r = watchTarget.EnabledGathererAndCrafter; break;
                case 11: r = watchTarget.EnabledGathererAndCrafter; break;
                case 12: r = watchTarget.EnabledGathererAndCrafter; break;
                case 13: r = watchTarget.EnabledGathererAndCrafter; break;
                case 14: r = watchTarget.EnabledGathererAndCrafter; break;
                case 15: r = watchTarget.EnabledGathererAndCrafter; break;
                case 16: r = watchTarget.EnabledGathererAndCrafter; break;
                case 17: r = watchTarget.EnabledGathererAndCrafter; break;
                case 18: r = watchTarget.EnabledGathererAndCrafter; break;

                case 19: r = watchTarget.EnabledKnight; break;
                case 20: r = watchTarget.EnabledMonk; break;
                case 21: r = watchTarget.EnabledSenshi; break;
                case 22: r = watchTarget.EnabledRyukishi; break;
                case 23: r = watchTarget.EnabledGinyushijin; break;
                case 24: r = watchTarget.EnabledShiromadoshi; break;
                case 25: r = watchTarget.EnabledKuromadoshi; break;
                case 26: r = watchTarget.EnabledShokanshi; break;
                case 27: r = watchTarget.EnabledShokanshi; break;
                case 28: r = watchTarget.EnabledGakusha; break;
                case 29: r = watchTarget.EnabledNinja; break;
                case 30: r = watchTarget.EnabledNinja; break;

                case 31: r = watchTarget.EnabledMachinist; break;
                case 32: r = watchTarget.EnabledDarkKnight; break;
                case 33: r = watchTarget.EnabledAstrologian; break;

                default: r = false; break;
            }

            // 自分自身か？
            if (targetInfo.ID == playerInfo.ID)
            {
                r = watchTarget.EnabledSelf;
            }

            return r;
        }

        /// <summary>
        /// 直前のPTメンバステータス
        /// </summary>
        private class PreviousPartyMemberStatus
        {
            /// <summary>
            /// ID
            /// </summary>
            public uint ID { get; set; }

            /// <summary>
            /// 名前
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// HP率
            /// </summary>
            public decimal HPRate { get; set; }

            /// <summary>
            /// MP率
            /// </summary>
            public decimal MPRate { get; set; }

            /// <summary>
            /// TP率
            /// </summary>
            public decimal TPRate { get; set; }
        }
    }
}
