using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSF20M024_EAD_A8
{
    // ****************************************  Example 01 *******************************************

    // State interface
    interface ITrafficLightState
    {
        void ChangeLight(TrafficLight light);
    }

    // Concrete states
    class RedLight : ITrafficLightState
    {
        public void ChangeLight(TrafficLight light)
        {
            Console.WriteLine("Red Light - Stop");
            light.SetState(new GreenLight());
        }
    }

    class GreenLight : ITrafficLightState
    {
        public void ChangeLight(TrafficLight light)
        {
            Console.WriteLine("Green Light - Go");
            light.SetState(new YellowLight());
        }
    }

    class YellowLight : ITrafficLightState
    {
        public void ChangeLight(TrafficLight light)
        {
            Console.WriteLine("Yellow Light - Prepare to Stop");
            light.SetState(new RedLight());
        }
    }

    // Context
    class TrafficLight
    {
        private ITrafficLightState currentState;

        public TrafficLight()
        {
            currentState = new RedLight();
        }

        public void SetState(ITrafficLightState state)
        {
            currentState = state;
        }

        public void ChangeLight()
        {
            currentState.ChangeLight(this);
        }
    }

    // ****************************************  Example 02 *******************************************


    // State interface
    interface IWritingState
    {
        void Write(string words);
    }

    // Concrete states
    class UpperCaseState : IWritingState
    {
        public void Write(string words)
        {
            Console.WriteLine(words.ToUpper());
        }
    }

    class LowerCaseState : IWritingState
    {
        public void Write(string words)
        {
            Console.WriteLine(words.ToLower());
        }
    }

    class DefaultState : IWritingState
    {
        public void Write(string words)
        {
            Console.WriteLine(words);
        }
    }

    // Context
    class TextEditor
    {
        private IWritingState currentState;

        public TextEditor()
        {
            currentState = new DefaultState();
        }

        public void SetState(IWritingState state)
        {
            currentState = state;
        }

        public void Type(string words)
        {
            currentState.Write(words);
        }
    }
}
