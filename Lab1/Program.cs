using Lab1._1;
using Xunit.Abstractions;

namespace Lab1;

public class Program
{
    static void Main(string[] args)
    {
        //float[] toTest = { 1, -2, 6, 0, -8, 3, 5, -1 };
        //float X = 2;
        //question1 q1 = new question1(toTest, X);
        question1 q1 = new question1();
        Console.WriteLine("X: " + q1.GetX());
        Console.WriteLine();
        q1.show();
        Console.WriteLine("Numbers greater than X: " + q1.compareToX());
        Console.WriteLine("Multiplication result: " + q1.multiplication());
        q1.Sort();
        Console.WriteLine("------------------------");
        Console.WriteLine("Sorted massiv");

        q1.show();

        Console.WriteLine("------------------------");
        Console.WriteLine("------------------------");
        Console.WriteLine("------------------------");
        Console.WriteLine("------------------------");


        question2 q2 = new question2();
        q2.show();
        Console.WriteLine("First column with zero element: " + q2.FirstZeroColumn());
        Console.WriteLine("---------------------------------");
        Console.WriteLine("sorted matrix: ");
        int[] clist = q2.characteristic();
        q2.setMatrix(q2.sort());
        q2.show();
    }

}