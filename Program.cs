using System;
using System.Collections.Generic;
using System.Data;

namespace Bussiness_Layer
{
    internal class Program
    {
        public enum enEvaluate { High = 0, Meduem = 1, Low = 2 };

        private struct stEmployeesInfo
        {
            public string Name { get; set; }
            public string Department { get; set; }
            public double Salary { get; set; }
            public double Bonus { get; set; }

            public int Performance { get; set; }

            public enEvaluate Evaluate { get; set; }
        }

        private static void Main(string[] args)
        {
            List<stEmployeesInfo> ListofEmployee = new List<stEmployeesInfo>();

            // افترض أن clsEmployees2.GetAllEmployees2() موجود ويعيد DataTable مناسب
            DataTable AllEmployee = clsEmployees2.GetAllEmployees2();
            foreach (DataRow raw in AllEmployee.Rows)
            {
                stEmployeesInfo stEmployeesInfo = new stEmployeesInfo
                {
                    Name = raw["Name"].ToString(),
                    Performance = Convert.ToInt32(raw["PerformanceRating"]),
                    Salary = Convert.ToDouble(raw["Salary"]),
                    Department = raw["Department"].ToString()
                };

                ListofEmployee.Add(stEmployeesInfo);
            }

            for (int i = 0; i < ListofEmployee.Count; i++)
            {
                stEmployeesInfo employee = ListofEmployee[i];  // استخراج العنصر


                if (employee.Performance < 100 && employee.Performance > 80)
                {
                    employee.Evaluate = enEvaluate.High;
                }
                if (employee.Performance < 80 && employee.Performance > 60)
                {
                    employee.Evaluate = enEvaluate.Meduem;
                }
                if (employee.Performance < 60 && employee.Performance > 0)
                {
                    employee.Evaluate = enEvaluate.Low;

                }



                ListofEmployee[i] = employee;  // إعادة تعيين العنصر المعدل إلى القائمة
            }



            int HighCount = 0;
            int MedumCount = 0;
            int LowCount = 0;


            for (int i = 0; i < ListofEmployee.Count; i++)
            {

                switch (ListofEmployee[i].Evaluate)
                {
                    case enEvaluate.High:
                        {
                            HighCount++;
                            break;
                        }
                    case enEvaluate.Meduem:
                        {
                            MedumCount++;
                            break;
                        }
                    case enEvaluate.Low:
                        {
                            LowCount++;
                            break;

                        }
 
                }
            }
            Console.WriteLine("The number of high is : " + HighCount);
            Console.WriteLine("The number of Medum is : " + MedumCount);
            Console.WriteLine("The number of Low is : " + LowCount);

        }
    }
}
