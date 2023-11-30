using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSF20M024_EAD_A8
{
    // ****************************************  Example 01 *******************************************

    // Memento
    class EditorMemento
    {
        public string Text { get; }

        public EditorMemento(string text)
        {
            Text = text;
        }
    }

    // Originator
    class MementoTextEditor
    {
        private string text;

        public string Text
        {
            get => text;
            set
            {
                text = value;
                Console.WriteLine($"Current text: {text}");
            }
        }

        public EditorMemento Save()
        {
            return new EditorMemento(text);
        }

        public void Restore(EditorMemento memento)
        {
            text = memento.Text;
            Console.WriteLine($"Restored text: {text}");
        }
    }

    // Caretaker
    class History
    {
        public EditorMemento Memento { get; set; }
    }

    // ****************************************  Example 02 *******************************************

    // Memento
    class GameStateMemento
    {
        public int Level { get; }
        public int Score { get; }

        public GameStateMemento(int level, int score)
        {
            Level = level;
            Score = score;
        }
    }

    // Originator
    class Game
    {
        private int level;
        private int score;

        public void Play()
        {
            // Simulating gameplay
            level++;
            score += 100;
            Console.WriteLine($"Level: {level}, Score: {score}");
        }

        public GameStateMemento Save()
        {
            return new GameStateMemento(level, score);
        }

        public void Restore(GameStateMemento memento)
        {
            level = memento.Level;
            score = memento.Score;
            Console.WriteLine($"Restored - Level: {level}, Score: {score}");
        }
    }

    // Caretaker
    class GameHistory
    {
        public GameStateMemento Memento { get; set; }
    }
}
