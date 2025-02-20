# Bekstvo (Escape)

You are at a concert and you have realized that your programming competition starts soon, meaning that it is, perhaps, better to leave. The only problem is the fact that you are surrounded by faithful crowd which refuses to move until the end of performance.

Luckily, you are prepared! You have pulled a magical tree out of your backpack, just for this occasion. Your magic tree has, of course, **n** nodes and **n-1** edges. You hve quickly planted the tree and applied at most **k** magical operations in orther to move as far away as possible.

In one such operation, you are allowed to pick one edge from the tree and move it, such that your graph still remains a tree. Formally, you are allowed to choose one edge of the tree, erase it, and add one edge such that the newly formed graph is again a tree. Your goal is to escape as far as possible, hence, you want to maximize the diameter of the tree. The diameter is defined as the maximal number of edges on a path between two nodes.

**Input:**  
In the first line of input is the number **t** ($1\leq t\leq 10$), the number of test cases. Each test case consists of the following:  
The first line consists of two integers **n** and **k** ($n\leq 3000$, $0\leq k \leq n$). The following $n-1$ lines contain two numbers each, describing the nodes of the tree connected by an edge.

**Output:**  
For each test case you should print one integer, the maximal diameter of the tree after $k$ operations.

**Example:**  
Input:  
3  
5 0  
1 4  
3 4  
2 4  
5 2  
5 1  
1 4  
3 4  
2 4  
5 2  
7 3  
1 4  
4 6  
4 3  
2 4  
5 2  
5 7

Output:  
3  
4  
6
