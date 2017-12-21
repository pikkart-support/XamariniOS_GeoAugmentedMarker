using System;
using UIKit;
using Pikkart.ArSdk.Geo;
using System.Collections.Generic;
using CoreLocation;

namespace XamariniOS_GeoAugmentedMarker
{
	public partial class ViewController : PKTGeoMainController
	{
		
		public ViewController():base() {}
		
		public ViewController(PKTMarkerViewAdapter  geoAdapter, 
							  PKTMarkerViewAdapter	mapAdapter):base(geoAdapter, mapAdapter) {}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			Dictionary<string, CLLocation> poiNames=new Dictionary<string, CLLocation>();
			PKTGeoLocation geoLocation;
			PKTGeoElement geoElement;
			List<PKTGeoElement> geoElements=new List<PKTGeoElement>();			
			poiNames.Add("COOP, Modena",new CLLocation(44.654894,10.914749));
			poiNames.Add("Burger King, Modena",new CLLocation(44.653505,10.909653));
			poiNames.Add("Piazza Matteotti, Modena",new CLLocation(44.647315,10.924802));
        	var index = 0;
        	foreach (var pair in poiNames)  {
           		geoLocation = new PKTGeoLocation(pair.Value.Coordinate.Latitude, pair.Value.Coordinate.Longitude,0);
           		geoElement = new PKTGeoElement(geoLocation, index+pair.Key, pair.Key);
           		geoElements.Add(geoElement);
           		index = index + 1;
        	}
            DisableRecognition();
            EnableGeoAR();
            EnableGeoMap();
        	Show(geoElements.ToArray());
		}
		
		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
			
		}
		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.		
		}
	}
}
