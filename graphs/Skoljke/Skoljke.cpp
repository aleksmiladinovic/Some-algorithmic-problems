#include <cstdlib>
#include <iostream>
#include <vector>
#include <queue>

using namespace std;

class compare
{
	public:
		bool operator()(const int &instance1, const int &instance2)
		{
			return instance1 > instance2;
		}
};

int num_islands, num_bridges, num_forbidden_islands;

vector<int> bridges[20005];
int forbidden_island[20005];
int steps[20005], steps_new[20005], steps_reversed[20005];
int num_of_islands_in_steps[20005];

void Initialize()
{
	for(int i=0; i<=num_islands; i++)
	{
		steps[i] = -1;
		steps_new[i] = -1;
		steps_reversed[i] = -1;
		num_of_islands_in_steps[i] = 0;
	}
}

void Dijkstra(int *min_steps, int start_island)
{
	min_steps[start_island] = 0;
	
	priority_queue<int, vector<int>, compare> Q;
	
	Q.push(start_island);
	
	while( !Q.empty() )
	{
		int current_island = Q.top();
		Q.pop();
		
		int num_neighbors = bridges[current_island].size();
		for(int i=0; i<num_neighbors; i++)
		{
			int neighbor_island = bridges[current_island][i];
			
			if(min_steps[neighbor_island]==-2) continue;
			
			if(min_steps[neighbor_island]==-1 || min_steps[neighbor_island]>min_steps[current_island]+1)
			{
				min_steps[neighbor_island] = min_steps[current_island]+1;
				Q.push(neighbor_island);
			}
		}
	}
}

int main()
{
	scanf("%d %d %d", &num_islands, &num_bridges, &num_forbidden_islands);
	
	Initialize();
	
	for( int i=0; i<num_forbidden_islands; i++ )
	{
		scanf("%d",&forbidden_island[i]);
		steps_new[forbidden_island[i]] = -2;
		steps_reversed[forbidden_island[i]] = -2;
	}
	
	for( int i=0; i<num_bridges; i++ )
	{
		int island1, island2;
		scanf("%d %d", &island1, &island2);
		
		bridges[island1].push_back(island2);
		bridges[island2].push_back(island1);
	}
	
	Dijkstra(steps, 1);
	
	int num_of_steps = steps[num_islands];
	
	Dijkstra(steps_new, 1);
	Dijkstra(steps_reversed, num_islands);
	
	int solution = 0;
	
	for(int i=1; i<=num_islands; i++)
		if(steps_new[i] >= 0) num_of_islands_in_steps[steps_new[i]]++;
		
	for(int i=1; i<=num_islands; i++)
	{
		if(steps_reversed[i]<0) continue;
		
		int difference = num_of_steps - steps_reversed[i] - 1;
		if(difference >= 0) solution += num_of_islands_in_steps[difference];
	}
	
	printf("%d\n", solution);
	
	return 0;
}