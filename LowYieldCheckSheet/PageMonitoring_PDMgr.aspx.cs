using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iLibrary;


namespace LowYieldCheckSheet
{
    public partial class PageMonitoring_PDMgr : System.Web.UI.Page
    {
        DBAccess dba = new DBAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public string GetImage(string value)
        {

            if (value == "1")
            {
                return "~/Images/NEW_100px.gif";
            }
            else if (value == "2")
            {
                return "~/Images/user2.png";
            }
            else if (value == "3")
            {
                return "~/Images/user3.png";
            }
            else if (value == "4")
            {
                return "~/Images/user4.png";
            }
            else if (value == "5")
            {
                return "~/Images/user5.png";
            }
            else if (value == "5A")
            {
                return "~/Images/user5A.png";
            }
            else if (value == "5B")
            {
                return "~/Images/user5B.png";
            }
            else if (value == "6")
            {
                return "~/Images/user7.png";
            }
            else if (value == "7")
            {
                return "~/Images/user9.png";
            }
            else if (value == "8")
            {
                return "~/Images/user8.png";
            }
            else if (value == "ML1")
            {
                return "~/Images/MLOP1.png";
            }
            else if (value == "ML2")
            {
                return "~/Images/MLGL1.png";
            }
            else if (value == "ML3")
            {
                return "~/Images/MLOP2.png";
            }
            else if (value == "ML4")
            {
                return "~/Images/MLGL2.png";
            }
            else
            {
                return "";
            }

        }

        public object GetYield(string RequestType, object InitialYield, object FinalYield)
        //I can't convert object float value from Database then use Object 
        // The Result is same same (Hell Yeah)
        {
            object re;

            if (RequestType.ToUpper() == "INITIAL")
            {
                re = InitialYield;
            }

            else //if(RequestType == "FINAL")
            {
                re = FinalYield;
            }

            return re;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditSheet")
            {
                string str = Convert.ToString(e.CommandArgument);
                string[] splitSTR = str.Split(',');
                string Process = splitSTR[0];
                string McNo = splitSTR[1];
                string Device = splitSTR[2];
                string LotNo = splitSTR[3];
                string Status = splitSTR[4];
                string project = "LowYieldController";
                string option = "LowYieldOPAction";
                string strUrl;
                string Edit = "FALSE";
                string userId = Request.Params["userId"];

                if (Status == "7") //PD MGr.
                {
                    strUrl = "~/InputPageUser7.aspx?Process=" + Process + "&MCNo=" + McNo + "&Device=" + Device + "&LotNo=" + LotNo + "&User=" + userId + "&Edit=" + Edit;
                    option = "LowYieldPDApprove";
                    Response.Redirect(strUrl);
                }
            }

            else if (e.CommandName == "Option")
            {
                string str = Convert.ToString(e.CommandArgument);
                string[] splitSTR = str.Split(',');
                string Process = splitSTR[0];
                string McNo = splitSTR[1];
                string Device = splitSTR[2];
                string LotNo = splitSTR[3];
                string Status = splitSTR[4];
                txtStoreValue.Text = Process + "," + McNo + "," + Device + "," + LotNo + "," + Status + "," + "OPTION";

                //Call javascript function(in design code side) to show modal input ser number
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openOptionModal();", true);
            }

        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridViewPageMonitoring.DataBind();
            }
        }


        public void GoHistoryAdvance(object sender, EventArgs e)
        {
            Response.Redirect("~/HistoryAdvancePage.aspx");
        }

        public void GoHistoryDaily(object sender, EventArgs e)
        {
            Response.Redirect("~/HistoryDailyPage.aspx");
        }


        protected void BtnSubmitLogin_ServerClick(object sender, EventArgs e)
        {
            string str = txtStoreValue.Text; //get Value from txtStoreValue
            string[] splitSTR = str.Split(',');
            string process = splitSTR[0];
            string mcno = splitSTR[1];
            string device = splitSTR[2];
            string lotno = splitSTR[3];
            string status = splitSTR[4];
            string logtype = splitSTR[5];


            //Message Box
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + Process + " ::" + McNo + " ::" + Device + " ::" + LotNo + " ::" + Status + "')", true);

            var tbl = new DataTable();
            tbl = dba.Login(tbUserID.Value);


            if (tbl.Rows.Count == 0) //if == 0 it's mean no user in system or wrong input
            {
                //Message Box
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User not found ! \\nMay be input UserID wrong or UserID not regist in system.')", true);
            }
            else
            {
                string userId = tbUserID.Value;
                //string project = "CellController";
                //option = "DB-SetupLot";
                string project = "LowYieldController";
                string option = "LowYieldOPAction";
                string strUrl;
                string Edit = "FALSE";

                if (logtype == "CANCEL")
                {
                    option = "LowYieldQYIAction";
                    CheckCancelPermission(userId, project, option);
                }
                else //if logtype = LOGIN or EDIT
                {
                    if (logtype == "LOGIN")
                    {
                        Edit = "FALSE";
                    }
                    else if (logtype == "EDIT")
                    {
                        Edit = "TRUE";
                    }

                    //################################## GO EACH PAGE by STATUS ###################
                    if (status == "1")
                    {
                        strUrl = "~/InputPageUser1.aspx?Process=" + process + "&MCNo=" + mcno + "&Device=" + device + "&LotNo=" + lotno + "&User=" + userId + "&Edit=" + Edit;
                        option = "LowYieldOPAction";
                        CheckPermission(userId, strUrl, project, option);
                    }
                    else if (status == "2")
                    {
                        strUrl = "~/InputPageUser2.aspx?Process=" + process + "&MCNo=" + mcno + "&Device=" + device + "&LotNo=" + lotno + "&User=" + userId + "&Edit=" + Edit;
                        option = "LowYieldTEAction";
                        CheckPermission(userId, strUrl, project, option);
                    }
                    else if (status == "3")
                    {
                        strUrl = "~/InputPageUser3.aspx?Process=" + process + "&MCNo=" + mcno + "&Device=" + device + "&LotNo=" + lotno + "&User=" + userId + "&Edit=" + Edit;
                        option = "LowYieldOPAction";
                        CheckPermission(userId, strUrl, project, option);
                    }
                    else if (status == "4")
                    {
                        strUrl = "~/InputPageUser4.aspx?Process=" + process + "&MCNo=" + mcno + "&Device=" + device + "&LotNo=" + lotno + "&User=" + userId + "&Edit=" + Edit;
                        option = "LowYieldGLAction";
                        CheckPermission(userId, strUrl, project, option);
                    }
                    else if (status == "5")
                    {
                        strUrl = "~/InputPageUser5.aspx?Process=" + process + "&MCNo=" + mcno + "&Device=" + device + "&LotNo=" + lotno + "&User=" + userId + "&Edit=" + Edit;
                        option = "LowYieldQYIAction";
                        CheckPermission(userId, strUrl, project, option);
                    }
                    else if (status == "5A") //this status is differnt other status
                    {
                        option = "LowYieldQYIAction";
                        //this method has check permission and Update Status
                        CheckPermissionQYI1(userId, project, option, process, mcno, lotno, "5B");
                    }
                    else if (status == "5B")
                    {
                        strUrl = "~/InputPageUser5.aspx?Process=" + process + "&MCNo=" + mcno + "&Device=" + device + "&LotNo=" + lotno + "&User=" + userId + "&Edit=" + Edit;
                        option = "LowYieldQYIAction";
                        CheckPermission(userId, strUrl, project, option);
                    }
                    else if (status == "6")
                    {
                        strUrl = "~/InputPageUser6.aspx?Process=" + process + "&MCNo=" + mcno + "&Device=" + device + "&LotNo=" + lotno + "&User=" + userId + "&Edit=" + Edit;
                        option = "LowYieldQYIAction";
                        CheckPermission(userId, strUrl, project, option);
                    }
                    else if (status == "7")
                    {
                        strUrl = "~/InputPageUser7.aspx?Process=" + process + "&MCNo=" + mcno + "&Device=" + device + "&LotNo=" + lotno + "&User=" + userId + "&Edit=" + Edit;
                        option = "LowYieldPDApprove";
                        CheckPermission(userId, strUrl, project, option);
                    }
                    else if (status == "8")
                    {
                        strUrl = "~/InputPageUser8.aspx?Process=" + process + "&MCNo=" + mcno + "&Device=" + device + "&LotNo=" + lotno + "&User=" + userId + "&Edit=" + Edit;
                        option = "LowYieldQCApprove";
                        CheckPermission(userId, strUrl, project, option);
                    }
                    else if (status == "ML1")
                    {
                        strUrl = "~/LotMoveStep1.aspx?Process=" + process + "&MCNo=" + mcno + "&Device=" + device + "&LotNo=" + lotno + "&User=" + userId + "&Edit=" + Edit;
                        option = "LowYieldOPAction";
                        CheckPermission(userId, strUrl, project, option);
                    }
                    else if (status == "ML2")
                    {
                        strUrl = "~/LotMoveStep2.aspx?Process=" + process + "&MCNo=" + mcno + "&Device=" + device + "&LotNo=" + lotno + "&User=" + userId + "&Edit=" + Edit;
                        option = "LowYieldGLAction";
                        CheckPermission(userId, strUrl, project, option);
                    }
                    else if (status == "ML3")
                    {
                        strUrl = "~/LotMoveStep3.aspx?Process=" + process + "&MCNo=" + mcno + "&Device=" + device + "&LotNo=" + lotno + "&User=" + userId + "&Edit=" + Edit;
                        option = "LowYieldOPAction";
                        CheckPermission(userId, strUrl, project, option);
                    }
                    else if (status == "ML4")
                    {
                        strUrl = "~/LotMoveStep4.aspx?Process=" + process + "&MCNo=" + mcno + "&Device=" + device + "&LotNo=" + lotno + "&User=" + userId + "&Edit=" + Edit;
                        option = "LowYieldGLAction";
                        CheckPermission(userId, strUrl, project, option);
                    }
                }

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
                //go to each page by status
                Response.Redirect(strUrl);
            }
        }


        public void CheckCancelPermission(string userId, string project, string option)
        {
            ApcsProService ApcsProService = new ApcsProService();
            UserInfo userInfo = ApcsProService.GetUserInfo(userId);
            //CheckUserPermissionResult result = ApcsProService.CheckUserPermission(userInfo, "CellController", "DB-SetupLot");

            CheckUserPermissionResult result = ApcsProService.CheckUserPermission(userInfo, project, option);

            if (!result.IsPass)
            {
                //Message Box
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User has no permission to cancel lot')", true);
            }
            else
            {
                //Call javascript function(in design code side) to show modal Cancal describe
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openDescribeModal();", true);
            }
        }


        public void CheckPermissionQYI1(string userId, string project, string option, string Process, string MCNo, string LotNo, string Status)
        {
            ApcsProService ApcsProService = new ApcsProService();
            UserInfo userInfo = ApcsProService.GetUserInfo(userId);

            CheckUserPermissionResult result = ApcsProService.CheckUserPermission(userInfo, project, option);

            if (!result.IsPass)
            {
                //Message Box
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User has no permission')", true);
            }
            else
            {
                //update status
                dba.UpdateStatusOnly(Process, MCNo, LotNo, Status);

                //Refresh gridView
                GridViewPageMonitoring.DataBind();

            }
        }

        protected void BtnSubmitDescribe_ServerClick(object sender, EventArgs e)
        {
            string str = txtStoreValue.Text;
            string[] splitSTR = str.Split(',');
            string Process = splitSTR[0];
            string MCNo = splitSTR[1];
            string Device = splitSTR[2];
            string Lotno = splitSTR[3];
            string Status = "CANCEL";
            string Describe = txtDescribe.Value;

            //update status and describe why cancel.
            dba.UpdateCancelStatus(Process, MCNo, Lotno, Status, Describe);

            //move data from monitoring to history table
            dba.MoveToHistory(Process, MCNo, Lotno);

            //delete this data row from monitoring table
            dba.DeleteReportRow(Process, MCNo, Lotno);

            //Message Box
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Cancel Done')", true);

            //refresh gridview monitoring
            GridViewPageMonitoring.DataBind();
        }

        protected void ImBtnCancelLot_Click(object sender, ImageClickEventArgs e)
        {
            string str = txtStoreValue.Text; //get Value from txtStoreValue
            string[] splitSTR = str.Split(',');
            string Process = splitSTR[0];
            string MCNo = splitSTR[1];
            string Device = splitSTR[2];
            string LotNo = splitSTR[3];
            string Status = splitSTR[4];

            //Set Log type to CANCEL
            txtStoreValue.Text = Process + "," + MCNo + "," + Device + "," + LotNo + "," + Status + "," + "CANCEL";


            //Call javascript function(in design code side)
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openLoginModal();", true);
        }

        protected void ImBtnCheckSheet_Click(object sender, ImageClickEventArgs e)
        {
            string str = txtStoreValue.Text; //get Value from txtStoreValue
            string[] splitSTR = str.Split(',');
            string Process = splitSTR[0];
            string MCNo = splitSTR[1];
            string Device = splitSTR[2];
            string LotNo = splitSTR[3];


            Response.Redirect("~/PortalPdfPage.aspx?Process=" + Process + "&MCNo=" + MCNo + "&LotNo=" + LotNo + "&Page=" + "MAIN" + "&ViewType=" + "WORK_SHEET");

        }


        protected void ImBtnEditCheckSheet_Click(object sender, ImageClickEventArgs e)
        {
            //Call javascript function
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openEditModal();", true);
        }


        public void SetTextStore(string Status, string Edit)
        {
            string str = txtStoreValue.Text; //get Value from txtStoreValue
            string[] splitSTR = str.Split(',');
            string Process = splitSTR[0];
            string MCNo = splitSTR[1];
            string Device = splitSTR[2];
            string LotNo = splitSTR[3];
            //string Status = splitSTR[4];
            //string Logtype = splitSTR[5];

            txtStoreValue.Text = Process + "," + MCNo + "," + Device + "," + LotNo + "," + Status + "," + Edit;

            //Call javascript function(in design code side)
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openLoginModal();", true);
        }

        protected void BtnEditUser1_Click(object sender, ImageClickEventArgs e)
        {
            SetTextStore("1", "EDIT");
        }

        protected void BtnEditUser2_Click(object sender, ImageClickEventArgs e)
        {
            SetTextStore("2", "EDIT");
        }

        protected void BtnEditUser3_Click(object sender, ImageClickEventArgs e)
        {
            SetTextStore("3", "EDIT");
        }

        protected void BtnEditUser4_Click(object sender, ImageClickEventArgs e)
        {
            SetTextStore("4", "EDIT");
        }

        protected void BtnEditUser5_Click(object sender, ImageClickEventArgs e)
        {
            SetTextStore("5", "EDIT");
        }

        protected void BtnEditUser6_Click(object sender, ImageClickEventArgs e)
        {
            SetTextStore("6", "EDIT");
        }

        protected void BtnEditUser8_Click(object sender, ImageClickEventArgs e)
        {
            SetTextStore("8", "EDIT");
        }

        protected void BtnEditMLOP1_Click(object sender, ImageClickEventArgs e)
        {
            SetTextStore("ML1", "EDIT");
        }

        protected void BtnEditMLOP2_Click(object sender, ImageClickEventArgs e)
        {
            SetTextStore("ML3", "EDIT");
        }

        protected void BtnEditMLGL1_Click(object sender, ImageClickEventArgs e)
        {
            SetTextStore("ML2", "EDIT");
        }

        protected void BtnEditMLGL2_Click(object sender, ImageClickEventArgs e)
        {
            SetTextStore("ML4", "EDIT");
        }


        public Boolean Isnumeric(string str)
        {
            double Result;
            // String(integer,double),it will return true 
            return double.TryParse(str, out Result);
        }


        public string GetRequestType(string RequestType, object Mode, object AlarmBin)
        {
            //Recieve parameter type object because If gridview have value = Null
            //The value cant convert Null value to string before send to this function then as you see like this 

            string result = "";
            string[] splitStr;
            int i;

            string c_AlarmBin = "";

            if (RequestType.ToUpper() == "INITIAL")
            {
                result = RequestType;
            }
            else
            {
                result = RequestType;
            }

            if (Mode.ToString() == "1")
            {
                result = result + "\n LOW YIELD";
            }
            else if (Mode.ToString() == "2")
            {
                result = result + "\n ALARM ";
            }
            else if (Mode.ToString() == "3")
            {
                result = result + "\n LOW YIELD & ALARM ";
            }

            if (AlarmBin != null)
            {
                c_AlarmBin = AlarmBin.ToString();
            }

            if (AlarmBin.ToString() != "NO")
            {
                splitStr = c_AlarmBin.Split(',');
                if (splitStr.Length >= 1)
                {
                    result = result + "\n";
                    for (i = 0; i < splitStr.Length; i++)
                    {
                        if (i == 0)
                        {
                            result = result + splitStr[i];
                        }
                        else
                        {
                            result = result + "," + splitStr[i];
                        }
                    }
                }
            }
            return result;
        }



        public string GetLCL(string RequestType, object ControlYield, object ControlLCL)
        {
            string result = "";

            if (RequestType == "INITIAL")
            {
                result = ControlYield.ToString();
            }
            else //if RequestType == "FINAL" 
            {
                result = ControlLCL.ToString();
            }

            return result;
        }


    }
}