using System;

namespace ParniPodnizovi
{
    public class Node
    {
        public int value;
        public int occurrence;
        public Node? leftChild;
        public Node? rightChild;

        public Node(int v)
        {
            value = v;
            occurrence = 1;
            leftChild = null;
            rightChild = null;
        }

        public Node(int v, int oc)
        {
            value = v;
            occurrence = oc;
        }

        public Node(Node n)
        {
            value = n.value;
            occurrence = n.occurrence;
        }
    }

    public class Tree
    {
        Node root;

        public Tree()
        {
            root = new Node(0);
        }
        public Tree(Node r)
        {
            root = r;
        }

        public int Update(int v)
        {
            if( root == null )
            {
                root = new Node(v);
                return 1;
            }

            Node current_node = root;

            while(true)
            {
                if( current_node.value == v )
                {
                    current_node.occurrence++;
                    return current_node.occurrence;
                }

                if( v > current_node.value )
                {
                    if( current_node.leftChild == null )
                    {
                        Node new_node = new Node(v);
                        current_node.leftChild = new_node;
                        return 1;
                    }

                    current_node = current_node.leftChild;
                    continue;
                }

                if( v < current_node.value )
                {
                    if( current_node.rightChild == null )
                    {
                        Node new_node = new Node(v);
                        current_node.rightChild = new_node;
                        return 1;
                    }

                    current_node = current_node.rightChild;
                    continue;
                }
            }
        }
    }
    class ParniPodnizovi
    {
        public static int Transform(int x)
        {
            int s = x;
            s *= x;
            s %= 1000007;
            s *= x;
            s %= 1000007;
            s += 3*x;
            s %= 1000007;
            s++;
            s %= 1000007;
            if(s < 0) s+= 1000007;
            return s;
        }
        public static void Main()
        {
            int n;
            n = Convert.ToInt32(Console.ReadLine());

            string inputLine = Console.ReadLine();

            int[] a = inputLine.Split(' ').Select(int.Parse).ToArray();

            Tree set = new Tree();
            Tree configuration = new Tree();

            int s = 0;
            int solution = 0;

            for(int i=0; i<n; i++)
            {
                int x = Transform(a[i]);
                
                int occurrence = set.Update(a[i]);
                if( occurrence % 2 == 0 ) x = -x;

                s += x;
                s %= 1000007;

                solution += configuration.Update(s)-1;
            }

            Console.WriteLine(solution);
        }
    }
}
