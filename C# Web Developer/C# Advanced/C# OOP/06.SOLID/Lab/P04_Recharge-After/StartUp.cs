namespace P04_Recharge_After
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee("1");
            Robot robot = new Robot("2", 12);

            employee.Work(2);
            employee.Sleep();

            robot.Recharge();
            robot.Work(5);
        }
    }
}
