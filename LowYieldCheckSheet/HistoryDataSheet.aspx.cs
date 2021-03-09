using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LowYieldCheckSheet
{
    public partial class HistoryDataSheet : System.Web.UI.Page
    {
        DBAccess dba = new DBAccess();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }


        public void LoadData()
        {
            string Process = Request.Params["Process"]; //get parameter from url;
            string MCNo = Request.Params["MCNo"]; //get parameter from url;
            string LotNo = Request.Params["LotNo"]; //get parameter from url;

            var tbl = new DataTable();

            tbl = dba.PullHistory(Process, MCNo, LotNo);

            if (tbl.Rows.Count == 1)
            {
                foreach (DataRow row in tbl.Rows)
                {
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
                        }
                        else if (row["ManaulCheck1"].ToString() == "REQUESTPM")
                        {
                            cbStep5_1.Checked = true;
                            rbStep5A2.Checked = true;
                        }
                        else
                        {
                            cbStep5_1.Checked = true;
                            rbStep5A3.Checked = true;
                            tbS5.Text = row["ManaulCheck1"].ToString();
                        }
                    }


                    if (!(string.IsNullOrEmpty(row["ManaulCheck2"].ToString())))
                    {
                        cbStep5_2.Checked = true;
                    }

                    if (!(string.IsNullOrEmpty(row["ManaulCheck3"].ToString())))
                    {
                        cbStep5_3.Checked = true;
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


                    //####################### STEP 19 ##############################
                    if (!(string.IsNullOrEmpty(row["LowYieldAnalysis"].ToString())))
                    {
                        if (row["LowYieldAnalysis"].ToString() == "YES")
                        {
                            SelectS19.SelectedIndex = 1;
                        }
                        else if (row["LowYieldAnalysis"].ToString() == "NO")
                        {
                            SelectS19.SelectedIndex = 2;
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

                    //###################### STEP 21 #######################
                    tbS21.Text = row["QCJudgement"].ToString();



                    //###################### Time Stamp ######################
                    lblStampH1.Text = row["FYIFQIIncharge_Sign"].ToString();
                    lblStampH2.Text = row["FYIFQIIncharge_SignDate"].ToString();

                    lblStampH3.Text = row["PDMgr_Sign"].ToString();
                    lblStampH4.Text = row["PDMgr_SignDate"].ToString();

                    lblStampH5.Text = row["QCIncharge_Sign"].ToString();
                    lblStampH6.Text = row["QCIncharge_SignDate"].ToString();

                    lblStamp1.Text = row["OPName1_Sign"].ToString();
                    lblStamp2.Text = row["OPName1_SignDate"].ToString();

                    lblStamp3.Text = row["TestIncharge_Sign"].ToString();
                    lblStamp4.Text = row["TestIncharge_SignDate"].ToString();

                    lblStamp5.Text = row["OPName2_Sign"].ToString();
                    lblStamp6.Text = row["OPName2_SignDate"].ToString();

                    lblStamp7.Text = row["GL_Sign"].ToString();
                    lblStamp8.Text = row["GL_SignDate"].ToString();

                    lblStamp9.Text = row["AnalysisIncharge_Sign"].ToString();
                    lblStamp10.Text = row["AnalysisIncharge_SignDate"].ToString();

                    lblStamp13.Text = row["FYIFQIIncharge_Sign"].ToString();
                    lblStamp14.Text = row["FYIFQIIncharge_SignDate"].ToString();

                    lblStamp15.Text = row["QCIncharge_Sign"].ToString();
                    lblStamp16.Text = row["QCIncharge_SignDate"].ToString();

            }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No Data In Table')", true);
            }
        }
    }
}