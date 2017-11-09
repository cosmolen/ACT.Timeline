namespace ACT.TTSYukkuri.Config
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Xml.Serialization;

    [Serializable]
    public class OpenJTalkConfig
    {
        public OpenJTalkConfig()
        {
            this.SetDefault();
        }

        public string Voice { get; set; }

        public int Gain { get; set; }

        public int Volume { get; set; }

        public int Speed { get; set; }

        public int Pitch { get; set; }

        public void SetDefault()
        {
            this.Voice = "mei_normal.htsvoice";
            this.Gain = 100;
            this.Volume = 100;
            this.Speed = 100;
            this.Pitch = 0;
        }

        [XmlIgnore]
        public string OpenJTalkDirectory
        {
            get
            {
                // ACTのパスを取得する
                var asm = Assembly.GetEntryAssembly();
                if (asm != null)
                {
                    var actDirectory = Path.GetDirectoryName(asm.Location);
                    var resourcesUnderAct = Path.Combine(actDirectory, @"OpenJTalk");

                    if (Directory.Exists(resourcesUnderAct))
                    {
                        return resourcesUnderAct;
                    }
                }

                // 自身の場所を取得する
                var selfDirectory = TTSYukkuriPlugin.PluginDirectory ?? string.Empty;
                var resourcesUnderThis = Path.Combine(selfDirectory, @"OpenJTalk");

                if (Directory.Exists(resourcesUnderThis))
                {
                    return resourcesUnderThis;
                }

                return string.Empty;
            }
        }

        public OpenJTalkVoice[] EnumlateVoice()
        {
            var list = new List<OpenJTalkVoice>();

            var openTalk = this.OpenJTalkDirectory;

            if (string.IsNullOrWhiteSpace(openTalk))
            {
                return list.ToArray();
            }

            var voice = Path.Combine(
                openTalk,
                "voice");

            if (Directory.Exists(voice))
            {
                foreach (var item in Directory.GetFiles(voice, "*.htsvoice")
                    .OrderBy(x => x)
                    .ToArray())
                {
                    list.Add(new OpenJTalkVoice()
                    {
                        File = item
                    });
                }
            }

            return list.ToArray();
        }

        public override string ToString()
        {
            var t = string.Empty;

            t += this.Voice;
            t += this.Gain.ToString();
            t += this.Volume.ToString();
            t += this.Speed.ToString();
            t += this.Pitch.ToString();

            return t;
        }
    }

    [Serializable]
    public class OpenJTalkVoice
    {
        public string Value
        {
            get
            {
                return Path.GetFileName(this.File);
            }
        }

        public string Name
        {
            get
            {
                return Path.GetFileName(this.File);
            }
        }

        public string File { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
