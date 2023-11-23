using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSF20M024_EAD_A7
{
    // *************************************** EXAMPLE  01
    // File System Structure

    // Component - Abstract base class for both files and directories
    public abstract class FileSystemComponent
    {
        protected string name;

        public FileSystemComponent(string name)
        {
            this.name = name;
        }

        public abstract void Print();
    }

    // Leaf - Represents a file in the file system
    public class File : FileSystemComponent
    {
        public File(string name) : base(name) { }

        public override void Print()
        {
            Console.WriteLine($"File: {name}");
        }
    }

    // Composite - Represents a directory containing files and subdirectories
    public class Directory : FileSystemComponent
    {
        private List<FileSystemComponent> components = new List<FileSystemComponent>();

        public Directory(string name) : base(name) { }

        public void AddComponent(FileSystemComponent component)
        {
            components.Add(component);
        }

        public override void Print()
        {
            Console.WriteLine($"Directory: {name}");
            foreach (var component in components)
            {
                component.Print();
            }
        }
    }


    // *************************************** EXAMPLE  02
    // Organization Structure

    // Component - Abstract base class for both individual employees and departments
    public abstract class OrganizationComponent
    {
        protected string name;

        public OrganizationComponent(string name)
        {
            this.name = name;
        }

        public abstract void Display();
    }

    // Leaf - Represents an individual employee in the organization
    public class Employee : OrganizationComponent
    {
        public Employee(string name) : base(name) { }

        public override void Display()
        {
            Console.WriteLine($"Employee: {name}");
        }
    }

    // Composite - Represents a department containing employees
    public class Department : OrganizationComponent
    {
        private List<OrganizationComponent> components = new List<OrganizationComponent>();

        public Department(string name) : base(name) { }

        public void AddComponent(OrganizationComponent component)
        {
            components.Add(component);
        }

        public override void Display()
        {
            Console.WriteLine($"Department: {name}");
            foreach (var component in components)
            {
                component.Display();
            }
        }
    }

}
