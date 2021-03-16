using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LowYieldCheckSheet
{
    public partial class InputPageUser2_Test : System.Web.UI.Page
    {
        DBAccess dba = new DBAccess();
        GlobalClass gc = new GlobalClass();

        string[] splitStr;
        string tempStr;
        string checkalarmbin;
        string tempStr2;
        string bmid;

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
                                    checkalarmbin = "BIN19";
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
                                checkalarmbin = "BIN19";
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


                    //###################### Time Stamp ######################
                    lblStampOP1A1.Text = row["OPName1_Sign"].ToString();
                    lblStampOP1A2.Text = row["OPName1_ID"].ToString();
                    lblStampOP1A3.Text = row["OPName1_SignDate"].ToString();



                }


                foreach (DataRow row in tbl.Rows)
                {
                    txtStoreValue.Text = row["Status"].ToString();  //store Current Status

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

                    //BMID  bmid
                    if (row["BMID"].ToString() != "")
                    {
                        bmid = row["BMID"].ToString();
                    }

                    var tblbm = new DataTable();
                    tblbm = dba.CheckDataBM(bmid);
                    if (tblbm.Rows.Count == 1)
                    {
                        foreach (DataRow rowbm in tblbm.Rows)
                        {
                            if (rowbm["NGDescription"].ToString() != "")
                            {
                                tbS8r1c1.Text = rowbm["NGDescription"].ToString();
                            }

                            if (rowbm["ChkLimitLo"].ToString() != "")
                            {
                                tbS8r2c1.Text = rowbm["ChkLimitLo"].ToString();
                            }

                            if (rowbm["ChkLimitHi"].ToString() != "")
                            {
                                tbS8r3c1.Text = rowbm["ChkLimitHi"].ToString();
                            }

                            if (rowbm["ConchkPro"].ToString() != "")
                            {
                                tbS8r8.Text = rowbm["ConchkPro"].ToString();
                            }

                            if (rowbm["ChkLimitHiData"].ToString() != "")
                            {
                                tbS8r4c1.Text = rowbm["ChkLimitHiData"].ToString();
                            }

                            if (rowbm["ChkLimitLoData"].ToString() != "")
                            {
                                tbS8r5c1.Text = rowbm["ChkLimitLoData"].ToString();
                            }

                            if (rowbm["ChkTesterChChangeData"].ToString() != "")
                            {
                                tbS8r6c1.Text = rowbm["ChkTesterChChangeData"].ToString();
                            }
                            //################################ STEP 9 ######################
                            if (!(string.IsNullOrEmpty(rowbm["BMUnitID"].ToString())))
                            {
                                if (rowbm["BMUnitID"].ToString() == "1")
                                {
                                    SelectS9.SelectedIndex = 1;
                                }
                                else if (rowbm["BMUnitID"].ToString() == "2")
                                {
                                    SelectS9.SelectedIndex = 2;
                                }
                                else if (rowbm["BMUnitID"].ToString() == "3")
                                {
                                    SelectS9.SelectedIndex = 3;
                                }
                                else 
                                {
                                    SelectS9.SelectedIndex = 7;
                                }
                            }
                        }
                    }
                    else
                    {
                         tbS8r1c1.Text = row["TNo1"].ToString();
                        tbS8r2c1.Text = row["LimitLow1"].ToString();
                        tbS8r3c1.Text = row["LimitHigh1"].ToString();
                        tbS8r8.Text = row["ProgramName"].ToString();
                        tbS8r4c1.Text = row["MassProductNG1"].ToString();
                        tbS8r5c1.Text = row["GoodSample1"].ToString();
                        tbS8r6c1.Text = row["TesterETC1"].ToString();
                    }
                    

               
                    tbS8r1c2.Text = row["TNo2"].ToString();
                    tbS8r1c3.Text = row["TNo3"].ToString();
                    tbS8r1c4.Text = row["TNo4"].ToString();
                    tbS8r1c5.Text = row["TNo5"].ToString();

                    //tbS8r2c1.Text = row["LimitLow1"].ToString();
                    tbS8r2c2.Text = row["LimitLow2"].ToString();
                    tbS8r2c3.Text = row["LimitLow3"].ToString();
                    tbS8r2c4.Text = row["LimitLow4"].ToString();
                    tbS8r2c5.Text = row["LimitLow5"].ToString();

                    //tbS8r3c1.Text = row["LimitHigh1"].ToString();
                    tbS8r3c2.Text = row["LimitHigh2"].ToString();
                    tbS8r3c3.Text = row["LimitHigh3"].ToString();
                    tbS8r3c4.Text = row["LimitHigh4"].ToString();
                    tbS8r3c5.Text = row["LimitHigh5"].ToString();

                    //tbS8r4c1.Text = row["MassProductNG1"].ToString();
                    tbS8r4c2.Text = row["MassProductNG2"].ToString();
                    tbS8r4c3.Text = row["MassProductNG3"].ToString();
                    tbS8r4c4.Text = row["MassProductNG4"].ToString();
                    tbS8r4c5.Text = row["MassProductNG5"].ToString();

                    //tbS8r5c1.Text = row["GoodSample1"].ToString();
                    tbS8r5c2.Text = row["GoodSample2"].ToString();
                    tbS8r5c3.Text = row["GoodSample3"].ToString();
                    tbS8r5c4.Text = row["GoodSample4"].ToString();
                    tbS8r5c5.Text = row["GoodSample5"].ToString();

                    //tbS8r6c1.Text = row["TesterETC1"].ToString();
                    tbS8r6c2.Text = row["TesterETC2"].ToString();
                    tbS8r6c3.Text = row["TesterETC3"].ToString();
                    tbS8r6c4.Text = row["TesterETC4"].ToString();
                    tbS8r6c5.Text = row["TesterETC5"].ToString();

                    tbS8r7c1.Text = row["CheckRepeat1"].ToString();
                    tbS8r7c2.Text = row["CheckRepeat2"].ToString();
                    tbS8r7c3.Text = row["CheckRepeat3"].ToString();
                    tbS8r7c4.Text = row["CheckRepeat4"].ToString();
                    tbS8r7c5.Text = row["CheckRepeat5"].ToString();

                    //tbS8r8.Text = row["ProgramName"].ToString();

                    tbS8A1.Text = row["UseMassProductGood"].ToString();
                    tbS8A2.Text = row["UseMassProductNG"].ToString();

                    tbS8A3.Text = row["ScrapAmountGood"].ToString();
                    tbS8A4.Text = row["ScrapAmountNG"].ToString();

                   
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

            //############ set User Stamp
            //user id
            gc.TestIncharge_ID = gc.User;

            //user sign
            var tbl = new DataTable();

            tbl = dba.Login(gc.User);//Get data from Apcs Database

            if (tbl.Rows.Count == 1)
            {
                foreach (DataRow row in tbl.Rows)
                {
                    gc.TestIncharge_Sign = row["name"].ToString(); //get name of user
                }
            }
            else
            {
                gc.TestIncharge_Sign = gc.User;
            }

            //user sign date
            gc.TestIncharge_SignDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // case sensitive



            //############################ SET STEP 8 ###############################
            //Tester Checker
            if (SelectS8A1.SelectedIndex == 0)
            {
                gc.TesterChecker = "";
            }
            else if (SelectS8A1.SelectedIndex == 1)
            {
                gc.TesterChecker = "OK";
            }
            else if (SelectS8A1.SelectedIndex == 2)
            {
                gc.TesterChecker = "NG";
            }
            else if (SelectS8A1.SelectedIndex == 3)
            {
                gc.TesterChecker = "NO";
            }

            //Set Up
            if (SelectS8A2.SelectedIndex == 0)
            {
                gc.Setup = "";
            }
            else if (SelectS8A2.SelectedIndex == 1)
            {
                gc.Setup = "OK";
            }
            else if (SelectS8A2.SelectedIndex == 2)
            {
                gc.Setup = "NG";
            }
            else if (SelectS8A2.SelectedIndex == 3)
            {
                gc.Setup = "NO";
            }

            //LowYiledMode 
            if (SelectS8A3.SelectedIndex == 0)
            {
                gc.LowYieldMode = "";
            }
            else if (SelectS8A3.SelectedIndex == 1)
            {
                gc.LowYieldMode = "New Mode";
            }
            else if (SelectS8A3.SelectedIndex == 2)
            {
                gc.LowYieldMode = "Kanban หมดอายุ";
            }


            //T No.
            gc.TNo1 = tbS8r1c1.Text;
            gc.TNo2 = tbS8r1c2.Text;
            gc.TNo3 = tbS8r1c3.Text;
            gc.TNo4 = tbS8r1c4.Text;
            gc.TNo5 = tbS8r1c5.Text;

            //Limit Low
            gc.LimitLow1 = tbS8r2c1.Text;
            gc.LimitLow2 = tbS8r2c2.Text;
            gc.LimitLow3 = tbS8r2c3.Text;
            gc.LimitLow4 = tbS8r2c4.Text;
            gc.LimitLow5 = tbS8r2c5.Text;

            //Limit High
            gc.LimitHigh1 = tbS8r3c1.Text;
            gc.LimitHigh2 = tbS8r3c2.Text;
            gc.LimitHigh3 = tbS8r3c3.Text;
            gc.LimitHigh4 = tbS8r3c4.Text;
            gc.LimitHigh5 = tbS8r3c5.Text;

            //Mass-Product NG
            gc.MassProductNG1 = tbS8r4c1.Text;
            gc.MassProductNG2 = tbS8r4c2.Text;
            gc.MassProductNG3 = tbS8r4c3.Text;
            gc.MassProductNG4 = tbS8r4c4.Text;
            gc.MassProductNG5 = tbS8r4c5.Text;

            //Good Sample
            gc.GoodSample1 = tbS8r5c1.Text;
            gc.GoodSample2 = tbS8r5c2.Text;
            gc.GoodSample3 = tbS8r5c3.Text;
            gc.GoodSample4 = tbS8r5c4.Text;
            gc.GoodSample5 = tbS8r5c5.Text;

            //ยืนยัน Tester อื่นๆ
            gc.TesterETC1 = tbS8r6c1.Text;
            gc.TesterETC2 = tbS8r6c2.Text;
            gc.TesterETC3 = tbS8r6c3.Text;
            gc.TesterETC4 = tbS8r6c4.Text;
            gc.TesterETC5 = tbS8r6c5.Text;

            //Repeat Check
            gc.CheckRepeat1 = tbS8r7c1.Text;
            gc.CheckRepeat2 = tbS8r7c2.Text;
            gc.CheckRepeat3 = tbS8r7c3.Text;
            gc.CheckRepeat4 = tbS8r7c4.Text;
            gc.CheckRepeat5 = tbS8r7c5.Text;

            gc.ProgramName = tbS8r8.Text;

            //UseMassProduct
            if (tbS8A1.Text != "")
            {
                gc.UseMassProductGood = Int32.Parse(tbS8A1.Text);
            }

            if (tbS8A2.Text != "")
            {
                gc.UseMassProductNG = Int32.Parse(tbS8A2.Text);
            }

            //ScrapAmount
            if (tbS8A3.Text != "")
            {
                gc.ScrapAmountGood = Int32.Parse(tbS8A3.Text);
            }

            if (tbS8A4.Text != "")
            {
                gc.ScrapAmountNG = Int32.Parse(tbS8A4.Text);
            }


            //############################### SET STEP 9 #############################
            if (checkalarmbin == "BIN19")
            {
                gc.Cause = "ICBURN";  
            }
            else
            { 
                if (SelectS9.SelectedIndex == 0)
                {
                    gc.Cause = "";
                }
                else if (SelectS9.SelectedIndex == 1)
                {
                    gc.Cause = "TESTER";
                }
                else if (SelectS9.SelectedIndex == 2)
                {
                    gc.Cause = "BOX";
                }
                else if (SelectS9.SelectedIndex == 3)
                {
                    gc.Cause = "OPTION";
                }
                else if (SelectS9.SelectedIndex == 4)
                {
                    gc.Cause = "OPMISS";
                }
                else if (SelectS9.SelectedIndex == 5)
                {
                    gc.Cause = "TAKEBACK";
                }
                else if (SelectS9.SelectedIndex == 6)
                {
                    gc.Cause = "ICBURN";
                }
                else if (SelectS9.SelectedIndex == 7)
                {
                    gc.Cause = "ETC";
                }
            }

            //########### set to next status ##########
            if (gc.Edit == "TRUE")
            {
                //this is edit case
                //set status from store current status
                gc.Status = txtStoreValue.Text;
            }
            else if (gc.Edit == "FALSE")
            {
                if (bmid != "")
                {
                    gc.Status = "3";
                }
                else
                {
                    if (gc.Cause == "TAKEBACK" || gc.Cause == "ICBURN")
                    {
                        gc.Status = "4";
                        //comment 25-02-2021 --> gc.Status = "5B";
                    }
                    else
                    {
                        //Status 
                        gc.Status = "7";
                    }
                }

               
            }

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

                dba.UpdatePageUser2(gc.Process, gc.HandlerNo, gc.LotNo, gc.Status, gc.TesterChecker,
                    gc.Setup,gc.LowYieldMode, gc.TNo1, gc.TNo2, gc.TNo3, gc.TNo4, gc.TNo5,
                    gc.LimitLow1, gc.LimitLow2, gc.LimitLow3, gc.LimitLow4, gc.LimitLow5,
                    gc.LimitHigh1, gc.LimitHigh2, gc.LimitHigh3, gc.LimitHigh4, gc.LimitHigh5,
                    gc.MassProductNG1, gc.MassProductNG2, gc.MassProductNG3, gc.MassProductNG4, gc.MassProductNG5,
                    gc.GoodSample1, gc.GoodSample2, gc.GoodSample3, gc.GoodSample4, gc.GoodSample5,
                    gc.TesterETC1, gc.TesterETC2, gc.TesterETC3, gc.TesterETC4, gc.TesterETC5,
                    gc.CheckRepeat1, gc.CheckRepeat2, gc.CheckRepeat3, gc.CheckRepeat4, gc.CheckRepeat5,
                    gc.ProgramName, gc.UseMassProductGood, gc.UseMassProductNG, gc.ScrapAmountGood, gc.ScrapAmountNG,
                    gc.Cause, gc.TestIncharge_ID, gc.TestIncharge_Sign, gc.TestIncharge_SignDate);

                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Save Done')", true);

                string strUrl;
                strUrl = "~/PageMonitoring_BM.aspx?userId=" + Request.Params["User"];
                Response.Redirect(strUrl);
            }
        }


        protected void BtnClose_ServerClick(object sender, EventArgs e)
        {
            string strUrl;
            strUrl = "~/PageMonitoring_BM.aspx?userId=" + Request.Params["User"];
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


        public Boolean CheckEmptyInput()
        {
            Boolean result = false;
            int countEmpty = 0;

            //############################### Step 8 ##############################
            //T.No
            if (String.IsNullOrEmpty(tbS8r1c1.Text))
            {
                tbS8r1c1.BackColor = System.Drawing.Color.Red;
                countEmpty += 1;
            }
            else
            {
                tbS8r1c1.BackColor = System.Drawing.Color.White;
            }


            //Limit-Low
            if (String.IsNullOrEmpty(tbS8r2c1.Text))
            {
                tbS8r2c1.BackColor = System.Drawing.Color.Red;
                countEmpty += 1;
            }
            else
            {
                tbS8r2c1.BackColor = System.Drawing.Color.White;
            }


            //Limit-High
            if (String.IsNullOrEmpty(tbS8r3c1.Text))
            {
                tbS8r3c1.BackColor = System.Drawing.Color.Red;
                countEmpty += 1;
            }
            else
            {
                tbS8r3c1.BackColor = System.Drawing.Color.White;
            }

           

            //Mass Product NG
            if (String.IsNullOrEmpty(tbS8r4c1.Text))
            {
                tbS8r4c1.BackColor = System.Drawing.Color.Red;
                countEmpty += 1;
            }
            else
            {
                tbS8r4c1.BackColor = System.Drawing.Color.White;
            }

            
            //Good Sample
            if (String.IsNullOrEmpty(tbS8r5c1.Text))
            {
                tbS8r5c1.BackColor = System.Drawing.Color.Red;
                countEmpty += 1;
            }
            else
            {
                tbS8r5c1.BackColor = System.Drawing.Color.White;
            }

            //ยืนยัน Tester อื่นๆ
            if (String.IsNullOrEmpty(tbS8r6c1.Text))
            {
                tbS8r6c1.BackColor = System.Drawing.Color.Red;
                countEmpty += 1;
            }
            else
            {
                tbS8r6c1.BackColor = System.Drawing.Color.White;
            }

            //เช็คซ้ำ
            if (String.IsNullOrEmpty(tbS8r7c1.Text))
            {
                tbS8r7c1.BackColor = System.Drawing.Color.Red;
                countEmpty += 1;
            }
            else
            {
                tbS8r7c1.BackColor = System.Drawing.Color.White;
            }


            //ชื่อ Program
            if (String.IsNullOrEmpty(tbS8r8.Text))
            {
                tbS8r8.BackColor = System.Drawing.Color.Red;
                countEmpty += 1;
            }
            else
            {
                tbS8r8.BackColor = System.Drawing.Color.White;
            }

            //#################### Check count empty ###############
            if (countEmpty > 0)
            {
                result = true;
            }

            return result;

        }




    }
}