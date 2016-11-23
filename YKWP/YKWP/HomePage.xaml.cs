using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace YKWP
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            this.Padding = Device.OnPlatform(
                new Thickness(10, 20, 10, 10),
                new Thickness(10),
                new Thickness(10));

            dokterListView.ItemTemplate = new DataTemplate(typeof(DokterCell));
            dokterListView.RowHeight = 75;

                tambahBtn.Clicked += TambahBtn_Clicked;
            dokterListView.ItemSelected += DokterListView_ItemSelected;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (var datas = new DataAccess())
            {
                dokterListView.ItemsSource = datas.GetDokters();
            }
        }

        private async void DokterListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new EditPage((Dokter)e.SelectedItem));
        }

        private async void TambahBtn_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(namaEntry.Text))
            {
                await DisplayAlert("Error", "Nama Harus Diisi", "OK");
                namaEntry.Focus();
                return;
            }

            if(string.IsNullOrEmpty(margaEntry.Text))
            {
                await DisplayAlert("Error", "Marga Harus Diisi", "OK");
                margaEntry.Focus();
                return;
            }

            var dokter = new Dokter
            {
                Nama = namaEntry.Text,
                Marga = margaEntry.Text,
                TanggalLahir = TanggalLahirDatePicker.Date,
                Aktif = aktifSwitch.IsToggled
            };

            using (var datas = new DataAccess())
            {
                datas.InsertDokter(dokter);
                dokterListView.ItemsSource = datas.GetDokters();
            }

            namaEntry.Text = string.Empty;
            margaEntry.Text = string.Empty;
            TanggalLahirDatePicker.Date = DateTime.Now;
            aktifSwitch.IsToggled = true;
            await DisplayAlert("Konfirmasi", "Data Dokter Ditambahkan", "OK");
        }
    }
}
