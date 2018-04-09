using System;
using System.Collections.Generic;
using System.Linq;
using IteratorTest;

namespace Database
{
    using System;
    using NUnit.Framework;
    [TestFixture]
    public class IteratorTests
    {
        [Test]
        public void TestValidConstruction()
        {
            int[] values = new[] {1, 2, 3, 5, 67, 7};
            ListIterator<int> listyIterator = new ListIterator<int>(values.ToList());
        }

        [Test]
        public void TestWrongConstruction()
        {
            ListIterator<int> listyIterator = new ListIterator<int>(null);
        }

        [Test]
        public void TestValidMove()
        {
            int[] values = new[] { 1, 2, 3, 5, 67, 7 };
            ListIterator<int> listyIterator = new ListIterator<int>(values.ToList());
            listyIterator.Move();
        }


        [Test]
        public void TestValidPrint()
        {
            int[] values = new[] { 1, 2, 3, 5, 67, 7 };
            ListIterator<int> listyIterator = new ListIterator<int>(values.ToList());
            listyIterator.Print();
        }

        [Test]
        public void TestValidHasNext()
        {
            int[] values = new[] { 1, 2, 3, 5, 67, 7 };
            ListIterator<int> listyIterator = new ListIterator<int>(values.ToList());
            listyIterator.HasNext();
        }
    }
}