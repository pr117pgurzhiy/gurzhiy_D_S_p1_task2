using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace Florist
{
    /// <summary>
    /// Логика взаимодействия для tovars.xaml
    /// </summary>
    public partial class tovars : Window
    {
        private users user = null;

        public tovars(users user)
        {
            InitializeComponent();
            icTov.ItemsSource = Instances.db.tovary.ToList(); // обновление ItemsControl
            Instances.db.SaveChanges(); // обновление бд
            Refresh();
        }
        public void Refresh()
        {
           icTov.ItemsSource = Instances.db.tovary.ToList();
           var zxc = cbFilter.SelectedValue;
           switch (cbFilter.SelectedValue) // фильтрация по размеру скидки
           {
               case "1":
                   icTov.ItemsSource = Instances.db.tovary
                       .ToList();
                   break;
               case "2":
                   icTov.ItemsSource = Instances.db.tovary
                       .Where(t => t.Действующая_скидка < 10)
                       .ToList();
                   break;
               case "3":
                   icTov.ItemsSource = Instances.db.tovary
                       .Where(t => t.Действующая_скидка >= 10 && t.Действующая_скидка < 15)
                       .ToList();
                   break;
               case "4":
                   icTov.ItemsSource = Instances.db.tovary
                       .Where(t => t.Действующая_скидка >= 15)
                       .ToList();
                   break;
           }
           Instances.db.SaveChanges();

            var asd = cbSort.SelectedValue;
            switch (cbSort.SelectedValue) // сортировка по наименованию и цене
            {
                case "1":
                    icTov.ItemsSource = Instances.db.tovary
                        .Where(t => t.Наименование.Contains(txtSearch.Text))
                        .OrderBy(t => t.Наименование)
                        .ToList();
                    break;
                case "2":
                    icTov.ItemsSource = Instances.db.tovary
                        .Where(t => t.Наименование.Contains(txtSearch.Text))
                        .OrderByDescending(t => t.Наименование)
                        .ToList();
                    break;
                case "3":
                    icTov.ItemsSource = Instances.db.tovary
                        .Where(t => t.Наименование.Contains(txtSearch.Text))
                        .OrderBy(t => t.Стоимость)
                        .ToList();
                    break;
                case "4":
                    icTov.ItemsSource = Instances.db.tovary
                        .Where(t => t.Наименование.Contains(txtSearch.Text))
                        .OrderByDescending(t => t.Стоимость)
                        .ToList();
                    break;
            }
            Instances.db.SaveChanges();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (icTov != null) Refresh(); // itemscontrol обновляется при изменении текста в поиске
        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (icTov != null) Refresh();
        }

        private void cbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (icTov != null) Refresh();
        }

        private void btnBuy_Click(object sender, RoutedEventArgs e)
        {
            btnCart.Visibility = Visibility.Visible; // видимость кнопки "Корзина"
        }

        private void btnCart_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}

