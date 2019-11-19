namespace P03_WildFarm.Contracts
{
    using Models.Foods;

    public interface IEat
    {
        //---------- Methods -----------
        void Eat(Food food);
    }
}
