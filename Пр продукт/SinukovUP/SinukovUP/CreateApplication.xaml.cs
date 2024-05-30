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
    /// Логика взаимодействия для CreateApplication.xaml
    /// </summary>
    public partial class CreateApplication : Window
    {

        
        public CreateApplication()
        {
            InitializeComponent();
            setDate();
        }

        // Установка даты
        private void setDate() => dateInformation.Text = new Helps().takeTime();



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

        // Account
        private void Account(object sender, RoutedEventArgs e)
        {
            new Helps().openUserAccounts(new MemoryWork().getUserROLE());
            this.Visibility = Visibility.Hidden;

        }

        // Открытие заявок пользователя
        private void OpenMyApps(object sender, RoutedEventArgs e)
        {
            if (new Helps().createQuestionMessageBox("Вы точно хотите прекратить процесс создания новой заявки?"))
            {
                ClientMyApplications clientMyApplications = new ClientMyApplications()
                {
                    Top = Top,
                    Left = Left
                };

                clientMyApplications.Show();
                this.Visibility = Visibility.Hidden;
            }
        }


        // Создание заявки
        private void CreateNewApplication(object sender, RoutedEventArgs e)
        {
            Dictionary<string, string> applicationCreateInfo = new Dictionary<string, string>()
            {
                {"Дата добавления", dateInformation.Text.ToString()},
                {"Тип техники", TechTypeInput.Text.ToString()},
                {"Модель техники", TechModelInput.Text.ToString()},
                {"Описание", TechDInput.Text.ToString()},
                {"Статус", "Новая заявка"},
                {"ID Заказчика", new MemoryWork().getUserID().ToString()}
            };
            bool checkResult = true;
            foreach(var item in applicationCreateInfo)
            {
                if ((checkResult = checkInputInformation(item.Value)) == false)
                    break;
            }
            if (!checkResult)
            {
                new Helps().createInformationMessageBox("Ошибка при проверке данных. проверьте чтобы каждое поле было заполнено!");
                return;
            }
            // Регистрация заявки
            if (new DB().regNewApplication(applicationCreateInfo))
            {
                new Helps().createInformationMessageBox("Заявка зарегистрирована!");
                // Возврат на окно аккаунта
                new Helps().openUserAccounts("Заказчик");
                this.Visibility = Visibility.Hidden;
            }
                


        }

        // Проверка информации на корректность
        private bool checkInputInformation(string example)
        {
            if(example.Length < 1)
            {
                return false;
            }
            return true;
        }

        

    }
}
