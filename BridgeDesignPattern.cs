using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSF20M024_EAD_A7
{
    // *************************************** EXAMPLE  01
    // Rendering Shape with differnt Colors


    // Bridge - Color abstraction
    public interface IColor
    {
        string Fill();
    }

    // Concrete Implementations - Different colors
    public class RedColor : IColor
    {
        public string Fill()
        {
            return "Red";
        }
    }

    public class BlueColor : IColor
    {
        public string Fill()
        {
            return "Blue";
        }
    }

    // Bridge - Shape abstraction
    public abstract class Shape
    {
        protected IColor color;

        protected Shape(IColor color)
        {
            this.color = color;
        }

        public abstract string Draw();
    }

    // Concrete Implementations - Different shapes
    public class Circle : Shape
    {
        private int radius;

        public Circle(int radius, IColor color) : base(color)
        {
            this.radius = radius;
        }

        public override string Draw()
        {
            return $"Drawing Circle with color {color.Fill()} and radius {radius}";
        }
    }

    public class Rectangle : Shape
    {
        private int width;
        private int height;

        public Rectangle(int width, int height, IColor color) : base(color)
        {
            this.width = width;
            this.height = height;
        }

        public override string Draw()
        {
            return $"Drawing Rectangle with color {color.Fill()}, width {width}, and height {height}";
        }
    }

    // *************************************** EXAMPLE  02
    // Remote Control Devices


    // Bridge - Device abstraction
    public interface IDevice
    {
        void TurnOn();
        void TurnOff();
        void SetChannel(double channel);
    }

    // Concrete Implementations - Different types of devices
    public class TV : IDevice
    {
        public void TurnOn()
        {
            Console.WriteLine("TV is on");
        }

        public void TurnOff()
        {
            Console.WriteLine("TV is off");
        }

        public void SetChannel(double channel)
        {
            Console.WriteLine($"Setting TV channel to {channel}");
        }
    }

    public class Radio : IDevice
    {
        public void TurnOn()
        {
            Console.WriteLine("Radio is on");
        }

        public void TurnOff()
        {
            Console.WriteLine("Radio is off");
        }

        public void SetChannel(double channel)
        {
            Console.WriteLine($"Setting Radio channel to {channel}");
        }
    }

    // Abstraction - Remote Control
    public abstract class RemoteControl
    {
        protected IDevice device;

        protected RemoteControl(IDevice device)
        {
            this.device = device;
        }

        public abstract void TurnOn();
        public abstract void TurnOff();
        public abstract void SetChannel(double channel);
    }

    // Refined Abstraction - Remote for TV
    public class TVRemote : RemoteControl
    {
        public TVRemote(IDevice device) : base(device) { }

        public override void TurnOn()
        {
            device.TurnOn();
        }

        public override void TurnOff()
        {
            device.TurnOff();
        }

        public override void SetChannel(double channel)
        {
            device.SetChannel(channel);
        }
    }

    // Refined Abstraction - Remote for Radio
    public class RadioRemote : RemoteControl
    {
        public RadioRemote(IDevice device) : base(device) { }

        public override void TurnOn()
        {
            device.TurnOn();
        }

        public override void TurnOff()
        {
            device.TurnOff();
        }

        public override void SetChannel(double channel)
        {
            device.SetChannel(channel);
        }
    }
}
