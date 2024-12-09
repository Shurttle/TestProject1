namespace TestProject1
{
    public class UnitTest1
    {
        private readonly Dictionary<string, string> users = new Dictionary<string, string>
    {
        { "teacher", "123" },
        { "admin", "admin" }
    };

        public string Login(string username, string password)
        {
            if (users.ContainsKey(username) && users[username] == password)
            {
                return "Login successful";
            }
            return "Login failed";
        }
    }

    public class AuthenticationTests
    {
        private readonly UnitTest1 auth;

        public AuthenticationTests()
        {
            auth = new UnitTest1();
        }

        [Theory]
        [InlineData("teacher", "123", "Login successful")]
        [InlineData("teacher", "wrongpass", "Login failed")]
        [InlineData("unknown", "123", "Login failed")]
        [InlineData("", "", "Login failed")]
        public void Login_ReturnsExpectedResult(string username, string password, string expected)
        {
            var result = auth.Login(username, password);
            Assert.Equal(expected, result);
        }
    }
}