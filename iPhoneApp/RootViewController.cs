using System;
using System.Drawing;

using Foundation;
using UIKit;

using CommonLibrary;
using System.IO;
using System.Collections.Generic;
using CommonLibrary.model;

namespace iPhoneApp
{
	public partial class RootViewController : UIViewController
	{
		IDBManager db;

		public RootViewController(IntPtr handle) : base(handle)
		{
		}

		public override void DidReceiveMemoryWarning()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning();

			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			// Perform any additional setup after loading the view, typically from a nib.
			this.txtTekst.ShouldReturn += (textField) =>
			{
				textField.ResignFirstResponder();
				return true;
			};

			var sqliteFilename = "tekst.db";
			string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
			string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
			var path = Path.Combine(libraryPath, sqliteFilename);
			db = new DBManager(path);
			FillList();
		}

		private void FillList()
		{
			List<Tekst> values = (db.LoadDataFromDB("select * from tekst")).ConvertAll<Tekst>(x => (Tekst)x);
			tblTekst.Source = new TableSource(values);
			tblTekst.ReloadData();
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			btnGem.TouchUpInside += (sender, e) => {
				saveText(txtTekst.Text);
				FillList();
            };
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
		}

		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);
		}

		public override void ViewDidDisappear(bool animated)
		{
			base.ViewDidDisappear(animated);
		}

		#endregion

		public void saveText(string text)
		{
			db.executeQuery(string.Format("insert into tekst values(null, '{0}');", text));
			txtTekst.Text = "";
		}
	}
}