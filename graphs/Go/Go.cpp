#include <cstdlib>
#include <iostream>
#include <queue>
#include <vector>
#include <utility>

using namespace std;

const int dx[] = { 1, 0, -1, 0};
const int dy[] = { 0, 1, 0, -1};

int dimension;
char table[1005][1005];
int connected_component[1005][1005];
int size_of_cc[1000000], num_of_free_squares[1000000];
int num_white, num_black, num_cc;
int solution;

void Initialize()
{
	num_cc=0;
	num_white=0;
	num_black=0;
	
	for(int i=0; i<dimension; i++)
		for(int j=0; j<dimension; j++)
		{
			connected_component[i][j]=0;
			size_of_cc[i*dimension+j]=0;
			num_of_free_squares[i*dimension+j]=0;
		}
}

bool Out_of_bounds_check(int x, int y)
{
	return (x>0)&&(y>0)&&(x<dimension)&&(y<dimension);
}

int BFS(char color, int x_coordinate, int y_coordinate)
{
	int size=0;
	queue<pair<int, int>> Q;
	Q.push(make_pair(x_coordinate, y_coordinate));
	
	while(!Q.empty())
	{
		int x, y;
		x = Q.front().first;
		y = Q.front().second;
		Q.pop();
		
		size++;
		connected_component[x][y] = num_cc;
		
		int xn, yn;
		for(int l=0; l<4; l++)
		{
			xn = x+dx[l];
			yn = y+dy[l];
			if( !Out_of_bounds_check(xn, yn) ) continue;
			
			if(table[xn][yn]==color && connected_component[xn][yn]==0)
			{
				Q.push(make_pair(xn, yn));
			}
		}
	}
	
	return size;
}

void Update_free_squares(int x, int y)
{
	int xn, yn;
	vector<int> free_square_of_cc;
	
	for(int l=0; l<4; l++)
	{
		xn = x+dx[l];
		yn = y+dy[l];
		if( !Out_of_bounds_check( xn, yn) ) continue;
		
		if( connected_component[xn][yn]!=0 )
		{
			int cc=connected_component[xn][yn];
			
			bool already_associated = false;
			int length = free_square_of_cc.size();
			for(int k=0; k<length; k++)
				if( cc == free_square_of_cc[k] ) already_associated=true;	
			if( already_associated ) continue;
			
			num_of_free_squares[cc]++;
			free_square_of_cc.push_back( cc );
		}
	}
}

int Place_pebble(int x, int y)
{
	int xn, yn;
	vector<int> cc_buffer;
	bool there_is_black = false;
	
	int black_erased=0;
	int white_erased=0;
	
	for(int l=0; l<4; l++)
	{
		xn = x+dx[l];
		yn = y+dy[l];
		
		if(!Out_of_bounds_check(xn, yn)) continue;
		
		int cc = connected_component[xn][yn];
		
		if( cc!=0 && num_of_free_squares[cc]==1)
		{
			bool already_accounted_for = false;
			int length = cc_buffer.size();
			
			for(int k=0; k<length; k++)
				if( cc_buffer[k] == cc ) already_accounted_for=true;
			
			if( already_accounted_for ) continue;
			cc_buffer.push_back(cc);
			
			if( table[xn][yn]=='C' )
			{
				there_is_black = true;
				black_erased += size_of_cc[cc];
			}
			else white_erased += size_of_cc[cc];
		}
	}
	
	if( there_is_black ) white_erased=-1;
	
	return num_white - white_erased - num_black + black_erased;
}

int main()
{
	scanf("%d",&dimension);
	
	for(int i=0; i<dimension; i++)
		scanf("%s",table[i]);
	
	Initialize();
	
	for(int i=0; i<dimension; i++)
		for(int j=0; j<dimension; j++)
		{
			if(table[i][j]!='.' && connected_component[i][j]==0)
			{
				num_cc++;
				size_of_cc[num_cc] = BFS(table[i][j], i, j);
				
				if( table[i][j]=='B' ) num_white += size_of_cc[num_cc];
				else num_black += size_of_cc[num_cc];
			}
		}
	
	for(int i=0; i<dimension; i++)
		for(int j=0; j<dimension; j++)
			if( table[i][j]=='.' )
				Update_free_squares( i, j );
				
	solution = -dimension*dimension;
				
	for(int i=0; i<dimension; i++)
		for(int j=0; j<dimension; j++)
			if( table[i][j]=='.' )
			{
				int difference = Place_pebble( i, j );
				if( solution<difference ) solution = difference;
			}
			
	printf("%d\n", solution);
	
	return 0;
}