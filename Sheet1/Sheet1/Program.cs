// See https://aka.ms/new-console-template for more information
using System;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

class HelperFunctions<T> where T : IComparable<T>
{
    public static bool BinarySearch(T target, int start, int end, T[] arr)
    {
        if (start > end) return false;
        int mid = (start + end) / 2;
        if (arr[mid].CompareTo(target) == 0) return true;
        else if (arr[mid].CompareTo(target) > 0) return BinarySearch(target, start, mid - 1, arr);
        else return BinarySearch(target, mid + 1, end, arr);
    }
    private static T getMaxValue()
    {
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

    private static void merge(T[] arr, int start, int mid, int end)
    {
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
        while (lIndex < leftSize || rIndex < rightSize)
        {
            if (rightArr[rIndex].CompareTo(leftArr[lIndex]) < 0)
                arr[arrIndex++] = rightArr[rIndex++];
            else
                arr[arrIndex++] = leftArr[lIndex++];
        }

    }

    public static void mergeSort(T[] arr, int start, int end)
    {
        if (start >= end)
            return;
        int mid = (start + end) / 2;
        mergeSort(arr, start, mid);
        mergeSort(arr, mid + 1, end);
        merge(arr, start, mid, end);
    }

}


class Program
{


    class Sheet1
    {

        public struct MaxDiffNode
        {
            public int min, max, diff;
            public MaxDiffNode()
            {
                min = int.MaxValue;
                max = int.MinValue;
                diff = int.MinValue;
            }
        }
        ///* QUESTION1: Two Items with Difference X
        // * 
        //    • Given
        //        – An array A of N integers.
        //        – An integer value X.
        //    • Required
        //        – Check is there TWO items whom difference equal X?
        //    • Examples
        //        – Input: A = {−7, −2, 5, −3, 8}, X = 4
        //        – Output: yes (-3 – (-7))
        //        - Input: A = {−10, 4, −5, 9, 8}, X = 2 
        //        – Output: No
        //    • Complexity: O(N²)
        // */
        //public bool DiffrenceX(int[] arr, int k) {
        //    HelperFunctions<int>.mergeSort(arr, 0, arr.Length - 1);
        //    for (int i = 0; i < arr.Length; i++) {
        //        int target = arr[i] + k;
        //        if (HelperFunctions<int>.BinarySearch(target, 0, arr.Length - 1, arr)) return true;
        //    }
        //    return false;
        //}
        ///* QUESTION2: Powering a Number
        // * 
        //    Write an efficient algorithm to compute 𝑨
        //    𝑵, 𝑵 𝒊𝒔 𝒑𝒐𝒔𝒊𝒕𝒊𝒗𝒆 𝒊𝒏𝒕𝒆𝒈𝒆𝒓
        //    without using "Power" function? 
        //    Complexity: O(Log(N))
        // */
        //public int Power(int A, int N) {
        //    if (N == 1) return A;
        //    int power = Power(A, N / 2);
        //    if (N % 2 != 0)
        //        return A * power * power;
        //    else
        //        return power * power;
        //}

        ///*QUESTION3: Even Odd Checking
        //    Given an array with a set of integer numbers, each number value can be between 1 and 231-
        //    1- you have to determine if the sum of all the numbers is odd (return true) or even (return false)
        //        Note: 1-Adding all the items' values might cause an overflow
        //    2-Even + Even = Even, Odd + Odd = Even, Odd + Even = Odd

        //    Sample Input :
        //        1 30 4 300000000 5 8 7 4 5
        //    Sample Output:
        //        false
        //    (Note: summing all the 9 number will lead to an even number so we returned false)
        //*/
        //public bool EvenOddCheck(int[] arr, int start, int end) {
        //    int mid = (start + end) / 2;
        //    if (start >= end) {
        //        if (arr[start] % 2 == 0)
        //            return true;
        //        return false;
        //    }
        //    bool right = EvenOddCheck(arr, start, mid);
        //    bool left = EvenOddCheck(arr, mid + 1, end);
        //    return !(right ^ left);
        //}


        ///* QUESTION4: Unimodal Search
        //    An array A[1…N] is unimodal if it consists of an increasing sequence followed by a 
        //    decreasing sequence, or more precisely, if there is an index 𝑚 ∈ {1,2, … , 𝑁}such that
        //    • 𝐴[𝑖] < 𝐴[𝑖 + 1] ∀ 1 ≤ 𝑖 < 𝑚, 𝑎𝑛𝑑
        //    • 𝐴[𝑖] > 𝐴[𝑖 + 1] ∀ 𝑚 ≤ 𝑖 < 𝑁
        //    In particular, 𝐴[𝑚] is the maximum element, and it is the unique “locally maximum” 
        //    element surrounded by smaller elements (𝐴[𝑚 − 1] 𝑎𝑛𝑑 𝐴[𝑚 + 1])
        //    Give an algorithm to compute the maximum element of a unimodal input array in an 
        //    efficient way?
        // */
        //public int UnimodalSearch(int[] arr, int start, int end) {
        //    int mid = (start + end) / 2;
        //    if (start >= end)
        //        return -1; // not found
        //    if (arr[mid] > arr[mid - 1] && arr[mid] > arr[mid + 1])
        //        return arr[mid];
        //    if (arr[mid] > arr[mid - 1])
        //        return UnimodalSearch(arr, mid + 1, end);
        //    else
        //        return UnimodalSearch(arr, start, mid);
        //}

        ///* QUESTION5: K-Piles
        //    A volunteer selects 3 cards from a deck containing N distinct cards. We can then 
        //    show cards in k piles to the volunteer, who will point to all the piles containing one 
        //    or more of the three cards. The computational model we will use is that it takes 1 
        //    time unit to show 1 pile of cards to the volunteer. How can we determine which 
        //    three cards the volunteer picked in an efficient way? 
        // */
        //private bool foundCard(int[] arr, int start, int end, int[] cards) {
        //    for (int i = start; i <= end; i++) {
        //        for (int j = 0; j < cards.Length; j++)
        //            if (arr[i] == cards[j]) {
        //                return true;
        //            }
        //    }
        //    return false;
        //}
        //public void KPiles(int[] arr, int start, int end, int[] cards) {
        //    int mid = (start + end) / 2;
        //    if (start >= end)
        //        return;
        //    if (foundCard(arr, start, mid, cards))
        //        KPiles(arr, start, mid, cards);
        //    if (foundCard(arr, mid + 1, end, cards))
        //        KPiles(arr, mid + 1, end, cards);
        //    for (int j = 0; j < cards.Length; j++)
        //        if (arr[mid] == cards[j]) { Console.Write(arr[mid] + " "); break; }
        //}


        ///*QUESTION6: Celebrity Person 
        //    Adel is a person whom everybody knows but he knows nobody. You have gone to a party. 
        //    There are total n persons in the party. Your job is to find Adel in the party. You can ask 
        //    questions of the form "Does person X know person Y?" How many questions you should 
        //    ask to find Adel. (O(n) ,O(n2
        //    ). O(nlogn),….). 
        // */

        /*QUESTION7: A[i] = i?
            Suppose you are given an increasing sequence of n distinct integers in an array 
            A[1..n]. Design an efficient algorithm to determine whether there exists an index i 
            such that A[i] = i. Analyze the running time of your algorithm.
         */
        public bool AisI(int[] arr, int start, int end)
        {
            int mid = (start + end) / 2;
            if (start > end)
                return false;
            if (arr[mid] == mid) return true;
            else if (arr[mid] < mid)
                return AisI(arr, start, mid);
            else
                return AisI(arr, mid + 1, end);
        }



        /*QUESTION8: Guess a Number!
            Your friend guesses an integer between A and B: You can ask questions like is the 
            number less than 100? He will give YES NO answers. How many questions can your 
            friend force you to ask, if you are a smart person?
         */
        public int GuessANumber(int A, int B)
        {
            int mid = (A + B) / 2;
            //if (A == B)
            //    return A;

            if (B - A == 1)
            {
                Console.WriteLine("number is " + A + "?");
                string ans = Console.ReadLine();
                if (ans == "y")
                    return A;
                return B;
            }

            Console.WriteLine("is number less than " + mid);
            string s = Console.ReadLine();
            if (s == "y")
                return GuessANumber(A, mid);
            else
                return GuessANumber(mid + 1, B);
        }




        /*QUESTION11: Max Difference
            Let A[1::n] be an array of positive integers. Design a divide-and-conquer algorithm for 
            computing the maximum value of A[j] - A[i] with j ≥ i.
            Analyze your algorithm running time.
         */

        private MaxDiffNode MaxDifference(int[] arr, int start, int end)
        {
            if (start == end)
            {
                MaxDiffNode node = new MaxDiffNode();
                node.min = node.max = arr[start];
                node.diff = 0;
                return node;
            }
            int mid = (start + end) / 2;
            MaxDiffNode left = MaxDifference(arr, start, mid);
            MaxDiffNode right = MaxDifference(arr, mid + 1, end);
            MaxDiffNode newNode = new MaxDiffNode();
            newNode.min = Math.Min(left.min, right.min);
            newNode.max = Math.Max(left.max, right.max);
            newNode.diff = Math.Max(left.diff, right.diff);
            newNode.diff = Math.Max(newNode.diff, (right.max - left.min));
            return newNode;
        }
        public int CalcMaxDiffrence(int[] arr)
        {
            MaxDiffNode node = MaxDifference(arr, 0, arr.Length - 1);
            return node.diff;
        }
    }

    public static void Main(string[] args)
    {
        Sheet1 sheet1 = new Sheet1();
        /* test mergeSorting
        int[] arr = { 2, 7, 3, 4, 1, 6, 7, 8, 9 };
        HelperFunctions<int>.mergeSort(arr, 0, arr.Length - 1);
        for (int i = 0; i < arr.Length; i++) {
            Console.WriteLine(arr[i]);
        }
        */

        /* test binarySearching
           Console.WriteLine(helper.BinarySearch(9, 0, arr.Length - 1, arr));
        */

        /* //Question 1
         int []arr = { -10, 4, -5, 9, 8 };
         Console.WriteLine(sheet1.DiffrenceX(arr, 2));
        */

        /* //Question 2
        Console.WriteLine(sheet1.Power(2, 3));
        */

        /*//Question 3
        int[] arr = { 2, 2};
        Console.WriteLine(sheet1.EvenOddCheck(arr,0,arr.Length-1));
        */

        /* Question 4
        int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
        Console.WriteLine(sheet1.UnimodalSearch(arr, 0, arr.Length - 1));
         */

        /* Question 5
        int[] deck = { 1, 10, 9, 8, 7, 6, 5, 11 };
        int[] cards = { 10, 8, 6 };
        sheet1.KPiles(deck, 0, deck.Length - 1, cards);
         */


        /*Question 7
        int[] arr = { 2, 3, 6, 1, 4, 10 };
        Console.WriteLine(sheet1.AisI(arr, 0, arr.Length - 1));
         */
        /*Question 8
        Console.Write(sheet1.GuessANumber(1,20));
         */
        /*Question 11
         */
        int[] arr = { 20,10 };
        int diff = sheet1.CalcMaxDiffrence(arr);
        Console.WriteLine(diff);
    }

}