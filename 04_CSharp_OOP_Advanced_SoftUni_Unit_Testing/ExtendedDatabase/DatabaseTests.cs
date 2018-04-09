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
            Dictionary<long, string> values = new Dictionary<long, string>();
            for (int i = 0; i < 10; i++)
            {
                string value = ('a' + i).ToString();
                values.Add(i,value);
            }
            Database db = new Database(values);

        }
        [Test]
        public void TestWrongConstructor()
        {
            Dictionary<long, string> values = new Dictionary<long, string>();
            for (int i = 0; i < 10; i++)
            {
                string value = ('a' + i).ToString();
                values.Add(i, value);
            }
            Database db = new Database(values);
            
        }
        [Test]
        public void TestValidAdd()
        {
            Dictionary<long, string> values = new Dictionary<long, string>();
            for (int i = 0; i < 10; i++)
            {
                string value = ('a' + i).ToString();
                values.Add(i, value);
            }
            Database db = new Database(values);
            db.Add(new KeyValuePair<long, string>(32, "bdfdfgj"));
        }
        [Test]
        public void TestWrongAdd()
        {
            Dictionary<long, string> values = new Dictionary<long, string>();
            for (int i = 0; i < 10; i++)
            {
                string value = ('a' + i).ToString();
                values.Add(i, value);
            }
            Database db = new Database(values);
            db.Add(new KeyValuePair<long, string>(0, "a"));
        }
        [Test]
        public void TestValidRemove()
        {
            Dictionary<long, string> values = new Dictionary<long, string>();
            for (int i = 0; i < 10; i++)
            {
                string value = ('a' + i).ToString();
                values.Add(i, value);
            }
            Database db = new Database(values);
            db.Remove();
        }
        [Test]
        public void TestWrongRemove()
        {
            Dictionary<long, string> values = new Dictionary<long, string>();
            for (int i = 0; i < 10; i++)
            {
                string value = ('a' + i).ToString();
                values.Add(i, value);
            }
            Database db = new Database(values);
            for (int i = 0; i < 28; i++)
            {
                db.Remove();
            }
        }

        [Test]
        public void TestValidFindByUsername()
        {
            Dictionary<long, string> values = new Dictionary<long, string>();
            for (int i = 0; i < 10; i++)
            {
                string value = ('a' + i).ToString();
                values.Add(i, value);
            }
            Database db = new Database(values);
            db.FindByUsername("b");
        }

        [Test]
        public void TestWrongFindByUsernameNull()
        {
            Dictionary<long, string> values = new Dictionary<long, string>();
            for (int i = 0; i < 10; i++)
            {
                string value = ('a' + i).ToString();
                values.Add(i, value);
            }
            Database db = new Database(values);
            db.FindByUsername(null);
        }

        [Test]
        public void testWrongFindByUsernameNotPresent()
        {
            Dictionary<long, string> values = new Dictionary<long, string>();
            for (int i = 0; i < 10; i++)
            {
                string value = ('a' + i).ToString();
                values.Add(i, value);
            }
            Database db = new Database(values);
            db.FindByUsername("rtyui");
        }

        [Test]
        public void TestValidFindById()
        {
            Dictionary<long, string> values = new Dictionary<long, string>();
            for (int i = 0; i < 10; i++)
            {
                string value = ('a' + i).ToString();
                values.Add(i, value);
            }
            Database db = new Database(values);
            db.FindById(0);
        }

        [Test]
        public void TestWrongFindByIdNotPresent()
        {
            Dictionary<long, string> values = new Dictionary<long, string>();
            for (int i = 0; i < 10; i++)
            {
                string value = ('a' + i).ToString();
                values.Add(i, value);
            }
            Database db = new Database(values);
            db.FindById(334443);
        }

        [Test]
        public void TestWrongFindByIdNegative()
        {
            Dictionary<long, string> values = new Dictionary<long, string>();
            for (int i = 0; i < 10; i++)
            {
                string value = ('a' + i).ToString();
                values.Add(i, value);
            }
            Database db = new Database(values);
            db.FindById(-20);
        }
    }
}