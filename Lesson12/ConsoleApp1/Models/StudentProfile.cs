namespace ConsoleApp1.Models
{
    public class StudentProfile
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }

        public int StudentRecordId { get; set; }
        public Student StudentRecord { get; set; }
    }
}