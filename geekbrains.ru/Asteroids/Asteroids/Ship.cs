using System.Drawing;
namespace MyGame
{
    class Ship : BaseObject
    {
        Image img = Image.FromFile("data/images/ship.png");
        private int _energy = 100;
        public int Energy => _energy;

        //объем энергии (например, при столкновении с астероидом)
        public void EnergyLow(int n)
        {
            _energy -= n;
            System.Media.SystemSounds.Asterisk.Play();
            if (_energy <= 0) Destroy();
        }

        //восстановление энергии (например, при подборе аптечки)
        public void EnergyUp(int n)
        {
            _energy += n;
            System.Media.SystemSounds.Asterisk.Play();
            if (_energy > 100) _energy = 100;
        }
        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
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
        }

        //при нажатии стрелки ВВЕРХ
        public void Up()
        {
            if (Pos.Y > 0) Pos.Y = Pos.Y - Dir.Y;
        }

        //при нажатии стрелки ВНИЗ
        public void Down()
        {
            if (Pos.Y < Game.Height) Pos.Y = Pos.Y + Dir.Y;
        }

        public static event Message MessageDie;
        public override void Destroy()
        {
            MessageDie?.Invoke();
        }
    }
}