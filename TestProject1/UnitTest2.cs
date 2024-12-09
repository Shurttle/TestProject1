namespace TestProject1
{
    public class UnitTest2
    {

        public List<Student> FilterStudents(List<Student> students, int minScore)
        {
            return students.Where(student => student.Score >= minScore).ToList();
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public int Score { get; set; }
    }

    public class StudentFilterTests
    {
        private readonly UnitTest2 filter;
        private readonly List<Student> students;

        public StudentFilterTests()
        {
            filter = new UnitTest2();
            students = new List<Student>
        {
            new Student { Name = "Yuri", Score = 4 },
            new Student { Name = "Kirill", Score = 3 },
            new Student { Name = "Danil", Score = 5 }
        };
        }

        [Fact]
        public void FilterAbove80_ReturnsCorrectStudents()
        {
            var result = filter.FilterStudents(students, 4);
            Assert.Single(result);
            Assert.Equal("Yuri", result[0].Name);
        }

        [Fact]
        public void FilterAbove4_ReturnsCorrectStudents()
        {
            var result = filter.FilterStudents(students, 3);
            Assert.Equal(1, result.Count);
        }

        [Fact]
        public void FilterAbove5_ReturnsEmptyList()
        {
            var result = filter.FilterStudents(students, 5);
            Assert.Empty(result);
        }
    }
}