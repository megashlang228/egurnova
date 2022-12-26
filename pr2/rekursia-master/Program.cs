using System;
using System.Diagnostics.Metrics;

namespace Program
{
    class Rekursia
    {
        static void Main(string[] args)
        {
            Rekursia r = new Rekursia();
            Console.WriteLine("введите число");
            string str = Console.ReadLine();

            Console.WriteLine(r.p(Convert.ToInt32(str)));


            int n;
            Console.WriteLine("введите число");
            n = Convert.ToInt32(Console.ReadLine());
            if (r.IsSimple(n, 2))
                Console.WriteLine("prostoe");
            else
                Console.WriteLine("ne prostoe");


            Console.WriteLine("Введите строку");
            string str2 = Console.ReadLine();
            if (r.isPalindrom(str2))
            {
                Console.WriteLine("palindrom");
            }
            else
            {
                Console.WriteLine("ne palingrom");
            }


            Console.WriteLine("Введите скобки");
            string str1 = Console.ReadLine();
            if (r.checker(str1))
            {
                Console.WriteLine("норм");
            }
            else
            {
                Console.WriteLine("не норм");
            }
        }
        
        long p(int n)
        {
            if (n < 0) return 0;
            if (n <= 1) return 1;
            long sum = 0;
            for (int k = 1, s = 1; (3 * k - 1) * k / 2 <= n; ++k)
            {
                int l = (3 * k + 1) * k / 2;
                int m = (3 * k - 1) * k / 2;
                sum += s * (p(n - l) + p(n - m));
                s = -s;
            }
            return sum;
        }

        bool IsSimple(int n, int k)
        {
            if (n == 1 || n == k)
                return true;
            if (n % k == 0)
                return false;
            return IsSimple(n, k + 1);

        }

        bool isPalindrom(string str)
        {
            for(int i = 0; i < str.Length/2; i++)
            {
                if (str[i] != str[str.Length - (i + 1)]) return false;
            }
            return true;
        }

        bool checker(string str, int s = 0, int counter = 0)
        {
            if (counter< 0) return false;

            for(;s<str.Length;s++)
                switch(str[s])
                {
                    case '(': return checker(str, s+1, counter+1);
                    case ')': return checker(str, s+1, counter-1);
            }
            return (counter == 0);
        }
       
    }
}
