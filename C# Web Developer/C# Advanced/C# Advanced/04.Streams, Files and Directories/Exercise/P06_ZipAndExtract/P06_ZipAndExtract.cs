namespace P06_ZipAndExtract
{
    using System.IO.Compression;

    class P06_ZipAndExtract
    {
        static void Main(string[] args)
        {
            string startPath = "../../../Images";
            string zipPath = "../../../Zipped/zippedFile.zip";
            string extractPath = "../../../Unzipped";

            ZipFile.CreateFromDirectory(startPath, zipPath);
            ZipFile.ExtractToDirectory(zipPath, extractPath);
        }
    }
}
