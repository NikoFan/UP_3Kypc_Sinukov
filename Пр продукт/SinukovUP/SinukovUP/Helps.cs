using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SinukovUP
{
    internal class Helps : Window
    {

        // Вывод информационного сообщения
        public object createInformationMessageBox(string message) => MessageBox.Show(message, "Тех-поддержка", MessageBoxButton.OK, MessageBoxImage.Information);


        // Вывод уточняющих сообщений
        public bool createQuestionMessageBox(string message) => (MessageBox.Show(message, "Тех-поддержка", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes);


        // Выходит из приложения + чистит КЕШ программы
        public void exitApp() => Environment.Exit(0);


        public void openUserAccounts(string userRole)
        {
            switch(userRole)
            {
                case ("Оператор"):
                    OperatorAccountWindow operatorAccWindow = new OperatorAccountWindow()
                    {
                        Top = Top,
                        Left = Left
                    };

                    operatorAccWindow.Show();
                    break;
                case ("Мастер"):
                    MasterAccountWindow masterAccountWindow = new MasterAccountWindow()
                    {
                        Top = Top,
                        Left = Left
                    };

                    masterAccountWindow.Show();
                    break;
                case ("Менеджер"):
                    ManagerAccountWindow managerAccountWindow = new ManagerAccountWindow()
                    {
                        Top = Top,
                        Left = Left
                    };

                    managerAccountWindow.Show();
                    break;
                case ("Заказчик"):
                    ClientAccountWindow clientAccountWindow = new ClientAccountWindow()
                    {
                        Top = Top,
                        Left = Left
                    };

                    clientAccountWindow.Show();
                    break;

            }
        }

        // Возврат даты ГГГГ-ММ-ДД
        public string takeTime() => DateTime.Today.ToString().Split(' ')[0].Split('.')[2] + "-" +
                                    DateTime.Today.ToString().Split(' ')[0].Split('.')[1] + "-" +
                                    DateTime.Today.ToString().Split(' ')[0].Split('.')[0];


        public Dictionary<string, string> userAccountInformation()
        {
            return new DB().returnuserAccountInformation();
        }

        
           

        public TextBlock createAppInfTextBlock(string text) => new TextBlock
        {
            Text = text,
            Foreground = new SolidColorBrush(Colors.White),
            FontSize = 12,
            HorizontalAlignment = HorizontalAlignment.Left,
        };

    }
}
