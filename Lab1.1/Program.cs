namespace Lab1;

public class Program
{
    private float[] massiv;
    private float X;

    public Program()
    {
        Random r = new Random();
        int N = r.Next() % 20 + 1;
        massiv = new float[N];
        X = r.NextSingle() * 20 - 10;
        for (int i = 0; i < massiv.Length; i++)
        {
            massiv[i] = (r.NextSingle() * 20 - 10);
        }

    }

    public int compareToX()
    {
        int count = 0;
        for (int i = 0; i < massiv.Length; i++)
        {
            if (massiv[i] > X)
            {
                count++;
            }
        }

        return count;
    }

    public float multiplication()
    {
        float result = 1;
        float max = -0.1f;
        for (int i = 0; i < massiv.Length; i++)
        {
            result *= massiv[i];
            if (Math.Abs(massiv[i]) > max) // если новое значение больше текущего максимального
            {
                result = 1; // сбрасываем результат произведения
                max = Math.Abs(massiv[i]); // устанавливаем новое текущее максимальное значение
            }
        }
        return result;
    }

    public void Sort()
    {
        int j = 0;
        while (j < massiv.Length)
        {
            if (massiv[j] < 0)
            {
                float val = massiv[j];
                int i = j;
                for (i = j; i > 0; i--)
                {
                    massiv[i] = massiv[i - 1];
                }
                massiv[i] = val;
            }
            j++;
        }
    }

    public void show()
    {
        for (int i = 0; i < massiv.Length; i++)
        {
            Console.WriteLine(i + ". " + massiv[i]);
        }
    }
    static void Main(string[] args)
    {
        Program p = new Program();
        Console.WriteLine("X: " + p.X);
        Console.WriteLine();
        p.show();
        Console.WriteLine("Numbers greater than X: " + p.compareToX());
        Console.WriteLine("Multiplication result: " + p.multiplication());
        p.Sort();
        Console.WriteLine("------------------------");
        Console.WriteLine("Sorted massiv");

        p.show();
    }
}