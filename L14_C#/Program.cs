using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L14_C_
{
    public class PropertyEventArgs
    {
        public string PropertyName { get; set; }
        public PropertyEventArgs(string propertyName)
        {
            PropertyName = propertyName;
        }
    }

    public delegate void PropertyEventHandler(object sender, PropertyEventArgs e);
    public interface IPropertyChanged
    {
        event PropertyEventHandler PropertyChanged;
        void OnPropertyChanged(string propertyName);
    }

    public class Student : IPropertyChanged
    {
        private string name;
        private int age;
        private string email;

        public event PropertyEventHandler PropertyChanged;
        public string Name 
        { 
            get => name;
            set 
            { 
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public int Age 
        { 
            get => age; 
            set
            { 
                age = value;
                OnPropertyChanged(nameof(Age));
            } 
        }
        public string Email 
        { 
            get => email; 
            set 
            { 
                email = value;
                OnPropertyChanged(nameof(Email));
            } 
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyEventArgs(propertyName));
        }
    }
    // delegate EventHandler<TEventArgs>(object sender, TEventArgs eventArgs)
    // TEventArgs - наследник EventArgs
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student()
            {
                Name = "Ivan",
                Age = 30,
                Email = "ivan@mail.ru"
            };
            student.PropertyChanged += Message;
            student.Age = 25;

            Console.WriteLine();
        }
        static void Message(object sender, PropertyEventArgs eventArgs)
        {
            Console.WriteLine($"В объекте {sender} " +
                $"изменено свойство {eventArgs.PropertyName}");
        }
    }
}
