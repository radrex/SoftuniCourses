namespace PetStore.Data.Models
{
    public class ToyOrder
    {
        //------------ Food [FK] -----------
        public int ToyId { get; set; }
        public Toy Toy { get; set; }

        //------------ Order [FK] -----------
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
