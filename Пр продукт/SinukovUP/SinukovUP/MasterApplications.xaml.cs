using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
    /// Логика взаимодействия для MasterApplications.xaml
    /// </summary>
    public partial class MasterApplications : Window
    {
        public MasterApplications()
        {
            InitializeComponent();
            setData();
        }

        // Установка даты
        private void setData()
        {
            foreach (var item in new DB().returnApplicationsInfo())
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
                openSecondInfoPlace();
            };


            return border;
        }

        public void openSecondInfoPlace()
        {
            ApplicationsSecondInfoPlace.Visibility = Visibility.Visible;

            Comment.Text = new DB().getComment();

            WorkParts.Items.Add("Новая заявка");
            WorkParts.Items.Add("В процессе ремонта");
            WorkParts.Items.Add("Готова к выдаче");
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
            // проверка что комментарий есть
            if (WorkParts.Text.ToString().Length == 0)
            {
                new Helps().createInformationMessageBox("Выберите статус заявки!");
                return;
            }

            ApplicationsSecondInfoPlace.Visibility = Visibility.Hidden;
            // Если комментарий к записи существует
            if (new DB().IsCommentBe())
            {
                if (WorkParts.Text.ToString() == "Готов к выдаче")
                {
                    // Обновление + добавление даты выдачи
                    if ((new DB().updateWorkParts(WorkParts.Text.ToString())) & (new DB().updateComment(Comment.Text.ToString())))
                        new Helps().createInformationMessageBox("Статус обновлен! Комментарий обновлен!");
                    else
                        new Helps().createInformationMessageBox("Ошибка обновления!");
                    new MemoryWork().setAppID("-1");
                    return;
                }
                if ((new DB().updateOnlyWorkParts(WorkParts.Text.ToString())) & (new DB().updateComment(Comment.Text.ToString())))
                    new Helps().createInformationMessageBox("Статус обновлен!");
                else
                    new Helps().createInformationMessageBox("Ошибка обновления! Комментарий обновлен!");
                new MemoryWork().setAppID("-1");
                return;
            }

            if (WorkParts.Text.ToString() == "Готов к выдаче")
            {
                // Обновление + добавление даты выдачи + Создание комментария
                if ((new DB().updateWorkParts(WorkParts.Text.ToString())) & (new DB().addNewComment(Comment.Text.ToString())))
                    new Helps().createInformationMessageBox("Статус обновлен! Комментарий Добавлен!");
                else
                    new Helps().createInformationMessageBox("Ошибка обновления!");
                new MemoryWork().setAppID("-1");
                return;
            }
            if ((new DB().updateOnlyWorkParts(WorkParts.Text.ToString())) & (new DB().addNewComment(Comment.Text.ToString())))
                new Helps().createInformationMessageBox("Статус обновлен!");
            else
                new Helps().createInformationMessageBox("Ошибка обновления! Комментарий Добавлен!");
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

        // Account
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
