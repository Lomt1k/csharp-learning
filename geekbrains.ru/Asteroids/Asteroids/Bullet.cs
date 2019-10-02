using System;
using System.Drawing;

namespace MyGame
{
    class Bullet : BaseObject //класс пули, которую может выстреливать корабль игрока
    {
        Image img = Image.FromFile("data/images/bullet.png");
        
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        //отрисовка на экране
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(img, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        //физика и механика (срабатывает каждые 25 мс)
        public override void Update()
        {
            Pos.X = Pos.X + 3;
        }

        public override void Destroy()
        {
            Pos.X = 9999;//уничтожение (за пределами карты)
        }
    }
}