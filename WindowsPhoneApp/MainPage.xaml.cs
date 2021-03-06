﻿using CommonLibrary;
using CommonLibrary.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace WindowsPhoneApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
		IDBManager db;

		public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

			var sqliteFilename = "tekst.db";            
			string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);

			db = new DBManager(path);

			FillList();
		}

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

		private void btnSave_Click(object sender, RoutedEventArgs e)
		{
			newText(txtText.Text);
			FillList();
		}

		public void newText(string text)
		{
			/*tekstDao = new TekstDao(this, null, null, 1);

			Tekst tekst = new Tekst(txtTekst.getText().toString());

			tekstDao.addTekst(tekst);*/
			db.executeQuery(string.Format("insert into tekst values(null, '{0}');", text));
			txtText.Text = "";
		}

		private void FillList()
		{
			List<Tekst> values = (db.LoadDataFromDB("select * from tekst")).Cast<Tekst>().ToList();

			lvTexts.ItemsSource = values;
		}
	}
}
