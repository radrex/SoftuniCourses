namespace P01_StreamProgress_After
{
    public class Music : IStreamable
    {
        //-------------- Fields ---------------
        private string artist;
        private string album;

        //----------- Constructors ------------
        public Music(string artist, string album, int length, int bytesSent)
        {
            this.artist = artist;
            this.album = album;
            this.Length = length;
            this.BytesSent = bytesSent;
        }

        //------------ Properties -------------
        public int Length { get; set; }
        public int BytesSent { get; set; }
    }
}
