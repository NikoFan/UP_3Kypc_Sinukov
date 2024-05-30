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
    /// Логика взаимодействия для OperatorApplications.xaml
    /// </summary>
    public partial class OperatorApplications : Window
    {
        private int count = 0;
        private int compliteC = 0;
        public OperatorApplications()
        {
            InitializeComponent();
            setData();
        }

        // Установка даты
        private void setData()
        {
            foreach (var item in new DB().returnAllApplicationsInfo())
            {
                StackPanel stackPanel = new StackPanel();
                Border border = createAppBorder(item.Key);
                count++;
                stackPanel.Children.Add(new Helps().createAppInfTextBlock("Номер: " + item.Key));
                foreach (var info in item.Value)
                {
                    if (info.Value == "Готова к выдаче")
                        compliteC++;
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
                openSecondInfoPlace();
            };


            return border;
        }

        // Установка информации в доп область
        public void openSecondInfoPlace()
        {
            ApplicationsSecondInfoPlace.Visibility = Visibility.Visible;
            AllCount.Text = count.ToString();
            CompleteCount.Text = compliteC.ToString();
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

        // Аккаунт
        private void Account(object sender, RoutedEventArgs e)
        {
            new Helps().openUserAccounts(new MemoryWork().getUserROLE());
            this.Visibility = Visibility.Hidden;

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
