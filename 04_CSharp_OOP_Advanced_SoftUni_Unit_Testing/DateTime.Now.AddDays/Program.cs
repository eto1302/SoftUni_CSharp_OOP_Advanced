

namespace Hack
{
    using System;
    using NUnit.Framework;
    [TestFixture]
    public class Tests
    {
        [Test]
        public void AddingDaysToTheMiddleOfTheMonth()
        {
            DateTime now = new DateTime(2018, 4, 9);
            if (now.AddDays(1).Day != 10) throw new Exception("Error!");

        }

        [Test]
        public void AddingDaysToIncreaseMonth()
        {
            DateTime now = new DateTime(2018, 4, 30);
            if (now.AddDays(1).Day != 1 || now.AddDays(1).Month != 5) throw new Exception("Error!");

        }

        [Test]
        public void AddingNegativeValues()
        {
            DateTime now = new DateTime(2018, 4, 9);
            if (now.AddDays(-1).Day != 8) throw new Exception("Error!");

        }

        [Test]
        public void AddingNegativeDaysToDecreaseMonth()
        {
            DateTime now = new DateTime(2018, 4, 1);
            if (now.AddDays(-1).Day != 31 || now.AddDays(-1).Month != 3) throw new Exception("Error!");

        }

        [Test]
        public void AddingDaysToLeapYear()
        {
            DateTime now = new DateTime(2008, 2, 28);
            if (now.AddDays(1).Day != 29 || now.AddDays(1).Month != 2) throw new Exception("Error!");

        }

        [Test]
        public void AddingDaysToNonLeapYear()
        {
            DateTime now = new DateTime(2009, 2, 28);
            if (now.AddDays(1).Day != 1 || now.AddDays(1).Month != 3) throw new Exception("Error!");

        }
    }
}