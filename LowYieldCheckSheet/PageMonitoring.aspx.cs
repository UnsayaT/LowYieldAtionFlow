 using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iLibrary;

namespace LowYieldCheckSheet
{

    public partial class PageMonitoring_Test : System.Web.UI.Page
    {
        DBAccess dba = new DBAccess();
        GlobalClass gc = new GlobalClass();
        string user;
        protected void Page_Load(object sender, EventArgs e)
        {
            string process = "%";
            string Flow = "%";
            string Status = "%";
            string Type = "%";
            string mcno = "%";
            string lotno = "%";
            string package = "%";
            string device = "%";
            string Status1 = (string)(Session["Status"]);
            user = Request.Params["userId"];
            //DateTime date1 = DateTime.Today.AddHours(8).AddMinutes(00);
            //DateTime date2 = DateTime.Today.AddHours(7).AddMinutes(59).AddSeconds(59);
            //DateTime date1 = Convert.ToDateTime("1990/01/01");
            //DateTime date2 = DateTime.Today;

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

            if (SearchSelect2.SelectedIndex != 0)
            {
                if (SearchSelect2.SelectedIndex == 1)
                {
                    Flow = "AUTO1";
                }
                else if (SearchSelect2.SelectedIndex == 2)
                {
                    Flow = "AUTO2";
                }
                else if (SearchSelect2.SelectedIndex == 3)
                {
                    Flow = "AUTO3";
                }
                else //select 4
                {
                    Flow = "AUTO4";
                }
            }

            if (SearchSelect3.SelectedIndex != 0)
            {
                if (SearchSelect3.SelectedIndex == 1)
                {
                    Status = "1";
                }
                else if (SearchSelect3.SelectedIndex == 2)
                {
                    Status = "2";
                }
                else if (SearchSelect3.SelectedIndex == 3)
                {
                    Status = "3";
                }
                else if (SearchSelect3.SelectedIndex == 4)
                {
                    Status = "4";
                }
                else if (SearchSelect3.SelectedIndex == 5)
                {
                    Status = "%5%";
                }
                else if (SearchSelect3.SelectedIndex == 6)
                {
                    Status = "6";
                }
                else if (SearchSelect3.SelectedIndex == 7)
                {
                    Status = "7";
                }
                else //select 8
                {
                    Status = "8";
                }
            }

            if (SearchSelect4.SelectedIndex != 0)
            {
                if (SearchSelect4.SelectedIndex == 1)
                {
                    Type = "1";
                }
                else if (SearchSelect4.SelectedIndex == 2)
                {
                    Type = "2";
                }
                else //select 3
                {
                    Type = "3";
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


            if (Status1 == "7")
            {
                Status = "7";
                SearchSelect3.SelectedIndex = 7;
                SearchCustomers();
            }

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
                return "~/Images/FQI.png";
            }
            else if (value == "5A")
            {
                return "~/Images/FQI.png";
            }
            else if (value == "5B")
            {
                return "~/Images/FQI.png";
            }
            else if (value == "5C")
            {
                return "~/Images/FQI.png";
            }
            else if (value == "6")
            {
                return "~/Images/FYI.png";
            }
            else if (value == "7")
            {
                return "~/Images/user9.png";
            }
            else if (value == "8")
            {
                return "~/Images/user8.png";
            }
            else if (value == "8B")
            {
                return "~/Images/QAApp.png";
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
                txtStoreValue.Text = Process + "," + McNo + "," + Device + "," + LotNo + "," + Status + "," + "LOGIN";

                //Call javascript function(in design code side) to show modal input ser number
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openLoginModal();", true);
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
                //string userId = tbUserID.Value;
                string userId = user;
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
                        //strUrl = "~/InputPageUser1.aspx?Process=" + process + "&MCNo=" + mcno + "&Device=" + device + "&LotNo=" + lotno + "&User=" + userId + "&Edit=" + Edit;
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
                            GridViewPageMonitoring.DataBind();
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

        public void SetValue()
        {
            string controlbmno;
            string bmid;
            string Iss;
            string str = txtStoreValue.Text;
            string[] splitSTR = str.Split(',');
            string Process = splitSTR[0];
            string MCNo = splitSTR[1];
            string Device = splitSTR[2];
            string Lotno = splitSTR[3];

            //Get data from dabatabase by MCNo and LotNo
            var tbl = new DataTable();
            tbl = dba.PullByMCNoAndLotNo(Process, MCNo, Lotno);
            if (tbl.Rows.Count == 1)
            {
                foreach (DataRow row in tbl.Rows)
                {
                    gc.RequestDate = row["RequestDate"].ToString();
                    gc.Mode = Int32.Parse(row["Mode"].ToString());
                    gc.RequestType = row["RequestType"].ToString();
                    gc.AmountNG = Int32.Parse(row["AmountNG"].ToString());
                    gc.Flow = row["Flow"].ToString();
                    gc.MNo = row["MNo"].ToString();
                    gc.TesterNo = row["TesterNo"].ToString();
                    gc.BoxNo = row["BoxNo"].ToString();
                    gc.TRank = row["TRank"].ToString();
                    gc.WaferLotNo = row["WaferLotNo"].ToString();
                    gc.WaferSheetNo = row["WaferSheetNo"].ToString();
                    gc.TPRank = row["TPRank"].ToString();
                    gc.Shipment = txtShipment.Text;
                    gc.InputQuantity = Int32.Parse(row["InputQuantity"].ToString());
                    gc.SocketChangeLastDate = row["SocketChangeLastDate"].ToString();
                    gc.TNo1 = row["TNo1"].ToString();
                    gc.TNo2 = row["TNo2"].ToString();
                    gc.TNo3 = row["TNo3"].ToString();
                    gc.TNo4 = row["TNo4"].ToString();
                    gc.TNo5 = row["TNo5"].ToString();
                    gc.S2TestNoB1 = row["S2TestNoB1"].ToString();
                    gc.S2TestNoB2 = row["S2TestNoB2"].ToString();
                    gc.S2TestNoB3 = row["S2TestNoB3"].ToString();
                    gc.S2TestNoB4 = row["S2TestNoB4"].ToString();
                    gc.S2TestNoB5 = row["S2TestNoB5"].ToString();
                    gc.SetupCheck = txtSetupCheck.Text;
                    gc.ManaulCheck1 = txtManaulCheck1.Text;
                    gc.Result1_1 = txtResult1_1.Text;
                    gc.ManaulCheck1_2 = txtManaulCheck1_2.Text;
                    gc.Result1_2 = txtResult1_2.Text;
                    gc.ManaulCheck1_3 = txtManaulCheck1_3.Text;
                    gc.Result1_3 = txtManaulCheck2.Text;
                    gc.ManaulCheck2 = txtManaulCheck2.Text;
                    gc.Result2 = txtResult2.Text;
                    gc.ManaulCheck3 = txtManaulCheck3.Text;
                    gc.Result3 = txtResult3.Text;
                    gc.SocketChangeHist = txtSocketChangeHist.Text;
                    gc.IsRestartStep3 = txtIsRestartStep3.Text;
                    gc.CheckLowYieldKanban = txtCheckLowYieldKanban.Text;
                    gc.CheckAlarmBin = txtCheckAlarmBin.Text;
                    gc.TesterChecker = txtTesterChecker.Text;
                    gc.Setup = txtSetup.Text;
                    gc.ControlYield = row["ControlYield"].ToString();
                    gc.InitialYield = row["InitialYield"].ToString();
                    gc.CheckValue = row["CheckValue"].ToString();
                    gc.ActionPercent = row["ActionPercent"].ToString();
                    gc.S2TestNoA1 = row["S2TestNoA1"].ToString();
                    gc.S2TestNoA2 = row["S2TestNoA2"].ToString();
                    gc.S2TestNoA3 = row["S2TestNoA3"].ToString();
                    gc.S2TestNoA4 = row["S2TestNoA4"].ToString();
                    gc.S2TestNoA5 = row["S2TestNoA5"].ToString();
                    gc.LimitLow1 = row["LimitLow1"].ToString();
                    gc.LimitLow2 = row["LimitLow2"].ToString();
                    gc.LimitLow3 = row["LimitLow3"].ToString();
                    gc.LimitLow4 = row["LimitLow4"].ToString();
                    gc.LimitLow5 = row["LimitLow5"].ToString();
                    gc.LimitHigh1 = row["LimitHigh1"].ToString();
                    gc.LimitHigh2 = row["LimitHigh2"].ToString();
                    gc.LimitHigh3 = row["LimitHigh3"].ToString();
                    gc.LimitHigh4 = row["LimitHigh4"].ToString();
                    gc.LimitHigh5 = row["LimitHigh5"].ToString();
                    gc.MassProductNG1 = row["MassProductNG1"].ToString();
                    gc.MassProductNG2 = row["MassProductNG2"].ToString();
                    gc.MassProductNG3 = row["MassProductNG3"].ToString();
                    gc.MassProductNG4 = row["MassProductNG4"].ToString();
                    gc.MassProductNG5 = row["MassProductNG5"].ToString();
                    gc.GoodSample1 = row["GoodSample1"].ToString();
                    gc.GoodSample2 = row["GoodSample2"].ToString();
                    gc.GoodSample3 = row["GoodSample3"].ToString();
                    gc.GoodSample4 = row["GoodSample4"].ToString();
                    gc.GoodSample5 = row["GoodSample5"].ToString();
                    gc.SelectS16 = txtSelectS16.Text;
                    gc.TEIncharge_ID = txtTEIncharge_ID.Text;
                    gc.TEIncharge_Sign = txtTEIncharge_Sign.Text;
                    gc.TEIncharge_SignDate = txtTEIncharge_SignDate.Text;
                    gc.TesterETC1 = row["TesterETC1"].ToString();
                    gc.TesterETC2 = row["TesterETC2"].ToString();
                    gc.TesterETC3 = row["TesterETC3"].ToString();
                    gc.TesterETC4 = row["TesterETC4"].ToString();
                    gc.TesterETC5 = row["TesterETC5"].ToString();
                    gc.CheckRepeat1 = row["CheckRepeat1"].ToString();
                    gc.CheckRepeat2 = row["CheckRepeat2"].ToString();
                    gc.CheckRepeat3 = row["CheckRepeat3"].ToString();
                    gc.CheckRepeat4 = row["CheckRepeat4"].ToString();
                    gc.CheckRepeat5 = row["CheckRepeat5"].ToString();
                    gc.ProgramName = row["ProgramName"].ToString();
                    gc.Cause = txtCause.Text;
                    gc.S10TestNoA1 = row["S10TestNoA1"].ToString();
                    gc.S10TestNoA2 = row["S10TestNoA2"].ToString();
                    gc.S10TestNoA3 = row["S10TestNoA3"].ToString();
                    gc.S10TestNoA4 = row["S10TestNoA4"].ToString();
                    gc.S10TestNoA5 = row["S10TestNoA5"].ToString();
                    gc.AddOn = txtAddOn.Text;
                    gc.RequestAQIS13 = txtRequestAQIS13.Text;
                    gc.StopNextLotS13 = txtStopNextLotS13.Text;
                    gc.RequestAQIS14 = txtRequestAQIS14.Text;
                    gc.StopNextLotS14 = txtStopNextLotS14.Text;
                    gc.StopPKGS14 = txtStopPKGS14.Text;
                    gc.SystemInspection = txtSystemInspection.Text;
                    gc.JudgementResult = txtJudgementResult.Text;
                    gc.LowYieldAnalysis = txtLowYieldAnalysis.Text;
                    gc.Process = Request.Params["Process"]; //get parameter from url
                    gc.LotNo = Request.Params["LotNo"]; //get parameter from url
                    gc.HandlerNo = Request.Params["MCNo"]; //get parameter from url
                    gc.User = Request.Params["User"]; //get parameter from url
                    gc.Edit = Request.Params["Edit"]; //get parameter from url
                    gc.S10TestNoB1 = row["S10TestNoB1"].ToString();
                    gc.S10TestNoB2 = row["S10TestNoB2"].ToString();
                    gc.S10TestNoB3 = row["S10TestNoB3"].ToString();
                    gc.S10TestNoB4 = row["S10TestNoB4"].ToString();
                    gc.S10TestNoB5 = row["S10TestNoB5"].ToString();
                    gc.KanbanCtrlNo = row["KanbanCtrlNo"].ToString();
                    gc.KanbanTestNo = row["KanbanTestNo"].ToString();
                    gc.KanbanExpireDate = row["KanbanExpireDate"].ToString();
                    gc.ResultBurnGood = row["ResultBurnGood"].ToString();
                    gc.ResultBurnNG = row["ResultBurnNG"].ToString();
                    gc.ResultChipCrackGood = row["ResultChipCrackGood"].ToString();
                    gc.ResultChipCrackNG = row["ResultChipCrackNG"].ToString();
                    gc.FinalYield = row["FinalYield"].ToString();
                    gc.ControlLCL = row["ControlLCL"].ToString();
                    gc.AsiGood = row["AsiGood"].ToString();
                    gc.AsiNG = row["AsiNG"].ToString();
                    gc.AndonManage = row["AndonManage"].ToString();
                    gc.AndonWho = row["AndonWho"].ToString();
                    gc.AndonManageDetail = row["AndonManageDetail"].ToString();
                    gc.OPName1_ID = row["OPName1_ID"].ToString();
                    gc.TestIncharge_ID = row["TestIncharge_ID"].ToString();
                    gc.OPName2_ID = row["OPName2_ID"].ToString();
                    gc.GL_ID = row["GL_ID"].ToString();
                    gc.AnalysisIncharge_ID = row["AnalysisIncharge_ID"].ToString();
                    gc.FYIFQIIncharge_ID = row["FYIFQIIncharge_ID"].ToString();
                    gc.PDMgr_ID = row["PDMgr_ID"].ToString();
                    gc.OPName1_Sign = row["OPName1_Sign"].ToString();
                    gc.TestIncharge_Sign = row["TestIncharge_Sign"].ToString();
                    gc.OPName2_Sign = row["OPName2_Sign"].ToString();
                    gc.GL_Sign = row["GL_Sign"].ToString();
                    gc.AnalysisIncharge_Sign = row["AnalysisIncharge_Sign"].ToString();
                    gc.FYIFQIIncharge_Sign = row["FYIFQIIncharge_Sign"].ToString();
                    gc.PDMgr_Sign = row["PDMgr_Sign"].ToString();
                    gc.OPName1_SignDate = row["OPName1_SignDate"].ToString();
                    gc.TestIncharge_SignDate = row["TestIncharge_SignDate"].ToString();
                    gc.OPName2_SignDate = row["OPName2_SignDate"].ToString();
                    gc.GL_SignDate = row["GL_SignDate"].ToString();
                    gc.AnalysisIncharge_SignDate = row["AnalysisIncharge_SignDate"].ToString();
                    gc.FYIFQIIncharge_SignDate = row["FYIFQIIncharge_SignDate"].ToString();
                    gc.PDMgr_SignDate = row["PDMgr_SignDate"].ToString();
                    gc.Status = txtStoreValue.Text;
                    gc.QCIncharge_ID = row["QCIncharge_ID"].ToString();
                    gc.QCIncharge_Sign = row["QCIncharge_Sign"].ToString();
                    gc.QCIncharge_SignDate = row["QCIncharge_SignDate"].ToString();
                    gc.FTRetestGood = row["FTRetestGood"].ToString();
                    gc.FTRetestNG = row["FTRetestNG"].ToString();
                    gc.QCJudgement = row["QCJudgement"].ToString();
                    gc.StopShipmentPKG = row["StopShipmentPKG"].ToString();
                    gc.Assy = row["Assy"].ToString();
                    gc.ActionPCS = Int32.Parse(row["ActionPCS"].ToString());
                    gc.RequestAQIS15 = row["RequestAQIS15"].ToString();
                    gc.StopShipObjDevice = row["StopShipObjDevice"].ToString();
                    gc.StopLabel = row["StopLabel"].ToString();
                    gc.ObjectScope = row["ObjectScope"].ToString();
                    gc.StopRecallShipment = row["StopRecallShipment"].ToString();

                    if (row["TesttotalAmount"].ToString() != "")
                    {
                        gc.TesttotalAmount = Int32.Parse(row["TesttotalAmount"].ToString());
                    }
                    if (row["ResultChipMixGood"].ToString() != "")
                    {
                        gc.ResultChipMixGood = Int32.Parse(row["ResultChipMixGood"].ToString());
                    }
                 

                    gc.S2NG_A1 = Int32.Parse(row["S2NG_A1"].ToString());
                    gc.S2NG_A2 = Int32.Parse(row["S2NG_A2"].ToString());
                    gc.S2NG_A3 = Int32.Parse(row["S2NG_A3"].ToString());
                    gc.S2NG_A4 = Int32.Parse(row["S2NG_A4"].ToString());
                    gc.S2NG_A5 = Int32.Parse(row["S2NG_A5"].ToString());
                    gc.S2NG_B1 = Int32.Parse(row["S2NG_B1"].ToString());
                    gc.S2NG_B2 = Int32.Parse(row["S2NG_B2"].ToString());
                    gc.S2NG_B3 = Int32.Parse(row["S2NG_B3"].ToString());
                    gc.S2NG_B4 = Int32.Parse(row["S2NG_B4"].ToString());
                    gc.S2NG_B5 = Int32.Parse(row["S2NG_B5"].ToString());
                    
                    if (row["UseMassProductGood"].ToString() != "")
                    {
                        gc.UseMassProductGood = Int32.Parse(row["UseMassProductGood"].ToString());
                    }

                    if (row["UseMassProductNG"].ToString() != "")
                    {
                        gc.UseMassProductNG = Int32.Parse(row["UseMassProductNG"].ToString());
                    }

                    if (row["ScrapAmountGood"].ToString() != "")
                    {
                        gc.ScrapAmountGood = Int32.Parse(row["ScrapAmountGood"].ToString());
                    }

                    if (row["ScrapAmountNG"].ToString() != "")
                    {
                        gc.ScrapAmountNG = Int32.Parse(row["ScrapAmountNG"].ToString());
                    }
                    
                    gc.S10NGA1 = Int32.Parse(row["S10NGA1"].ToString());
                    gc.S10NGA2 = Int32.Parse(row["S10NGA2"].ToString());
                    gc.S10NGA3 = Int32.Parse(row["S10NGA3"].ToString());
                    gc.S10NGA4 = Int32.Parse(row["S10NGA4"].ToString());
                    gc.S10NGA5 = Int32.Parse(row["S10NGA5"].ToString());
                    gc.S10NGB1 = Int32.Parse(row["S10NGB1"].ToString());
                    gc.S10NGB2 = Int32.Parse(row["S10NGB2"].ToString());
                    gc.S10NGB3 = Int32.Parse(row["S10NGB3"].ToString());
                    gc.S10NGB4 = Int32.Parse(row["S10NGB4"].ToString());
                    gc.S10NGB5 = Int32.Parse(row["S10NGB5"].ToString());

                    //Add 2020-09-16 By Unsaya

                    controlbmno = row["ControlBMNo"].ToString();
                    bmid = row["BMID"].ToString();
                    Iss = row["IssueNo"].ToString();

                    if (controlbmno != null)
                    {
                        gc.ControlBMNo = controlbmno;
                    }

                    if (row["BMID"].ToString() != "")
                    {
                        gc.BMID = Int32.Parse(row["BMID"].ToString());
                    }

                    //if (bmid != null)
                    //{
                    //    gc.BMID = Int32.Parse(bmid);
                    //}

                    if (Iss != null)
                    {
                        gc.IssueNo = Iss;
                    }

                    //Add 2020-10-20
                    gc.CheckSocket = row["CheckSocket"].ToString();

                }
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
            SetValue();

            //update status and describe why cancel.
            dba.UpdateCancelStatus(Process, MCNo,Lotno, Status, Describe);

            
            //move data from monitoring to history table
            dba.MoveToHistory8(Process, MCNo, Lotno, gc.PackageName, Device, gc.RequestDate, gc.Mode, Status, Describe, gc.RequestType, gc.AmountNG, gc.Flow, gc.MNo, gc.TesterNo, gc.BoxNo, gc.TRank, gc.WaferLotNo, gc.WaferSheetNo,
                    gc.TPRank,gc.Shipment, gc.InputQuantity, gc.ControlYield, gc.InitialYield, gc.CheckValue, gc.ActionPCS, gc.ActionPercent, gc.S2TestNoA1, gc.S2TestNoA2, gc.S2TestNoA3, gc.S2TestNoA4, gc.S2TestNoA5, gc.S2NG_A1, gc.S2NG_A2, gc.S2NG_A3, gc.S2NG_A4, gc.S2NG_A5,
                    gc.S2TestNoB1, gc.S2TestNoB2, gc.S2TestNoB3, gc.S2TestNoB4, gc.S2TestNoB5, gc.S2NG_B1, gc.S2NG_B2, gc.S2NG_B3, gc.S2NG_B4, gc.S2NG_B5, gc.SetupCheck, gc.ManaulCheck1, gc.Result1_1, gc.ManaulCheck1_2, gc.Result1_2, gc.ManaulCheck1_3, gc.Result1_3, gc.ManaulCheck2, gc.Result2, gc.ManaulCheck3, gc.Result3,
                    gc.SocketChangeHist, gc.SocketChangeLastDate, gc.IsRestartStep3, gc.CheckLowYieldKanban, gc.CheckAlarmBin, gc.TesterChecker, gc.Setup, gc.TNo1, gc.TNo2, gc.TNo3, gc.TNo4, gc.TNo5, gc.LimitLow1, gc.LimitLow2, gc.LimitLow3, gc.LimitLow4, gc.LimitLow5, gc.LimitHigh1, gc.LimitHigh2, gc.LimitHigh3, gc.LimitHigh4, gc.LimitHigh5,
                    gc.MassProductNG1, gc.MassProductNG2, gc.MassProductNG3, gc.MassProductNG4, gc.MassProductNG5, gc.GoodSample1, gc.GoodSample2, gc.GoodSample3, gc.GoodSample4, gc.GoodSample5, gc.TesterETC1, gc.TesterETC2, gc.TesterETC3, gc.TesterETC4, gc.TesterETC5, gc.CheckRepeat1, gc.CheckRepeat2, gc.CheckRepeat3, gc.CheckRepeat4, gc.CheckRepeat5,
                    gc.ProgramName, gc.UseMassProductGood, gc.UseMassProductNG, gc.ScrapAmountGood, gc.ScrapAmountNG, gc.Cause, gc.S10TestNoA1, gc.S10TestNoA2, gc.S10TestNoA3, gc.S10TestNoA4, gc.S10TestNoA5, gc.S10NGA1, gc.S10NGA2, gc.S10NGA3, gc.S10NGA4, gc.S10NGA5, gc.S10TestNoB1, gc.S10TestNoB2, gc.S10TestNoB3, gc.S10TestNoB4, gc.S10TestNoB5,
                    gc.S10NGB1, gc.S10NGB2, gc.S10NGB3, gc.S10NGB4, gc.S10NGB5, gc.FinalYield, gc.ControlLCL, gc.AsiGood, gc.AsiNG, gc.AddOn, gc.AndonManage, gc.AndonWho, gc.AndonManageDetail, gc.TestResultGood, gc.TestResultNG, gc.RequestAQIS13, gc.StopNextLotS13, gc.KanbanCtrlNo, gc.KanbanTestNo, gc.KanbanExpireDate,
                    gc.ResultBurnGood, gc.ResultBurnNG, gc.ResultChipCrackGood, gc.ResultChipCrackNG, gc.ResultChipMixGood, gc.ResultChipMixNG, gc.RequestAQIS14, gc.StopNextLotS14, gc.StopPKGS14, gc.RequestAQIS15, gc.StopShipObjDevice, gc.StopLabel, gc.SystemInspection, gc.JudgementResult, gc.FTRetestGood,
                    gc.FTRetestNG, gc.ObjectScope, gc.StopRecallShipment, gc.LowYieldAnalysis, gc.StopShipmentPKG, gc.Assy, gc.QCJudgement, gc.OPName1_ID, gc.TestIncharge_ID, gc.OPName2_ID, gc.GL_ID, gc.AnalysisIncharge_ID, gc.FYIFQIIncharge_ID, gc.PDMgr_ID, gc.QCIncharge_ID, gc.OPName1_Sign, gc.TestIncharge_Sign,
                    gc.OPName2_Sign, gc.GL_Sign, gc.AnalysisIncharge_Sign, gc.FYIFQIIncharge_Sign, gc.PDMgr_Sign, gc.QCIncharge_Sign, gc.OPName1_SignDate, gc.TestIncharge_SignDate, gc.OPName2_SignDate, gc.GL_SignDate, gc.AnalysisIncharge_SignDate, gc.FYIFQIIncharge_SignDate, gc.PDMgr_SignDate, gc.QCIncharge_SignDate, gc.TesttotalAmount,
                    gc.SelectS16, gc.TEIncharge_ID, gc.TEIncharge_Sign, gc.TEIncharge_SignDate, gc.Shipmentdate, gc.LowYieldMode, gc.ControlBMNo, gc.BMID, gc.IssueNo,gc.CheckSocket);


            //move data from monitoring to history table
            //dba.MoveToHistory(Process, MCNo, Lotno);

            //delete this data row from monitoring table
            dba.DeleteReportRow(Process, MCNo, Lotno);

            //Message Box
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Cancel Done')", true);

            //refresh gridview monitoring
            GridViewPageMonitoring.DataBind();
        }

        //protected void BtnSubmitDescribe_ServerClick_Test(object sender, EventArgs e)
        //{
        //    string str = txtStoreValue.Text;
        //    string[] splitSTR = str.Split(',');
        //    string Process = splitSTR[0];
        //    string MCNo = splitSTR[1];
        //    string Device = splitSTR[2];
        //    string Lotno = splitSTR[3];
        //    string Status = "CANCEL";
        //    string Describe = txtDescribe.Value;
        //    string PackageName = txtPackageName.Value;


        //    update status and describe why cancel.
        //    dba.UpdateCancelStatus(Process, MCNo, Lotno, Status, Describe);

        //    move data from monitoring to history table
        //    dba.MoveToHistory8(Process, MCNo, Lotno, PackageName, DeviceName, RequestDate, Mode, Status, Describe, RequestType, AmountNG, Flow, MNo, TesterNo, BoxNo, TRank, WaferLotNo, WaferSheetNo,
        //             TPRank, Shipment, InputQuantity, ControlYield, InitialYield, CheckValue, ActionPCS, ActionPercent, S2TestNoA1, S2TestNoA2, S2TestNoA3, S2TestNoA4, S2TestNoA5, S2NG_A1, S2NG_A2, S2NG_A3, S2NG_A4, S2NG_A5,
        //             S2TestNoB1, S2TestNoB2, S2TestNoB3, S2TestNoB4, S2TestNoB5, S2NG_B1, S2NG_B2, S2NG_B3, S2NG_B4, S2NG_B5, SetupCheck, ManaulCheck1, Result1_1, ManaulCheck1_2, Result1_2, ManaulCheck1_3, Result1_3, ManaulCheck2, Result2, ManaulCheck3, Result3,
        //             SocketChangeHist, SocketChangeLastDate, IsRestartStep3, CheckLowYieldKanban, CheckAlarmBin, TesterChecker, Setup, TNo1, TNo2, TNo3, TNo4, TNo5, LimitLow1, LimitLow2, LimitLow3, LimitLow4, LimitLow5, LimitHigh1, LimitHigh2, LimitHigh3, LimitHigh4, LimitHigh5,
        //             MassProductNG1, MassProductNG2, MassProductNG3, MassProductNG4, MassProductNG5, GoodSample1, GoodSample2, GoodSample3, GoodSample4, GoodSample5, TesterETC1, TesterETC2, TesterETC3, TesterETC4, TesterETC5, CheckRepeat1, CheckRepeat2, CheckRepeat3, CheckRepeat4, CheckRepeat5,
        //             ProgramName, UseMassProductGood, UseMassProductNG, ScrapAmountGood, ScrapAmountNG, Cause, S10TestNoA1, S10TestNoA2, S10TestNoA3, S10TestNoA4, S10TestNoA5, S10NGA1, S10NGA2, S10NGA3, S10NGA4, S10NGA5, S10TestNoB1, S10TestNoB2, S10TestNoB3, S10TestNoB4, S10TestNoB5,
        //             S10NGB1, S10NGB2, S10NGB3, S10NGB4, S10NGB5, FinalYield, ControlLCL, AsiGood, AsiNG, AddOn, AndonManage, AndonWho, AndonManageDetail, TestResultGood, TestResultNG, RequestAQIS13, StopNextLotS13, KanbanCtrlNo, g KanbanTestNo, KanbanExpireDate,
        //            ResultBurnGood, ResultBurnNG, ResultChipCrackGood, ResultChipCrackNG, ResultChipMixGood, ResultChipMixNG, RequestAQIS14, StopNextLotS14, StopPKGS14, RequestAQIS15, StopShipObjDevice, StopLabel, SystemInspection, JudgementResult, FTRetestGood,
        //             FTRetestNG, ObjectScope, StopRecallShipment, LowYieldAnalysis, StopShipmentPKG, Assy, QCJudgement, OPName1_ID, TestIncharge_ID, OPName2_ID, GL_ID, AnalysisIncharge_ID, FYIFQIIncharge_ID, PDMgr_ID, QCIncharge_ID, OPName1_Sign, TestIncharge_Sign,
        //             OPName2_Sign, GL_Sign, AnalysisIncharge_Sign, FYIFQIIncharge_Sign, PDMgr_Sign, QCIncharge_Sign, OPName1_SignDate, TestIncharge_SignDate, OPName2_SignDate, GL_SignDate, AnalysisIncharge_SignDate, FYIFQIIncharge_SignDate, PDMgr_SignDate, QCIncharge_SignDate, TesttotalAmount,
        //             SelectS16, TEIncharge_ID, TEIncharge_Sign, TEIncharge_SignDate, ShipmentDate, LowYieldMode);

        //    delete this data row from monitoring table
        //    dba.DeleteReportRow(Process, MCNo, Lotno);

        //    Message Box
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Cancel Done')", true);

        //    refresh gridview monitoring
        //    GridViewPageMonitoring.DataBind();
        //}

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


        private void SearchCustomers()
        {
            string strSQL;

            string process = "%";
            string Flow = "%";
            string Status = "%";
            string Type = "%";
            string mcno = "%";
            string lotno = "%";
            string package = "%";
            string device = "%";
            string Status1 = (string)(Session["Status"]);

            //DateTime date1 = DateTime.Today.AddHours(8).AddMinutes(00);
            //DateTime date2 = DateTime.Today.AddHours(7).AddMinutes(59).AddSeconds(59);
            //DateTime date1 = Convert.ToDateTime("1990/01/01");
            //DateTime date2 = DateTime.Today;

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

            if (SearchSelect2.SelectedIndex != 0)
            {
                if (SearchSelect2.SelectedIndex == 1)
                {
                    Flow = "AUTO1";
                }
                else if (SearchSelect2.SelectedIndex == 2)
                {
                    Flow = "AUTO2";
                }
                else if (SearchSelect2.SelectedIndex == 3)
                {
                    Flow = "AUTO3";
                }
                else //select 4
                {
                    Flow = "AUTO4";
                }
            }

            if (SearchSelect3.SelectedIndex != 0)
            {
                if (SearchSelect3.SelectedIndex == 1)
                {
                    Status = "1";
                }
                else if (SearchSelect3.SelectedIndex == 2)
                {
                    Status = "2";
                }
                else if (SearchSelect3.SelectedIndex == 3)
                {
                    Status = "3";
                }
                else if (SearchSelect3.SelectedIndex == 4)
                {
                    Status = "4";
                }
                else if (SearchSelect3.SelectedIndex == 5)
                {
                    Status = "%5%";
                }
                else if (SearchSelect3.SelectedIndex == 6)
                {
                    Status = "6";
                }
                else if (SearchSelect3.SelectedIndex == 7)
                {
                    Status = "7";
                }
                else //select 8
                {
                    Status = "8";
                }
            }

            if (Status1 == "7")
            {
                Status = "7";
                Session["Status"] = null;
            }

            if (SearchSelect4.SelectedIndex != 0)
            {
                if (SearchSelect4.SelectedIndex == 1)
                {
                    Type = "1";
                }
                else if (SearchSelect4.SelectedIndex == 2)
                {
                    Type = "2";
                }
                else //select 3
                {
                    Type = "3";
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

            //if (SearchDate1.Value != "")
            //{
            //    date1 = Convert.ToDateTime(SearchDate1.Value);
            //    date1 = date1.AddHours(8).AddMinutes(00);
            //    date2 = date1.AddDays(+1).AddSeconds(-1);
            //}


            strSQL = "SELECT [Process], [HandlerNo], [LotNo], [PackageName], [DeviceName], [RequestDate], [Status], [RequestType], [Flow], [InitialYield], [ControlYield], [FinalYield], [ControlLCL],[CheckAlarmBin],[Mode],[AndonManageDetail]" +
                "FROM [DBx].[dbo].[LowYieldActionReport]" +
                "WHERE Process LIKE '" + process + "' AND HandlerNo LIKE '" + mcno + "' AND  LotNo LIKE '" + lotno + "' AND PackageName LIKE '" + package + "' " +
                "AND Status LIKE '" + Status + "' AND Flow LIKE '" + Flow + "' AND Mode LIKE '" + Type + "' " +
                //"AND DeviceName LIKE '" + device + "' AND RequestDate BETWEEN '" + date1 + "' AND '" + date2 + "' " +
                "AND Status!='CANCEL' ORDER BY RequestDate DESC";

            SqlDataSource1.SelectCommand = strSQL;
            GridViewPageMonitoring.DataBind();
        }

        protected void btnSearch_ServerClick(object sender, EventArgs e)
        {
            this.SearchCustomers();
        }


        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            GridViewPageMonitoring.PageIndex = e.NewPageIndex;
            this.SearchCustomers();
        }
    }
}