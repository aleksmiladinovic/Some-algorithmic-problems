## Skoljke (Sea shell)

A long time ago there were num_islands islands in a sea (numerated with numbers **1**, **2**,..., **num_islands**) and num_bridges bridges between them. Zika, a known sea shell smuggler, had traveled each week from island **1** to island **num_islands** on foot, crossing the bridges in order to sell his sea shells. He always chose a path in which the number of bridges that he would cross was minimal.

Alas, after some time, Zika got a bad reputation, hence, the authorities of particular **num_forbidden_islands** islands have denied him access to theis islands. Zika still wants to get to his destination while crossing the minimal number of bridges, but, as it turns out, his path is longer than it has been before. Fortunately, the inhabitants of the island **num_islands** still want Zika to cross the same number of bridges as before (in order for his arrival time to remain the same), hence, they decided to help him by building one bridge between islands where Zika is not denied access.

In how many ways can this be done?

**Input:**  
In the first line we read three numbers: **num_islands**, **num_bridges**, **num_forbidden_islands** (2<**num_islands**<20001, 0<**num_bridges**<200001, 0<**num_forbidden_islands**<**num_islands**-1). In the following line there are **num_forbidden_islands** numbers indicating which islands have denied Zika the access to their island. In the following **num_bridges** lines there are two integers, indicating that there is a bridge between islands numerated with the read numbers (there will be at most one bridge between two islands, and there will always be a path from island **1** to the island **num_islands**).

**Output:**  
The output should contain only one integer, the number of ways the inhabitants can build a bridge in order to help Zika.

**Example:**  
Input:  
8 7 4  
6 7 3 5  
1 2  
3 8  
5 8  
2 4  
1 5  
4 8  
1 3  

Output:  
2

**Explanation:** Before the denial of access, Zika traveled crossing only 2 bridges (1-3-8 or 1-5-8). After he is denied access to islands 6, 7, 3 and 5, the shortest (and only) path contains 3 bridges. However, if the inhabitants of the island 8 build a bridge between islands 2 and 8 or between islands 1 and 4 Zika can choose paths 1-2-8 and 1-4-8 respectively. These are the only two solutions. Note that building a bridge between islands 1 and 8 is not a solution.
