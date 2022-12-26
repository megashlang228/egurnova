using System;

namespace TreeExample
{

    public class Program
    {
        static void Main()
        {
            BinaryTree T = new BinaryTree();    // объявление объекта класса “Бинарное дерево” 
            T.Root = T.Create_Balanced(7);  // создание сбалансированного дерева из 7 узлов   
            Console.WriteLine("среднее арифметическое = "+(T.KLP(T.Root)/7).ToString()); 	// трасса нисходящего обхода дерева  
        }
    }
}