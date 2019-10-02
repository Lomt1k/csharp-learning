using System;
using System.Windows.Forms;
using System.Drawing;
namespace MyGame
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static BaseObject[] _objs;
        public static Asteroid[] _asteroids;
        private static Bullet _bullet;        
        private static Timer _timer = new Timer();
        public static Random Rnd = new Random();
        private static Ship _ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(80, 42));
        private static HealthPack _healthpack = new HealthPack(new Point(500, 400), new Point(5, 5), new Size(21, 30));
        private static int score;

        static Game()
        {
        }
        public static void Init(Form form)
        {
            // Графическое устройство для вывода графики
            Graphics g;
            // предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();// Создаём объект - поверхность рисования и связываем его с формой
                                      // Запоминаем размеры формы
            Width = form.Width;
            Height = form.Height;
            if (Width > 1000 || Width < 0 || Height > 1000 || Height < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            // Связываем буфер в памяти с графическим объектом.
            // для того, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Load();
            _timer = new Timer { Interval = 25 };
            _timer.Start();
            _timer.Tick += Timer_Tick;
            form.KeyDown += Form_KeyDown; //добавляем обработчик нажатия клавиши
            Ship.MessageDie += Finish;
        }

        //обработчик нажатия клавиш
        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) _bullet = new Bullet(new Point(_ship.Pos.X + 50, _ship.Pos.Y + 14), new Point(5, 0), new Size(38, 15));
            if (e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.Down) _ship.Down();
        }

        //загрузка объектов при старте игры
        public static void Load()
        {
            _objs = new BaseObject[30];
            _asteroids = new Asteroid[4];
            var rnd = new Random();
            for (var i = 0; i < _objs.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _objs[i] = new Star(new Point(1000, rnd.Next(0, Game.Height)), new Point(-r, r), new Size(3, 3));
            }
            for (var i = 0; i < _asteroids.Length; i++)
            {
                int r = rnd.Next(15, 60);
                _asteroids[i] = new Asteroid(new Point(1000, rnd.Next(0, Game.Height)), new Point(-r / 3, r), new Size(r, r));
            }
        }

        //отрисовка объектов, интерфейса и прочего на экране
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();
            foreach (Asteroid a in _asteroids)
            {
                a?.Draw();
            }
            _bullet?.Draw();
            _ship?.Draw();
            if (_ship != null) Buffer.Graphics.DrawString("Энергия:" + _ship.Energy + "   Очков: " + score, SystemFonts.DefaultFont, Brushes.White, 0, 0);
            _healthpack?.Draw();
            Buffer.Render();
        }

        public static void Update() //обновление игровой логики (в основном обработка столкновений) - вызывается каждые 25 мс!
        {
            foreach (BaseObject obj in _objs)
            {
                obj.Update(); //обновляем физику всех базовых объектов карты
            }
            _bullet?.Update(); //обновляем физику пули если она существует

            //астероиды
            for (var i = 0; i < _asteroids.Length; i++)
            {                
                if (_asteroids[i] == null) continue;
                _asteroids[i].Update();

                //если существует пуля - проверяем её на столкновение с астероидом
                if (_bullet != null && _bullet.Collision(_asteroids[i]))
                {
                    score += 10;
                    System.Media.SystemSounds.Hand.Play();
                    _asteroids[i].Destroy();
                    _bullet.Destroy();
                    continue;            
                }

                //корабль - проверяем столкновение с астероидом
                if (_ship.Collision(_asteroids[i]))
                {
                    var rnd = new Random();
                    _ship?.EnergyLow(rnd.Next(1, 10));
                }
            }

            _healthpack?.Update(); //обновляем физику аптечки если она существует
            if (_bullet != null && _bullet.Collision(_healthpack)) //если пуля существует и попала в аптечку - ломаем аптечку 
            {
                _healthpack.Destroy();
                _bullet.Destroy();
            }

            if (_ship.Collision(_healthpack)) //если корабль сталкивается с аптечкой ("подбирает аптечку")
            {
                _ship?.EnergyUp(50); 
                _healthpack.Destroy();
            }
        }

        //таймер, срабатывающий каждые 25 мс (40 раз в секунду)
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        //конец игры
        public static void Finish()
        {
            _timer.Stop();
            Buffer.Graphics.DrawString("Это Конец", new Font(FontFamily.GenericSansSerif, 60,
            FontStyle.Underline), Brushes.White, 200, 100);
            Buffer.Render();
        }

    }
}