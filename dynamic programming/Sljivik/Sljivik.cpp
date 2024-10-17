#include <cstdlib>
#include <iostream>
#include <vector>
#include <queue>
#include <algorithm>

using namespace std;

int dim_x, dim_y, n_kids;
int matrix[255][255], cumulative_sums[255][255];
int n_sums[1000005], iteration[1000005];
int counter, result, current_sum;

void Initialize()
{
	result=0;
	counter=0;
	current_sum=0;
	for(int i=0; i<n_kids; i++)
	{
		n_sums[i] = 0;
		iteration[i] = 0;
	}
}

int main()
{
	scanf("%d %d %d", &dim_x, &dim_y, &n_kids);
	
	for(int i=0; i<dim_x; i++)
		for(int j=0; j<dim_y; j++)
			scanf("%d", &matrix[i][j]);
	
	for(int i=0; i<dim_x; i++)
	{
		cumulative_sums[i][0]=0;
		
		for(int j=0; j<dim_y; j++)
			cumulative_sums[i][j+1] = cumulative_sums[i][j]+matrix[i][j];
	}
	
	Initialize();
	
	for(int i=1; i<=dim_y; i++)
		for(int j=0; j<i; j++)
		{
			counter++;
			current_sum=0;
			iteration[0]=counter;
			n_sums[0]=1;
			
			for(int l=0; l<dim_x; l++)
			{
				current_sum += cumulative_sums[l][i]-cumulative_sums[l][j];
				current_sum %= n_kids;
				if(current_sum<0) current_sum += n_kids;
				
				if( iteration[current_sum] == counter )
				{
					result += n_sums[current_sum];
					n_sums[current_sum]++;
				}
				else
				{
					iteration[current_sum]=counter;
					n_sums[current_sum]=1;
				}
			}
		}
	
	printf("%d\n", result);
	
	return 0;
}