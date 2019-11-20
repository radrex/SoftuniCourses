//namespace P04_Collector
//{
    public class Hacker
    {
        //----------------- Fields -----------------
        public string username = "securityGod82";
        private string password = "mySuperSecretPassw0rd";

        //--------------- Properties ---------------
        public string Password
        {
            get => this.password;
            set => this.password = value;
        }

        private int Id { get; set; }

        public double BankAccountBalance { get; private set; }

        //---------------- Methods -----------------
        public void DownloadAllBankAccountsInTheWorld()
        {
        }
    }
//}
