namespace PetStore.Data.Models
{
    public class FoodOrder
    {
        //------------ Food [FK] -----------
        public int FoodId { get; set; }
        public Food Food { get; set; }

        //------------ Order [FK] -----------
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
