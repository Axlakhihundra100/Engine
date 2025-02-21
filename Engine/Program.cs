using Engine.Engine;

class Program
{
    static void Main()
    {
        using (Game game = new Game())
        {
            game.Run();
        }
    }
}