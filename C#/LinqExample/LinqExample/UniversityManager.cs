namespace LinqExample
{
    internal class UniversityManager
    {
        public List<University>? Universities;
        public List<Student>? Students;

        public UniversityManager()
        {
            Universities = new List<University>();
            Students = new List<Student>();

            // Sample Data for Universities
            Universities.Add(new University { Id = 1, Name = "Yale" });
            Universities.Add(new University { Id = 2, Name = "IISc" });

            //Sample Data for Students
            Students.Add(new Student { Id = 1, Name = "Carla", Gender = "Female", Age = 17, UniversityId = 1 });
            Students.Add(new Student { Id = 2, Name = "Toni", Gender = "Male", Age = 21, UniversityId = 1 });
            Students.Add(new Student { Id = 3, Name = "Leyla", Gender = "Female", Age = 19, UniversityId = 2 });
            Students.Add(new Student { Id = 4, Name = "James", Gender = "Male", Age = 25, UniversityId = 2 });
            Students.Add(new Student { Id = 5, Name = "Linda", Gender = "Female", Age = 22, UniversityId = 2 });
        }

        public void MaleStudents()
        {
            /*
             * IEnumerable method of Linq.
             * IEnumerable<List<Student>> maleStudent = from student in Students where student.Gender="Male" select student; 
             */
            List<Student> MaleStudents = Students!.Where(static student => student.Gender == "Male").ToList();
            Console.WriteLine("Male Students");
            foreach (Student student in MaleStudents)
            {
                student.ShowInfo();
            }
            Console.WriteLine();
        }

        public void FemaleStudents()
        {
            List<Student> FemaleStudents = Students!.Where(static student => student.Gender == "Female").ToList();
            Console.WriteLine("Female Students");
            foreach (Student student in FemaleStudents)
            {
                student.ShowInfo();
            }
            Console.WriteLine();
        }

        public void SortStudentByAge()
        {
            // var sortedStudents =from Student in Students Orderby student.Age select Student;
            List<Student> SortedStudents = Students!.OrderBy(static x => x.Age).ToList();
            Console.WriteLine("Sorted By Age");
            foreach (Student student in SortedStudents)
            {
                student.ShowInfo();
            }
            Console.WriteLine();
        }

        public void AllStudentsFromIISc()
        {

            //IEnumerable<Student> iiscStudents = from student in Students
            //                                    join university in Universities!
            //                                    on student.UniversityId equals university.Id
            //                                    where university.Name == "IISc"
            //                                    select student;

            var IIScId = Universities!.FirstOrDefault(u => u.Name == "IISc")?.Id;

            if (IIScId == null)
            {
                Console.WriteLine("University does not exists");
                return;
            }

            Console.WriteLine("Students from IISc");
            List<Student> IIScStudents = Students!.FindAll(student => student.UniversityId == IIScId).ToList();
            foreach (Student student in IIScStudents) { student.ShowInfo(); }
            Console.WriteLine();
        }

        public void AllStudentsById(int id)
        {
            var universityExists = Universities!.Find(u => u.Id == id);
            if (universityExists == null)
            {
                Console.WriteLine("No University with the id {0} exists in the database", id);
                return;
            }

            List<Student> students = Students!.FindAll(student => student.UniversityId == id).ToList();
            Console.WriteLine("Students of the University with id: " + id);
            foreach (Student student in students)
            {
                student.ShowInfo();
            }
            Console.WriteLine();
        }

        public void StudentAndNameCollection()
        {
            //var newCollection = from student in Students
            //                    join university in Universities!
            //                    on student.UniversityId equals university.Id
            //                    orderby student.Name
            //                    select new StudentUniversityCollection { Student = student, UniversityName = university.Name! };

            List<StudentUniversityCollection> newCollection = Students!
                .Join(Universities!,
                    student => student.UniversityId,
                    university => university.Id,
                    (student, university) => new StudentUniversityCollection { Student = student, UniversityName = university.Name! })
                .OrderBy(x => x.Student.Name)
                .ToList();
            Console.WriteLine("New Collection ");
            foreach (StudentUniversityCollection item in newCollection)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
        }
    }
}
