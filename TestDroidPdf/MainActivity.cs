using System;
using System.IO;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Com.Artifex.Mupdfdemo;
using Java.IO;
using File = Java.IO.File;

namespace TestDroidPdf
{
    //[Activity(Label = "TestDroidPdf", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it

            var file = fileFromAsset(this, "test.pdf");
            
            //var uri = Android.Net.Uri.FromFile(new File("file:///android_asset/test.pdf"));

            var uri = Android.Net.Uri.Parse(file.AbsolutePath);
            var intent = new Intent (this, typeof (MuPDFActivity));
            intent.SetFlags (ActivityFlags.NoHistory);
            intent.SetAction (Intent.ActionView);
            intent.SetData(uri);
            this.StartActivity(intent);

        }

        public static File fileFromAsset(Context context, String assetName) {
            File outFile = new File(context.CacheDir, assetName + "-pdfview.pdf");
            copy(context.Assets.Open(assetName), outFile);
            return outFile;
        }

    public static void copy(Stream inputStream, File output){
        OutputStream outputStream = null;
        var bufferedInputStream = new BufferedInputStream(inputStream);        
        try {
            outputStream = new FileOutputStream(output);
            int read = 0;
            byte[] bytes = new byte[1024];
            while ((read = bufferedInputStream.Read(bytes)) != -1){
                outputStream.Write(bytes, 0, read);
            }
        } finally {
            try {
                if (inputStream != null) {
                    inputStream.Close();
                }
            } finally {
                if (outputStream != null) {
                    outputStream.Close();
                }
            }
        }
    }
    }
}

