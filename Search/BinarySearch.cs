namespace BinaryTree
{
    
    class Program
    {
        public int BinarySearch(int[] arrayForSearch, int upLim, int downLim, int searchEl)
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
                return BinarySearch(arrayForSearch, upLim, middle + 1, searchEl);
            }
            else 
            {
                return BinarySearch(arrayForSearch, middle-1, downLim, searchEl);
            }
           
        }
        static void Main(string[] args)
        {

            int[] arrayForSearch = new int[] {1, 2, 3, 4, 5, 6, 7};
            Program p = new Program();
            Console.WriteLine(p.BinarySearch(arrayForSearch, 0,arrayForSearch.Length-1, 5));
            Console.ReadLine();

        }
    }
}