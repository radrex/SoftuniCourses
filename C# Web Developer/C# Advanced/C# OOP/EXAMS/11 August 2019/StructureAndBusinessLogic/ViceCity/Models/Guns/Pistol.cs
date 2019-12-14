namespace ViceCity.Models.Guns
{
    using ViceCity.Models.Guns.Contracts;

    public class Pistol : Gun, IGun
    {
        //-------------- Fields ---------------
        private const int InitialBulletsPerBarrel = 10;
        private const int InitialTotalBullets = 100;
        private const int InitialBulletShootCount = 1;

        //----------- Constructors ------------
        public Pistol(string name) 
            : base(name, InitialBulletsPerBarrel, InitialTotalBullets)
        {

        }

        //-------------- Methods --------------
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
