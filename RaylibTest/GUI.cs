using Raylib_cs;

namespace RaylibTest;

public readonly struct Screen
{
    public readonly int screen_width;
    public readonly int screen_height;

    public Screen()
    {
        screen_width = Raylib.GetScreenWidth();
        screen_height = Raylib.GetScreenHeight();
    }

    public Screen(int sw, int sh)
    {
        screen_width = sw;
        screen_height = sh;
    }
}

public readonly struct TextButton
{
    readonly string text;
    readonly Rectangle rect;
    readonly Color back_color;
    readonly Color outline_color;
    readonly Color text_color;
    readonly int[] pos = new int[2];
    readonly int font_size;
    readonly bool is_clicked;

    public TextButton(string t, Rectangle r, Color bc, Color oc, Color tc, int posx, int posy, int fs, bool is_clicked = false)
    {
        text = t;
        rect = r;
        back_color = bc;
        outline_color = oc;
        text_color = tc;
        pos[0] = posx;    
        pos[1] = posy;
        font_size = fs;
        this.is_clicked = is_clicked;
    }

    public bool draw_text_button()
    {
        Raylib.DrawRectangleRec(rect, back_color);
        Raylib.DrawRectangleLines((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height, outline_color);

        Raylib.DrawText(text, pos[0], pos[1], font_size, text_color);

        if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), rect) && Raylib.IsMouseButtonPressed(MouseButton.Left) == true)
        {
            return !is_clicked;
        }
        return is_clicked;
    }
}

public readonly struct Text
{
    readonly string value;
    readonly int[] pos = new int[2];
    readonly int font_size;
    readonly Color color;

    public Text(string v, int posx, int posy, int fs, Color c)
    {
        value = v;
        pos[0] = posx;
        pos[1] = posy;
        font_size = fs;
        color = c;
    }

    public void draw_text()
    {
        Raylib.DrawText(value, pos[0], pos[1], font_size, color);
    }
}
