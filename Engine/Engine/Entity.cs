namespace Engine.Engine;
using OpenTK.Mathematics;
public class Entity
{
    public Vector2 Position;
    public Texture Sprite;

    public Entity(Vector2 position, Texture sprite)
    {
        Position = position;
        Sprite = sprite;
    }

    public void Draw()
    {
        Renderer.Render(Sprite);
    }
}