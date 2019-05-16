using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReactiveWatchList.Pages;
using Xamarin.Forms;

namespace ReactiveWatchList
{
    public class App
    {
        public static Page GetMainPage()
        {
            return new WatchListPage();
        }
    }
}
