using AutoPark.Lib.Modul;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark.Lib.Generator
{
    public class Generator
    {
        private Random rand = new Random();

      
        public bool GenerateProject(ref List<Project> projects, out string message)
        {
            try
            {
                if(projects == null)

                projects = new List<Project>();
                projects.Add(new Project() { ProjectName = "Варваринский ГОК" });
                projects[0].cars = GenerCar(out message);

                projects.Add(new Project() { ProjectName = "Карагандинская шахта" });               
                projects[1].cars = GenerCar(out message);

                projects.Add(new Project() { ProjectName = "СС ГОК" });
                projects[2].cars = GenerCar(out message);

                message = "The project was added successfully!";
                    return true;
              
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        private List<Car> GenerCar(out string message)
        {
            List<Car> cars = new List<Car>();
            for (int i = 0; i < 5; i++)
            {
                Car car = new Car();
                car.GodVipuska = DateTime.Now.AddMonths((rand.Next(10, 200) * -1));
                car.GosNomer = rand.Next(1000, 9999);
                car.CarModel = "Model" + rand.Next(1, 10);
                car.CarType = (CarType)rand.Next(0, 4);
                car.CarStatus = Status.Activ;
                car.components = GenerComponent(out message);

                cars.Add(car);
            }
            message = "The car was added successfully!";
            return cars;
        }

        private List<Component> GenerComponent(out string message)
        {
            List<Component> components = new List<Component>();
            for (int i = 0; i < 3; i++)
            {
                Component component = new Component();
                component.ComponentId = rand.Next();
                component.ComponentName = (Parts)rand.Next(1, 4);

                components.Add(component);
            }
            message = "The component was added successfully!";
            return components;
        }
    }
}