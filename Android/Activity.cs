using System;
using System.Text.RegularExpressions;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Test
{
    [Activity (Label = "Test", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity : Android.App.Activity
    {
        private int count = 1;

        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            SetContentView (new TestView (this));

//             Get our button from the layout resource,
//             and attach an event to it
            Button button = FindViewById<Button> (Resource.Id.MyButton);
            button.Click += delegate { button.Text = string.Format ("{0} clicks!", count++); };

            var viewGroup = new LinearLayout (ApplicationContext);
            AddContentView (viewGroup, Window.Attributes);
            viewGroup.AddView (new TestView (ApplicationContext));
        }

    }

    //------------------------------------------------------------------
    public class TestView : TextView
    {
        private readonly ShapeDrawable _shape;
        private Bitmap bitmap;

        public TestView (Context context) : base (context)
        {
            SetSoftwareLayer();

            bitmap = Bitmap.CreateBitmap (300, 300, Android.Graphics.Bitmap.Config.Argb8888);
            bitmap.EraseColor (Color.Orange);
        }

        //------------------------------------------------------------------
        private void SetSoftwareLayer ()
        {
            SetLayerType (Android.Views.LayerType.Hardware, null);
            Console.WriteLine(LayerType);


            const int layerTypeSoftware = 1;

            if ((int) Build.VERSION.SdkInt >= 11)
            {
                var method = JNIEnv.GetMethodID (JNIEnv.GetObjectClass (Handle), "setLayerType", "(ILandroid/graphics/Paint;)V");
                JNIEnv.CallVoidMethod (Handle, method, new JValue (layerTypeSoftware), new JValue (null));
            }


            Console.WriteLine (LayerType);


        }
    }
}