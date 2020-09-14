using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sort;
using System;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Str_less_to_up_11_elements_InsertionSort()
        {
            //arrange
            int[] arr = { 234, 443, 582, 484, 326, 746, 245, 126, 453, 615 };
            //actual
            string res = "126 234 245 326 443 453 484 582 615 746";

            string resFunc = Sorting.InsertionSort(arr);

            //assert
            Assert.AreEqual(resFunc, res);
        }

        [TestMethod]
        public void Str_up_to_less_11_elements_SortDecreaseInt()
        {
            //arrange
            int[] arr = { 234, 443, 582, 484, 326, 746, 245, 126, 453, 615 };
            //actual
            string res = "746 615 582 484 453 443 326 245 234 126";

            string resFunc = Sorting.SortDecreaseInt(arr);

            //assert
            Assert.AreEqual(resFunc, res);
        }

        [TestMethod]
        public void Str_less_to_up_SortAscending()
        {
            //arrange
            string[] array = { "fhdy", "dhvdsd", "q", "rw", "qwe", "qwasda", "sdasdww" };
            //actual
            string res = "q rw qwe fhdy dhvdsd qwasda sdasdww ";

            string resFunc = Sorting.SortAscending(array);

            //assert
            Assert.AreEqual(resFunc, res);
        }

        [TestMethod]
        public void Str_up_to_less_SortDecrease()
        {
            //arrange
            string[] array = { "fhdy", "dhvdsd", "q", "rw", "qwe", "qwasda", "sdasdww" };
            //actual
            string res = "sdasdww dhvdsd qwasda fhdy qwe rw q ";

            string resFunc = Sorting.SortDecrease(array);

            //assert
            Assert.AreEqual(resFunc, res);
        }
    }
}
