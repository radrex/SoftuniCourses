namespace PetStore.Services.Implementations
{
    using Data;

    public class OrderService : IOrderService
    {
        //----------------- Fields ------------------
        private readonly PetStoreDbContext context;

        //-------------- Constructors ---------------
        public OrderService(PetStoreDbContext context)
        {
            this.context = context;
        }

        //---------------- Methods ------------------
        public void CompleteOrder(int orderId)
        {
            var order = this.context.Orders.Find(orderId);
            order.Status = Data.Models.Enums.OrderStatus.Done;
            this.context.SaveChanges();
        }
    }
}
