using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LowYieldCheckSheet
{
    public partial class InputPageUser3_Test : System.Web.UI.Page
    {
        DBAccess dba = new DBAccess();
        GlobalClass gc = new GlobalClass();

        string[] splitStr;
        string tempStr;
        string tempStr2;

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


                    //###################### Time Stamp ######################
                    lblStampOP1A1.Text = row["OPName1_Sign"].ToString();
                    lblStampOP1A2.Text = row["OPName1_ID"].ToString();
                    lblStampOP1A3.Text = row["OPName1_SignDate"].ToString();

                    lblStampBMA1.Text = row["TestIncharge_Sign"].ToString();
                    lblStampBMA2.Text = row["TestIncharge_ID"].ToString();
                    lblStampBMA3.Text = row["TestIncharge_SignDate"].ToString();






                }


                foreach (DataRow row in tbl.Rows)
                {
                    txtStoreValue.Text = row["Status"].ToString();  //store Current Status

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
                    if (SelectS12.SelectedIndex == 0)
                    {
                        gc.AndonManageDetail = "";
                    }
                    else if (SelectS12.SelectedIndex == 1)
                    {
                        gc.AndonManageDetail = "FLOW LOT CONTACT NG";
                    }
                    else if (SelectS12.SelectedIndex == 2)
                    {
                        gc.AndonManageDetail = "HOLD QYI";
                    }
                    //gc.AndonManageDetail = tbS11A5.Text;

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
                gc.Status = txtStoreValue.Text;
            }
            else if (gc.Edit == "FALSE")
            {
                ////this is normal case
                //if (SelectS12.SelectedIndex == 1)
                //{
                //    gc.Status = "4";
                //}
                //else if (SelectS12.SelectedIndex == 2)
                //{
                //    gc.Status = "5B";
                //}
                gc.Status = "4";
            }


            //set User Stamp
            //uer id
            gc.OPName2_ID = gc.User;

            //user sign
            var tbl = new DataTable();

            tbl = dba.Login(gc.User);//Get data from Apcs Database

            if (tbl.Rows.Count == 1)
            {
                foreach (DataRow row in tbl.Rows)
                {
                    gc.OPName2_Sign = row["name"].ToString(); //get name of user
                }
            }
            else
            {
                gc.OPName2_Sign = gc.User;
            }

            //user sign date
            gc.OPName2_SignDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // case sensitive


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
            if (SelectS12.SelectedIndex == 0)
            {
                gc.AndonManageDetail = "";
            }
            else if (SelectS12.SelectedIndex == 1)
            {
                gc.AndonManageDetail = "FLOW LOT CONTACT NG";
            }
            else if (SelectS12.SelectedIndex == 2)
            {
                gc.AndonManageDetail = "HOLD QYI";
            }
            //gc.AndonManageDetail = tbS11A5.Text;

        }



        public void ConfirmBtnOnClick(object sender, EventArgs e)
        {
            if (CheckEmptyInput()) //if this function return true it's mean Operator is not fill in some textbox
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณากรอกช่องที่มีสีแดงให้ครบถ้วน \\n Please fill in all Red textbox !!!')", true);
            }
            else //Everything is OK. go go go
            {
                SetValue();

                dba.UpdatePageUser3(gc.Process, gc.HandlerNo, gc.LotNo, gc.Status, gc.S10TestNoA1, gc.S10TestNoA2, gc.S10TestNoA3, gc.S10TestNoA4, gc.S10TestNoA5,
                    gc.S10NGA1, gc.S10NGA2, gc.S10NGA3, gc.S10NGA4, gc.S10NGA5, gc.S10TestNoB1, gc.S10TestNoB2, gc.S10TestNoB3, gc.S10TestNoB4, gc.S10TestNoB5,
                    gc.S10NGB1, gc.S10NGB2, gc.S10NGB3, gc.S10NGB4, gc.S10NGB5, gc.FinalYield, gc.ControlLCL, gc.AsiGood, gc.AsiNG, gc.AddOn,
                    gc.AndonManage, gc.AndonWho, gc.AndonManageDetail, gc.OPName2_ID, gc.OPName2_Sign, gc.OPName2_SignDate);

                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Save Done')", true);

                string strUrl;
                strUrl = "~/PageMonitoring_OP.aspx?userId=" + Request.Params["User"];
                Response.Redirect(strUrl);
            }
        }



        protected void BtnClose_ServerClick(object sender, EventArgs e)
        {
            string strUrl;
            strUrl = "~/PageMonitoring_OP.aspx?userId=" + Request.Params["User"];
            Response.Redirect(strUrl);
        }


        public Boolean CheckEmptyInput()
        {
            Boolean result = false;
            int countEmpty = 0;

            //############################### Step 10 ##############################

            //############################# Ach #############

            //Test No
            if (String.IsNullOrEmpty(tbS10r1c1.Text))
            {
                tbS10r1c1.BackColor = System.Drawing.Color.Red;
                countEmpty += 1;
            }
            else
            {
                tbS10r1c1.BackColor = System.Drawing.Color.White;
            }


            //จำนวน NG
            if (String.IsNullOrEmpty(tbS10r2c1.Text))
            {
                tbS10r2c1.BackColor = System.Drawing.Color.Red;
                countEmpty += 1;
            }
            else
            {
                tbS10r2c1.BackColor = System.Drawing.Color.White;
            }



            // ############################ Bch ####################
            //Test No
            if (String.IsNullOrEmpty(tbS10r3c1.Text))
            {
                tbS10r3c1.BackColor = System.Drawing.Color.Red;
                countEmpty += 1;
            }
            else
            {
                tbS10r3c1.BackColor = System.Drawing.Color.White;
            }


            //จำนวน NG
            if (String.IsNullOrEmpty(tbS10r4c1.Text))
            {
                tbS10r4c1.BackColor = System.Drawing.Color.Red;
                countEmpty += 1;
            }
            else
            {
                tbS10r4c1.BackColor = System.Drawing.Color.White;
            }

            
            //fianl yield
            if (String.IsNullOrEmpty(tbS10A1.Text))
            {
                tbS10A1.BackColor = System.Drawing.Color.Red;
                countEmpty += 1;
            }
            else
            {
                tbS10A1.BackColor = System.Drawing.Color.White;
            }

            //control yield
            if (String.IsNullOrEmpty(tbS10A2.Text))
            {
                tbS10A2.BackColor = System.Drawing.Color.Red;
                countEmpty += 1;
            }
            else
            {
                tbS10A2.BackColor = System.Drawing.Color.White;
            }

            //การจัดการอย่างไร ?
            if (SelectS12.SelectedIndex == 0)
            {
                SelectS12.BackColor = System.Drawing.Color.Red;
                countEmpty += 1;
            }
            else
            {
                SelectS12.BackColor = System.Drawing.Color.White;
            }

            //#################### Check count empty ###############
            if (countEmpty > 0)
            {
                result = true;
            }

            return result;

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

        protected void tbS11A1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}