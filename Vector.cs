#pragma warning disable
public class Vector
{
    public double[] Arr { get; set; }
    public Vector(double[] a) {
        Arr = (double[])a.Clone();
    }
    public Vector() : this(1)
    { }
    public Vector(int n)
    {
        if (n <= 0) { n = 1; }
        Arr = new double[n];
    }

    public void InputVec()
    {
        for (int i = 0; i < Arr.Length; i++) { Arr[i] = Convert.ToDouble(Console.ReadLine()); }
    }
    public override string ToString()
    {
        string array = "";
        for (int i = 0; i < Arr.Length; i++) { array = array + Arr[i] + " "; }
        return array;
    }
    public double Module()
    {
        double sum_square = 0;
        for (int i = 0; i < Arr.Length; i++) { sum_square += Math.Pow(Arr[i], 2); }
        return Math.Round(Math.Sqrt(sum_square), 3);
    }
    public double MaxElem()
    {
        int ind = 0;
        for (int i = 1; i < Arr.Length; i++) { if (Arr[i] > Arr[ind]) ind = i; }
        return Arr[ind];
    }
    public int IndMinElem()
    {
        int ind = 0;
        for (int i = 1; i < Arr.Length; i++) { if (Arr[i] < Arr[ind]) ind = i; }
        return ind;
    }
    public Vector VecPositiveElem()
    {
        int size = 0, count = 0;
        for (int i = 0; i < Arr.Length; i++) { if (Arr[i] > 0) size++; }
        Vector arr_new = new(size);
        for (int i = 0; i < Arr.Length; i++) { if (Arr[i] > 0) arr_new.Arr[count++] = Arr[i]; }
        return arr_new;
    }
    public static Vector? Sum(Vector a, Vector b)
    {
        if (a.Arr.Length != b.Arr.Length)
        {
            return null;
        }
        Vector res = new(a.Arr.Length);
        for (int i = 0; i < a.Arr.Length; i++) { res.Arr[i] = a.Arr[i] + b.Arr[i]; }
        return res;
    }
    public static double? ScalarProduct(Vector a, Vector b)
    {
        if (a.Arr.Length != b.Arr.Length)
        {
            return null;
        }
        double res = 0;
        for (int i = 0; i < a.Arr.Length; i++) { res += a.Arr[i] * b.Arr[i]; }
        return res;
    }
    public static bool CheckEquality(Vector a, Vector b)
    {
        if (a.Arr.Length != b.Arr.Length) return false;
        for (int i = 0; i < a.Arr.Length; i++)
        {
            if (a.Arr[i] != b.Arr[i]) return false;
        }
        return true;
    }
    public double Elem(int i)
    {
        if (i >= 0) return Arr[i];
        else return Arr[^-i];
    }
    public void ChangeElem(int i, double new_el)
    {
        if (i >= 0) Arr[i] = new_el;
        else Arr[^-i] = new_el;
    }
    public void RandVec(int a, int b)
    {
        Random rnd = new();
        for (int i = 0; i < Arr.Length; i++) Arr[i] = rnd.Next(a, b);
    }
    public int LinearSearch(double el)
    {
        for (int i = 0; i < Arr.Length; i++) {
            if (Arr[i] == el) return i;
        }
        return -1;
    }
    public bool IsSorted()
    {
        for (int i = 0; i < Arr.Length - 1;) {
            if (Arr[i] > Arr[++i]) return false;
        }
        return true;
    }
    public int BinarySearch(double el)
    {
        bool flag = false;
        int mid = 0, l = 0, r = Arr.Length - 1;
        while ((l <= r) & (!flag))
        {
            mid = (l + r) / 2;
            if (Arr[mid] == el) flag = true;
            else if (Arr[mid] > el) r = mid - 1;
            else l = mid + 1;
        }
        if (flag) return mid;
        return -1;
    }
    public void LeftShift(int k)
    {
        int n = Arr.Length;
        double[] a = new double[n];
        for (int i = 0; i < n; i++)
        {
            a[(i + n - k) % n] = Arr[i];
        }
        Arr = a;
    }
    public bool AreTwoNegativeElements()
    {
        for (int i = 0; i < Arr.Length - 1;) {
            if (Arr[i] < 0 & Arr[++i] < 0) return true;
        }
        return false;
    }
    public void HeapSort()
    {
        int n = Arr.Length;
        for (int i = n / 2; i >= 0; i--)    // формируем нижний ряд пирамиды
            Heapify(i, n - 1);
        for (int i = n - 1; i >= 1; i--)    // просеиваем через пирамиду остальные элементы
        {
            double temp = Arr[0];
            Arr[0] = Arr[i];
            Arr[i] = temp;
            Heapify(0, i - 1);
        }
    }
    private void Heapify(int root, int bottom)  // формирование кучи
    {
        int largest;    // индекс максимального потомка
        bool done = false;   // маркер сформированности кучи
        while ((root * 2 <= bottom) & (!done))   // пока не дошли до последнего ряда
        {
            if (root * 2 == bottom)     // если мы в последнем ряду
                largest = root * 2;
            else if (Arr[root * 2] > Arr[root * 2 + 1])
                largest = root * 2;
            else largest = root * 2 + 1;
            if (Arr[root] < Arr[largest])       // если элемент вершины меньше максимального потомка
            {
                double temp = Arr[root];
                Arr[root] = Arr[largest];
                Arr[largest] = temp;
                root = largest;
            }
            else done = true;
        }
    }
}
