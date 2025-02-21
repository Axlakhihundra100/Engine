namespace Engine.Engine;

public interface IScene
{
    void Load();
    void Unload();
    void Update(double deltaTime);
    void Render();
}