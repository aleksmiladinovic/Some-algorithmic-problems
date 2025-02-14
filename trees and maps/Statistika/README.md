# Statistika (Statistics)

You have gained the access to a database containing information about a virus in your city, from which we can obtain insights about the spread of the disease. The city is divided into fields that make a matrix **a** with **n** rows and **m** columns. The values **a[i][j]** in the database represent the number of cases of the virus in the field **(i,j)**.

You have decided to find the number of most heathy fields i.e. the number of fields that contain a number less or equal to any other number in the matrix. In order to make your analysis more interesting, you have decided to repeat you calculation **q** times. Each time, you chose a rectangular part of the city which you ignore in the calculation.

**Input:**  
First line of the input contains the numbers **n**, **m** and **q** (**n**, **m** < 1001, **q** < 100001). The next **n** lines contain **m** numbers each, which represent the values of the elements **a[i,j]** (**a[i,j]** < 10^9) of the matrix **a**. The next **q** lines contain four numbers each, **x**, **y**, **h**, **w** which is to be ignored in the query: **(x,y)** is the upper-left field of the ignored part of the city (with **(1,1)** being the upper-left field of the whole city), **h** is the height and **w** is the width of the ignored block. Note that the block that is to be ignored will never contain the whole city.

**Output:**  
For each query, you should print one number: the number of most healthy fields.

**Example:**  
Input:  
3 3 3  
1 2 3  
1 1 2  
3 3 3  
1 1 1 1  
1 1 2 2  
2 2 1 1

Output:  
2  
1  
2

**Explanation:** In the first query, we only ignore the upper-left field which is *1*. We see that the number of fields with only one case is *2*, hence the answer. In the second query, we ignore the upper-left block *{(1, 2), (1, 1)}*. In the remaining fields, we see that the minimal number is *1* and it occurs only *1* time. Finally, for the third query, we ignore the central field, which is marked with number *1*. From the remaining fields, *1* is the minimal number that occurs, and it occurs *2* times, hence the answer.
