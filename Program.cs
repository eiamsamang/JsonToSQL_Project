using System.IO;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using JsonToSQL_Project.DAL;
using System.Linq;

namespace JsonToSQL_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadJsonToSQL();
        }

        private static void ReadJsonToSQL()
        {
            var jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "JsonFiles", "output.json");
            using (StreamReader sr = new StreamReader(jsonPath))
            {
                var jsonData = sr.ReadToEnd();
                if (jsonData != null)
                {
                    var jsonDatalist = JsonConvert.DeserializeObject<List<CLSJSonConv>>(jsonData);
                    if (jsonDatalist.Count() > 0)
                    {
                        var dataStore = new List<TbJson>();
                        foreach (var data in jsonDatalist)
                        {
                            TbJson t = new TbJson()
                            {
                                Fname = data.Column2,
                                Lname = data.Column3
                            };
                            dataStore.Add(t);
                        }
                        if (dataStore.Count() > 0)
                        {
                            using (dbYTContext dbConn = new dbYTContext())
                            {
                                dbConn.TbJsons.AddRange(dataStore);
                                dbConn.SaveChanges();
                            }
                        }

                    }
                }
            }
        }
    }
    class CLSJSonConv
    {
        public string Column1 { get; set; }
        public string Column2 { get; set; }
        public string Column3 { get; set; }
    }
}
