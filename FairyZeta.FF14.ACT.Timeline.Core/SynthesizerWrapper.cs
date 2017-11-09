namespace FairyZeta.FF14.ACT.Timeline.Core
{
    using System;
    using System.Speech.Synthesis;

    /// <summary>
    /// 非同期でしゃべるデリゲート
    /// </summary>
    /// <param name="textToSpeak">読上げる文章</param>
    public delegate Prompt SpeakAsyncDelegate(string textToSpeak);

    /// <summary>
    /// 非同期でしゃべるデリゲート(ゆっくり)
    /// </summary>
    /// <param name="textToSpeak">読上げる文章</param>
    public delegate void SpeakAsyncByYukkuriDelegate(string textToSpeak);

    /// <summary>
    /// シンセサイザーの汎用うわっかぶせ
    /// </summary>
    public class SynthesizerWrapper : IDisposable
    {
        /// <summary>
        /// お喋りシンセサイザー
        /// </summary>
        public SpeechSynthesizer Synthesizer { get; set; }

        /// <summary>
        /// 非同期でしゃべるデリゲート
        /// </summary>
        /// <param name="textToSpeak">読上げる文章</param>
        public SpeakAsyncDelegate SpeakAsyncDelegate { get; set; }

        /// <summary>
        /// 非同期でしゃべるデリゲート(ゆっくり)
        /// </summary>
        /// <param name="textToSpeak">読上げる文章</param>
        public SpeakAsyncByYukkuriDelegate SpeakAsyncByYukkuriDelegate { get; set; }

        /// <summary>
        /// 非同期でしゃべる
        /// </summary>
        /// <param name="textToSpeak">読上げる文章</param>
        public bool SpeakAsync(
            string textToSpeak)
        {
            if (this.SpeakAsyncDelegate != null)
            {
                this.SpeakAsyncDelegate(textToSpeak);
            }

            if (this.SpeakAsyncByYukkuriDelegate != null)
            {
                this.SpeakAsyncByYukkuriDelegate(textToSpeak);
            }
            return true;
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            if (this.Synthesizer != null)
            {
                this.Synthesizer.Dispose();
                this.Synthesizer = null;
            }
        }
    }
}
