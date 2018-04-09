

namespace Hack
{
    using System;
    
    using NUnit.Framework;
    [TestFixture]
    public class Tests
    {
        [Test]
        public void NegativeAbsolute()
        {
            int a = -1;
            if(a*-1 != Math.Abs(a)) throw new Exception("Error!");

        }

        [Test]
        public void ZeroAbsolute()
        {
            int a = 0;
            if (a  != Math.Abs(a)) throw new Exception("Error!");

        }

        [Test]
        public void PositiveAbsolute()
        {
            int a = 24;
            if (a != Math.Abs(a)) throw new Exception("Error!");

        }

        [Test]
        public void ValidFloor()
        {
            double a = 1.4;
            if(Convert.ToInt32(a.ToString().Split('.')[0]) != Math.Floor(a)) throw new Exception("Error!");

        }

        
    }
}