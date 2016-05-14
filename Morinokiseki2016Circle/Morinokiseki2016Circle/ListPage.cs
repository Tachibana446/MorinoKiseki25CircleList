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

        public ListPage()
        {
            Title = "サークルリスト";
            var scroll = new ScrollView();
            scroll.Content = stackLayout;
            Content = scroll;
            this.Appearing += ListPage_Appearing;
        }

        async private void ListPage_Appearing(object sender, EventArgs e)
        {
            if (loaded) return;
            await LoadData();
            SetData();
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
            stackLayout.Children.Clear();
            foreach (var d in Data)
            {
                stackLayout.Children.Add(d.GetLayout());
                stackLayout.Children.Add(new Label { Text = "-------------------------------", HorizontalOptions = LayoutOptions.CenterAndExpand });
            }
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
    }
}
