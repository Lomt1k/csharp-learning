using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

/*
2. Класс "Инвентарь". Должен описывать инвентарь и содержать поля размер
(количество ячеек), а так же поля,
описывающие, в какой ячейке сколько находится предметов и каких
предметов.
*/

namespace TestNIITKD
{
    public class Inventory
    {
        int size; //размер (количество ячеек)
        Item[] cells; //ячейки (содержит предмет, который находится в ячейке)
        int[] itemCount; //количество пердметов в ячейке

        SoundPlayer sound_itemUsed; //для воспроизведения звука при использовании предмета

        //конструктор
        public Inventory(int _size = 9)
        {
            size = _size;
            cells = new Item[size];
            itemCount = new int[size];
            //загружаем звук
            sound_itemUsed = new SoundPlayer("Resources/ItemUsed.wav");
            sound_itemUsed.Load();

            //test
            TryAddItem(new Item(Item.ItemType.Apple), 0, 3);
            TryAddItem(new Item(Item.ItemType.Banana), 1, 2);
        }

        #region Свойства
        //размер инвентаря
        public int Size
        {
            get { return size; }
        }
        //предметы в ячейках инвентаря
        public Item[] Cells
        {
            get { return cells; }
        }
        //количество предметов в ячейке инвентаря
        public int[] ItemCount
        {
            get { return itemCount; }
        }
        #endregion

        //добавление предмета в инвентарь (возвращаем false в случае неудачи)
        public bool TryAddItem(Item _item, int _cellID, int _count = 1)
        {
            if (cells[_cellID] != null && cells[_cellID].Type != _item.Type) return false; //ошибка при попытке добавить в ячейку предмет другого типа
            //добавляем предмет в ячейку
            cells[_cellID] = _item;
            itemCount[_cellID] += _count;
            //отрисовываем ячейку инвентаря
            GameWindow.Instance.DrawInventoryCell(_cellID, itemCount[_cellID], _item.ImageSource);

            return true;
        }

        //очистить ячейку инвентаря
        public void ClearCell(int _cellID)
        {
            cells[_cellID] = null;
            itemCount[_cellID] = 0;
            //отрисовываем ячейку инвентаря
            GameWindow.Instance.DrawInventoryCell(_cellID, itemCount[_cellID]);
        }

        //использование предмета (ПКМ)
        public void UseItem(int _cellID)
        {
            if (itemCount[_cellID] < 1) return;
            sound_itemUsed.Play();
            itemCount[_cellID]--;
            if (itemCount[_cellID] == 0) cells[_cellID] = null;
            //отрисовываем ячейку инвентаря
            GameWindow.Instance.DrawInventoryCell(_cellID, itemCount[_cellID]);
        }

        //проверка на то, что ячейка пуста (используется в Drag And Drop - перетаскивание предмета из ячейки не запустится, если эта ячейка пуста)
        public bool CellIsEmpty(int _cellID)
        {
            if (cells[_cellID] == null || itemCount[_cellID] < 1) return true;
            return false;
        }

        //перенос предмета из одной ячейки в другую
        public bool TryMoveItem(int _cellFrom, int _cellTo)
        {
            if (_cellFrom == _cellTo) return false;
            if (CellIsEmpty(_cellFrom)) return false;
            if (TryAddItem(cells[_cellFrom], _cellTo, itemCount[_cellFrom]) ) //пытаемся скопировать предмет в ячейку _cellTo
            {
                ClearCell(_cellFrom); //если копирование произошло успешно - удаляем предмет из предыдущей ячейки
                return true;
            }

            return false;
        }

    }
}
