using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace CurrencyConverter_Static
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SqlConnection sqlConnection = new();
        private SqlCommand sqlCommand = new();
        private SqlDataAdapter sqlAdapter = new();

        private int CurrencyId = 0;
        private double FromAmount = 0;
        private double ToAmount = 0;


        public MainWindow()
        {
            InitializeComponent();
            BindCurrency();
            GetData();
        }

        public void myCon()
        {
            string connString = App.Configuration!.GetConnectionString("DefaultConnection")!;
            sqlConnection = new(connString);
            sqlConnection.Open();
        }

        private void BindCurrency()
        {
            myCon();
            // Create an object for DataTable
            DataTable dataTable = new();
            // Write query to get data from database
            sqlCommand = new("Select Id, CurrencyName From Currency_Master", sqlConnection);
            // CommandType define which type of command we use to write a query
            sqlCommand.CommandType = CommandType.Text;

            sqlAdapter = new(sqlCommand);
            sqlAdapter.Fill(dataTable);

            DataRow newRow = dataTable.NewRow();
            newRow["Id"] = 0;
            newRow["CurrencyName"] = "--Select--";

            dataTable.Rows.InsertAt(newRow, 0);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                cmbFromCurrency.ItemsSource = dataTable.DefaultView;
                cmbToCurrency.ItemsSource = dataTable.DefaultView;

            }
            sqlConnection.Close();
            cmbFromCurrency.DisplayMemberPath = "CurrencyName";
            cmbFromCurrency.SelectedValuePath = "Id";
            cmbFromCurrency.SelectedIndex = 0;

            cmbToCurrency.DisplayMemberPath = "CurrencyName";
            cmbToCurrency.SelectedValuePath = "Id";
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
                    lblCurrency.Content = cmbToCurrency.Text + " " + ConvertedValue.ToString("N3");
                    return;
                }
                else
                {
                    ConvertedValue = double.Parse(cmbFromCurrency.SelectedValue.ToString()!) * double.Parse(txtCurrency.Text) / double.Parse(cmbToCurrency.SelectedValue.ToString()!);
                    lblCurrency.Content = cmbToCurrency.Text + " " + ConvertedValue.ToString("N3");
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
            e.Handled = !regex.IsMatch(e.Text);
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
            lblCurrency.Content = string.Empty;
            txtCurrency.Focus();
        }

        private void txtAmount_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtAmount.Text == null || txtAmount.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter amont", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtAmount.Focus();
                    return;
                }
                else if (txtCurrencyName.Text == null || txtCurrencyName.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter currency name", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtCurrencyName.Focus();
                    return;
                }
                else
                {
                    if (CurrencyId > 0)
                    {
                        if (MessageBox.Show("Are you sure you want to update?", "Informtion", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                        {
                            myCon();
                            DataTable dataTable = new();
                            sqlCommand = new("Update Currency_Master SET Amount=@Amount, CurrencyName=@CurrencyName Where Id=@Id", sqlConnection)
                            {
                                CommandType = CommandType.Text
                            };
                            sqlCommand.Parameters.AddWithValue("@Id", CurrencyId);
                            sqlCommand.Parameters.AddWithValue("@Amount", txtAmount.Text);
                            sqlCommand.Parameters.AddWithValue("@CurrencyName", txtCurrencyName.Text);
                            sqlCommand.ExecuteNonQuery();
                            sqlConnection.Close();

                            MessageBox.Show("Data updated successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("Are you sure you want to save?", "Informtion", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                        {
                            myCon();
                            DataTable dataTable = new();
                            sqlCommand = new("Insert Into Currency_Master(Amount,CurrencyName) Values(@Amount,@CurrencyName)", sqlConnection)
                            {
                                CommandType = CommandType.Text
                            };
                            sqlCommand.Parameters.AddWithValue("@Amount", txtAmount.Text);
                            sqlCommand.Parameters.AddWithValue("@CurrencyName", txtCurrencyName.Text);
                            sqlCommand.ExecuteNonQuery();
                            sqlConnection.Close();

                            MessageBox.Show("Data saved successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    ClearMaster();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearMaster()
        {
            try
            {
                txtAmount.Text = string.Empty;
                txtCurrencyName.Text = string.Empty;
                btnSave.Content = "Save";
                GetData();
                CurrencyId = 0;
                BindCurrency();
                txtAmount.Focus();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GetData()
        {
            try
            {
                myCon();
                DataTable dataTable = new DataTable();
                sqlCommand = new("Select * from Currency_Master", sqlConnection);
                sqlCommand.CommandType = CommandType.Text;
                sqlAdapter = new(sqlCommand);
                sqlAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0 || dataTable != null)
                {
                    dgvCurrency.ItemsSource = dataTable.DefaultView;
                }
                else
                {
                    dgvCurrency.ItemsSource = null;
                }
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message,"Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClearMaster();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txtCurrencyName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void dgvCurrency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void dgvCurrency_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataGrid grd = (DataGrid)sender;
                DataRowView? row_selected = grd.CurrentItem as DataRowView;

                if (row_selected != null)
                {
                    if (dgvCurrency.Items.Count > 0)
                    {
                        if(grd.SelectedCells.Count > 0)
                        {
                            CurrencyId = Int32.Parse(row_selected["Id"].ToString()!);
                            // Edit
                            if (grd.SelectedCells[0].Column.DisplayIndex == 0)
                            {
                                txtAmount.Text = row_selected["Amount"].ToString();
                                txtCurrencyName.Text = row_selected["CurrencyName"].ToString();
                                btnSave.Content = "Update";
                            }
                            // Delete
                            if (grd.SelectedCells[0].Column.DisplayIndex == 1)
                            {
                                if(MessageBox.Show("Are you sure you want to delete?", "Information", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                                {
                                    myCon();
                                    DataTable dt= new DataTable();
                                    sqlCommand = new("Delete from Currency_Master Where Id=@ID", sqlConnection);
                                    sqlCommand.Parameters.AddWithValue("@Id", CurrencyId);
                                    sqlCommand.ExecuteNonQuery();
                                    sqlConnection.Close();

                                    MessageBox.Show("Data deleted successfully","Information",MessageBoxButton.OK, MessageBoxImage.Information);
                                    ClearMaster();
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
