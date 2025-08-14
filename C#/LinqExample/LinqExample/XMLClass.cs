using System.Xml.Linq;
namespace LinqExample
{
    internal class XMLClass
    {
        string studentsXML =
                        @"<Students>
                            <Student>
                                <Name>Toni</Name>
                                <Age>21</Age>
                                <University>Yale</University>
                                <Semester>6</Semester>
                            </Student>
                            <Student>
                                <Name>Carla</Name>
                                <Age>17</Age>
                                <University>Yale</University>
                                <Semester>1</Semester>
                            </Student>
                            <Student>
                                <Name>Leyla</Name>
                                <Age>19</Age>
                                <University>Beijing Tech</University>
                                <Semester>3</Semester>
                            </Student>
                            <Student>
                                <Name>Frank</Name>
                                <Age>25</Age>
                                <University>Beijing Tech</University>
                                <Semester>10</Semester>
                            </Student>
                        </Students>";

        private XDocument studentsXDoc;

        public XMLClass()
        {
            studentsXDoc = XDocument.Parse(studentsXML);
        }

        public void Foo()
        {
            var students = from student in studentsXDoc.Descendants("Student")
                           select new
                           {
                               Name = student.Element("Name")?.Value,
                               Age = student.Element("Age")?.Value,
                               University = student.Element("University")?.Value,
                               Semester = student.Element("Semester")?.Value,
                           };

            //studentsXDoc.Descendants("Student")
            //    .Select(student => new
            //    {
            //        Name = student.Element("Name")?.Value,
            //        Age = student.Element("Age")?.Value,
            //        University = student.Element("University")?.Value,
            //        Semester = student.Element("Semester")?.Value,
            //    }).ToList().ForEach(Console.WriteLine);

            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }

        public void Sort()
        {
            //var sortedStudent = studentsXDoc.Descendants("Student")
            //                  .OrderBy(s => int.Parse(s.Element("Age")?.Value ?? "0"));

            var students = from student in studentsXDoc.Descendants("Student")
                           select new
                           {
                               Name = student.Element("Name")?.Value,
                               Age = student.Element("Age")?.Value,
                               University = student.Element("University")?.Value,
                               Semester = student.Element("Semester")?.Value,
                           };

            var sortedStudent = from student in students
                                orderby student.Age
                                select student;
            Console.WriteLine("Sorted By Age");
            foreach (var student in sortedStudent)
            {
                Console.WriteLine(student);
            }

            studentsXDoc.Root?.ReplaceNodes(sortedStudent);
        }

    }
}
