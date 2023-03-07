// Индивидуальные задания 3. Вариант 4

using System.Security.Cryptography;

Vector a = new(5);
Console.WriteLine($"Введите вектор из {a.Arr.Length} вещественных чисел:");
a.InputVec();
Console.WriteLine("Массив: " + a);
Console.Write("Введите индекс элемента: ");
int i = Convert.ToInt32(Console.ReadLine());
Console.WriteLine($"Элемент с индексом {i} = {a.Elem(i)}");

Console.Write("Введите индекс элемента: ");
i = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите новое значение элемента: ");
double new_element = Convert.ToDouble(Console.ReadLine());
a.ChangeElem(i, new_element);
Console.WriteLine("Массив: " + a);

Vector b = new(5);
b.RandVec(-100, 100);
Console.WriteLine("Рандомный массив: " + b);

double x = 1.5;
if (a.LinearSearch(x) == -1) Console.WriteLine($"Элемент {x} осутствует.");
else Console.WriteLine($"Индекс элемента {x} = {a.LinearSearch(x)}");

if (a.IsSorted()) Console.WriteLine("Массив отсортирован по возрастанию.");
else Console.WriteLine("Массив не отсортирован по возрастанию.");

int ind = 0;
x = 3;
if (a.IsSorted())
{
    ind = a.BinarySearch(x);
    if (ind == -1) Console.WriteLine($"Элемент {x} отсутсвует.");
    else Console.WriteLine($"Индекс элемента {x} = {ind}");
}
else Console.WriteLine("Бинарный поиск невозможен в неотсортированном массиве.");

Vector a2 = new(a.Arr);
int k = 3;
a2.LeftShift(k);
Console.WriteLine($"Массив, полученный сдвигом влево на {k}: " + a2);

if (a.AreTwoNegativeElements()) Console.WriteLine("В массиве есть два рядом стоящих отрицательных числа.");
else Console.WriteLine("В массиве нет двух рядом стоящих отрицательных чисел.");

Vector a3 = new(a.Arr);
a3.HeapSort();
Console.WriteLine("Результат пирамидальной сортировки: " + a3);

