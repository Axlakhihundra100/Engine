using OpenTK.Graphics.ES11;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;

namespace Engine.Engine;

class Game : GameWindow
{
    private Texture backgroundTexture;
    private Player player;
    private InputManager input;
    public Game() : base(GameWindowSettings.Default, NativeWindowSettings.Default) {}
    private Texture texture;
    
    protected override void OnLoad()
    {
        input = new InputManager(this);
        base.OnLoad();
        Renderer.Init();
        backgroundTexture = new Texture("C:\\Users\\AxelEngan\\RiderProjects\\Engine\\Engine\\Assets\\bobfa.png");
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
        GL.Clear(ClearBufferMask.ColorBufferBit);
        Renderer.Render(backgroundTexture, new Vector2(0,0), new Vector2(2.0f,2.0f));
        player.Draw();
        SwapBuffers();
    }

    protected override void OnUnload()
    {
        base.OnUnload();
        backgroundTexture.Delete();
        player = null;
        backgroundTexture = null;
    }
}