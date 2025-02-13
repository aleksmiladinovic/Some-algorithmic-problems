using System;

namespace Statistika
{
    public class Node
    {
        public int minValue;
        public int numOccurences;
        public int leftBound;
        public int rightBound;
        public Node? leftChild;
        public Node? rightChild;
        public Node? parent;

        public Node()
        {
            leftBound = 0;
            rightBound = 0;
            minValue = 0;
            numOccurences = 0;
            leftChild = null;
            rightChild = null;
            parent = null;
        }

        public Node( Node n )
        {
            leftBound = n.leftBound;
            rightBound = n.rightBound;
            minValue = n.minValue;
            numOccurences = n.numOccurences;
            leftChild = n.leftChild;
            rightChild = n.rightChild;
            parent = n.parent;
        }
    }

    public class NodePointer
    {
        public Node node;
        public int leftBound;
        public int rightBound;
        public NodePointer? leftChild;
        public NodePointer? rightChild;
        public NodePointer? parent;

        public NodePointer()
        {
            node = new Node();
            leftBound = 0;
            rightBound = 0;
            leftChild = null;
            rightChild = null;
            parent = null;
        }

        public NodePointer( Node element )
        {
            node = element;
            leftBound = 0;
            rightBound = 0;
            leftChild = null;
            rightChild = null;
            parent = null;
        }
    }

    public class Pair
    {
        public int value;
        public int occurence;

        public Pair()
        {
            value = 0;
            occurence = 0;
        }

        public Pair(int v, int o)
        {
            value = v;
            occurence = o;
        }

        public Pair(Pair pair)
        {
            value = pair.value;
            occurence = pair.occurence;
        }
    }


    class Program
    {

        public static Node MakeTree(int[] a, int left_bound, int right_bound)
        {
            Node node = new Node();

            node.leftBound = left_bound;
            node.rightBound = right_bound;

            if( left_bound == right_bound )
            {
                node.minValue = a[left_bound];
                node.numOccurences = 1;
            }
            else
            {
                int middle = (left_bound+right_bound)/2;
            
                Node left_child = MakeTree(a, left_bound, middle);
                Node right_child = MakeTree(a, middle+1, right_bound);
            
                node.leftChild = left_child;
                node.rightChild = right_child;

                left_child.parent = node;
                right_child.parent = node;

                int mvl = left_child.minValue;
                int mvr = right_child.minValue;
                int nol = left_child.numOccurences;
                int nor = right_child.numOccurences;

                if(mvl < mvr)
                {
                    node.minValue = mvl;
                    node.numOccurences = nol;
                }
                else if(mvl > mvr)
                {
                    node.minValue = mvr;
                    node.numOccurences = nor;
                }
                else
                {
                    node.minValue = mvl;
                    node.numOccurences = nol+nor;
                }
            }

            return node;
        }

        public static Node MergeTrees(Node tree1, Node tree2)
        {
            int lb = tree1.leftBound;
            int rb = tree1.rightBound;
            int mv1 = tree1.minValue;
            int mv2 = tree2.minValue;
            int no1 = tree1.numOccurences;
            int no2 = tree2.numOccurences;

            Node merged_tree = new Node();

            merged_tree.leftBound = lb;
            merged_tree.rightBound = rb;

            if(mv1 < mv2)
            {
                merged_tree.minValue = mv1;
                merged_tree.numOccurences = no1;
            }
            else if(mv1 > mv2)
            {
                merged_tree.minValue = mv2;
                merged_tree.numOccurences = no2;
            }
            else
            {
                merged_tree.minValue = mv1;
                merged_tree.numOccurences = no1+no2;
            }

            if(tree1.leftChild != null)
            {
                Node left_child = MergeTrees(tree1.leftChild, tree2.leftChild);
                merged_tree.leftChild = left_child;
                left_child.parent = merged_tree;
            }

            if(tree1.rightChild != null)
            {
                Node right_child = MergeTrees(tree1.rightChild, tree2.rightChild);
                merged_tree.rightChild = right_child;
                right_child.parent = merged_tree;
            }

            return merged_tree;
        }

        public static Pair ComparePairs(Pair pair1, Pair pair2)
        {
            if( pair1.occurence == 0 ) return new Pair(pair2);

            if( pair2.occurence == 0 ) return new Pair(pair1);

            if( pair1.value < pair2.value ) return new Pair(pair1);

            if( pair2.value < pair1.value ) return new Pair(pair2);

            return new Pair(pair1.value, pair1.occurence + pair2.occurence);
        }

        public static Pair SearchTree(Node tree, int left_bound, int right_bound)
        {
            if( tree == null )
            {
                return new Pair();
            }

            int lb = tree.leftBound;
            int rb = tree.rightBound;

            if( (lb >= left_bound) && (rb <= right_bound) )
            {
                return new Pair(tree.minValue, tree.numOccurences);
            }

            if((lb > right_bound) || (left_bound > rb))
            {
                return new Pair();
            }

            Pair left_pair = SearchTree(tree.leftChild, left_bound, right_bound);
            Pair right_pair = SearchTree(tree.rightChild, left_bound, right_bound);

            return ComparePairs(left_pair, right_pair);
            /*
            if( left_pair.occurence == 0 ) return right_pair;

            if( right_pair.occurence == 0 ) return left_pair;

            int mv, no;

            if(left_pair.value < right_pair.value)
            {
                mv = left_pair.value;
                no = left_pair.occurence;
            }
            else if(left_pair.value > right_pair.value)
            {
                mv = right_pair.value;
                no = right_pair.occurence;
            }
            else
            {
                mv = left_pair.value;
                no = left_pair.occurence + right_pair.occurence;
            }

            return new Pair(mv, no);
            */
        }


        
        public static NodePointer MakeForest(Node[] tree, int left_bound, int right_bound)
        {
            NodePointer new_tree = new NodePointer();

            new_tree.leftBound = left_bound;
            new_tree.rightBound = right_bound;

            if( left_bound == right_bound )
            {
                new_tree.node = tree[left_bound];
            }
            else
            {
                int middle = (left_bound+right_bound)/2;
                NodePointer left_child = MakeForest(tree, left_bound, middle);
                NodePointer right_child = MakeForest(tree, middle+1, right_bound);

                new_tree.leftChild = left_child;
                new_tree.rightChild = right_child;

                left_child.parent = new_tree;
                right_child.parent = new_tree;

                new_tree.node = MergeTrees(left_child.node, right_child.node);
            }

            return new_tree;
        }

        public static Pair SearchForest(NodePointer forest, int x_lb, int x_rb, int y_lb, int y_rb)
        {
            if( forest == null ) return new Pair();

            int lb = forest.leftBound;
            int rb = forest.rightBound;

            if((y_lb <= lb) && (y_rb >= rb)) return SearchTree(forest.node, x_lb, x_rb);

            if((lb > y_rb) || (y_lb > rb)) return new Pair();

            Pair left_pair = SearchForest(forest.leftChild, x_lb, x_rb, y_lb, y_rb);
            Pair right_pair = SearchForest(forest.rightChild, x_lb, x_rb, y_lb, y_rb);

            return ComparePairs(left_pair, right_pair);

            /*
            if( left_pair.occurence == 0 ) return right_pair;

            if( right_pair.occurence == 0 ) return left_pair;

            int mv, no;

            if(left_pair.value < right_pair.value)
            {
                mv = left_pair.value;
                no = left_pair.occurence;
            }
            else if(left_pair.value > right_pair.value)
            {
                mv = right_pair.value;
                no = right_pair.occurence;
            }
            else
            {
                mv = left_pair.value;
                no = left_pair.occurence + right_pair.occurence;
            }

            return new Pair(mv, no);
            */
        }
        

        
        public static void WriteDownTree(Node tree)
        {
            int mv = tree.minValue;
            int no = tree.numOccurences;

            Console.Write("("+mv+","+no+") ");

            if( tree.leftChild != null ) WriteDownTree(tree.leftChild);

            if( tree.rightChild != null ) WriteDownTree(tree.rightChild);
        }
        

        public static void WriteDownForest(NodePointer forest)
        {
            Console.Write("Tree: lb: "+forest.leftBound+" rb: "+forest.rightBound+" :");
            WriteDownTree(forest.node);
            Console.WriteLine();

            if(forest.leftChild != null) WriteDownForest(forest.leftChild);

            if(forest.rightChild != null) WriteDownForest(forest.rightChild);
        }

        public static void Main()
        {
            int n, m ,q;

            string[] input = Console.ReadLine().Split();
            n = Convert.ToInt32(input[0]);
            m = Convert.ToInt32(input[1]);
            q = Convert.ToInt32(input[2]);

            int[][] a = new int[n+1][];

            for(int i=0; i<n; i++)
            {
                string inputLine = Console.ReadLine();
                a[i] = inputLine.Split(' ').Select(int.Parse).ToArray();
            }

            Node[] seg_tree = new Node[n];

            for(int i=0; i<n; i++)
                seg_tree[i] = MakeTree(a[i], 0, m-1);

            /*
            for(int i=0; i<n; i++)
            {
                WriteDownTree(seg_tree[i]);
                Console.WriteLine();
            }
            */

            NodePointer seg_forest = MakeForest(seg_tree, 0, n-1);

            WriteDownForest(seg_forest);

            for(int i=0; i<q; i++)
            {
                int x, y, h, w;

                string[] inputLine = Console.ReadLine().Split();
                x = Convert.ToInt32(inputLine[0]);
                y = Convert.ToInt32(inputLine[1]);
                h = Convert.ToInt32(inputLine[2]);
                w = Convert.ToInt32(inputLine[3]);

                //Pair p = SearchForest(seg_forest, x-1, x+w-2 ,y-1, y+h-2);
                //Console.WriteLine(p.occurence);

                

                Pair pair_up, pair_down, pair_left, pair_right;

                if( y > 1 ) pair_up = SearchForest(seg_forest, 0, m-1, 0, y-2);
                else pair_up = new Pair();

                if( y+h-1 < n ) pair_down = SearchForest(seg_forest, 0, m-1, y+h-1 , n-1);
                else pair_down = new Pair();

                if( x > 1 ) pair_left = SearchForest(seg_forest, 0, x-2, y-1, y+h-2);
                else pair_left = new Pair();

                if( x+w-1 < m ) pair_right = SearchForest(seg_forest, x+w-1, m-1, y-1, y+h-2);
                else pair_right = new Pair();

                Pair result_pair = ComparePairs( ComparePairs(pair_up, pair_down), ComparePairs(pair_left, pair_right) );

                Console.WriteLine(result_pair.occurence);
                
            }
        }
    }
}