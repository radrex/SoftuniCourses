namespace PlayersAndMonsters.IO
{
    using PlayersAndMonsters.IO.Contracts;
    using System;
    using System.IO;

    public class FileWriter : IWriter
    {
        //-------------- Fields ---------------
        private FileStream fileStream;
        private StreamWriter streamWriter;

        //----------- Constructors ------------
        public FileWriter()
        {
            this.fileStream = new FileStream("../../../ouput.txt", FileMode.OpenOrCreate, FileAccess.Write);
            this.streamWriter = new StreamWriter(fileStream);

            this.streamWriter.AutoFlush = true;

            Console.SetOut(streamWriter);
        }

        //-------------- Methods --------------
        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
