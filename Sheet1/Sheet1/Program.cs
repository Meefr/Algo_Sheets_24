// See https://aka.ms/new-console-template for more information

class HelperFunctions<T> where T : IComparable<T> {
    public static bool BinarySearch(T target, int start, int end, T[] arr) {
        if (start > end) return false;
        int mid = (start + end) / 2;
        if (arr[mid].CompareTo(target) == 0) return true;
        else if (arr[mid].CompareTo(target) > 0) return BinarySearch(target, start, mid - 1, arr);
        else return BinarySearch(target, mid + 1, end, arr);
    }
    private static T getMaxValue() {
        T maxT = default(T);
        if (typeof(T) == typeof(long))
            maxT = (T)Convert.ChangeType(long.MaxValue, typeof(T));
        else if (typeof(T) == typeof(int))
            maxT = (T)Convert.ChangeType(int.MaxValue, typeof(T));
        else if (typeof(T) == typeof(float))
            maxT = (T)Convert.ChangeType(float.MaxValue, typeof(T));
        else if (typeof(T) == typeof(double))
            maxT = (T)Convert.ChangeType(double.MaxValue, typeof(T));
        return maxT;
    }

    private static void merge(T[] arr, int start, int mid, int end) {
        int leftSize = mid - start + 1;
        int rightSize = end - mid;

        T[] leftArr = new T[leftSize + 1];
        T[] rightArr = new T[rightSize + 1];

        for (int i = 0; i < leftSize; i++)
            leftArr[i] = arr[start + i];
        for (int i = 0; i < rightSize; i++)
            rightArr[i] = arr[mid + 1 + i];

        leftArr[leftSize] = getMaxValue();
        rightArr[rightSize] = getMaxValue();

        int lIndex = 0, rIndex = 0, arrIndex = start;
        while (lIndex < leftSize || rIndex < rightSize) {
            if (rightArr[rIndex].CompareTo(leftArr[lIndex]) < 0)
                arr[arrIndex++] = rightArr[rIndex++];
            else
                arr[arrIndex++] = leftArr[lIndex++];
        }

    }

    public static void mergeSort(T[] arr, int start, int end) {
        if (start >= end)
            return;
        int mid = (start + end) / 2;
        mergeSort(arr, start, mid);
        mergeSort(arr, mid + 1, end);
        merge(arr, start, mid, end);
    }

}
class Sheet1 {

    /*
     * QUESTION1: Two Items with Difference X
        • Given
            – An array A of N integers.
            – An integer value X.
        • Required
            – Check is there TWO items whom difference equal X?
        • Examples
            – Input: A = {−7, −2, 5, −3, 8}, X = 4
            – Output: yes (-3 – (-7))
            - Input: A = {−10, 4, −5, 9, 8}, X = 2 
            – Output: No
        • Complexity: O(N²)
     */
    public bool DiffrenceX(int[] arr, int k) {
        HelperFunctions<int>.mergeSort(arr, 0, arr.Length - 1);
        for (int i = 0; i < arr.Length; i++) {
            int target = arr[i] + k;
            if (HelperFunctions<int>.BinarySearch(target, 0, arr.Length - 1, arr)) return true;
        }
        return false;
    }
    /*
     * QUESTION2: Powering a Number
        Write an efficient algorithm to compute 𝑨
        𝑵, 𝑵 𝒊𝒔 𝒑𝒐𝒔𝒊𝒕𝒊𝒗𝒆 𝒊𝒏𝒕𝒆𝒈𝒆𝒓
        without using "Power" function? 
        Complexity: O(Log(N))
     */
    public int Power(int A, int N) {
        if (N == 1) return A;
        int power = Power(A, N / 2);
        if (N % 2 != 0)
            return A * power * power;
        else
            return power * power;
    }
    public bool EvenOddCheck(int[] arr, int start, int end) {
        int mid = (start + end) / 2;
        if (start >= end) {
            if (arr[start] % 2 == 0)
                return true;
            return false;
        }
        bool right = EvenOddCheck(arr, start, mid);
        bool left = EvenOddCheck(arr, mid + 1, end);
        return (right && left);
    }

}


class Program {

    public static void Main(string[] args) {
        Sheet1 sheet1 = new Sheet1();
        /* //test mergeSorting
         *
        int[] arr = { 2, 7, 3, 4, 1, 6, 7, 8, 9 };
        HelperFunctions<int>.mergeSort(arr, 0, arr.Length - 1);
        for (int i = 0; i < arr.Length; i++) {
            Console.WriteLine(arr[i]);
        }*/

        /* //test binarySearching
        //Console.WriteLine(helper.BinarySearch(9, 0, arr.Length - 1, arr));
        */


        /* //Question 1
         int []arr = { -10, 4, -5, 9, 8 };
         Console.WriteLine(sheet1.DiffrenceX(arr, 2));
        */

        /* //Question 2
        Console.WriteLine(sheet1.Power(2, 3));
        */

        /*//Question 3
        int[] arr = { 1, 30, 4, 300000000, 5, 8, 7, 4, 5 };
        Console.WriteLine(sheet1.EvenOddCheck(arr,0,arr.Length-1));
         */

    }

}