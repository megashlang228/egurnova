using System;

namespace TreeExample
{

    public class Program
    {
        static void Main()
        {
            int a = 4; // искомое значение
            BinaryTree T = new BinaryTree();    // объявление объекта класса “Бинарное дерево” 
            T.Root = T.Create_Balanced(7);  // создание сбалансированного дерева из 7 узлов   
            Console.WriteLine("найдено: "+(T.KLP(T.Root, a)).ToString()); 	// трасса нисходящего обхода дерева  
        }
    }
}