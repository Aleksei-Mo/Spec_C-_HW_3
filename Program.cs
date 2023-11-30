// Дан массив и число. Найдите три числа в массиве сумма которых равна искомому числу. 
//Подсказка: если взять первое число в массиве, можно ли найти в оставшейся его части два числа равных по сумме первому.

Console.Clear();
int array_lenght = EnterUserData("Enter lenght of array (should contain at least 3 numbers):");
int lowerLim = EnterUserData("Enter lower limit for random range (positive):");
int upperLim = EnterUserData("Enter upper limit for random range (positive):");
int userNumber = EnterUserData("Enter number:");
int precision = 0; // only unsigned integer
if (array_lenght < 3)
{
    array_lenght = 3;
    Console.WriteLine("The array lenght has been changed to 3!");
}
double[] randomArray = new double[array_lenght];

FillArray(randomArray, array_lenght, lowerLim, upperLim, precision);
Console.WriteLine("The entered array is:");
PrintArray(randomArray);
Find_Number(userNumber);

void Find_Number(int number)
{
    Array.Sort(randomArray);
    Console.WriteLine("The sorted array is:");
    PrintArray(randomArray);
    int k = 0;
    int n = 0;
    double sum = 0;
    int counter = 0;
    if (randomArray[0] > number)//if the min array member is bigger than the number = we cannot find sum
    {
        Console.WriteLine("This configuration doesn't have solution. Try again!");
    }

    for (int i = 0; i < array_lenght - 2; i++)
    {
        k = i + 1;
        n = array_lenght - 1;
        while (k < n)
        {
            sum = randomArray[k] + randomArray[i] + randomArray[n];
            if (sum == number)
            {
                counter++;
                Console.WriteLine("Solution #" + counter + " has been found: " + randomArray[k] + " + " + randomArray[i] + " + " + randomArray[n] + " =" + " " + number);
                k++;
                n--;
                continue;
            }
            if (sum < number)//if sum too small then need to move the array lower bound
            {
                k++;
                continue;
            }
            if (sum > number)//if sum too big then need to move the array upper bound
            {
                n--;
                continue;
            }
        }
    }
    if (counter == 0)
    {
        Console.WriteLine("This configuration doesn't have solution. Try again!");
    }
}

double[] FillArray(double[] array, int array_lenght, int lowerLim, int upperLim, int precision)
{
    if (lowerLim < 0)
    {
        lowerLim = lowerLim * (-1);
    }
    if (upperLim < 0)
    {
        upperLim = upperLim * (-1);
    }
    if (lowerLim > upperLim)
    {
        int temp = lowerLim;
        lowerLim = upperLim;
        upperLim = temp;
    }
    for (int j = 0; j < array.GetLength(0); j++)
    {
        double randomNum = new Random().NextDouble() * (upperLim - lowerLim);
        randomArray[j] = Math.Round(randomNum, precision);
    }
    return array;
}

void PrintArray(double[] array)
{
    for (int j = 0; j < array.GetLength(0); j++)
    {
        Console.Write(array[j] + " ");
    }
    Console.WriteLine();
}

int EnterUserData(string nameUserData)
{
    Console.Write($"{nameUserData}");
    return Convert.ToInt32(Console.ReadLine());
}