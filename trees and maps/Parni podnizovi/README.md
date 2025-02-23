# Parni podnizovi (Even subsequences)

You are given a sequence **a** of **n** integers. Find the number of subsequences of consecutive elements of **a** such that every element of the subsequence occurs even number of times in that subsequence.

**Input:**  
The first line of input contains one integer **n** ($1\leq n\leq 535353$). The following line contains $n$ integers $a[i]$, the elements of the sequence **a** ($1\leq a[i] \leq 10^9$).

**Output:**  
The output should consist of only one integer, the nuber of subsequences of consecutive elements of **a**, such that every element of the subsequence occurs even number of times.

**Example:**  
Input:  
8  
3 5 3 5 9 9 5 3

Output:  
5

**Explanation:** There are 5 such subsequences: $[3, 5, 3, 5]$, $[3, 5, 3, 5, 9, 9]$, $[9, 9]$, $[5, 9, 9, 5]$ and $[3, 5, 9, 9, 5, 3]$. 
