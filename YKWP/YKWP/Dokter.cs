using SQLite.Net.Attributes;
using System;

namespace YKWP
{
    public class Dokter
    {
        [PrimaryKey, AutoIncrement]
        public int IDDokter { get; set; }
        public string Nama { get; set; }
        public string Marga { get; set; }
        public DateTime TanggalLahir { get; set; }
        public bool Aktif { get; set; }

        public string NamaLengkap
        {
            get
            {
                return string.Format("{0} {1}", this.Nama, this.Marga);
            }
        }

        public string TanggalLahirEdited
        {
            get
            {
                return string.Format("{0:yy-MM-dd}", TanggalLahir);
            }
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", IDDokter, NamaLengkap,
                TanggalLahirEdited,  Aktif);
        }
    }
}
