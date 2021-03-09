using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace LowYieldCheckSheet
{
    public partial class InputPageUser9 : System.Web.UI.Page
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
            gc.Edit = Request.Params["Edit"];//get parameter from url
            gc.TEIncharge_ID = Request.Params["User"]; //get parameter from url

            var tbl = new DataTable();
            tbl = dba.PullByMCNoAndLotNo(gc.Process, gc.HandlerNo, gc.LotNo);  //Get Data history And Keep it in tbl

            if (tbl.Rows.Count == 1)
            {
                foreach (DataRow row in tbl.Rows)
                {
                    txtStoreValue.Text = row["Status"].ToString();  //store Current Status

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

                    //Add 28-02-2020 Unsaya
                    txtRequestDate.Text = row["RequestDate"].ToString();
                    txtMode.Text = row["Mode"].ToString();
                    txtDescribe.Text = row["Describe"].ToString();
                    txtRequestType.Text = row["RequestType"].ToString();
                    txtFlow.Text = row["Flow"].ToString();
                    txtShipment.Text = row["Shipment"].ToString();
                    txtSetupCheck.Text = row["SetupCheck"].ToString();
                    txtManaulCheck1.Text = row["ManaulCheck1"].ToString();
                    txtResult1_1.Text = row["Result1_1"].ToString();
                    txtManaulCheck1_2.Text = row["ManaulCheck1_2"].ToString();
                    txtResult1_2.Text = row["Result1_2"].ToString();
                    txtManaulCheck1_3.Text = row["ManaulCheck1_3"].ToString();
                    txtManaulCheck2.Text = row["ManaulCheck2"].ToString();
                    txtResult2.Text = row["Result2"].ToString();
                    txtManaulCheck3.Text = row["ManaulCheck3"].ToString();
                    txtResult3.Text = row["Result3"].ToString();
                    txtSocketChangeHist.Text = row["SocketChangeHist"].ToString();
                    txtIsRestartStep3.Text = row["IsRestartStep3"].ToString();
                    txtCheckLowYieldKanban.Text = row["CheckLowYieldKanban"].ToString();
                    txtCheckAlarmBin.Text = row["CheckAlarmBin"].ToString();
                    txtTesterChecker.Text = row["TesterChecker"].ToString();
                    txtSetup.Text = row["Setup"].ToString();
                    txtCause.Text = row["Cause"].ToString();
                    txtAddOn.Text = row["AddOn"].ToString();
                    txtRequestAQIS13.Text = row["RequestAQIS13"].ToString();
                    txtStopNextLotS13.Text = row["StopNextLotS13"].ToString();
                    txtRequestAQIS14.Text = row["RequestAQIS14"].ToString();
                    txtStopNextLotS14.Text = row["StopNextLotS14"].ToString();
                    txtStopPKGS14.Text = row["StopPKGS14"].ToString();
                    txtSystemInspection.Text = row["SystemInspection"].ToString();
                    txtJudgementResult.Text = row["JudgementResult"].ToString();
                    txtLowYieldAnalysis.Text = row["LowYieldAnalysis"].ToString();


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

                    //################################## STEP 13 ######################################
                    tbS13A1.Text = row["TestTotalAmount"].ToString();
                    tbS13A2.Text = row["TestResultGood"].ToString();
                    tbS13A3.Text = row["TestResultNG"].ToString();

                    if (!(string.IsNullOrEmpty(row["RequestAQIS13"].ToString())))
                    {
                        if (row["RequestAQIS13"].ToString() == "YES")
                        {
                            SelectS13A1.SelectedIndex = 1;
                        }
                        else if (row["RequestAQIS13"].ToString() == "NO")
                        {
                            SelectS13A1.SelectedIndex = 2;
                        }
                    }

                    if (!(string.IsNullOrEmpty(row["StopNextLotS13"].ToString())))
                    {
                        if (row["StopNextLotS13"].ToString() == "YES")
                        {
                            SelectS13A2.SelectedIndex = 1;
                        }
                        else if (row["StopNextLotS13"].ToString() == "NO")
                        {
                            SelectS13A2.SelectedIndex = 2;
                        }
                    }

                    tbS13A4.Text = row["KanbanCtrlNo"].ToString();
                    tbS13A5.Text = row["KanbanTestNo"].ToString();

                    dateS13.Value = row["KanbanExpireDate"].ToString();

                    //################################### STEP 14 #############################
                    tbS14A1.Text = row["ResultBurnGood"].ToString();
                    tbS14A2.Text = row["ResultBurnNG"].ToString();

                    tbS14A3.Text = row["ResultChipCrackGood"].ToString();
                    tbS14A4.Text = row["ResultChipCrackNG"].ToString();

                    tbS14A5.Text = row["ResultChipMixGood"].ToString();
                    tbS14A6.Text = row["ResultChipMixNG"].ToString();

                    if (!(string.IsNullOrEmpty(row["RequestAQIS14"].ToString())))
                    {
                        if (row["RequestAQIS14"].ToString() == "YES")
                        {
                            SelectS14A1.SelectedIndex = 1;
                        }
                        else if (row["RequestAQIS14"].ToString() == "NO")
                        {
                            SelectS14A1.SelectedIndex = 2;
                        }
                    }

                    if (!(string.IsNullOrEmpty(row["StopNextLotS14"].ToString())))
                    {
                        if (row["StopNextLotS14"].ToString() == "YES")
                        {
                            SelectS14A2.SelectedIndex = 1;
                        }
                        else if (row["StopNextLotS14"].ToString() == "NO")
                        {
                            SelectS14A2.SelectedIndex = 2;
                        }
                    }

                    if (!(string.IsNullOrEmpty(row["StopPKGS14"].ToString())))
                    {
                        if (row["StopPKGS14"].ToString() == "YES")
                        {
                            SelectS14A3.SelectedIndex = 1;
                        }
                        else if (row["StopPKGS14"].ToString() == "NO")
                        {
                            SelectS14A3.SelectedIndex = 2;
                        }
                    }

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


                    //############################ STEP 16 ########################
                    if (!(string.IsNullOrEmpty(row["SystemInspection"].ToString())))
                    {
                        if (row["SystemInspection"].ToString() == "OK")
                        {
                            SelectS16.SelectedIndex = 1;
                        }
                        else if (row["SystemInspection"].ToString() == "NG")
                        {
                            SelectS16.SelectedIndex = 2;
                        }
                    }

                    //####################### STEP 17 #############################
                    if (!(string.IsNullOrEmpty(row["JudgementResult"].ToString())))
                    {
                        if (row["JudgementResult"].ToString() == "FLOW")
                        {
                            SelectS17.SelectedIndex = 1;
                        }
                        else
                        {
                            SelectS17.SelectedIndex = 2;
                            tbS17.Text = row["JudgementResult"].ToString();
                        }
                    }


                    

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

                    lblStampGLA1.Text = row["GL_Sign"].ToString();
                    lblStampGLA2.Text = row["GL_ID"].ToString();
                    lblStampGLA3.Text = row["GL_SignDate"].ToString();


                    lblStampQYI1A1.Text = row["AnalysisIncharge_Sign"].ToString();
                    lblStampQYI1A2.Text = row["AnalysisIncharge_ID"].ToString();
                    lblStampQYI1A3.Text = row["AnalysisIncharge_SignDate"].ToString();

                    lblStampQYI3A1.Text = row["FYIFQIIncharge_Sign"].ToString();
                    lblStampQYI3A2.Text = row["FYIFQIIncharge_ID"].ToString();
                    lblStampQYI3A3.Text = row["FYIFQIIncharge_SignDate"].ToString();

                    lblStampPDMGRA1.Text = row["PDMgr_Sign"].ToString();
                    lblStampPDMGRA2.Text = row["PDMgr_ID"].ToString();
                    lblStampPDMGRA3.Text = row["PDMgr_SignDate"].ToString();

                }



            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No Data In Table')", true);
            }
        }

        public void SetValue()
        {
            //Get data 28/02/2020
            gc.PackageName = tbHead4.Text;
            gc.DeviceName = tbHead5.Text;
            gc.RequestDate = txtRequestDate.Text;
            if (txtMode.Text != "")
            {
                gc.Mode = Int16.Parse(txtMode.Text);
            }

            gc.Describe = txtDescribe.Text;
            gc.RequestType = txtRequestType.Text;
            if (tbHead1.Text != "")
            {
                gc.AmountNG = Int16.Parse(tbHead1.Text);
            }

            gc.Flow = txtFlow.Text;
            gc.MNo = tbHead6.Text;
            gc.TesterNo = tbHead7.Text;
            gc.BoxNo = tbHead8.Text;
            gc.TRank = tbHead9.Text;
            gc.WaferLotNo = tbHead10.Text;
            gc.WaferSheetNo = tbHead11.Text;
            gc.TPRank = tbHead12.Text;
            gc.Shipment = txtShipment.Text;
            if (tbS1A1.Text != "")
            {
                gc.InputQuantity = Int32.Parse(tbS1A1.Text);
            }
            gc.ControlYield = tbS1A2.Text;
            gc.InitialYield = tbS1A3.Text;
            gc.CheckValue = tbS1A4.Text;
            if (tbS1A5.Text != "")
            {
                gc.ActionPCS = Int32.Parse(tbS1A5.Text);
            }
            gc.ActionPercent = tbS1A6.Text;
            gc.S2TestNoA1 = tbS2r1c1.Text;
            gc.S2TestNoA2 = tbS2r1c2.Text;
            gc.S2TestNoA3 = tbS2r1c3.Text;
            gc.S2TestNoA4 = tbS2r1c4.Text;
            gc.S2TestNoA5 = tbS2r1c5.Text;

            if (tbS2r2c1.Text != "")
            {
                gc.S2NG_A1 = Int32.Parse(tbS2r2c1.Text);
            }
            if (tbS2r2c2.Text != "")
            {
                gc.S2NG_A2 = Int32.Parse(tbS2r2c2.Text);
            }
            if (tbS2r2c3.Text != "")
            {
                gc.S2NG_A3 = Int32.Parse(tbS2r2c3.Text);
            }
            if (tbS2r2c4.Text != "")
            {
                gc.S2NG_A4 = Int32.Parse(tbS2r2c4.Text);
            }
            if (tbS2r2c5.Text != "")
            {
                gc.S2NG_A5 = Int32.Parse(tbS2r2c5.Text);
            }

            gc.S2TestNoB1 = tbS2r3c1.Text;
            gc.S2TestNoB2 = tbS2r3c2.Text;
            gc.S2TestNoB3 = tbS2r3c3.Text;
            gc.S2TestNoB4 = tbS2r3c4.Text;
            gc.S2TestNoB5 = tbS2r3c5.Text;


            if (tbS2r4c1.Text != "")
            {
                gc.S2NG_B1 = Int32.Parse(tbS2r4c1.Text);
            }
            if (tbS2r4c2.Text != "")
            {
                gc.S2NG_B2 = Int32.Parse(tbS2r4c2.Text);
            }
            if (tbS2r4c3.Text != "")
            {
                gc.S2NG_B3 = Int32.Parse(tbS2r4c3.Text);
            }
            if (tbS2r4c4.Text != "")
            {
                gc.S2NG_B4 = Int32.Parse(tbS2r4c4.Text);
            }
            if (tbS2r4c5.Text != "")
            {
                gc.S2NG_B5 = Int32.Parse(tbS2r4c5.Text);
            }

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
            gc.SocketChangeLastDate = DateS6.Value;
            gc.IsRestartStep3 = txtIsRestartStep3.Text;
            gc.CheckLowYieldKanban = txtCheckLowYieldKanban.Text;
            gc.CheckAlarmBin = txtCheckAlarmBin.Text;
            gc.TesterChecker = txtTesterChecker.Text;
            gc.Setup = txtSetup.Text;
            gc.TNo1 = tbS8r1c1.Text;
            gc.TNo2 = tbS8r1c2.Text;
            gc.TNo3 = tbS8r1c3.Text;
            gc.TNo4 = tbS8r1c4.Text;
            gc.TNo5 = tbS8r1c5.Text;
            gc.LimitLow1 = tbS8r2c1.Text;
            gc.LimitLow2 = tbS8r2c2.Text;
            gc.LimitLow3 = tbS8r2c3.Text;
            gc.LimitLow4 = tbS8r2c4.Text;
            gc.LimitLow5 = tbS8r2c5.Text;
            gc.LimitHigh1 = tbS8r3c1.Text;
            gc.LimitHigh2 = tbS8r3c2.Text;
            gc.LimitHigh3 = tbS8r3c3.Text;
            gc.LimitHigh4 = tbS8r3c4.Text;
            gc.LimitHigh5 = tbS8r3c5.Text;
            gc.MassProductNG1 = tbS8r4c1.Text;
            gc.MassProductNG2 = tbS8r4c2.Text;
            gc.MassProductNG3 = tbS8r4c3.Text;
            gc.MassProductNG4 = tbS8r4c4.Text;
            gc.MassProductNG5 = tbS8r4c5.Text;
            gc.GoodSample1 = tbS8r5c1.Text;
            gc.GoodSample2 = tbS8r5c2.Text;
            gc.GoodSample3 = tbS8r5c3.Text;
            gc.GoodSample4 = tbS8r5c4.Text;
            gc.GoodSample5 = tbS8r5c5.Text;
            gc.TesterETC1 = tbS8r6c1.Text;
            gc.TesterETC2 = tbS8r6c2.Text;
            gc.TesterETC3 = tbS8r6c3.Text;
            gc.TesterETC4 = tbS8r6c4.Text;
            gc.TesterETC5 = tbS8r6c5.Text;
            gc.CheckRepeat1 = tbS8r7c1.Text;
            gc.CheckRepeat2 = tbS8r7c2.Text;
            gc.CheckRepeat3 = tbS8r7c3.Text;
            gc.CheckRepeat4 = tbS8r7c4.Text;
            gc.CheckRepeat5 = tbS8r7c5.Text;
            gc.ProgramName = tbS8r8.Text;
            if (tbS8A1.Text != "")
            {
                gc.UseMassProductGood = Int32.Parse(tbS8A1.Text);
            }
            if (tbS8A2.Text != "")
            {
                gc.UseMassProductNG = Int32.Parse(tbS8A2.Text);
            }
            if (tbS8A3.Text != "")
            {
                gc.ScrapAmountGood = Int32.Parse(tbS8A3.Text);
            }
            if (tbS8A4.Text != "")
            {
                gc.ScrapAmountNG = Int32.Parse(tbS8A4.Text);
            }
            gc.Cause = txtCause.Text;
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
            if (tbS10r2c5.Text != "")
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
            gc.FinalYield = tbS10A1.Text;
            gc.ControlLCL = tbS10A2.Text;
            gc.AsiGood = tbS11A1.Text;
            gc.AsiNG = tbS11A2.Text;
            gc.AddOn = txtAddOn.Text;
            gc.AndonManage = tbS11A3.Text;
            gc.AndonWho = tbS11A4.Text;
            gc.AndonManageDetail = tbS11A5.Text;
            if (tbS13A1.Text != "")
            {
                gc.TesttotalAmount = Int32.Parse(tbS13A1.Text);
            }
            if (tbS13A2.Text != "")
            {
                gc.TestResultGood = Int32.Parse(tbS13A2.Text);
            }
            if (tbS13A3.Text != "")
            {
                gc.TestResultNG = Int32.Parse(tbS13A3.Text);
            }
            gc.RequestAQIS13 = txtRequestAQIS13.Text;
            gc.StopNextLotS13 = txtStopNextLotS13.Text;
            gc.KanbanCtrlNo = tbS13A4.Text;
            gc.KanbanTestNo = tbS13A5.Text;
            gc.KanbanExpireDate = dateS13.Value;
            gc.ResultBurnGood = tbS14A1.Text;
            gc.ResultBurnNG = tbS14A2.Text;
            gc.ResultChipCrackGood = tbS14A3.Text;
            gc.ResultChipCrackNG = tbS14A4.Text;
            if (tbS14A5.Text != "")
            {
                gc.ResultChipMixGood = Int32.Parse(tbS14A5.Text);
            }
            if (tbS14A6.Text != "")
            {
                gc.ResultChipMixNG = Int32.Parse(tbS14A6.Text);
            }
            gc.RequestAQIS14 = txtRequestAQIS14.Text;
            gc.StopNextLotS14 = txtStopNextLotS14.Text;
            gc.StopPKGS14 = txtStopPKGS14.Text;
            gc.SystemInspection = txtSystemInspection.Text;
            gc.JudgementResult = txtJudgementResult.Text;
            gc.LowYieldAnalysis = txtLowYieldAnalysis.Text;
            gc.OPName1_ID = lblStampOP1A2.Text;
            gc.TestIncharge_ID = lblStampBMA2.Text;
            gc.OPName2_ID = lblStampOP2A2.Text;
            gc.GL_ID = lblStampGLA2.Text;
            gc.AnalysisIncharge_ID = lblStampQYI1A2.Text;
            gc.FYIFQIIncharge_ID = lblStampQYI3A2.Text;
            gc.PDMgr_ID = lblStampPDMGRA2.Text;
            gc.OPName1_Sign = lblStampOP1A1.Text;
            gc.TestIncharge_Sign = lblStampBMA1.Text;
            gc.OPName2_Sign = lblStampOP2A1.Text;
            gc.GL_Sign = lblStampGLA1.Text;
            gc.AnalysisIncharge_Sign = lblStampQYI1A1.Text;
            gc.FYIFQIIncharge_Sign = lblStampQYI3A1.Text;
            gc.PDMgr_Sign = lblStampPDMGRA1.Text;
            gc.OPName1_SignDate = lblStampOP1A3.Text;
            gc.TestIncharge_SignDate = lblStampBMA3.Text;
            gc.OPName2_SignDate = lblStampOP2A3.Text;
            gc.GL_SignDate = lblStampGLA3.Text;
            gc.AnalysisIncharge_SignDate = lblStampQYI1A3.Text;
            gc.FYIFQIIncharge_SignDate = lblStampQYI3A3.Text;
            gc.PDMgr_SignDate = lblStampPDMGRA3.Text;
            //End Get data


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
                //this is normal case
                gc.Status = "6";
            }

            //############## SET STEP 16 ##########################
            if (SelectS16A1.SelectedIndex == 0)
            {
                gc.SelectS16 = "";
            }
            else if (SelectS16A1.SelectedIndex == 1)
            {
                gc.SelectS16 = "OK";
            }
            else if (SelectS16A1.SelectedIndex == 2)
            {
                gc.SelectS16 = "NG";
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



            //######### set User Stamp ###########
            gc.TEIncharge_ID = gc.User;

            //user sign
            var tbl = new DataTable();

            tbl = dba.Login(gc.User);//Get data from Apcs Database

            if (tbl.Rows.Count == 1)
            {
                foreach (DataRow row in tbl.Rows)
                {
                    gc.TEIncharge_Sign = row["name"].ToString(); //get name of user
                }
            }
            else
            {
                gc.TEIncharge_Sign = gc.User;
            }

            gc.TEIncharge_SignDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // case sensitive




        }

        public void ConfirmBtnOnClick(object sender, EventArgs e)
        {
            gc.Edit = Request.Params["Edit"]; //get parameter from url

            //ถ้าแผนก QYI2 (FYI) ไม่ทำการเลือกข้อมูลในข้อ 16 และ ข้อ 18 จะทำการเป็นแค่Status เท่านั้น จะไม่ทำการUpdate ค่า TE Incharge ลงไปใน Database
            if (SelectS16A1.SelectedIndex == 0 || tbS18A1.Text == "" || tbS18A2.Text == "" || SelectS18A1.SelectedIndex == 0 || SelectS18A2.SelectedIndex == 0)
            {
                SetValue();
                dba.UpdatePageUser10(gc.Process, gc.HandlerNo, gc.LotNo, gc.Status);
            }
            else
            {
                SetValue();
                dba.UpdatePageUser9(gc.Process, gc.HandlerNo, gc.LotNo, gc.Status, gc.SelectS16, gc.FTRetestGood,
                    gc.FTRetestNG, gc.ObjectScope, gc.StopRecallShipment, gc.TEIncharge_ID, gc.TEIncharge_Sign, gc.TEIncharge_SignDate);
            }


            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Save Done')", true);

            string strUrl;
            strUrl = "~/PageMonitoring_QYI.aspx?userId=" + Request.Params["User"];
            Response.Redirect(strUrl);
        }

        protected void BtnClose_ServerClick(object sender, EventArgs e)
        {
            string strUrl;
            strUrl = "~/PageMonitoring_QYI.aspx?userId=" + Request.Params["User"];
            Response.Redirect(strUrl);
        }


    }
}