using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;
using CommonLibrary.model;

namespace CommonLibrary
{
	public class DBManager : IDBManager
	{
		private SQLiteConnection connection;
		private List<object> results;
		private List<string> columnNames;
		private string dbPath;

		public DBManager(string dbPath)
		{
			this.dbPath = dbPath;
			using (connection = new SQLiteConnection(dbPath))
			{
				using (var statement = connection.Prepare("CREATE TABLE IF NOT EXISTS tekst(id INTEGER PRIMARY KEY, tekst TEXT);"))
				{
					statement.Step();
				}
			}
        }

		public void executeQuery(string query)
		{
			this.runQuery(query, true);
		}

		public List<object> LoadDataFromDB(string query)
		{
			this.runQuery(query, false);
			return results;
		}

		private void runQuery(string query, bool isQueryExecutable)
		{
			if (this.results != null)
			{
				this.results.RemoveAll(all());
				this.results = null;
            }
			results = new List<object>();

			if (this.columnNames != null)
			{
				this.columnNames.RemoveAll(all());
				this.columnNames = null;
			}
			columnNames = new List<string>();

			var queriedRecords = new List<Tekst>();

			using (connection = new SQLiteConnection(dbPath))
			{
				
				if (!isQueryExecutable)
				{
					using (var statement = connection.Prepare(query))
					{
						int totalColumns = statement.ColumnCount;
						while (statement.Step() == SQLiteResult.ROW)
						{
							var id = (long)statement[0];
							var t = (string)statement[1];

							queriedRecords.Add(new Tekst((int)id, t));
						}
						results = queriedRecords.Cast<object>().ToList();
						for (int i = 0; columnNames.Count > totalColumns; i++)
						{
							columnNames.Add(statement.ColumnName(i));
						}
					}
				}
				else
				{
					using (var statement = connection.Prepare(query))
					{
						statement.Step();
					}
				}
			}
		}

		static Predicate<object> all()
		{
			return delegate (object obj)
			{
				return true;
			};
		}
		
	}
}
