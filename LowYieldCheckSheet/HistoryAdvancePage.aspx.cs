using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iLibrary;
using System.Data;

namespace LowYieldCheckSheet
{
    public partial class HistoryAdvancePage : System.Web.UI.Page
    {
        DBAccess dba = new DBAccess();
        string user;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }


        public object GetYield(string RequestType, object InitialYield, object FinalYield)
        //I can't convert object float value from Database then use Object 
        //But the result is same same (Hell Yeah)
        {
            object re;

            if (RequestType == "INITIAL")
            {
                re = InitialYield;
            }

            else //if(RequestType == "FINAL")
            {
                re = FinalYield;
            }

            return re;
        }

        public string getCause(object CheckLowYieldKanban, object Cause)
        {
            string re = "";
            string ck = CheckLowYieldKanban.ToString();
            string cc = Cause.ToString();

            if (!string.IsNullOrEmpty(ck) && ck != "NO")
            {
                re = ck;
            }
            else
            {
                re = cc;
            }

            return re;
        }

        //Add 2019-03-01
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
        //End Add

        protected void btnSearch_ServerClick(object sender, EventArgs e)
        {
            string strSQL;

            string process = "%";
            string mcno = "%";
            string lotno = "%";
            string package = "%";
            string device = "%";

            //DateTime date1 = DateTime.Today.AddHours(8).AddMinutes(00);
            //DateTime date2 = DateTime.Today.AddHours(7).AddMinutes(59).AddSeconds(59);
            DateTime date1 = Convert.ToDateTime("1990/01/01");
            DateTime date2 = DateTime.Today;


            if (SearchSelect1.SelectedIndex != 0)
            {
                if (SearchSelect1.SelectedIndex == 1)
                {
                    process = "FL";
                }
                else if (SearchSelect1.SelectedIndex == 2)
                {
                    process = "FT";
                }
                else //select 3
                {
                    process = "MAPPING";
                }
            }

            if (tbMCNo.Value != "")
            {
                mcno = "%" + tbMCNo.Value + "%";
            }

            if (tbLotNo.Value != "")
            {
                lotno = "%" + tbLotNo.Value + "%";
            }

            if (tbPackage.Value != "")
            {
                package = "%" + tbPackage.Value + "%";
            }

            if (tbDevice.Value != "")
            {
                device = "%" + tbDevice.Value + "%"; 
            }

            if (SearchDate1.Value != "")
            {
                date1 = Convert.ToDateTime(SearchDate1.Value);
                //date1 = date1.AddHours(8).AddMinutes(00);
            }

            if (SearchDate2.Value != "")
            {
                date2 = Convert.ToDateTime(SearchDate2.Value);
                //date2 = date2.AddDays(+1).AddHours(7).AddMinutes(59).AddSeconds(59);
            }


            strSQL = "SELECT [Process], [HandlerNo], [LotNo], [PackageName], [DeviceName], [RequestDate], [RequestType], [Flow]," +
                " [InitialYield], [ControlYield], [FinalYield], [ControlLCL], [CheckLowYieldKanban], [Cause],[CheckAlarmBin],[Mode] FROM [LowYieldActionHistory]" +
                "WHERE Process LIKE '" + process + "' AND HandlerNo LIKE '" + mcno + "' AND  LotNo LIKE '" + lotno + "' AND PackageName LIKE '" + package + "' " +
                "AND DeviceName LIKE '" + device + "' AND RequestDate BETWEEN '" + date1 + "' AND '" + date2 + "' " +
                "ORDER BY RequestDate DESC";

            SqlDataSource1.SelectCommand = strSQL;
            GridView1.DataBind();

        }

        protected void btnBack_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("PageMonitoring.aspx");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewSheet")
            {
                string str = Convert.ToString(e.CommandArgument);
                string[] splitSTR = str.Split(',');
                string Process = splitSTR[0];
                string MCNo = splitSTR[1];
                string LotNo = splitSTR[2];
                //Response.Redirect("~/HistoryDataSheet.aspx?Process=" + Process + "&MCNo=" + MCNo + "&LotNo=" + LotNo);
                Response.Redirect("~/PortalPdfPage.aspx?Process=" + Process + "&MCNo=" + MCNo + "&LotNo=" + LotNo + "&Page=" + "HAP" + "&ViewType=" + "HIST_SHEET");
            }

            else if (e.CommandName == "ViewMoveLot")
            {
                string str = Convert.ToString(e.CommandArgument);
                string[] splitSTR = str.Split(',');
                string Process = splitSTR[0];
                string MCNo = splitSTR[1];
                string LotNo = splitSTR[2];
                //Response.Redirect("~/HistoryDataSheet.aspx?Process=" + Process + "&MCNo=" + MCNo + "&LotNo=" + LotNo);
                Response.Redirect("~/PortalPdfPage.aspx?Process=" + Process + "&MCNo=" + MCNo + "&LotNo=" + LotNo + "&Page=" + "HAP" + "&ViewType=" + "HIST_MOVELOT");
            }
            else if (e.CommandName == "Option")
            {
                string str = Convert.ToString(e.CommandArgument);
                string[] splitSTR = str.Split(',');
                string Process = splitSTR[0];
                string MCNo = splitSTR[1];
                string LotNo = splitSTR[2];
                txtStoreValue.Text = Process + "," + MCNo + "," + LotNo + ","  + "OPTION";

                //Call javascript function(in design code side) to show modal input ser number
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openOptionModal();", true);
            }
        }

        protected void ImBtnEditCheckSheet_Click(object sender, ImageClickEventArgs e)
        {
            //Call javascript function
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openEditModal();", true);
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
                       
                        option = "LowYieldOPAction";
                       

                        var tblOP = new DataTable();
                        tblOP = dba.CheckPermissionOP(userId);
                        //strUrl = "~/InputPageUser5.aspx?Process=" + Process + "&MCNo=" + McNo + "&Device=" + Device + "&LotNo=" + LotNo + "&User=" + userId + "&Edit=" + Edit;

                        if (tblOP.Rows.Count == 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User has no permission')", true);
                        }
                        else
                        {
                            //Response.Redirect(strUrl);
                        }

                    }
                    else if (status == "2")
                    {
                        //strUrl = "~/InputPageUser2.aspx?Process=" + process + "&MCNo=" + mcno + "&Device=" + device + "&LotNo=" + lotno + "&User=" + userId + "&Edit=" + Edit;
                        option = "LowYieldTEAction";
                        //CheckPermission(userId, strUrl, project, option);
                        var tblQYI = new DataTable();
                        tblQYI = dba.CheckPermissionQYI(userId);

                        if (tblQYI.Rows.Count == 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User has no permission')", true);
                        }
                        else
                        {
                            //Response.Redirect(strUrl);
                        }
                    }
                    else if (status == "3")
                    {
                        //strUrl = "~/InputPageUser3.aspx?Process=" + process + "&MCNo=" + mcno + "&Device=" + device + "&LotNo=" + lotno + "&User=" + userId + "&Edit=" + Edit;
                        option = "LowYieldOPAction";

                        //CheckPermission(userId, strUrl, project, option);

                        var tblOP = new DataTable();
                        tblOP = dba.CheckPermissionOP(userId);

                        if (tblOP.Rows.Count == 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User has no permission')", true);
                        }
                        else
                        {
                            //Response.Redirect(strUrl);
                        }
                    }
                    else if (status == "4")
                    {
                        //strUrl = "~/InputPageUser4.aspx?Process=" + process + "&MCNo=" + mcno + "&Device=" + device + "&LotNo=" + lotno + "&User=" + userId + "&Edit=" + Edit;
                        option = "LowYieldGLAction";
                        //CheckPermission(userId, strUrl, project, option);
                        var tblGL = new DataTable();
                        tblGL = dba.CheckPermissionGL(userId);

                        if (tblGL.Rows.Count == 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User has no permission')", true);
                        }
                        else
                        {
                            //Response.Redirect(strUrl);
                        }

                    }
                    else if (status == "5")
                    {
                        //strUrl = "~/InputPageUser5.aspx?Process=" + process + "&MCNo=" + mcno + "&Device=" + device + "&LotNo=" + lotno + "&User=" + userId + "&Edit=" + Edit;
                        option = "LowYieldQYIAction";
                        //CheckPermission(userId, strUrl, project, option);
                        var tblQYI = new DataTable();
                        tblQYI = dba.CheckPermissionQYI(userId);

                        if (tblQYI.Rows.Count == 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User has no permission')", true);
                        }
                        else
                        {
                            //Response.Redirect(strUrl);
                        }
                    }
                    else if (status == "5A") //this status is differnt other status
                    {
                        option = "LowYieldQYIAction";
                        //this method has check permission and Update Status
                        //CheckPermissionQYI1(userId, project, option, process, mcno, lotno, "5B");
                        var tblQYI = new DataTable();
                        tblQYI = dba.CheckPermissionQYI(userId);

                        if (tblQYI.Rows.Count == 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User has no permission')", true);
                        }
                        else
                        {
                            //update status
                            dba.UpdateStatusOnly(process, mcno, lotno, "5B");

                            //Refresh gridView
                            GridView1.DataBind();
                        }
                    }
                    else if (status == "5B")
                    {
                        //strUrl = "~/InputPageUser5.aspx?Process=" + process + "&MCNo=" + mcno + "&Device=" + device + "&LotNo=" + lotno + "&User=" + userId + "&Edit=" + Edit;
                        option = "LowYieldQYIAction";
                        //CheckPermission(userId, strUrl, project, option);
                        var tblQYI = new DataTable();
                        tblQYI = dba.CheckPermissionQYI(userId);

                        if (tblQYI.Rows.Count == 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User has no permission')", true);
                        }
                        else
                        {
                            //Response.Redirect(strUrl);
                        }
                    }
                    else if (status == "5C")
                    {
                        //strUrl = "~/InputPageUser9.aspx?Process=" + process + "&MCNo=" + mcno + "&Device=" + device + "&LotNo=" + lotno + "&User=" + userId + "&Edit=" + Edit;
                        option = "LowYieldQYIAction";
                        // CheckPermission(userId, strUrl, project, option);
                        var tblQYI = new DataTable();
                        tblQYI = dba.CheckPermissionQYI(userId);

                        if (tblQYI.Rows.Count == 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User has no permission')", true);
                        }
                        else
                        {
                            //Response.Redirect(strUrl);
                        }
                    }
                    else if (status == "6")
                    {
                        //strUrl = "~/InputPageUser6.aspx?Process=" + process + "&MCNo=" + mcno + "&Device=" + device + "&LotNo=" + lotno + "&User=" + userId + "&Edit=" + Edit;
                        option = "LowYieldQYIAction";
                        //CheckPermission(userId, strUrl, project, option);
                        var tblQYI = new DataTable();
                        tblQYI = dba.CheckPermissionQYI(userId);

                        if (tblQYI.Rows.Count == 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User has no permission')", true);
                        }
                        else
                        {
                            //Response.Redirect(strUrl);
                        }
                    }
                    else if (status == "7")
                    {
                        //strUrl = "~/InputPageUser7.aspx?Process=" + process + "&MCNo=" + mcno + "&Device=" + device + "&LotNo=" + lotno + "&User=" + userId + "&Edit=" + Edit;
                        option = "LowYieldPDApprove";
                        //CheckPermission(userId, strUrl, project, option);
                        var tblMGR = new DataTable();
                        tblMGR = dba.CheckPermissionMGR(userId);

                        if (tblMGR.Rows.Count == 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User has no permission')", true);
                        }
                        else
                        {
                            //Response.Redirect(strUrl);
                        }
                    }
                    else if (status == "8")
                    {
                        //strUrl = "~/InputPageUser8.aspx?Process=" + process + "&MCNo=" + mcno + "&Device=" + device + "&LotNo=" + lotno + "&User=" + userId + "&Edit=" + Edit;
                        option = "LowYieldQCApprove";
                        //CheckPermission(userId, strUrl, project, option);
                        var tblQC = new DataTable();
                        tblQC = dba.CheckPermissionQC(userId);

                        if (tblQC.Rows.Count == 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User has no permission')", true);
                        }
                        else
                        {
                            //Response.Redirect(strUrl);
                        }
                    }
                    else if (status == "8B")
                    {
                        //strUrl = "~/InputPageUser10.aspx?Process=" + process + "&MCNo=" + mcno + "&Device=" + device + "&LotNo=" + lotno + "&User=" + userId + "&Edit=" + Edit;
                        option = "LowYieldQCApprove";
                        //CheckPermission(userId, strUrl, project, option);
                        var tblQC = new DataTable();
                        tblQC = dba.CheckPermissionQC(userId);

                        if (tblQC.Rows.Count == 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User has no permission')", true);
                        }
                        else
                        {
                            //Response.Redirect(strUrl);
                        }
                    }
                    else if (status == "ML1")
                    {
                        //strUrl = "~/LotMoveStep1.aspx?Process=" + process + "&MCNo=" + mcno + "&Device=" + device + "&LotNo=" + lotno + "&User=" + userId + "&Edit=" + Edit;
                        option = "LowYieldOPAction";
                        //CheckPermission(userId, strUrl, project, option);
                    }
                    else if (status == "ML2")
                    {
                        //strUrl = "~/LotMoveStep2.aspx?Process=" + process + "&MCNo=" + mcno + "&Device=" + device + "&LotNo=" + lotno + "&User=" + userId + "&Edit=" + Edit;
                        option = "LowYieldGLAction";
                        //CheckPermission(userId, strUrl, project, option);
                    }
                    else if (status == "ML3")
                    {
                        //strUrl = "~/LotMoveStep3.aspx?Process=" + process + "&MCNo=" + mcno + "&Device=" + device + "&LotNo=" + lotno + "&User=" + userId + "&Edit=" + Edit;
                        option = "LowYieldOPAction";
                        //CheckPermission(userId, strUrl, project, option);
                    }
                    else if (status == "ML4")
                    {
                        //strUrl = "~/LotMoveStep4.aspx?Process=" + process + "&MCNo=" + mcno + "&Device=" + device + "&LotNo=" + lotno + "&User=" + userId + "&Edit=" + Edit;
                        option = "LowYieldGLAction";
                        //CheckPermission(userId, strUrl, project, option);
                    }
                    else if (status == "END") { }
                }

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

    }
}