using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BashSoft.Contracts;
using BashSoft.DataStructures;
namespace BashSoftTesting
{
    [TestClass]
    public class OrderedDataStructureTester
    {

        private ISimpleOrderedBag<string> names;
        [TestMethod]
        public void TestEmptyCtor()
        {
            this.names = new SimpleSortedList<string>();
            Assert.AreEqual(this.names.Capacity, 16);
            Assert.AreEqual(this.names.Size, 0);
        }

        [TestMethod]
        public void TestCtorWithInitialCapacity()
        {
            this.names = new SimpleSortedList<string>(20);
            Assert.AreEqual(this.names.Capacity, 20);
            Assert.AreEqual(this.names.Size, 0);
        }

        [TestMethod]
        public void TestCtorWithAllParams()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase,30);
            Assert.AreEqual(this.names.Capacity, 30);
            Assert.AreEqual(this.names.Size, 0);
        }

        [TestMethod]
        public void TestCtorWithInitialComparer()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase);
            Assert.AreEqual(this.names.Capacity, 16);
            Assert.AreEqual(this.names.Size, 0);
        }

        [TestInitialize]
        public void SetUp()
        {
            this.names = new SimpleSortedList<string>();
        }

        [TestMethod]
        public void TestAddIncreaseSize()
        {
            this.names.Add("Nasko");
            Assert.AreEqual(1, this.names.Size);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddNullThrowsException()
        {
            this.names.Add(null);
        }

        [TestMethod]
        public void TestAddUnsortedDataIsHeldSorted()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase)
            {
                "Rosen",
                "Georgi",
                "Balkan"
            };
           

            string[] expectedNamesCollection = new string[] {"Balkan", "Georgi", "Rosen"};
            Assert.AreEqual(expectedNamesCollection[0], names.ToArray()[0]);
            Assert.AreEqual(expectedNamesCollection[1], names.ToArray()[1]);
            Assert.AreEqual(expectedNamesCollection[2], names.ToArray()[2]);
            
        }

        [TestMethod]
        public void TestAddingMoreThanInitialCapacity()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase)
            {
                "E1",
                "E2",
                "E3",
                "E4",
                "E5",
                "E6",
                "E7",
                "E8",
                "E9",
                "E10",
                "E11",
                "E12",
                "E13",
                "E14",
                "E15",
                "E16",
                "E17",
            };
            Assert.AreEqual(17, this.names.Size);
            Assert.AreNotEqual(16, this.names.Capacity);
        }

        [TestMethod]
        public void TestAddingAllFromCollectionIncreasesSize()
        {
            List<string> temp = new List<string>();
            temp.Add("E1");
            temp.Add("E2");
            this.names.AddAll(temp);
            Assert.AreEqual(2, this.names.Size);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddingAllFromNullThrowsException()
        {
            this.names.AddAll(null);

        }

        [TestMethod]
        public void TestAddAllKeepsSorted()
        {
            string[] expectedNamesCollection = new string[] { "Balkan", "Georgi", "Rosen" };
            List<string> namesToBeSorted = new List<string>();
            namesToBeSorted.Add("Rosen");
            namesToBeSorted.Add("Georgi");
            namesToBeSorted.Add("Balkan");
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase);
            names.AddAll(namesToBeSorted);
            Assert.AreEqual(expectedNamesCollection[0], names.ToArray()[0]);
            Assert.AreEqual(expectedNamesCollection[1], names.ToArray()[1]);
            Assert.AreEqual(expectedNamesCollection[2], names.ToArray()[2]);
        }

        [TestMethod]
        public void TestRemoveValidElementDecreaseSize()
        {
            this.names.Add("TestElement");
            var sizeBeforeRemoval = this.names.Size;
            this.names.Remove("TestElement");
            Assert.AreNotEqual(sizeBeforeRemoval, this.names.Size);
        }

        [TestMethod]
        public void TestRemoveValidElementRemoveSelectedOne()
        {
            this.names.Add("ivan");
            this.names.Add("nasko");
            this.names.Remove("ivan");
            foreach (var name in this.names)
            {
                Assert.AreNotEqual("ivan", name);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestRemovingNullThrowsException()
        {
            this.names.Add("TestElement");
            this.names.Remove(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestJoinWithNull()
        {
            this.names.Add("TestElementFirst");
            this.names.Add("TestElementSecond");
            this.names.Add("TestElementThird");
            this.names.Add("TestElementForth");
            this.names.Add("TestElementFifth");
            this.names.JoinWith(null);
            
        }

        [TestMethod]
        public void TestJoinWorksFine()
        {
            this.names.Add("A");
            this.names.Add("B");
            this.names.Add("C");
            Assert.AreEqual("A,B,C", this.names.JoinWith(","));
        }

    }
}
