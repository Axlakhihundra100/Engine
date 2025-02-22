
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
namespace Engine.Engine
{
    public static class Renderer
    {
        private static int shaderProgram;
        private static int vao;
        private static int vbo;
        private static int ebo;

        public static void Init()
        {
            float[] vertices = {
                -0.5f, -0.5f, 0f,  0f, 0f,
                 0.5f, -0.5f, 0f,  1f, 0f,
                 0.5f,  0.5f, 0f,  1f, 1f,
                -0.5f,  0.5f, 0f,  0f, 1f
            };

            int[] indices = {
                0, 1, 2,
                2, 3, 0
            };
            vao = GL.GenVertexArray();
            GL.BindVertexArray(vao);

            vbo = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

            ebo = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ebo);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(int), indices, BufferUsageHint.StaticDraw);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), 3 * sizeof(float));
            GL.EnableVertexAttribArray(1);

            shaderProgram = Shader.Load("Shaders/vertex.glsl", "Shaders/fragment.glsl");
            GL.UseProgram(shaderProgram);
        }

        public static void Render(Texture texture, Vector2 position, Vector2 scale)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            texture.Bind();
            GL.UseProgram(shaderProgram);
            GL.BindVertexArray(vao);

            Matrix4 model = Matrix4.CreateTranslation(new Vector3(scale.X, scale.Y, 1))*Matrix4.CreateTranslation(new Vector3(position.X, position.Y, 0));
            int modelLoc = GL.GetUniformLocation(shaderProgram, "model");
            GL.UniformMatrix4(modelLoc, false, ref model);
            
            GL.DrawElements(PrimitiveType.Triangles, 6, DrawElementsType.UnsignedInt, 0);
        }
        
        
    }
}
