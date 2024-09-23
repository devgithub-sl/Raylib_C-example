using Raylib_cs;

class Program
{
    static void Main()
    {
        int window_width = 1280;
        int window_height = 720;
        Raylib.InitWindow(window_width, window_height, "Test");
        Raylib.SetTargetFPS(60);
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RayWhite);
            Raylib.DrawText("Hallo from Raylib C#", window_height / 2, window_height / 2, 50, Color.Black);
            Raylib.EndDrawing();
        }
        Raylib.CloseWindow();
    }
}