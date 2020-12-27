using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using CsvHelper;
using System.IO;
using System.Reflection;
using System.Globalization;

namespace INCIreader
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);           

            if (!IfTableExists("Ingredient"))
            {
                _database.CreateTableAsync<Ingredient>().Wait();
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = "INCIreader.InciTable.csv";

                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                using (StreamReader reader = new StreamReader(stream))

                {
                    if (reader != null)
                    {
                        using (var csv = new CsvReader(reader, CultureInfo.CurrentCulture))
                        {
                            csv.Configuration.Delimiter = ";";
                            var records = csv.GetRecords<Ingredient>();

                            foreach (Ingredient x in records)
                            {

                                Console.WriteLine(x.ID);
                                SaveIngAsync(x);
                            }

                        }
                    }


                }
            }

        }


        public Task<List<Ingredient>> GetIngsAsync()
        {          
          return _database.Table<Ingredient>().ToListAsync();
        }

        public Task<int> SaveIngAsync(Ingredient person)
        {
            return _database.InsertAsync(person);
        }


        public bool IfTableExists(string tableName)
        {
            try
            {
                var tableInfo = _database.GetConnection().GetTableInfo(tableName);
                if (tableInfo.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }

}
