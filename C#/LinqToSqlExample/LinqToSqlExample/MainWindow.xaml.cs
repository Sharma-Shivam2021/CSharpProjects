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
using System.Configuration;
namespace LinqToSqlExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LinqToSqlDataContext dataContext;
        public MainWindow()
        {
            InitializeComponent();

            string connString = ConfigurationManager.ConnectionStrings["LinqToSqlExample.Properties.Settings.UdemyTutorialsConnectionString"].ConnectionString;
            dataContext = new LinqToSqlDataContext(connString);

            //InsertUniversities();
            //InsertStudent();
            //InsertLecture();
            //InsertStudentLectureAssociation();
            //GetUniversityOfToni();
            //GetToniLecture();
            //GetAllStudentFromYale();
            //GetAllLectureOfIISc();
            //UpdateToni();
            DeleteJames();
        }

        public void InsertUniversities()
        {
            dataContext.ExecuteCommand("delete from university");


            University yale = new University();
            yale.Name = "Yale";
            dataContext.Universities.InsertOnSubmit(yale);

            University iisc = new University();
            iisc.Name = "Indian Institute of Science";
            dataContext.Universities.InsertOnSubmit(iisc);

            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.Universities;
        }

        public void InsertStudent()
        {
            dataContext.ExecuteCommand("delete from Student");

            University yale = dataContext.Universities
                .First(university => university.Name.Equals("Yale"));
            University iisc = dataContext.Universities
                .First(un => un.Name.Equals("Indian Institute of Science"));

            List<Student> students = new List<Student>();

            students.Add(new Student { Name = "Carls", Gender = "female", UniversityId = yale.Id });
            students.Add(new Student { Name = "Toni", Gender = "male", University = yale });
            students.Add(new Student { Name = "Leyela", Gender = "female", UniversityId = iisc.Id });
            students.Add(new Student { Name = "James", Gender = "male", UniversityId = iisc.Id });

            dataContext.Students.InsertAllOnSubmit(students);
            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.Students;

        }

        public void InsertLecture()
        {
            dataContext.ExecuteCommand("delete from Lecture");

            List<Lecture> lectures = new List<Lecture>();
            lectures.Add(new Lecture { Name = "C#" });
            lectures.Add(new Lecture { Name = "SQL" });

            dataContext.Lectures.InsertAllOnSubmit(lectures);
            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.Lectures;
        }

        public void InsertStudentLectureAssociation()
        {
            Student Carls = dataContext.Students
                .First(st => st.Name.Equals("Carls"));

            Student Toni = dataContext.Students
                .First(st => st.Name.Equals("Toni"));

            Student Leyela = dataContext.Students
                .First(st => st.Name.Equals("Leyela"));

            Student James = dataContext.Students
                .First(st => st.Name.Equals("James"));

            Lecture CSharp = dataContext.Lectures
                .First(lc => lc.Name.Equals("C#"));

            Lecture SQL = dataContext.Lectures
                .First(lc => lc.Name.Equals("SQL"));

            dataContext.StudentLectures.InsertOnSubmit(
                new StudentLecture { Student = Carls, Lecture = CSharp }
                );
            dataContext.StudentLectures.InsertOnSubmit(
                new StudentLecture { Student = Toni, Lecture = CSharp }
                );
            dataContext.StudentLectures.InsertOnSubmit(
                new StudentLecture { Student = Carls, Lecture = SQL }
                );
            dataContext.StudentLectures.InsertOnSubmit(
                new StudentLecture { Student = James, Lecture = SQL }
                );
            dataContext.StudentLectures.InsertOnSubmit(
                new StudentLecture { Student = Leyela, Lecture = CSharp }
                );
            dataContext.StudentLectures.InsertOnSubmit(
                new StudentLecture { Student = Leyela, Lecture = SQL }
                );

            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.StudentLectures;
        }

        public void GetUniversityOfToni()
        {
            Student Toni = dataContext.Students.First(st => st.Name.Equals("Toni"));
            University toniUniversity = Toni.University;
            List<University> universities = new List<University>();
            universities.Add(toniUniversity);
            MainDataGrid.ItemsSource = universities;
        }

        public void GetToniLecture()
        {
            Student Toni = dataContext.Students.First(st => st.Name.Equals("Toni"));
            List<Lecture> toniLecture = Toni.StudentLectures.Select(sl => sl.Lecture).ToList();
            MainDataGrid.ItemsSource = toniLecture;
        }

        public void GetAllStudentFromYale()
        {
            List<Student> studentFromYale = dataContext.Students.Where(st => st.University.Name.Equals("Yale")).ToList();
            MainDataGrid.ItemsSource = studentFromYale;
        }

        public void GetAllLectureOfIISc()
        {
            var lecturesIISc = from sl in dataContext.StudentLectures
                               join student in dataContext.Students
                               on sl.StudentId equals student.Id
                               where student.University.Name == "Indian Institute of Science"
                               select sl.Lecture ;

            List < Lecture > lecturesOfIISc = dataContext.StudentLectures
                .Where(sl => sl.Student.University.Name == "Indian Institute of Science")
                .Select(sl => sl.Lecture)
                .Distinct()
                .ToList();

            MainDataGrid.ItemsSource=lecturesIISc;
        }
    
        public void UpdateToni()
        {
            Student Toni = dataContext.Students.FirstOrDefault(st => st.Name == "Toni");
            Toni.Name = "Antonio";
            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.Students;
        }    
    
        public void DeleteJames()
        {
            Student James = dataContext.Students.FirstOrDefault(st=>st.Name=="James");
            dataContext.Students.DeleteOnSubmit(James);
            dataContext.SubmitChanges();
            MainDataGrid.ItemsSource = dataContext.Students;

        }

    }
}
