using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LowYieldCheckSheet
{
    public partial class UpdateTotalNG : System.Web.UI.Page
    {
        DBAccess dba = new DBAccess();
        GlobalClass gc = new GlobalClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            gc.LotNo = Request.Params["LotNo"]; //get parameter from url
            gc.TotalNG = Int32.Parse(Request.Params["AmountNG"]); //get parameter from url


            dba.UpdateAmountNG(gc.LotNo, gc.TotalNG);
        }
    }
}