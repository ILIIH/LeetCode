internal class Program
{
    static string[][] zigzag; 
    private static void Main(string[] args)
    {
        convert("hello my name is illia", 3);
    }

    static string convert(string line, int numRows) 
    {
        string result = "";
        line = line.Replace(" ", "");
        Console.WriteLine(line);

        if (line.Length <= numRows) {
            return line;
        }
        int sectionAmount = (line.Length + 2 * numRows - 2) / (2 * numRows - 1);
        int arrLenght = numRows* sectionAmount;

        zigzag = new string[numRows][];

        for (int k = 0; k < numRows; k++) {
            zigzag[k] = new string[arrLenght];
        }

        bool reverse = false;

        int i = 0;
        int j = 0;
        int charIndex = 0;

        for (int o = 0; o < sectionAmount; o++) {
            if (!reverse)
            {
                while (true)
                {
                    if (i == numRows)
                    {
                        reverse = true;
                        break;
                    }

                    if (charIndex< line.Length)
                    {
                        zigzag[i][j] = line[charIndex].ToString();
                    }
                        
                    
                    i++;
                    charIndex++;
                }
            }
            else {
                while (true)
                {
                    i--;
                    j++;
                    charIndex++;

                    if (charIndex < line.Length)
                    {
                        zigzag[i][j] = line[charIndex].ToString();
                    }
                   
                    if (i == 1)
                    {
                        reverse = false;
                        break;
                    }
                    

                }
            }

        }

        showArr(zigzag);
        return result;
    }

    static void showArr(string[][] arr) { 

        for(int i = 0;i < arr.Length;i++) {
            for (int j = 0; j < arr[i].Length; j++){
                Console.Write(arr[i][j]+',');
            }
            Console.WriteLine();
        }
    }
}