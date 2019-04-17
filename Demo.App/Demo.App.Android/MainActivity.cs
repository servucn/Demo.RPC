using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Environment = System.Environment;
using Demo.Interface;
using System.Collections.Generic;
using Demo.Model;
using System.IO;

namespace Demo.App.Droid
{
    [Activity(Label = "Demo.App", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static UcAsp.RPC.ApplicationContext context;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            string configFromOriginalFile = string.Empty;
            using (var sr = new StreamReader(Android.App.Application.Context.Assets.Open("Application.config")))
                configFromOriginalFile = sr.ReadToEnd();
            string path = Environment.CurrentDirectory;

            var localFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var filePath = localFolder + "/Application.config";

            if (File.Exists(filePath))
                File.Delete(filePath);
            File.WriteAllText(filePath, configFromOriginalFile);


            context = new UcAsp.RPC.ApplicationContext();
            context.Start(filePath, AppDomain.CurrentDomain.BaseDirectory);
            ISwPackageWeight swExport = context.GetProxyObject<ISwPackageWeight>();
            List<SwPackageWeight> swPackageWeights = swExport.GetSwPackageWeights();
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
    }
}