using System;
using System.Data;
using System.Web.UI;

namespace LowYieldCheckSheet
{
    public partial class InputPageUser1_Test : System.Web.UI.Page
    {
        DBAccess dba = new DBAccess();
        GlobalClass gc = new GlobalClass();

        string[] splitStr;
        string tempStr;
        string tempStr2;
        string checkalrmbin;
        string checkalrm;
        string FlowName;
        string Statuspart;
        string LotNo;
        string MCNo;
        string strUrl;
        string Floor;
        string IssueNoVa;
        string IssueNoVa1;
        string ISNO;
        string YY1;
        string MM1;
        int MyNumber1;
        string MyNumber;

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
            gc.MNo = Request.Params["MNo"]; //get parameter from url
            gc.TesterNo = Request.Params["TesterNo"]; //get parameter from url
            gc.Flow = Request.Params["Flow"]; //get parameter from url
            gc.PackageName = Request.Params["Package"]; //get parameter from url
            gc.ControlYield = Request.Params["Control"]; //get parameter from url
            gc.TRank = Request.Params["TRank"]; //get parameter from url
            gc.WaferLotNo = Request.Params["WaferLotNo"]; //get parameter from url
            gc.TPRank = Request.Params["TPRank"]; //get parameter from url

            //################### Request.Params["Control"]; //get parameter from url####### HEAD ##############################
            tbHead1.Text = Request.Params["AmountNG"];
            tbHead2.Text = Request.Params["MCNo"];
            tbHead3.Text = Request.Params["LotNo"]; 
            tbHead4.Text = Request.Params["Package"]; 
            tbHead5.Text = Request.Params["Device"];
            tbHead9.Text = Request.Params["TRank"];
            tbHead10.Text = Request.Params["WaferLotNo"];
            tbHead12.Text = Request.Params["TPRank"];

            tbS1A1.Text = Request.Params["Input"]; //get parameter from url
            tbS1A2.Text = Request.Params["Control"]; //get parameter from url

            FlowName = Request.Params["Flow"];
            if (string.IsNullOrEmpty(FlowName))
            {
                headSelect1.SelectedIndex = 0;
            }
            else
            {
                if (FlowName == "Auto1") { headSelect1.SelectedIndex = 1; }
                else if (FlowName == "Auto2") { headSelect1.SelectedIndex = 2; }
                else if (FlowName == "Auto3") { headSelect1.SelectedIndex = 3; }
                else if (FlowName == "Auto4") { headSelect1.SelectedIndex = 4; }
            }
            tbHead6.Text = Request.Params["MNo"]; 
            tbHead7.Text = Request.Params["TesterNo"];

           
              
                //Add 2020-08-24
            var tblpro = new DataTable();
            tblpro = dba.PullLotNo(gc.LotNo);
            if (tblpro.Rows.Count == 1)
            {
                foreach (DataRow row in tblpro.Rows)
                {
                    if (row["FORWADING_BUNRUI"].ToString() == "OVER SEAS")
                    {
                        headSelect2.SelectedIndex = 2;
                    }
                    else if (row["FORWADING_BUNRUI"].ToString() == "JAPAN")
                    {
                        headSelect2.SelectedIndex = 1;
                    }

                    //Add 2020-09-22
                    // TP_RANK
                   gc.TPRank = row["TP_RANK_1"].ToString();
                   tbHead12.Text = row["TP_RANK_1"].ToString();
                    // TRank
                    if (row["THROW_RANK_1"].ToString() != "")
                    {
                        gc.TRank = row["THROW_RANK_1"].ToString();
                        tbHead9.Text = row["THROW_RANK_1"].ToString();
                    }
                    else if (row["THROW_RANK_2"].ToString() != "")
                    {
                        gc.TRank = row["THROW_RANK_2"].ToString();
                        tbHead9.Text = row["THROW_RANK_2"].ToString();
                    }
                    else if (row["THROW_RANK_3"].ToString() != "")
                    {
                        gc.TRank = row["THROW_RANK_3"].ToString();
                        tbHead9.Text = row["THROW_RANK_3"].ToString();
                    }
                    else if (row["THROW_RANK_5"].ToString() != "")
                    {
                        gc.TRank = row["THROW_RANK_5"].ToString();
                        tbHead9.Text = row["THROW_RANK_5"].ToString();
                    }
                    //WaferLotNo

                }
            }

            var tblpro1 = new DataTable();
            tblpro1 = dba.PullLotNoWafer(gc.LotNo);
            if (tblpro1.Rows.Count == 1)
            {
                foreach (DataRow row in tblpro1.Rows)
                {
                    if (row["WF_NO_START_1"].ToString() == row["WF_NO_END_1"].ToString())
                    {
                        tbHead11.Text = row["WF_NO_START_1"].ToString();
                    }
                    else 
                    {
                        tbHead11.Text = row["WF_NO_START_1"].ToString() + "-" + row["WF_NO_END_1"].ToString();
                    }

                    
                    tbHead10.Text = row["RUN_NO"].ToString();
                    gc.WaferLotNo = row["RUN_NO"].ToString();
                }
            }


            var tbl = new DataTable();

            //Get data from dabatabase by MCNo and LotNo
            tbl = dba.PullByMCNoAndLotNo(gc.Process, gc.HandlerNo, gc.LotNo);


            if (tbl.Rows.Count == 0)
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
                                    checkalrmbin = row["CheckAlarmBin"].ToString();
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
                                    checkalrmbin = row["CheckAlarmBin"].ToString();
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

                    ////Final
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
                                    checkalrmbin = row["CheckAlarmBin"].ToString();
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
                                    checkalrmbin = row["CheckAlarmBin"].ToString();
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
                    //tbHead1.Text = Request.Params["AmountNG"];
                    //tbHead2.Text = row["HandlerNo"].ToString();
                    //tbHead3.Text = row["LotNo"].ToString();
                    //tbHead4.Text = row["PackageName"].ToString();
                    //tbHead5.Text = row["DeviceName"].ToString();

                    //if (string.IsNullOrEmpty(row["Flow"].ToString()))
                    //{
                    //    headSelect1.SelectedIndex = 0;
                    //}
                    //else
                    //{
                    //    if (row["Flow"].ToString() == "AUTO1") { headSelect1.SelectedIndex = 1; }
                    //    else if (row["Flow"].ToString() == "AUTO2") { headSelect1.SelectedIndex = 2; }
                    //    else if (row["Flow"].ToString() == "AUTO3") { headSelect1.SelectedIndex = 3; }
                    //    else if (row["Flow"].ToString() == "AUTO4") { headSelect1.SelectedIndex = 4; }
                    //}

                    tbHead6.Text = row["MNo"].ToString();
                    tbHead7.Text = row["TesterNo"].ToString();
                    tbHead8.Text = row["BoxNo"].ToString();
                    //tbHead9.Text = row["TRank"].ToString();
                    //tbHead10.Text = row["WaferLotNo"].ToString();
                    //tbHead11.Text = row["WaferSheetNo"].ToString();
                    //tbHead12.Text = row["TPRank"].ToString();

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
                    //tbS1A1.Text = row["InputQuantity"].ToString();
                    //tbS1A2.Text = row["ControlYield"].ToString();
                    tbS1A1.Text = Request.Params["Input"]; //get parameter from url
                    tbS1A2.Text = Request.Params["Control"]; //get parameter from url

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
                        else if (row["ManaulCheck1_2"].ToString() == "REQUESTPM")
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
                        if (row["Result2"].ToString() == "Good to NG")
                        {
                            cbStep5_2.Checked = true;
                            cbStep5_2chkok.Checked = true;
                        }
                        else if (row["Result2"].ToString() == "Good to Good")
                        {
                            cbStep5_2.Checked = true;
                            cbStep5_2chkng.Checked = true;
                        }
                    }

                    if (!(string.IsNullOrEmpty(row["ManaulCheck3"].ToString())))
                    {
                        if (row["Result3"].ToString() == "NG to NG AND Good to Good")
                        {
                            cbStep5_3.Checked = true;
                            cbStep5_3chkok.Checked = true;
                        }
                        else if (row["Result3"].ToString() == "NG to Good AND Good to Good")
                        {
                            cbStep5_3.Checked = true;
                            cbStep5_3chkng.Checked = true;
                        }
                       
                    }

                    //Add 2020-10-20
                    if (string.IsNullOrEmpty(row["CheckSocket"].ToString()))
                    {
                        SelectS5A1.SelectedIndex = 0;
                    }
                    else
                    {
                        if (row["CheckSocket"].ToString() == "A")
                        {
                            SelectS5A1.SelectedIndex = 1;
                        }
                        else if (row["CheckSocket"].ToString() == "B")
                        {
                            SelectS5A1.SelectedIndex = 2;
                        }
                        else if (row["CheckSocket"].ToString() == "C")
                        {
                            SelectS5A1.SelectedIndex = 3;
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


                    //if (!(string.IsNullOrEmpty(row["SocketChangeLastDate"].ToString())))
                    //{
                        //DateS6.Value = row["SocketChangeLastDate"].ToString();
                    //}

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
                                else 
                                {
                                    CheckS7A5.Checked = true;
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


                }
            }
            else
            {
                //message box
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Lot นี้ได้ Request Low Yield แล้วไม่สามารถ Requestซ้ำได้')", true);
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

        protected void cbStep5_2_CheckedChanged(object sender, EventArgs e)
        {
            if (cbStep5_2.Checked == true)
            {
                cbStep5_2chkok.Enabled = true;
                cbStep5_2chkng.Enabled = true;
            }
            else
            {
                cbStep5_2chkok.Enabled = false;
                cbStep5_2chkng.Enabled = false;
                cbStep5_2chkok.Checked = false;
                cbStep5_2chkng.Checked = false;
            }
        }

        protected void cbStep5_3_CheckedChanged(object sender, EventArgs e)
        {
            if (cbStep5_3.Checked == true)
            {
                cbStep5_3chkok.Enabled = true;
                cbStep5_3chkng.Enabled = true;
            }
            else
            {
                cbStep5_3chkok.Enabled = false;
                cbStep5_3chkng.Enabled = false;
                cbStep5_3chkok.Checked = false;
                cbStep5_3chkng.Checked = false;
            }
        }

        protected void rbStep5A1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbStep5A1.Checked == true)
            {
                Step5A1chkok.Enabled = true;
                Step5A1chkng.Enabled = true;
            }
            else
            {
                Step5A1chkok.Enabled = false;
                Step5A1chkng.Enabled = false;
                Step5A1chkok.Checked = false;
                Step5A1chkng.Checked = false;
            }
        }

        protected void rbStep5A2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbStep5A2.Checked == true)
            {
                Step5A2chkok.Enabled = true;
                Step5A2chkng.Enabled = true;
            }
            else
            {
                Step5A2chkok.Enabled = false;
                Step5A2chkng.Enabled = false;
                Step5A2chkok.Checked = false;
                Step5A2chkng.Checked = false;
            }
        }

        protected void rbStep5A3_CheckedChanged(object sender, EventArgs e)
        {
            if (rbStep5A3.Checked == true)
            {
                Step5A3chkok.Enabled = true;
                Step5A3chkng.Enabled = true;
            }
            else
            {
                Step5A3chkok.Enabled = false;
                Step5A3chkng.Enabled = false;
                Step5A3chkok.Checked = false;
                Step5A3chkng.Checked = false;
            }
        }

        protected void Step5A1chkng_CheckedChanged(object sender, EventArgs e)
        {
            if (Step5A1chkng.Checked == true)
            {
                Step5A2chkok.Enabled = true;
                Step5A2chkng.Enabled = true;
                rbStep5A2.Checked = true;
            }
            else if (Step5A1chkok.Checked == true)
            {
                Step5A2chkok.Enabled = false;
                Step5A2chkng.Enabled = false;
                rbStep5A2.Checked = false;
                Step5A2chkok.Checked = false;
                Step5A2chkng.Checked = false;
            }
            else
            {
                Step5A1chkok.Enabled = false;
                Step5A1chkng.Enabled = false;
                Step5A2chkok.Enabled = false;
                Step5A2chkng.Enabled = false;
                Step5A1chkok.Checked = false;
                Step5A1chkng.Checked = false;
                Step5A2chkok.Checked = false;
                Step5A2chkng.Checked = false;
            }

        }

        protected void Step5A2chkng_CheckedChanged(object sender, EventArgs e)
        {
            if (Step5A2chkng.Checked == true)
            {
                Step5A3chkok.Enabled = true;
                Step5A3chkng.Enabled = true;
                rbStep5A3.Checked = true;
            }
            else if (Step5A2chkok.Checked == true)
            {
                Step5A3chkok.Enabled = false;
                Step5A3chkng.Enabled = false;
                rbStep5A3.Checked = false;
                Step5A3chkok.Checked = false;
                Step5A3chkng.Checked = false;
            }
            else
            {
                Step5A2chkok.Enabled = false;
                Step5A2chkng.Enabled = false;
                Step5A3chkok.Enabled = false;
                Step5A3chkng.Enabled = false;
                Step5A2chkok.Checked = false;
                Step5A2chkng.Checked = false;
                Step5A3chkok.Checked = false;
                Step5A3chkng.Checked = false;
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

                dba.UpdatePageUser1(gc.Process, gc.HandlerNo, gc.LotNo, gc.Status, gc.AmountNG, gc.PackageName, gc.DeviceName,
                    gc.Flow, gc.MNo, gc.TesterNo, gc.BoxNo, gc.TRank, gc.WaferLotNo, gc.WaferSheetNo, gc.TPRank, gc.Shipment, gc.Shipmentdate,
                    gc.InputQuantity, gc.ControlYield, gc.InitialYield, gc.CheckValue, gc.ActionPCS, gc.ActionPercent,
                    gc.S2TestNoA1, gc.S2TestNoA2, gc.S2TestNoA3, gc.S2TestNoA4, gc.S2TestNoA5,
                    gc.S2NG_A1, gc.S2NG_A2, gc.S2NG_A3, gc.S2NG_A4, gc.S2NG_A5,
                    gc.S2TestNoB1, gc.S2TestNoB2, gc.S2TestNoB3, gc.S2TestNoB4, gc.S2TestNoB5,
                    gc.S2NG_B1, gc.S2NG_B2, gc.S2NG_B3, gc.S2NG_B4, gc.S2NG_B5,
                    gc.SetupCheck, gc.ManaulCheck1, gc.Result1_1, gc.ManaulCheck1_2, gc.Result1_2, gc.ManaulCheck1_3, gc.Result1_3, gc.ManaulCheck2, gc.Result2, gc.ManaulCheck3, gc.Result3, gc.SocketChangeHist, gc.SocketChangeLastDate, gc.IsRestartStep3,
                    gc.CheckLowYieldKanban, gc.CheckAlarmBin, gc.OPName1_ID, gc.OPName1_Sign, gc.OPName1_SignDate,gc.RequestDate,gc.Mode,gc.RequestType, gc.FinalYield, gc.ControlLCL, gc.IssueNo, gc.CheckSocket, gc.ContactNG);

                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Save Done')", true);

                //Response.Redirect("~/PageMonitoring.aspx");

                if (Statuspart == "2")
                {
                    //Request BM
                    Response.Redirect("http://webserv.thematrix.net/LsiPETE/LSI_Prog/Maintenance/MainloginPD.asp?MCNo=" + gc.HandlerNo + "&LotNo=" + gc.LotNo);
                    //MCNo=FL - C-02&LotNo=2025A1154V&MCStatus=Running
                }
                else if (Statuspart == "3")
                {
                    Response.Redirect("~/InputPageUser3.aspx?Process=" + gc.Process + "&MCNo=" + gc.HandlerNo + "&Device=" + gc.DeviceName + "&LotNo=" + gc.LotNo + "&User=" + gc.OPName1_ID + "&Edit=FALSE");
                }
                else
                {
                    string strUrl;
                    strUrl = "~/PageMonitoring_OP.aspx?userId=" + Request.Params["User"];
                    Response.Redirect(strUrl);
                }
            }

        }

        public void SetValue()
        {
            if (Request.Params["Process"] == "")
            {
                gc.Process = "FL";
            }
            else
            {
                gc.Process = Request.Params["Process"]; //get parameter from url
            }

            gc.LotNo = Request.Params["LotNo"]; //get parameter from url
            gc.HandlerNo = Request.Params["MCNo"]; //get parameter from url
            gc.User = Request.Params["User"];
            gc.Edit = Request.Params["Edit"];
            gc.MNo = Request.Params["MNo"]; //get parameter from url
            gc.TesterNo = Request.Params["TesterNo"]; //get parameter from url
            gc.Flow = Request.Params["Flow"]; //get parameter from url
            gc.PackageName = Request.Params["Package"]; //get parameter from url
            gc.ControlYield = Request.Params["Control"]; //get parameter from url
            gc.ControlLCL = Request.Params["Control"]; //get parameter from url


            //Add 2020-08-28 แยกชั้นจาก Package
            var tblPackage = new DataTable();
            tblPackage = dba.CheckPackage(gc.PackageName);
            if (tblPackage.Rows.Count == 1)
            {
                foreach (DataRow row in tblPackage.Rows)
                {
                    Floor = row["Floor"].ToString();
                    IssueNoVa = "%" + gc.Process + Floor + "%"; //ค่าที่ได้คือ FL1 , FL2 , FT1 , FT2 , MAP
                }
            }

            var tblRunIssueNo = new DataTable();
            tblRunIssueNo = dba.CheckRunIssueNo(IssueNoVa);
            if (tblRunIssueNo.Rows.Count > 0)
            {
                foreach (DataRow row in tblRunIssueNo.Rows)
                {
                    //IssueNoVa1 = row["IssueNo"].ToString();
                    MyNumber1 = Int32.Parse(row["MyNumber"].ToString());
                    MM1 = row["MyMM"].ToString();
                    YY1 = row["MyYYYY"].ToString();

                    string myYear = DateTime.Now.ToString("yyyy"); // ค่าที่ได้เป็น ค.ศ ปัจจุบัน เช่น 2020
                    string myMonth = DateTime.Now.ToString("MM");  // ค่าที่ได้เป็น เดือน ปัจจุบัน เช่น 08
                    //tbHead4.Text = myMonth + myYear;

                    ////เทียบค่าแล้ว รัน Issue No
                    if (YY1 == myYear)
                    {
                        if (MM1 == myMonth)
                        {
                            MyNumber1 = MyNumber1 + 1;
                            MyNumber = String.Format("{0,4:D4}", MyNumber1);
                            //ISNO = Request.Params["Process"] + Floor + "F-" + myYear + "-" + myMonth + "-" + MyNumber;
                            ISNO = "FL" + Floor + "F-" + myYear + "-" + myMonth + "-" + MyNumber;
                            gc.IssueNo = ISNO;
                            //tbHead4.Text = ISNO;
                        }
                        else if (MM1 != myMonth)
                        {
                            MyNumber1 = MyNumber1 + 1;
                            MyNumber = String.Format("{0,4:D4}", MyNumber1);
                            //ISNO = Request.Params["Process"] + Floor + "F-" + myYear + "-" + myMonth + "-0001";
                            ISNO = "FL" + Floor + "F-" + myYear + "-" + myMonth + "-" + MyNumber;
                            gc.IssueNo = ISNO;
                            //tbHead4.Text = gc.IssueNo;

                        }
                    }
                    else if (YY1 != myYear)
                    {
                        if (MM1 != myMonth)
                        {
                            MyNumber = String.Format("{0,4:D4}", MyNumber1);
                            //ISNO = Request.Params["Process"] + Floor + "F-" + myYear + "-" + myMonth + "-0001";
                            ISNO = "FL" + Floor + "F-" + myYear + "-" + myMonth + "-" + MyNumber;
                            gc.IssueNo = ISNO;
                            //tbHead4.Text = gc.IssueNo;
                        }
                    }
                }
            }

            //Add 2019-03-04
            if (Request.Params["Mode"] != "")
            {
                gc.Mode = Int32.Parse(Request.Params["Mode"]);
            }
            else
            {
                //Add 2020-06-24 กรณีRequest ผ่านเว็บ
                if (CheckS7A1.Checked == true || CheckS7A2.Checked == true || CheckS7A3.Checked == true || CheckS7A4.Checked == true)
                {
                    gc.Mode = 2;
                }
                else
                {
                    gc.Mode = 1;
                }
            }

            if (Request.Params["RequestType"] == "")
            {
                gc.RequestType = "INITIAL";
            }
            else
            {
                gc.RequestType = Request.Params["RequestType"];
            }


            //Add 2020-03-09
            // Shipmentdate date
            if (DateS1.Value != "Date" && DateS2.Value != "Month" && DateS3.Value != "Year" && DateS4.Value != "Hour" && DateS5.Value != "Minute")
            {
                gc.Shipmentdate = DateS3.Value + "-" + DateS2.Value + "-" + DateS1.Value + " " + DateS4.Value + ":" + DateS5.Value;
            }




            //set User Stamp
            //user ID
            gc.OPName1_ID = gc.User;

            //user sign
            var tbl = new DataTable();

            tbl = dba.Login(gc.User);//Get data from Apcs Database

            if (tbl.Rows.Count == 1)
            {
                foreach (DataRow row in tbl.Rows)
                {
                    gc.OPName1_Sign = row["name"].ToString(); //get name of user
                }
            }
            else
            {
                gc.OPName1_Sign = gc.User;
            }

            //user sign date
            gc.OPName1_SignDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // case sensitive

            //Request Date 
            gc.RequestDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            //Header
            if (tbHead1.Text != "")
            {
                gc.AmountNG = Int32.Parse(tbHead1.Text);
            }

            gc.HandlerNo = tbHead2.Text;
            gc.LotNo = tbHead3.Text;
            gc.PackageName = tbHead4.Text;
            gc.DeviceName = tbHead5.Text;


            if (headSelect1.SelectedIndex == 0)
            {
                gc.Flow = "";
            }
            else if (headSelect1.SelectedIndex == 1)
            {
                gc.Flow = "AUTO1";
            }
            else if (headSelect1.SelectedIndex == 2)
            {
                gc.Flow = "AUTO2";
            }
            else if (headSelect1.SelectedIndex == 3)
            {
                gc.Flow = "AUTO3";
            }
            else if (headSelect1.SelectedIndex == 4)
            {
                gc.Flow = "AUTO4";
            }


            gc.MNo = tbHead6.Text;
            gc.TesterNo = tbHead7.Text;
            gc.BoxNo = tbHead8.Text;
            gc.TRank = tbHead9.Text;
            gc.WaferLotNo = tbHead10.Text;
            gc.WaferSheetNo = tbHead11.Text;
            gc.TPRank = tbHead12.Text;

            //shipment
            if (headSelect2.SelectedIndex == 0)
            {
                gc.Shipment = "";
            }
            else if (headSelect2.SelectedIndex == 1)
            {
                gc.Shipment = "JAPAN";
            }
            else
            {
                gc.Shipment = "OVERSEA";
            }


            //################################## SET STEP 1 ##################################
            if (tbS1A1.Text != "")
            {
                gc.InputQuantity = Int32.Parse(tbS1A1.Text);
            }

            if (tbS1A2.Text != "")
            {
                gc.ControlYield = tbS1A2.Text;
            }

            if (tbS1A3.Text != "")
            {
                gc.InitialYield = tbS1A3.Text;
                gc.FinalYield = tbS1A3.Text;
            }
            else
            {
                gc.InitialYield = "-";
                gc.FinalYield = "-";
            }

            if (tbS1A4.Text != "")
            {
                gc.CheckValue = tbS1A4.Text;
            }
            else
            {
                gc.CheckValue = "-";
            }

            if (tbS1A5.Text != "")
            {
                gc.ActionPCS = Int32.Parse(tbS1A5.Text);
            }

            if (tbS1A6.Text != "")
            {
                gc.ActionPercent = tbS1A6.Text;
            }
            else
            {
                gc.ActionPercent = "-";
            }


            //################################### SET STEP 2,3 ###############################

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


            //################################ SET STEP 4 #####################################
            if (SelectS4.SelectedIndex == 0)
            {
                gc.SetupCheck = "";
            }
            else if (SelectS4.SelectedIndex == 1)
            {
                gc.SetupCheck = "OK";
            }
            else
            {
                gc.SetupCheck = "NG";
            }

            //############################## STEP 5 ##########################################
            if (cbStep5_1.Checked == true)
            {
                if (rbStep5A1.Checked == true)
                {
                    gc.ManaulCheck1 = "SOCKETCHANGE";

                    if (Step5A1chkok.Checked == true)
                    {
                        gc.Result1_1 = "Mass NG to Good";
                    }
                    if (Step5A1chkng.Checked == true)
                    {
                        gc.Result1_1 = "Mass NG to NG";
                    }
                }

                if (rbStep5A2.Checked == true)
                {
                    gc.ManaulCheck1_2 = "REQUESTPM";
                    if (Step5A2chkok.Checked == true)
                    {
                        gc.Result1_2 = "Mass NG to Good";
                    }
                    if (Step5A2chkng.Checked == true)
                    {
                        gc.Result1_2 = "Mass NG to NG";
                    }
                }

                if (rbStep5A3.Checked == true)
                {
                    gc.ManaulCheck1_3 = tbS5.Text;
                    if (Step5A3chkok.Checked == true)
                    {
                        gc.Result1_3 = "Mass NG to Good";
                    }
                    if (Step5A3chkng.Checked == true)
                    {
                        gc.Result1_3 = "Mass NG to NG";
                    }
                }

            }
            else
            {
                gc.ManaulCheck1 = "";
                gc.ManaulCheck1_2 = "";
                gc.ManaulCheck1_3 = "";
                gc.Result1_1 = "";
                gc.Result1_2 = "";
                gc.Result1_3 = "";
            }


            if (cbStep5_2.Checked == true)
            {
                gc.ManaulCheck2 = "REQUESTTE";
                if (cbStep5_2chkok.Checked == true)
                {
                    gc.Result2 = "Good to NG";
                }
                if (cbStep5_2chkng.Checked == true)
                {
                    gc.Result2 = "Good to Good";
                }
            }
            else
            {
                gc.ManaulCheck2 = "";
                gc.Result2 = "";
            }


            if (cbStep5_3.Checked == true)
            {
                gc.ManaulCheck3 = "REQUESTTE";
                if (cbStep5_3chkok.Checked == true)
                {
                    gc.Result3 = "NG to NG AND Good to Good";
                }
                if (cbStep5_3chkng.Checked == true)
                {
                    gc.Result3 = "NG to Good AND Good to Good";
                }
            }
            else
            {
                gc.ManaulCheck3 = "";
                gc.Result3 = "";
            }

            //Add 2020-10-20
            if (SelectS5A1.SelectedIndex == 0)
            {
                gc.CheckSocket = "";
            }
            if (SelectS5A1.SelectedIndex == 1)
            {
                gc.CheckSocket = "A";
            }
            else if (SelectS5A1.SelectedIndex == 2)
            {
                gc.CheckSocket = "B";
            }
            else if (SelectS5A1.SelectedIndex == 3)
            {
                gc.CheckSocket = "C";
            }

            //############################### STEP 6 ############################
            if (SelectS6A1.SelectedIndex == 0)
            {
                gc.SocketChangeHist = "";
            }
            if (SelectS6A1.SelectedIndex == 1)
            {
                gc.SocketChangeHist = "WEEK";
            }
            else
            {
                gc.SocketChangeHist = "OVERWEEK";
            }

            // socket change date
            if (DateS6.Value != "Date" && DateS7.Value != "Month" && DateS8.Value != "Year" && DateS9.Value != "Hour" && DateS10.Value != "Minute")
            {
                gc.SocketChangeLastDate = DateS8.Value + "-" + DateS7.Value + "-" + DateS6.Value + " " + DateS9.Value + ":" + DateS10.Value;
            }


            if (SelectS6A2.SelectedIndex == 0)
            {
                gc.IsRestartStep3 = "";
            }
            else if (SelectS6A2.SelectedIndex == 1)
            {
                gc.IsRestartStep3 = "YES";
            }
            else
            {
                gc.IsRestartStep3 = "NO";
            }

            //############################ STEP 7 #######################
            if (SelectS7.SelectedIndex == 0)
            {
                gc.CheckLowYieldKanban = "";
            }
            else if (SelectS7.SelectedIndex == 1)
            {
                gc.CheckLowYieldKanban = tbS7.Text;
            }
            else if (SelectS7.SelectedIndex == 2)
            {
                gc.CheckLowYieldKanban = "NO";
            }
            else if (SelectS7.SelectedIndex == 3)
            {
                gc.CheckLowYieldKanban = "EXP";
            }

            //Contact NG
            if (SelectS7_1.SelectedIndex == 0)
            {
                gc.ContactNG = "";
            }
            else if (SelectS7_1.SelectedIndex == 1)
            {
                gc.ContactNG = tbS7.Text;
            }
            else if (SelectS7_1.SelectedIndex == 2)
            {
                gc.ContactNG = "NO";
            }

            //set alarm bin
            if (CheckS7A1.Checked == true)
            {
                gc.CheckAlarmBin = "BIN28";
            }

            if (CheckS7A2.Checked == true)
            {
                if (gc.CheckAlarmBin == "")
                {
                    gc.CheckAlarmBin = "BIN29";
                }
                else
                {
                    gc.CheckAlarmBin = gc.CheckAlarmBin + ",BIN29";
                }
            }

            if (CheckS7A3.Checked == true)
            {
                if (gc.CheckAlarmBin == "")
                {
                    gc.CheckAlarmBin = "BIN30";
                }
                else
                {
                    gc.CheckAlarmBin = gc.CheckAlarmBin + ",BIN30";
                }

            }

            if (CheckS7A4.Checked == true)
            {
                if (gc.CheckAlarmBin == "")
                {
                    gc.CheckAlarmBin = "BIN31";
                }
                else
                {
                    gc.CheckAlarmBin = gc.CheckAlarmBin + ",BIN31";
                }

            }

            if (CheckS7A5.Checked == true)
            {
                gc.CheckAlarmBin = "NO";
            }

            ///############################ STEP Status #######################
            //Lot นี้ Request เข้ามาด้วย BIN29 หลังจาก OP กรอกเสร็จ ให้ไปหา BM เลย ไม่ว่าข้อ5 Manual Check เลือกเป็นอะไร
            //if (CheckS7A2.Checked == true)
            //{
            //    if (gc.CheckAlarmBin == "")
            //    {
            //        checkalrm = "BIN29";
            //        gc.Status = "2";
            //        Statuspart = "2";
            //    }
            //}


            //if (checkalrm == "BIN29")
            //{
            //    gc.Status = "2";
            //    Statuspart = "2";
            //}
            //else
            //{
            //    if (gc.Edit == "TRUE")
            //    {
            //        gc.Status = "3";
            //        Statuspart = "3";
            //    }
            //    else if (gc.Edit == "FALSE")
            //    {
            //        //check Low Yield Kanban ledger = มี
            //        if (SelectS7.SelectedIndex == 1)
            //        {
            //            //OP
            //            gc.Status = "3";
            //            Statuspart = "3";
            //        }
            //        else
            //        {
            //            if (SelectS7_1.SelectedIndex == 1)
            //            {
            //                gc.Status = "3";
            //                Statuspart = "3";
            //            }
            //            else
            //            {
            //                //check Low Yield Kanban ledger = ไม่มี หรือ หมดอายุ
            //                //BM
            //                gc.Status = "2";
            //                Statuspart = "2";
            //            }
            //        }
            //    }
            //}


            //ADD 2020-12-10
            if (gc.CheckAlarmBin == "BIN29")
            {
                checkalrm = "BIN29";
                gc.Status = "2";
                Statuspart = "2";
            }
            else if (gc.CheckAlarmBin == "BIN28" || gc.CheckAlarmBin == "BIN30" || gc.CheckAlarmBin == "BIN31")
            {
                //BIN28-30-31
                //ถ้าเป็นงาน BIN จะไม่ Request BM
                //OP
                gc.Status = "3";
                Statuspart = "3";
            }
            else
            {
                //ไม่ได้เลือก Check Alarm Bin ข้อ 7
                //check Low Yield Kanban ledger = มี
                if (SelectS7.SelectedIndex == 1)
                {
                    //OP
                    gc.Status = "3";
                    Statuspart = "3";
                }
                else
                {
                    if (SelectS7_1.SelectedIndex == 1)
                    {
                        gc.Status = "3";
                        Statuspart = "3";
                    }
                    else
                    {
                        //check Low Yield Kanban ledger = ไม่มี หรือ หมดอายุ
                        //BM
                        gc.Status = "2";
                        Statuspart = "2";
                    }
                }
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

            ////amount ng
            if (String.IsNullOrEmpty(tbHead1.Text))
            {
                tbHead1.BackColor = System.Drawing.Color.Red;
                countEmpty += 1;
            }
            else
            {
                tbHead1.BackColor = System.Drawing.Color.White;
            }

            ////handlerno
            if (String.IsNullOrEmpty(tbHead2.Text))
            {
                tbHead2.BackColor = System.Drawing.Color.Red;
                countEmpty += 1;
            }
            else
            {
                tbHead2.BackColor = System.Drawing.Color.White;
            }

            ////lotno
            if (String.IsNullOrEmpty(tbHead3.Text))
            {
                tbHead3.BackColor = System.Drawing.Color.Red;
                countEmpty += 1;
            }
            else
            {
                tbHead3.BackColor = System.Drawing.Color.White;
            }

            ////packagename
            if (String.IsNullOrEmpty(tbHead4.Text))
            {
                tbHead4.BackColor = System.Drawing.Color.Red;
                countEmpty += 1;
            }
            else
            {
                tbHead4.BackColor = System.Drawing.Color.White;
            }

            ////device
            if (String.IsNullOrEmpty(tbHead5.Text))
            {
                tbHead5.BackColor = System.Drawing.Color.Red;
                countEmpty += 1;
            }
            else
            {
                tbHead5.BackColor = System.Drawing.Color.White;
            }

            ////flow
            //headSelect1.SelectedIndex;
            if (headSelect1.SelectedIndex == 0)
            {
                headSelect1.BackColor = System.Drawing.Color.Red;
                countEmpty += 1;
            }
            else
            {
                headSelect1.BackColor = System.Drawing.Color.White;
            }

            ////m no
            if (String.IsNullOrEmpty(tbHead6.Text))
            {
                tbHead6.BackColor = System.Drawing.Color.Red;
                countEmpty += 1;
            }
            else
            {
                tbHead6.BackColor = System.Drawing.Color.White;
            }

            ////test no
            if (String.IsNullOrEmpty(tbHead7.Text))
            {
                tbHead7.BackColor = System.Drawing.Color.Red;
                countEmpty += 1;
            }
            else
            {
                tbHead7.BackColor = System.Drawing.Color.White;
            }

            ////box no
            if (String.IsNullOrEmpty(tbHead8.Text))
            {
                tbHead8.BackColor = System.Drawing.Color.Red;
                countEmpty += 1;
            }
            else
            {
                tbHead8.BackColor = System.Drawing.Color.White;
            }

            //T rank
            if (String.IsNullOrEmpty(tbHead9.Text))
            {
                tbHead9.BackColor = System.Drawing.Color.Red;
                countEmpty += 1;
            }
            else
            {
                tbHead9.BackColor = System.Drawing.Color.White;
            }

            //Wafer Lot No
            if (String.IsNullOrEmpty(tbHead10.Text))
            {
                tbHead10.BackColor = System.Drawing.Color.Red;
                countEmpty += 1;
            }
            else
            {
                tbHead10.BackColor = System.Drawing.Color.White;
            }

            //wafer no
            if (String.IsNullOrEmpty(tbHead11.Text))
            {
                tbHead11.BackColor = System.Drawing.Color.Red;
                countEmpty += 1;
            }
            else
            {
                tbHead11.BackColor = System.Drawing.Color.White;
            }

            // T/P Rank
            if (String.IsNullOrEmpty(tbHead12.Text))
            {
                tbHead12.BackColor = System.Drawing.Color.Red;
                countEmpty += 1;
            }
            else
            {
                tbHead12.BackColor = System.Drawing.Color.White;
            }


            //Shipment
            //if (headSelect2.SelectedIndex == 0)
            //{
            //    headSelect2.BackColor = System.Drawing.Color.Red;
            //    countEmpty += 1;
            //}
            //else
            //{
            //    headSelect2.BackColor = System.Drawing.Color.White;
            //}

            //################### Step 1 #################
            //input quantity
            if (String.IsNullOrEmpty(tbS1A1.Text))
            {
                tbS1A1.BackColor = System.Drawing.Color.Red;
                countEmpty += 1;
            }
            else
            {
                tbS1A1.BackColor = System.Drawing.Color.White;
            }

            //Control Yield
            if (String.IsNullOrEmpty(tbS1A2.Text))
            {
                tbS1A2.BackColor = System.Drawing.Color.Red;
                countEmpty += 1;
            }
            else
            {
                tbS1A2.BackColor = System.Drawing.Color.White;
            }

            //Initial Yield
            if (String.IsNullOrEmpty(tbS1A3.Text))
            {
                tbS1A3.BackColor = System.Drawing.Color.Red;
                countEmpty += 1;
            }
            else
            {
                tbS1A3.BackColor = System.Drawing.Color.White;
            }

            //Check
            if (String.IsNullOrEmpty(tbS1A4.Text))
            {
                tbS1A4.BackColor = System.Drawing.Color.Red;
                countEmpty += 1;
            }
            else
            {
                tbS1A4.BackColor = System.Drawing.Color.White;
            }

            //Action
            if (String.IsNullOrEmpty(tbS1A5.Text))
            {
                tbS1A5.BackColor = System.Drawing.Color.Red;
                countEmpty += 1;
            }
            else
            {
                tbS1A5.BackColor = System.Drawing.Color.White;
            }

            //PCS
            if (String.IsNullOrEmpty(tbS1A6.Text))
            {
                tbS1A6.BackColor = System.Drawing.Color.Red;
                countEmpty += 1;
            }
            else
            {
                tbS1A6.BackColor = System.Drawing.Color.White;
            }

            //############################### Step 2 3 ##############################

            //############################# Ach #############

            //Test No
            if (String.IsNullOrEmpty(tbS2r1c1.Text))
            {
                tbS2r1c1.BackColor = System.Drawing.Color.Red;
                countEmpty += 1;
            }
            else
            {
                tbS2r1c1.BackColor = System.Drawing.Color.White;
            }


            //จำนวน NG
            if (String.IsNullOrEmpty(tbS2r2c1.Text))
            {
                tbS2r2c1.BackColor = System.Drawing.Color.Red;
                countEmpty += 1;
            }
            else
            {
                tbS2r2c1.BackColor = System.Drawing.Color.White;
            }


            // ############################ Bch ####################
            //Test No
            if (String.IsNullOrEmpty(tbS2r3c1.Text))
            {
                tbS2r3c1.BackColor = System.Drawing.Color.Red;
                countEmpty += 1;
            }
            else
            {
                tbS2r3c1.BackColor = System.Drawing.Color.White;
            }



            //จำนวน NG
            if (String.IsNullOrEmpty(tbS2r4c1.Text))
            {
                tbS2r4c1.BackColor = System.Drawing.Color.Red;
                countEmpty += 1;
            }
            else
            {
                tbS2r4c1.BackColor = System.Drawing.Color.White;
            }


            ////######################### STEP 5 ##############################
            if (SelectS7.SelectedIndex == 1) // 1 = มี 
            {

            }
            else
            {
                if (cbStep5_1.Checked == false && cbStep5_2.Checked == false && cbStep5_3.Checked == false)
                {
                    cbStep5_1.BackColor = System.Drawing.Color.Red;
                    cbStep5_2.BackColor = System.Drawing.Color.Red;
                    cbStep5_3.BackColor = System.Drawing.Color.Red;
                    countEmpty += 1;
                }
                else
                {
                    if (cbStep5_1.Checked == true)
                    {
                        if (rbStep5A1.Checked == false && rbStep5A2.Checked == false && rbStep5A3.Checked == false)
                        {
                            rbStep5A1.BackColor = System.Drawing.Color.Red;
                            rbStep5A2.BackColor = System.Drawing.Color.Red;
                            rbStep5A3.BackColor = System.Drawing.Color.Red;
                            countEmpty += 1;
                        }
                    }
                    else if (cbStep5_2.Checked == true)
                    {
                        if (cbStep5_2chkok.Checked == false && cbStep5_2chkng.Checked == false)
                        {
                            cbStep5_2chkok.BackColor = System.Drawing.Color.Red;
                            cbStep5_2chkng.BackColor = System.Drawing.Color.Red;
                            countEmpty += 1;
                        }
                    }
                    else if (cbStep5_3.Checked == true)
                    {
                        if (cbStep5_3chkok.Checked == false && cbStep5_3chkng.Checked == false)
                        {
                            cbStep5_3chkok.BackColor = System.Drawing.Color.Red;
                            cbStep5_3chkng.BackColor = System.Drawing.Color.Red;
                            countEmpty += 1;
                        }
                    }
                }
            }
            ////######################### STEP 7 ##############################
            if (SelectS7_1.SelectedIndex == 0 && (SelectS7.SelectedIndex==2 || SelectS7.SelectedIndex==3))
            {
                SelectS7_1.BackColor = System.Drawing.Color.Red;
                countEmpty += 1;
            }
            else
            {
                SelectS7_1.BackColor = System.Drawing.Color.White;
            }

            //if (SelectS7.SelectedIndex == 0)
            //{
            //    SelectS7.BackColor = System.Drawing.Color.Red;
            //    countEmpty += 1;
            //}
            //else
            //{
            //    SelectS7.BackColor = System.Drawing.Color.White;
            //}


            //if (CheckS7A1.Checked == false && CheckS7A2.Checked == false && CheckS7A3.Checked == false && CheckS7A4.Checked == false && CheckS7A5.Checked == false)
            //{
            //    CheckS7A1.BackColor = System.Drawing.Color.Red;
            //    CheckS7A2.BackColor = System.Drawing.Color.Red;
            //    CheckS7A3.BackColor = System.Drawing.Color.Red;
            //    CheckS7A4.BackColor = System.Drawing.Color.Red;
            //    CheckS7A5.BackColor = System.Drawing.Color.Red;
            //    countEmpty += 1;
            //}
            //else
            //{
            //    CheckS7A1.BackColor = System.Drawing.Color.White;
            //    CheckS7A2.BackColor = System.Drawing.Color.White;
            //    CheckS7A3.BackColor = System.Drawing.Color.White;
            //    CheckS7A4.BackColor = System.Drawing.Color.White;
            //    CheckS7A5.BackColor = System.Drawing.Color.White;
            //}



            ////#################### Check count empty ###############
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


    }
}