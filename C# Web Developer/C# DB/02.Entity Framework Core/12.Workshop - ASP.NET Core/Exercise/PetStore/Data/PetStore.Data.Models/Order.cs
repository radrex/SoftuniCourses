namespace PetStore.Data.Models
{
    using Enums;
    using System;
    using System.Collections.Generic;

    public class Order
    {
        //------------ Properties ------------
        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public OrderStatus Status { get; set; }

        //------------ User [FK] -----------
        public int UserId { get; set; }
        public User User { get; set; }

        //------------ Pet [FK] -----------
        public ICollection<Pet> Pets { get; set; } = new HashSet<Pet>();

        //------------ FoodOrder [FK] MAPPING TABLE -----------
        public ICollection<FoodOrder> Foods { get; set; } = new HashSet<FoodOrder>();

        //------------ ToyOrder [FK] MAPPING TABLE -----------
        public ICollection<ToyOrder> Toys { get; set; } = new HashSet<ToyOrder>();

    }
}
