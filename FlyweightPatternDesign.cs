using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSF20M024_EAD_A7
{
    // *************************************** EXAMPLE  01
    // Text Formatting

    // Flyweight Interface
    public interface IFont
    {
        void SetFont(string name, int size);
        void Print(string content);
    }

    // Concrete Flyweight - Represents a font
    public class Font : IFont
    {
        private string name;
        private int size;

        public void SetFont(string name, int size)
        {
            this.name = name;
            this.size = size;
        }

        public void Print(string content)
        {
            Console.WriteLine($"Printing '{content}' with {name} ({size}px)");
        }
    }

    // Flyweight Factory - Manages shared flyweight objects
    public class FontFactory
    {
        private Dictionary<string, Font> fonts = new Dictionary<string, Font>();

        public Font GetFont(string key)
        {
            if (!fonts.ContainsKey(key))
            {
                // Create and cache a new font if it doesn't exist
                fonts[key] = new Font();
            }
            return fonts[key];
        }
    }

    // *************************************** EXAMPLE  02
    // Gaming - Tree Models


    // Flyweight Interface
    public interface ITreeModel
    {
        void Render(int x, int y);
    }

    // Concrete Flyweight - Represents a tree model
    public class TreeModel : ITreeModel
    {
        private string texture;
        private string model;

        public TreeModel(string texture, string model)
        {
            this.texture = texture;
            this.model = model;
        }

        public void Render(int x, int y)
        {
            Console.WriteLine($"Rendering tree at ({x},{y}) with texture '{texture}' and model '{model}'");
        }
    }

    // Flyweight Factory - Manages shared flyweight objects
    public class TreeModelFactory
    {
        private static TreeModel sharedModel;

        public static TreeModel GetTreeModel()
        {
            // Create and share the tree model if it doesn't exist
            if (sharedModel == null)
            {
                sharedModel = new TreeModel("tree_texture.png", "tree.obj");
            }
            return sharedModel;
        }
    }
}

