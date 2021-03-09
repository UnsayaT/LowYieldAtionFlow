using iLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LowYieldCheckSheet
{
    public partial class RequestLogin : System.Web.UI.Page
    {
        DBAccess dba = new DBAccess();

        string process;
        string mcno;
        string device;
        string lotno;
        string amountNG;
        string package;
        string flow;
        string mno;
        string testerNo;
        string inputQty;
        string controlYield;
        string mode;
        string requesttype;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Call javascript function(in design code side) to show modal input ser number
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openLoginModal();", true);
        }

        protected void BtnSubmitLogin_ServerClick(object sender, EventArgs e)
        {
            process = Request.Params["Process"];
            mcno = Request.Params["MCNo"];
            device = Request.Params["Device"];
            lotno = Request.Params["LotNo"];
            amountNG = Request.Params["AmountNG"];
            package = Request.Params["Package"];
            flow = Request.Params["Flow"];
            mno = Request.Params["MNo"];
            testerNo = Request.Params["TesterNo"];
            inputQty = Request.Params["Input"];
            controlYield = Request.Params["Control"];
            mode = Request.Params["Mode"];
            requesttype = Request.Params["RequestType"];

            var tbl = new DataTable();
            tbl = dba.Login(tbUserID.Value);

            if (tbl.Rows.Count == 0) //if == 0 it's mean no user in system or wrong input
            {
                //Message Box
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User not found ! \\nMay be input UserID wrong or UserID not regist in system.')", true);
            }
            else
            {
                string userId = tbUserID.Value; //value from textbox
                string project = "LowYieldController";
                string option = "LowYieldOPAction"; //this login only for OP request
                string strUrl;
                string Edit = "FALSE"; //Fix it's not edit page

                //This Login is only for PageUser1
                strUrl = "~/InputPageUser1.aspx?Process=" + process + "&MCNo=" + mcno + "&Device=" + device + "&LotNo=" + lotno + "&AmountNG=" + amountNG + "&Package=" + package + "&Flow=" + flow + "&MNo=" + mno + "&TesterNo=" + testerNo + "&Input=" + inputQty + "&Control=" + controlYield + "&User=" + userId + "&Edit=" + Edit + "&Mode=" + mode + "&RequestType=" + requesttype;
                //CheckPermission(userId, strUrl, project, option);
                Response.Redirect(strUrl);
                //strUrl = "~/InputPageUser1.aspx?Process=" + process + "&MCNo=" + mcno + "&Device=" + device + "&LotNo=" + lotno + "&User=" + userId + "&Edit=" + Edit;
                //CheckPermission(userId, strUrl, project, option);

            }


        }


        public void CheckPermission(string userId, string strUrl, string project, string option)
        {
            ApcsProService ApcsProService = new ApcsProService();
            UserInfo userInfo = ApcsProService.GetUserInfo(userId);
            //CheckUserPermissionResult result = ApcsProService.CheckUserPermission(userInfo, "CellController", "DB-SetupLot");

            CheckUserPermissionResult result = ApcsProService.CheckUserPermission(userInfo, project, option);

            if (!result.IsPass)
            {
                //Message Box
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User has no permission')", true);
            }
            else
            {
                //go to url page
                Response.Redirect(strUrl);
            }
        }




    }
}