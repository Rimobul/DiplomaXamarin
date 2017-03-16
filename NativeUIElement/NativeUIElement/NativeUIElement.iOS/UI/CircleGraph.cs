using CoreGraphics;
using System;
using UIKit;

namespace NativeUIElement.iOS.UI
{
    public class CircleGraph : UIView
    {
        private const float FullCircle = 2 * (float)Math.PI;
        private int radius = 10;
        private int lineWidth = 10;
        private nfloat progress = 0.0f;

        public CircleGraph(CGRect frame, float max)
        {
            Max = max;
            this.Frame = new CGRect(frame.X, frame.Y, frame.Width, frame.Height);
            this.BackgroundColor = UIColor.Clear;
        }

        public float Progress
        {
            get { return (float)progress; }
            set
            {
                if(progress != value)
                {
                    if(value >= Max)
                    {
                        progress = Max - 0.0001f;
                    }
                    else
                    {
                        progress = value;
                    }

                    SetNeedsDisplay();
                }

            }
        }

        public UIColor ProgressColor { get; set; }

        public UIColor ProgressBackgroundColor { get; set; }

        public float Max { get; private set; }

        public override void Draw(CoreGraphics.CGRect rect)
        {
            base.Draw(rect);

            using (CGContext g = UIGraphics.GetCurrentContext())
            {
                var diameter = Math.Min(this.Bounds.Width, this.Bounds.Height);
                radius = (int)(diameter / 2) - lineWidth;

                DrawGraph(g, this.Bounds.GetMidX(), this.Bounds.GetMidY());
            };
        }

        public void DrawGraph(CGContext g, nfloat x, nfloat y)
        {
            g.SetLineWidth(lineWidth);

            // Draw background circle
            CGPath path = new CGPath();
            ProgressBackgroundColor.SetStroke();
            path.AddArc(x, y, radius, 0, progress * FullCircle, true);
            g.AddPath(path);
            g.DrawPath(CGPathDrawingMode.Stroke);

            // Draw overlay circle
            var pathStatus = new CGPath();
            ProgressColor.SetStroke();

            // Same Arc params except direction so colors don't overlap
            pathStatus.AddArc(x, y, radius, 0, progress * FullCircle, false);
            g.AddPath(pathStatus);
            g.DrawPath(CGPathDrawingMode.Stroke);
        }
    }
}