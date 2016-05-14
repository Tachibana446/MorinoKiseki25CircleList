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

        public StackLayout GetLayout(int n)
        {
            var backCol = n % 2 == 0 ? Color.Black : Color.Gray;
            var stackLayout = new StackLayout
            {
                Spacing = 5,
                BackgroundColor = backCol
            };
            stackLayout.Children.Add(new Label { Text = Space, TextColor = Color.White });
            stackLayout.Children.Add(new Label { Text = Name, TextColor = Color.White });
            stackLayout.Children.Add(new Label { Text = Author, TextColor = Color.White });
            stackLayout.Children.Add(new Entry { Text = HomePage, TextColor = Color.White });
            stackLayout.Children.Add(new Label { Text = Genre, TextColor = Color.White });
            return stackLayout;
        }

        public string ToString()
        {
            return $"{Name} , {Author} : {Space} , {Genre} \n{HomePage}";
        }
    }
}
