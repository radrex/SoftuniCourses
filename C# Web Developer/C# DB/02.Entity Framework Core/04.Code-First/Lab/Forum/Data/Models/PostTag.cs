namespace Forum.Data.Models
{
    public class PostTag
    {
        //----- Mapping Table / Composite Key -----
        public int PostId { get; set; }
        public Post Post { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
