using System;

namespace TreeExample
{

    public class Program
    {
        static void Main()
        {
            int uzelCount = 7;
            BinaryTree T = new BinaryTree();    // объявление объекта класса “Бинарное дерево” 
            T.Root = T.Create_Balanced(uzelCount);  // создание сбалансированного дерева из 7 узлов   
            Console.WriteLine("положительных: " + T.KLP(T.Root).ToString());    // трасса нисходящего обхода дерева  
            Console.WriteLine("отрицательных: " + (uzelCount - T.KLP(T.Root)).ToString());    // трасса нисходящего обхода дерева  
        }
    }
}