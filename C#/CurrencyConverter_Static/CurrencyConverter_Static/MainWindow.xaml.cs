using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CurrencyConverter_Static
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BindCurrency();
        }

        private void BindCurrency()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Text");
            dataTable.Columns.Add("Value");

            dataTable.Rows.Add("--Select--", 0);
            dataTable.Rows.Add("INR", 1);
            dataTable.Rows.Add("USD", 75);
            dataTable.Rows.Add("EUR", 85);
            dataTable.Rows.Add("SAR", 20);
            dataTable.Rows.Add("POUND", 5);
            dataTable.Rows.Add("DEM", 43);

            cmbFromCurrency.ItemsSource = dataTable.DefaultView;
            cmbFromCurrency.DisplayMemberPath = "Text";
            cmbFromCurrency.SelectedValuePath = "Value";
            cmbFromCurrency.SelectedIndex = 0;

            cmbToCurrency.ItemsSource = dataTable.DefaultView;
            cmbToCurrency.DisplayMemberPath = "Text";
            cmbToCurrency.SelectedValuePath = "Value";
            cmbToCurrency.SelectedIndex = 0;
        }

        private void Convert_Click(object sender, RoutedEventArgs e)
        {
            double ConvertedValue;
            if (txtCurrency.Text == null || txtCurrency.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Currency", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                txtCurrency.Focus();
                return;
            }
            else if (cmbFromCurrency.SelectedValue == null || cmbFromCurrency.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Currenct From", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                cmbFromCurrency.Focus();
                return;
            }
            else if (cmbToCurrency.SelectedValue == null || cmbToCurrency.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Currenct To", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                cmbToCurrency.Focus();
                return;
            }
            else
            {
                if (cmbFromCurrency.Text == cmbToCurrency.Text)
                {
                    ConvertedValue = double.Parse(txtCurrency.Text);
                    labelCurrency.Content = cmbToCurrency.Text + " " + ConvertedValue.ToString("N3");
                    return;
                }
                else
                {
                    ConvertedValue = double.Parse(cmbFromCurrency.SelectedValue.ToString()!) * double.Parse(txtCurrency.Text) / double.Parse(cmbToCurrency.SelectedValue.ToString()!);
                    labelCurrency.Content = cmbToCurrency.Text + " " + ConvertedValue.ToString("N3");
                    return;
                }
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearControls();
        }

        private void txtCurrency_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cmbFromCurrency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmbToCurrency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmbToCurrency_PreviewKeyDown(object sender, KeyEventArgs e)
        {
        }
        private void cmbFromCurrency_PreviewKeyDown(object sender, KeyEventArgs e)
        {
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"\d+(\.\d+)?");
            e.Handled=regex.IsMatch(e.Text);
        }

        private void ClearControls()
        {
            txtCurrency.Text = string.Empty;
            if (cmbFromCurrency.Items.Count > 0)
            {
                cmbFromCurrency.SelectedIndex = 0;
            }
            if (cmbToCurrency.Items.Count > 0)
            {
                cmbToCurrency.SelectedIndex = 0;
            }
            labelCurrency.Content = string.Empty;
            txtCurrency.Focus();
        }
    }
}
