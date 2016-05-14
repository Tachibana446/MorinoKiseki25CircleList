using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Morinokiseki2016Circle
{
    class ListPage : ContentPage
    {
        public List<CircleData> Data { get; set; } = new List<CircleData>();
        private List<CircleData> oldData = new List<CircleData>();

        bool loaded = false;

        StackLayout stackLayout = new StackLayout();
        ScrollView scrollView = new ScrollView();
        View tempContent;


        public ListPage()
        {
            Title = "サークルリスト";
            scrollView.Content = stackLayout;
            Content = scrollView;
            this.Appearing += ListPage_Appearing;
        }

        async private void ListPage_Appearing(object sender, EventArgs e)
        {

            if (loaded) return;
            var c = Content;
            Content = new ActivityIndicator { Color = Color.Default, IsRunning = true, VerticalOptions = LayoutOptions.CenterAndExpand };
            await LoadData();
            SetData();
            Content = c;
            loaded = true;
        }

        async private Task LoadData()
        {
            var lines = (await Download()).Split('\n');
            foreach (var l in lines)
            {
                var array = l.Split(',').ToList();
                if (array.Count < 2) array.Add("");
                if (array.Count < 3) array.Add("");
                if (array.Count < 4) array.Add("");
                if (array.Count < 5) array.Add("");

                Data.Add(new CircleData(array[0], array[1], array[2], array[3], array[4]));
            }

            oldData = Data;
        }

        public void SetData()
        {
            // stackLayout.Children.Clear();
            var stackL = new StackLayout();
            int i = 0;
            foreach (var d in Data)
            {
                stackL.Children.Add(d.GetLayout(i)); i++;
                stackL.Children.Add(new Label
                {
                    Text = new string('-', 50),
                    HorizontalOptions = LayoutOptions.CenterAndExpand
                });
            }
            scrollView.Content = stackL;
            Content = scrollView;
        }

        public void ResetData()
        {
            Data = oldData;
            SetData();
        }

        async Task<String> Download()
        {
            var httpClient = new System.Net.Http.HttpClient();
            //return await httpClient.GetStringAsync("http://nameka-tei.blog.jp/circles.csv");
            return await httpClient.GetStringAsync("http://nameka-tei.blog.jp/circles-utf8.csv");
        }

        public void StartActivityIndicator()
        {
            tempContent = Content;
            Content = new ActivityIndicator { Color = Color.Default, IsRunning = true, VerticalOptions = LayoutOptions.CenterAndExpand };
        }

        public void StopActivityIndicator()
        {
            Content = tempContent;
        }
    }
}
