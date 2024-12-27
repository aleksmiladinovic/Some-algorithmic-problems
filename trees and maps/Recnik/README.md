## Recnik (Dictionary)

Little Dekica has decided to make his own dictionary in which he would store all the words that he can think of. As in any dictionary, the words are sorted alfabetically from the smallest to the largest. As the time passes by, the dictionary grows bigger and bigger. For a selected word, little Dekica would like to know how many words there are in the dictionary that come before his selected word.

**Input:**  
In the first line of the standard input there is one integer **N** (0<**N**<1000000) representing the number of commands. The following **N** lines of standard input contain the commands which include:  
ADD *word*  
LESS *word*  
The words will be composed only of letters of English alphabet, either lowercase or uppercase. However, words such as "PoPoKaTaPeTL" and "POPOkataPETl" are considered to be the same word. Length of each word will not exceed 100 characters while the length of the whole dictionary will be less than 2000000 characters.

**Output:**  
For each LESS command one integer should be printed, which represents how many words there are in the dictionary that come before the given word in the command. If the given word does not exist in the dictionary, "no such word" should be printed.

**Example:**  
Input:  
14  
ADD Petronije  
ADD PeTrONIJE  
ADD Jovan  
ADD STEVAN  
LESS Stevan  
ADD ISTVAn  
LESS pajVan  
ADD maja  
LESS istvan  
ADD KlipaN  
ADD Milica  
LESS stevan  
ADD Milica  
ADD MiliCA  

Output:  
2  
no such word  
0  
6
