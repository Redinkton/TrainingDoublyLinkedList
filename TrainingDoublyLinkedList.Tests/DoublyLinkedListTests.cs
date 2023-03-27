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
            Assert.AreEqual(expected, actual, "Correctly");
        }

        [TestMethod]
        public void AddAtIndex()
        {
            // Arrange
            int expected = 100;
            DoublyLinkedList list = new DoublyLinkedList(new int[] { 2, 244, 5, 86, 1});

            // Act
            list.AddAtIndex(2, 100);

            // Assert
            int actual = list[2];
            Assert.AreEqual(expected, actual, "Correctly");
        }

        [TestMethod]
        public void RemoveFirstElement()
        {
            // Arrange
            bool expected = true;
            MainList = new DoublyLinkedList(new int[] { 1, 2, 3, 4, 5 });
            SecondaryList = new LinkedList<int>(new int [] { 2, 3, 4, 5 });

            // Act
            MainList.RemoveAt(0);

            // Assert
            bool actual = Equals(SecondaryList);
            Assert.AreEqual(expected, actual, "Correctly");
        }

        [TestMethod]
        public void RemoveLastElement()
        {
            // Arrange
            bool expected = true;
            MainList = new DoublyLinkedList(new int[] { 1, 2, 3, 4, 5 });
            SecondaryList = new LinkedList<int>(new int[] { 1, 2, 3, 4 });

            // Act
            MainList.RemoveAt(MainList.Count-1);

            // Assert
            bool actual = Equals(SecondaryList);
            Assert.AreEqual(expected, actual, "Correctly");
        }

        [TestMethod]
        public void RemoveAllElements_3()
        {
            // Arrange
            bool expected = true;
            SecondaryList = new LinkedList<int>(new int []{ 1, 2, 4, 5, 2, 4 });
            MainList = new DoublyLinkedList(new int[] { 1, 3, 3, 2, 4, 5, 3, 2, 4, 3});

            // Act
            MainList.RemoveAllThisInstances(3);

            // Assert
            bool actual = Equals(SecondaryList);
            Assert.AreEqual(expected, actual, "Correctly");
        }

        [TestMethod]
        public void CLearAll()
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
            Assert.AreEqual(expected, actual, "Correctly");
        }

        #region Helper
        private bool Equals(LinkedList<int> secondaryList)
        {
            if (secondaryList != null)
            {
                int i = 0;
                foreach (var item in secondaryList)
                {
                    if (item != MainList[i])
                        return false;
                    i++;
                }
                return true;
            }
            return false;
        }

        private void FillList()
        {
            int i = 0;
            while (i < 99999)
            {
                MainList.Add(i);
                SecondaryList.AddLast(i);
                i++;
            }
        }
        #endregion
    }
}