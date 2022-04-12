using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Florist
{
    public partial class tovary
    {
        public string price
        {
            get
            {
                return Стоимость.ToString("0.00 руб\\."); // перевод стоимости в денежный формат
            }
        }
        public string skidka
        {
            get
            {
                return (Действующая_скидка).ToString("Скидка: " + "0\\" + "%"); // добавление текста и знака "%" к скидке
            }
        }
        public string proiz
        {
            get
            {
                return "Производитель: " + $"{proizv.Производитель}"; // возвращает производителя
            }
        }
        public string newprice
        {
            get
            {
                if (Действующая_скидка != 0)
                    return (Стоимость - ((Действующая_скидка * Стоимость) / 100)).ToString("0.00руб\\."); // расчет стоимости по акции
                else
                    return null;
            }
        }
        public Object zacherkivanie
        {
            get
            {
                if (Действующая_скидка != 0)
                    return TextDecorations.Strikethrough; // создание декорации зачеркивания к старой цене, если товар по акции
                else
                    return null;
            }
        }
        public string design
        {
            get
            {
                if (Действующая_скидка > 15)
                    return "#7fff00"; // изменение цвета фона при скидке, большей 15%
                return "#ffffff";
            }
        }
    }
}
