using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSF20M024_EAD_A8
{
    // ****************************************  Example 01 *******************************************

    // Command interface
    interface ICommand
    {
        void ExecuteAction();
    }

    // Concrete commands
    class LightOnCommand : ICommand
    {
        private readonly Light light;

        public LightOnCommand(Light light)
        {
            this.light = light;
        }

        public void ExecuteAction()
        {
            light.TurnOn();
        }
    }

    class LightOffCommand : ICommand
    {
        private readonly Light light;

        public LightOffCommand(Light light)
        {
            this.light = light;
        }

        public void ExecuteAction()
        {
            light.TurnOff();
        }
    }

    // Receiver
    class Light
    {
        public void TurnOn()
        {
            Console.WriteLine("Light is ON");
        }

        public void TurnOff()
        {
            Console.WriteLine("Light is OFF");
        }
    }

    // Invoker
    class RemoteControl
    {
        private ICommand command;

        public void SetCommand(ICommand command)
        {
            this.command = command;
        }

        public void PressButton()
        {
            command.ExecuteAction();
        }
    }

}

// ****************************************  Example 02 *******************************************

// Command interface
interface IEditorCommand
{
    void ExecuteOperation();
}

// Concrete commands
class CopyCommand : IEditorCommand
{
    private readonly Clipboard clipboard;

    public CopyCommand(Clipboard clipboard)
    {
        this.clipboard = clipboard;
    }

    public void ExecuteOperation()
    {
        clipboard.CopyContent();
    }
}

class PasteCommand : IEditorCommand
{
    private readonly Clipboard clipboard;

    public PasteCommand(Clipboard clipboard)
    {
        this.clipboard = clipboard;
    }

    public void ExecuteOperation()
    {
        clipboard.PasteContent();
    }
}

// Receiver
class Clipboard
{
    public void CopyContent()
    {
        Console.WriteLine("Copied to clipboard");
    }

    public void PasteContent()
    {
        Console.WriteLine("Pasted from clipboard");
    }
}

// Invoker
class TextEditor
{
    private IEditorCommand command;

    public void SetCommand(IEditorCommand command)
    {
        this.command = command;
    }

    public void ExecuteCommand()
    {
        command.ExecuteOperation();
    }
}