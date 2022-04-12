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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Florist
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Instances.db.SaveChanges(); // обновление данных в бд
        }

        private void Log_In_Click(object sender, RoutedEventArgs e)
        {
            var login = txtLogin.Text;
            var pass = txtPass.Password;
            users user;
            if ((user = Instances.db.users.FirstOrDefault(q => q.Login == login && q.Password == pass)) != null) // проверка логина и пароль на верность
            {
                Hide();
                new tovars(user).ShowDialog(); // запуск окна товары при успешной авторизации
                Show();
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль"); // вывод сообщения при неудаче
            }
        }

        private void Guest_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new tovars(null).ShowDialog(); //вход по кнопке гость
            Show();
        }
    }
}