using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;



class Program
{
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


    public static void Main()
    {

        int[] array = {6,5,37,42,7,9,10,200};
        //insert(array, 200, 6);
        //inserttest(array, 10);
        //Console.WriteLine(GetMax(array));
        //BubleSort(array);
        //SelectionSort(array);
        PrintArrayInLine(array);
        InsertationSort(array);
        PrintArrayInLine(array);
        Console.ReadLine();
    }
}
   


