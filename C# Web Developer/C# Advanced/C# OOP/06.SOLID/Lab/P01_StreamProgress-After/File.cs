namespace P01_StreamProgress_After
{
    public class File : IStreamable
    {
        //-------------- Fields ---------------
        private string name;

        //----------- Constructors ------------
        public File(string name, int length, int bytesSent)
        {
            this.name = name;
            this.Length = length;
            this.BytesSent = bytesSent;
        }

        //------------ Properties -------------
        public int Length { get; set; }
        public int BytesSent { get; set; }
    }
}
