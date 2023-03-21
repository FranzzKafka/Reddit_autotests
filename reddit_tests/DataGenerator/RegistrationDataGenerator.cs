using System;
namespace reddit_tests.DataGenerator
{
	public class RegistrationDataGenerator
	{
        Random rand = new Random();
        private const string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public string GenerateRandomEmail()
        {
            const int emailLength = 10;

            return new string(Enumerable.Repeat(_chars, emailLength)
                .Select(s => s[rand.Next(s.Length)]).ToArray()) + "@gmail.com";
        }

        public string GenerateRandomPassword()
        {
            const int passwordLength = 10;

            return new string(Enumerable.Repeat(_chars, passwordLength)
                .Select(s => s[rand.Next(s.Length)]).ToArray()) + "!1Aa";
        }

        public string GenerateRandomUserName()
        {
            const int userNameLength = 10;

            return new string(Enumerable.Repeat(_chars, userNameLength)
                .Select(s => s[rand.Next(s.Length)]).ToArray());
        }
    }
}

