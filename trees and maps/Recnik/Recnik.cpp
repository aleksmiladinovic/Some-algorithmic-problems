#include <cstdlib>
#include <iostream>
#include <cstring>

using namespace std;

struct vertex
{
	char *wordd;
	int less;
	struct vertex *parent;
	struct vertex *left;
	struct vertex *right;
};

void all_lowercase(char *word)
{
	int len = strlen(word);
	for(int i=0; i<len; i++)
		if((word[i]>='A')&&(word[i]<='Z')) word[i] = 'a'+(word[i]-'A');
}

char* add_word(char *word)
{
	int len = strlen(word);
	char *new_word;
	new_word = (char*)calloc(len, sizeof(char));
	
	for(int i=0; i<len; i++)
		new_word[i] = word[i];
		
	return new_word;
}

char cmp(char *word1, char *word2)
{
	int len, lenw1, lenw2;
	lenw1 = strlen(word1);
	lenw2 = strlen(word2);
	if( lenw1 < lenw2 ) len = lenw1;
	else len = lenw2;
	
	for(int i=0; i<len; i++)
		if( word1[i] < word2[i] ) return '<';
		else if( word1[i] > word2[i] ) return '>';
		
	if( lenw1 < lenw2 ) return '<';
	else if(lenw1 > lenw2) return '>';
	
	return '=';
}

void cancel_update(struct vertex *vert, char *word)
{
	while(vert != NULL)
	{
		char sign = cmp(vert->wordd, word);
		if(sign == '<') vert = vert->parent;
		else if(sign == '>')
		{
			(vert->less)--;
			vert = vert->parent;
		}
	}
}

struct vertex* update_dict(struct vertex *root, char *word)
{
	struct vertex *new_vertex;
	new_vertex = (struct vertex*)malloc(sizeof(struct vertex));
	new_vertex->wordd = word;
	new_vertex->less = 0;
	new_vertex->left = NULL;
	new_vertex->right = NULL;
	new_vertex->parent = NULL;
	
	if(root == NULL) return new_vertex;
	
	struct vertex *current;
	current = root;
	
	while(true)
	{
		char sign = cmp(current->wordd, word);
		if(sign == '>')
		{
			(current->less)++;
			if( current->right == NULL )
			{
				current->right = new_vertex;
				new_vertex->parent = current;
				return root;
			}
			current = current->right;
		}
		else if(sign == '<')
		{
			if( current->left == NULL )
			{
				current->left = new_vertex;
				new_vertex->parent = current;
				return root;
			}
			current = current->left;
		}
		else
		{
			cancel_update(current->parent, word);
			return root;
		}	
	}
}

int less_than(struct vertex *root, char *word)
{
	int solution = 0;
	struct vertex *current;
	current = root;
	
	while(current != NULL)
	{
		char sign = cmp(word, current->wordd);
		
		if(sign == '=') return solution + current->less;
		if(sign == '>')
		{
			solution += current->less + 1;
			current = current->left;
		}
		if(sign == '<') current = current->right;
	}
	
	return -1;
}

int main()
{
	int n, num_words=0;
	char *words[20001];
	struct vertex *root;
	root = NULL;
	
	scanf("%d",&n);
	
	for(int i=0; i<n; i++)
	{
		char command[5], word[101];
		scanf("%s %s", command, word);
		all_lowercase(word);
		
		if(command[0] == 'A')
		{			
			words[num_words] = add_word( word );
			root = update_dict(root, words[num_words]);
			num_words++;
		}
		if(command[0] == 'L')
		{			
			int lessthan = less_than(root, word);
			if(lessthan == -1) printf("no such word\n");
			else printf("%d\n",lessthan);
		}
	}
	
	return 0;
}