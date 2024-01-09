using System.Diagnostics;

class Program
{
    private int[,] matrix;

    public Program()
    {
        Random r = new Random();
        Console.WriteLine();
        matrix = new int[r.Next() % 10 + 1, r.Next() % 10 + 1];
        Console.WriteLine("Высота: " + matrix.GetLength(0));
        Console.WriteLine("Длина: " + matrix.GetLength(1));
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = r.Next() % 31 - 15;
            }
        }
    }
    public int FirstZeroColumn()
    {
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                if (matrix[j, i] == 0)
                {
                    return i;
                }
            }
        }

        return -1;
    }

    public void show()
    {
        int[] clist = characteristic();
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write("{0,5}", matrix[i, j]);
            }
            Console.Write("{0,10}", clist[i]);
            Console.WriteLine();
        }
    }
    public int [] characteristic()
    {
        int [] clist = new int[matrix.GetLength(0)];
        int val = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if ((matrix[i, j] < 0) && (matrix[i, j] % 2 == 0))
                {
                    val += matrix[i, j];
                }
            }
            clist[i] = val;
            val = 0;
        }
        return clist;
    }
    public void replaceLine(int i)
    {
        for(int j=0; j < matrix.GetLength(1); j++)
        {
            int copy = matrix[i, j];
            matrix[i, j] = matrix[i - 1, j];
            matrix[i-1, j]= copy;
        }
    }
    public void sort()
    {
        if(matrix.GetLength(0) == 1)
        {
            return;
        }
        bool finish = false;
        int [] clist = characteristic();
        while (!finish)
        {
            finish = true;
            for(int i = 1; i < clist.GetLength(0); i++)
            {
                if (clist[i] > clist[i - 1])
                {
                    int copy = clist[i];
                    clist[i]= clist[i - 1];
                    clist[i-1]= copy;
                    replaceLine(i);
                    finish = false;
                    i++;
                }
            }
        }

    }
    public static void Main(string[] args)
    {
        Program p = new Program();
        p.show();
        Console.WriteLine("First column with zero element: " + p.FirstZeroColumn());
        Console.WriteLine("---------------------------------");
        Console.WriteLine("sorted matrix: ");
        int[] clist = p.characteristic();
        p.sort();
        p.show();
    }
}