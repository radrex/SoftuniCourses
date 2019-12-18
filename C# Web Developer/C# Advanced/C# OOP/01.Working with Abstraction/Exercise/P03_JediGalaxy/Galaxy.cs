namespace P03_JediGalaxy
{
    public class Galaxy
    {
        //---------------- Fields ------------------
        private int currentStarValue = 0;

        //------------- Constructors ---------------
        public Galaxy(int dimensionX, int dimensionY)
        {
            this.DimensionX = dimensionX;
            this.DimensionY = dimensionY;
            this.GalaxyStars = new int[dimensionX, dimensionY];
            this.SpawnStars();
        }

        //-------------- Properties ----------------
        public int[,] GalaxyStars { get; private set; }
        public int DimensionX { get; private set; }
        public int DimensionY { get; private set; }

        //----------- Private Methods --------------
        private void SpawnStars()
        {
            for (int row = 0; row < this.GalaxyStars.GetLength(0); row++)
            {
                for (int i = 0; i < this.GalaxyStars.GetLength(1); i++)
                {
                    this.GalaxyStars[row, i] = currentStarValue++;
                }
            }
        }
    }
}
