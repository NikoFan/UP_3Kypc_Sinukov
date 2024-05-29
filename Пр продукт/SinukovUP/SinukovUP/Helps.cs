using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SinukovUP
{
    internal class Helps
    {

        // Вывод информационного сообщения
        public object createInformationMessageBox(string message) => MessageBox.Show(message, "Тех-поддержка", MessageBoxButton.OK, MessageBoxImage.Information);


        // Вывод уточняющих сообщений
        public bool createQuestionMessageBox(string message) => (MessageBox.Show(message, "Тех-поддержка", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes);


        // Выходит из приложения + чистит КЕШ программы
        public void exitApp() => Environment.Exit(0);
    }
}
