namespace Game
{
    public interface IGame
    {
        public void Simulate(ref int winAmount, ref int looseAmount, Random rnd);
    }
}
