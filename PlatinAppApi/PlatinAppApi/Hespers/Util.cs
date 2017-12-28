using Plugin.Vibrate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZXing.Net.Mobile.Forms;

namespace  PlatinAppApi.Hespers
{
    public class Util
    {
        public static void Vibrar()
        {
            try
            {
                var v = CrossVibrate.Current;
                v.Vibration();
            }
            catch
            {

            }
        }

        public async static Task<ZXingScannerPage> CapturarCodigoAsync(ZXingScannerPage scanpage, string titulo, ZXing.BarcodeFormat formato)
        {
            if (scanpage == null)
            {
                var options = new ZXing.Mobile.MobileBarcodeScanningOptions();
                options.PossibleFormats = new List<ZXing.BarcodeFormat>()
                {
                    formato
                };

#if __ANDROID__
                //Initialize scanner first
            //    MobileBarcodeScanner.Initialize (Application);
#endif
                scanpage = new ZXingScannerPage(options);
                scanpage.IsScanning = true;
            }

            scanpage.Title = titulo;
            return scanpage;
        }
    }
}
