using System.Windows;

namespace TaskI
{
    public partial class Confirm : Window
    {
     
        public bool Answer { get; set; }//результат нажатия на клавишу
        private void Ok_Click(object sender, RoutedEventArgs e)//Обрабочик собтия нажатия на кнопку ок
        {
            Answer= true;
            this.Close();
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)//Обрабочик собтия нажатия на кнопку cancel
            {
            Answer = false;
            this.Close();
            }
    }
}
