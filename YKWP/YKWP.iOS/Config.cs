using SQLite.Net.Interop;
using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(YKWP.iOS.Config))]

namespace YKWP.iOS
{
    public class Config : IConfig
    {
        private string directoryDB;
        private ISQLitePlatform plataforma;

        public string DirectorioDB
        {
            get
            {
                if (string.IsNullOrEmpty(directoryDB))
                {
                    //     var directorio = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    //     directoryDB = System.IO.Path.Combine(directorio, "Library", "YKWP.db3");
                    directoryDB = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }

                return directoryDB;
            }
        }

        public string DirectoryDB
        {
            get
            {
                if (string.IsNullOrEmpty(directoryDB))
                {
                    //    var directorio = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    //    directoryDB = System.IO.Path.Combine(directorio, "...", "Library");
                    directoryDB = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }

                return directoryDB;
                throw new NotImplementedException();
            }
        }

        public ISQLitePlatform Plataforma
        {
            get
            {
                if (plataforma == null)
                {
                    plataforma = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
                }

                return plataforma;
            }
        }
    }
}
