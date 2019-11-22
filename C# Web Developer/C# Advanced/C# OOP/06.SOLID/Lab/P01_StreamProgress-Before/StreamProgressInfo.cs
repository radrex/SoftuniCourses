namespace P01_StreamProgress_Before
{
    public class StreamProgressInfo
    {
        //-------------- Fields ---------------
        private File file;

        //----------- Constructors ------------
        // If we want to stream a music file, we can't
        public StreamProgressInfo(File file)
        {
            this.file = file;
        }

        //------------- Methods ---------------
        public int CalculateCurrentPercent()
        {
            return (this.file.BytesSent * 100) / this.file.Length;
        }
    }
}
