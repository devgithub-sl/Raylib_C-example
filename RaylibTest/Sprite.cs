using Raylib_cs;

namespace RaylibTest;

public class Sprite
{
    protected string name;
    protected float health;
    protected int width;
    public int x, y;

    public Sprite(string name, float health, int width)
    {
        this.name = name;
        this.health = health;
        this.width = width;
    }

    public void draw_sprite(int pos_x, int pos_y)
    {
        Raylib.DrawRectangle(pos_x, pos_y, width, width, Color.Red);
    }
}
