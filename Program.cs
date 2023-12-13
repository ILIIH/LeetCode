using System.Text;

internal class Program
{
  
    private static void Main(string[] args)
    {
        string textToConverte = "Apalindromeisaword,phrase,number,orothersequenceofunitsthatcanbereadthesamewayineitherdirection,withgeneralallowancesforadjustmentstopunctuationandworddividers.";
        int numberOfRows = 2;
        convert(textToConverte, numberOfRows);
    }

    static string convert(string line, int numRows) 
    {
        string result = "";
        line = line.Replace(" ", "");

        if (line.Length <= numRows || numRows == 1) {
            return line;
        }
        string[][] zigzag = convertStringToZigZagArr(line, numRows);

        showArr(zigzag);
        Console.WriteLine(getResult(zigzag));
        return result;
    }

    static string[][] convertStringToZigZagArr(string line, int numRows) {

        int sectionAmount = (line.Length + 2 * numRows - 2) / (2 * numRows - 1);
        int arrLenght = numRows * sectionAmount;

        string[][] zigzag = new string[numRows][];

        for (int k = 0; k < numRows; k++)
        {
            zigzag[k] = new string[arrLenght];
        }

        int i = 0;
        int j = 0;
        int charIndex = 0;

        while (j< arrLenght)
        {
            while (true)
            {
                if (i == numRows)
                {
                    i--;
                    break;
                }

                if (charIndex < line.Length)
                {
                    zigzag[i][j] = line[charIndex].ToString();

                }
                if (i < numRows)
                {
                    i++;
                    charIndex++;
                }

            }


            while (true)
            {
         
                i--;
                j++;
               
                if (charIndex < line.Length)
                {
                    zigzag[i][j] = line[charIndex].ToString();
                }

                if (i == 0)
                {
                    break;
                }
                else
                {
                    charIndex++;
                }
            }

        }
        return zigzag;
    }

    static string getResult(string[][] arr)
    {
        StringBuilder stringBuilder = new StringBuilder();

        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < arr[i].Length; j++)
            {
                if (arr[i][j]!= null) stringBuilder.Append(arr[i][j]);
            }
        }

        return stringBuilder.ToString();
    }
    static void showArr(string[][] arr) { 

        for(int i = 0;i < arr.Length;i++) {
            for (int j = 0; j < arr[i].Length; j++){
                if(arr[i][j] == null) Console.Write("-,");
                else Console.Write(arr[i][j]+',');
            }
            Console.WriteLine();
        }
    }
}