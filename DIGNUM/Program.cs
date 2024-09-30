using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> data = new List<string>();
        string EOF = " ";
        while( (EOF = Console.ReadLine()) != null && EOF != "" )
        {
            data.Add(EOF);
        }

        for(int j = 0; j < data.Count; j+=3)
        {

            string finalNuber = "";
            
            string input1 = data[j];
            string input2 = data[j+1];
            string input3 = data[j+2];


            for(int i = 0; i < input2.Length; i+=3)
            {
                //All numbers
                //    _  _     _  _  _  _  _  _ 
                //  | _| _||_||_ |_   ||_||_|| |
                //  ||_  _|  | _||_|  ||_|  ||_|

                //string printLine1 = ""; //Only for tests
                string printLine2 = "";
                string printLine3 = "";

                ///printLine1 = printLine1 + input1[i] + input1[i+1] + input1[i+2]; //Only for tests
                printLine2 = printLine2 + input2[i] + input2[i+1] + input2[i+2];
                printLine3 = printLine3 + input3[i] + input3[i+1] + input3[i+2];

                //Console.WriteLine(i); //Only for tests
                //Console.WriteLine(printLine1);
                //Console.WriteLine(printLine2);
                //Console.WriteLine(printLine3);
                
                switch(printLine3)
                {
                    case "  |": //1 || 4 || 7 || 9
        
                        switch(printLine2)
                        {
                            case "  |": //1 || 7
                                if(input1[i+1] != '_')
                                    finalNuber = finalNuber + "1";
                                else
                                    finalNuber = finalNuber + "7";
                                break;

                            case "|_|": //4 || 9
                                if(input1[i+1] != '_')
                                    finalNuber = finalNuber + "4";
                                else
                                    finalNuber = finalNuber + "9";
                                break;
                        }
                        break;


                    case "|_|": //6 || 8 || 0

                        switch(printLine2)
                        {
                            case "|_ ":
                                finalNuber = finalNuber + "6";
                                break;

                            case "|_|":
                                finalNuber = finalNuber + "8";
                                break;
                            case "| |":
                                finalNuber = finalNuber + "0";
                                break;
                        }
                        break;


                    case " _|": //3 || 5
                        switch(printLine2)
                        {
                            case " _|":
                                finalNuber = finalNuber + "3";
                                break;

                            case "|_ ":
                                finalNuber = finalNuber + "5";
                                break;
                        }
                        break;


                    case "|_ ": //2
                        finalNuber = finalNuber + "2";
                        break;
                }

            }
            Console.WriteLine(finalNuber);
        }

    }
}