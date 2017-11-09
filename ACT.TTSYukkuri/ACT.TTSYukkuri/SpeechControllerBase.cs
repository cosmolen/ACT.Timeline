namespace ACT.TTSYukkuri
{
    using System.Threading;
    using System.Windows.Forms;

    /// <summary>
    /// スピーチコントローラの基底クラス
    /// </summary>
    public abstract class SpeechControllerBase : ISpeechController
    {
        /// <summary>
        /// TTSの設定Panel
        /// </summary>
        public abstract UserControl TTSSettingsPanel { get; }

        /// <summary>
        /// TTSを初期化する
        /// </summary>
        public abstract void Initialize();

        /// <summary>
        /// TTSに話してもらう
        /// </summary>
        /// <param name="text">読上げるテキスト</param>
        public abstract void Speak(string text);

        /// <summary>
        /// TTSにディレイ後に話してもらう
        /// </summary>
        /// <param name="text">読上げるテキスト</param>
        /// <param name="delay">ディレイ(秒)</param>
        public void SpeakWithDelay(string text, int delay)
        {
            if (delay == 0)
            {
                this.Speak(text);
                return;
            }

            var timer = new System.Threading.Timer(new TimerCallback((state) =>
            {
                this.Speak(text);
                (state as System.Threading.Timer).Dispose();
            }));

            timer.Change(
                delay * 1000,
                0);
        }
    }
}
