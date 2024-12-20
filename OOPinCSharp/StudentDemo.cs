using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPinCSharp
{
    public class StudentDemo
    {
        public int[] CreHr { get; set; }
        public int[] Marks { get; set; }
        public decimal CalculateGPa()
        {
            decimal[] gps = new decimal[CreHr.Length];
            char[] grades= new char[CreHr.Length];
            decimal gpSum = 0.0M;
            int CrhrSum = 0;
            for(int i = 0; i < Marks.Length; i++)
            {
                grades[i] = this.CalculateGrade(Marks[i]);
                gps[i] = this.CalculateGradePoint(grades[i]) * CreHr[i];
                gpSum = gpSum + gps[i];
                CrhrSum = CrhrSum + CreHr[i];
            }
            return gpSum / CrhrSum;
        }
        private decimal CalculateGradePoint(char grade)
        {
            if(grade =='A')
            {
                return 4.0M;
            }
            else if(grade =='B')
            {
                return 3.0M;
            }
            else if (grade == 'C')
            {
                return 2.0M;
            }
            else if (grade == 'D')
            {
                return 1.0M;
            }
            else
            {
                return 0.0M;
            }
        }
        private char CalculateGrade(int mark)
        {
            char result = ' ';
            if(mark>90)
            {
                result = 'A';
            }
            else if (mark>70)
            {
                result = 'B';
            }
            else if (mark > 50)
            {
                result = 'C';
            }
            else if (mark > 40)
            {
                result = 'D';
            }
            else
            {
                result = 'F';
            }
            return result;

        }
        public static void Main10()
        {
            StudentDemo s1 = new StudentDemo();
            s1.CreHr = new int[6];
            s1.CreHr = [3, 2, 3, 4, 3,4];
            s1.Marks = [87, 87, 87, 87, 87, 89];
            var studentGpa = s1.CalculateGPa();
            Console.WriteLine(studentGpa);
        }
    }
   
}
