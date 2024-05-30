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

namespace SinukovUP
{
    /// <summary>
    /// Логика взаимодействия для ClientAccountWindow.xaml
    /// </summary>
    public partial class ClientAccountWindow : Window
    {
        public ClientAccountWindow()
        {
            InitializeComponent();
            setUserAccountInf();
        }

        // Загрузка данных пользвоателя
        private void setUserAccountInf()
        {
            Dictionary<string, string> userInf = new Helps().userAccountInformation();
            fioInf.Text = userInf["ФИО"];
            loginInf.Text = userInf["Логин"];
            phoneInf.Text = userInf["Телефон"];
            roleInf.Text = userInf["Роль"];
        }

        // Сокрытие всплывающей области
        private void HideSettingsPlace(object sedner, RoutedEventArgs e)
        {
            try
            {
                SettingsPlace.Visibility = Visibility.Hidden;
                this.DragMove();
            }
            catch (Exception)
            {
                Console.WriteLine("nothing");
            }

        }


        // Открытие заявок пользователя
        private void OpenMyApps(object sender, RoutedEventArgs e)
        {
            
            ClientMyApplications clientMyApplications = new ClientMyApplications()
            {
                Top = Top,
                Left = Left
            };

            clientMyApplications.Show();
            this.Visibility = Visibility.Hidden;
            
        }


        // Открытие окна для создания заявки
        private void CreateNewApplication(object sedner, RoutedEventArgs e)
        {
            CreateApplication createApplication = new CreateApplication()
            {
                Top = Top,
                Left = Left
            };
            createApplication.Show();
            this.Visibility = Visibility.Hidden;
        }



        // Обработчик нажатия на кнопку настроек
        private void OpenSettingsPlace(object sedner, RoutedEventArgs e)
        {
            SettingsPlace.Visibility = Visibility.Visible;
        }


        // Обработчик нажатия на кнопку закрытия приложения
        private void CloseApp(object sedner, RoutedEventArgs e)
        {
            if (new Helps().createQuestionMessageBox("Вы точно хотите выйти из приложения?"))
                new Helps().exitApp();
        }

        // Выход из аккаунта
        private void LogOut(object sender, RoutedEventArgs e)
        {
            if (new Helps().createQuestionMessageBox("Вы точно хотите выйти из аккаунта?"))
            {
                MainWindow mainWindow = new MainWindow()
                {
                    Top = Top,
                    Left = Left
                };

                mainWindow.Show();
                this.Visibility = Visibility.Hidden;
            }
            
        }

        
    }
}
