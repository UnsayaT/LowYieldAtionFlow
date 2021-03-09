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
    public partial class _Default : Page
    {
        DBAccess dba = new DBAccess();
        GlobalClass gc = new GlobalClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSubmitLogin_ServerClick(object sender, EventArgs e)
        {
            var tbl = new DataTable();
            tbl = dba.LoginDefault(tbUserID.Value);


            if (tbl.Rows.Count == 0) 
            {
                //Message Box
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User not found ! \\nMay be input UserID wrong or UserID not regist in system.')", true);
            }
            else
            {
                string strUrl;
                string userId = tbUserID.Value;
                
                foreach (DataRow row in tbl.Rows)
                {
                    if (row["role_id"].ToString() == "8")
                    {
                        //OP
                        strUrl = "~/PageMonitoring_OP.aspx?userId=" + userId;
                        Response.Redirect(strUrl);
                    }
                    else if (row["role_id"].ToString() == "16")
                    {
                        //GL
                        strUrl = "~/PageMonitoring_GL.aspx?userId=" + userId;
                        Response.Redirect(strUrl);
                    }
                    else if (row["role_id"].ToString() == "26")
                    {
                        //PDMGR
                        strUrl = "~/PageMonitoring_PDMgr.aspx?userId=" + userId;
                        Response.Redirect(strUrl);
                    }
                    else if (row["role_id"].ToString() == "37" || row["role_id"].ToString() == "39")
                    {
                        //QYI
                        strUrl = "~/PageMonitoring_QYI.aspx?userId=" + userId;
                        Response.Redirect(strUrl);
                    }
                    else if (row["role_id"].ToString() == "34" || row["role_id"].ToString() == "104")
                    {
                        //QC
                        strUrl = "~/PageMonitoring_QC.aspx?userId=" + userId;
                        Response.Redirect(strUrl);
                    }
                    else if (row["role_id"].ToString() == "38")
                    {
                        //QC
                        strUrl = "~/PageMonitoring_BM.aspx?userId=" + userId;
                        Response.Redirect(strUrl);
                    }

                }
                
            }
        }

    }
}