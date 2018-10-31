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

            dynamic dynData = JsonConvert.DeserializeObject<ExpandoObject>(jsonWideCol, new ExpandoObjectConverter());
            var dicObj = (IDictionary<string, object>)dynData;
            if(dicObj.ContainsKey("rows") && dicObj.ContainsKey("columns")) //&& dicObj["rows"].Count == dicObj["columns"].Count
            {
                List<object> lstRows = dynData.rows;
                List<object> lstColumns = dynData.columns;
            }
            List<Dictionary<string, string>> lstDictionary = new List<Dictionary<string, string>>();
            // foreach(var item in dicObj["columns"])

            Console.Read();
        }
    }
}
