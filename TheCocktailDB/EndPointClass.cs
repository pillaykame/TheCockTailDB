using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace TheCocktailDB
{
   public class EndPointClass
    {
        #region Constructors
        public EndPointClass() { }

        #endregion

        #region Private Fields

        private String _EndPointName; //End point name
        private Hashtable _Parameters = new Hashtable(); //End point parameters

        #endregion

        #region Public Properties

        public String EndPointName { get { return _EndPointName; } set { _EndPointName = value; } } //End point name
        public Hashtable Parameters { get { return _Parameters; } set { _Parameters = value; } } //End point parameters

        #endregion
    }
}
