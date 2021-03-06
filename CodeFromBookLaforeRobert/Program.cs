﻿using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;



#region MergeSorting
class DArray
{
    private long[] theArray;
    private int nElems;

    public DArray(int max)
    {
        theArray = new long[max];
        nElems = 0;
    }

    public void insert(long value)
    {
        theArray[nElems] = value;
        nElems++;
    }

    public void display()
    {
        for (int j = 0; j < nElems; j++)
        {
            Console.WriteLine(theArray[j] + " ");
            Console.WriteLine("");
        }
    }

    public void mergeSort()
    {
        long[] workSpace = new long[nElems];
        recMergeSort(workSpace, 0, nElems - 1);
    }

    private void recMergeSort(long[] workSpace, int lowerBound, int upperBound)
    {
        // if only 1 element
        if (lowerBound == upperBound)
        {
            return;
        }
        else
        {
            //find middle
            int mid = (lowerBound + upperBound)/2;
            //Sorting
            recMergeSort(workSpace, lowerBound, mid);
            recMergeSort(workSpace,mid+1, upperBound);
            //Merge
            merge(workSpace, lowerBound,mid+1,upperBound);
        }
    }

    private void merge(long[] workSpace, int lowPtr, int highPtr, int upperBound)
    {
        int j = 0;
        int lowerBound = lowPtr;
        int mid = highPtr - 1;
        //Elements
        int n = upperBound - lowerBound + 1;

        while (lowPtr <= mid && highPtr <= upperBound)
        {
            if (theArray[lowPtr] < theArray[highPtr])
            {
                workSpace[j++] = theArray[lowPtr++];
            }
            else
            {
                workSpace[j++] = theArray[highPtr++];
            }
        }
        while (lowPtr <= mid)
        {
            workSpace[j++] = theArray[lowPtr++];
        }
        while (highPtr <= upperBound)
        {
            workSpace[j++] = theArray[highPtr++];
        }
        for (j = 0; j < n; j++)
        {
            theArray[lowerBound + j] = workSpace[j];
        }
    }
}
#endregion
#region ShellSort

class ArraySh
{
    private long[] theArray;
    private int nElems;

    public ArraySh(int max)
    {
        theArray = new long[max];
        nElems = 0;
    }

    public void insert(long value)
    {
        theArray[nElems] = value;
        nElems++;
    }

    public void display()
    {
        Console.WriteLine("A=");
        for (int j = 0; j < nElems; j++)
        {
            Console.WriteLine(theArray[j] + " ");
        }
        Console.WriteLine("");
    }

    public void shellSort()
    {
        int inner, outer;
        long temp;
        int h = 1;
        while (h <= nElems/3)
            h = h*3 + 1;
        while (h > 0)
        {
            for (outer = h; outer < nElems; outer++)
            {
                temp = theArray[outer];
                inner = outer;

                while (inner > h - 1 && theArray[inner-h] >= temp)
                {
                    theArray[inner] = theArray[inner - h];
                    inner -= h;
                }
                theArray[inner] = temp;
            }
            h = (h - 1)/3;
        }
    }
}


#endregion
#region QuickSort

class ArrayIns
{
    private long[] theArray;
    private int nElems;

    public ArrayIns(int max)
    {
        theArray = new long[max];
        nElems = 0;
    }

    public void insert(long value)
    {
        theArray[nElems] = value;
        nElems++;
    }

    public void display()
    {
        Console.WriteLine("A=");
        for (int j = 0; j < nElems; j++)
        {
            Console.WriteLine(theArray[j] + " ");
        }
        Console.WriteLine("");
    }

    public void quickSort()
    {
        recQuickSort(0, nElems - 1);
    }

    public void recQuickSort(int left, int right)
    {
        if (right - left <= 0)
            return;
        else
        {
            long pivot = theArray[right];

            int partition = partitionIt(left, right, pivot);
            recQuickSort(left, partition-1);
            recQuickSort(partition+1, right);
        }
    }

    public int partitionIt(int left, int right, long pivot)
    {
        int leftPtr = left - 1;
        int rightPtr = right;
        while (true)
        {
            while (theArray[++leftPtr] < pivot)
                ; //(nop)
            while (right > 0 && theArray[--rightPtr] > pivot)
                ; //(nop)
            if (leftPtr >= rightPtr)
            {
                break;
            }
            else
            {
                swap(leftPtr, rightPtr);
            }
           
        }
        swap(leftPtr, right);
        return leftPtr;
    }

    public void swap(int dex1, int dex2)
    {
        long temp;
        temp = theArray[dex1];
        theArray[dex1] = theArray[dex2];
        theArray[dex2] = temp;
    }
} 
#endregion
class Program
{
    #region Base Sorting
        public static void insert(int[] array, int value, int startfrom)
        {
            int i = startfrom;
            string temp;
            for (i = startfrom; i >= 0 && array[i] > value; i--)
            {
                array[i+1] = array[i];
            }
            array[i + 1] = value;
       
       
        }
        public static void PrintArrayInLine(int[] a)
        {
            string textForPrint = "";
            foreach (var v in a)
            {
                textForPrint += v.ToString();
            }
            Console.WriteLine(textForPrint);
        }
        public static int GetMax(int[] a)
        {
            int maxElement = 0;
            int indexOfMaxEl = -1;
            if (a.Length > 0)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] > maxElement)
                    {
                        maxElement = a[i];
                        indexOfMaxEl = i;
                    }
                }
                if (indexOfMaxEl > -1)
                {
                    for (int j = indexOfMaxEl; j < a.Length-1; j++)
                    {
                        a[j] = a[j + 1];
                    }
                
                }
            }
            else
            {
                maxElement = -1;
            }
        
            return maxElement;
        }
        public static void BubleSort(int[] a)
        {
            for (int i = a.Length-1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (a[j] > a[j + 1])
                    {
                        int temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                    }
                }
            }
        }
        public static void SelectionSort(int[] a)
        {
            int minIndex, inIndex, outIndex, temp;

            for (outIndex = 0; outIndex < a.Length - 1; outIndex++)
            {
                minIndex = outIndex;
                for (inIndex = outIndex + 1; inIndex < a.Length - 1; inIndex++)
                {
                    if (a[inIndex] < a[minIndex])
                    {
                        minIndex = inIndex;
                    }

                }
                temp = a[outIndex];
                a[outIndex] = a[minIndex];
                a[minIndex] = temp;
            }
        }
        public static void InsertationSort(int[] a)
        {
            int temp;
            int inIndex;

            for (int i = 1; i < a.Length-1; i++)
            {
                temp = a[i];
                inIndex = i;

                while (inIndex > 0 && a[inIndex - 1] >= temp)
                {
                    a[inIndex] = a[inIndex - 1];
                    --inIndex;
                }
                a[inIndex] = temp;
            }
        }
    #endregion
    public static void Main()
    {
        #region base main
            //int[] array = { 6, 5, 37, 42, 7, 9, 10, 200 };
            //insert(array, 200, 6);
            //inserttest(array, 10);
            //Console.WriteLine(GetMax(array));
            //BubleSort(array);
            //SelectionSort(array);
            //PrintArrayInLine(array);
            //InsertationSort(array);
            //PrintArrayInLine(array);
        #endregion
        #region MergeMain
        /*MergeSort*/
        /*
        int maxSize = 100;
        DArray arr;
        arr = new DArray(maxSize);

        arr.insert(64);
        arr.insert(21);
        arr.insert(33);
        arr.insert(70);
        arr.insert(12);
        arr.insert(85);
        arr.insert(44);
        arr.insert(3);

        arr.display();
        arr.mergeSort();
        arr.display();
        */
        /*EndMergeSort*/
        #endregion
        #region ShellMain
        /*int maxSize = 10;
            ArraySh arr;
            Random rnd = new Random();
            arr = new ArraySh(maxSize);
           for (int j = 0; j < maxSize; j++)
           {
                long n = (int)( rnd.Next(1,600) * 99);
                arr.insert(n);
           }
           arr.display();
           arr.shellSort();
           arr.display();*/
        #endregion
        #region QuickMain
            int maxSize = 16; // Размер массива
            ArrayIns arr;
            Random rnd = new Random();
            arr = new ArrayIns(maxSize);
            for (int j = 0; j < maxSize; j++)
            {
                long n = (int)(rnd.Next() * 99);
                arr.insert(n);
            }
            arr.display();
            arr.quickSort();
            arr.display();
        #endregion

            Console.ReadLine();
    }
}
   


