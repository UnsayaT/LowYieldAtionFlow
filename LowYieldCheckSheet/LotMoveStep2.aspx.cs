using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LowYieldCheckSheet
{
    public partial class LotMoveStep2_Test : System.Web.UI.Page
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
                            tbR1.Disabled = false;
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

                            tbR2A1.Disabled = false;
                            tbR2A2.Disabled = false;
                            tbR2A3.Disabled = false;

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

                            tbR3A1.Disabled = false;
                            tbR3A2.Disabled = false;
                            tbR3A3.Disabled = false;
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
                            tbR4.Disabled = false;
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
                            tbR5.Disabled = false;
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
                            tbR6.Disabled = false;
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
                            tbR7.Disabled = false;
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
                            tbR8.Disabled = false;
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
                            tbR9.Disabled = false;
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

                }
            }
        }


        public void SetValue()
        {
            //##################### set #######################################
            gc.Process = Request.Params["Process"]; //get parameter from url
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
                gc.Status = "5A"; //Go to QYI1
            }

            //##################### set User Stamp #############################

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

            //########################## HEADER ########################################
            gc.RequestMoveDate = tbDate.Value;
            gc.DeviceName = Request.Params["Device"]; //get parameter from url
            gc.LotNo = Request.Params["LotNo"]; //get parameter from url
            gc.HandlerNo = Request.Params["MCNo"]; //get parameter from url
            gc.MoveLotReason = tbReason.Value;


            //######################## number 1 ######################################
            if (select1.SelectedIndex == 1)
            {
                gc.Bfb1 = "YES";

                if (tbR1.Value == "")
                {
                    gc.Bfb1_TgBefore = 0;
                }
                else
                {
                    gc.Bfb1_TgBefore = Int32.Parse(tbR1.Value);
                }
            }
            else if (select1.SelectedIndex == 2)
            {
                gc.Bfb1 = "NO";
            }



            //####################### number 2 #######################################
            if (select2.SelectedIndex == 1)
            {
                gc.Bfb2 = "YES";


                if (tbR2A1.Value == "")
                {
                    gc.Bfb2_Good = 0;
                }
                else
                {
                    gc.Bfb2_Good = Int32.Parse(tbR2A1.Value);
                }

                if (tbR2A2.Value == "")
                {
                    gc.Bfb2_StdReel = 0;
                }
                else
                {
                    gc.Bfb2_StdReel = Int32.Parse(tbR2A2.Value);
                }

                if (tbR2A3.Value == "")
                {
                    gc.Bfb2_HasuuReel = 0;
                }
                else
                {
                    gc.Bfb2_HasuuReel = Int32.Parse(tbR2A3.Value);
                }
            }
            else if (select2.SelectedIndex == 2)
            {
                gc.Bfb2 = "NO";
            }



            //####################### number 3 ########################################
            if (select3.SelectedIndex == 1)
            {
                gc.Bfb3 = "YES";

                if (tbR3A1.Value == "")
                {
                    gc.Bfb3_QTy = 0;
                }
                else
                {
                    gc.Bfb3_QTy = Int32.Parse(tbR3A1.Value);
                }

                if (tbR3A2.Value == "")
                {
                    gc.Bfb3_Unit = 0;
                }
                else
                {
                    gc.Bfb3_Unit = Int32.Parse(tbR3A2.Value);
                }

                if (tbR3A3.Value == "")
                {
                    gc.Bfb3_Result = 0;
                }
                else
                {
                    gc.Bfb3_Result = Int32.Parse(tbR3A3.Value);
                }


            }
            else if (select3.SelectedIndex == 2)
            {
                gc.Bfb3 = "NO";
            }





            //########################### number 4 ######################################
            if (select4.SelectedIndex == 1)
            {
                gc.Bfb4 = "YES";

                if (tbR4.Value == "")
                {
                    gc.Bfb4_OS = 0;
                }
                else
                {
                    gc.Bfb4_OS = Int32.Parse(tbR4.Value);
                }
            }
            else if (select4.SelectedIndex == 2)
            {
                gc.Bfb4 = "NO";
            }



            //########################## number 5 #####################################
            if (select5.SelectedIndex == 1)
            {
                gc.Bfb5 = "YES";

                if (tbR5.Value == "")
                {
                    gc.Bfb5_FT = 0;
                }
                else
                {
                    gc.Bfb5_FT = Int32.Parse(tbR5.Value);
                }
            }
            else if (select5.SelectedIndex == 2)
            {
                gc.Bfb5 = "NO";
            }




            //########################## number 6 #####################################
            if (select6.SelectedIndex == 1)
            {
                gc.Bfb6 = "YES";

                if (tbR6.Value == "")
                {
                    gc.Bfb6_Make = 0;
                }
                else
                {
                    gc.Bfb6_Make = Int32.Parse(tbR6.Value);
                }
            }
            else if (select6.SelectedIndex == 2)
            {
                gc.Bfb6 = "NO";
            }



            //########################## number 7 #####################################
            if (select7.SelectedIndex == 1)
            {
                gc.Bfb7 = "YES";

                if (tbR7.Value == "")
                {
                    gc.Bfb7_Marker = 0;
                }
                else
                {
                    gc.Bfb7_Marker = Int32.Parse(tbR7.Value);
                }
            }
            else if (select7.SelectedIndex == 2)
            {
                gc.Bfb7 = "NO";
            }




            //########################## number 8 #####################################
            if (select8.SelectedIndex == 1)
            {
                gc.Bfb8 = "YES";

                if (tbR8.Value == "")
                {
                    gc.Bfb8_TP = 0;
                }
                else
                {
                    gc.Bfb8_TP = Int32.Parse(tbR8.Value);
                }
            }
            else if (select8.SelectedIndex == 2)
            {
                gc.Bfb8 = "NO";
            }




            //########################## number 9 #####################################
            if (select9.SelectedIndex == 1)
            {
                gc.Bfb9 = "YES";

                if (tbR9.Value == "")
                {
                    gc.Bfb9_Missing = 0;
                }
                else
                {
                    gc.Bfb9_Missing = Int32.Parse(tbR9.Value);
                }
            }
            else if (select9.SelectedIndex == 2)
            {
                gc.Bfb9 = "NO";
            }




            //########################## number 10 #####################################
            if (select10.SelectedIndex == 1)
            {
                gc.Bfb10 = "YES";
            }
            else if (select10.SelectedIndex == 2)
            {
                gc.Bfb10 = "NO";
            }


            //############################ total ###################################
            if (tbTotal.Value == "")
            {
                gc.BfbTotal = 0;
            }
            else
            {
                gc.BfbTotal = Int32.Parse(tbTotal.Value);
            }

        }


        protected void btnConfirm_ServerClick(object sender, EventArgs e)
        {
            SetValue();

            dba.MoveLotS2(gc.HandlerNo, gc.DeviceName, gc.LotNo, gc.MoveLotReason, gc.RequestMoveDate,
                gc.Bfb1, gc.Bfb1_TgBefore,
                gc.Bfb2, gc.Bfb2_Good, gc.Bfb2_StdReel, gc.Bfb2_HasuuReel, gc.Bfb3, gc.Bfb3_QTy, gc.Bfb3_Unit, gc.Bfb3_Result,
                gc.Bfb4, gc.Bfb4_OS, gc.Bfb5, gc.Bfb5_FT, gc.Bfb6, gc.Bfb6_Make, gc.Bfb7, gc.Bfb7_Marker, gc.Bfb8, gc.Bfb8_TP,
                gc.Bfb9, gc.Bfb9_Missing, gc.Bfb10, gc.BfbTotal, gc.GL_ID, gc.GL_Sign, gc.GL_SignDate);


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