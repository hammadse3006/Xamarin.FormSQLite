using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace YKWP
{
    public partial class EditPage : ContentPage
    {
        private Dokter dokter;

        public EditPage(Dokter dokter)
        {
            InitializeComponent();

            this.dokter = dokter;

            this.Padding = Device.OnPlatform(
                new Thickness(10, 20, 10, 10),
                new Thickness(10),
                new Thickness(10));

            namaEntry.Text = dokter.Nama;
            margaEntry.Text = dokter.Marga;
            TanggalLahirDatePicker.Date = dokter.TanggalLahir;
            aktifSwitch.IsToggled = dokter.Aktif;

            updateBtn.Clicked += UpdateBtn_Clicked;
            hapusBtn.Clicked += HapusBtn_Clicked;
        }

        private async void HapusBtn_Clicked(object sender, EventArgs e)
        {
            var hps = await DisplayAlert("Konfirmasi", "Dokter Akan Dihapus?", "Ya", "Batal");
            if (!hps)
            {
                return;
            }

            using (var datas = new DataAccess())
            {
                datas.DeleteDokter(dokter);
            }

            await DisplayAlert("Informasi", "Data Dokter Telah Dihapus", "OK");
            await Navigation.PopAsync();
        }

        private async void UpdateBtn_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(namaEntry.Text))
            {
                await DisplayAlert("Error", "Nama Dokter Harus Diisi", "OK");
                namaEntry.Focus();
                return;
            }

            if(string.IsNullOrEmpty(margaEntry.Text))
            {
                await DisplayAlert("Error", "Marga Dokter Harus Diisi", "OK");
                margaEntry.Focus();
                return;
            }

            dokter.Nama = namaEntry.Text;
            dokter.Marga = margaEntry.Text;
            dokter.TanggalLahir = TanggalLahirDatePicker.Date;
            dokter.Aktif = aktifSwitch.IsToggled;

            using (var datas = new DataAccess())
            {
                datas.UpdateDokter(dokter);
            }

            await DisplayAlert("Konfirmasi", "Data Dokter Berhasil Diperbaharui", "OK");
            await Navigation.PopAsync();

        }
    }
}
