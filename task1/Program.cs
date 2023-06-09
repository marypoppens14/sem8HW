//задача 54. двумерный массив; программа, которая упорядочит по убыванию элементы каждой строки двумерного массива 
//задача 56. двумерный массив; программа, которая будет находить строку с наименьшей суммой элементов
//задача 58. две матрицы; программа, которая будет находить произведение двух матриц
//задача 62. Заполнить спирально массив 4 на 4

Console.WriteLine("Введите номер задачи: ");
int task = Convert.ToInt32(Console.ReadLine());

switch(task)
{
    case 1:
        task1();
        break;
    
    case 2:
        task2();
        break;
    
    case 3:
        task3();
        break;

    case 4:
        task4();
        break;
    
    default:
        break;
}


void task1()
{
    Console.WriteLine("Введите число столбцов: ");
    int m = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите число строк: ");
    int n = Convert.ToInt32(Console.ReadLine());

    int[,] array = new int[m, n];
    CreateArray(m, n);

    Console.WriteLine($"Новый массив: {array}");
    Sortirovka(array);
    WriteArray(array);

    void CreateArray(int m, int n)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = new Random().Next(1, 10);
                Console.Write(array[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
    
    void Sortirovka(int[,] array)
    {
    for (int i = 0; i < array.GetLength(0); i++)
        {
        for (int j = 0; j < array.GetLength(1); j++)
            {
                for (int k = 0; k < array.GetLength(1) - 1; k++)
                {
                    if (array[i, k] < array[i, k + 1])
                    {
                    int temp = array[i, k + 1];
                    array[i, k + 1] = array[i, k];
                    array[i, k] = temp;
                    }
                }
            }
        }
    }
    
    void WriteArray(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
            Console.Write(array[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}

void task2()
{
    Console.WriteLine("Введите число столбцов: ");
    int m = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите число строк: ");
    int n = Convert.ToInt32(Console.ReadLine());

    int[,] array = new int[m, n];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = new Random().Next(1, 10);
            Console.Write(array[i, j] + " ");
        }
        Console.WriteLine();
    }

    int SumLine(int[,] array, int i)
    {
        int sum = array[i, 0];
        for (int j = 1; j < array.GetLength(1); j++)
        {
            sum += array[i, j];
        }
        return sum;
    }
    int minSum = 1;
    int sum = SumLine(array, 0);
    for (int i = 1; i < array.GetLength(0); i++)
    {
        if (sum > SumLine(array, i))
        {
            sum = SumLine(array, i);
            minSum = i+1;
        }
    }
    Console.WriteLine($"Строка с минимальной суммой: {minSum}");

}

void task3()
{   
    Console.WriteLine("Число строк 1ой матрицы: ");
    int m = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Число столбцов 1ой матрицы (и строк второй): ");
    int n = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Число столбцов 2ой матрицы: ");
    int b = Convert.ToInt32(Console.ReadLine());

    int[,] matrix1 = new int[m, n];
    CreateArray(matrix1);
    Console.WriteLine("Матрица 1: ");
    WriteArray(matrix1);

    int[,] matrix2 = new int[n, b];
    CreateArray(matrix2);
    Console.WriteLine("Матрица 2: ");
    WriteArray(matrix2);

    int[,] matrix3 = new int[m, b];

    MultiplyMatrix(matrix1, matrix2, matrix3);
    Console.WriteLine("Произведение равно: ");
    WriteArray(matrix3);

    void MultiplyMatrix(int[,] matrix1, int[,] matrix2, int[,] matrix3)
    {
        for (int i = 0; i < matrix3.GetLength(0); i++)
        {
            for (int j = 0; j < matrix3.GetLength(1); j++)
            {
                int sum = 0;
                int k = 0;
                for (k = 0; k < matrix1.GetLength(1); k++)
                {
                    sum += matrix1[i, k] * matrix2[k, j];
                }
                matrix3[i, j] = sum;
            }
        }
    }
    void CreateArray(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = new Random().Next(1, 10);
            }
        }
    }
    void WriteArray(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write(array[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}

void task4()
{
    int m = 4;
    int n = 4;
    int[,] array = new int[m, n];
    int start = 1;
    int i = 0;
    int j = 0;

    while (start <= array.GetLength(0) * array.GetLength(1))
    {
        array[i, j] = start;
        start++;
        
        if (i <= j+1 && i + j < array.GetLength(1)-1)
        j++;

        else if (i < j && i + j >= array.GetLength(0)-1)
        i++;

        else if (i >= j && i + j > array.GetLength(1)-1)
        j--;

        else
        i--;
    }
   WriteArray(array);
   void WriteArray(int[,] array)
   {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (array[i, j] / 10 <= 0)
                Console.Write($"{array[i, j]} ");

                else 
                Console.Write($"{array[i, j]} ");
            }
            Console.WriteLine();
        }
   }
}