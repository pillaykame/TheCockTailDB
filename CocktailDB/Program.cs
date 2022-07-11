using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CocktailDB
{
    public class Program
    {
        private String sUrl = "http://thecocktaildb.com/api/";
        private String sIngredientUrl = "json/v1/1/search.php?i=";
        private String sCocktailUrl = "json/v1/1/search.php?s=";

        public class SearchIngredientsByName
        {
            public string IngredientID { get; set; }
            public string Ingredient { get; set; }
            public string Description { get; set; }
            public string Type { get; set; }
            public string Alcohol { get; set; }
            public string ABV { get; set; }

        }

        public static void Main(string[] args)
        {
            Program program = new Program();
            program.IngredientTest();
        }

        void IngredientTest()
        {
            Webhelper webServiceClient = new Webhelper();
            String[] saHeader = new String[] { };

            try
            {
                String sReturnData = webServiceClient.CallEndPointJSON(sUrl, sIngredientUrl + "vodka", "", saHeader, "GET");//gets the "endpoint"
                object rvRet = Webhelper.Deserialize(sReturnData);//converts from json string to object 

                var test = JsonConvert.DeserializeObject(sReturnData);

               

                //var myJsonString = "{report: {Id: \"aaakkj98898983\"}}";
                //var jo = JObject.Parse(sReturnData);
                //var id = test["ingredients"]["idIngredient"].ToString();

                //var result = test["ingredients"]["idIngredient"].Value<int>();

                //var data = (JObject)JsonConvert.DeserializeObject(sReturnData);
                //var result1 = data["ingredients"]["idIngredient"].Value<int>();


                //var jvalue = (JValue)jobject["ingredients"]["idIngredient"];
                //Console.WriteLine(jvalue.Value); // 2098

                //var result = data.SelectToken("ingredients.idIngredient").ToString();
                //JToken outer = JToken.Parse(sReturnData);
                //JObject inner = outer["ingredients"].Value<JObject>();

                //List<string> keys = inner.Properties().Select(p => p.Name).ToList();

                ////foreach (string k in keys)
                ////{
                ////    Console.WriteLine(k);
                ////}

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }





    }

    //private DataTable objToDataTable(Mktdetails obj)
    //{
    //    DataTable dt = new DataTable();
    //    Mktdetails objmkt = new Mktdetails();
    //    dt.Columns.Add("Column_Name");
    //    foreach (PropertyInfo info in typeof(Mktdetails).GetProperties())
    //    {
    //        dt.Rows.Add(info.Name);
    //    }
    //    dt.AcceptChanges();
    //    return dt;
    //}




    
}
