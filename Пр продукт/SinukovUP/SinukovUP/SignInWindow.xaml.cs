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
    /// Логика взаимодействия для SignInWindow.xaml
    /// </summary>
    public partial class SignInWindow : Window
    {
        public SignInWindow()
        {
            InitializeComponent();
        }



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

        private void OpenRegistrationWindow(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow()
            {
                Top = Top,
                Left = Left
            };

            mainWindow.Show();
            this.Visibility = Visibility.Hidden;
        }

        // Авторизация пользователя
        private void StartAuthUserAccount(object sender, RoutedEventArgs e)
        {
            string[] informationToAuthorization = new string[3]{

                loginInput.Text.ToString(),
                passwordInput.Text.ToString(),
                roleSelect.Text.ToString()
            };
            if (checkData(informationToAuthorization))
            {
                // Если информаци корректна
                if (new DB().SignInAccount(informationToAuthorization))
                {
                    new Helps().openUserAccounts(roleSelect.Text.ToString());
                    this.Visibility = Visibility.Hidden;
                    return;
                }

                
            }
            new Helps().createInformationMessageBox("Проверьте введенные данные!");
        }



        private bool checkData(string[] inputDataToCheck)
        {
            CheckInputData checkInformationInput = new CheckInputData();
            if (checkInformationInput.checkSQLI(inputDataToCheck[1]) &&
                checkInformationInput.checkSQLI(inputDataToCheck[0]) &&
                checkInformationInput.checkSQLI(inputDataToCheck[2]))
                return true;
            return false;
        }
    }
}
