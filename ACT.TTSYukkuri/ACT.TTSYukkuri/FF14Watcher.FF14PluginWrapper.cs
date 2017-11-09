namespace ACT.TTSYukkuri
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// FF14を監視する FF14Pluginラップ部分
    /// </summary>
    public partial class FF14Watcher
    {
        /// <summary>
        /// 戦闘メンバリストを取得する
        /// </summary>
        /// <returns>戦闘メンバリスト</returns>
        public List<Combatant> GetCombatantList()
        {
            return FF14PluginHelper.GetCombatantList();
        }

        /// <summary>
        /// プレイヤ情報を取得する
        /// </summary>
        /// <returns>プレイヤ情報</returns>
        public Combatant GetPlayer()
        {
            var list = FF14PluginHelper.GetCombatantList();

            if (list.Count > 0)
            {
                return list[0];
            }
            else
            {
                return new Combatant();
            }
        }

        /// <summary>
        /// パーティの戦闘メンバリストを取得する
        /// </summary>
        /// <returns>パーティの戦闘メンバリスト</returns>
        public List<Combatant> GetCombatantListParty()
        {
            // 総戦闘メンバリストを取得する（周囲のPC, NPC, MOB等すべて）
            var combatListAll = this.GetCombatantList();

            // パーティメンバのIDリストを取得する
            int partyCount;
            var partyListById = FF14PluginHelper.GetCurrentPartyList(out partyCount);

            var combatListParty = new List<Combatant>();

            foreach (var partyMemberId in partyListById)
            {
                if (partyMemberId == 0)
                {
                    continue;
                }

                var partyMember = (
                    from x in combatListAll
                    where
                    x.ID == partyMemberId
                    select
                    x).FirstOrDefault();

                if (partyMember != null)
                {
                    combatListParty.Add(partyMember);
                }
            }

            return combatListParty;
        }

        /// <summary>
        /// ジョブ名を取得する
        /// </summary>
        /// <param name="jobId">ジョブID</param>
        /// <returns>ジョブ名（TTS用）</returns>
        public static string GetJobNameToSpeak(
            int jobId)
        {
            switch (jobId)
            {
                case 0:
                    return string.Empty;
                case 1:
                    return "けんじゅつし";
                case 2:
                    return "かくとうし";
                case 3:
                    return "ふじゅつし";
                case 4:
                    return "そうじゅつし";
                case 5:
                    return "きゅうじゅつし";
                case 6:
                    return "げんじゅつし";
                case 7:
                    return "じゅじゅつし";
                case 8:
                    return "もっこうし";
                case 9:
                    return "かじし";
                case 10:
                    return "かっちゅうし";
                case 11:
                    return "ちょうきんし";
                case 12:
                    return "かわざいくし";
                case 13:
                    return "さいほうし";
                case 14:
                    return "れんきんじゅつし";
                case 15:
                    return "ちょうりし";
                case 16:
                    return "さいくつし";
                case 17:
                    return "えんげいし";
                case 18:
                    return "りょうし";
                case 19:
                    return "ないと";
                case 20:
                    return "もんく";
                case 21:
                    return "せんし";
                case 22:
                    return "りゅうきし";
                case 23:
                    return "ぎんゆうしじん";
                case 24:
                    return "しろまどうし";
                case 25:
                    return "くろまどうし";
                case 26:
                    return "はじゅつし";
                case 27:
                    return "しょうかんし";
                case 28:
                    return "がくしゃ";
                case 29:
                    return "そうけんし";
                case 30:
                    return "にんじゃ";
                case 31:
                    return "きこうし";
                case 32:
                    return "あんこくきし";
                case 33:
                    return "せんせいじゅつし";
                default:
                    return jobId.ToString();
            }
        }
    }
}
