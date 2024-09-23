using Raylib_cs;

namespace RaylibTest;

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

    public bool draw_text_button(TextButton b)
    {
        Raylib.DrawRectangleRec(b.rect, b.back_color);
        Raylib.DrawRectangleLines((int)b.rect.X, (int)b.rect.Y, (int)b.rect.Width, (int)b.rect.Height, b.outline_color);

        Raylib.DrawText(b.text, b.pos[0], b.pos[1], b.font_size, b.text_color);

        if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), b.rect) && Raylib.IsMouseButtonPressed(MouseButton.Left) == true)
        {
            return !b.is_clicked;
        }
        return b.is_clicked;
    }
}
