using BGStopwatch.Helpers;
using BGStopwatch.iOS.Renderers;
using CoreAnimation;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(GradientContentPage), typeof(GradientContentPageRenderer))]

namespace BGStopwatch.iOS.Renderers
{
    public class GradientContentPageRenderer : PageRenderer
    {
        public CAGradientLayer gradient;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            gradient = new CAGradientLayer();
            gradient.Frame = View.Bounds;
            gradient.NeedsDisplayOnBoundsChange = true;
            gradient.MasksToBounds = true;
            gradient.Colors = new[] { Color.FromHex("#FFFFFF").ToCGColor(), Color.FromHex("#808080").ToCGColor() };
            View.Layer.InsertSublayer(gradient, 0);
        }

        public override void ViewWillLayoutSubviews()
        {
            base.ViewWillLayoutSubviews();
            gradient.Frame = View.Bounds;
        }
    }
}