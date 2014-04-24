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
//            SetContentView (Resource.Layout.Main);
            SetContentView (new TestView (this));

            // Get our button from the layout resource, and attach an event to it
//            Button button = FindViewById<Button> (Resource.Id.MyButton);
//            button.Click += delegate { button.Text = string.Format ("{0} clicks!", count++); };
//
//            var viewGroup = new LinearLayout (ApplicationContext);
//            AddContentView (viewGroup, Window.Attributes);
//            viewGroup.AddView (new TestView (ApplicationContext));
        }
    }

    //------------------------------------------------------------------
    public class TestView : TextView
    {
        private Bitmap bitmap;
        private Canvas canvas;

        //------------------------------------------------------------------
        public TestView (Context context) : base (context)
        {
            bitmap = Bitmap.CreateBitmap (400, 400, Android.Graphics.Bitmap.Config.Argb8888);
            bitmap.EraseColor (Color.Orange);

            canvas = new Canvas (bitmap);
        }

        //------------------------------------------------------------------
        protected override void OnDraw (Canvas canvas)
        {
            Rect rect = new Rect (0, 0, 1000, 1000);
//            canvas.DrawBitmap (bitmap, null, rect, Paint);
            canvas.DrawBitmap (bitmap, 0, 0, Paint);

//            canvas.Translate (500, 500);
//            bitmap.EraseColor (Color.GreenYellow);
//            canvas.DrawBitmap (bitmap, 0, 0, Paint);

            base.OnDraw (canvas);
        }
    }
}