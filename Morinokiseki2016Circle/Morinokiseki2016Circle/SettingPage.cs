using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Morinokiseki2016Circle
{
    class SettingPage : ContentPage
    {
        private ListPage listPage;

        public SettingPage(ListPage parent)
        {
            Title = "ソート・検索";
            listPage = parent;
            var nameSortButton = new Button() { Text = "サークル名ソート" };
            var authorSortButton = new Button() { Text = "代表者名ソート" };
            var spaceSortButton = new Button() { Text = "スペースソート" };
            var genreSortButton = new Button() { Text = "ジャンルソート" };
            nameSortButton.Clicked += OnClickButton;
            authorSortButton.Clicked += OnClickButton;
            spaceSortButton.Clicked += OnClickButton;
            genreSortButton.Clicked += OnClickButton;

            var searchEntry = new Entry();
            var searchButton = new Button() { Text = "検索" };
            var clearButton = new Button() { Text = "クリア" };

            searchButton.Clicked += OnClickSearchButton;
            clearButton.Clicked += OnClickClearButton;

            var stackL = new StackLayout();
            stackL.Children.Add(nameSortButton);
            stackL.Children.Add(authorSortButton);
            stackL.Children.Add(spaceSortButton);
            stackL.Children.Add(genreSortButton);
            stackL.Children.Add(searchEntry);
            stackL.Children.Add(searchButton);
            stackL.Children.Add(clearButton);
            Content = stackL;
        }

        private void OnClickButton(object sender, EventArgs e)
        {
            var b = (Button)sender;
            switch (b.Text)
            {
                case "サークル名ソート":
                    listPage.Data = listPage.Data.OrderBy(d => d.Name).ToList();
                    break;
                case "代表者名ソート":
                    listPage.Data = listPage.Data.OrderBy(d => d.Author).ToList();
                    break;
                case "スペースソート":
                    listPage.Data = listPage.Data.OrderBy(d => d.Space).ToList();
                    break;
                case "ジャンルソート":
                    listPage.Data = listPage.Data.OrderBy(d => d.Genre).ToList();
                    break;
            }
            listPage.SetData();
        }

        private void OnClickSearchButton(object sender, EventArgs e)
        {
            // TODO
        }

        private void OnClickClearButton(object sender, EventArgs e)
        {
            listPage.ResetData();
        }
    }
}
