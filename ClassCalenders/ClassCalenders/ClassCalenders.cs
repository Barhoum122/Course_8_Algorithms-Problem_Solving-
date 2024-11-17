using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassCalenders
{
    internal class ClassCalender
    {
        public struct _structDate
        {
            public short Year = 0;
            public short Month = 0;
            public short Day = 0;
        }

        struct _StructPeriodType
        {

            public _structDate StartDate;
            public _structDate EndDate;
        }



        short Year = 0;
        short Month = 0;
        short day = 0;
        public string alert = "alert";

        public void ReadNumber()
        {
            Console.WriteLine(" Please Enter The Year To Cheak :> ");
            Year = short.Parse(Console.ReadLine()!);
            Console.WriteLine(" Please Enter The Month To Cheak :> ");
            Month = short.Parse(Console.ReadLine()!);
            Console.WriteLine(" Please Enter The day To Cheak :> ");
            day = short.Parse(Console.ReadLine()!);
        }
        short Read(String alert)
        {
            Console.Write(alert);
            short read = short.Parse(Console.ReadLine()!);
            return read;

        }
        short ReadYear()
        {
            Console.Write(" Please Enter The Year  To Cheak  :> ");
            short Year = short.Parse(Console.ReadLine()!);
            return Year;

        }
        short ReadMonth()
        {
            Console.Write(" Please Enter The Month To Cheak  :> ");
            short Month = short.Parse(Console.ReadLine()!);
            return Month;
        }
        short ReadDay()
        {
            Console.Write("\n Please Enter The day   To Cheak  :> ");
            short day = short.Parse(Console.ReadLine()!);
            return day;
        }
        short ReadMoreAddDays()
        {
            Console.WriteLine(" Please Enter The days To Added to Date :> ");
            short AddDays = short.Parse(Console.ReadLine()!);
            return AddDays;
        }
        _structDate ReadFullDate1()

        {
            _structDate Date = new _structDate();
            Date.Year = Read(alert);
            Date.Month = Read(alert);
            Date.Day = Read(alert);
            return Date;

        }
        _structDate ReadFullDate()
        {
            _structDate Date = new _structDate();
            Date.Day = ReadDay();
            Date.Month = ReadMonth();
            Date.Year = ReadYear();
            return Date;

        }
        _StructPeriodType ReadPeriod()
        {
            _StructPeriodType _StructPeriod;
            Console.WriteLine(" Enter Start date _Period : ");
            _StructPeriod.StartDate = ReadFullDate();
            Console.WriteLine("\n Enter End date _Period : ");
            _StructPeriod.EndDate = ReadFullDate();
            return _StructPeriod;

        }




        /// My labrary
        short dayOfWeekOrder(short day, short Month, short Year)
        {
            short a, m, y;
            a = (short)((14 - Month) / 12);
            y = (short)(Year - a);
            m = (short)(Month + (12 * a) - 2);
            return (short)((day + y + (y / 4) - (y / 100) + (y / 400) + ((31 * m) / 12)) % 7);
        }
        short dayOfWeekOrder(_structDate date)
        {
            return dayOfWeekOrder(date);
        }
        void Swapdates(ref _structDate date1, ref _structDate date2)
        {
            _structDate Tempdate;

            Tempdate.Year = date1.Year;
            Tempdate.Month = date1.Month;
            Tempdate.Day = date1.Day;

            date1.Year = date2.Year;
            date1.Month = date2.Month;
            date1.Day = date2.Day;

            date2.Year = Tempdate.Year;
            date2.Month = Tempdate.Month;
            date2.Day = Tempdate.Day;


        }
        String NameOfMonths(short Month)
        {

            String[] Months = { "January", "February", "March", "Apr", "May", "June", "July", "August", "Sep", "Oct", "Nov", "Dec" };

            return (Months[Month - 1]);
        }
        String NameOfDays(short Day)
        {

            String[] Days = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

            return (Days[Day]);
        }
        bool IsleadYeare(short Year)
        {
            return (Year % 4 == 0 && Year % 100 != 0) || (Year % 400 == 0);
        }


        int GetDeffrenceInDay(_structDate date1, _structDate date2, bool includingDay = false)
        {
            /*short RemainingDays1 = NumbersOfDaysFromBeginingOfTheYear(date1);
            int RemainingDays2 = NumbersOfDaysFromBeginingOfTheYear(date2);
            int res = RemainingDays2 -= RemainingDays1;
            return res;*/

            int Days = 0;
            short Swapdateflage = 1;
            if (!IsDate1LessThanData2(date1, date2))
            {
                //Swapdates
                Swapdates(ref date1, ref date2);//This fun Swaping the data1 ,date2
                Swapdateflage = -1;
            }
            while (IsDate1LessThanData2(date1, date2))
            {
                Days++;
                date1 = (IncressDateOneDay(date1));

            }
            return includingDay ? ++Days * Swapdateflage : Days * Swapdateflage;

        }
        _structDate IncressDateOneDay(_structDate date)
        {
            if (IsLastDayInMonth(date))//if True exe next line
            {
                if (IsLastMonthInYear(date.Month)) // if True exe next line
                {
                    date.Month = 1;
                    date.Day = 1;
                    date.Year++;
                }
                else  // if false exe next line
                {
                    date.Day = 1;
                    date.Month++;
                }

            } // if false exe next line
            else
            {
                date.Day++;
            }
            return date;
        }
        bool IsLastDayInMonth(_structDate date)
        {
            return (date.Day == NumberOfDayInMonth(date.Month, date.Year));

        }
        bool IsLastMonthInYear(short Month)
        {
            return (Month == 12);
        }
        bool IsDate1LessThanData2(_structDate date1, _structDate date2)
        {
            /* short _date1 = NumbersOfDaysFromBeginingOfTheYear(date1);
             short _date2 = NumbersOfDaysFromBeginingOfTheYear(date2);
             if (_date1 < _date2 && _date1 != _date2) 
                 return true; 
             else 
                 return false;*/

            return (date1.Year < date2.Year) ? true
                : ((date1.Year == date2.Year) ? (date1.Month < date2.Month ? true : (date1.Month == date2.Month ? date1.Day < date2.Day : false)) : false);


        }
        bool IsDate1GreaterThanData2(_structDate date1, _structDate date2)
        {
            return (!IsDate1LessThanData2(date1, date2) && !IsDate1quailData2(date1, date2));
        }
        bool IsDate1quailData2(_structDate date1, _structDate date2)
        {

            return (date1.Year == date2.Year) ? ((date1.Month == date2.Month) ? ((date1.Day == date2.Day) ? true : false) : false) : false;
        }
        _structDate AddNumberOfDays(short AddDays, _structDate date)
        {
            short RemainingDays = (short)(AddDays + NumbersOfDaysFromBeginingOfTheYear(date));
            //  short MonthDate = 0;
            /* _structDate date = new _structDate();*/
            /* date.Year = Year;*/
            date.Month = 1;
            while (true)
            {
                short MonthDate = NumberOfDayInMonth(date.Month, date.Year);//30
                if (RemainingDays > MonthDate)
                {
                    RemainingDays -= MonthDate;
                    date.Month++;
                    if (date.Month > 12)
                    {
                        date.Year++;
                        date.Month = 1;
                    }
                }
                else
                {
                    date.Day = RemainingDays;
                    break;
                }
            }

            return date;
        }
        short NumberOfDayInMonth(short Month, short Year)
        {
            if (Month < 1 || Month > 12)
                return 0;

            int[] days = { 31, 28, 31, 30, 31, 30, 31, 30, 31, 30, 31, 30 };
            return (short)((Month == 2) ? (IsleadYeare(Year) ? 29 : 28) : days[Month - 1]);

        }
        short NumbersOfDaysFromBeginingOfTheYear(_structDate date)
        {
            short totalDaysOfTheYear = 0;
            for (short i = 1; i <= date.Month - 1; i++)
            {
                totalDaysOfTheYear += NumberOfDayInMonth(i, date.Year);
            }
            totalDaysOfTheYear += date.Day;
            return totalDaysOfTheYear;

        }
        _structDate getDatefromNumberOfDayInMonth(short totalDaysOfTheYear, short Year)
        {
            short RemainingDays = totalDaysOfTheYear;
            //  short MonthDate = 0;
            _structDate date = new _structDate();
            date.Year = Year;
            date.Month = 1;
            while (true)
            {
                short MonthDate = NumberOfDayInMonth(date.Month, Year);
                if (RemainingDays > MonthDate)
                {
                    RemainingDays -= MonthDate;
                    date.Month++;
                }
                else
                {
                    date.Day = RemainingDays;
                    break;
                }


            }

            return date;
        }
        bool IsWeekEnd(_structDate dateFrom)
        {
            short DayIndex = dayOfWeekOrder(dateFrom.Day, dateFrom.Month, dateFrom.Year);
            return DayIndex == 5 || DayIndex == 6;

        }
        short CalculateVacationPeriod(_structDate dateFrom, _structDate dateTo)
        {
            short daysCont = 0;
            while (IsDate1LessThanData2(dateFrom, dateTo))
            {
                if (!IsWeekEnd(dateFrom))
                    daysCont++;

                dateFrom = IncressDateOneDay(dateFrom);
            }
            return daysCont;
        }
        _structDate CalculateVacationPeriodDay(_structDate dateFrom, short VacationDay)
        {
            short WeekEndCounter = 0;
            while (IsWeekEnd(dateFrom))
            {
                dateFrom = IncressDateOneDay(dateFrom);
            }

            for (int i = 1; i <= VacationDay + WeekEndCounter; i++)
            {
                if (IsWeekEnd(dateFrom))
                    WeekEndCounter++;

                dateFrom = IncressDateOneDay(dateFrom);
            }
            while (IsWeekEnd(dateFrom))
            {
                dateFrom = IncressDateOneDay(dateFrom);
            }

            return dateFrom;
        }
        enum enDataCompare
        {
            Greater = 1,  //after
            Less = -1,   // before
            Quail = 0,

        };
        enDataCompare DataCompare(_structDate date1, _structDate date2)
        {
            if (IsDate1LessThanData2(date1, date2))
                return enDataCompare.Less;

            if (IsDate1quailData2(date1, date2))
                return enDataCompare.Quail;

            return enDataCompare.Greater;

        }
        bool OverlapPeriods(_StructPeriodType _StructPeriod1, _StructPeriodType _StructPeriod2)
        {
            if (
                 DataCompare(_StructPeriod2.EndDate, _StructPeriod1.StartDate) == enDataCompare.Less
                || DataCompare(_StructPeriod2.StartDate, _StructPeriod1.EndDate) == enDataCompare.Greater
                )
                return false;
            else
                return true;
        }
        bool IsDateInPeriods(_StructPeriodType _StructPeriod, _structDate date)
        {

            return !(DataCompare(date, _StructPeriod.StartDate) == enDataCompare.Less
                || DataCompare(date, _StructPeriod.EndDate) == enDataCompare.Greater);


        }

        int PeriodLengthInDays(_StructPeriodType _StructPeriod, bool Including = false)
        {
            return GetDeffrenceInDay(_StructPeriod.StartDate, _StructPeriod.EndDate, Including);
        }

        int CounOverlapPeriodDays(_StructPeriodType _StructPeriod1, _StructPeriodType _StructPeriod2)
        {
            int _countPeriodLength1 = PeriodLengthInDays(_StructPeriod1, true);
            int _countPeriodLength2 = PeriodLengthInDays(_StructPeriod2, true);
            int _overlabDays = 0;
            if (!OverlapPeriods(_StructPeriod1, _StructPeriod2))
                return 0;

            if (_countPeriodLength1 < _countPeriodLength2)
            {
                while (IsDate1LessThanData2(_StructPeriod1.StartDate, _StructPeriod1.EndDate))
                {
                    if (IsDateInPeriods(_StructPeriod2, _StructPeriod1.StartDate))
                        _overlabDays++;
                    _StructPeriod1.StartDate = IncressDateOneDay(_StructPeriod1.StartDate);
                }
            }
            else
            {
                while (IsDate1LessThanData2(_StructPeriod2.StartDate, _StructPeriod2.EndDate))
                {
                    if (IsDateInPeriods(_StructPeriod1, _StructPeriod2.StartDate))
                        _overlabDays++;
                    _StructPeriod2.StartDate = IncressDateOneDay(_StructPeriod2.StartDate);
                }
            }
            return _overlabDays;

        }
        bool IsValideDate(_structDate date)
        {
            if (date.Day < 1 || date.Day > 31)
                return false;

            if (date.Month < 1 || date.Month > 12)
                return false;
            if (date.Month == 2)
            {

                if (IsleadYeare(date.Year))
                {
                    if (date.Day > 29)
                        return false;

                }
                else
                {
                    if (date.Day > 28)
                        return false;
                }
            }

            short daysInMonth = NumberOfDayInMonth(date.Month, date.Month);

            if (date.Day > daysInMonth)
                return false;


            return true;

        }

        _structDate StringToData(string dateString)
        {
            _structDate date;
            string[] vdate;
            char[] charArray={'/','-','.'};
            vdate = dateString.Split(charArray);

            date.Day = short.Parse(vdate[0]);
            date.Month = short.Parse(vdate[1]);
            date.Year = short.Parse(vdate[2]);
            return date;

        }
        string DataToString(_structDate date)
        {
            return date.Day + "/" + date.Month + "/" + date.Year;

        }
        string ReplaceWordInString(string _input,string _stringToReplace, string _replaceTo)
        {
            int pos=_input.IndexOf(_stringToReplace);//find string area while replaced
            while(pos != -1)
            {
                _input = _input.Remove(pos, _stringToReplace.Length).Insert(pos,_replaceTo);//deleted old string,and replaced with new string
                
                pos = _input.IndexOf(_stringToReplace,pos +_replaceTo.Length);
            }
            return _input;

        }
        string FormatDate(_structDate Date,string DateFormat = "dd/mm/yyyy")
        {

            string FormatDateString = "";
            FormatDateString = ReplaceWordInString(DateFormat,"dd",Date.Day.ToString());
            FormatDateString = ReplaceWordInString(FormatDateString, "mm",Date.Month.ToString());
            FormatDateString = ReplaceWordInString(FormatDateString, "yyyy",Date.Year.ToString());
            return FormatDateString;

        }


        //Proplems-(8)Print a Month______________________________________
        public void ExecutingProplem8PrintMonthCalender(short Month, short Year)
        {
            short _Current = dayOfWeekOrder(1, Month, Year);
            short _NumberOfDayOfMonth = NumberOfDayInMonth(Month, Year);
            Console.WriteLine("  ______________[ " + NameOfMonths(Month) + " ]_____________ \n");
            Console.WriteLine("   Sun  Mon  Tue  Wed  Thu  Fri  Sat\n");
            int i;
            for (i = 0; i < _Current; i++)

                Console.Write($"{"",5}");
            for (int j = 1; j <= _NumberOfDayOfMonth; j++)
            {
                Console.Write($"{j,5}");
                if (++i == 7)
                {
                    i = 0;
                    Console.WriteLine("\n");
                }
            }
            Console.WriteLine("\n  __________________________________");

        }
        //Proplems-(9)Print All Months Calender In Year______________________________________
        public void ExecutingProplem9PrintAllCalenders(short Year)
        {

            Console.WriteLine("  _____________________________________________________________________ \n");
            Console.WriteLine("                Calenders In This Year[ " + Year + " ]\n");
            Console.WriteLine("  _____________________________________________________________________ \n\n");

            for (short i = 1; i <= 12; i++)
            {
                ExecutingProplem8PrintMonthCalender(i, Year);
                Console.WriteLine("\n");
            }

        }
        //Proplems-10______________________________________

        /*short NumbersOfDaysFromBeginingOfTheYear(short day, short Month, short Yeare)
        {
            short totalDaysOfTheYear = 0;
            for (short i = 1; i <= Month - 1; i++)
            {
                totalDaysOfTheYear += NumberOfDayInMonth(i, Yeare);
            }
            totalDaysOfTheYear += day;
            return totalDaysOfTheYear;

        }*/
        //Proplems-11______________________________________
        public void ExecutingProplem11()
        {

            _structDate date = ReadFullDate();
            short totalDaysOfTheYear = NumbersOfDaysFromBeginingOfTheYear(date);

            date = getDatefromNumberOfDayInMonth(totalDaysOfTheYear, date.Year);
            Console.WriteLine("Number Of Days From Begining Of The Year: " + totalDaysOfTheYear);
            Console.WriteLine("date Format : " + date.Day + "/" + date.Month + "/" + date.Year);

        }

        //Proplems-12____________________________________________________________________________
        public void ExecutingProplem12()
        {
            _structDate date = ReadFullDate();
            short DaysToAdd = ReadMoreAddDays();
            date = AddNumberOfDays(DaysToAdd, date);
            Console.WriteLine("date Format : " + date.Day + "/" + date.Month + "/" + date.Year);

        }
        //Proplems-13____________________________________________________________________________
        public void ExecutingProplem13()
        {
            /* _structDate date1 = ReadFullDate();
             Console.WriteLine("date 1 : " + date1.Day + "/" + date1.Month + "/" + date1.Year);
             _structDate date2 = ReadFullDate();
             Console.WriteLine("date 2 : " + date2.Day + "/" + date2.Month + "/" + date2.Year);

             Console.WriteLine(IsDate1LessThanData2(date1, date2));


             if (IsDate1LessThanData2(date1, date2)) Console.WriteLine("Yes,Date1 Is Less Than Date2");
             else Console.WriteLine("No,Date 1 is Not Less Than Date 2");*/


            _structDate date1 = ReadFullDate();
            Console.WriteLine("date 1 : " + date1.Day + "/" + date1.Month + "/" + date1.Year);
            _structDate date2 = ReadFullDate();
            Console.WriteLine("date 2 : " + date2.Day + "/" + date2.Month + "/" + date2.Year);

            Console.WriteLine(IsDate1GreaterThanData2(date1, date2));


            if (IsDate1GreaterThanData2(date1, date2)) Console.WriteLine("Yes,Date1 Is Greater Than Date2");
            else Console.WriteLine("No,Date 1 is Not Greater Than Date 2");




        }

        //Proplems-14____________________________________________________________________________
        public void ExecutingProplem14()
        {
            _structDate date1 = ReadFullDate();
            Console.WriteLine("date 1 : " + date1.Day + "/" + date1.Month + "/" + date1.Year);
            _structDate date2 = ReadFullDate();
            Console.WriteLine("date 2 : " + date2.Day + "/" + date2.Month + "/" + date2.Year);

            Console.WriteLine(IsDate1LessThanData2(date1, date2));
            if (IsDate1quailData2(date1, date2)) Console.WriteLine("Yes,Date1 Is =  Date2");
            else Console.WriteLine("No,Date 1 is Not =  Date 2");

        }

        //Proplems-15____________________________________________________________________________
        public void ExecutingProplem15()
        {
            _structDate date = ReadFullDate();

            if (IsLastMonthInYear(date.Month)) Console.WriteLine("Yes,Is Last Month In Year:" + date.Month);
            else Console.WriteLine("No,Is not Last Month In Year:" + date.Month);

            if (IsLastDayInMonth(date)) Console.WriteLine("Yes,Is Last Day In Month:" + date.Day);
            else Console.WriteLine("No,Is not Last Day In Month:" + date.Day);

        }

        //Proplems-16____________________________________________________________________________
        public void ExecutingProplem16()
        {
            _structDate date = ReadFullDate();

            _structDate Result = IncressDateOneDay(date);
            Console.WriteLine("Incresse a Day:" + Result.Day + "/" + Result.Month + "/" + Result.Year);

        }

        //Proplems-17____________________________________________________________________________
        public void ExecutingProplem17()
        {
            _structDate date1 = ReadFullDate();
            _structDate date2 = ReadFullDate();
            int Result = GetDeffrenceInDay(date1, date2);
            int Result2 = GetDeffrenceInDay(date1, date2, true);
            if (IsDate1quailData2(date1, date2))
                Console.WriteLine("\n Deffrence without including a Day:" + Result);
            else
                Console.WriteLine("\n Deffrence without including a Day:" + Result);
            Console.WriteLine("\n Deffrence with including a Day:" + Result2);

        }



        //Proplems-20-30____________________________________________________________________
        _structDate IncressDateByXDays(short addDate, _structDate date)
        {

            _structDate _date = AddNumberOfDays(addDate, date);

            return _date;
        }
        _structDate IncressDateByOneWeek(short addOneWeek, _structDate date)
        {

            _structDate _date = IncressDateByXDays(addOneWeek, date);

            return _date;
        }
        _structDate IncressDateByOneMonth(_structDate date)
        {

            /* _structDate date = IncressDateByXDays(addOneWeek, Resultdate);*/
            if (date.Month == 12)
            {
                date.Month = 1;
                date.Year++;

            }
            else
            {
                date.Month++;
            }
            short NumberOfDayInCurrentMonth = NumberOfDayInMonth(date.Month, date.Year);
            if (date.Day > NumberOfDayInCurrentMonth)
            {
                date.Day = NumberOfDayInCurrentMonth;
            }
            return date;

        }
        _structDate IncressDateByXMonth(short Month, _structDate date)
        {

            for (short i = 1; i < Month; i++)
            {
                date.Month++;
            }
            return date;

        }
        _structDate IncressDateByOneYeare(_structDate date)
        {

            date.Year++;
            return date;

        }
        _structDate IncressDateByXYear(short Year, _structDate date)
        {

            for (short i = 1; i < Year; i++)
            {
                date.Year++;
            }
            return date;

        }
        public void ExecutingProplem20_30()
        {
            _structDate _date = ReadFullDate();

            _structDate Result = IncressDateOneDay(_date);

            Console.WriteLine("\nIncresse One Day          :" + Result.Day + "/" + Result.Month + "/" + Result.Year);

            _structDate incressDateByXDay = IncressDateByXDays(10, Result);
            Console.WriteLine("Incresse 10 Days          :" + incressDateByXDay.Day + "/" + incressDateByXDay.Month + "/" + incressDateByXDay.Year);

            _structDate _IncressDateByOneWeek = IncressDateByOneWeek(7, incressDateByXDay);
            Console.WriteLine("Incresse one Week        :" + _IncressDateByOneWeek.Day + "/" + _IncressDateByOneWeek.Month + "/" + _IncressDateByOneWeek.Year);

            _structDate _IncressDateByOneMonth = IncressDateByOneMonth(_IncressDateByOneWeek);
            Console.WriteLine("Incresse Date By One Month:" + _IncressDateByOneMonth.Day + "/" + _IncressDateByOneMonth.Month + "/" + _IncressDateByOneMonth.Year);

            _structDate _IncressDateByXMonth = IncressDateByXMonth(5, _IncressDateByOneMonth);
            Console.WriteLine("Incresse Date By X Month  :" + _IncressDateByXMonth.Day + "/" + _IncressDateByXMonth.Month + "/" + _IncressDateByXMonth.Year);
            _structDate _IncressDateByOneYeare = IncressDateByOneYeare(_IncressDateByXMonth);
            Console.WriteLine("Incresse Date By One Year :" + _IncressDateByOneYeare.Day + "/" + _IncressDateByOneYeare.Month + "/" + _IncressDateByOneYeare.Year);

            _structDate _IncressDateByXYear = IncressDateByXYear(5, _IncressDateByOneYeare);
            Console.WriteLine("Incresse Date By X Year   :" + _IncressDateByXYear.Day + "/" + _IncressDateByXYear.Month + "/" + _IncressDateByXYear.Year);

        }



        //Proplems-33-46____________________________________________________________________
        _structDate DecressDateByOneDay(_structDate date)
        {
            if (date.Day == 1)//if True exe next line
            {
                if (date.Month == 1) // if True exe next line
                {
                    date.Month = 12;
                    date.Day = 31;
                    date.Year--;
                }
                else  // if false exe next line
                {
                    date.Month--;
      
                    date.Day = NumberOfDayInMonth(date.Month, date.Year);

                }

            } // if false exe next line
            else
            {
                date.Day--;
            }
            return date;
        }
        _structDate DecressDateByXDays(short addDate, _structDate date)
        {

            for (short i = 1; i <= addDate; i++)
            {
                date = DecressDateByOneDay(date);
            }

            return date;
        }
        _structDate DecressDateByOneWeek(short addOneWeek, _structDate date)
        {

            for (short i = 1; i <= addOneWeek; i++)
            {
                date = DecressDateByOneDay(date);
            }

            return date;


        }
        _structDate DecressDateByOneMonth(_structDate date)
        {

            //* _structDate date = IncressDateByXDays(addOneWeek, Resultdate);*//*
            if (date.Month == 1)//if True exe next line
            {
                date.Month = 12;
                date.Year--;
            }
            else  // if false exe next line
            {
                date.Month--;


            }

            short NumberOfDayInCurrentMonth = NumberOfDayInMonth(date.Month, date.Year);
            if (date.Day > NumberOfDayInCurrentMonth)
            {
                date.Day = NumberOfDayInCurrentMonth;
            }
            return date;
        }
        _structDate DecressDateByXMonth(short Month, _structDate date)
        {

            for (short i = 1; i < Month; i++)
            {
                date = DecressDateByOneMonth(date);
            }
            return date;


        }
        _structDate DecressDateByOneYeare(_structDate date)
        {

            date.Year--;
            return date;

        }
        _structDate DecressDateByXYear(short Year, _structDate date)
        {

            for (short i = 1; i < Year; i++)
            {
                date = DecressDateByOneYeare(date);
            }
            return date;

        }

        public void ExecutingProplem33_45()
        {
            _structDate _date = ReadFullDate();

            _structDate Result;
            Result = DecressDateByOneDay(_date);

            Console.WriteLine("\nDecresse Date By One Day  :          :" + Result.Day + "/" + Result.Month + "/" + Result.Year);

            Result = DecressDateByXDays(10, Result);
            Console.WriteLine("Decresse Date By 10  Days   :          :" + Result.Day + "/" + Result.Month + "/" + Result.Year);

            Result = DecressDateByOneWeek(7, Result);
            Console.WriteLine("Decresse Date By one Week  :         :" + Result.Day + "/" + Result.Month + "/" + Result.Year);
            Result = DecressDateByOneMonth(Result);
            Console.WriteLine("Decresse Date By One Month :        :" + Result.Day + "/" + Result.Month + "/" + Result.Year);

            Result = DecressDateByXMonth(10, Result);
            Console.WriteLine("Decresse Date By X10 Months:        :" + Result.Day + "/" + Result.Month + "/" + Result.Year);

            Result = DecressDateByOneYeare(Result);
            Console.WriteLine("Decresse Date By One Years :         :" + Result.Day + "/" + Result.Month + "/" + Result.Year);

            Result = DecressDateByXYear(5, Result);
            Console.WriteLine("Decresse Date By X5  Years  :          :" + Result.Day + "/" + Result.Month + "/" + Result.Year);

        }
        //Proplems-54____________________________________________________________________
        public void ExecutingProplem54()
        {
            /* Console.WriteLine(IsDate1LessThanData2(date1, date2));
             if (IsDate1quailData2(date1, date2)) Console.WriteLine("Yes,Date1 Is =  Date2");
             else Console.WriteLine("No,Date 1 is Not =  Date 2");*/
            Console.WriteLine("Vacation Starts   :");
            _structDate dateFrom = ReadFullDate();
            Console.WriteLine("Vacation Ends     :");
            _structDate dateTo = ReadFullDate();
            short day = dayOfWeekOrder(dateFrom.Day, dateFrom.Month, dateFrom.Year);
            short dayto = dayOfWeekOrder(dateTo.Day, dateTo.Month, dateTo.Year);
            /* Console.WriteLine("order day from    : "+dayOfWeekOrder(dateFrom.Day,dateFrom.Month,dateFrom.Year));
             Console.WriteLine("order day   to  : " +dayOfWeekOrder(dateTo.Day, dateTo.Month, dateTo.Year));*/
            Console.WriteLine("\nVacation Date From : " + NameOfDays(day) + " " + dateFrom.Day + "/" + dateFrom.Month + "/" + dateFrom.Year);
            Console.WriteLine("Vacation Date To   : " + NameOfDays(dayto) + " " + dateTo.Day + "/" + dateTo.Month + "/" + dateTo.Year);
            Console.WriteLine("Actucal Vacation Days is:" + CalculateVacationPeriod(dateFrom, dateTo));

        }

        //Proplems-55____________________________________________________________________
        public void ExecutingProplem55()
        {
            Console.WriteLine("Vacation Starts   :");
            _structDate dateFrom = ReadFullDate();
            Console.Write("\n Please Enter The days to return Date :> ");
            short VacationDay = short.Parse(Console.ReadLine()!);

            short day = dayOfWeekOrder(dateFrom.Day, dateFrom.Month, dateFrom.Year);
            _structDate Returndate = CalculateVacationPeriodDay(dateFrom, VacationDay);
            Console.WriteLine("\nVacation Date From : " + NameOfDays(day) + " " + dateFrom.Day + "/" + dateFrom.Month + "/" + dateFrom.Year);
            Console.WriteLine("\nActucal return Vacation Days is: " + " " + Returndate.Day + "/" + Returndate.Month + "/" + Returndate.Year);


        }
        //Proplems-57____________________________________________________________________________
        public void ExecutingProplem57()
        {
            _structDate date1 = ReadFullDate();
            Console.WriteLine("\nDate 1 : " + date1.Day + "/" + date1.Month + "/" + date1.Year);
            _structDate date2 = ReadFullDate();
            Console.WriteLine("\nDate 2 : " + date2.Day + "/" + date2.Month + "/" + date2.Year);

            Console.WriteLine("\nDataCompare by value: " + (short)DataCompare(date1, date2));
            Console.WriteLine("\nDataCompare by Names: " + DataCompare(date1, date2));

        }
        //Proplems-58____________________________________________________________________________
        public void ExecutingProplem58()
        {
            Console.WriteLine("\n Start _Period 1: ");
            _StructPeriodType period1 = ReadPeriod();
            Console.WriteLine("\n Start _Period 2: ");
            _StructPeriodType period2 = ReadPeriod();

            if (OverlapPeriods(period1, period2)) Console.WriteLine("\n Yes,Period is Overlap: ");
            else Console.WriteLine("\n No,Period is not Overlap: ");

            /* Console.WriteLine("End date _Period 2: " + period1.EndDate.Day + "/" + period1.EndDate.Month + "/" + period1.EndDate.Year);*/

        }
        //Proplems-59____________________________________________________________________________

        public void ExecutingProplem59()
        {
            Console.WriteLine("\n Start _Period 1: ");
            _StructPeriodType period = ReadPeriod();
            int Result = PeriodLengthInDays(period);
            int Result2 = PeriodLengthInDays(period, true);
            if (IsDate1quailData2(period.StartDate, period.EndDate))
                Console.WriteLine("\n Period Length In Days without including a Day:" + Result);
            else
                Console.WriteLine("\n Period Length In Days without including a Day:" + Result);
            Console.WriteLine("\n Period Length In Days with including a Day:" + Result2);

        }
        //Proplems-60____________________________________________________________________________

        public void ExecutingProplem60()
        {
            Console.WriteLine("\n Start _Period 1: ");
            _StructPeriodType period = ReadPeriod();
            Console.WriteLine("\n Enter Date To Cheake: ");
            _structDate date1 = ReadFullDate();

            if (IsDateInPeriods(period, date1)) Console.WriteLine("\n Yes,Within Period  : ");
            else Console.WriteLine("\n No,Without Period: ");


        }
        //Proplems-61____________________________________________________________________________
        public void ExecutingProplem61()
        {
            Console.WriteLine("\n Start _Period 1: ");
            _StructPeriodType period1 = ReadPeriod();
            Console.WriteLine("\n Start _Period 2: ");
            _StructPeriodType period2 = ReadPeriod();
            int Result = CounOverlapPeriodDays(period1, period2);
            if (OverlapPeriods(period1, period2)) Console.WriteLine("\n Yes,Period is Overlap: ");
            else Console.WriteLine("\n No,Period is not Overlap: ");
            Console.WriteLine("\n Period Length In Days with including a Day:" + Result);

            /* Console.WriteLine("End date _Period 2: " + period1.EndDate.Day + "/" + period1.EndDate.Month + "/" + period1.EndDate.Year);*/

        }

        //Proplems-62____________________________________________________________________________
        public void ExecutingProplem62()
        {
            Console.WriteLine("\n Enter To Valide Date: ");
            _structDate date = ReadFullDate();

            if (IsValideDate(date)) Console.WriteLine("\n Yes, Is Valide Date: ");
            else Console.WriteLine("\n No, Is Not Valide Date: ");

            /* Console.WriteLine("End date _Period 2: " + period1.EndDate.Day + "/" + period1.EndDate.Month + "/" + period1.EndDate.Year);*/

        }
        //Proplems-63-64____________________________________________________________________________
       
        public void ExecutingProplem63_64()
        {
                Console.Write("\n Enter The Date like This Format dd/mm/yy: ");
               string dateString = Console.ReadLine()!;

           _structDate Date = StringToData(dateString);
            Console.WriteLine("Day: " + Date.Day + "\nMonth: " + Date.Month + "\nYear: " + Date.Year);
           
            Console.Write("Date String: " + DataToString(Date));

        }
         //Proplems-65____________________________________________________________________________
       
        public void ExecutingProplem65()
        {
                Console.Write("\n Enter The Date like This Format dd/mm/yyyy: ");
               string dateString = Console.ReadLine()!;

           _structDate Date = StringToData(dateString);
            Console.WriteLine("Day: " + Date.Day + "\nMonth: " + Date.Month + "\nYear: " + Date.Year);
           
            Console.Write("\nFormat Date: " + FormatDate(Date));
            Console.Write("\nFormat Date: " + FormatDate(Date,"mm/dd/yyyy"));
            Console.Write("\nFormat Date: " + FormatDate(Date, "yyyy/mm/dd"));
          

        }


    }
}
