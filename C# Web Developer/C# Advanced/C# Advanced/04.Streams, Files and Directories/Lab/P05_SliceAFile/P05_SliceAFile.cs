namespace P05_SliceAFile
{
    using System;
    using System.IO;

    class P05_SliceAFile
    {
        static void Main(string[] args)
        {
            long size = new FileInfo("sliceMe.txt").Length;
            int sizePerFile = (int)Math.Ceiling(size / 4.0);

            using (FileStream reader = new FileStream("sliceMe.txt", FileMode.Open))
            {
                for (int i = 1; i <= 4; i++)
                {
                    byte[] buffer = new byte[sizePerFile];
                    int readBytes = reader.Read(buffer, 0, sizePerFile);
                    using (FileStream writer = new FileStream($"../../../Part-{i}.txt", FileMode.OpenOrCreate))
                    {
                        writer.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}
