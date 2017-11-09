namespace ACT.TTSYukkuri.Config
{
    using System;
    using System.Text;

    using VoiceTextWebAPI.Client;

    [Serializable]
    public class HOYAConfig
    {
        public HOYAConfig()
        {
            this.APIKey = string.Empty;
            this.SetDefault();
        }

        public string APIKey { get; set; }

        public Speaker Speaker { get; set; }

        public Emotion Emotion { get; set; }

        public EmotionLevel EmotionLevel { get; set; }

        // 50-200
        public int Volume { get; set; }

        // 50-400
        public int Speed { get; set; }

        // 50-200
        public int Pitch { get; set; }

        public void SetDefault()
        {
            this.Speaker = Speaker.Hikari;
            this.Emotion = Emotion.Default;
            this.EmotionLevel = EmotionLevel.Default;
            this.Pitch = 100;
            this.Speed = 100;
            this.Volume = 100;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("{");
            sb.AppendLine("APIKey = " + this.APIKey + ",");
            sb.AppendLine("Speaker = " + this.Speaker.ToString() + ",");
            sb.AppendLine("Emotion = " + this.Emotion.ToString() + ",");
            sb.AppendLine("EmotionLevel = " + this.EmotionLevel.ToString() + ",");
            sb.AppendLine("Volume = " + this.Volume.ToString() + ",");
            sb.AppendLine("Speed = " + this.Speed.ToString() + ",");
            sb.AppendLine("Pitch = " + this.Pitch.ToString() + ",");
            sb.AppendLine("}");

            return sb.ToString();
        }
    }
}
