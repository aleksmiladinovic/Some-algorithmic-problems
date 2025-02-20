#include <cstdlib>
#include <iostream>
#include <vector>
#include <queue>
#include <utility>

using namespace std;

int n,k,t;
vector<int> paths[3001];
int steps[3001];

void initialize_paths()
{
	for(int i=1; i<=n; i++)
		paths[i].clear();
}

void initialize_steps()
{
	for(int i=1; i<=n; i++)
		steps[i] = -1;
}

pair<int, int> find_farthest()
{
	int max_steps = -1;
	int farthest = 0;
	
	for(int i=1; i<=n; i++)
		if( max_steps < steps[i] )
		{
			farthest = i;
			max_steps = steps[i];
		}
	return make_pair(farthest, max_steps);
}

void BFS(int start)
{
	steps[start] = 0;
	
	queue<int> Q;
	
	Q.push(start);
	
	while( !Q.empty() )
	{
		int node = Q.front();
		Q.pop();
		
		int num_neighbors = paths[node].size();
		for(int i=0; i<num_neighbors; i++)
		{
			int neighbor_node = paths[node][i];
			
			if(steps[neighbor_node]==-1 || steps[neighbor_node]>steps[node]+1)
			{
				steps[neighbor_node] = steps[node]+1;
				Q.push(neighbor_node);
			}
		}
	}
}

int main()
{
	scanf("%d",&t);
	
	for(int case_no=0; case_no<t; case_no++)
	{
		scanf("%d %d", &n, &k);
		
		initialize_paths();
		
		for(int i=0; i<n-1; i++)
		{
			int node1, node2;
			scanf("%d %d", &node1, &node2);
			
			paths[node1].push_back(node2);
			paths[node2].push_back(node1);
		}
		
		initialize_steps();
		BFS(1);
		
		int farthest = find_farthest().first;
		
		initialize_steps();
		BFS(farthest);
		
		int diameter = find_farthest().second;
		
		int branches = n-1-diameter;
		if( k>branches ) k=branches;
		
		printf("%d\n", diameter+k);
		
	}
	
	return 0;
}
