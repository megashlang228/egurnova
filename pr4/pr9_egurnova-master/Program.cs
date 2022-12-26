using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trees;

namespace SearchTree9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random(); 

            //Создадим дерево с корневым элементом 33
            BinaryTree tree = new BinaryTree(random.Next(-1000, 1000), null);

            for(int i = 0; i < 20; i++)
            {
                tree.add(random.Next(-1000, 1000));
            }
            

            tree.summ();

            tree.nodeCount();
            //Распечатаем элементы дерева
            tree.print();
            //Удалим корень
            //tree.remove(33);
            //tree.remove(17);
            //tree.print();
            ////Проверяем элементы дерева
            //System.out.println(tree);
            //System.out.println(tree.left());
            //System.out.println(tree.left().left());
            //System.out.println(tree.right().left());
            Console.ReadLine();
        }
    }
}
