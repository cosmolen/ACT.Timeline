namespace VoiceTextWebAPI.Client.Internal
{
    public class VoiceTextErrorResponse
    {
        public class VoiceTextError
        {
            public string message { get; set; }
        } 

        public VoiceTextError error { get; set; }
    }
}
