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
	[Register ("RootViewController")]
	partial class RootViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnGem { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView tblTekst { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtTekst { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (btnGem != null) {
				btnGem.Dispose ();
				btnGem = null;
			}
			if (tblTekst != null) {
				tblTekst.Dispose ();
				tblTekst = null;
			}
			if (txtTekst != null) {
				txtTekst.Dispose ();
				txtTekst = null;
			}
		}
	}
}
