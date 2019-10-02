using System;
using System.Drawing;
namespace MyGame
{
    abstract class BaseObject
    {
        public Point Pos;
        public Point Dir;
        public Size Size;
        protected BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }
        public abstract void Draw();
        public abstract void Update();
        public abstract void Destroy();
        public delegate void Message();

        //метод для проверки столкновения с объектом
        public bool Collision(BaseObject obj)
        {
            if (obj == null) return false;
            int centerX = Pos.X + Size.Width / 2;
            int centerY = Pos.Y + Size.Height / 2;
            int fullSize = Size.Width * Size.Height;
            int objCenterX = obj.Pos.X + obj.Size.Width / 2;
            int objCenterY = obj.Pos.Y + obj.Size.Height / 2;
            //int objFullSize = obj.Size.Width * obj.Size.Height;

            if (Math.Pow(centerX - objCenterX, 2) + Math.Pow(centerY - objCenterY, 2) < fullSize * 0.7)
                return true;
            else
                return false;
        }
    }
}