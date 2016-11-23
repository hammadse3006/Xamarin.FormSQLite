using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite.Net.Interop;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

[assembly: Dependency(typeof(YKWP.Droid.Config))]

namespace YKWP.Droid
{
    public class Config : IConfig
    {
        private string directoryDB;
        private ISQLitePlatform plataforma;

        public string DirectoryDB
        {
            get
            {
                if(string.IsNullOrEmpty(directoryDB))
                {
                    directoryDB = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

                }
                return directoryDB;
            }
        }

        public ISQLitePlatform Plataforma
        {
            get
            {
                if(plataforma == null)
                {
                    plataforma = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
                }
                return plataforma;
            }
        }
    }
}