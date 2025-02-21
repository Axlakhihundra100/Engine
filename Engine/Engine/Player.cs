namespace Engine.Engine;
using OpenTK.Mathematics;
public class Player : Character
{
    public Player(Vector2 startPosition, string texturePath)
        : base(startPosition, texturePath)
    {
        
    }

    public void HandleInput(InputManager input, float deltaTime)
    {
        Update(deltaTime, input);
    }
}