using System;
using System.Drawing;

namespace MyGame
{
    class Asteroid : BaseObject
    {
        public int Power { get; set; }
        Image img = Image.FromFile("data/images/asteroid.png");

        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = 1;
        }

        //отрисовка на экране
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(img, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        //физика и механика (срабатывает каждые 25 мс)
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0)
            {
                Destroy();
            }
        }

        //метод для уничтожения / респавна астероида
        public override void Destroy()
        {
            Pos.X = Game.Width + Size.Width;
            var rand = new Random();
            Pos.Y = rand.Next(100, Game.Height - 100);
        }
    }
}
