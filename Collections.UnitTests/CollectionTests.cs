using NUnit.Framework;
using System;
using System.Linq;

namespace Collections.UnitTests
{
    public class CollectionTests
    {
        [Test]
        public void Test_Collection_EmptyConstructor()
        {
            // arrange
            var nums = new Collection<int>();

            // Assert
            Assert.That(nums.Count == 0, "Count property");
            Assert.AreEqual(nums.Capacity, 16, "Capacity property");
            Assert.That(nums.ToString() == "[]");

        }

        [Test]
        public void Test_Collection_ConstructorSingleItem()
        {
            // arrange
            var nums = new Collection<int>(5);

            // Assert
            Assert.That(nums.Count == 1, "Count property");
            Assert.AreEqual(nums.Capacity, 16, "Capacity property");
            Assert.That(nums.ToString() == "[5]");
        }

        [Test]
        public void Test_Collection_ConstructorMultipleleItems()
        {
            // arrange
            var nums = new Collection<int>(5, 6);

            // Assert
            Assert.That(nums.Count == 2, "Count property");
            Assert.AreEqual(nums.Capacity, 16, "Capacity property");
            Assert.That(nums.ToString() == "[5, 6]");
        }

        [Test]
        public void Test_Collection_Add()
        {
            // arrange
            var nums = new Collection<int>();

            // act
            nums.Add(7);

            // Assert
            Assert.That(nums.Count == 1, "Count property");
            Assert.AreEqual(nums.Capacity, 16, "Capacity property");
            Assert.That(nums.ToString() == "[7]");
        }

        [Test]
        public void Test_Collection_AddRange()
        {
            // arrange
            var items = new int[] { 6, 7, 8, };
            var nums = new Collection<int>();

            // act
            nums.AddRange(items);

            // assert
            Assert.That(nums.Count == 3, "Count property");
            Assert.AreEqual(nums.Capacity, 16, "Capacity property");
            Assert.That(nums.ToString() == "[6, 7, 8]");
        }

        [Test]
        [Timeout(5000)]
        public void Test_Collection_1MillionItems()
        {
            const int itemsCount = 10000;
            var nums = new Collection<int>();

            nums.AddRange(Enumerable.Range(1, itemsCount).ToArray());
            Assert.That(nums.Count == itemsCount);
            Assert.That(nums.Capacity >= nums.Count);
            for (int i = itemsCount - 1; i >= 0; i--)
                nums.RemoveAt(i);
            Assert.That(nums.ToString() == "[]");
            Assert.That(nums.Capacity >= nums.Count);
        }

        [Test]
        public void Test_Collection_InsertAtBeginning()
        {
            var numbers = new int[] {1, 2, 3, 4, 5, 6 };
            int InsertNumber = 0;
            var collection = new Collection<int>(numbers);

            collection.InsertAt(0, InsertNumber);
            
            Assert.AreEqual(InsertNumber, collection[0]);
        }

        [Test]
        public void Test_Collection_InsertAtEnd()
        {
            var numbers = new int[] { 1, 2, 3, 4, 5, 6 };
            int InsertNumber = 0;
            var collection = new Collection<int>(numbers);

            collection.InsertAt(numbers.Length, InsertNumber);

            Assert.AreEqual(InsertNumber, collection[numbers.Length]);
        }

        [Test]
        public void Test_Collection_Clear()
        {
            var numbers = new int[] { 1, 2, 3, 4, 5, 6 };
            var collection = new Collection<int>(numbers);

            collection.Clear();

            Assert.AreEqual(0, collection.Count);
        }
        [Test]
        public void Test_Exhange_FirstAndLast()
        {
            var numbers = new int[] { 1, 2, 3, 4, 5, 6 };
            var collection = new Collection<int>(numbers);

            collection.Exchange(0, numbers.Length - 1);
            Assert.AreEqual(numbers[numbers.Length -1], collection[0]);
        }

        [Test]
        public void Test_Collection_ToStringSingle()
        {
            var collection = new Collection<int>(5);

            Assert.That(collection.ToString(), Is.EqualTo("[5]"));
        }

        [Test]
        public void Test_Collection_ToStringMultiple()
        {
            var collection = new Collection<int>(10, 20);

            Assert.That(collection.ToString(), Is.EqualTo("[10, 20]"));
        }
        [Test]
        public void Test_Collection_RemoveItem()
        {
            var numbers = new int[] { 1, 2, 3, 4, 5, 6 };
            var collection = new Collection<int>(numbers);

            collection.RemoveAt(1);

            Assert.AreEqual(numbers[2], collection[1]);
        }

        [Test]
        public void Test_Collection_GetByIndex()
        {
            var names = new Collection<string>("Peter", "Alex");

            var firstName = names[0];
            var secondName = names[1];

            Assert.AreEqual("Peter", firstName);
            Assert.AreEqual("Alex", secondName);
        }

        [Test]
        public void Test_Collection_SetByIndex()
        {
            var nums = new int[] { 1, 3, 5, 7 };
            int insertNum = 5;

            var collection = new Collection<int>(nums);

            collection.InsertAt(4, insertNum);

            Assert.AreEqual(insertNum, collection[4]);
        }

        [Test]
        public void Test_Collection_SetByInvalidIndex()
        {
            var nums = new int[] { 1, 3, 5, 7 };
            int insertNum = 5;

            var collection = new Collection<int>(nums);

            Assert.That(() => collection.InsertAt(-1, insertNum), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collection_Set_WithIndex()
        {
            var collection = new Collection<int>(1, 2, 3);

            collection[2] = 4;

            Assert.AreEqual(4, collection[2]);
        }

        [TestCase("Peter", 0, "Peter")]
        [TestCase("Peter, Maria, George", 0, "Peter")]
        [TestCase("Peter, Maria, George", 1, "Maria")]
        [TestCase("Peter, Maria, George", 2, "George")]

        public void Test_Collection_GetByValidIndex(
            string data, int index, string expectedValue)
        {
            var nums = new Collection<string>(data.Split(", "));
            var actual = nums[index];

            Assert.AreEqual(expectedValue, actual);
        }
    }
}