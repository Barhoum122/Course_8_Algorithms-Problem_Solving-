using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToText
{
   public class ClsNumberToText
    {
         private int _number = 0;

        
        public String NumberToText(int _number)
        {
            if (_number == 0)
            {
                return "";
            }
            else if (_number >= 1 && _number <= 19)
            {
                String[] arr = 
                { 
                    
                    "One","Two","Three","Four","Five","Six","Seven", "Eight","Nine","Ten","Eleven",
                    "Twelve","Thirteen","Fourteen", "Fifteen","Sixteen","Seventeen","Eighteen","Nineteen "
                };
                return arr[_number-1]+" ";

            }
            else if (_number >= 20 && _number <= 99)
            {
                String[] arr = { "","", "Twenty","Thirty","Forty","Fifty","Sixty","Seventy","Eighty","Ninety", };
                return arr[_number/10] + " "+ NumberToText(_number %10);


            }
            else if (_number >= 100 && _number <= 199)
            {
                
                return "One Hundred" + " " + NumberToText(_number % 100);


            }
            else if (_number >= 200 && _number <= 299)
            {

                return "Tow Hundred" + " " + NumberToText(_number % 100);


            }
            else if (_number >= 300 && _number <= 999)
            {

                return  NumberToText(_number % 100)+ "  Hunderds"  ;


            }
            return " This Number Out Range";

        }
        public void ReadNumber()
        {
            
            Console.WriteLine("     Please enter The Number From 1- 200:> ");
            _number = int.Parse(Console.ReadLine());
        }
        public void Print()
        {
            ReadNumber();
            Console.WriteLine(NumberToText(_number));



        }
    }
   


   
}
