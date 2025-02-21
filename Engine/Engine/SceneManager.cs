namespace Engine.Engine;

public static class SceneManager
{
    private static IScene currentScene;

    public static void LoadScene(IScene newScene)
    {
        currentScene?.Unload();
        currentScene = newScene;
        currentScene.Load();
    }

    public static void Update(double deltaTime)
    {
        currentScene?.Update(deltaTime);
    }

    public static void Render()
    {
        currentScene?.Render();
    }
}