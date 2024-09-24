using Raylib_cs;
using RaylibTest;

class Program
{
    private int posx, posy = 0;

    // @Hack: Controls sprite movement for now
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
        // @Note: Initialize Game Variables, etc...
        Program p = new();
        Screen s = new(1280, 720); // @Note: Get The Current GUI Window Dimensions
        Text app_name = new("Raylib C# Demo", s.screen_width / 2 - 250, s.screen_height / 2 - 350, 75, Color.Black);
        GAME_STATE mode = GAME_STATE.MAIN;

        // @Note: Hello World Button
        Rectangle start_btn_rect = new(s.screen_width/2 - 100, s.screen_height/2 - 200, 200, 100);
        TextButton start_btn = new("Hello World", start_btn_rect, Color.Gold, Color.Black, Color.Lime, (int)(start_btn_rect.X*1.03), (int)(start_btn_rect.Y*1.25), 30);

        // @Note: Snake Button
        Rectangle snake_game_btn_rect = new(s.screen_width / 2 - 100, s.screen_height / 2 - 50, 200, 100);
        TextButton snake_game_btn = new("Snake", snake_game_btn_rect, Color.SkyBlue, Color.Black, Color.Purple, (int)(snake_game_btn_rect.X*1.03), (int)(snake_game_btn_rect.Y*1.11), 30);

        // @Note: Invaders Button
        Rectangle invaders_game_btn_rect = new(s.screen_width / 2 - 100, s.screen_height / 2 + 100, 200, 100);
        TextButton invaders_game_btn = new("Invaders", invaders_game_btn_rect, Color.DarkPurple, Color.Black, Color.White, (int)(invaders_game_btn_rect.X*1.03), (int)(invaders_game_btn_rect.Y*1.11), 30);

        // @Note: Initialize window
        Raylib.InitWindow(s.screen_width, s.screen_height, "Raylib C# Demo");
        Raylib.SetTargetFPS(60);
        Console.WriteLine($"Window Dimensions(width:{s.screen_width}, height:{s.screen_height})");

        while (!Raylib.WindowShouldClose())
        {
            p.update();

            // @Note: Window Draw Code
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.RayWhite); // @Note: Refresh the Window with a Static Color

            switch (mode)
            {
                case GAME_STATE.MAIN:
                    app_name.draw_text();
                    if (start_btn.draw_text_button())
                    {
                        Console.WriteLine("Starting HELLO_WORLD MODE");
                        mode = GAME_STATE.HELLO_WORLD;
                    }

                    if (snake_game_btn.draw_text_button())
                    {
                        Console.WriteLine("Starting SNAKE GAME");
                        mode = GAME_STATE.SNAKE;
                    }

                    if (invaders_game_btn.draw_text_button())
                    {
                        Console.WriteLine("Starting INVADERS GAME");
                        mode = GAME_STATE.INVADERS;
                    }
                    break;

                case GAME_STATE.HELLO_WORLD:
                    Sprite sprite = new("Player", 100, 50);
                    Raylib.DrawText("Hallo from Raylib C#", s.screen_height / 2, s.screen_height / 2, 50, Color.Black);
                    Raylib.DrawText("use WASD OR Arrow Keys to move", s.screen_height / 2, s.screen_height/ 2 + 100, 35, Color.Black);
                    sprite.draw_sprite(p.posx, p.posy); //@Note: player draw code
                    break;

                case GAME_STATE.SNAKE:
                    break;

                case GAME_STATE.INVADERS:
                    break;
            }

            //@Note: Close the Window Once you done
            Raylib.EndDrawing();
        }
        Raylib.CloseWindow();
    }
}