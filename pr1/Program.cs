
using System.Diagnostics;
using System.Collections;


namespace HelloWord
{
    class Program
    {

        
        static void Main(string[] args)
        {

            Program method = new Program();
            int[] a = new int[10000];
            Random rnd = new Random();
             
            for (int i = 0; i < a.Length; i++)
                a[i] = rnd.Next() % 10000;
            Timing timing1 = new Timing();
            Stopwatch stpWatch = new Stopwatch();
            timing1.StartTime();
            stpWatch.Start();
            
            method.bubbleSort(a);

            stpWatch.Stop();
            timing1.StopTime();
            Console.WriteLine("StopWatch: " + stpWatch.Elapsed.ToString()); // 00:00:00.3376594
            Console.WriteLine("Timing: " + timing1.Result().ToString()); // 00:00:00.3281250


            int[] b = new int[10000000];
            for (int i = 0; i < b.Length; i++)
                b[i] = rnd.Next() % 100000000;
            Timing timing2 = new Timing();
            timing2.StartTime();
            stpWatch.Restart();
            
            method.simpleSearch(b, 6455);

            stpWatch.Stop();
            timing2.StopTime();
            Console.WriteLine("StopWatch: " + stpWatch.Elapsed.ToString()); // 00:00:00.0281313
            Console.WriteLine("Timing: " + timing2.Result().ToString()); // 00:00:00.0156250


            int[] c = new int[10000000];
            for (int i = 0; i < c.Length; i++)
                c[i] = 1;
            Timing timing3 = new Timing();
            timing3.StartTime();
            stpWatch.Restart();
            
            method.simpleSearch(c, 67455);

            stpWatch.Stop();
            timing3.StopTime();
            Console.WriteLine("StopWatch: " + stpWatch.Elapsed.ToString()); // 00:00:00.0285959
            Console.WriteLine("Timing: " + timing3.Result().ToString()); // 00:00:00.0156250


            Hashtable hash = new Hashtable(10000000);
            for (int i = 0; i < hash.Count; i++)
                hash.Add(i.ToString(), rnd.Next() % 100000);
            Timing timing4 = new Timing();
            timing4.StartTime();
            stpWatch.Restart();
            
            hash.Values.OfType<int>().Where(s => s == 10000);

            stpWatch.Stop();
            timing4.StopTime();
            Console.WriteLine("StopWatch: " + stpWatch.Elapsed.ToString()); // 00:00:00.0016142
            Console.WriteLine("Timing: " + timing4.Result().ToString()); // 00:00:00



            // класс Timing прохо работает с маленьким временем

        }

        public void bubbleSort(int[] a)
        {
            int N = a.Length;
            for (int i = 1; i < N; i++)
                for (int j = N - 1; j >= i; j--) 
                    if (a[j - 1] > a[j]) 
                    {
                        int temp = a[j - 1]; 
                        a[j - 1] = a[j];
                        a[j] = temp;
                    } 
             
        }

        public int simpleSearch(int[] a, int x)
        {
            int i = 0;
            while(i < a.Length && a[i] != x)
                i++;
                if(i < a.Length){
                    return i;
                }else{
                    return -1;
                }
        }

        public int binarySearch(int[] a, int x)
        {
            int middle, left = 0, right = a.Length - 1;
            do
            {
                middle = (left + right/2);
                if(x > a[middle])
                    left = middle + 1;
                else
                    right = middle - 1;
            }
            while ((a[middle] != x) && (left <= right));
                if(a[middle] == x)
                    return middle;
                else
                    return -1;
        }
    }

    internal class Timing
    {
        TimeSpan duration; //хранение результата измерения
        TimeSpan[] threads; // значения времени для всех потоков процесса
        public Timing()
        {
            duration = new TimeSpan(0);
            threads = new TimeSpan[Process.GetCurrentProcess().
            Threads.Count];
        }
        public void StartTime() //инициализация массива threads после вызова сборщика мусора
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            for (int i = 0; i < threads.Length; i++)
                threads[i] = Process.GetCurrentProcess().Threads[i].
                UserProcessorTime;
        }
        public void StopTime() //повторный запрос текущего времени и выбирается тот, у которого результат отличается от
        {				//предыдущего
            TimeSpan tmp;
            for (int i = 0; i < threads.Length; i++)
            {
                tmp = Process.GetCurrentProcess().Threads[i].
                UserProcessorTime.Subtract(threads[i]);
                if (tmp > TimeSpan.Zero)
                    duration = tmp;
            }
        }
        public TimeSpan Result()
        {
            return duration;
        }
    }

}
