using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LowYieldCheckSheet
{
    public partial class LotMoveStep3_Test : System.Web.UI.Page
    {
        DBAccess dba = new DBAccess();
        GlobalClass gc = new GlobalClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        public void LoadData()
        {
            gc.Process = Request.Params["Process"]; //get parameter from url
            gc.LotNo = Request.Params["LotNo"]; //get parameter from url
            gc.HandlerNo = Request.Params["MCNo"]; //get parameter from url
            gc.Edit = Request.Params["Edit"]; // get parameter from url

            var tbl1 = new DataTable();
            tbl1 = dba.PullByMCNoAndLotNo(gc.Process, gc.HandlerNo, gc.LotNo); //get data from main table

            if (tbl1.Rows.Count == 1)
            {
                foreach (DataRow row in tbl1.Rows)
                {
                    txtStoreValue.Text = row["Status"].ToString();  //store Current Status
                }
            }


            var tbl = new DataTable();
            //get data from movelot table
            tbl = dba.PullMoveLotData(Request.Params["MCNo"], Request.Params["LotNo"]); //Send a function with parameter from url

            if (tbl.Rows.Count == 1)
            {
                foreach (DataRow row in tbl.Rows)
                {
                    //############ HEADER ####################
                    tbDate.Value = row["RequestMoveDate"].ToString();
                    tbDevice.Value = row["DeviceName"].ToString();
                    tbLotNo.Value = row["LotNo"].ToString();
                    tbMCNo.Value = row["MCNo"].ToString();
                    tbReason.Value = row["MoveLotReason"].ToString();

                    //########### number 1 ######################
                    if (string.IsNullOrEmpty(row["Bfb1"].ToString()))
                    {
                        select1.SelectedIndex = 0;
                    }
                    else
                    {
                        if (row["Bfb1"].ToString() == "YES")
                        {
                            select1.SelectedIndex = 1;
                            tbR1.Value = row["Bfb1_TgBefore"].ToString();
                        }
                        else if (row["Bfb1"].ToString() == "NO")
                        {
                            select1.SelectedIndex = 2;
                        }
                    }

                    //########### number 2 ######################
                    if (string.IsNullOrEmpty(row["Bfb2"].ToString()))
                    {
                        select2.SelectedIndex = 0;
                    }
                    else
                    {
                        if (row["Bfb2"].ToString() == "YES")
                        {
                            select2.SelectedIndex = 1;
                            tbR2A1.Value = row["Bfb2_Good"].ToString();
                            tbR2A2.Value = row["Bfb2_StdReel"].ToString();
                            tbR2A3.Value = row["Bfb2_HasuuReel"].ToString();

                        }
                        else if (row["Bfb2"].ToString() == "NO")
                        {
                            select2.SelectedIndex = 2;
                        }
                    }

                    //######## number 3 ######################
                    if (string.IsNullOrEmpty(row["Bfb3"].ToString()))
                    {
                        select3.SelectedIndex = 0;
                    }
                    else
                    {
                        if (row["Bfb3"].ToString() == "YES")
                        {
                            select3.SelectedIndex = 1;
                            tbR3A1.Value = row["Bfb3_QTy"].ToString();
                            tbR3A2.Value = row["Bfb3_Unit"].ToString();
                            tbR3A3.Value = row["Bfb3_Result"].ToString();
                        }
                        else if (row["Bfb3"].ToString() == "NO")
                        {
                            select3.SelectedIndex = 2;
                        }
                    }

                    //####### number 4 #######################
                    if (string.IsNullOrEmpty(row["Bfb4"].ToString()))
                    {
                        select4.SelectedIndex = 0;
                    }
                    else
                    {
                        if (row["Bfb4"].ToString() == "YES")
                        {
                            select4.SelectedIndex = 1;
                            tbR4.Value = row["Bfb4_OS"].ToString();
                        }
                        else if (row["Bfb4"].ToString() == "NO")
                        {
                            select4.SelectedIndex = 2;
                        }
                    }

                    //######### number 5 ####################
                    if (string.IsNullOrEmpty(row["Bfb5"].ToString()))
                    {
                        select5.SelectedIndex = 0;
                    }
                    else
                    {
                        if (row["Bfb5"].ToString() == "YES")
                        {
                            select5.SelectedIndex = 1;
                            tbR5.Value = row["Bfb5_FT"].ToString();
                        }
                        else if (row["Bfb5"].ToString() == "NO")
                        {
                            select5.SelectedIndex = 2;
                        }
                    }

                    //######## number 6 ##################
                    if (string.IsNullOrEmpty(row["Bfb6"].ToString()))
                    {
                        select6.SelectedIndex = 0;
                    }
                    else
                    {
                        if (row["Bfb6"].ToString() == "YES")
                        {
                            select6.SelectedIndex = 1;
                            tbR6.Value = row["Bfb6_Make"].ToString();
                        }
                        else if (row["Bfb6"].ToString() == "NO")
                        {
                            select6.SelectedIndex = 2;
                        }
                    }

                    //############# number 7 ###############
                    if (string.IsNullOrEmpty(row["Bfb7"].ToString()))
                    {
                        select7.SelectedIndex = 0;
                    }
                    else
                    {
                        if (row["Bfb7"].ToString() == "YES")
                        {
                            select7.SelectedIndex = 1;
                            tbR7.Value = row["Bfb7_Marker"].ToString();
                        }
                        else if (row["Bfb7"].ToString() == "NO")
                        {
                            select7.SelectedIndex = 2;
                        }
                    }

                    //########### number 8 ###################
                    if (string.IsNullOrEmpty(row["Bfb8"].ToString()))
                    {
                        select8.SelectedIndex = 0;
                    }
                    else
                    {
                        if (row["Bfb8"].ToString() == "YES")
                        {
                            select8.SelectedIndex = 1;
                            tbR8.Value = row["Bfb8_TP"].ToString();
                        }
                        else if (row["Bfb8"].ToString() == "NO")
                        {
                            select8.SelectedIndex = 2;
                        }
                    }

                    //######## number 9 ################
                    if (string.IsNullOrEmpty(row["Bfb9"].ToString()))
                    {
                        select9.SelectedIndex = 0;
                    }
                    else
                    {
                        if (row["Bfb9"].ToString() == "YES")
                        {
                            select9.SelectedIndex = 1;
                            tbR9.Value = row["Bfb9_Missing"].ToString();
                        }
                        else if (row["Bfb9"].ToString() == "NO")
                        {
                            select9.SelectedIndex = 2;
                        }
                    }

                    //########### number 10 #########
                    if (string.IsNullOrEmpty(row["Bfb10"].ToString()))
                    {
                        select10.SelectedIndex = 0;
                    }
                    else
                    {
                        if (row["Bfb10"].ToString() == "YES")
                        {
                            select10.SelectedIndex = 1;
                        }
                        else if (row["Bfb10"].ToString() == "NO")
                        {
                            select10.SelectedIndex = 2;
                        }
                    }


                    // ############# Total #############
                    tbTotal.Value = row["BfbTotal"].ToString();



                    //################################################### Bsr ########################################

                    //########### number 1 ######################
                    if (string.IsNullOrEmpty(row["Bsr1"].ToString()))
                    {
                        selectB1.SelectedIndex = 0;
                    }
                    else
                    {
                        if (row["Bsr1"].ToString() == "YES")
                        {
                            selectB1.SelectedIndex = 1;
                            tbR1B.Value = row["Bsr1_TgBefore"].ToString();
                            tbR1B.Disabled = false; ;
                        }
                        else if (row["Bsr1"].ToString() == "NO")
                        {
                            selectB1.SelectedIndex = 2;
                        }
                    }

                    //########### number 2 ######################
                    if (string.IsNullOrEmpty(row["Bsr2"].ToString()))
                    {
                        selectB2.SelectedIndex = 0;
                    }
                    else
                    {
                        if (row["Bsr2"].ToString() == "YES")
                        {
                            selectB2.SelectedIndex = 1;
                            tbR2B1.Value = row["Bsr2_Good"].ToString();
                            tbR2B2.Value = row["Bsr2_StdReel"].ToString();
                            tbR2B3.Value = row["Bsr2_HasuuReel"].ToString();

                            tbR2B1.Disabled = false;
                            tbR2B2.Disabled = false;
                            tbR2B3.Disabled = false;

                        }
                        else if (row["Bsr2"].ToString() == "NO")
                        {
                            selectB2.SelectedIndex = 2;
                        }
                    }

                    //######## number 3 ######################
                    if (string.IsNullOrEmpty(row["Bsr3"].ToString()))
                    {
                        selectB3.SelectedIndex = 0;
                    }
                    else
                    {
                        if (row["Bsr3"].ToString() == "YES")
                        {
                            selectB3.SelectedIndex = 1;
                            tbR3B1.Value = row["Bsr3_QTy"].ToString();
                            tbR3B2.Value = row["Bsr3_Unit"].ToString();
                            tbR3B3.Value = row["Bsr3_Result"].ToString();

                            tbR3B1.Disabled = false;
                            tbR3B2.Disabled = false;
                            tbR3B3.Disabled = false;
                        }
                        else if (row["Bsr3"].ToString() == "NO")
                        {
                            selectB3.SelectedIndex = 2;
                        }
                    }

                    //####### number 4 #######################
                    if (string.IsNullOrEmpty(row["Bsr4"].ToString()))
                    {
                        selectB4.SelectedIndex = 0;
                    }
                    else
                    {
                        if (row["Bsr4"].ToString() == "YES")
                        {
                            selectB4.SelectedIndex = 1;
                            tbR4B.Value = row["Bsr4_OS"].ToString();
                            tbR4B.Disabled = false;
                        }
                        else if (row["Bfb4"].ToString() == "NO")
                        {
                            selectB4.SelectedIndex = 2;
                        }
                    }

                    //######### number 5 ####################
                    if (string.IsNullOrEmpty(row["Bsr5"].ToString()))
                    {
                        selectB5.SelectedIndex = 0;
                    }
                    else
                    {
                        if (row["Bsr5"].ToString() == "YES")
                        {
                            selectB5.SelectedIndex = 1;
                            tbR5B.Value = row["Bsr5_FT"].ToString();
                            tbR5B.Disabled = false;
                        }
                        else if (row["Bsr5"].ToString() == "NO")
                        {
                            selectB5.SelectedIndex = 2;
                        }
                    }

                    //######## number 6 ##################
                    if (string.IsNullOrEmpty(row["Bsr6"].ToString()))
                    {
                        selectB6.SelectedIndex = 0;
                    }
                    else
                    {
                        if (row["Bsr6"].ToString() == "YES")
                        {
                            selectB6.SelectedIndex = 1;
                            tbR6B.Value = row["Bsr6_Make"].ToString();
                            tbR6B.Disabled = false;
                        }
                        else if (row["Bsr6"].ToString() == "NO")
                        {
                            selectB6.SelectedIndex = 2;
                        }
                    }

                    //############# number 7 ###############
                    if (string.IsNullOrEmpty(row["Bsr7"].ToString()))
                    {
                        selectB7.SelectedIndex = 0;
                    }
                    else
                    {
                        if (row["Bsr7"].ToString() == "YES")
                        {
                            selectB7.SelectedIndex = 1;
                            tbR7B.Value = row["Bsr7_Marker"].ToString();
                            tbR7B.Disabled = false;
                        }
                        else if (row["Bsr7"].ToString() == "NO")
                        {
                            selectB7.SelectedIndex = 2;
                        }
                    }

                    //########### number 8 ###################
                    if (string.IsNullOrEmpty(row["Bsr8"].ToString()))
                    {
                        selectB8.SelectedIndex = 0;
                    }
                    else
                    {
                        if (row["Bsr8"].ToString() == "YES")
                        {
                            selectB8.SelectedIndex = 1;
                            tbR8B.Value = row["Bsr8_TP"].ToString();
                            tbR8B.Disabled = false;
                        }
                        else if (row["Bsr8"].ToString() == "NO")
                        {
                            selectB8.SelectedIndex = 2;
                        }
                    }

                    //######## number 9 ################
                    if (string.IsNullOrEmpty(row["Bsr9"].ToString()))
                    {
                        selectB9.SelectedIndex = 0;
                    }
                    else
                    {
                        if (row["Bsr9"].ToString() == "YES")
                        {
                            selectB9.SelectedIndex = 1;
                            tbR9B.Value = row["Bsr9_Missing"].ToString();
                            tbR9B.Disabled = false;
                        }
                        else if (row["Bsr9"].ToString() == "NO")
                        {
                            selectB9.SelectedIndex = 2;
                        }
                    }

                    //########### number 10 #########
                    if (string.IsNullOrEmpty(row["Bsr10"].ToString()))
                    {
                        selectB10.SelectedIndex = 0;
                    }
                    else
                    {
                        if (row["Bsr10"].ToString() == "YES")
                        {
                            selectB10.SelectedIndex = 1;
                        }
                        else if (row["Bsr10"].ToString() == "NO")
                        {
                            selectB10.SelectedIndex = 2;
                        }
                    }


                    // ############# Total #############
                    tbTotalB.Value = row["BsrTotal"].ToString();

                }
            }
        }


        public void SetValue()
        {
            //##################### set #######################################
            gc.Process = Request.Params["Process"]; //get parameter from url
            //gc.DeviceName = Request.Params["Device"]; //get parameter from url
            gc.LotNo = Request.Params["LotNo"]; //get parameter from url
            gc.HandlerNo = Request.Params["MCNo"]; //get parameter from url
            gc.User = Request.Params["User"];
            gc.Edit = Request.Params["Edit"];//get parameter from url

            //############## set status #################
            if (gc.Edit == "TRUE")
            {
                //this is edit case
                //set status from store current status
                gc.Status = txtStoreValue.Text;
            }
            else if (gc.Edit == "FALSE")
            {
                //this is normal case
                gc.Status = "ML4";
            }

            //##################### set User Stamp #############################

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

            gc.OPName2_SignDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // case sensitive

            //######################## number 1 ######################################
            if (selectB1.SelectedIndex == 1)
            {
                gc.Bsr1 = "YES";


                if (tbR1B.Value == "")
                {
                    gc.Bsr1_TgBefore = 0;
                }
                else
                {
                    gc.Bsr1_TgBefore = Int32.Parse(tbR1B.Value);
                }
            }
            else if (selectB1.SelectedIndex == 2)
            {
                gc.Bsr1 = "NO";
            }



            //####################### number 2 #######################################
            if (selectB2.SelectedIndex == 1)
            {
                gc.Bsr2 = "YES";


                if (tbR2B1.Value == "")
                {
                    gc.Bsr2_Good = 0;
                }
                else
                {
                    gc.Bsr2_Good = Int32.Parse(tbR2B1.Value);
                }

                if (tbR2B2.Value == "")
                {
                    gc.Bsr2_StdReel = 0;
                }
                else
                {
                    gc.Bsr2_StdReel = Int32.Parse(tbR2B2.Value);
                }

                if (tbR2B3.Value == "")
                {
                    gc.Bsr2_HasuuReel = 0;
                }
                else
                {
                    gc.Bsr2_HasuuReel = Int32.Parse(tbR2B3.Value);
                }
            }
            else if (selectB2.SelectedIndex == 2)
            {
                gc.Bsr2 = "NO";
            }



            //####################### number 3 ########################################
            if (selectB3.SelectedIndex == 1)
            {
                gc.Bsr3 = "YES";

                if (tbR3B1.Value == "")
                {
                    gc.Bsr3_QTy = 0;
                }
                else
                {
                    gc.Bsr3_QTy = Int32.Parse(tbR3B1.Value);
                }

                if (tbR3B2.Value == "")
                {
                    gc.Bsr3_Unit = 0;
                }
                else
                {
                    gc.Bsr3_Unit = Int32.Parse(tbR3B2.Value);
                }

                if (tbR3B3.Value == "")
                {
                    gc.Bsr3_Result = 0;
                }
                else
                {
                    gc.Bsr3_Result = Int32.Parse(tbR3B3.Value);
                }
            }
            else if (selectB3.SelectedIndex == 2)
            {
                gc.Bsr3 = "NO";
            }




            //########################### number 4 ######################################
            if (selectB4.SelectedIndex == 1)
            {
                gc.Bsr4 = "YES";

                if (tbR4B.Value == "")
                {
                    gc.Bsr4_OS = 0;
                }
                else
                {
                    gc.Bsr4_OS = Int32.Parse(tbR4B.Value);
                }
            }
            else if (selectB4.SelectedIndex == 2)
            {
                gc.Bsr4 = "NO";
            }



            //########################## number 5 #####################################
            if (selectB5.SelectedIndex == 1)
            {
                gc.Bsr5 = "YES";

                if (tbR5B.Value == "")
                {
                    gc.Bsr5_FT = 0;
                }
                else
                {
                    gc.Bsr5_FT = Int32.Parse(tbR5B.Value);
                }
            }
            else if (selectB5.SelectedIndex == 2)
            {
                gc.Bsr5 = "NO";
            }




            //########################## number 6 #####################################
            if (selectB6.SelectedIndex == 1)
            {
                gc.Bsr6 = "YES";

                if (tbR6B.Value == "")
                {
                    gc.Bsr6_Make = 0;
                }
                else
                {
                    gc.Bsr6_Make = Int32.Parse(tbR6B.Value);
                }
            }
            else if (selectB6.SelectedIndex == 2)
            {
                gc.Bsr6 = "NO";
            }



            //########################## number 7 #####################################
            if (selectB7.SelectedIndex == 1)
            {
                gc.Bsr7 = "YES";

                if (tbR7B.Value == "")
                {
                    gc.Bsr7_Marker = 0;
                }
                else
                {
                    gc.Bsr7_Marker = Int32.Parse(tbR7B.Value);
                }
            }
            else if (selectB7.SelectedIndex == 2)
            {
                gc.Bsr7 = "NO";
            }




            //########################## number 8 #####################################
            if (selectB8.SelectedIndex == 1)
            {
                gc.Bsr8 = "YES";

                if (tbR8B.Value == "")
                {
                    gc.Bsr8_TP = 0;
                }
                else
                {
                    gc.Bsr8_TP = Int32.Parse(tbR8B.Value);
                }
            }
            else if (selectB8.SelectedIndex == 2)
            {
                gc.Bsr8 = "NO";
            }




            //########################## number 9 #####################################
            if (selectB9.SelectedIndex == 1)
            {
                gc.Bsr9 = "YES";

                if (tbR9B.Value == "")
                {
                    gc.Bsr9_Missing = 0;
                }
                else
                {
                    gc.Bsr9_Missing = Int32.Parse(tbR9B.Value);
                }
            }
            else if (selectB9.SelectedIndex == 2)
            {
                gc.Bsr9 = "NO";
            }




            //########################## number 10 #####################################
            if (selectB10.SelectedIndex == 1)
            {
                gc.Bsr10 = "YES";
            }
            else if (selectB10.SelectedIndex == 2)
            {
                gc.Bsr10 = "NO";
            }


            //############################ total ###################################
            if (tbTotalB.Value == "")
            {
                gc.BsrTotal = 0;
            }
            else
            {
                gc.BsrTotal = Int32.Parse(tbTotalB.Value);
            }

        }


        protected void btnConfirm_ServerClick(object sender, EventArgs e)
        {
            SetValue();

            dba.MoveLotS3(gc.HandlerNo, gc.LotNo,
                gc.Bsr1, gc.Bsr1_TgBefore,
                gc.Bsr2, gc.Bsr2_Good, gc.Bsr2_StdReel, gc.Bsr2_HasuuReel, gc.Bsr3, gc.Bsr3_QTy, gc.Bsr3_Unit, gc.Bsr3_Result,
                gc.Bsr4, gc.Bsr4_OS, gc.Bsr5, gc.Bsr5_FT, gc.Bsr6, gc.Bsr6_Make, gc.Bsr7, gc.Bsr7_Marker, gc.Bsr8, gc.Bsr8_TP,
                gc.Bsr9, gc.Bsr9_Missing, gc.Bsr10, gc.BsrTotal, gc.OPName2_ID, gc.OPName2_Sign, gc.OPName2_SignDate);


            dba.UpdateStatusOnly(gc.Process, gc.HandlerNo, gc.LotNo, gc.Status);

            //Back To Monitoring
            Response.Redirect("~/PageMonitoring.aspx");
        }




        protected void btnClose_ServerClick(object sender, EventArgs e)
        {
            //Back to monitoring
            Response.Redirect("~/PageMonitoring.aspx");
        }


    }
}