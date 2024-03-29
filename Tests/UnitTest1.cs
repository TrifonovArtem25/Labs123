using Lab1;
using Lab1._1;
using Lab2;
using Lab3;
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
namespace Lab2
{
    public class Lab2_Test
    {
        [Fact]
        public void Testing()
        {
            PlayList test = new PlayList();

            Song snow = new Song("Red Hot Chili Peppers", "Snow");
            Song wonderwall = new Song("Oasis", "Wonderwall");
            Song kids = new Song("MGMT", "Kigs");
            Song extremeWays = new Song("Moby", "Extreme Ways");

            test.AddSong(snow);
            test.AddSong(wonderwall);
            test.AddSong(kids);
            int beforeAdding = test.Songs.Count();
            test.AddSong(extremeWays);

            Assert.Equal(beforeAdding, test.Songs.Count() - 1);

            int beforeDeleting = test.Songs.Count();
            test.DeleteSong(snow);

            Assert.Equal(beforeDeleting, test.Songs.Count() + 1);
        }
    }
}
namespace Lab3
{
    public class Lab3_Test
    {
        [Fact]
        public void Testing()
        {
            PlayList test = new PlayList();

            Song snow = new Song("Red Hot Chili Peppers", "Snow");
            Song wonderwall = new Song("Oasis", "Wonderwall");
            Song kids = new Song("MGMT", "Kigs");
            Song extremeWays = new Song("Moby", "Extreme Ways");

            test.AddSong(snow);
            test.AddSong(wonderwall);
            test.AddSong(kids);
            int beforeAdding = test.Songs.Count();
            test.AddSong(extremeWays);

            Assert.Equal(beforeAdding, test.Songs.Count() - 1);

            int beforeDeleting = test.Songs.Count();
            test.DeleteSong(snow);

            Assert.Equal(beforeDeleting, test.Songs.Count() + 1);

            test.ToJSON();

            PlayList loaded = test.FromJSON();

            Assert.Equal(test.Songs.Count(), loaded.Songs.Count());

            string SQL_PL_name = "test";

            test.ToSQL(SQL_PL_name);
            test.FromSQL(SQL_PL_name);
            loaded = test;

            Assert.Equal(test.Songs.Count(), loaded.Songs.Count());
        }
    }
}
