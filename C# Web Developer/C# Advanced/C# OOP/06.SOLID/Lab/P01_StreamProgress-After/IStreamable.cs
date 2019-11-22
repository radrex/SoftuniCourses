namespace P01_StreamProgress_After
{
    public interface IStreamable
    {
        //----------- Properties -----------
        int Length { get; }
        int BytesSent { get; }
    }
}
