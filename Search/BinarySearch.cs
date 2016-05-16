namespace BinaryTree
{
    
    class Program
    {
        public int recBinarySearch(int[] arrayForSearch, int upLim, int downLim, int searchEl)
        {
            
            int range = upLim - downLim;
            if (range == 0 && arrayForSearch[downLim] != searchEl)
            {
               throw new Exception("Element is not found");
               
            }
            if (range < 0)
            {
                throw new Exception("Replace limits");
            }
            if (arrayForSearch[downLim] > arrayForSearch[upLim])
            {
                throw new Exception("Array not sorted");
            }
            int middle = (range)/2 + downLim;
            
            if (arrayForSearch[middle] == searchEl)
            {
                return middle;
            }
            
            else if (arrayForSearch[middle] < searchEl)
            {
                return recBinarySearch(arrayForSearch, upLim, middle + 1, searchEl);
            }
            else 
            {
                return recBinarySearch(arrayForSearch, middle-1, downLim, searchEl);
            }
           
        }

        public int iterBinarySearch(int[] array, int target)
        {
            int lower = 0, upper = array.Length - 1;
            int center, range;

            if (lower > upper)
            {
                throw  new Exception("Replace limits");
            }
            while (true)
            {
                range = upper - lower;
                if (range == 0 && array[lower] != target)
                {
                    throw  new Exception("Array is not sorted");
                }
                center = (range/2) + lower;
                if (target == array[center])
                {
                    return center;
                }
                else if (target < array[center])
                {
                    upper = center - 1;
                }
                else
                {
                    lower = center + 1;
                }
            }
        }
        static void Main(string[] args)
        {

            int[] arrayForSearch = new int[] {1, 2, 3, 4, 5, 6, 7};
            Program p = new Program();
            Console.WriteLine(p.recBinarySearch(arrayForSearch, arrayForSearch.Length - 1, 0, 5));
            Console.WriteLine(p.iterBinarySearch(arrayForSearch,6));
            Console.ReadLine();

        }
    }
}