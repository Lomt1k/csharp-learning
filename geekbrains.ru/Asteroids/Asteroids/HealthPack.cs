using System;
using System.Drawing;

namespace MyGame
{
    class HealthPack : BaseObject //класс аптечки, которую игрок может подобрать на карте
    {
        public int Power { get; set; }
        Image img = Image.FromFile("data/images/healthpack.png");

        public HealthPack(Point pos, Point dir, Size size) : base(pos, dir, size)
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
            Pos.X = Pos.X + - 5;
            if (Pos.X < 0)
            {
                Destroy();
            }
        }
        
        //метод для уничтожения / респавна аптечки
        public override void Destroy()
        {
            Pos.X = Game.Width + Size.Width;
            var rand = new Random();
            Pos.Y = rand.Next(100, Game.Height - 100);
        }
    }
}

