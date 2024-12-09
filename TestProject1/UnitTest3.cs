namespace TestProject1
{
    public class UnitTest3
    {
        public double CalculateAverage(List<Student> students)
        {
            if (students.Count == 0) return 0;
            return students.Average(student => student.Score);
        }

        public List<Student> FindAtRiskStudents(List<Student> students, int threshold)
        {
            return students.Where(student => student.Score < threshold).ToList();
        }
    }

    public class PerformanceAnalyzerTests
    {
        private readonly UnitTest3 analyzer;
        private readonly List<Student> students;

        public PerformanceAnalyzerTests()
        {
            analyzer = new UnitTest3();
            students = new List<Student>
        {
            new Student { Name = "Yuri", Score = 85 },
            new Student { Name = "kirill", Score = 72 },
            new Student { Name = "Danill", Score = 60 }
        };
        }

        [Fact]
        public void CalculateAverage_ReturnsCorrectValue()
        {
            Assert.Equal(72.33, analyzer.CalculateAverage(students), 2);
        }

        [Fact]
        public void CalculateAverage_EmptyList_ReturnsZero()
        {
            Assert.Equal(0, analyzer.CalculateAverage(new List<Student>()));
        }

        [Fact]
        public void FindAtRiskStudents_ReturnsCorrectStudents()
        {
            var result = analyzer.FindAtRiskStudents(students, 70);
            Assert.Single(result);
            Assert.Equal("Danill", result[0].Name);
        }
    }
}