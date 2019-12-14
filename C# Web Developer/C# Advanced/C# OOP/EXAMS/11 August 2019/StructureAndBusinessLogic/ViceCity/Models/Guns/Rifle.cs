namespace ViceCity.Models.Guns
{
    using ViceCity.Models.Guns.Contracts;

    public class Rifle : Gun, IGun
    {
        //-------------- Fields ---------------
        private const int InitialBulletsPerBarrel = 50;
        private const int InitialTotalBullets = 500;
        private const int InitialBulletShootCount = 5;

        //----------- Constructors ------------
        public Rifle(string name) 
            : base(name, InitialBulletsPerBarrel, InitialTotalBullets)
        {

        }

        public override int Fire()
        {
            if (this.CanFire)
            {
                this.TotalBullets -= InitialBulletShootCount;
                return InitialBulletShootCount;
            }

            return 0; // No more bullets
        }
    }
}
