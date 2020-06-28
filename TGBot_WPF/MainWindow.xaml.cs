using ConsoleBot;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Telegram.Bot.Args;

namespace TGBot_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string token = "1070622790:AAHB5PT4dFq3_BhMArCTBuaeMP3H1eu6cqk";
        MyTelegramBot bot;
        
        public MainWindow()
        {
            InitializeComponent();
            bot = new MyTelegramBot(this, token);
            bot.Start();
            Chat_lb.ItemsSource = bot.History;
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bot.Stop();
        }

        private async void Send_btn_Click(object sender, RoutedEventArgs e)
        {
            if(Chat_lb.SelectedItem != null)
            {
                var chatId = (Chat_lb.SelectedItem as ChatMessage).Id;
                var text = SendText_tb.Text;
                await bot.SendMessageToUser(chatId, text);
            }
        }

        private void SaveHistory_btn(object sender, RoutedEventArgs e)
        {
            if (bot.History.Count > 0)
            {
                bot.SaveHistoryAsJson();
            }
            else MessageBox.Show("История пуста.");
        }
    }
}
