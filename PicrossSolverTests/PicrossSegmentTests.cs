using Microsoft.VisualStudio.TestTools.UnitTesting;
using PicrossSolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicrossSolver.Tests
{
    [TestClass()]
    public class PicrossSegmentTests
    {
        /*  There are more blocks needed for the groups than what has been
         *  specified as the length of the picross segment. */
        [TestMethod()]
        public void Constructor_Length5Groups4And2()
        {
            ArgumentOutOfRangeException expectedException;
            expectedException =
                new ArgumentOutOfRangeException("PicrossSegment not" +
                    " large enough to contain supplied BlockGroups.");
            try
            {
                PicrossSegment ps = new PicrossSegment(5, 4, 2);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Assert.AreEqual(expectedException.Message, e.Message);
            }
        }
        [TestMethod()]
        public void Constructor_Length10Groups15()
        {
            ArgumentOutOfRangeException expectedException;
            expectedException =
                new ArgumentOutOfRangeException("PicrossSegment not" +
                    " large enough to contain supplied BlockGroups.");
            try
            {
                PicrossSegment ps = new PicrossSegment(10, 15);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Assert.AreEqual(expectedException.Message, e.Message);
            }
        }
        [TestMethod()]
        public void Constructor_Length15Groups16()
        {
            ArgumentOutOfRangeException expectedException;
            expectedException =
                new ArgumentOutOfRangeException("PicrossSegment not" +
                    " large enough to contain supplied BlockGroups.");
            try
            {
                PicrossSegment ps = new PicrossSegment(15, 16);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Assert.AreEqual(expectedException.Message, e.Message);
            }
        }

        /*  Zero or negative values passed in as length of segment or as group
         *  members. */
        [TestMethod()]
        public void Constructor_Length0Groups16()
        {
            ArgumentOutOfRangeException expectedException;
            expectedException =
                new ArgumentOutOfRangeException("length", "Length of" +
                    " PicrossSegment must be greater than 0.");
            try
            {
                PicrossSegment ps = new PicrossSegment(0, 16);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Assert.AreEqual(expectedException.Message, e.Message);
            }
        }
        [TestMethod()]
        public void Constructor_Length5GroupsNeg1()
        {
            ArgumentOutOfRangeException expectedException;
            expectedException =
                new ArgumentOutOfRangeException("size",
                    "Size must be greater than 0.");
            try
            {
                PicrossSegment ps = new PicrossSegment(5, -1);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Assert.AreEqual(expectedException.Message, e.Message);
            }
        }
        [TestMethod()]
        public void Constructor_Length5Groups3AndNeg1()
        {
            ArgumentOutOfRangeException expectedException;
            expectedException =
                new ArgumentOutOfRangeException("size",
                    "Size must be greater than 0.");
            try
            {
                PicrossSegment ps = new PicrossSegment(5, 3, -1);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Assert.AreEqual(expectedException.Message, e.Message);
            }
        }
        [TestMethod()]
        public void Constructor_Length5Groups5And0And0()
        {

            ArgumentOutOfRangeException expectedException;
            expectedException =
                new ArgumentOutOfRangeException("size",
                    "Size must be greater than 0.");
            try
            {
                PicrossSegment ps = new PicrossSegment(5, 0, 0);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Assert.AreEqual(expectedException.Message, e.Message);
            }
        }

        // These objects should all be valid. No errors should be thrown.
        [TestMethod()]
        public void Constructor_Length15Groups15()
        {
            PicrossSegment ps = new PicrossSegment(15, 15);
        }
        [TestMethod()]
        public void Constructor_Length5Groups5()
        {
            PicrossSegment ps = new PicrossSegment(5, 5);
        }
        [TestMethod()]
        public void Constructor_Length5Groups1And3()
        {
            PicrossSegment ps = new PicrossSegment(5, 1, 3);
        }
        [TestMethod()]
        public void Constructor_Length10Groups7()
        {
            PicrossSegment ps = new PicrossSegment(10, 7);
        }
        [TestMethod()]
        public void Constructor_Length10Groups2And7()
        {
            PicrossSegment ps = new PicrossSegment(10, 2, 7);
        }

        // Testing some default values
        [TestMethod()]
        public void Length_NewObject()
        {
            PicrossSegment ps = new PicrossSegment(5, 1, 2);
            Assert.AreEqual(ps.Length, 5);
        }
        [TestMethod()]
        public void SolvedGroups_NewObject()
        {
            PicrossSegment ps = new PicrossSegment(5, 1, 2);
            Assert.AreEqual(ps.SolvedGroups, 0);
        }
        [TestMethod()]
        public void IsSolved_NewObject()
        {
            PicrossSegment ps = new PicrossSegment(5, 1, 2);
            Assert.AreEqual(ps.IsSolved, false);
        }
        [TestMethod()]
        public void GetFormattedBlocks_NewObject()
        {
            PicrossSegment ps = new PicrossSegment(5, 4);
            Assert.AreEqual(ps.GetFormattedBlocks(), "[ ][ ][ ][ ][ ]");
        }

        // Ensuring obtained array is a copy and cannot modify original
        [TestMethod()]
        public void ReturnCopyOfBlocks_NewObject()
        {
            PicrossSegment ps = new PicrossSegment(10, 4);
            char[] newArray = new char[ps.Length];
            newArray = ps.GetBlocks();
            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = 'X';
            }

            Assert.AreNotEqual(newArray, ps.GetBlocks());
        }

    }

}