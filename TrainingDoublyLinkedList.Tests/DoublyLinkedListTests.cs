using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TrainingDoublyLinkedList.Tests
{
    [TestClass]
    public class DoublyLinkedListTests
    {
        private DoublyLinkedList MainList { get; set; }
        private LinkedList<int> SecondaryList {  get; set; }

        [TestMethod]
        public void AddElements()
        {
            // Arrange
            bool expected = true;
            MainList = new DoublyLinkedList();
            SecondaryList = new LinkedList<int>();

            // Act
            FillList();

            // Assert
            bool actual = Equals(SecondaryList);
            Assert.AreEqual(expected, actual, "Addition to LinkedList and DoublyLinkedList has different results");
        }

        [TestMethod]
        public void AddAtIndex()
        {
            // Arrange
            bool expected = true;
            MainList = new DoublyLinkedList(new int[] { 2, 244, 5, 86, 1 });
            SecondaryList = new LinkedList<int>(new int[] { 2, 244, 100, 86, 1 });

            // Act
            MainList.AddAtIndex(2, 100);

            // Assert
            bool actual = Equals(SecondaryList);
            Assert.AreEqual(expected, actual, "Addition by index to LinkedList and Doubly Linked List has different results");
        }

        [TestMethod]
        public void RemoveAt_FirstElement_MainEqualSecondary()
        {
            // Arrange
            bool expected = true;
            MainList = new DoublyLinkedList(new int[] { 1, 2, 3, 4, 5 });
            SecondaryList = new LinkedList<int>(new int [] { 2, 3, 4, 5 });

            // Act
            MainList.RemoveAt(0);

            // Assert
            bool actual = Equals(SecondaryList);
            Assert.AreEqual(expected, actual, "After removal first element LinkedList and Doubly Linked List has different results");
        }

        [TestMethod]
        public void RemoveAt_LastElement_MainEqualSecondary()
        {
            // Arrange
            bool expected = true;
            MainList = new DoublyLinkedList(new int[] { 1, 2, 3, 4, 5 });
            SecondaryList = new LinkedList<int>(new int[] { 1, 2, 3, 4 });

            // Act
            MainList.RemoveAt(MainList.Count-1);

            // Assert
            bool actual = Equals(SecondaryList);
            Assert.AreEqual(expected, actual, "Removal last element LinkedList and Doubly Linked List has different results");
        }

        [TestMethod]
        public void RemoveAllElements_3RemoveFromMain_MainEqualSecondary()
        {
            // Arrange
            bool expected = true;
            MainList = new DoublyLinkedList(new int[] { 1, 3, 3, 2, 4, 5, 3, 2, 4, 3 });
            SecondaryList = new LinkedList<int>(new int[] { 1, 2, 4, 5, 2, 4 });

            // Act
            MainList.RemoveAllThisInstances(3);

            // Assert
            bool actual = Equals(SecondaryList);
            Assert.AreEqual(expected, actual, "Removal all instances \"3\" element LinkedList and Doubly Linked List has different results");
        }

        [TestMethod]
        public void RemoveAllThisInstances_1RemoveFromMain_MainEqualSecondary()
        {
            // Arrange
            bool expected = true;
            MainList = new DoublyLinkedList(new int[] { 1, 1, 1, 1, 1, 4, 1, 4 });
            SecondaryList = new LinkedList<int>(new int[] { 4, 4 });

            // Act
            MainList.RemoveAllThisInstances(1);
            // Assert
            bool actual = Equals(SecondaryList);
            Assert.AreEqual(expected, actual, "Removal all instances \"1\" element LinkedList and Doubly Linked List has different results");
        }

        [TestMethod]
        public void CLearAll_MainSecondary_MainEqualSecondary()
        {
            // Arrange
            bool expected = true;
            MainList = new DoublyLinkedList(new int[] { 1, 3, 3, 2, 4, 5, 3, 2, 4, 3 });
            SecondaryList = new LinkedList<int>(new int[] { 3, 44, 74, 16, 90, 0, 3 });

            // Act
            MainList.Clear();
            SecondaryList.Clear();

            //Assert
            bool actual = Equals(SecondaryList);
            Assert.AreEqual(expected, actual, "Cleaning LinkedList and DoublyLinkedList has different results");
        }

        [TestMethod]
        public void AddAtIndex_AddToAnyWrongIndex_NullReferenceExceptionReturned()
        {
            // Arrange
            bool expected = true;
            MainList = new DoublyLinkedList();

            // Act
            MainList.Add(811);
            MainList.Add(77);
            var ex = Assert.ThrowsException<NullReferenceException>(() => MainList.AddAtIndex(100, 100));

            // Assert
            Assert.AreEqual("Object reference not set to an instance of an object.", ex.Message);
        }

        [TestMethod]
        public void RemoveAt_FromMiddle_MainEqualSecondary()
        {
            // Arrange
            bool expected = true;
            MainList = new DoublyLinkedList(new int[] { 1, 2, 3, 4, 5, 6 });
            SecondaryList = new LinkedList<int>(new int[] { 1, 2, 4, 5, 6 });

            // Act
            MainList.RemoveAt(2);

            // Assert
            bool actual = Equals(SecondaryList);
            Assert.AreEqual(expected, actual, "Removal the middle element LinkedList and Doubly Linked List has different results");
        }

        [TestMethod]
        public void RemoveAt_ToAnyWrongIndex_MainEqualSecondary()
        {
            // Arrange
            bool expected = true;
            MainList = new DoublyLinkedList(new int[] { 1, 2, 3, 4, 5, 6 });

            // Act
            var ex = Assert.ThrowsException<NullReferenceException>(() => MainList.RemoveAt(99));

            // Assert
            Assert.AreEqual("Object reference not set to an instance of an object.", ex.Message);
        }

        [TestMethod]
        public void AddAtIndex_AddToZeroIndex_NullReferenceExceptionReturned()
        {
            // Arrange
            bool expected = true;
            MainList = new DoublyLinkedList();
            SecondaryList = new LinkedList<int>(new int[] { 100, 77 });

            // Act
            MainList.Add(811);
            MainList.Add(77);
            MainList.AddAtIndex(0, 100);

            // Assert
            bool actual = Equals(SecondaryList);
            Assert.AreEqual(expected, actual, "Addition to the zero index LinkedList and DoublyLinkedList has different results");
        }

        [TestMethod]
        public void AddAtIndex_AddToLastIndex_NullReferenceExceptionReturned()
        {
            // Arrange
            bool expected = true;
            MainList = new DoublyLinkedList();
            SecondaryList = new LinkedList<int>(new int[] { 13, 77, 100 });

            // Act
            MainList.Add(13);
            MainList.Add(77);
            MainList.Add(199);
            MainList.AddAtIndex(2, 100);

            // Assert
            bool actual = Equals(SecondaryList);
            Assert.AreEqual(expected, actual, "Addition to the last index LinkedList and DoublyLinkedList has different results");
        }

        #region Helper
        private bool Equals(LinkedList<int> secondaryList)
        {
            if(MainList.Count != secondaryList.Count)
                return false;

            int i = 0;
            var main = MainList.First;
            var second = secondaryList.First;
            if (secondaryList != null)
            {
                while (main != null)
                {
                    if (main.Value != second.Value)
                        return false;
                    main = main.Next;
                    second = second.Next;
                    ++i;
                }
                return true;
            }

            //if (secondaryList != null)
            //{
            //    int i = 0;
            //    foreach (var item in secondaryList)
            //    {
            //        if (item != MainList[i])
            //            return false;
            //        i++;
            //    }
            //    return true;
            //}
            return false;
        }

        private void FillList()
        {
            for(int i = 0; i < 99999; i++)
            {
                MainList.Add(i);
                SecondaryList.AddLast(i);
            }
        }
        #endregion
    }
}