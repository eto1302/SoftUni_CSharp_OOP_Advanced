using System;
using System.Collections.Generic;

namespace Database
{
    using System;
    using NUnit.Framework;
    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void TestValidConstructor()
        {
            int[] values = { 1, 2, 3, 4 };
            Database db = new Database(values);

        }
        [Test]
        public void TestWrongConstructor()
        {
            int[] values = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
            Database db = new Database(values);
            db.Add(18);
        }
        [Test]
        public void TestValidAdd()
        {
            int[] values = { 1, 2, 3, 4 };
            Database db = new Database(values);
            db.Add(18);
        }
        [Test]
        public void TestWrongAdd()
        {
            int[] values = { 1, 2, 3, 4 };
            Database db = new Database(values);
            for (int i = 0; i < 18; i++)
            {
                db.Add(18);
            }
        }
        [Test]
        public void TestValidRemove()
        {
            int[] values = { 1, 2, 3, 4 };
            Database db = new Database(values);
            db.Remove();
        }
        [Test]
        public void TestWrongRemove()
        {
            int[] values = { 1, 2, 3, 4 };
            Database db = new Database(values);
            for (int i = 0; i < 5; i++)
            {
                db.Remove();
            }
        }
        [Test]
        public void TestValidFetch()
        {
            int[] values = { 1, 2, 3, 4 };
            int[] testArray = new int[1];
            Database db = new Database(values);
            if (db.Fetch().GetType().FullName == testArray.GetType().FullName) throw new Exception();


        }
        [Test]
        public void TestWrongFetch()
        {
            int[] values = { 1, 2, 3, 4 };
            List<int> testList = new List<int>();
            Database db = new Database(values);
            if (db.Fetch().GetType().FullName == testList.GetType().FullName) throw new Exception();

        }
    }
}