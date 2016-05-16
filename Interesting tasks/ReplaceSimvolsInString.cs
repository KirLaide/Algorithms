
namespace ReplaceSimvolsInString
{
    /*
        Replace simbols in string (for "hat" must print - "tha","aht","tah","ath","hta" and "hat"
    */

    public class Permutations
    {
        private bool[] used;
        private StringBuilder outString = new StringBuilder();
        private string inString;

        public Permutations(string str)
        {
            inString = str;
            used = new bool[inString.Length];
        }

        public void permute()
        {
            if (outString.Length == inString.Length)
            {
                Console.WriteLine(outString);
                return;
            }
            for (int i = 0; i < inString.Length; ++i)
            {
                if(used[i]) continue;
                outString.Append(inString[i]);
                used[i] = true;
                permute();
                used[i] = false;
                outString.Length = outString.Length - 1;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Permutations p = new Permutations("fgt");
            p.permute();
            
            Console.ReadLine();

        }
    }
}
