using Demo.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Person> People = new List<Person>
        {
            new Person{Name="John",Age=25},
            new Person{Name="John",Age=25},
            new Person{Name="John",Age=25},
            new Person{Name="John",Age=25},
            new Person{Name="John",Age=25},
            new Person{Name="John",Age=25},
        };
        public MainWindow()
        {
            InitializeComponent();

            ListBoxPeople.ItemsSource = People;

            //this.DataContext = person;
            ////MainContent.Content=new LoginView();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedPeople = ListBoxPeople.SelectedItems;
            if (selectedPeople.Count > 0)
            {
                foreach(var item in selectedPeople)
                {
                    var person=(Person)item;
                    MessageBox.Show(person.Name);
                }
            }
            else
            {
                MessageBox.Show("NO Selected People");
            }


        }
    }
}