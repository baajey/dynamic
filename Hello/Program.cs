using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonKeyVal = System.IO.File.ReadAllText(@"C:\Users\manis\source\repos\Hello\JsonData.KeyVal.json");
            string jsonWideCol = System.IO.File.ReadAllText(@"C:\Users\manis\source\repos\Hello\JsonData.Wide.json");
            bool isWideColumn = false;
            List<Dictionary<string, string>> lstDictionary = new List<Dictionary<string, string>>();

            dynamic dynData = JsonConvert.DeserializeObject<ExpandoObject>(jsonWideCol, new ExpandoObjectConverter());


            var dicObj = (IDictionary<string, object>)dynData;
            List<string> columnNames = new List<string>();
            if (dicObj.ContainsKey("rows") && dicObj.ContainsKey("columns"))
            {
                List<object> lstRows = dynData.rows;
                List<object> lstColumns = dynData.columns;
                Dictionary<string, string> eachVal = new Dictionary<string, string>();
                foreach (dynamic e in lstColumns)
                {
                    columnNames.Add((string)e.name);
                }
                foreach (dynamic e in lstRows)
                {
                    int i = 0;
                    foreach (dynamic f in e)
                    {

                        eachVal[columnNames[i]] = Convert.ToString(f);
                        i++;
                    }

                    lstDictionary.Add(eachVal);
                    eachVal = new Dictionary<string, string>();
                }
            }



            Console.Read();
        }
    }
}
