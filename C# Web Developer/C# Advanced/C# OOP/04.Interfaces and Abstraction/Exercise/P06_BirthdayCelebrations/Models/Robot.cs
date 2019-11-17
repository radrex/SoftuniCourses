namespace P06_BirthdayCelebrations.Models
{
    using P06_BirthdayCelebrations.Interfaces;

    public class Robot : IIdentifiable
    {
        //------------------ Constructors --------------------
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        //------------------- Properties ---------------------
        public string Model { get; private set; }
        public string Id { get; private set; }
    }
}
