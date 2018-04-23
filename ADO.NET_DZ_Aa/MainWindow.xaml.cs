using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace ADO.NET_DZ_Aa
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void signInButton_Click(object sender, RoutedEventArgs e)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.MultipleActiveResultSets = true;
            builder.UserID = loginBox.Text;
            builder.Password = passwordBox.Password;
            builder.DataSource = @"ZHASLAN\SQLEXPRESS";
            builder.IntegratedSecurity = true;
            builder.InitialCatalog = "TstDB";
            MessageBox.Show(builder.ToString());

            var connectionString = builder.ToString();
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    MessageBox.Show("Вы вошли");
                }
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
