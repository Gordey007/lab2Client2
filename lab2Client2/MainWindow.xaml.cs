using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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

namespace lab2Client2
{

    public partial class MainWindow : Window
    {
        // инициализация класса clientSocket
        ClientSocket clientSocket;
        public MainWindow()
        {
            InitializeComponent();

            clientSocket = new ClientSocket(11000);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string push = "Id: " + id.Text + ", модель: " + model.Text + ", цена: " + price.Text + ", кол-во: " + count.Text;
            // вызов функции SendMessage из класса clientSocket и отправка введенных данных push
            clientSocket.SendMessage(push);
        }

        private void Students_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            
        }


        private void SendDiscipline_Click(object sender, RoutedEventArgs e)
        {
          // string strDiscipline = discipline.Text;
         //  clientSocket.SendMessage(strDiscipline);
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // вызов функции SendMessage из класса clientSocket и отправка номер строки
            clientSocket.SendMessage(lineNumber.Text);
            // запись полученных данных с сервера
            string text = clientSocket.response();
            txtBlock.Text = text;
        }


        private void View_Click(object sender, RoutedEventArgs e)
        {
            // вызов функции SendMessage из класса clientSocket и отправка единицы
            clientSocket.SendMessage("1");
            // запись полученных данных с сервера
            string text = clientSocket.response();
            txtBlock.Text = text;
        }


        private void Search_Click(object sender, RoutedEventArgs e)
        {
            // вызов функции SendMessage из класса clientSocket и отправка двойки и текст, который нужно будет искать
            clientSocket.SendMessage("2"+find.Text);
            // запись полученных данных с сервера
            string text = clientSocket.response();
            txtBlock.Text = text;
        }


        private void Del_Click(object sender, RoutedEventArgs e)
        {
            // вызов функции SendMessage из класса clientSocket и отправка тройки и номер строки
            clientSocket.SendMessage("3"+lineNumber.Text);
            // запись полученных данных с сервера
            string text = clientSocket.response();
            txtBlock.Text = text;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            string push = "4" + lineNumber.Text + "Id: " + id.Text + ", модель: " + model.Text + ", цена: " + price.Text + ", кол-во: " + count.Text;
            // вызов функции SendMessage из класса clientSocket и отправка данных push на сервер
            clientSocket.SendMessage(push);
            // запись полученных данных с сервера
            string text = clientSocket.response();
            txtBlock.Text = text;         
        }

        private void LineNumber_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
