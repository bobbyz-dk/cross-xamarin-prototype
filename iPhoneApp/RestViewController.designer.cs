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
	[Register ("RestViewController")]
	partial class RestViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnGet { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnPost { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView tblComments { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtComment { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtEmail { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (btnGet != null) {
				btnGet.Dispose ();
				btnGet = null;
			}
			if (btnPost != null) {
				btnPost.Dispose ();
				btnPost = null;
			}
			if (tblComments != null) {
				tblComments.Dispose ();
				tblComments = null;
			}
			if (txtComment != null) {
				txtComment.Dispose ();
				txtComment = null;
			}
			if (txtEmail != null) {
				txtEmail.Dispose ();
				txtEmail = null;
			}
		}
	}
}
