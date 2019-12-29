namespace ACT.TTSYukkuri.Config
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// 監視対象
    /// </summary>
    [Serializable]
    public class WatchTargets
    {
        /// <summary>自分</summary>
        public bool EnabledSelf { get; set; }

        /// <summary>ナイト・剣術士</summary>
        public bool EnabledKnight { get; set; }

        /// <summary>戦士・斧術士</summary>
        public bool EnabledSenshi { get; set; }

        /// <summary>白魔道士・幻術士</summary>
        public bool EnabledShiromadoshi { get; set; }

        /// <summary>学者</summary>
        public bool EnabledGakusha { get; set; }

        /// <summary>モンク・格闘士</summary>
        public bool EnabledMonk { get; set; }

        /// <summary>竜騎士・槍術士</summary>
        public bool EnabledRyukishi { get; set; }

        /// <summary>忍者・双剣士</summary>
        public bool EnabledNinja { get; set; }

        /// <summary>吟遊詩人・弓術士</summary>
        public bool EnabledGinyushijin { get; set; }

        /// <summary>黒魔道士・呪術士</summary>
        public bool EnabledKuromadoshi { get; set; }

        /// <summary>召喚士・巴術士</summary>
        public bool EnabledShokanshi { get; set; }

        /// <summary>ギャザラー・クラフター</summary>
        public bool EnabledGathererAndCrafter { get; set; }

        /// <summary>機工士</summary>
        public bool EnabledMachinist { get; set; }

        /// <summary>暗黒騎士</summary>
        public bool EnabledDarkKnight { get; set; }

        /// <summary>占星術師</summary>
        public bool EnabledAstrologian { get; set; }

        /// <summary>
        /// 要素を配列で設定、取得します
        /// </summary>
        [XmlIgnore]
        public bool[] ItemArray
        {
            get
            {
                return new bool[]
                {
                    this.EnabledSelf,
                    this.EnabledKnight,
                    this.EnabledSenshi,
                    this.EnabledShiromadoshi,
                    this.EnabledGakusha,
                    this.EnabledMonk,
                    this.EnabledRyukishi,
                    this.EnabledNinja,
                    this.EnabledGinyushijin,
                    this.EnabledKuromadoshi,
                    this.EnabledShokanshi,
                    this.EnabledGathererAndCrafter,
                    this.EnabledMachinist,
                    this.EnabledDarkKnight,
                    this.EnabledAstrologian,
                };
            }

            set
            {
                this.EnabledSelf = value.Length > 0 ? value[0] : this.EnabledSelf;
                this.EnabledKnight = value.Length > 1 ? value[1] : this.EnabledKnight;
                this.EnabledSenshi = value.Length > 2 ? value[2] : this.EnabledSenshi;
                this.EnabledShiromadoshi = value.Length > 3 ? value[3] : this.EnabledShiromadoshi;
                this.EnabledGakusha = value.Length > 4 ? value[4] : this.EnabledGakusha;
                this.EnabledMonk = value.Length > 5 ? value[5] : this.EnabledMonk;
                this.EnabledRyukishi = value.Length > 6 ? value[6] : this.EnabledRyukishi;
                this.EnabledNinja = value.Length > 7 ? value[7] : this.EnabledNinja;
                this.EnabledGinyushijin = value.Length > 8 ? value[8] : this.EnabledGinyushijin;
                this.EnabledKuromadoshi = value.Length > 9 ? value[9] : this.EnabledKuromadoshi;
                this.EnabledShokanshi = value.Length > 10 ? value[10] : this.EnabledShokanshi;
                this.EnabledGathererAndCrafter = value.Length > 11 ? value[11] : this.EnabledGathererAndCrafter;
                this.EnabledMachinist = value.Length > 12 ? value[12] : this.EnabledMachinist;
                this.EnabledDarkKnight = value.Length > 13 ? value[13] : this.EnabledDarkKnight;
                this.EnabledAstrologian = value.Length > 14 ? value[14] : this.EnabledAstrologian;
            }
        }
    }
}
