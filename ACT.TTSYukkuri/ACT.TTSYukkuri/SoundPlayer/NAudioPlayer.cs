namespace ACT.TTSYukkuri.SoundPlayer
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;

    using ACT.TTSYukkuri.Config;
    using Advanced_Combat_Tracker;
    using NAudio.CoreAudioApi;
    using NAudio.Wave;

    /// <summary>
    /// WavePlayers
    /// </summary>
    public enum WavePlayers
    {
        WaveOut,
        DirectSound,
        WASAPI,
        ASIO,
    }

    /// <summary>
    /// NAudioプレイヤー
    /// </summary>
    public partial class NAudioPlayer
    {
        /// <summary>
        /// プレイヤのレイテンシ
        /// </summary>
        private const int PlayerLatencyWaveOut = 128;
        private const int PlayerLatencyDirectSoundOut = 40;
        private const int PlayerLatencyWasapiOut = 80;

        /// <summary>
        /// Device Enumrator
        /// </summary>
        private static MMDeviceEnumerator deviceEnumrator = new MMDeviceEnumerator();

        /// <summary>
        /// 再生デバイスを列挙する
        /// </summary>
        /// <returns>再生デバイスのリスト</returns>
        public static List<PlayDevice> EnumlateDevices()
        {
            switch (TTSYukkuriConfig.Default.Player)
            {
                case WavePlayers.WaveOut:
                    return EnumlateDevicesByWaveOut();

                case WavePlayers.DirectSound:
                    return EnumlateDevicesByDirectSoundOut();

                case WavePlayers.WASAPI:
                    return EnumlateDevicesByWasapiOut();

                case WavePlayers.ASIO:
                    return EnumlateDevicesByAsioOut();
            }

            return null;
        }

        /// <summary>
        /// WaveOutから再生デバイスを列挙する
        /// </summary>
        /// <returns>再生デバイスのリスト</returns>
        public static List<PlayDevice> EnumlateDevicesByWaveOut()
        {
            var list = new List<PlayDevice>();

            for (int i = 0; i < WaveOut.DeviceCount; i++)
            {
                var capabilities = WaveOut.GetCapabilities(i);
                list.Add(new PlayDevice()
                {
                    ID = i.ToString(),
                    Name = capabilities.ProductName,
                });
            }

            return list;
        }

        /// <summary>
        /// DirectSoundOutから再生デバイスを列挙する
        /// </summary>
        /// <returns>再生デバイスのリスト</returns>
        public static List<PlayDevice> EnumlateDevicesByDirectSoundOut()
        {
            var list = new List<PlayDevice>();

            foreach (var device in DirectSoundOut.Devices)
            {
                list.Add(new PlayDevice()
                {
                    ID = device.Guid.ToString(),
                    Name = device.Description,
                });
            }

            return list;
        }

        /// <summary>
        /// WasapiOutから再生デバイスを列挙する
        /// </summary>
        /// <returns>再生デバイスのリスト</returns>
        public static List<PlayDevice> EnumlateDevicesByWasapiOut()
        {
            var list = new List<PlayDevice>();

            foreach (var device in deviceEnumrator.EnumerateAudioEndPoints(
                DataFlow.Render,
                DeviceState.Active))
            {
                list.Add(new PlayDevice()
                {
                    ID = device.ID,
                    Name = device.FriendlyName,
                });
            }

            return list;
        }


        /// <summary>
        /// WasapiOutから再生デバイスを列挙する
        /// </summary>
        /// <returns>再生デバイスのリスト</returns>
        public static List<PlayDevice> EnumlateDevicesByAsioOut()
        {
            var list = new List<PlayDevice>();

            foreach (var name in AsioOut.GetDriverNames())
            {
                list.Add(new PlayDevice()
                {
                    ID = name,
                    Name = name,
                });
            }

            return list;
        }

        /// <summary>
        /// 再生する
        /// </summary>
        /// <param name="deviceID">再生デバイスID</param>
        /// <param name="waveFile">wavファイル</param>
        /// <param name="isDelete">再生後に削除する</param>
        /// <param name="volume">ボリューム</param>
        public static void Play(
            string deviceID,
            string waveFile,
            bool isDelete,
            int volume)
        {
            var sw = Stopwatch.StartNew();

            var volumeAsFloat = ((float)volume / 100f);

            try
            {
                IWavePlayer player = null;
                IWaveProvider provider = null;

                switch (TTSYukkuriConfig.Default.Player)
                {
                    case WavePlayers.WaveOut:
                        player = new WaveOut()
                        {
                            DeviceNumber = int.Parse(deviceID),
                            DesiredLatency = PlayerLatencyWaveOut,
                        };
                        break;

                    case WavePlayers.DirectSound:
                        player = new DirectSoundOut(
                            Guid.Parse(deviceID),
                            PlayerLatencyDirectSoundOut);
                        break;

                    case WavePlayers.WASAPI:
                        player = new WasapiOut(
                            deviceEnumrator.GetDevice(deviceID),
                            AudioClientShareMode.Shared,
                            false,
                            PlayerLatencyWasapiOut);
                        break;

                    case WavePlayers.ASIO:
                        player = new AsioOut(deviceID);
                        break;
                }

                if (player == null)
                {
                    return;
                }

                provider = new AudioFileReader(waveFile)
                {
                    Volume = volumeAsFloat
                };

                player.Init(provider);
                player.PlaybackStopped += (s, e) =>
                {
                    player.Dispose();

                    var file = provider as IDisposable;
                    if (file != null)
                    {
                        file.Dispose();
                    }

                    if (isDelete)
                    {
                        File.Delete(waveFile);
                    }
                };

                // 再生する
                player.Play();
            }
            catch (Exception ex)
            {
                ActGlobals.oFormActMain.WriteExceptionLog(
                    ex,
                    "サウンドの再生で例外が発生しました。");
            }
            finally
            {
                sw.Stop();
                Debug.WriteLine(
                    "PlaySound ({0}) -> {1:N0} ticks",
                    TTSYukkuriConfig.Default.Player,
                    sw.ElapsedTicks);
            }
        }

        /// <summary>
        /// プレイヤを開放する
        /// </summary>
        public static void DisposePlayers()
        {
            // NO-OP
        }
    }

    /// <summary>
    /// 再生デバイス
    /// </summary>
    public class PlayDevice
    {
        /// <summary>
        /// デバイスのID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// デバイス名
        /// </summary>
        public string Name { get; set; }
    }
}
