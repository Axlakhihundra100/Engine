namespace Engine.Engine;
using OpenTK.Mathematics;
public class Character
{
    public Vector2 Position;
    private Texture Sprite;
    private float Speed = 2.0f;


    public Character(Vector2 startPosition, string texturePath)
    {
        Position = startPosition;
        Sprite = new Texture(texturePath);
    }

    public void Update(float deltaTime, InputManager input)
    {
        Vector2 movement = Vector2.Zero;
        if (input.IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.W))
            movement.Y += 1;
        if (input.IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.S))
            movement.Y -= 1;
        if (input.IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.A))
            movement.X -= 1;
        if (input.IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.D))
            movement.X += 1;
        if (movement.Length > 0)
        {
            movement = movement.Normalized();
            Position += movement * Speed * deltaTime;
        }
    }

    public void draw()
    {
        Renderer.Render(Sprite, Position);
    }
    
}