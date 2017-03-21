using System;
using NativeUIElement.Dependencies;
using NativeUIElement.UWP.Dependencies;

[assembly: Xamarin.Forms.Dependency(typeof(WindowsRandomProvider))]
namespace NativeUIElement.UWP.Dependencies
{
    public class WindowsRandomProvider : IRandomProvider
    {
        private static readonly Lazy<Random> source =
               new Lazy<Random>(() => new Random());

        public double GenerateRandomPercentage()
        {
            return source.Value.NextDouble();
        }
    }
}
