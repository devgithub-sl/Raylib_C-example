using Raylib_cs;
using RaylibTest;

class Program
{
    private int window_width;
    private int window_height;
    private Sprite sprite;
    private int posx, posy = 0;

    Program()
    {
        window_width = 1280;
        window_height = 720;
        sprite = new Sprite("Player", 100, 50);
    }

    private void update()
    {
        if (Raylib.IsKeyDown(KeyboardKey.W) || Raylib.IsKeyDown(KeyboardKey.Up))
        {
            posy -= 10;
            Console.WriteLine("Moving Up");
        }
        else if (Raylib.IsKeyDown(KeyboardKey.A) || Raylib.IsKeyDown(KeyboardKey.Left))
        {
            posx -= 10;
            Console.WriteLine("Moving Left");
        }
        else if (Raylib.IsKeyDown(KeyboardKey.S) || Raylib.IsKeyDown(KeyboardKey.Down))
        {
            posy += 10;
            Console.WriteLine("Moving Down");
        }

        else if (Raylib.IsKeyDown(KeyboardKey.D) || Raylib.IsKeyDown(KeyboardKey.Right))
        {
            posx += 10;
            Console.WriteLine("Moving Right");
        }
    }

    static void Main()
    {
        Program p = new Program();
        GAME_STATE mode = GAME_STATE.MAIN;
        Rectangle start_rect = new Rectangle(100, 100, 200, 100);
        TextButton start = new TextButton("Start", start_rect, Color.Magenta, Color.Yellow, Color.RayWhite, 
            100,100, 50);


        Raylib.InitWindow(p.window_width, p.window_height, "Test");
        Raylib.SetTargetFPS(60);

        while (!Raylib.WindowShouldClose())
        {
            p.update();

            // Window Draw Code
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RayWhite); // Refresh the Window with a Static Color

            switch (mode)
            {
                case GAME_STATE.MAIN:
                    if (new TextButton().draw_text_button(start))
                    {
                        Console.WriteLine("starting test");
                        mode = GAME_STATE.GAME;
                    }
                    Raylib.DrawText("Click me!!!", p.window_height / 2 - 250, p.window_height / 2 - 195, 25, Color.Black);
                    break;

                case GAME_STATE.GAME:
                    Raylib.DrawText("Hallo from Raylib C#", p.window_height / 2, p.window_height / 2, 50, Color.Black);
                    Raylib.DrawText("use WASD OR Arrow Keys to move", p.window_height / 2, p.window_height/ 2 + 100, 35, Color.Black);
                    p.sprite.draw_player(p.posx, p.posy); // player draw code
                    break;
            }

            // Close the Window Once you done
            Raylib.EndDrawing();
        }
        Raylib.CloseWindow();
    }
}