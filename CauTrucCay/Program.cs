using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
  MSSV:
  Ho va ten: 
 */

namespace CauTrucCay
{

   //cau 1
    interface ITree
    {
        void ThemNut(ref TNode root, int x);
        void TaoCay();
        void LNR(TNode root);
        int DemSoNut(TNode root);
        int DemSoNutLa(TNode root);
        int TinhTong(TNode root);
        int TimMin(TNode root);
    }
    class TNode
    {
        public int data;
        public TNode left;
        public TNode right;

        public TNode(int x)
        {
            //viết code thực hiện khỏi tạo nút
            data = x;
            left = null;
            right = null;

        }
    }
    class BST : ITree
    {
        public TNode root;
        public BST()
        {
            this.root = null;
        }

        //viet code cho cac phuong thuc sau 
        public void ThemNut(ref TNode root, int x)
        {
            if (root == null)
            {
                root = new TNode(x);
                return;
            }

            if (x < root.data)
            {
                ThemNut(ref root.left, x);
            }
            else if (x > root.data)
            {
                ThemNut(ref root.right, x);
            }
        }
        public void TaoCay()
        {
            root = null;
        }

        public void LNR(TNode root)  //duyet cay theo thu tu giua
        {
            if (root != null)
            {
                LNR(root.left);
                Console.Write(root.data + " ");
                LNR(root.right);
            }
        }
        public int DemSoNut(TNode root)
        {
            if (root == null)
            {
                return 0;
            }
            return 1 + DemSoNut(root.left) + DemSoNut(root.right);
        }

        public int DemSoNutLa(TNode root)
        {
            if (root == null)
            {
                return 0;
            }
            if (root.left == null && root.right == null)
            {
                return 1;
            }
            return DemSoNutLa(root.left) + DemSoNutLa(root.right);
        }       

        public int TimMin(TNode root)
        {
            if (root == null)
            {
                return int.MaxValue;
            }
            int leftMin = TimMin(root.left);
            int rightMin = TimMin(root.right);
            return Math.Min(root.data, Math.Min(leftMin, rightMin));
        }

        public int TinhTong(TNode root)
        {
            if (root == null)
            {
                return 0;
            }
            return root.data + TinhTong(root.left) + TinhTong(root.right);
        }
    }


    //cau 2
    class Program
    {
        static void Main(string[] args)
        {
            BST tree = new BST();

            // Thêm các khóa vào cây
            int[] keys = { 30, 12, 17, 49, 22, 65, 51, 56, 70, 68 };
            foreach (int key in keys)
            {
                tree.ThemNut(ref tree.root, key);
            }

            // Duyệt cây theo thứ tự giữa (in-order)
            Console.WriteLine("Duyet cay theo thu tu giua (In-order traversal):");
            tree.LNR(tree.root);
            Console.WriteLine();

            // Tính toán 
            Console.WriteLine("Tong so nut trong cay: " + tree.DemSoNut(tree.root));
            Console.WriteLine("So nut la trong cay: " + tree.DemSoNutLa(tree.root));
            Console.WriteLine("Tong cac gia tri cua cac nut: " + tree.TinhTong(tree.root));
            Console.WriteLine("Gia tri nho nhat trong cay: " + tree.TimMin(tree.root));
            Console.ReadLine();
        }
    }
}