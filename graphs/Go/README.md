## Go

Perica and Jovica have recently discovered the ancient chineese game Go and decided to play one game. They liked the game so much that they have not studied all the rules, and have instead played by their own made up rules.

They play on a bord of size $dimension \times dimension$. Perica plays with white pebbles while Jovica plays with black pebbles. They play alternately, and in each turn a player puts a pebble on a free square.

Each square is adjacent to maximal four other squares - upper, lower, right and left square (if they are in the bounds of of the board). An empty square adjacent to a square with a pebble represents one degree of freedom of that pebble. Two adjacent squares both containing a pebble of the same color are connected, and all the squares that are mutually connected form a group. Additionally, the number of free squares adjacent to the squares of one group represents the degree of freedom of that group. If, after a turn, the degree of freedom of some opponent groups become 0, then we say that those groups lost their freedom all of the pebbles from those groups are removed from the board. If, by setting a pebble, a number of opponent's and the number of own groups lose their freedom, only the opponent's pebbles from those groups are to be removed. However, if setting a pebble leads only to the loss of freedom of own groups, then the pebbles of those groups are to be removed from the board.

The game is well underway and it is Perica's turn, who plays with white pebbles. Perica wants to place a pebble such that the difference between the white pebbles and the black pebbles is maximized. Help Perica decide where to place his pebble.

**Input:**  
The first line contains one integer **dimension** ($0<dimension \leq 1000$). The following **dimension** lines contain **dimension** caracters, which depict the board at the time of Perica's turn. The square marked with **'B'** represents a square with a white pebble on it, **'C'** represents a square with a black pebble on it, while **'.'** represents a free square. There will always be at least one free square and there will be no groups whose degree of freedom is $0$.

**Output:**  
Output should contain only one integer representing the maximal difference between white and black pebbles on the board after Perica's turn.

**Example:**  
Input:  
7  
.BBBB..  
BCCCCBC  
BCB.CBC  
BCCCCBB  
BBBBB..  
....B.C  
CB.....

Output:  
16

**Explanation:** There are 19 white and 14 black pebbles on the board. By placin a white pebble on the square in the third row and fourth column a group of 10 black pebbles is to be removed from the board, leaving 20 white and 4 black pebbles on the board.
