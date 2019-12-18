namespace P03_JediGalaxy
{
    public class Player
    {
        //------------- Constructors ---------------
        public Player(int rowCoordinates, int colCoordinates)
        {
            this.Row = rowCoordinates;
            this.Col = colCoordinates;
        }

        //-------------- Properties ----------------
        public int Row { get; private set; }
        public int Col { get; private set; }

        //------------ Public Methods --------------
        public void MoveTopRightDiagonal()
        {
            this.Row--;
            this.Col++;
        }

        public void MoveTopLeftDiagonal()
        {
            this.Row--;
            this.Col--;
        }
    }
}
