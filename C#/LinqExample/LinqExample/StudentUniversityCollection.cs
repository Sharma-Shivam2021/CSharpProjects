namespace LinqExample
{
    internal class StudentUniversityCollection
    {
        public required string UniversityName { get; set; }
        public required Student Student { get; set; }

        public override string ToString()
        {
            return $"{Student.Id}: {Student.Name} is a student of University {UniversityName}. The Gender is {Student.Gender}, Age {Student.Age}";
        }
    }
}
