using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LowYieldCheckSheet
{
    public partial class HistoryDailyPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SelectToday();
            }
        }


        public void SelectToday()
        {
            DateTime nowDate = DateTime.Today.AddHours(8).AddMinutes(00);
            DateTime nextDate = DateTime.Today.AddDays(1).AddHours(7).AddMinutes(59).AddSeconds(59);

            nowDate.ToString("yyyy-MM-dd HH:mm");
            nextDate.ToString("yyyy-MM-dd HH:mm");

            string strSQL = "SELECT [Process], [HandlerNo], [LotNo], [PackageName], [DeviceName], [RequestDate], [RequestType], [Flow]," +
                " [InitialYield], [ControlYield], [FinalYield], [ControlLCL], [CheckLowYieldKanban], [Cause] ,[CheckAlarmBin],[Mode] FROM [LowYieldActionHistory]" +
                "WHERE RequestDate BETWEEN '" + nowDate + "' AND '" + nextDate + "' ORDER BY RequestDate DESC";

            SqlDataSource1.SelectCommand = strSQL;
            SearchDate.Value = nowDate.ToString();
            GridView1.DataBind();
        }


        public object GetYield(string RequestType, object InitialYield, object FinalYield)
        //I can't convert object float value from Database then use Object 
        //But the result is same same (Hell Yeah)
        {
            object re;

            if (RequestType == "INITIAL")
            {
                re = InitialYield;
            }

            else //if(RequestType == "FINAL")
            {
                re = FinalYield;
            }

            return re;
        }

        public string getCause(object CheckLowYieldKanban, object Cause)
        {
            string re = "";
            string ck = CheckLowYieldKanban.ToString();
            string cc = Cause.ToString();

            if (!string.IsNullOrEmpty(ck) && ck != "NO")
            {
                re = ck;
            }
            else
            {
                re = cc;
            }

            return re;
        }
        //Add 2019-03-01
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
        //End Add 2019-03-01
        protected void btnSearch_ServerClick(object sender, EventArgs e)
        {
            string strSQL;

            string process="%";
            string mcno = "%";

            DateTime date1 = DateTime.Today.AddHours(8).AddMinutes(00);
            DateTime date2 = date1.AddDays(+1).AddHours(7).AddMinutes(59).AddSeconds(59);


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

            if (tbMCNo.Value != "")
            {
                mcno = "%" + tbMCNo.Value + "%";
            }

            if (SearchDate.Value != "")
            {
                date1 = Convert.ToDateTime(SearchDate.Value);
                date1 = date1.AddHours(8).AddMinutes(00);
                date2 = date1.AddDays(+1).AddSeconds(-1);
            }


            strSQL = "SELECT [Process], [HandlerNo], [LotNo], [PackageName], [DeviceName], [RequestDate], [RequestType], [Flow]," +
                " [InitialYield], [ControlYield], [FinalYield], [ControlLCL], [CheckLowYieldKanban], [Cause],[CheckAlarmBin],[Mode] FROM [LowYieldActionHistory]" +
                "WHERE Process LIKE '" + process + "' AND HandlerNo LIKE '" + mcno + "' AND RequestDate BETWEEN '" + date1 + "' AND '" + date2 + "' " +
                "ORDER BY RequestDate DESC";

            SqlDataSource1.SelectCommand = strSQL;
            GridView1.DataBind();

        }



        protected void btnBack_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("PageMonitoring.aspx");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewSheet")
            {
                string str = Convert.ToString(e.CommandArgument);
                string[] splitSTR = str.Split(',');
                string Process = splitSTR[0];
                string MCNo = splitSTR[1];
                string LotNo = splitSTR[2];
                //Response.Redirect("~/HistoryDataSheet.aspx?Process=" + Process + "&MCNo=" + MCNo + "&LotNo=" + LotNo);
                Response.Redirect("~/PortalPdfPage.aspx?Process=" + Process + "&MCNo=" + MCNo + "&LotNo=" + LotNo + "&Page=" + "HDP" + "&ViewType=" + "HIST_SHEET");
            }

            else if (e.CommandName == "ViewMoveLot")
            {
                string str = Convert.ToString(e.CommandArgument);
                string[] splitSTR = str.Split(',');
                string Process = splitSTR[0];
                string MCNo = splitSTR[1];
                string LotNo = splitSTR[2];
                //Response.Redirect("~/HistoryDataSheet.aspx?Process=" + Process + "&MCNo=" + MCNo + "&LotNo=" + LotNo);
                Response.Redirect("~/PortalPdfPage.aspx?Process=" + Process + "&MCNo=" + MCNo + "&LotNo=" + LotNo + "&Page=" + "HDP" + "&ViewType=" + "HIST_MOVELOT");
            }
        }


    }
}