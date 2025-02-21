using OpenTK.Windowing.Desktop;

namespace Engine.Engine;
using OpenTK.Windowing.GraphicsLibraryFramework;
public class InputManager
{
    private KeyboardState keyboardState;

    public void Update()
    {
        keyboardState = GLFW.GetKey(OpenTK.Windowing.Desktop.NativeWindowSettings.Default.Handle);
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