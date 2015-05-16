// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace iPhoneApp
{
	[Register ("GPSViewcontroller")]
	partial class GPSViewcontroller
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnShowLocation { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblLatitude { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblLongitude { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (btnShowLocation != null) {
				btnShowLocation.Dispose ();
				btnShowLocation = null;
			}
			if (lblLatitude != null) {
				lblLatitude.Dispose ();
				lblLatitude = null;
			}
			if (lblLongitude != null) {
				lblLongitude.Dispose ();
				lblLongitude = null;
			}
		}
	}
}
