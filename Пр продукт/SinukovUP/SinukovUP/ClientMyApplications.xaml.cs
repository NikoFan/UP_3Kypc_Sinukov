using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Логика взаимодействия для ClientMyApplications.xaml
    /// </summary>
    public partial class ClientMyApplications : Window
    {
        public ClientMyApplications()
        {
            InitializeComponent();
            setData();
        }

        // Установка даты
        private void setData()
        {
            foreach(var item in new DB().returnApplicationsInfo())
            {
                StackPanel stackPanel = new StackPanel();
                Border border = createAppBorder(item.Key);
                stackPanel.Children.Add(new Helps().createAppInfTextBlock("Номер: " + item.Key));
                foreach (var info in item.Value)
                {
                    stackPanel.Children.Add(new Helps().createAppInfTextBlock(info.Value));
                }

                border.Child = stackPanel;
                AppSetter.Children.Add(border);
            }
        }
        // Создание карточки
        public Border createAppBorder(string name)
        {

            Border border = new Border
            {
                Name = "name_" + name,
                Height = 100,
                Width = 280,
                Background = new SolidColorBrush(Colors.Black),
                BorderBrush = new SolidColorBrush(Colors.White),
                BorderThickness = new Thickness(1),

                HorizontalAlignment = HorizontalAlignment.Left
            };

            border.MouseEnter += (sender, args) =>
            {
                border.Background = new SolidColorBrush(Colors.DarkGray);
            };

            border.MouseLeave += (sender, args) =>
            {
                border.Background = new SolidColorBrush(Colors.Black);
            };
            border.MouseDown += (sender, args) =>
            {
                new MemoryWork().setAppID(border.Name.ToString().Split('_')[1]);
                openSecondInfoPlace(border.Name.ToString().Split('_')[1]);
            };


            return border;
        }

        public void openSecondInfoPlace(string idApplication)
        {
            ApplicationsSecondInfoPlace.Visibility = Visibility.Visible;
            Dictionary<string, string> dictInfo = new DB().returnSecondApplicationsInfo(idApplication);
            Comment.Text = dictInfo["Комментарий"];
            ProblemD.Text = dictInfo["Описание"];
        }


        private void HideInfoPlace(object sedner, RoutedEventArgs e)
        {
            ApplicationsSecondInfoPlace.Visibility = Visibility.Hidden;
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


        // Сохранение новой информации
        private void SaveNewInfo(object sedner, RoutedEventArgs e)
        {

            ApplicationsSecondInfoPlace.Visibility = Visibility.Hidden;
            if (new DB().updateProblemD(ProblemD.Text.ToString()))
                new Helps().createInformationMessageBox("Описание обновлено!");
            else
                new Helps().createInformationMessageBox("ООшибка одновления! Проверьте новое описание!");
            new MemoryWork().setAppID("-1");



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

        // Создание заявки
        private void CreateNewUsersApplication(object sender, RoutedEventArgs e)
        {
            CreateApplication createNewApplication = new CreateApplication()
            {
                Top = Top,
                Left = Left
            };

            createNewApplication.Show();
            this.Visibility = Visibility.Hidden;



        }
    }
}
