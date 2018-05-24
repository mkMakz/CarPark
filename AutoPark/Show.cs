using AutoPark.Lib;
using AutoPark.Lib.Generator;
using AutoPark.Lib.Modul;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark
{
    public class Show
    {
        public void ShowInfo()
        {
            Generator gen = new Generator();

            List<Project> projects = null;

            string message;

            if (!gen.GenerateProject(ref projects, out message))
            {
                Console.WriteLine(message);
                return;
            }

            foreach (Project item in projects)
            {
                item.PrintInfo();
            }
            Console.WriteLine();

            Console.WriteLine("Choose project: ");
            foreach (var item in projects)
                Console.WriteLine(" - " + item.ProjectName);

            Project temp = null;
            do
            {
                Console.WriteLine();
                string name = Console.ReadLine();

                temp = projects.FirstOrDefault(o => o.ProjectName.ToLower() == name.ToLower());

                if (temp != null)
                    break;

                Console.WriteLine("Проект не найден!");
            }
            while (temp == null);

            Console.WriteLine("Выберите критерии поиска: 1 - гаражный номер, 2 - модель");

            int choise = 0;
            do
            {
                Console.Write("-> ");
                Int32.TryParse(Console.ReadLine(), out choise);

            } while (choise != 1 && choise != 2);

            Service service = new Service();

            int GosNomer;
            Car findCar = null;

            switch (choise)
            {
                case 1:
                    {
                        
                        Console.Write("Enter gos number: ");
                        Int32.TryParse(Console.ReadLine(), out GosNomer);
                        findCar = service.Search(temp, GosNomer);
                    }
                    break;
                case 2:
                    {
                       
                        Console.Write("Enter car model: ");
                        findCar = service.Search(temp, Console.ReadLine());
                    }
                    break;
            }

            if (findCar == null)
                Console.WriteLine("The car wasn't found");
            else
                findCar.PrintInfo();

            Console.WriteLine();
            Console.WriteLine("Change car status: 1 - Active, 2 - Inactive");
            do
            {
              
                Int32.TryParse(Console.ReadLine(), out choise);

            } while (choise != 1 && choise != 2);

            if (choise == 1)
            {
                projects.First(t => t == temp).cars.First(o => o == findCar).CarStatus = Status.Activ;
            }
            else if (choise == 2)
            {
                projects.First(t => t == temp).cars.First(o => o == findCar).CarStatus = Status.Inactiv;
            }
            
            foreach (Project item in projects)
            {
                item.PrintInfo();
            }
        }
    }
}