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


namespace Login_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Acessar_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("foi1");
            var Login_attempt = new Login(Usuario.Text, Senha.Text);
            Console.WriteLine("foi2");
            try
            {
                if (Login_attempt.validate())
                {
                    Main_Grid.Children.Add(new Message_success());
                }
                else
                {
                    Main_Grid.Children.Add(new Message_failure());
                }
            }
            catch (Exception err)
            {
                Usuario.Text = err.Message;
            }
        }
    }
}
