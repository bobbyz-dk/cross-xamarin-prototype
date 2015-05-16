using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
	public interface IDBManager
	{
		List<object> LoadDataFromDB(string query);
		void executeQuery(string query);
    }
}
