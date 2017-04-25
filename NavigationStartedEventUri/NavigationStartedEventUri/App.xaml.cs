using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xam.Plugin.Abstractions;
using Xamarin.Forms;
using System.Diagnostics;

namespace NavigationStartedEventUri
{
    public partial class App : Application
    {
        Label label = new Label();
        public App()
        {
            var htmlString = @"
<html>
<head>
<meta charset='utf-8'/>
</head>
<body>
<h1>Title</h1>
<a href='http://www.google.com'>google</a>
</body>
</html>
";
            FormsWebView wv = new FormsWebView();
            wv.ContentType = Xam.Plugin.Abstractions.Enumerations.WebViewContentType.StringData;
            wv.Source = htmlString;
            wv.HeightRequest = 500.0;
            wv.WidthRequest = 500.0;

            label.Text = "Initial";
            
            // The root page of your application
            var content = new ContentPage
            {
                Title = "lastCalendar",
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    BackgroundColor = Color.Red,
                    Children = {
                        label,
                        wv
                    }
                }
            };

            wv.OnNavigationStarted += Wv_OnNavigationStarted;

            //content.Appearing += Content_Appearing;
            MainPage = new NavigationPage(content);
        }

        private Xam.Plugin.Abstractions.Events.Inbound.NavigationRequestedDelegate Wv_OnNavigationStarted(Xam.Plugin.Abstractions.Events.Inbound.NavigationRequestedDelegate eventObj)
        {
            label.Text = ("eventObj.Uri = "+eventObj.Uri);
            return eventObj;
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
