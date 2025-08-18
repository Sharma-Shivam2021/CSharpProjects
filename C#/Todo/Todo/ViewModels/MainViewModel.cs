using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Todo.Data;
using Todo.Models;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Todo.ViewModels;

public class MainViewModel : BaseViewModel
{
    public ObservableCollection<Tasks> Tasks { get; set; } = new ObservableCollection<Tasks>();

    private Tasks? _selectedTask;
    public Tasks SelectedTask
    {
        get => _selectedTask!;
        set { _selectedTask = value; OnPropertyChanged(); }
    }

    public string? NewTask { get; set; }
    public string? NewDay { get; set; }

    public ICommand? AddCommand { get; }
    public ICommand? UpdateCommand { get; }
    public ICommand? DeleteCommand { get; }

    public MainViewModel()
    {
        LoadData();
        AddCommand = new RelayCommand(execute: AddTask);
        UpdateCommand = new RelayCommand(execute: UpdateTask, canExecute: () => SelectedTask != null);
        DeleteCommand = new RelayCommand(execute: DeleteTask, canExecute: () => SelectedTask != null);
    }

    private void LoadData()
    {
        using AppDbContext? db = new AppDbContext();
        db.Database.EnsureCreated();
        Tasks.Clear();
        foreach (Tasks? task in db.Tasks.ToList())
        {
            Tasks.Add(task);
        }
    }

    public void AddTask()
    {
        using AppDbContext? db = new AppDbContext();
        var task = new Tasks { TaskName = NewTask, Day = NewDay };
        db.Tasks.Add(task);
        db.SaveChanges();
        LoadData();
    }
    public void UpdateTask()
    {
        if (SelectedTask == null) return;
        using AppDbContext? db = new AppDbContext();
        db.Tasks.Update(SelectedTask);
        db.SaveChanges();
        LoadData();
    }

    public void DeleteTask()
    {
        if (SelectedTask == null) return;
        using AppDbContext? db = new AppDbContext();
        db.Tasks.Remove(SelectedTask);
        db.SaveChanges();
        LoadData();
    }
}
