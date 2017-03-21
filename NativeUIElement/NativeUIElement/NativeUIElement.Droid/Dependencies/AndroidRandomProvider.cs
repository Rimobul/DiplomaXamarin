using NativeUIElement.Dependencies;
using NativeUIElement.Droid.Dependencies;
using System;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidRandomProvider))]
namespace NativeUIElement.Droid.Dependencies
{
    public class AndroidRandomProvider : IRandomProvider
    {
        private static readonly Lazy<Java.Util.Random> source =
            new Lazy<Java.Util.Random>(() => new Java.Util.Random());

        public double GenerateRandomPercentage()
        {
            return source.Value.NextDouble();
        }
    }
}