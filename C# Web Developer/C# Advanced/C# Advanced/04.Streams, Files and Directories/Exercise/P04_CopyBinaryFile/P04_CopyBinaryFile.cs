namespace P04_CopyBinaryFile
{
    using System.IO;

    class P04_CopyBinaryFile
    {
        static void Main(string[] args)
        {
            using (FileStream source = new FileStream("../../../copyMe.png", FileMode.Open))
            {
                using (FileStream destination = new FileStream("../../../copied.png", FileMode.Create))
                {
                    while (true)
                    {
                        byte[] buffer = new byte[4096];
                        int bytesCount = source.Read(buffer, 0, buffer.Length);
                        if (bytesCount == 0)
                        {
                            break;
                        }
                        destination.Write(buffer, 0, bytesCount);
                    }
                }
            }
        }
    }
}
