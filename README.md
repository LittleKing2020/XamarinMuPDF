# MuPDF for Xamarin
View Pdf with Java Binding Library for Xamarin

In this project you can use MuPDF library that has ported correctly to Xamarin .

1- For PDFs you want to show, you should put them into "Asset" folder , and load by this code.

            var file = fileFromAsset(this, "test.pdf");   //write file name with extension
            var uri = Android.Net.Uri.Parse(file.AbsolutePath);
            var intent = new Intent (this, typeof (MuPDFActivity));   //to use MuPDFActivity
            intent.SetFlags (ActivityFlags.NoHistory);
            intent.SetAction (Intent.ActionView);
            intent.SetData(uri);
            this.StartActivity(intent);   //start a activity
            
2- Here we have two function that help us to read pdf files properly without any crash in app .
  2-1 "fileFromAsset":
    >No information
  2-2 "copy":
    For loading pdf in your xamarin app with MuPDF library you should use stream to load it.

