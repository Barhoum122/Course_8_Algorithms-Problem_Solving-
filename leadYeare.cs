using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToText
{
    internal class leadYeare
    {

        private int _number = 0;


        public String ISLeadYeare(int _number)
        {
            if (_number % 400== 0)
            {
                return "Yes:";
            }
           else if (_number % 100 == 0)
            {
                return "No:";
            }
           else if (_number % 4 == 0)
            {
                return "Yes:";
            }
            else { return "No:"; }

           /* return " lll_No:";*/

        }
        public void ReadNumber()
        {

            Console.WriteLine("     Please enter the Number To Cheak The Yeare is Lead:> ");
            _number = int.Parse(Console.ReadLine());
        }
        public void Print()
        {
            ReadNumber();
            Console.WriteLine(ISLeadYeare(_number));



        }
    }


}
