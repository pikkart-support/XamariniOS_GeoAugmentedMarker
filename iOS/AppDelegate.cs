using Foundation;
using UIKit;
using CoreGraphics;
using Pikkart.ArSdk.Geo;

namespace XamariniOS_GeoAugmentedMarker
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
	[Register ("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
	
		class GeoViewMarkerAdapter:PKTMarkerViewAdapter {
    
    		public GeoViewMarkerAdapter(CGSize size):base(size) {}
            

        	public override UIView GetView(PKTGeoElement geoElement)  {
            	return new UIImageView(UIImage.FromBundle("map-marker-Yellow.png"));
        	}
        
        	public override UIView GetSelectedView(PKTGeoElement geoElement) {
            	return new UIImageView(UIImage.FromBundle("map-marker-Orange.png"));
        	}
    	}
    
    	class MapViewMarkerAdapter:PKTMarkerViewAdapter {
        
        	public MapViewMarkerAdapter(CGSize size):base(size) {}

        	
       	 	public override UIView GetView(PKTGeoElement geoElement)  {
            	return new UIImageView(UIImage.FromBundle("map-marker-Brown.png"));
        	}
        
        	public override UIView GetSelectedView(PKTGeoElement geoElement) {
            	return new UIImageView(UIImage.FromBundle("map-marker-Black.png"));
        	}
    	}
		// class-level declarations

		public override UIWindow Window {
			get;
			set;
		}
		
		static string kGMapManagerGoogleMapsAPIKey = "AIzaSyA7uiTxeRFbbYaK-Y1j6xmXZtcI8ayOb6Y";

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			// Override point for customization after application launch.
			// If not required for your application you can safely delete this method
			Window = new UIWindow (UIScreen.MainScreen.Bounds);
			PKTGeoMainController.SetGoogleMapsKey(kGMapManagerGoogleMapsAPIKey);
			
 			ViewController geoMain=new ViewController(new GeoViewMarkerAdapter(new CGSize(30,45)),
 													  new MapViewMarkerAdapter(new CGSize(40,40)));
 			 
 			Window.RootViewController=geoMain;
 			
 			Window.MakeKeyAndVisible();
 			
			return true;
		}

		public override void OnResignActivation (UIApplication application)
		{
			// Invoked when the application is about to move from active to inactive state.
			// This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
			// or when the user quits the application and it begins the transition to the background state.
			// Games should use this method to pause the game.
		}

		public override void DidEnterBackground (UIApplication application)
		{
			// Use this method to release shared resources, save user data, invalidate timers and store the application state.
			// If your application supports background exection this method is called instead of WillTerminate when the user quits.
		}

		public override void WillEnterForeground (UIApplication application)
		{
			// Called as part of the transiton from background to active state.
			// Here you can undo many of the changes made on entering the background.
		}

		public override void OnActivated (UIApplication application)
		{
			// Restart any tasks that were paused (or not yet started) while the application was inactive. 
			// If the application was previously in the background, optionally refresh the user interface.
		}

		public override void WillTerminate (UIApplication application)
		{
			// Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
		}
	}
}

