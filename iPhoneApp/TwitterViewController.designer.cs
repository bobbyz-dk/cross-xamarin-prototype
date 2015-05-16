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
	[Register ("TwitterViewController")]
	partial class TwitterViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnName { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblResult { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView TwitterView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtScreenName { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (btnName != null) {
				btnName.Dispose ();
				btnName = null;
			}
			if (lblResult != null) {
				lblResult.Dispose ();
				lblResult = null;
			}
			if (TwitterView != null) {
				TwitterView.Dispose ();
				TwitterView = null;
			}
			if (txtScreenName != null) {
				txtScreenName.Dispose ();
				txtScreenName = null;
			}
		}
	}
}
