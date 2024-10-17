## Sljivik (Plum orchard)

Srba has an orchard of plums in the shape of a rectangle, in which the trees are organized in **dim_x** rows and **dim_y** columns. Each of the trees has a number of plums on it which is carefully registered by Srba.

Srba also has **n_kids** number of kids that love plums. In order to surprise them, he decided to harvest some plums for them such that each child gets the same amount of plums. Since Srba is a perfectioninst he wants to harvest a part of the orchard in the shape of a rectangle whose sides are parallel to the sides of the orchard, such that all the plums from the selected rectangle are harvested.

Help Srba determine in how many ways he can choose the part of the orchard to harvest.

**Input:**  
In the first line we read three numbers: **dim_x**, **dim_y** and **n_kids** (0<**dim_x**, **dim_y**<251, 0<**n_kids**<1000001). In each of the following **dim_x** lines we read **dim_y** numbers corresponding to the number of plums on each tree in the orchard (each of the numbers is in the interval [1, 10^9]).

**Output:**  
Print the number of ways Srba can choose a part of the orchard to harvest.

**Example:**  
Input:  
3 3 5  
2 9 3  
10 8 6  
1 4 12  

Output:  
4

**Explanation:** The following rectangles are adequate: (1,1)-(3,3) , (2,1)-(2,1) , (3,1)-(3,2) , (2,2)-(3,3), where the first pair represents the upper left and the second pair the lower right vertex of the selected rectangle.
