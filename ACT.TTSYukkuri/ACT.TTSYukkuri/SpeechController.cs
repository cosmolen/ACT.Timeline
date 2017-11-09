namespace ACT.TTSYukkuri
{
    using System.Windows.Forms;

    using ACT.TTSYukkuri.Boyomichan;
    using ACT.TTSYukkuri.Config;
    using ACT.TTSYukkuri.HOYA;
    using ACT.TTSYukkuri.OpenJTalk;
    using ACT.TTSYukkuri.Sasara;
    using ACT.TTSYukkuri.Yukkuri;

    /// <summary>
    /// スピーチコントローラ
    /// </summary>
    public class SpeechController :
        SpeechControllerBase,
        ISpeechController
    {
        /// <summary>
        /// Lockオブジェクト
        /// </summary>
        private static object lockObject = new object();

        /// <summary>
        /// シングルトンinstance
        /// </summary>
        private static ISpeechController instance;

        /// <summary>
        /// 現在のTTSタイプ
        /// </summary>
        private static string nowTTSType;

        /// <summary>
        /// シングルトンinstanceを返す
        /// </summary>
        public static ISpeechController Default
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null ||
                        nowTTSType != TTSYukkuriConfig.Default.TTS)
                    {
                        switch (TTSYukkuriConfig.Default.TTS)
                        {
                            case TTSType.Yukkuri:
                                instance = new YukkuriSpeechController();
                                break;

                            case TTSType.SasaraSato:
                                instance = new SasaraSpeechController();
                                break;

                            case TTSType.Boyomichan:
                                instance = new BoyomichanSpeechController();
                                break;

                            case TTSType.OpenJTalk:
                                instance = new OpenJTalkSpeechController();
                                break;

                            case TTSType.HOYA:
                                instance = new HOYASpeechController();
                                break;

                            default:
                                instance = new YukkuriSpeechController();
                                break;
                        }

                        instance.Initialize();

                        nowTTSType = TTSYukkuriConfig.Default.TTS;

                        // 監視スレッドにスピークdelegateを与える
                        FF14Watcher.Default.SpeakDelegate = instance.Speak;
                    }

                    return instance;
                }
            }
        }

        /// <summary>
        /// TTSの設定Panel
        /// </summary>
        public override UserControl TTSSettingsPanel
        {
            get
            {
                return SpeechController.Default.TTSSettingsPanel;
            }
        }

        /// <summary>
        /// 初期化する
        /// </summary>
        public override void Initialize()
        {
            SpeechController.Default.Initialize();
        }

        /// <summary>
        /// TTSに話してもらう
        /// </summary>
        /// <param name="text">読上げるテキスト</param>
        public override void Speak(string text)
        {
            instance.Speak(text);
        }
    }
}
