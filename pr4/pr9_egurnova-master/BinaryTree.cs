using System;
using System.Collections.Generic;
namespace Trees
{
    public class BinaryTree
    {
        private BinaryTree parent, left, right;
        private int val;
        private List<int> listForPrint = new List<int>();

        public BinaryTree(int val, BinaryTree parent)
        {
            this.val = val;
            this.parent = parent;
        }

        public void add(int val)
        {
            if (val.CompareTo(this.val) < 0)
            {
                if (this.left == null)
                {
                    this.left = new BinaryTree(val, this);
                }
                else if (this.left != null)
                    this.left.add(val);
            }
            else
            {
                if (this.right == null)
                {
                    this.right = new BinaryTree(val, this);
                }
                else if (this.right != null)
                    this.right.add(val);
            }
        }

        private BinaryTree _search(BinaryTree tree, int val)
        {
            if (tree == null) return null;
            switch (val.CompareTo(tree.val))
            {
                case 1: return _search(tree.right, val);
                case -1: return _search(tree.left, val);
                case 0: return tree;
                default: return null;
            }
        }

        public BinaryTree search(int val)
        {
            return _search(this, val);
        }

        public bool remove(int val)
        {
            //Проверяем, существует ли данный узел
            BinaryTree tree = search(val);
            if (tree == null)
            {
                //Если узла не существует, вернем false
                return false;
            }
            BinaryTree curTree;

            //Если удаляем корень
            if (tree == this)
            {
                if (tree.right != null)
                {
                    curTree = tree.right;
                }
                else curTree = tree.left;

                while (curTree.left != null)
                {
                    curTree = curTree.left;
                }
                int temp = curTree.val;
                this.remove(temp);
                tree.val = temp;

                return true;
            }

            //Удаление листьев
            if (tree.left == null && tree.right == null && tree.parent != null)
            {
                if (tree == tree.parent.left)
                    tree.parent.left = null;
                else
                {
                    tree.parent.right = null;
                }
                return true;
            }

            //Удаление узла, имеющего левое поддерево, но не имеющее правого поддерева
            if (tree.left != null && tree.right == null)
            {
                //Меняем родителя
                tree.left.parent = tree.parent;
                if (tree == tree.parent.left)
                {
                    tree.parent.left = tree.left;
                }
                else if (tree == tree.parent.right)
                {
                    tree.parent.right = tree.left;
                }
                return true;
            }

            //Удаление узла, имеющего правое поддерево, но не имеющее левого поддерева
            if (tree.left == null && tree.right != null)
            {
                //Меняем родителя
                tree.right.parent = tree.parent;
                if (tree == tree.parent.left)
                {
                    tree.parent.left = tree.right;
                }
                else if (tree == tree.parent.right)
                {
                    tree.parent.right = tree.right;
                }
                return true;
            }

            //Удаляем узел, имеющий поддеревья с обеих сторон
            if (tree.right != null && tree.left != null)
            {
                curTree = tree.right;

                while (curTree.left != null)
                {
                    curTree = curTree.left;
                }

                //Если самый левый элемент является первым потомком
                if (curTree.parent == tree)
                {
                    curTree.left = tree.left;
                    tree.left.parent = curTree;
                    curTree.parent = tree.parent;
                    if (tree == tree.parent.left)
                    {
                        tree.parent.left = curTree;
                    }
                    else if (tree == tree.parent.right)
                    {
                        tree.parent.right = curTree;
                    }
                    return true;
                }
                //Если самый левый элемент НЕ является первым потомком
                else
                {
                    if (curTree.right != null)
                    {
                        curTree.right.parent = curTree.parent;
                    }
                    curTree.parent.left = curTree.right;
                    curTree.right = tree.right;
                    curTree.left = tree.left;
                    tree.left.parent = curTree;
                    tree.right.parent = curTree;
                    curTree.parent = tree.parent;
                    if (tree == tree.parent.left)
                    {
                        tree.parent.left = curTree;
                    }
                    else if (tree == tree.parent.right)
                    {
                        tree.parent.right = curTree;
                    }

                    return true;
                }
            }
            return false;
        }

        private void _print(BinaryTree node)
        {
            if (node == null) return;
            _print(node.left);
            if (node.val < 0)
            {
                listForPrint.Add(node.val);
                Console.Write(node + " ");
            }
            if (node.right != null)
                _print(node.right);
        }
        private int _summ(BinaryTree node)
        {
            int left = 0;
            int right = 0;
        
            if (node == null) return 0;
                left = _summ(node.left);
            if (node.right != null)
                right = _summ(node.right);
            return node.val + left + right;
        }
        private int _nodeCount(BinaryTree node)
        {
            if (node == null) return 0;
            if (node.right == null && node.left == null)
                return 0;
            else 
                return 1 + _nodeCount(node.right) + _nodeCount(node.left);
        }

        public void summ()
        {
            Console.WriteLine("Сумма элементов: " + (_summ(this).ToString()));
        }
        public void nodeCount()
        {
            Console.WriteLine("Количество внутренних узлов: " + (_nodeCount(this).ToString()));
        }
        public void print()
        {
            listForPrint.Clear();
            _print(this);
            Console.WriteLine();
        }

        public override string ToString()
        {
            return val.ToString();
        }
    }
}