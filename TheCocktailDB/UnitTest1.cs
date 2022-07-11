using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;
using System.Web.UI;
using System.Data;


namespace TheCocktailDB
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public System.String TestMethod1()
        {
             System.String lRet = "";

             try
             {
                IngredientByName();
                 //lRet = ;
             }
             catch (Exception ex)
             {
                 throw ex;
             }
             finally
             {
                 
             }
             return lRet;
            
        }

        private void IngredientByName()
        {
            System.String sparam = "";
            System.String sIngreadientName = " www.thecocktaildb.com/api/json/v1/1/search.php?";
            //sIngreadientName.
        }

        
    }
}
