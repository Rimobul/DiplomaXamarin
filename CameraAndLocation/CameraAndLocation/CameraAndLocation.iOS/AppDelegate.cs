using Foundation;
using UIKit;
using XLabs.Forms;
using System.IO;
using XLabs.Platform.Device;
using XLabs.Platform.Services.Media;
using XLabs.Platform.Mvvm;

namespace CameraAndLocation.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : XFormsApplicationDelegate// : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            this.SetIoc();

            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

        private void SetIoc()
        {
            var resolverContainer = new global::XLabs.Ioc.SimpleContainer();

            var app = new XFormsAppiOS();
            app.Init(this);

            var documents = app.AppDataDirectory;
            var pathToDatabase = Path.Combine(documents, "xforms.db");

            resolverContainer.Register<IDevice>(t => AppleDevice.CurrentDevice)
                .Register<IDisplay>(t => t.Resolve<IDevice>().Display)
                //.Register<IFontManager>(t => new FontManager(t.Resolve<IDisplay>()))
                //.Register<XLabs.Serialization.IJsonSerializer, XLabs.Serialization.JsonNET.JsonSerializer>()
                //.Register<IJsonSerializer, Services.Serialization.SystemJsonSerializer>()
                //.Register<ITextToSpeechService, TextToSpeechService>()
                //.Register<IEmailService, EmailService>()
                .Register<IMediaPicker, MediaPicker>()
                .Register<IXFormsApp>(app)
                //.Register<ISecureStorage, SecureStorage>()
                .Register<global::XLabs.Ioc.IDependencyContainer>(t => resolverContainer);
                //.Register<global::XLabs.Caching.ICacheProvider>(
                    //t => new SQLiteSimpleCache(new SQLitePlatformIOS(),
                        //new SQLiteConnectionString(pathToDatabase, true), t.Resolve<global::XLabs.Serialization.IJsonSerializer>()));

            XLabs.Ioc.Resolver.SetResolver(resolverContainer.GetResolver());
        }
    }
}
