using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Morinokiseki2016Circle
{
    class CircleData
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Space { get; set; }
        public string HomePage { get; set; }
        public string Genre { get; set; }

        public CircleData(string name, string author, string space, string hp, string genre)
        {
            Name = name;
            Author = author;
            Space = space;
            HomePage = hp;
            Genre = genre;
        }

        public StackLayout GetLayout()
        {
            var stackLayout = new StackLayout
            {
                Spacing = 5
            };
            stackLayout.Children.Add(new Label { Text = Space });
            stackLayout.Children.Add(new Label { Text = Name });
            stackLayout.Children.Add(new Label { Text = Author });
            stackLayout.Children.Add(new Entry { Text = HomePage });
            stackLayout.Children.Add(new Label { Text = Genre });
            return stackLayout;
        }
    }
}
