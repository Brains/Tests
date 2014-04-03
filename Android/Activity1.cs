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

namespace AndroidApplication6
{
    [Activity (Label = "AndroidApplication6", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
        int count = 1;

        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);

            // Set our view from the "main" layout resource
//            SetContentView (Resource.Layout.Main);
//            SetContentView (new MyOvalShape (this));


            // Get our button from the layout resource,
            // and attach an event to it
//            Button button = FindViewById<Button> (Resource.Id.MyButton);
//            button.Click += delegate { button.Text = string.Format ("{0} clicks!", count++); };

            var viewGroup = new LinearLayout (ApplicationContext);
            AddContentView (viewGroup, Window.Attributes);
            viewGroup.AddView (new MyOvalShape (ApplicationContext));

        }
    }

    //------------------------------------------------------------------
    public class MyOvalShape : TextView
    {
        private readonly ShapeDrawable _shape;

        public MyOvalShape (Context context)
            : base (context)
        {
            var paint = new Paint ();
            paint.SetARGB (255, 200, 255, 0);
            paint.SetStyle (Android.Graphics.Paint.Style.Stroke);
            paint.StrokeWidth = 1;

            _shape = new ShapeDrawable (new OvalShape ());
            _shape.Paint.Set (paint);

            _shape.SetBounds (0, 0, 300, 300);

            Text = "Kill";


            Click += (sender, args) => Toast.MakeText (context, "Kill", ToastLength.Short).Show();
        }

        protected override void OnDraw (Canvas canvas)
        {
            SetHeight (100);
            SetWidth (100);


            base.OnDraw (canvas);
//            _shape.Draw (canvas);

            Paint.Color = Color.Chocolate;
            Paint.TextSize = 32;
            canvas.DrawText ("?", Width / 2.0f, Height / 2.0f, Paint);

        }
    }
}

