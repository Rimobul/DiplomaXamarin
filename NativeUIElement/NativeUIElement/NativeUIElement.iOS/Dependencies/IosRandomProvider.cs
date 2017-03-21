using NativeUIElement.Dependencies;
using NativeUIElement.iOS.Dependencies;
using GameplayKit;
using System;

[assembly: Xamarin.Forms.Dependency(typeof(IosRandomProvider))]
namespace NativeUIElement.iOS.Dependencies
{
    public class IosRandomProvider : IRandomProvider
    {
        private static readonly Lazy<GKARC4RandomSource> source =
            new Lazy<GKARC4RandomSource>(() => new GKARC4RandomSource());

        public double GenerateRandomPercentage()
        {
            return source.Value.GetNextUniform();
        }
    }
}
