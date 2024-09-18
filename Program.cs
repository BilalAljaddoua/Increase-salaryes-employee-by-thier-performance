using System;
using System.Collections.Generic;
using System.Data;

namespace Bussiness_Layer
{
    internal class Program
    {
        private struct stEmployeesInfo
        {
            public string Name { get; set; }
            public string Department { get; set; }
            public double Salary { get; set; }
            public double Bonus { get; set; }

            public int Performance { get; set; }


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
                switch (employee.Department)
                {
                    case "IT":      
                        {
                            if (employee.Performance < 90 && employee.Performance > 0)
                            {
                                employee.Bonus = employee.Salary * 1.15;
                            }
                            if (employee.Performance < 75 && employee.Performance > 0)
                            {
                                employee.Bonus = employee.Salary * 1.1;
                            }
                            if (employee.Performance < 60 && employee.Performance > 0)
                            {
                                employee.Bonus = employee.Salary * 1.05;
                            }
                            break;
                        }
                    case "HR":
                            {

                            if (employee.Performance < 90 && employee.Performance > 0)
                            {
                                employee.Bonus = employee.Salary * 1.12;
                            }
                            if (employee.Performance < 75 && employee.Performance > 0)
                            {
                                employee.Bonus = employee.Salary * 0.8;
                            }
                            if (employee.Performance < 60 && employee.Performance > 0)
                            {
                                employee.Bonus = employee.Salary * 0.5;
                            }
                            break;
                        }
                    case "Marketing":
                        {

                            if (employee.Performance < 90 && employee.Performance > 0)
                            {
                                employee.Bonus = employee.Salary * 1.1 ;
                            }
                            if (employee.Performance < 75 && employee.Performance > 0)
                            {
                                employee.Bonus = employee.Salary * 0.6;
                            }
                            if (employee.Performance < 60 && employee.Performance > 0)
                            {
                                employee.Bonus = employee.Salary * 0.3;
                            }
                            break;
                        }
                }
                ListofEmployee[i] = employee;  // إعادة تعيين العنصر المعدل إلى القائمة
            }




            int count = 0;
            for (int i = 0; i < ListofEmployee.Count; i++)
            {
                clsEmployees2 employee=new clsEmployees2 ();
                employee.Name = ListofEmployee[i].Name;
                employee.Department = ListofEmployee[i].Department;
                employee.Salary = ListofEmployee[i].Salary;
                employee.PerformanceRating = ListofEmployee[i].Performance;
                employee.Bonus = ListofEmployee[i].Bonus;
                if(employee.Save())
                {
                    count++;
                }

            }
            Console.WriteLine($"there are {count} updates successfully");
        }
    }
}
