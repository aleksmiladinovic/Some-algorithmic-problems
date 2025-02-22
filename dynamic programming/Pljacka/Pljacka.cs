using System;

namespace Pljacka
{
    class Pljacka
    {
        public static void Main()
        {
            int n, m;

            string[] input = Console.ReadLine().Split();

            n = Convert.ToInt32(input[0]);
            m = Convert.ToInt32(input[1]);

            int[][] a = new int[n][];
            int[,] l = new int[n, m]; // l[i,j] will contain maximal
            //amount one could obtain left of (i,j) on the same floor
            int[,] d = new int[n, m]; // d[i,j] will contain maximal
            //amount one could obtain right of (i,j) on the same floor
            int[,] s = new int[n, m];

            for(int i=0; i<n; i++)
            {
                string inputLine = Console.ReadLine();
                a[i] = inputLine.Split(' ').Select(int.Parse).ToArray();
            }

            for(int i=0; i<n; i++)
            {
                l[i,0] = 0;
                for(int j=1; j<m; j++)
                    if( l[i,j-1]+a[i][j-1] > 0 ) l[i,j] = l[i,j-1]+a[i][j-1];
                    else l[i,j] = 0;

                d[i,m-1] = 0;
                for(int j=m-2; j>=0; j--)
                    if(d[i,j+1]+a[i][j+1] > 0) d[i,j] = d[i,j+1]+a[i][j+1];
                    else d[i,j] = 0;
            }

            int solution = a[0][0];

            for(int i=0; i<m; i++)
            {
                s[n-1, i] = a[n-1][i] + d[n-1,i] + l[n-1,i];
                if( solution < s[n-1,i] ) solution = s[n-1,i];
            }

            for(int i=n-2; i>=0; i--)
            {
                for(int j=0; j<m; j++)
                {
                    s[i,j] = a[i][j] + l[i,j] + d[i,j];

                    int current_sum = s[i,j] + s[i+1,j];
                    if( s[i,j] < current_sum ) s[i,j] = current_sum;

                    current_sum = a[i][j] + d[i,j];
                    for(int k=j-1; k>=0; k--)
                    {
                        current_sum += a[i][k];
                        if( s[i,j] < current_sum+l[i,k]+s[i+1,k] )
                            s[i,j] = current_sum+l[i,k]+s[i+1,k];
                    }

                    current_sum = a[i][j] + l[i,j];
                    for(int k=j+1; k<m; k++)
                    {
                        current_sum += a[i][k];
                        if( s[i,j] < current_sum+d[i,k]+s[i+1,k] )
                            s[i,j] = current_sum+d[i,k]+s[i+1,k];
                    }

                    if( solution < s[i,j] ) solution = s[i,j];
                }
            }

            Console.WriteLine(solution);
        }
    }
}
