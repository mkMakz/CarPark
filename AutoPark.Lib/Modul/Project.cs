using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AutoPark.Lib.Modul
{
    public class Project
    {
        public string ProjectName { get; set; }
        public List<Car> cars = new List<Car>();

        public void PrintInfo()
        {
            Console.WriteLine("\t\t Project: {0}", ProjectName);
            foreach (Car item in cars)
            {
                item.PrintInfo();
                Console.WriteLine();
            }
        }
    }
}