
//Selection Sort Recursive O(n2)

public void selectionSortRecursive(int[] data)
{
    selectionSortRecursive(data,0);
}

private void selectionSortRecursive(int[] data, int start)
{
    if(start < data.Length - 1)
    {
        swap(data, start, findMinimumIndex(data, start));
        selectionSortRecursive(data, start + 1);
    }
}

private int findMinimumIndex(int[] data, int start)
{
    int minPos = start;
    for (int i = start + 1; i < data.Length; i++)
    {
        if (data[i] < data[minPos])
        {
            minPos = i;
        }
    }
    return minPos;
}

private void swap(int[] data, int index1, int index2)
{
    if (index1 != index2)
    {
        int tmp = data[index1];
        data[index1] = data[index2];
        data[index2] = tmp;
    }
}

// Insertion Sort O(n2)
public void insertionSort(int[] data)
{
    for (int which = 1; which < data.Length; ++which)
    {
        int val = data[which];
        for (int i = 0; i < which; i++)
        {
            if (data[i] > val)
            {
                System.Array.Copy(data,i,data,i+1,which-1);
                data[i] = val;
                break;
            }
        }
    }
}

//Quick Sort O(n2) (but ~ O(nlog(n)))
public int[] quicksortSimple(int[] data)
{
    if (data.Length < 2)
    {
        return data;
    }
    int pivotIndex = data.Length/2;
    int pivotValue = data[pivotIndex];

    int leftCount = 0;

    //Count element? less then pivot Value
    for (int i = 0; i < data.Length; ++i)
    {
        if (data[i] < pivotValue) ++leftCount;
    }

    int[] left = new int[leftCount];
    int[] right = new int[data.Length - leftCount - 1];
    int l = 0;
    int r = 0;

    for (int i = 0; i < data.Length; ++i)
    {
        if( i == pivotIndex) continue;
        int val = data[i];
        if (val < pivotValue)
        {
            left[l++] = val;
        }
        else
        {
            right[r++] = val;
        }
    }

    left = quicksortSimple(left);
    right = quicksortSimple(right);

    System.Array.Copy(left,0,data,0,left.Length);
    data[left.Length] = pivotValue;
    System.Array.Copy(right,0,data,left.Length + 1,right.Length);

    return data;
}

//Merge Sort Simple O(nlog(n)) but need 0(n) memory
public int[] mergeSortSimple(int[] data)
{
    if (data.Length < 2)
    {
        return data;
    }

    int mid = data.Length/2;
    int[] left = new int[mid];
    int[] right = new int[data.Length - mid];

    System.Array.Copy(data, 0, left, 0, left.Length);
    System.Array.Copy(data, mid, right, 0, right.Length);

    mergeSortSimple(left);
    mergeSortSimple(right);

    return merge(data, left, right);
}

private int[] merge(int[] dest, int[] left, int[] right)
{
    int dind = 0;
    int lind = 0;
    int rind = 0;

    while (lind < left.Length && rind < right.Length)
    {
        if(left[lind] <= right[rind])
        {
            dest[dind++] = left[lind++];
        }
        else
        {
            dest[dind++] = right[rind++];
        }
    }
    while (lind < left.Length)
    {
        dest[dind++] = left[lind++];
    }
    while(rind < right.Length)
    {
        dest[dind++] = right[rind++];
    }

    return dest;
}
