using Android.Content;
using Android.Views;
using Android.Graphics;
using Java.Lang;

namespace NativeUIElement.Droid.UI
{
    public class CircularProgress : View
    {
        /**
         * ProgressBar's line thickness
         */
        private float strokeWidth = 4;
        //private float progress = 0;
        private int min = 0;
        //private int max = 100;
        /**
         * Start the progress at 12 o'clock
         */
        private int startAngle = -90;
        private double progress;
        private Color backgroundColor;
        private Color foregroundColor;
        private RectF rectF;
        private Paint backgroundPaint;
        private Paint foregroundPaint;

        public CircularProgress(Context context, double max) 
            : base(context)
        {
            rectF = new RectF();
            Max = max;
        }

        public double Max { get; private set; }

        public Color ProgressColor
        {
            get { return foregroundColor; }
            set
            {
                if (foregroundColor != value)
                {
                    foregroundColor = value;
                    foregroundPaint = new Paint(PaintFlags.AntiAlias);
                    foregroundPaint.Color = value;
                    foregroundPaint.SetStyle(Paint.Style.Stroke);
                    foregroundPaint.StrokeWidth = strokeWidth;

                    Invalidate();
                }
            }
        }

        public Color ProgressBackgroundColor
        {
            get { return backgroundColor; }
            set
            {
                if (backgroundColor != value)
                {
                    backgroundColor = value;
                    backgroundPaint = new Paint(PaintFlags.AntiAlias);
                    backgroundPaint.Color = value;
                    backgroundPaint.SetStyle(Paint.Style.Stroke);
                    backgroundPaint.StrokeWidth = strokeWidth;

                    Invalidate();
                }
            }
        }

        public double Progress
        {
            get { return progress; }
            set
            {
                if(progress != value)
                {
                    progress = value;
                    Invalidate();
                }
            }
        }

        private int Percentage(double value)
        {
            return (int)(value / Max * 100);
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            int height = GetDefaultSize(SuggestedMinimumHeight, heightMeasureSpec);
            int width = GetDefaultSize(SuggestedMinimumWidth, widthMeasureSpec);
            int min = Math.Min(width, height);
            SetMeasuredDimension(min, min);
            rectF.Set(0 + strokeWidth / 2, 0 + strokeWidth / 2, min - strokeWidth / 2, min - strokeWidth / 2);
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);

            canvas.DrawOval(rectF, backgroundPaint);
            float angle = 360 * Percentage(progress) / Percentage(Max);
            canvas.DrawArc(rectF, startAngle, angle, false, foregroundPaint);
        }
    }
}