using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LowYieldCheckSheet
{
    public partial class InputPageUser4_Test : System.Web.UI.Page
    {
        DBAccess dba = new DBAccess();
        GlobalClass gc = new GlobalClass();

        string[] splitStr;
        string tempStr;
        string tempStr2;
        string StepStatus1;
        string StepStatus2;
        string StepStatus3;
        string controlbmno;
        string bmid;
        string Iss;
        string socket;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }

        }

        private void LoadData()
        {
            gc.Process = Request.Params["Process"]; //get parameter from url
            gc.LotNo = Request.Params["LotNo"]; //get parameter from url
            gc.HandlerNo = Request.Params["MCNo"]; //get parameter from url
            gc.Edit = Request.Params["Edit"];

            var tbl = new DataTable();

            //Get data from dabatabase by MCNo and LotNo
            tbl = dba.PullByMCNoAndLotNo(gc.Process, gc.HandlerNo, gc.LotNo);
            
            if (tbl.Rows.Count == 1)
            {
                foreach (DataRow row in tbl.Rows)
                {
                    //RequesType 
                    if (row["RequestType"].ToString() == "INITIAL")
                    {
                        //SetRequestType(row["ControlYield"].ToString(),row["InitialYield"].ToString(),row["CheckAlarmBin"].ToString());
                        //Add 2019-03-01
                        if (row["Mode"].ToString() != "")
                        {
                            if (row["Mode"].ToString() == "1")
                            {
                                tempStr = "Request Type : Low Yield ";
                            }
                            else if (row["Mode"].ToString() == "2")
                            {
                                if (row["CheckAlarmBin"].ToString() != "NO")
                                {
                                    tempStr = "Request Type : Alarm ";
                                    tempStr2 = row["CheckAlarmBin"].ToString();
                                    splitStr = tempStr2.Split(',');
                                    if (splitStr.Length > 1)
                                    {
                                        for (int i = 0; i < splitStr.Length; i++)
                                        {
                                            if (splitStr[i] == "BIN28")
                                            {
                                                tempStr = tempStr + "BIN28 ";
                                            }
                                            else if (splitStr[i] == "BIN29")
                                            {
                                                tempStr = tempStr + "BIN29 ";
                                            }
                                            else if (splitStr[i] == "BIN30")
                                            {
                                                tempStr = tempStr + "BIN30 ";
                                            }
                                            else if (splitStr[i] == "BIN31")
                                            {
                                                tempStr = tempStr + "BIN31 ";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (tempStr2 == "BIN28")
                                        {
                                            tempStr = tempStr + tempStr2;
                                        }
                                        else if (tempStr2 == "BIN29")
                                        {
                                            tempStr = tempStr + tempStr2;
                                        }
                                        else if (tempStr2 == "BIN30")
                                        {
                                            tempStr = tempStr + tempStr2;
                                        }
                                        else if (tempStr2 == "BIN31")
                                        {
                                            tempStr = tempStr + tempStr2;
                                        }
                                    }
                                }
                            }
                            else if (row["Mode"].ToString() == "3")
                            {
                                if (row["CheckAlarmBin"].ToString() != "NO")
                                {
                                    tempStr = "Request Type : Low Yield & Alarm ";
                                    tempStr2 = row["CheckAlarmBin"].ToString();
                                    splitStr = tempStr2.Split(',');
                                    if (splitStr.Length > 1)
                                    {
                                        for (int i = 0; i < splitStr.Length; i++)
                                        {
                                            if (splitStr[i] == "BIN28")
                                            {
                                                tempStr = tempStr + "BIN28 ";
                                            }
                                            else if (splitStr[i] == "BIN29")
                                            {
                                                tempStr = tempStr + "BIN29 ";
                                            }
                                            else if (splitStr[i] == "BIN30")
                                            {
                                                tempStr = tempStr + "BIN30 ";
                                            }
                                            else if (splitStr[i] == "BIN31")
                                            {
                                                tempStr = tempStr + "BIN31 ";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (tempStr2 == "BIN28")
                                        {
                                            tempStr = tempStr + tempStr2;
                                        }
                                        else if (tempStr2 == "BIN29")
                                        {
                                            tempStr = tempStr + tempStr2;
                                        }
                                        else if (tempStr2 == "BIN30")
                                        {
                                            tempStr = tempStr + tempStr2;
                                        }
                                        else if (tempStr2 == "BIN31")
                                        {
                                            tempStr = tempStr + tempStr2;
                                        }
                                    }
                                }
                            }
                        }
                        lblRequestType.Text = tempStr;
                    }
                    else if (row["RequestType"].ToString() == "FINAL")
                    {
                        //SetRequestType(row["ControlLCL"].ToString(),row["FinalYield"].ToString(),row["CheckAlarmBin"].ToString());
                        //Add 2019-03-01
                        if (row["Mode"].ToString() != "")
                        {
                            if (row["Mode"].ToString() == "1")
                            {
                                tempStr = "Request Type : Low Yield ";
                            }
                            else if (row["Mode"].ToString() == "2")
                            {
                                if (row["CheckAlarmBin"].ToString() != "NO")
                                {
                                    tempStr = "Request Type : Alarm ";
                                    tempStr2 = row["CheckAlarmBin"].ToString();
                                    splitStr = tempStr2.Split(',');
                                    if (splitStr.Length > 1)
                                    {
                                        for (int i = 0; i < splitStr.Length; i++)
                                        {
                                            if (splitStr[i] == "BIN28")
                                            {
                                                tempStr = tempStr + "BIN28 ";
                                            }
                                            else if (splitStr[i] == "BIN29")
                                            {
                                                tempStr = tempStr + "BIN29 ";
                                            }
                                            else if (splitStr[i] == "BIN30")
                                            {
                                                tempStr = tempStr + "BIN30 ";
                                            }
                                            else if (splitStr[i] == "BIN31")
                                            {
                                                tempStr = tempStr + "BIN31 ";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (tempStr2 == "BIN28")
                                        {
                                            tempStr = tempStr + tempStr2;
                                        }
                                        else if (tempStr2 == "BIN29")
                                        {
                                            tempStr = tempStr + tempStr2;
                                        }
                                        else if (tempStr2 == "BIN30")
                                        {
                                            tempStr = tempStr + tempStr2;
                                        }
                                        else if (tempStr2 == "BIN31")
                                        {
                                            tempStr = tempStr + tempStr2;
                                        }
                                    }
                                }
                            }
                            else if (row["Mode"].ToString() == "3")
                            {
                                if (row["CheckAlarmBin"].ToString() != "NO")
                                {
                                    tempStr = "Request Type : Low Yield & Alarm ";
                                    tempStr2 = row["CheckAlarmBin"].ToString();
                                    splitStr = tempStr2.Split(',');
                                    if (splitStr.Length > 1)
                                    {
                                        for (int i = 0; i < splitStr.Length; i++)
                                        {
                                            if (splitStr[i] == "BIN28")
                                            {
                                                tempStr = tempStr + "BIN28 ";
                                            }
                                            else if (splitStr[i] == "BIN29")
                                            {
                                                tempStr = tempStr + "BIN29 ";
                                            }
                                            else if (splitStr[i] == "BIN30")
                                            {
                                                tempStr = tempStr + "BIN30 ";
                                            }
                                            else if (splitStr[i] == "BIN31")
                                            {
                                                tempStr = tempStr + "BIN31 ";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (tempStr2 == "BIN28")
                                        {
                                            tempStr = tempStr + tempStr2;
                                        }
                                        else if (tempStr2 == "BIN29")
                                        {
                                            tempStr = tempStr + tempStr2;
                                        }
                                        else if (tempStr2 == "BIN30")
                                        {
                                            tempStr = tempStr + tempStr2;
                                        }
                                        else if (tempStr2 == "BIN31")
                                        {
                                            tempStr = tempStr + tempStr2;
                                        }
                                    }
                                }
                            }
                        }
                        lblRequestType.Text = tempStr;
                    }

                    //########################## HEAD ##############################
                    tbHead1.Text = row["AmountNG"].ToString();
                    tbHead2.Text = row["HandlerNo"].ToString();
                    tbHead3.Text = row["LotNo"].ToString();
                    tbHead4.Text = row["PackageName"].ToString();
                    tbHead5.Text = row["DeviceName"].ToString();

                    Iss = row["IssueNo"].ToString();
                    socket = row["CheckSocket"].ToString();
                    if (string.IsNullOrEmpty(row["Flow"].ToString()))
                    {
                        headSelect1.SelectedIndex = 0;
                    }
                    else
                    {
                        if (row["Flow"].ToString() == "AUTO1") { headSelect1.SelectedIndex = 1; }
                        else if (row["Flow"].ToString() == "AUTO2") { headSelect1.SelectedIndex = 2; }
                        else if (row["Flow"].ToString() == "AUTO3") { headSelect1.SelectedIndex = 3; }
                        else if (row["Flow"].ToString() == "AUTO4") { headSelect1.SelectedIndex = 4; }
                    }

                    tbHead6.Text = row["MNo"].ToString();
                    tbHead7.Text = row["TesterNo"].ToString();
                    tbHead8.Text = row["BoxNo"].ToString();
                    tbHead9.Text = row["TRank"].ToString();
                    tbHead10.Text = row["WaferLotNo"].ToString();
                    tbHead11.Text = row["WaferSheetNo"].ToString();
                    tbHead12.Text = row["TPRank"].ToString();

                    if (string.IsNullOrEmpty(row["Shipment"].ToString()))
                    {
                        headSelect2.SelectedIndex = 0;
                    }
                    else
                    {
                        if (row["Shipment"].ToString() == "JAPAN")
                        {
                            headSelect2.SelectedIndex = 1;
                        }
                        else if (row["Shipment"].ToString() == "OVERSEA")
                        {
                            headSelect2.SelectedIndex = 2;
                        }
                    }

                    //Add 23-06-2020 Unsaya
                    controlbmno = row["ControlBMNo"].ToString();
                    bmid = row["BMID"].ToString();

                    //############################ STEP 1 #################################
                    tbS1A1.Text = row["InputQuantity"].ToString();
                    tbS1A2.Text = row["ControlYield"].ToString();
                    tbS1A3.Text = row["InitialYield"].ToString();
                    tbS1A4.Text = row["CheckValue"].ToString();
                    tbS1A5.Text = row["ActionPCS"].ToString();
                    tbS1A6.Text = row["ActionPercent"].ToString();

                    //############################ STEP 2,3 ###################################
                    tbS2r1c1.Text = row["S2TestNoA1"].ToString();
                    tbS2r1c2.Text = row["S2TestNoA2"].ToString();
                    tbS2r1c3.Text = row["S2TestNoA3"].ToString();
                    tbS2r1c4.Text = row["S2TestNoA4"].ToString();
                    tbS2r1c5.Text = row["S2TestNoA5"].ToString();

                    tbS2r2c1.Text = row["S2NG_A1"].ToString();
                    tbS2r2c2.Text = row["S2NG_A2"].ToString();
                    tbS2r2c3.Text = row["S2NG_A3"].ToString();
                    tbS2r2c4.Text = row["S2NG_A4"].ToString();
                    tbS2r2c5.Text = row["S2NG_A5"].ToString();

                    tbS2r3c1.Text = row["S2TestNoB1"].ToString();
                    tbS2r3c2.Text = row["S2TestNoB2"].ToString();
                    tbS2r3c3.Text = row["S2TestNoB3"].ToString();
                    tbS2r3c4.Text = row["S2TestNoB4"].ToString();
                    tbS2r3c5.Text = row["S2TestNoB5"].ToString();

                    tbS2r4c1.Text = row["S2NG_B1"].ToString();
                    tbS2r4c2.Text = row["S2NG_B2"].ToString();
                    tbS2r4c3.Text = row["S2NG_B3"].ToString();
                    tbS2r4c4.Text = row["S2NG_B4"].ToString();
                    tbS2r4c5.Text = row["S2NG_B5"].ToString();

                    //########################### STEP 4 #############################
                    if (!(string.IsNullOrEmpty(row["SetupCheck"].ToString())))
                    {
                        if (row["SetupCheck"].ToString() == "OK")
                        {
                            SelectS4.SelectedIndex = 1;
                        }
                        else if (row["SetupCheck"].ToString() == "NG")
                        {
                            SelectS4.SelectedIndex = 2;
                        }
                    }

                    //########################### STEP 5 ###############################
                    if (!(string.IsNullOrEmpty(row["ManaulCheck1"].ToString())))
                    {
                        if (row["ManaulCheck1"].ToString() == "SOCKETCHANGE")
                        {
                            cbStep5_1.Checked = true;
                            rbStep5A1.Checked = true;
                            if (row["Result1_1"].ToString() == "Mass NG to Good")
                            {
                                Step5A1chkok.Checked = true;
                                StepStatus1 = "OK";
                            }
                            else
                            {
                                Step5A1chkng.Checked = true;
                            }
                        }
                    }
                    if (row["ManaulCheck1_2"].ToString() == "REQUESTPM")
                    {
                            cbStep5_1.Checked = true;
                            rbStep5A2.Checked = true;
                            if (row["Result1_2"].ToString() == "Mass NG to Good")
                            {
                                Step5A2chkok.Checked = true;
                                StepStatus2 = "OK";
                        }
                            else
                            {
                                Step5A2chkng.Checked = true;
                            }
                    }

                     if (!(string.IsNullOrEmpty(row["ManaulCheck1_3"].ToString())))
                     {
                            cbStep5_1.Checked = true;
                            rbStep5A3.Checked = true;
                            tbS5.Text = row["ManaulCheck1_3"].ToString();
                            if (row["Result1_3"].ToString() == "Mass NG to Good")
                            {
                                Step5A3chkok.Checked = true;
                                StepStatus3 = "OK";
                        }
                            else
                            {
                                Step5A3chkng.Checked = true;
                            }
                     }
                    


                    if (!(string.IsNullOrEmpty(row["ManaulCheck2"].ToString())))
                    {
                        cbStep5_2.Checked = true;
                        if (row["Result2"].ToString() == "Good to NG")
                        {
                            cbStep5_2chkok.Checked = true;
                        }
                        else
                        {
                            cbStep5_2chkng.Checked = true;
                        }
                    }

                    if (!(string.IsNullOrEmpty(row["ManaulCheck3"].ToString())))
                    {
                        cbStep5_3.Checked = true;
                        if (row["Result3"].ToString() == "NG to NG AND Good to Good")
                        {
                            cbStep5_3chkok.Checked = true;
                        }
                        else
                        {
                            cbStep5_3chkng.Checked = true;
                        }
                    }

                    //#################################### STEP 6 #########################################
                    if (string.IsNullOrEmpty(row["SocketChangeHist"].ToString()))
                    {
                        SelectS6A1.SelectedIndex = 0;
                    }
                    else
                    {
                        if (row["SocketChangeHist"].ToString() == "WEEK")
                        {
                            SelectS6A1.SelectedIndex = 1;
                        }
                        else if (row["SocketChangeHist"].ToString() == "OVERWEEK")
                        {
                            SelectS6A1.SelectedIndex = 2;
                        }
                    }


                    if (!(string.IsNullOrEmpty(row["SocketChangeLastDate"].ToString())))
                    {
                        DateS6.Value = row["SocketChangeLastDate"].ToString();
                    }

                    if (!(string.IsNullOrEmpty(row["IsRestartStep3"].ToString())))
                    {
                        if (row["IsRestartStep3"].ToString() == "YES")
                        {
                            SelectS6A2.SelectedIndex = 1;
                        }
                        else if (row["IsRestartStep3"].ToString() == "NO")
                        {
                            SelectS6A2.SelectedIndex = 2;
                        }
                    }

                    //########################### STEP 7 ###################################
                    if (!(string.IsNullOrEmpty(row["CheckLowYieldKanban"].ToString())))
                    {
                        if (row["CheckLowYieldKanban"].ToString() != "NO" && row["CheckLowYieldKanban"].ToString() != "EXP")
                        {
                            SelectS7.SelectedIndex = 1;
                            tbS7.Text = row["CheckLowYieldKanban"].ToString();
                        }
                        else if (row["CheckLowYieldKanban"].ToString() == "NO")
                        {
                            SelectS7.SelectedIndex = 2;
                        }
                        else if (row["CheckLowYieldKanban"].ToString() == "EXP")
                        {
                            SelectS7.SelectedIndex = 3;
                        }
                    }

                    if (!(string.IsNullOrEmpty(row["CheckAlarmBin"].ToString())))
                    {
                        tempStr = row["CheckAlarmBin"].ToString().ToUpper();
                        splitStr = tempStr.Split(',');
                        if (splitStr.Length > 1)
                        {
                            for (int i = 0; i < splitStr.Length; i++)
                            {
                                if (splitStr[i] == "BIN28")
                                {
                                    CheckS7A1.Checked = true;
                                }
                                else if (splitStr[i] == "BIN29")
                                {
                                    CheckS7A2.Checked = true;
                                }
                                else if (splitStr[i] == "BIN30")
                                {
                                    CheckS7A3.Checked = true;
                                }
                                else if (splitStr[i] == "BIN31")
                                {
                                    CheckS7A4.Checked = true;
                                }

                            }
                        }
                        else
                        {
                            if (tempStr == "BIN28")
                            {
                                CheckS7A1.Checked = true;
                            }
                            else if (tempStr == "BIN29")
                            {
                                CheckS7A2.Checked = true;
                            }
                            else if (tempStr == "BIN30")
                            {
                                CheckS7A3.Checked = true;
                            }
                            else if (tempStr == "BIN31")
                            {
                                CheckS7A4.Checked = true;
                            }
                            else if (tempStr == "NO")
                            {
                                CheckS7A5.Checked = true;
                            }
                        }

                    }


                    //########################### STEP 8 ################################
                    if (!(string.IsNullOrEmpty(row["TesterChecker"].ToString())))
                    {
                        if (row["TesterChecker"].ToString() == "OK")
                        {
                            SelectS8A1.SelectedIndex = 1;
                        }
                        else if (row["TesterChecker"].ToString() == "NG")
                        {
                            SelectS8A1.SelectedIndex = 2;
                        }
                        else if (row["TesterChecker"].ToString() == "NO")
                        {
                            SelectS8A1.SelectedIndex = 3;
                        }
                    }


                    if (!(string.IsNullOrEmpty(row["Setup"].ToString())))
                    {
                        if (row["Setup"].ToString() == "OK")
                        {
                            SelectS8A2.SelectedIndex = 1;
                        }
                        else if (row["Setup"].ToString() == "NG")
                        {
                            SelectS8A2.SelectedIndex = 2;
                        }
                        else if (row["Setup"].ToString() == "NO")
                        {
                            SelectS8A2.SelectedIndex = 3;
                        }
                    }


                    tbS8r1c1.Text = row["TNo1"].ToString();
                    tbS8r1c2.Text = row["TNo2"].ToString();
                    tbS8r1c3.Text = row["TNo3"].ToString();
                    tbS8r1c4.Text = row["TNo4"].ToString();
                    tbS8r1c5.Text = row["TNo5"].ToString();

                    tbS8r2c1.Text = row["LimitLow1"].ToString();
                    tbS8r2c2.Text = row["LimitLow2"].ToString();
                    tbS8r2c3.Text = row["LimitLow3"].ToString();
                    tbS8r2c4.Text = row["LimitLow4"].ToString();
                    tbS8r2c5.Text = row["LimitLow5"].ToString();

                    tbS8r3c1.Text = row["LimitHigh1"].ToString();
                    tbS8r3c2.Text = row["LimitHigh2"].ToString();
                    tbS8r3c3.Text = row["LimitHigh3"].ToString();
                    tbS8r3c4.Text = row["LimitHigh4"].ToString();
                    tbS8r3c5.Text = row["LimitHigh5"].ToString();

                    tbS8r4c1.Text = row["MassProductNG1"].ToString();
                    tbS8r4c2.Text = row["MassProductNG2"].ToString();
                    tbS8r4c3.Text = row["MassProductNG3"].ToString();
                    tbS8r4c4.Text = row["MassProductNG4"].ToString();
                    tbS8r4c5.Text = row["MassProductNG5"].ToString();

                    tbS8r5c1.Text = row["GoodSample1"].ToString();
                    tbS8r5c2.Text = row["GoodSample2"].ToString();
                    tbS8r5c3.Text = row["GoodSample3"].ToString();
                    tbS8r5c4.Text = row["GoodSample4"].ToString();
                    tbS8r5c5.Text = row["GoodSample5"].ToString();

                    tbS8r6c1.Text = row["TesterETC1"].ToString();
                    tbS8r6c2.Text = row["TesterETC2"].ToString();
                    tbS8r6c3.Text = row["TesterETC3"].ToString();
                    tbS8r6c4.Text = row["TesterETC4"].ToString();
                    tbS8r6c5.Text = row["TesterETC5"].ToString();

                    tbS8r7c1.Text = row["CheckRepeat1"].ToString();
                    tbS8r7c2.Text = row["CheckRepeat2"].ToString();
                    tbS8r7c3.Text = row["CheckRepeat3"].ToString();
                    tbS8r7c4.Text = row["CheckRepeat4"].ToString();
                    tbS8r7c5.Text = row["CheckRepeat5"].ToString();

                    tbS8r8.Text = row["ProgramName"].ToString();

                    tbS8A1.Text = row["UseMassProductGood"].ToString();
                    tbS8A2.Text = row["UseMassProductNG"].ToString();

                    tbS8A3.Text = row["ScrapAmountGood"].ToString();
                    tbS8A4.Text = row["ScrapAmountNG"].ToString();

                    //################################ STEP 9 ######################
                    if (!(string.IsNullOrEmpty(row["Cause"].ToString())))
                    {
                        if (row["Cause"].ToString() == "TESTER")
                        {
                            SelectS9.SelectedIndex = 1;
                        }
                        else if (row["Cause"].ToString() == "BOX")
                        {
                            SelectS9.SelectedIndex = 2;
                        }
                        else if (row["Cause"].ToString() == "OPTION")
                        {
                            SelectS9.SelectedIndex = 3;
                        }
                        else if (row["Cause"].ToString() == "OPMISS")
                        {
                            SelectS9.SelectedIndex = 4;
                        }
                        else if (row["Cause"].ToString() == "TAKEBACK")
                        {
                            SelectS9.SelectedIndex = 5;
                        }
                        else if (row["Cause"].ToString() == "ICBURN")
                        {
                            SelectS9.SelectedIndex = 6;
                        }
                        else if (row["Cause"].ToString() == "ETC")
                        {
                            SelectS9.SelectedIndex = 7;
                        }
                    }

                    //############################### STEP 10 ############################
                    tbS10r1c1.Text = row["S10TestNoA1"].ToString();
                    tbS10r1c2.Text = row["S10TestNoA2"].ToString();
                    tbS10r1c3.Text = row["S10TestNoA3"].ToString();
                    tbS10r1c4.Text = row["S10TestNoA4"].ToString();
                    tbS10r1c5.Text = row["S10TestNoA5"].ToString();

                    tbS10r2c1.Text = row["S10NGA1"].ToString();
                    tbS10r2c2.Text = row["S10NGA2"].ToString();
                    tbS10r2c3.Text = row["S10NGA3"].ToString();
                    tbS10r2c4.Text = row["S10NGA4"].ToString();
                    tbS10r2c5.Text = row["S10NGA5"].ToString();

                    tbS10r3c1.Text = row["S10TestNoB1"].ToString();
                    tbS10r3c2.Text = row["S10TestNoB2"].ToString();
                    tbS10r3c3.Text = row["S10TestNoB3"].ToString();
                    tbS10r3c4.Text = row["S10TestNoB4"].ToString();
                    tbS10r3c5.Text = row["S10TestNoB5"].ToString();

                    tbS10r4c1.Text = row["S10NGB1"].ToString();
                    tbS10r4c2.Text = row["S10NGB2"].ToString();
                    tbS10r4c3.Text = row["S10NGB3"].ToString();
                    tbS10r4c4.Text = row["S10NGB4"].ToString();
                    tbS10r4c5.Text = row["S10NGB5"].ToString();

                    tbS10A1.Text = row["FinalYield"].ToString();
                    tbS10A2.Text = row["ControlLCL"].ToString();

                    //####################################### STEP 11 ##############################
                    tbS11A1.Text = row["AsiGood"].ToString();
                    tbS11A2.Text = row["AsiNG"].ToString();

                    if (!(string.IsNullOrEmpty(row["AddOn"].ToString())))
                    {
                        if (row["AddOn"].ToString() == "YES")
                        {
                            SelectS11.SelectedIndex = 1;
                        }
                        else if (row["AddOn"].ToString() == "NO")
                        {
                            SelectS11.SelectedIndex = 2;
                        }
                    }

                    tbS11A3.Text = row["AndonManage"].ToString();
                    tbS11A4.Text = row["AndonWho"].ToString();
                    tbS11A5.Text = row["AndonManageDetail"].ToString();


                    //###################### Time Stamp ######################

                    lblStampOP1A1.Text = row["OPName1_Sign"].ToString();
                    lblStampOP1A2.Text = row["OPName1_ID"].ToString();
                    lblStampOP1A3.Text = row["OPName1_SignDate"].ToString();

                    lblStampBMA1.Text = row["TestIncharge_Sign"].ToString();
                    lblStampBMA2.Text = row["TestIncharge_ID"].ToString();
                    lblStampBMA3.Text = row["TestIncharge_SignDate"].ToString();

                    lblStampOP2A1.Text = row["OPName2_Sign"].ToString();
                    lblStampOP2A2.Text = row["OPName2_ID"].ToString();
                    lblStampOP2A3.Text = row["OPName2_SignDate"].ToString();



                }



                foreach (DataRow row in tbl.Rows)
                {
                    txtStoreValue.Text = row["Status"].ToString();  //store Current Status

                    //############################ STEP 15 ###########################
                    if (!(string.IsNullOrEmpty(row["RequestAQIS15"].ToString())))
                    {
                        if (row["RequestAQIS15"].ToString() == "YES")
                        {
                            SelectS15A1.SelectedIndex = 1;
                        }
                        else if (row["RequestAQIS15"].ToString() == "NO")
                        {
                            SelectS15A1.SelectedIndex = 2;
                        }
                    }

                    if (!(string.IsNullOrEmpty(row["StopShipObjDevice"].ToString())))
                    {
                        if (row["StopShipObjDevice"].ToString() == "YES")
                        {
                            SelectS15A2.SelectedIndex = 1;
                        }
                        else if (row["StopShipObjDevice"].ToString() == "NO")
                        {
                            SelectS15A2.SelectedIndex = 2;
                        }
                    }

                    if (!(string.IsNullOrEmpty(row["StopLabel"].ToString())))
                    {
                        if (row["StopLabel"].ToString() == "YES")
                        {
                            SelectS15A3.SelectedIndex = 1;
                        }
                        else if (row["StopLabel"].ToString() == "NO")
                        {
                            SelectS15A3.SelectedIndex = 2;
                        }
                    }

                    //######################### STEP 18 ############################
                    tbS18A1.Text = row["FTRetestGood"].ToString();
                    tbS18A2.Text = row["FTRetestNG"].ToString();

                    if (!(string.IsNullOrEmpty(row["ObjectScope"].ToString())))
                    {
                        if (row["ObjectScope"].ToString() == "YES")
                        {
                            SelectS18A1.SelectedIndex = 1;
                        }
                        else if (row["ObjectScope"].ToString() == "NO")
                        {
                            SelectS18A1.SelectedIndex = 2;
                        }
                    }

                    if (!(string.IsNullOrEmpty(row["StopRecallShipment"].ToString())))
                    {
                        if (row["StopRecallShipment"].ToString() == "YES")
                        {
                            SelectS18A2.SelectedIndex = 1;
                        }
                        else if (row["StopRecallShipment"].ToString() == "NO")
                        {
                            SelectS18A2.SelectedIndex = 2;
                        }
                    }

                    //######################## STEP 20 ##############################
                    if (!(string.IsNullOrEmpty(row["StopShipmentPKG"].ToString())))
                    {
                        if (row["StopShipmentPKG"].ToString() == "YES")
                        {
                            SelectS20A1.SelectedIndex = 1;
                        }
                        else if (row["StopShipmentPKG"].ToString() == "NO")
                        {
                            SelectS20A1.SelectedIndex = 2;
                        }
                    }

                    if (!(string.IsNullOrEmpty(row["Assy"].ToString())))
                    {
                        if (row["Assy"].ToString() == "YES")
                        {
                            SelectS20A2.SelectedIndex = 1;
                        }
                        else if (row["Assy"].ToString() == "NO")
                        {
                            SelectS20A2.SelectedIndex = 2;
                        }
                    }
                }



            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No Data In Table')", true);
            }
        }

        protected void cbStep5_1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbStep5_1.Checked == true)
            {
                rbStep5A1.Enabled = true;
                rbStep5A2.Enabled = true;
                rbStep5A3.Enabled = true;
            }
            else
            {
                rbStep5A1.Enabled = false;
                rbStep5A2.Enabled = false;
                rbStep5A3.Enabled = false;
                rbStep5A1.Checked = false;
                rbStep5A2.Checked = false;
                rbStep5A3.Checked = false;
            }
        }





        public void SetValue()
        {
            gc.Process = Request.Params["Process"]; //get parameter from url
            gc.LotNo = Request.Params["LotNo"]; //get parameter from url
            gc.HandlerNo = Request.Params["MCNo"]; //get parameter from url
            gc.User = Request.Params["User"];
            gc.Edit = Request.Params["Edit"];

            
            //########### set to next status ##########
            if (gc.Edit == "TRUE")
            {
                //this is edit case
                //set status from store current status
                if (tbS11A5.Text == "FLOW LOT CONTACT NG")
                {
                    gc.Status = "7";
                }
                else
                {
                    gc.Status = "5B";
                }
            }
            else if (gc.Edit == "FALSE")
            {
                //this is normal case
                //gc.Status = "7";
                //gc.Status = "5A";

                //ยกเลิก Flow Move Lot 2020-03-11
                //if (SelectS9.SelectedIndex == 5) //if Step9 Select TE take back =  Move Lot
                //{
                //    //go to QC
                //    gc.Status = "8";
                //}

                if (tbS11A5.Text == "FLOW LOT CONTACT NG")
                {
                    gc.Status = "7";
                }
                else
                {
                    gc.Status = "5B";
                }

                //if (StepStatus1 == "OK")
                //{
                //    gc.Status = "END";
                //}
                //else if (StepStatus2 == "OK")
                //{
                //    gc.Status = "END";
                //}
                //else if (StepStatus3 == "OK")
                //{
                //    gc.Status = "END";
                //}
                //else
                //{
                //    //gc.Status = "5A";
                //    gc.Status = "5B";
                //}
            }




            //####### set User Stamp
            gc.GL_ID = gc.User;

            //user sign
            var tbl = new DataTable();

            tbl = dba.Login(gc.User);//Get data from Apcs Database

            if (tbl.Rows.Count == 1)
            {
                foreach (DataRow row in tbl.Rows)
                {
                    gc.GL_Sign = row["name"].ToString(); //get name of user
                }
            }
            else
            {
                gc.GL_Sign = gc.User;
            }

            gc.GL_SignDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // case sensitive



            //################### SET STEP 10 ##########################
            gc.S10TestNoA1 = tbS10r1c1.Text;
            gc.S10TestNoA2 = tbS10r1c2.Text;
            gc.S10TestNoA3 = tbS10r1c3.Text;
            gc.S10TestNoA4 = tbS10r1c4.Text;
            gc.S10TestNoA5 = tbS10r1c5.Text;

            if (tbS10r2c1.Text != "")
            {
                gc.S10NGA1 = Int32.Parse(tbS10r2c1.Text);
            }
            if (tbS10r2c2.Text != "")
            {
                gc.S10NGA2 = Int32.Parse(tbS10r2c2.Text);
            }
            if (tbS10r2c3.Text != "")
            {
                gc.S10NGA3 = Int32.Parse(tbS10r2c3.Text);
            }
            if (tbS10r2c4.Text != "")
            {
                gc.S10NGA4 = Int32.Parse(tbS10r2c4.Text);
            }
            if (tbS10r2c5.Text != "")
            {
                gc.S10NGA5 = Int32.Parse(tbS10r2c5.Text);
            }

            gc.S10TestNoB1 = tbS10r3c1.Text;
            gc.S10TestNoB2 = tbS10r3c2.Text;
            gc.S10TestNoB3 = tbS10r3c3.Text;
            gc.S10TestNoB4 = tbS10r3c4.Text;
            gc.S10TestNoB5 = tbS10r3c5.Text;

            if (tbS10r4c1.Text != "")
            {
                gc.S10NGB1 = Int32.Parse(tbS10r4c1.Text);
            }
            if (tbS10r4c2.Text != "")
            {
                gc.S10NGB2 = Int32.Parse(tbS10r4c2.Text);
            }
            if (tbS10r4c3.Text != "")
            {
                gc.S10NGB3 = Int32.Parse(tbS10r4c3.Text);
            }
            if (tbS10r4c4.Text != "")
            {
                gc.S10NGB4 = Int32.Parse(tbS10r4c4.Text);
            }
            if (tbS10r4c5.Text != "")
            {
                gc.S10NGB5 = Int32.Parse(tbS10r4c5.Text);
            }

            if (tbS10A1.Text != "")
            {
                gc.FinalYield = tbS10A1.Text;
            }
            if (tbS10A2.Text != "")
            {
                gc.ControlLCL = tbS10A2.Text;
            }



            //##################### STEP 11 #####################

            gc.AsiGood = tbS11A1.Text;

            gc.AsiNG = tbS11A2.Text;


            if (SelectS11.SelectedIndex == 0)
            {
                gc.AddOn = "";
            }
            else if (SelectS11.SelectedIndex == 1)
            {
                gc.AddOn = "YES";
            }
            else if (SelectS11.SelectedIndex == 2)
            {
                gc.AddOn = "NO";
            }


            gc.AndonManage = tbS11A3.Text;
            gc.AndonWho = tbS11A4.Text;
            gc.AndonManageDetail = tbS11A5.Text;



            //############## SET STEP 15 ##########################
            if (SelectS15A1.SelectedIndex == 0)
            {
                gc.RequestAQIS15 = "";
            }
            else if (SelectS15A1.SelectedIndex == 1)
            {
                gc.RequestAQIS15 = "YES";
            }
            else if (SelectS15A1.SelectedIndex == 2)
            {
                gc.RequestAQIS15 = "NO";
            }


            if (SelectS15A2.SelectedIndex == 0)
            {
                gc.StopShipObjDevice = "";
            }
            else if (SelectS15A2.SelectedIndex == 1)
            {
                gc.StopShipObjDevice = "YES";
            }
            else if (SelectS15A2.SelectedIndex == 2)
            {
                gc.StopShipObjDevice = "NO";
            }


            if (SelectS15A3.SelectedIndex == 0)
            {
                gc.StopLabel = "";
            }
            else if (SelectS15A3.SelectedIndex == 1)
            {
                gc.StopLabel = "YES";
            }
            else if (SelectS15A3.SelectedIndex == 2)
            {
                gc.StopLabel = "NO";
            }


            //########################## SET STEP 18 #########################
            gc.FTRetestGood = tbS18A1.Text;
            gc.FTRetestNG = tbS18A2.Text;


            if (SelectS18A1.SelectedIndex == 0)
            {
                gc.ObjectScope = "";
            }
            else if (SelectS18A1.SelectedIndex == 1)
            {
                gc.ObjectScope = "YES";
            }
            else if (SelectS18A1.SelectedIndex == 2)
            {
                gc.ObjectScope = "NO";
            }


            if (SelectS18A2.SelectedIndex == 0)
            {
                gc.StopRecallShipment = "";
            }
            else if (SelectS18A2.SelectedIndex == 1)
            {
                gc.StopRecallShipment = "YES";
            }
            else if (SelectS18A2.SelectedIndex == 2)
            {
                gc.StopRecallShipment = "NO";
            }

            //################################## SET STEP 20 ###################
            if (SelectS20A1.SelectedIndex == 0)
            {
                gc.StopShipmentPKG = "";
            }
            else if (SelectS20A1.SelectedIndex == 1)
            {
                gc.StopShipmentPKG = "YES";
            }
            else if (SelectS20A1.SelectedIndex == 2)
            {
                gc.StopShipmentPKG = "NO";
            }


            if (SelectS20A2.SelectedIndex == 0)
            {
                gc.Assy = "";
            }
            else if (SelectS20A2.SelectedIndex == 1)
            {
                gc.Assy = "YES";
            }
            else if (SelectS20A2.SelectedIndex == 2)
            {
                gc.Assy = "NO";
            }

            //################################## Add 2020-09-16 ###################
            if (controlbmno != null)
            {
                gc.ControlBMNo = controlbmno;
            }

            if (bmid != null)
            {
                gc.BMID = Int16.Parse(bmid);
            }

            if (Iss != null)
            {
                gc.IssueNo = Iss;
            }

            //Add 2020-10-20
            if (socket != null)
            {
                gc.CheckSocket = socket;
            }
                
        }

        //public void ConfirmBtnOnClick(object sender, EventArgs e)
        //{
        //    SetValue();

        //    dba.UpdatePageUser4(gc.Process, gc.HandlerNo, gc.LotNo, gc.Status, gc.S10TestNoA1, gc.S10TestNoA2, gc.S10TestNoA3, gc.S10TestNoA4, gc.S10TestNoA5,
        //        gc.S10NGA1, gc.S10NGA2, gc.S10NGA3, gc.S10NGA4, gc.S10NGA5, gc.S10TestNoB1, gc.S10TestNoB2, gc.S10TestNoB3, gc.S10TestNoB4, gc.S10TestNoB5,
        //        gc.S10NGB1, gc.S10NGB2, gc.S10NGB3, gc.S10NGB4, gc.S10NGB5, gc.FinalYield, gc.ControlLCL, gc.AsiGood, gc.AsiNG, gc.AddOn,
        //        gc.AndonManage, gc.AndonWho, gc.AndonManageDetail,
        //        gc.GL_ID, gc.GL_Sign, gc.GL_SignDate);

        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Save Done')", true);
        //    Response.Redirect("~/PageMonitoring.aspx");
        //}
        public void ConfirmBtnOnClick(object sender, EventArgs e)
        {
            SetValue();

            dba.UpdatePageUser4(gc.Process, gc.HandlerNo, gc.LotNo, gc.Status, gc.S10TestNoA1, gc.S10TestNoA2, gc.S10TestNoA3, gc.S10TestNoA4, gc.S10TestNoA5,
                gc.S10NGA1, gc.S10NGA2, gc.S10NGA3, gc.S10NGA4, gc.S10NGA5, gc.S10TestNoB1, gc.S10TestNoB2, gc.S10TestNoB3, gc.S10TestNoB4, gc.S10TestNoB5,
                gc.S10NGB1, gc.S10NGB2, gc.S10NGB3, gc.S10NGB4, gc.S10NGB5, gc.FinalYield, gc.ControlLCL, gc.AsiGood, gc.AsiNG, gc.AddOn,
                gc.AndonManage, gc.AndonWho, gc.AndonManageDetail,
                gc.RequestAQIS15, gc.StopShipObjDevice, gc.StopLabel, gc.JudgementResult, gc.FTRetestGood, gc.FTRetestNG, gc.ObjectScope,
                gc.StopRecallShipment, gc.StopShipmentPKG, gc.Assy,
                gc.GL_ID, gc.GL_Sign, gc.GL_SignDate);

            if (gc.Status == "END") // if not edit mode then do this
            {
                dba.MoveToHistory8(gc.Process, gc.HandlerNo, gc.LotNo, gc.PackageName, gc.DeviceName, gc.RequestDate, gc.Mode, gc.Status, gc.Describe, gc.RequestType, gc.AmountNG, gc.Flow, gc.MNo, gc.TesterNo, gc.BoxNo, gc.TRank, gc.WaferLotNo, gc.WaferSheetNo,
                    gc.TPRank, gc.Shipment, gc.InputQuantity, gc.ControlYield, gc.InitialYield, gc.CheckValue, gc.ActionPCS, gc.ActionPercent, gc.S2TestNoA1, gc.S2TestNoA2, gc.S2TestNoA3, gc.S2TestNoA4, gc.S2TestNoA5, gc.S2NG_A1, gc.S2NG_A2, gc.S2NG_A3, gc.S2NG_A4, gc.S2NG_A5,
                    gc.S2TestNoB1, gc.S2TestNoB2, gc.S2TestNoB3, gc.S2TestNoB4, gc.S2TestNoB5, gc.S2NG_B1, gc.S2NG_B2, gc.S2NG_B3, gc.S2NG_B4, gc.S2NG_B5, gc.SetupCheck, gc.ManaulCheck1, gc.Result1_1, gc.ManaulCheck1_2, gc.Result1_2, gc.ManaulCheck1_3, gc.Result1_3, gc.ManaulCheck2, gc.Result2, gc.ManaulCheck3, gc.Result3,
                    gc.SocketChangeHist, gc.SocketChangeLastDate, gc.IsRestartStep3, gc.CheckLowYieldKanban, gc.CheckAlarmBin, gc.TesterChecker, gc.Setup, gc.TNo1, gc.TNo2, gc.TNo3, gc.TNo4, gc.TNo5, gc.LimitLow1, gc.LimitLow2, gc.LimitLow3, gc.LimitLow4, gc.LimitLow5, gc.LimitHigh1, gc.LimitHigh2, gc.LimitHigh3, gc.LimitHigh4, gc.LimitHigh5,
                    gc.MassProductNG1, gc.MassProductNG2, gc.MassProductNG3, gc.MassProductNG4, gc.MassProductNG5, gc.GoodSample1, gc.GoodSample2, gc.GoodSample3, gc.GoodSample4, gc.GoodSample5, gc.TesterETC1, gc.TesterETC2, gc.TesterETC3, gc.TesterETC4, gc.TesterETC5, gc.CheckRepeat1, gc.CheckRepeat2, gc.CheckRepeat3, gc.CheckRepeat4, gc.CheckRepeat5,
                    gc.ProgramName, gc.UseMassProductGood, gc.UseMassProductNG, gc.ScrapAmountGood, gc.ScrapAmountNG, gc.Cause, gc.S10TestNoA1, gc.S10TestNoA2, gc.S10TestNoA3, gc.S10TestNoA4, gc.S10TestNoA5, gc.S10NGA1, gc.S10NGA2, gc.S10NGA3, gc.S10NGA4, gc.S10NGA5, gc.S10TestNoB1, gc.S10TestNoB2, gc.S10TestNoB3, gc.S10TestNoB4, gc.S10TestNoB5,
                    gc.S10NGB1, gc.S10NGB2, gc.S10NGB3, gc.S10NGB4, gc.S10NGB5, gc.FinalYield, gc.ControlLCL, gc.AsiGood, gc.AsiNG, gc.AddOn, gc.AndonManage, gc.AndonWho, gc.AndonManageDetail, gc.TestResultGood, gc.TestResultNG, gc.RequestAQIS13, gc.StopNextLotS13, gc.KanbanCtrlNo, gc.KanbanTestNo, gc.KanbanExpireDate,
                    gc.ResultBurnGood, gc.ResultBurnNG, gc.ResultChipCrackGood, gc.ResultChipCrackNG, gc.ResultChipMixGood, gc.ResultChipMixNG, gc.RequestAQIS14, gc.StopNextLotS14, gc.StopPKGS14, gc.RequestAQIS15, gc.StopShipObjDevice, gc.StopLabel, gc.SystemInspection, gc.JudgementResult, gc.FTRetestGood,
                    gc.FTRetestNG, gc.ObjectScope, gc.StopRecallShipment, gc.LowYieldAnalysis, gc.StopShipmentPKG, gc.Assy, gc.QCJudgement, gc.OPName1_ID, gc.TestIncharge_ID, gc.OPName2_ID, gc.GL_ID, gc.AnalysisIncharge_ID, gc.FYIFQIIncharge_ID, gc.PDMgr_ID, gc.QCIncharge_ID, gc.OPName1_Sign, gc.TestIncharge_Sign,
                    gc.OPName2_Sign, gc.GL_Sign, gc.AnalysisIncharge_Sign, gc.FYIFQIIncharge_Sign, gc.PDMgr_Sign, gc.QCIncharge_Sign, gc.OPName1_SignDate, gc.TestIncharge_SignDate, gc.OPName2_SignDate, gc.GL_SignDate, gc.AnalysisIncharge_SignDate, gc.FYIFQIIncharge_SignDate, gc.PDMgr_SignDate, gc.QCIncharge_SignDate, gc.TesttotalAmount,
                    gc.SelectS16, gc.TEIncharge_ID, gc.TEIncharge_Sign, gc.TEIncharge_SignDate, gc.Shipmentdate, gc.LowYieldMode, gc.ControlBMNo, gc.BMID, gc.IssueNo,gc.CheckSocket, gc.QCApprove_ID, gc.QCApprove_Sign, gc.QCApprove_Date);

                dba.DeleteReportRow(gc.Process, gc.HandlerNo, gc.LotNo);
            }
            // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Save Done')", true);
            string strUrl;
            strUrl = "~/PageMonitoring_GL.aspx?userId=" + Request.Params["User"];
            Response.Redirect(strUrl);
        }



        protected void BtnClose_ServerClick(object sender, EventArgs e)
        {
            string strUrl;
            strUrl = "~/PageMonitoring_GL.aspx?userId=" + Request.Params["User"];
            Response.Redirect(strUrl);
        }


        public Boolean Isnumeric(string str)
        {
            double Result;
            // String(integer,double),it will return true 
            return double.TryParse(str, out Result);
        }


        private void SetRequestType(string LCL, string Yield, string Alarmbin)
        {
            if (!(string.IsNullOrEmpty(LCL)) && !(string.IsNullOrEmpty(Yield)))
            {
                double tmpLCL = 0;
                double tmpYield = 0;

                //check value is numeric before parse
                if (Isnumeric(LCL) && Isnumeric(Yield))
                {
                    double.TryParse(LCL, out tmpLCL);
                    double.TryParse(Yield, out tmpYield);
                }

                tempStr = "";

                //check low yield
                if (tmpLCL > tmpYield)
                {
                    tempStr = "Request Type : Low Yield ";
                }

                //check bin
                if (!(string.IsNullOrEmpty(Alarmbin)))
                {
                    if (Alarmbin.ToUpper() != "NO")
                    {
                        tempStr2 = Alarmbin.ToUpper();
                        splitStr = tempStr2.Split(',');
                        if (splitStr.Length > 1)
                        {
                            if (tempStr == "")
                            {
                                tempStr = "Request Type : Alarm ";
                            }
                            else
                            {
                                tempStr = tempStr + " & Alarm ";
                            }

                            for (int i = 0; i < splitStr.Length; i++)
                            {
                                if (splitStr[i] == "BIN28")
                                {
                                    tempStr = tempStr + "BIN28 ";
                                }
                                else if (splitStr[i] == "BIN29")
                                {
                                    tempStr = tempStr + "BIN29 ";
                                }
                                else if (splitStr[i] == "BIN30")
                                {
                                    tempStr = tempStr + "BIN30 ";
                                }
                                else if (splitStr[i] == "BIN31")
                                {
                                    tempStr = tempStr + "BIN31 ";
                                }

                            }
                        }
                        else
                        {
                            if (tempStr == "")
                            {
                                tempStr = "Request Type : Alarm ";
                            }
                            else
                            {
                                tempStr = tempStr + " & Alarm ";
                            }

                            if (tempStr2 == "BIN28")
                            {
                                tempStr = tempStr + tempStr2;
                            }
                            else if (tempStr2 == "BIN29")
                            {
                                tempStr = tempStr + tempStr2;
                            }
                            else if (tempStr2 == "BIN30")
                            {
                                tempStr = tempStr + tempStr2;
                            }
                            else if (tempStr2 == "BIN31")
                            {
                                tempStr = tempStr + tempStr2;
                            }
                        }
                    }
                }

                lblRequestType.Text = tempStr;
            }
        }




    }
}