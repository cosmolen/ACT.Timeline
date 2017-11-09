namespace ACT.TTSYukkuri.Yukkuri
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    using ACT.TTSYukkuri.Config;
    using ACT.TTSYukkuri.TTSServer;
    using ACT.TTSYukkuri.TTSServer.Core;
    using Advanced_Combat_Tracker;
    using Microsoft.VisualBasic;

    /// <summary>
    /// ゆっくりスピーチコントローラ
    /// </summary>
    public class YukkuriSpeechController :
        SpeechControllerBase,
        ISpeechController
    {
        /// <summary>
        /// ロックオブジェクト
        /// </summary>
        private static object lockObject = new object();

        /// <summary>
        /// 正規表現A-Z
        /// </summary>
        private static Regex regexAZ = new Regex(@"[a-zA-Zａ-ｚＡ-Ｚ]+", RegexOptions.Compiled);

        /// <summary>
        /// 正規表現Num
        /// </summary>
        private static Regex regexNum = new Regex(@"\d+", RegexOptions.Compiled);

        /// <summary>
        /// TTSの設定Panel
        /// </summary>
        public override UserControl TTSSettingsPanel
        {
            get
            {
                return YukkuriSettingsPanel.Default;
            }
        }

        /// <summary>
        /// 初期化する
        /// </summary>
        public override void Initialize()
        {
            // NO-OP
        }

        /// <summary>
        /// テキストを読み上げる
        /// </summary>
        /// <param name="text">読み上げるテキスト</param>
        public override void Speak(
            string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return;
            }

            // 今回の再生データをMD5化したものからwaveファイルの名称を作る
            var wave = ("Yukkuri" + TTSYukkuriConfig.Default.YukkuriSpeed.ToString() + text).GetMD5() + ".wav";
            wave = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                @"anoyetta\ACT\" + wave);

            if (!File.Exists(wave))
            {
                // よみがなに変換する
                var textByYomigana = this.ConvertYomigana(text);

                // サーバに送信する
                var e = new TTSMessage.SpeakEventArg()
                {
                    TTSType = TTSTEngineType.Yukkuri,
                    TextToSpeack = textByYomigana,
                    SpeakSpeed = TTSYukkuriConfig.Default.YukkuriSpeed,
                    WaveFile = wave
                };

                TTSServerController.Message.Speak(e);
            }

            // サブデバイスを再生する
            // サブデバイスは専らVoiceChat用であるため先に鳴動させる
            if (TTSYukkuriConfig.Default.EnabledSubDevice)
            {
                SoundPlayerWrapper.Play(
                    TTSYukkuriConfig.Default.SubDeviceID,
                    wave,
                    TTSYukkuriConfig.Default.EnabledYukkuriVolumeSetting ? TTSYukkuriConfig.Default.YukkuriVolume : 100);
            }

            // メインデバイスを再生する
            SoundPlayerWrapper.Play(
                TTSYukkuriConfig.Default.MainDeviceID,
                wave,
                TTSYukkuriConfig.Default.EnabledYukkuriVolumeSetting ? TTSYukkuriConfig.Default.YukkuriVolume : 100);
        }

        /// <summary>
        /// よみがなに変換する
        /// </summary>
        /// <param name="textToConvert">変換するテキスト</param>
        /// <returns>よみがなに変換したテキスト</returns>
        private string ConvertYomigana(
            string textToConvert)
        {
            var yomigana = textToConvert.Trim();

            // IMEでよみがなに変換する
            ActGlobals.oFormActMain.Invoke((MethodInvoker)delegate
            {
                yomigana = KanjiTranslator.Default.GetYomigana(yomigana);
            });

            // 一旦すべて全角のカタカナに変換する
            yomigana = Strings.StrConv(yomigana, VbStrConv.Wide | VbStrConv.Katakana);

            // ゆっくりの読めない文字を置き換える
            yomigana = yomigana.Replace("ヴァ", "バ");
            yomigana = yomigana.Replace("ヴィ", "ビ");
            yomigana = yomigana.Replace("ヴェ", "ベ");
            yomigana = yomigana.Replace("ヴォ", "ボ");
            yomigana = yomigana.Replace("ヴ", "ブ");

            yomigana = yomigana.Replace("フュ", "ヒュ");
            yomigana = yomigana.Replace("スェ", "スエ");

            yomigana = yomigana.Replace("・", "'");

            // ひらがなに戻す
            yomigana = Strings.StrConv(yomigana, VbStrConv.Hiragana);

            // 半角に戻す
            yomigana = Strings.StrConv(yomigana, VbStrConv.Narrow);

            // スペースを置き換える
            yomigana = yomigana.Replace(" ", "、");
            yomigana = yomigana.Replace("　", "、");

            // 感嘆符を置き換える
            yomigana = yomigana.Replace("!", "。");
            yomigana = yomigana.Replace("！", "。");

            // 記号を置き換える
            yomigana = yomigana.Replace("\"", string.Empty);
            yomigana = yomigana.Replace("#", "しゃーぷ");
            yomigana = yomigana.Replace("$", "どる");
            yomigana = yomigana.Replace("%", "ぱーせ'んと");
            yomigana = yomigana.Replace("&", "あんど");
            yomigana = yomigana.Replace("(", "かっこ");
            yomigana = yomigana.Replace(")", "かっことじ");
            yomigana = yomigana.Replace("*", "あすた");
            yomigana = yomigana.Replace("-", "まいなす");
            yomigana = yomigana.Replace("@", "あっと");

            yomigana = yomigana.Replace(":", "ころん");
            yomigana = yomigana.Replace("<", "しょうなり");
            yomigana = yomigana.Replace("=", "いこーる");
            yomigana = yomigana.Replace(">", "だいなり");

            yomigana = yomigana.Replace("[", "だいかっこ");
            yomigana = yomigana.Replace("\\", "えん");
            yomigana = yomigana.Replace("]", "だいかっことじ");
            yomigana = yomigana.Replace("^", "きゃれっと");
            yomigana = yomigana.Replace("_", "あんだーばー");
            yomigana = yomigana.Replace("{", "ちゅうかっこ");
            yomigana = yomigana.Replace("|", "ぱいぷ");
            yomigana = yomigana.Replace("}", "ちゅうかっことじ");
            yomigana = yomigana.Replace("~", "ちるだ");

            // 半角化した句読点を置き換える
            yomigana = yomigana.Replace("､", "、");
            yomigana = yomigana.Replace("｡", "。");

            // 半角化した長音を置き換える
            yomigana = yomigana.Replace("-", "ー");
            yomigana = yomigana.Replace("ｰ", "ー");

            // アルファベットを置き換える
            yomigana = regexAZ.Replace(
                yomigana,
                (match) =>
                {
                    var replacement = match.Value;
                    replacement = Strings.StrConv(replacement, VbStrConv.Narrow);
                    replacement = Strings.StrConv(replacement, VbStrConv.Uppercase);
                    return replacement;
                });

#if false
            yomigana = yomigana.Replace("A", "あ'るふぁ");
            yomigana = yomigana.Replace("B", "ぶ'らぼー");
            yomigana = yomigana.Replace("C", "ちゃ'ーりー");
            yomigana = yomigana.Replace("D", "で'るた");
            yomigana = yomigana.Replace("E", "え'こー");
            yomigana = yomigana.Replace("F", "ふぉ'っくす");
            yomigana = yomigana.Replace("G", "ご'るふ");
            yomigana = yomigana.Replace("H", "ほ'てる");
            yomigana = yomigana.Replace("I", "い'んど");
            yomigana = yomigana.Replace("J", "じゃ'っく");
            yomigana = yomigana.Replace("K", "き'んぐ");
            yomigana = yomigana.Replace("L", "ら'ぶ");
            yomigana = yomigana.Replace("M", "ま'いく");
            yomigana = yomigana.Replace("N", "のー'べんばー");
            yomigana = yomigana.Replace("O", "お'すかー");
            yomigana = yomigana.Replace("P", "ぴー'たー");
            yomigana = yomigana.Replace("Q", "く'いーん");
            yomigana = yomigana.Replace("R", "ろ'じゃー");
            yomigana = yomigana.Replace("S", "しゅ'がー");
            yomigana = yomigana.Replace("T", "た'んご");
            yomigana = yomigana.Replace("U", "ゆ'にふぉーむ");
            yomigana = yomigana.Replace("V", "び'くたー");
            yomigana = yomigana.Replace("W", "うぃ'りあむ");
            yomigana = yomigana.Replace("X", "え'くすれい");
            yomigana = yomigana.Replace("Y", "や'んきー");
            yomigana = yomigana.Replace("Z", "ぜ'ぶら");
#else
            yomigana = yomigana.Replace("A", "えー");
            yomigana = yomigana.Replace("B", "びー");
            yomigana = yomigana.Replace("C", "しー");
            yomigana = yomigana.Replace("D", "でぃ");
            yomigana = yomigana.Replace("E", "いー");
            yomigana = yomigana.Replace("F", "えふ");
            yomigana = yomigana.Replace("G", "じー");
            yomigana = yomigana.Replace("H", "えいち");
            yomigana = yomigana.Replace("I", "あい");
            yomigana = yomigana.Replace("J", "じぇい");
            yomigana = yomigana.Replace("K", "けー");
            yomigana = yomigana.Replace("L", "える");
            yomigana = yomigana.Replace("M", "えむ");
            yomigana = yomigana.Replace("N", "えぬ");
            yomigana = yomigana.Replace("O", "おー");
            yomigana = yomigana.Replace("P", "ぴー");
            yomigana = yomigana.Replace("Q", "きゅー");
            yomigana = yomigana.Replace("R", "あーる");
            yomigana = yomigana.Replace("S", "えす");
            yomigana = yomigana.Replace("T", "てぃー");
            yomigana = yomigana.Replace("U", "ゆー");
            yomigana = yomigana.Replace("V", "ぶい");
            yomigana = yomigana.Replace("W", "だぶりゅー");
            yomigana = yomigana.Replace("X", "えっくす");
            yomigana = yomigana.Replace("Y", "わい");
            yomigana = yomigana.Replace("Z", "ぜっと");
#endif

            // 数字を音声記号に置き換える
            yomigana = yomigana.Replace("０", "0");
            yomigana = yomigana.Replace("１", "1");
            yomigana = yomigana.Replace("２", "2");
            yomigana = yomigana.Replace("３", "3");
            yomigana = yomigana.Replace("４", "4");
            yomigana = yomigana.Replace("５", "5");
            yomigana = yomigana.Replace("６", "6");
            yomigana = yomigana.Replace("７", "7");
            yomigana = yomigana.Replace("８", "8");
            yomigana = yomigana.Replace("９", "9");

            yomigana = regexNum.Replace(
                yomigana,
                (match) =>
                {
                    return "<NUMK VAL=" + match.Value + ">";
                });

            return yomigana;
        }
    }
}
