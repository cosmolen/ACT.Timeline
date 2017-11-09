namespace ACT.TTSYukkuri.TTSServer.Core
{
    using System;

    public enum TTSTEngineType
    {
        Yukkuri = 0,
        CeVIO = 1
    }

    [Serializable]
    public class TTSMessage : MarshalByRefObject
    {
        public override object InitializeLifetimeService()
        {
            return null;
        }

        [Serializable]
        public class SpeakEventArg : EventArgs
        {
            public TTSTEngineType TTSType { get; set; }
            public string TextToSpeack { get; set; }
            public int SpeakSpeed { get; set; }
            public string WaveFile { get; set; }
        }

        [Serializable]
        public class SasaraSettingsEventArg : EventArgs
        {
            public SasaraSettings Settings { get; set; }
        }

        public delegate bool OnIsReadyDelegate();

        public event OnIsReadyDelegate OnIsReady;

        public bool IsReady()
        {
            if (this.OnIsReady != null)
            {
                return this.OnIsReady();
            }

            return false;
        }

        public delegate void OnSpeakDelegate(SpeakEventArg e);

        public event OnSpeakDelegate OnSpeak;

        public void Speak(SpeakEventArg e)
        {
            if (this.OnSpeak != null)
            {
                this.OnSpeak(e);
            }
        }

        public delegate SasaraSettings GetSasaraSettingsDelegate();

        public event GetSasaraSettingsDelegate OnGetSasaraSettings;

        public SasaraSettings GetSasaraSettings()
        {
            if (this.OnGetSasaraSettings != null)
            {
                return this.OnGetSasaraSettings();
            }

            return null;
        }

        public delegate void SetSasaraSettingsDelegate(SasaraSettingsEventArg e);

        public event SetSasaraSettingsDelegate OnSetSasaraSettings;

        public void SetSasaraSettings(SasaraSettingsEventArg e)
        {
            if (this.OnSetSasaraSettings != null)
            {
                this.OnSetSasaraSettings(e);
            }
        }

        public delegate void OnStartSasaraDelegate();

        public event OnStartSasaraDelegate OnStartSasara;

        public void StartSasara()
        {
            if (this.OnStartSasara != null)
            {
                this.OnStartSasara();
            }
        }

        public delegate void OnCloseSasaraDelegate();

        public event OnCloseSasaraDelegate OnCloseSasara;

        public void CloseSasara()
        {
            if (this.OnCloseSasara != null)
            {
                this.OnCloseSasara();
            }
        }

        public delegate void OnEndDelegate();

        public event OnEndDelegate OnEnd;

        public void End()
        {
            if (this.OnEnd != null)
            {
                this.OnEnd();
            }
        }
    }

    [Serializable]
    public class SasaraSettings
    {
        public uint Volume { get; set; }
        public uint Speed { get; set; }
        public uint Tone { get; set; }
        public uint Alpha { get; set; }
        public uint ToneScale { get; set; }
        public string Cast { get; set; }
        public string[] AvailableCasts { get; set; }
        public SasaraTalkerComponent[] Components { get; set; }
    }

    [Serializable]
    public class SasaraTalkerComponent
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public uint Value { get; set; }
    }
}
