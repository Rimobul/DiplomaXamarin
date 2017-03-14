namespace NativeUIElement.UWP.UI
{
    public static class Extensions
    {
        public static Windows.UI.Color ToWindows(this Xamarin.Forms.Color xamarinColor)
        {
            return Windows.UI.Color.FromArgb(DoubleToByte(xamarinColor.A), DoubleToByte(xamarinColor.R), DoubleToByte(xamarinColor.G), DoubleToByte(xamarinColor.B));
        }

        private static byte DoubleToByte(double input)
        {
            var result = input * 255;
            return (byte)result;
        }
    }
}
