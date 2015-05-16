using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using CommonLibrary;
using System.IO;
using System.Collections.Generic;
using CommonLibrary.model;

namespace AndroidApp
{
	[Activity(Label = "AndroidApp"/*, MainLauncher = true, Icon = "@drawable/icon"*/)]
	public class MainActivity : Activity
	{
		EditText txtTekst;
		Button btnGem;
		ListView list;

		IDBManager db;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			var sqliteFilename = "tekst.db";
			string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
			var path = Path.Combine(documentsPath, sqliteFilename);
			db = new DBManager(path);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			txtTekst = FindViewById<EditText>(Resource.Id.txtTekst);
			btnGem = (Button)FindViewById(Resource.Id.btnGem);
			list = (ListView)FindViewById(Resource.Id.list);

			btnGem.Click += delegate { newTekst(txtTekst.Text); };

			fillList();
		}
		public void newTekst(string tekst)
		{
			/*tekstDao = new TekstDao(this, null, null, 1);

			Tekst tekst = new Tekst(txtTekst.getText().toString());

			tekstDao.addTekst(tekst);*/
			db.executeQuery(string.Format("insert into tekst values(null, '{0}');", tekst));
			txtTekst.Text = "";
			
			fillList();
		}

		private void fillList()
		{
			List<Tekst> values = (db.LoadDataFromDB("select * from tekst")).ConvertAll<Tekst>(x => (Tekst)x);

			// use the SimpleCursorAdapter to show the
			// elements in a ListView
			ArrayAdapter<Tekst> adapter = new ArrayAdapter<Tekst>(this, Android.Resource.Layout.SimpleListItem1, values);
			list.Adapter = adapter;
		}
	}
}

