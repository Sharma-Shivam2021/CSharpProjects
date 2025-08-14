using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace CurrencyConverter_Online
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Root val = new Root();

        public MainWindow()
        {
            InitializeComponent();
            ClearControls();
            GetDataFromAPI();
        }

        public async void GetDataFromAPI()
        {
            val = await HttpRequesterForCurrencyData.GetData<Root>("https://openexchangerates.org/api/latest.json?app_id=6fddb5639e1440e29152092be3f64814");
            BindCurrency();
        }

        private void ClearControls()
        {
            TextCurrency.Text = string.Empty;
            if (CmbFromCurrency.Items.Count > 0)
            {
                CmbFromCurrency.SelectedIndex = 0;
            }
            if (CmbToCurrency.Items.Count > 0)
            {
                CmbToCurrency.SelectedIndex = 0;
            }
            LabelCurrency.Content = string.Empty;
            TextCurrency.Focus();
        }

        private void BindCurrency()
        {
            DataTable dataTableCurrency = new DataTable();
            dataTableCurrency.Columns.Add("Text");
            dataTableCurrency.Columns.Add("Value");

            dataTableCurrency.Rows.Add("--Select--", 0);
            dataTableCurrency.Rows.Add("USD", val.rates.USD);
            dataTableCurrency.Rows.Add("EUR", val.rates.EUR);
            dataTableCurrency.Rows.Add("GBP", val.rates.GBP);
            dataTableCurrency.Rows.Add("JPY", val.rates.JPY);
            dataTableCurrency.Rows.Add("CNY", val.rates.CNY);
            dataTableCurrency.Rows.Add("INR", val.rates.INR);
            dataTableCurrency.Rows.Add("CAD", val.rates.CAD);
            dataTableCurrency.Rows.Add("AUD", val.rates.AUD);
            dataTableCurrency.Rows.Add("NZD", val.rates.NZD);
            dataTableCurrency.Rows.Add("CHF", val.rates.CHF);
            dataTableCurrency.Rows.Add("SGD", val.rates.SGD);
            dataTableCurrency.Rows.Add("KRW", val.rates.KRW);
            dataTableCurrency.Rows.Add("HKD", val.rates.HKD);
            dataTableCurrency.Rows.Add("BRL", val.rates.BRL);
            dataTableCurrency.Rows.Add("RUB", val.rates.RUB);
            dataTableCurrency.Rows.Add("ZAR", val.rates.ZAR);
            dataTableCurrency.Rows.Add("MXN", val.rates.MXN);
            dataTableCurrency.Rows.Add("SAR", val.rates.SAR);
            dataTableCurrency.Rows.Add("AED", val.rates.AED);

            CmbFromCurrency.ItemsSource = dataTableCurrency.DefaultView;
            CmbToCurrency.ItemsSource = dataTableCurrency.DefaultView;

            CmbFromCurrency.DisplayMemberPath = "Text";
            CmbToCurrency.DisplayMemberPath = "Text";

            CmbFromCurrency.SelectedValuePath = "Value";
            CmbToCurrency.SelectedValuePath = "Value";

            CmbFromCurrency.SelectedIndex = 0;
            CmbToCurrency.SelectedIndex = 0;

        }

        private void Convert_Click(object sender, RoutedEventArgs e)
        {
            double ConvertedValue;
            if (TextCurrency.Text==null || TextCurrency.Text.Trim()=="")
            {
                MessageBox.Show("Please Enter Currency", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                TextCurrency.Focus();
                return;
            }
            else if (CmbFromCurrency.SelectedValue == null || CmbFromCurrency.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Currenct From", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                CmbFromCurrency.Focus();
                return;
            }
            else if (CmbToCurrency.SelectedValue == null || CmbToCurrency.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Currenct To", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                CmbToCurrency.Focus();
                return;
            }
            else
            {
                if (CmbFromCurrency.Text==CmbToCurrency.Text)
                {
                    ConvertedValue = double.Parse(TextCurrency.Text);
                    LabelCurrency.Content = CmbToCurrency.Text + " " + ConvertedValue.ToString("N3");
                    return;
                }
                else
                {
                    ConvertedValue = double.Parse(CmbToCurrency.SelectedValue.ToString())*double.Parse(TextCurrency.Text)/double.Parse(CmbFromCurrency.SelectedValue.ToString());
                    LabelCurrency.Content = CmbToCurrency.Text + " " + ConvertedValue.ToString("N3");
                    return;
                }
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearControls();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"\d+(\.\d+)?");
            e.Handled = !regex.IsMatch(e.Text);
        }

        private void Reverse_Conversion(object sender, RoutedEventArgs e)
        {
            object tempValue = CmbFromCurrency.SelectedValue;
            CmbFromCurrency.SelectedValue = CmbToCurrency.SelectedValue;
            CmbToCurrency.SelectedValue = tempValue;

            Convert_Click(sender, e);
        }

    }
}
