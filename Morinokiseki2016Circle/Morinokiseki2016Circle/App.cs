using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Morinokiseki2016Circle
{
    [System.Runtime.InteropServices.ComVisible(true)]


    public class App : Application
    {
        public App()
        {
            // The root page of your application

            var stk = new StackLayout();

            var tabbedPage = new TabbedPage
            {

            };

            var listPage = new ListPage();
            var settingPage = new SettingPage(listPage);

            tabbedPage.Children.Add(listPage);
            tabbedPage.Children.Add(settingPage);

            MainPage = tabbedPage;

        }



        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
