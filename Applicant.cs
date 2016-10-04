using System;

namespace SecretaryApp
{
    public class Applicant
    {
        private static Random _random = new Random();
        public int Rating { get; } = _random.Next(1,10);
        public int Order { get; set; }
    }
}
