using Lab1;
using Lab1._1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using NuGet.Frameworks;

namespace Lab1
{
    public class question1_Test
    {
        [Fact]
        public void testGreaterThenX_Values_Count()
        {
            float[] toTest = { 1, -2, 6, 0, -8, 3, 5, -1 };
            float X = 2;
            int expectedResult = 3;
            question1 test = new question1(toTest, X);

            //Console.WriteLine(test.compareToX());

            Assert.Equal(expectedResult, test.compareToX());
        }
        [Fact]
        public void testMultiplication()
        {
            float[] toTest = { 1, -2, 6, 0, -8, 3, 5, -1 };
            float X = 2;
            float expectedResult = -15;
            question1 test = new question1(toTest, X);

            Assert.Equal(expectedResult, test.multiplication());
        }
    }
    public class question2_Test
    {
        [Fact]
        public void test_FirstZeroColumn()
        {
            int[,] toTest = { { 0, 5, -2 }, { 3, 5, -6 }, { -7, 4, 9 } };
            question2 test = new question2(toTest);
            int expectedResult = 0;

            Assert.Equal(expectedResult, test.FirstZeroColumn());
        }
        [Fact]
        public void test_sort()
        {
            int[,] toTest = { { 0, 5, -2 }, { 3, 5, -6 }, { -7, 4, 9 } };

            question2 test = new question2(toTest);

            int[,] expectedResult = { { -7, 4, 9 }, { 0, 5, -2 }, { 3, 5, -6 }};

            Assert.Equal(new int [,]{ { -7, 4, 9 }, { 0, 5, -2 }, { 3, 5, -6 } }, test.sort());
        }
    }
}
