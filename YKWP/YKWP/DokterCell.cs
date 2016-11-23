using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace YKWP
{
    public class DokterCell : ViewCell
    {
        public DokterCell()
        {
            var idDokterLabel = new Label
            {
                HorizontalTextAlignment = TextAlignment.End,
                HorizontalOptions = LayoutOptions.Start,
                FontSize = 20,
                FontAttributes = FontAttributes.Bold
            };

            idDokterLabel.SetBinding(Label.TextProperty, new Binding("IDDokter"));

            var namaLengkapLabel = new Label
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                FontSize = 20,
                FontAttributes = FontAttributes.Bold
            };

            namaLengkapLabel.SetBinding(Label.TextProperty, new Binding("NamaLengkap"));

            var tanggalLahirLabel = new Label
            {
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            tanggalLahirLabel.SetBinding(Label.TextProperty, new Binding("TanggalLahirEdited"));

            var aktivoSwitch = new Switch
            {
                IsEnabled = false,
                HorizontalOptions = LayoutOptions.End
            };

            aktivoSwitch.SetBinding(Switch.IsToggledProperty, new Binding("Aktif"));

            var line1 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    idDokterLabel, namaLengkapLabel,
                },
            };

            var line2 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    tanggalLahirLabel, aktivoSwitch,
                },
            };

            View = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children =
                {
                    line1 , line2,
                },
            };

        }

    }
}
