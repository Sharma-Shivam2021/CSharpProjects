using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection sqlConnection;
        public MainWindow()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["WpfApp1.Properties.Settings.UdemyTutorialsConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
            ShowZoo();
            ShowAllAnimals();
        }

        private void ShowZoo()
        {
            try
            {
                string query = "select * from Zoo";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                using (sqlDataAdapter)
                {
                    DataTable zooTable = new DataTable();

                    sqlDataAdapter.Fill(zooTable);

                    ListZoo.DisplayMemberPath = "Location";
                    ListZoo.SelectedValuePath = "Id";
                    ListZoo.ItemsSource = zooTable.DefaultView;

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        private void ShowAnimalsAssociatedToZoo()
        {
            try
            {
                string query = "select * from Animal a inner join ZooAnimal za on a.Id = za.AnimalId " +
                    "where za.ZooId = @ZooId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                using (sqlDataAdapter)
                {
                    sqlCommand.Parameters.AddWithValue("@ZooId", ListZoo.SelectedValue);
                    DataTable associatedAnimal = new DataTable();

                    sqlDataAdapter.Fill(associatedAnimal);

                    ListAssociatedAnimals.DisplayMemberPath = "Name";
                    ListAssociatedAnimals.SelectedValuePath = "Id";
                    ListAssociatedAnimals.ItemsSource = associatedAnimal.DefaultView;

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        private void ShowAllAnimals()
        {
            try
            {
                string query = "select * from Animal";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                using (sqlDataAdapter)
                {
                    DataTable allAnimals = new DataTable();

                    sqlDataAdapter.Fill(allAnimals);

                    ListAnimals.DisplayMemberPath = "Name";
                    ListAnimals.SelectedValuePath = "Id";
                    ListAnimals.ItemsSource = allAnimals.DefaultView;

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        private void ListZoo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListZoo.SelectedValue != null)
            {
                ShowAnimalsAssociatedToZoo();
                if (ListZoo.SelectedItem is DataRowView row)
                {
                    NameTextBox.Text = row["Location"].ToString();
                }
                else
                {
                    NameTextBox.Text = string.Empty;
                }
            }
        }

        private void ListAssociatedAnimals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListAnimals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListAnimals.SelectedItem is DataRowView row)
            {
                NameTextBox.Text = row["Name"].ToString();
            }
            else
            {
                NameTextBox.Text = string.Empty;
            }
        }

        private void ButtonDeleteZoo_Click(object sender, RoutedEventArgs routedEventArgs)
        {
            if (ListZoo.SelectedValue != null)
            {
                try
                {
                    string zooName = "";
                    if (ListZoo.SelectedItem is DataRowView row)
                        zooName = row["Location"].ToString();

                    string queryRelation = "delete from ZooAnimal where ZooId=@ZooId";
                    string query = "delete from Zoo where Id = @ZooId";
                    SqlCommand sqlCommand = new SqlCommand(queryRelation, sqlConnection);
                    SqlCommand sqlCommand2 = new SqlCommand(query, sqlConnection);

                    using (sqlCommand)
                    using (sqlCommand2)
                    {
                        sqlCommand.Parameters.AddWithValue("@ZooId", ListZoo.SelectedValue);
                        sqlCommand2.Parameters.AddWithValue("@ZooId", ListZoo.SelectedValue);

                        sqlConnection.Open();
                        sqlCommand.ExecuteNonQuery();
                        int rowsAffected = sqlCommand2.ExecuteNonQuery();
                        sqlConnection.Close();

                        if (rowsAffected > 0)
                        {
                            ShowZoo(); // refresh zoo list
                            ListAssociatedAnimals.ItemsSource = null;
                            MessageBox.Show($"Zoo '{zooName}' deleted successfully.");
                        }
                        else
                        {
                            MessageBox.Show("No zoo found with the selected ID.");
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    if (sqlConnection.State == ConnectionState.Open)
                    { sqlConnection.Close(); }
                }
                return;
            }
            else
            {
                MessageBox.Show("No Zoo Selected");
                return;
            }
        }

        private void ButtonRemoveAnimal_Click(object sender, RoutedEventArgs routedEventArgs)
        {
            if (ListAssociatedAnimals.SelectedValue != null)
            {
                try
                {
                    string animalName = "";
                    string zooName = "";
                    if (ListAssociatedAnimals.SelectedItem is DataRowView row)
                    {
                        animalName = row["Name"].ToString();
                    }
                    if (ListZoo.SelectedItem is DataRowView row2)
                    {
                        zooName = row2["Location"].ToString();
                    }

                    string query = "delete from ZooAnimal where ZooId = @ZooId and AnimalId=@AnimalId";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                    using (sqlCommand)
                    {
                        sqlCommand.Parameters.AddWithValue("@ZooId", ListZoo.SelectedValue);
                        sqlCommand.Parameters.AddWithValue("@AnimalId", ListAssociatedAnimals.SelectedValue);

                        sqlConnection.Open();
                        int rowsAffected = sqlCommand.ExecuteNonQuery();
                        sqlConnection.Close();

                        if (rowsAffected > 0)
                        {
                            ShowAnimalsAssociatedToZoo();
                            MessageBox.Show($"{animalName} removed {zooName} successfully.");
                        }
                        else
                        {
                            MessageBox.Show("No such animal found with the selected ID in this zoo.");
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    if (sqlConnection.State == ConnectionState.Open)
                    { sqlConnection.Close(); }
                }
                return;
            }
            else
            {
                MessageBox.Show("No Zoo Selected");
                return;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void ButtonAddZoo_Click(object sender, RoutedEventArgs routedEventArgs)
        {
            if (!string.IsNullOrEmpty(NameTextBox.Text))
            {
                try
                {
                    string zooName = NameTextBox.Text;
                    string query = "insert into  Zoo(Location)  values(@Location)";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                    using (sqlCommand)
                    {
                        sqlCommand.Parameters.AddWithValue("@Location", zooName);

                        sqlConnection.Open();
                        int rowsAffected = sqlCommand.ExecuteNonQuery();
                        sqlConnection.Close();

                        if (rowsAffected > 0)
                        {
                            ShowZoo();
                            NameTextBox.Clear();
                            NameTextBox.Focus();
                            MessageBox.Show($"{zooName} created.");
                        }
                        else
                        {
                            MessageBox.Show("error occured while creating a new Locaiton");
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    if (sqlConnection.State == ConnectionState.Open)
                    { sqlConnection.Close(); }
                }
                return;
            }
            else
            {
                MessageBox.Show("TextBox is Empty or NULL");
                return;
            }
        }

        private void ButtonUpdateZoo_Click(object sender, RoutedEventArgs e)
        {
            if (ListZoo.SelectedValue != null && !string.IsNullOrEmpty(NameTextBox.Text))
            {
                try
                {
                    string query = "update Zoo set Location =@Location where Id = @ZooId";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                    using (sqlCommand)
                    {
                        sqlCommand.Parameters.AddWithValue("@Location", NameTextBox.Text);
                        sqlCommand.Parameters.AddWithValue("@ZooId", ListZoo.SelectedValue);

                        sqlConnection.Open();
                        int rowsAffected = sqlCommand.ExecuteNonQuery();
                        sqlConnection.Close();

                        if (rowsAffected > 0)
                        {
                            ShowZoo();
                            MessageBox.Show($"Updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("No zoo found with the selected ID.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    if (sqlConnection.State == ConnectionState.Open)
                    { sqlConnection.Close(); }
                }
                return;
            }
            else
            {
                MessageBox.Show("No Zoo Selected");
                return;
            }
        }

        private void ButtonDeleteAnimal_Click(object sender, RoutedEventArgs routedEventArgs)
        {
            if (ListAnimals.SelectedValue != null)
            {
                try
                {
                    string animalName = "";
                    if (ListAnimals.SelectedItem is DataRowView row)
                        animalName = row["Name"].ToString();

                    string queryRelation = "delete from ZooAnimal where AnimalId=@AnimalId";
                    string query = "delete from Animal where Id = @AnimalId";
                    SqlCommand sqlCommand = new SqlCommand(queryRelation, sqlConnection);
                    SqlCommand sqlCommand2 = new SqlCommand(query, sqlConnection);

                    using (sqlCommand)
                    using (sqlCommand2)
                    {
                        sqlCommand.Parameters.AddWithValue("@AnimalId", ListAnimals.SelectedValue);
                        sqlCommand2.Parameters.AddWithValue("@AnimalId", ListAnimals.SelectedValue);

                        sqlConnection.Open();
                        sqlCommand.ExecuteNonQuery();
                        int rowsAffected = sqlCommand2.ExecuteNonQuery();
                        sqlConnection.Close();

                        if (rowsAffected > 0)
                        {
                            ShowAllAnimals(); // refresh zoo list
                            ShowAnimalsAssociatedToZoo();
                            MessageBox.Show($"{animalName} deleted successfully.");
                        }
                        else
                        {
                            MessageBox.Show("No zoo found with the selected ID.");
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    if (sqlConnection.State == ConnectionState.Open)
                    { sqlConnection.Close(); }
                }
                return;
            }
            else
            {
                MessageBox.Show("No Zoo Selected");
                return;
            }
        }

        private void ButtonAddAnimal_Click(object sender, RoutedEventArgs routedEventArgs)
        {
            if (!string.IsNullOrEmpty(NameTextBox.Text))
            {
                try
                {
                    string animalName = NameTextBox.Text;
                    string query = "insert into  Animal(Name)  values(@Name)";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                    using (sqlCommand)
                    {
                        sqlCommand.Parameters.AddWithValue("@Name", animalName);

                        sqlConnection.Open();
                        int rowsAffected = sqlCommand.ExecuteNonQuery();
                        sqlConnection.Close();

                        if (rowsAffected > 0)
                        {
                            ShowAllAnimals();
                            NameTextBox.Clear();
                            NameTextBox.Focus();
                            MessageBox.Show($"{animalName} created.");
                        }
                        else
                        {
                            MessageBox.Show("error occured while creating a new Animal");
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    if (sqlConnection.State == ConnectionState.Open)
                    { sqlConnection.Close(); }
                }
                return;
            }
            else
            {
                MessageBox.Show("TextBox is Empty or NULL");
                return;
            }
        }

        private void ButtonUpdateAnimal_Click(object sender, RoutedEventArgs e)
        {
            if (ListAnimals.SelectedValue != null && !string.IsNullOrEmpty(NameTextBox.Text))
            {
                try
                {
                    string query = "update Animal set Name =@Name where Id = @AnimalId";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                    using (sqlCommand)
                    {
                        sqlCommand.Parameters.AddWithValue("@Name", NameTextBox.Text);
                        sqlCommand.Parameters.AddWithValue("@AnimalId", ListAnimals.SelectedValue);

                        sqlConnection.Open();
                        int rowsAffected = sqlCommand.ExecuteNonQuery();
                        sqlConnection.Close();

                        if (rowsAffected > 0)
                        {
                            ShowAllAnimals();
                            MessageBox.Show($"Updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("No animal found with the selected ID.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    if (sqlConnection.State == ConnectionState.Open)
                    { sqlConnection.Close(); }
                }
                return;
            }
            else
            {
                MessageBox.Show("No Animal Selected");
                return;
            }
        }

        private void ButtonAddAnimalToZoo_Click(object sender, RoutedEventArgs routedEventArgs)
        {
            if (ListZoo.SelectedItem != null && ListAnimals.SelectedItem != null)
            {
                try
                {
                    string query = "insert into  ZooAnimal(ZooId,AnimalId)  values(@ZooId,@AnimalId)";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                    using (sqlCommand)
                    {
                        sqlCommand.Parameters.AddWithValue("@ZooId", ListZoo.SelectedValue);
                        sqlCommand.Parameters.AddWithValue("@AnimalId", ListAnimals.SelectedValue);

                        sqlConnection.Open();
                        int rowsAffected = sqlCommand.ExecuteNonQuery();
                        sqlConnection.Close();

                        if (rowsAffected > 0)
                        {
                            string animalName = "";
                            string zooName = "";
                            if (ListZoo.SelectedItem is DataRowView row)
                            {
                                zooName = row["Location"].ToString();
                            }
                            if (ListAnimals.SelectedItem is DataRowView row2)
                            {
                                animalName = row2["Name"].ToString();
                            }
                            ShowAnimalsAssociatedToZoo();
                            MessageBox.Show($"{animalName} Added to {zooName}.");
                        }
                        else
                        {
                            MessageBox.Show("error occured while creating a new Animal");
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    if (sqlConnection.State == ConnectionState.Open)
                    { sqlConnection.Close(); }
                }
                return;
            }
            else
            {
                MessageBox.Show("Select the Zoo and Animal both");
                return;
            }
        }
    }
}
