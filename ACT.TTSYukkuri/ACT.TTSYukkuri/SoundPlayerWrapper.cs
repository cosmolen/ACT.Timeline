namespace ACT.TTSYukkuri
{
    using System.IO;
    using System.Windows.Forms;

    using ACT.TTSYukkuri.SoundPlayer;
    using Advanced_Combat_Tracker;

    /// <summary>
    /// DirectXでサウンドを再生する
    /// </summary>
    public static class SoundPlayerWrapper
    {
        /// <summary>
        /// サウンドを再生する
        /// </summary>
        /// <param name="deviceID">デバイスID</param>
        /// <param name="file">再生するファイル</param>
        /// <param name="volume">ボリューム</param>
        public static void Play(
            string deviceID,
            string file,
            int volume)
        {
            PlayCore(deviceID, file, false, volume);
        }

        /// <summary>
        /// サウンドを再生する
        /// </summary>
        /// <param name="deviceID">デバイスID</param>
        /// <param name="file">再生するサウンドファイル</param>
        /// <param name="isFileDelete">ファイルを削除するか？</param>
        /// <param name="volume">ボリューム</param>
        private static void PlayCore(
            string deviceID,
            string file,
            bool isFileDelete,
            int volume)
        {
            if (!File.Exists(file))
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(deviceID))
            {
                return;
            }

            if (ActGlobals.oFormActMain.InvokeRequired)
            {
                ActGlobals.oFormActMain.Invoke((MethodInvoker)delegate
                {
                    NAudioPlayer.Play(
                        deviceID,
                        file,
                        isFileDelete,
                        volume);
                });
            }
            else
            {
                NAudioPlayer.Play(
                    deviceID,
                    file,
                    isFileDelete,
                    volume);
            }
        }
    }
}
