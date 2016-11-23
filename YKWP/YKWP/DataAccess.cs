using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace YKWP
{
    public class DataAccess : IDisposable
    {
        private SQLiteConnection connection;
        public DataAccess()
        {
            var config = DependencyService.Get<IConfig>();
            connection = new SQLiteConnection(config.Plataforma,
                System.IO.Path.Combine(config.DirectoryDB, "YKWP.db3"));
            connection.CreateTable<Dokter>();
        }

        public void InsertDokter(Dokter dokter)
        {
            connection.Insert(dokter);
        }

        public void UpdateDokter(Dokter dokter)
        {
            connection.Update(dokter);
        }

        public void DeleteDokter(Dokter dokter)
        {
            connection.Delete(dokter);
        }

        public Dokter GetDokter(int IDDokter)
        {
            return connection.Table<Dokter>().FirstOrDefault(c => c.IDDokter == IDDokter);
        }

        public List<Dokter> GetDokters()
        {
            return connection.Table<Dokter>().OrderBy(c => c.Marga).ToList();
        }

        public void Dispose()
        {
            connection.Dispose();
        }
    }
}
