using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace CocktailDB
{
    class Webhelper
    {
        public Webhelper()
        {

        }
        public String CallEndPointJSON(String psRemoteWebServiceURL, String psEndPointName, String sJsonPost, String[] saSpecialHeaders = null, String psMethod = "POST")
        {
            Byte[] data;
            String sJsonResult = "";
            using (WebClient client = new WebClient())
            {
                try
                {
                    client.BaseAddress = psRemoteWebServiceURL;
                    client.Headers.Add("Content-Type", "application/json");//sending a json request
                    client.Headers.Add("Accept", "application/json");
                    foreach (String header in saSpecialHeaders)
                    {
                        if (!String.IsNullOrEmpty(header))
                        {
                            client.Headers.Add(header);
                        }
                    }

                    UTF8Encoding encoding = new UTF8Encoding();
                    String sSlash = "/";
                    if (client.BaseAddress.ToString()[client.BaseAddress.ToString().Length - 1] == '/')
                    {
                        sSlash = "";
                    }

                    if (psMethod == "PUT" || psMethod == "POST" || psMethod == "DELETE")
                    {
                        data = client.UploadData(new Uri(client.BaseAddress + sSlash + psEndPointName), psMethod, encoding.GetBytes(sJsonPost));
                    }
                    else
                    {
                        data = client.DownloadData(client.BaseAddress + sSlash + psEndPointName);
                    }
                    //JavaScriptSerializer ser = new JavaScriptSerializer();
                    //ser.MaxJsonLength = Int32.MaxValue;
                    MemoryStream ms = new MemoryStream(data);

                    // convert stream to string
                    StreamReader reader = new StreamReader(ms);
                    sJsonResult = reader.ReadToEnd();
                }
                catch (WebException exception)
                {
                    if (exception.Response != null)
                    {
                        string responseText;

                        using (var reader = new StreamReader(exception.Response.GetResponseStream()))
                        {
                            responseText = reader.ReadToEnd();
                            throw new Exception(responseText);
                        }
                    }
                    else
                    {
                        throw exception;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }
            }

            return sJsonResult;
        }
        
        public static object Deserialize(String sJsonResult)
        {
            Object obj = null;

            try
            {
                var serializer = new JavaScriptSerializer();
                serializer.MaxJsonLength = int.MaxValue;

                obj = serializer.DeserializeObject(sJsonResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            return obj;
        }

    }
}
