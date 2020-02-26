using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Question_One
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var fileInput = "input.txt";

            ArrayList resultList = new ArrayList();

            string[] fullInput = File.ReadAllLines(fileInput);

            foreach(string element in fullInput)
            {
                if (element.StartsWith("LOC"))
                {
                    var splitString = element.Split('+');
                    var output = splitString[1] + ' ' + splitString[2]; 
                    resultList.Add(output);
                }
            }

            foreach(string elem in resultList)
            {
                Console.WriteLine(elem);
            }

            Console.ReadLine();
        }
    }
}
