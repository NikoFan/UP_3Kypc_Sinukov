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

namespace SinukovUP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        

        // Обработчик нажатия на main область
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

        // Открытие окна авторизации
        private void OpenAuthWindow(object sender, RoutedEventArgs e)
        {
            SignInWindow signInWindow = new SignInWindow()
            {
                Left = Left,
                Top = Top
            };
            signInWindow.Show();
            this.Visibility = Visibility.Hidden;
        }

        // Обработчик нажатия на кнопку регистрации
        private void StartRegUserAccount(object sender,  RoutedEventArgs e)
        {
            string[] informationToRegistration = new string[5]{
                phoneInput.Text.ToString(),
                fioInput.Text.ToString(),
                loginInput.Text.ToString(),
                passwordInput.Text.ToString(),
                roleSelect.Text.ToString()
            };
            if (checkData(informationToRegistration))
            {
                // Если информаци корректна
                new DB().addNewAccount(informationToRegistration);
                new Helps().createInformationMessageBox("Пользователь зарегистрирован!");
                return;
            }
            new Helps().createInformationMessageBox("Проверьте введенные данные! Помните:\nТелефон: 8xxxxxxxxxx\nПароль до 15 символов");
        }

        // Проверка данных на корректность
        private bool checkData(string[] inputDataToCheck)
        {
            CheckInputData checkInformationInput = new CheckInputData();
            if (checkInformationInput.checkSQLI(inputDataToCheck[1]) &&
                checkInformationInput.checkSQLI(inputDataToCheck[0]) &&
                checkInformationInput.checkInputPhoneNumber(inputDataToCheck[0]) &&
                checkInformationInput.checkSQLI(inputDataToCheck[2]) &&
                checkInformationInput.checkSQLI(inputDataToCheck[3]) &&
                checkInformationInput.checkSQLI(inputDataToCheck[4]))
                return true;
            return false;
        }

    }
}
