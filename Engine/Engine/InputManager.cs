using OpenTK.Windowing.Desktop;

namespace Engine.Engine;
using OpenTK.Windowing.GraphicsLibraryFramework;
public class InputManager
{
    private KeyboardState keyboardState;
    private GameWindow window;


    public InputManager(GameWindow gameWindow)
    {
        window = gameWindow;
    }
    public void Update()
    {
        keyboardState = window.KeyboardState;
    }
    
    public static void HandleInput(GameWindow window)
    {
        var keyboardState = window.KeyboardState;
        
        if (keyboardState.IsKeyDown(Keys.Escape))
        {
            System.Console.WriteLine("Escape Pressed");
        }
    }

    public bool IsKeyDown(Keys key)
    {
        return keyboardState.IsKeyDown(key);
    }
}