using System;
using System.Drawing;

namespace MyGame
{
    class Star : BaseObject
    {
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        //отрисовка объекта на экране
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
        }

        //физика и механика (срабатывает каждые 25 мс)
        public override void Update()
        {
            Pos.X = Pos.X + (Dir.X / 2);
            if (Pos.X < 0) Destroy();
        }

        //метод для уничтожения / респавна объекта
        public override void Destroy()
        {
            Pos.X = Game.Width + Size.Width;
        }

    }
}
