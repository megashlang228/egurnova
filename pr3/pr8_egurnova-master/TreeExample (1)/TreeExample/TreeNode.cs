using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeExample
{
    public class TreeNode// Класс «Узел бинарного дерева»  
    {
        private int info;      // информационное поле  
        private TreeNode left;  // ссылка на левое поддерево  
        private TreeNode right; // ссылка на правое поддерево  

        public int Info { get; set; }    // свойства  
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public TreeNode() { }   // конструкторы  
        public TreeNode(int info)
        {
            Info = info;
        }
        public TreeNode(int info, TreeNode left, TreeNode right)
        {
            Info = info; Left = left; Right = right;
        }
    }

    public class BinaryTree // Класс «Бинарное дерево произвольного вида»  
    {
        private TreeNode root;  // ссылка на корень дерева  
        public TreeNode Root    // свойство, открывающее доступ к корню дерева 
        {
            get { return root; }
            set { root = value; }
        }
        public BinaryTree() // создание пустого дерева  
        {
            root = null;
        }


        /// <summary>
        /// Метод построения сбалансированного дерева из N узлов 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public TreeNode Create_Balanced(int n)  	// n – количество узлов в дереве  
        {

            int x;
            TreeNode root;    // ссылка на корень дерева и на корень любого из поддеревьев 
            if (n == 0)
                root = null; // если n == 0, построить пустое дерево
            else
            {   // заполнить информационное поле корня  
                Console.WriteLine("введите значение поля узла (символ):");
                x = Int32.Parse(Console.ReadLine());
                root = new TreeNode(x);     // создать корень дерева  
                root.Left = Create_Balanced(n / 2);    // построить левое поддерево (*1*)
                root.Right = Create_Balanced(n - n / 2 - 1);    // построить правое поддерево  (*2*)
            }
            return root; //(*3*)
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        public int KLP(TreeNode root) // root – ссылка на корень дерева и любого из поддеревьев  
        {
            if (root !=null)    // дерево не пусто?  
            {   // распечатать информ. поле корневого узла  
                Console.WriteLine(root.Info);
                //KLP(root.Left)     // (*1*)обойти левое поддерево в нисходящем порядке  
                //KLP(root.Right)    // (*2*)обойти правое поддерево в нисходящем порядке  
                return root.Info + KLP(root.Left) + KLP(root.Right);
            }
            //(* 3 *) 
            return 0;
        }
    }
}


