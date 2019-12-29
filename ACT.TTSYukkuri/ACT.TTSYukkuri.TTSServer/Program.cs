namespace ACT.TTSYukkuri.TTSServer
{
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.Remoting;
    using System.Runtime.Remoting.Channels;
    using System.Runtime.Remoting.Channels.Ipc;

    using ACT.TTSYukkuri.TTSServer.Core;

    public static class Program
    {
        private static object lockObject = new object();

        private static IpcServerChannel channel;

        private static bool isSasaraStarted;

        public static void Main(string[] args)
        {
            channel = new IpcServerChannel("TTSYukkuriChannel");

            ChannelServices.RegisterChannel(channel, true);

            var message = new TTSMessage();
            RemotingServices.Marshal(message, "message", typeof(TTSMessage));

            message.OnIsReady += () => { return true; };
            message.OnSpeak += message_OnSpeak;
            message.OnGetSasaraSettings += message_OnGetSasaraSettings;
            message.OnSetSasaraSettings += message_OnSetSasaraSettings;
            message.OnStartSasara += message_OnStartSasara;
            message.OnCloseSasara += message_OnCloseSasara;
            message.OnEnd += message_OnEnd;

            Console.WriteLine("Listening on " + channel.GetChannelUri());

            // 終了を待つ
            Console.ReadLine();
        }

        private static void message_OnEnd()
        {
            try
            {
                if (channel != null)
                {
                    ChannelServices.UnregisterChannel(channel);
                    channel = null;
                }

                YukkuriController.Default.Free();

                if (isSasaraStarted)
                {
                    SasaraController.Default.CloseSasara();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Catched Exception on End");
                Console.WriteLine(ex.ToString());
            }
        }

        private static void message_OnSpeak(TTSMessage.SpeakEventArg e)
        {
            switch (e.TTSType)
            {
                case TTSTEngineType.Yukkuri:
                    SpeakByYukkuri(e);
                    break;

                case TTSTEngineType.CeVIO:
                    SpeakBySasara(e);
                    break;
            }
        }

        private static void SpeakByYukkuri(TTSMessage.SpeakEventArg e)
        {
            lock (lockObject)
            {
                YukkuriController.Default.OutputWaveToFile(
                    e.TextToSpeack,
                    (ushort)e.SpeakSpeed,
                    e.WaveFile);
            }
        }

        private static void SpeakBySasara(TTSMessage.SpeakEventArg e)
        {
            lock (lockObject)
            {
                SasaraController.Default.OutputWaveToFile(
                    e.TextToSpeack,
                    e.WaveFile);

                isSasaraStarted = true;
            }
        }

        private static void message_OnStartSasara()
        {
            SasaraController.Default.StartSasara();
            isSasaraStarted = true;
        }

        private static void message_OnCloseSasara()
        {
            SasaraController.Default.CloseSasara();
            isSasaraStarted = false;
        }

        private static SasaraSettings message_OnGetSasaraSettings()
        {
            var settings = SasaraController.Default.GetSasaraSettings();
            isSasaraStarted = true;
            return settings;
        }

        private static void message_OnSetSasaraSettings(TTSMessage.SasaraSettingsEventArg e)
        {
            SasaraController.Default.SetSasaraSettings(e.Settings);
            isSasaraStarted = true;
        }
    }
}
