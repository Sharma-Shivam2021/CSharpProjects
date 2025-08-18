using System.Collections.ObjectModel;
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
using Todo.Models;
using Todo.ViewModels;

namespace Todo;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private MainViewModel _viewModel;

    public MainWindow()
    {
        InitializeComponent();
        _viewModel = new MainViewModel();
        this.DataContext= _viewModel;
    }

    private void AddTask_Click(object sender, RoutedEventArgs e)
    {
        _viewModel.AddTask();
    }

    private void UpdateTask_Click(object sender, RoutedEventArgs e)
    {
        _viewModel.UpdateTask();
    }

    private void DeleteTask_Click(object sender, RoutedEventArgs e)
    {
        _viewModel.DeleteTask();
    }
}