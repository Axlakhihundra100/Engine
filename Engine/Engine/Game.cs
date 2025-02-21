using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;

namespace Engine.Engine;

class Game : GameWindow
{
    private Player player;
    private InputManager input;
    public Game() : base(GameWindowSettings.Default, NativeWindowSettings.Default) {}
    private Texture texture;
    
    protected override void OnLoad()
    {
        base.OnLoad();
        Renderer.Init();
        texture = new Texture("C:\\Users\\AxelEngan\\RiderProjects\\Engine\\Engine\\Assets\\bobfa.png");
        input = new InputManager();
        player = new Player(new Vector2(0.0f, 0.0f),
            "C:\\Users\\AxelEngan\\RiderProjects\\Engine\\Engine\\Assets\\player.png");
    }

    protected override void OnUpdateFrame(FrameEventArgs args)
    {
        base.OnUpdateFrame(args);
        input.Update();
        player.Update((float)args.Time, input);
        InputManager.HandleInput(this);
        SceneManager.Update(args.Time);
    }

    protected override void OnRenderFrame(FrameEventArgs args)
    {
        base.OnRenderFrame(args);
        Renderer.Render(texture);
        player.draw();
        SwapBuffers();
    }

    protected override void OnUnload()
    {
        base.OnUnload();
        texture.Delete();
        player = null;
    }
}