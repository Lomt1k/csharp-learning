using System;

/*
 * 1. Класс "Предмет". Должен описывать предмет инвентаря и содержать в 
 * себе поля: Тип предмета, изображение предмета (путь к изображению в 
 * ресурсах).
*/

namespace TestNIITKD
{
    public class Item
    {
        ItemType type; //тип предмета
        string img; //путь к изображению в ресурсах

        //список всех типов предметов
        public enum ItemType
        {
            Apple = 1,
            Banana = 2
        }

        //конструктор
        public Item(ItemType _type, string _extraImg = "")
        {
            type = _type;
            if (_extraImg.Length < 1) //если используется изображение по умолчанию
            {
                switch (type)
                {
                    case ItemType.Apple: img = "pack://siteoforigin:,,,/Resources/apple.png"; break;
                    case ItemType.Banana: img = "pack://siteoforigin:,,,/Resources/banana.png"; break;
                }
            }
            else img = _extraImg; //используется необычное изображение
        }

        #region Свойства
        //тип предмета
        public ItemType Type
        {
            get { return type; }
        }
        //путь к картинке
        public string ImageSource
        {
            get { return img; }
        }
        #endregion


    }
}
