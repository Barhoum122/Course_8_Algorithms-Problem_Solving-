using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToText
{
    public class houre_Munite_second
    {
        short Yeare = 0;
        short Month =0e;
      
        public void ReadNumber()
        {
            Console.WriteLine(" Please Enter The Year To Cheak :> ");
            Yeare = short.Parse(Console.ReadLine()!);
            Console.WriteLine(" Please Enter The Month To Cheak :> ");
            Month = short.Parse(Console.ReadLine()!);
        }
        public void Print()
        {
            string result = IsleadYeare(Yeare) ? " This Year Is Lead" : " This Year Is Not Lead";
            Console.WriteLine(result + ":" + Yeare + " Number Of Day Of Years Is :" + NumberOfDayOfYeare(Yeare));
            Console.WriteLine( " Number Of Day Of Month Is :" + NumberOfDayOfMonth(Month ,Yeare ));
            Console.WriteLine(" The huores  in this Year is: " + Yeare + " :" + NumberOfHoure(Yeare));
            Console.WriteLine(" The munites in this Year is: " + Yeare + " :" + NumberOfDayOfMunites(Yeare));
            Console.WriteLine(" The Seconds in this Year is: " + Yeare + " :" + NumberOfDayOfSeconds(Yeare));

        }
        bool IsleadYeare(short Yeare)
        {
            return (Yeare % 4 == 0 && Yeare % 100 != 0) || (Yeare % 400 == 0);
        }
        short NumberOfDayOfMonth(short Month, short Yeare)
        {
            if (Month <= 0 || Month > 12) return 0;
            int [] days = { 31, 28, 31, 30, 31, 30, 31, 30, 31, 30, 31, 30 };
            return (short)((Month == 2) ? (IsleadYeare(Yeare) ? 29 : 28) : days[Month - 1]); 

        }
         short NumberOfDayOfYeare(short Yeare)
        {
            return (short)(IsleadYeare(Yeare) ? 366 :365);
        }
        short NumberOfHoure(short Yeare)
        {
            return (short)(NumberOfDayOfYeare(Yeare) * 24);
        }
        int NumberOfDayOfMunites(short Yeare)
        {
            return NumberOfHoure(Yeare) * 60;
        }
        int NumberOfDayOfSeconds(short Yeare)
        {
            return NumberOfDayOfMunites(Yeare) * 60;
        }

       


    }
}
