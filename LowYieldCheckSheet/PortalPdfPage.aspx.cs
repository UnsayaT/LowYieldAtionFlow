using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LowYieldCheckSheet
{
    public partial class HistoryPdfPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["Process"] != "" && Request.Params["MCNo"] != "" && Request.Params["LotNo"] != "")
            {
                if (Request.Params["ViewType"] == "HIST_SHEET")
                {
                    OpenReport.Src = "OpenPdfHistorySheet.aspx?Process=" + Request.Params["Process"] + "&MCNo=" + Request.Params["MCNo"] +
                                    "&LotNo=" + Request.Params["LotNo"];
                }
                else if (Request.Params["ViewType"] == "HIST_MOVELOT")
                {
                    OpenReport.Src = "OpenPdfHistoryMoveLot.aspx?Process=" + Request.Params["Process"] + "&MCNo=" + Request.Params["MCNo"] +
                                    "&LotNo=" + Request.Params["LotNo"];
                }
                else if (Request.Params["ViewType"] == "WORK_SHEET")
                {
                    OpenReport.Src = "OpenPdfWorkSheet.aspx?Process=" + Request.Params["Process"] + "&MCNo=" + Request.Params["MCNo"] +
                                    "&LotNo=" + Request.Params["LotNo"];
                }
            }

        }

        protected void btnBack_ServerClick(object sender, EventArgs e)
        {
            if (Request.Params["Page"] == "HDP") //from HistoryDailyPage
            {
                Response.Redirect("HistoryDailyPage.aspx");
            }
            else if (Request.Params["Page"] == "HAP") //from HistoryAdvancePage
            {
                Response.Redirect("HistoryAdvancePage.aspx");
            }
            else
            {
                Response.Redirect("PageMonitoring.aspx");
            }
            
        }
    }
}