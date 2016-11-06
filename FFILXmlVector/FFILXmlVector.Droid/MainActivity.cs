using Android.App;
using Android.OS;
using Android.Support.V7.App;
using FFImageLoading;
using FFImageLoading.Views;

namespace FFILXmlVector.Droid
{
    [Activity (Label = "FFILXmlVector.Droid", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/AppTheme")]
	public class MainActivity : AppCompatActivity
	{
		int count = 1;

        ImageViewAsync imgXml, imgPng;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            this.imgPng = this.FindViewById<ImageViewAsync>(Resource.Id.img_common_png_placeholder);
            this.imgXml = this.FindViewById<ImageViewAsync>(Resource.Id.img_vector_drawable_placeholder);

            // Loads the image with png placeholders (works)
            ImageService.Instance.LoadUrl("This should load the error placeholder")
                .LoadingPlaceholder("@drawable/Icon", FFImageLoading.Work.ImageSource.CompiledResource)
                .ErrorPlaceholder("@drawable/Icon", FFImageLoading.Work.ImageSource.CompiledResource)
                .Into(this.imgPng);

            // Loads the image with xml placeholders (doesn't work)
            ImageService.Instance.LoadUrl("This should load the error placeholder")
                .LoadingPlaceholder("@drawable/freesample", FFImageLoading.Work.ImageSource.CompiledResource)
                .ErrorPlaceholder("@drawable/freesample", FFImageLoading.Work.ImageSource.CompiledResource)
                .Into(this.imgXml);
        }
	}
}