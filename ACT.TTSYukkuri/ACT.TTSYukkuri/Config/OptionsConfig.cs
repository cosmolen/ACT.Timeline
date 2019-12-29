namespace ACT.TTSYukkuri.Config
{
    using System;

    /// <summary>
    /// オプション設定
    /// </summary>
    [Serializable]
    public class OptionsConfig
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public OptionsConfig()
        {
            this.HPTextToSpeack = "<pcname>、HP<hpp>%。";
            this.MPTextToSpeack = "<pcname>、MP<mpp>%。";
            this.TPTextToSpeack = "<pcname>、TP<tpp>%。";
            this.WatchTargetsHP = new WatchTargets();
            this.WatchTargetsMP = new WatchTargets();
            this.WatchTargetsTP = new WatchTargets();
        }

        /// <summary>
        /// HPの監視を有効にする
        /// </summary>
        public bool EnabledHPWatch { get; set; }

        /// <summary>
        /// HP読上げのしきい値
        /// </summary>
        public int HPThreshold { get; set; }

        /// <summary>
        /// HP低下時の読上げテキスト
        /// </summary>
        public string HPTextToSpeack { get; set; }

        /// <summary>
        /// MPの監視を有効にする
        /// </summary>
        public bool EnabledMPWatch { get; set; }

        /// <summary>
        /// MP読上げのしきい値
        /// </summary>
        public int MPThreshold { get; set; }

        /// <summary>
        /// MP低下時の読上げテキスト
        /// </summary>
        public string MPTextToSpeack { get; set; }

        /// <summary>
        /// TPの監視を有効にする
        /// </summary>
        public bool EnabledTPWatch { get; set; }

        /// <summary>
        /// TP読上げのしきい値
        /// </summary>
        public int TPThreshold { get; set; }

        /// <summary>
        /// TP低下時の読上げテキスト
        /// </summary>
        public string TPTextToSpeack { get; set; }

        /// <summary>
        /// HPの監視対象
        /// </summary>
        public WatchTargets WatchTargetsHP { get; set; }

        /// <summary>
        /// MPの監視対象
        /// </summary>
        public WatchTargets WatchTargetsMP { get; set; }

        /// <summary>
        /// TPの監視対象
        /// </summary>
        public WatchTargets WatchTargetsTP { get; set; }
    }
}
