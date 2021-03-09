using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace LowYieldCheckSheet
{
    public class DBAccess
    {


        public DataTable PullByMCNoAndLotNo(string Process, string MCNo, string LotNo)
        {
            var tbl = new DataTable();
            string strSQL = "SELECT *,CONVERT(varchar, RequestDate, 111) As IssueDate FROM dbo.LowYieldActionReport WHERE Process = @Process AND HandlerNo = @MCNo AND LotNo = @LotNo";
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.DBxConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(strSQL, con))
                {
                    cmd.Parameters.AddWithValue("@Process", Process);
                    cmd.Parameters.AddWithValue("@MCNo", MCNo);
                    cmd.Parameters.AddWithValue("@LotNo", LotNo);
                    con.Open();
                    tbl.Load(cmd.ExecuteReader());
                    con.Close();
                }
            }
            return tbl;

            
        }

        public DataTable PullLotNo(string LotNo)
        {
            var tblpro = new DataTable();
            string strSQLPro = "SELECT  FORWADING_BUNRUI,TP_RANK_1,THROW_RANK_1,THROW_RANK_2,THROW_RANK_3,THROW_RANK_5 FROM [APCSDB].[dbo].[LCQW_UNION_WORK_DENPYO_PRINT] WHERE LOT_NO_1 = @LotNo";
            using (SqlConnection APCScon = new SqlConnection(Properties.Settings.Default.ApcsProConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(strSQLPro, APCScon))
                {
                    cmd.Parameters.AddWithValue("@LotNo", LotNo);
                    APCScon.Open();
                    tblpro.Load(cmd.ExecuteReader());
                    APCScon.Close();
                }
            }
            return tblpro;
        }

        //Add 2020-08-28
        public DataTable CheckPackage(string Package)
        {
            var tblPackage = new DataTable();
            string strSQLPackage = "SELECT * FROM [DBx].[dbo].[BMPackage] WHERE PMID='11' AND Description = @Package";
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.DBxConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(strSQLPackage, con))
                {
                    cmd.Parameters.AddWithValue("@Package", Package);
                    con.Open();
                    tblPackage.Load(cmd.ExecuteReader());
                    con.Close();
                }
            }
            return tblPackage;
        }
        public DataTable CheckRunIssueNo(string IssueNo)
        {
            var tblRunIssueNo = new DataTable();
            string strSQLRunIssueNo = "SELECT IssueNo,SUBSTRING(IssueNo, 6, 4) AS MyYYYY,SUBSTRING(IssueNo, 11, 2) AS MyMM,SUBSTRING(IssueNo, 14, 4) AS MyNumber FROM [DBx].[dbo].[LowYieldActionReport] WHERE IssueNo IS NOT NULL And IssueNo like @IssueNo UNION  SELECT IssueNo,SUBSTRING(IssueNo, 6, 4) AS MyYYYY,SUBSTRING(IssueNo, 11, 2) AS MyMM,SUBSTRING(IssueNo, 14, 4) AS MyNumber FROM [DBx].[dbo].[LowYieldActionHistory] WHERE IssueNo IS NOT NULL And IssueNo like @IssueNo ORDER BY IssueNo ASC";
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.DBxConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(strSQLRunIssueNo, con))
                {
                    cmd.Parameters.AddWithValue("@IssueNo","%" + IssueNo + "%");
                    con.Open();
                    tblRunIssueNo.Load(cmd.ExecuteReader());
                    con.Close();
                }
            }
            return tblRunIssueNo;
        }

       
        public DataTable PullLotNoWafer(string LotNo)
        {
            var tblpro1 = new DataTable();
            string strSQLPro1 = "SELECT  WF_NO_START_1,WF_NO_END_1,RUN_NO FROM [APCSDB].[dbo].[LCQW_STOCK_OUT_DETAILS_PRINT] WHERE LOT_NO = @LotNo";
            using (SqlConnection conPro = new SqlConnection("Data Source = 172.16.0.102; Initial Catalog = APCSDB; Persist Security Info = True; User ID = System; Password = p@$$w0rd"))
            {
                using (SqlCommand cmd = new SqlCommand(strSQLPro1, conPro))
                {
                    cmd.Parameters.AddWithValue("@LotNo", LotNo);
                    conPro.Open();
                    tblpro1.Load(cmd.ExecuteReader());
                    conPro.Close();
                }
            }
            return tblpro1;
        }


        //Add 2021-01-25 
        public DataTable CheckDataBM(string bmid)
        {
            var tblbm = new DataTable();
            string strSQLbm = " SELECT NGDescription,ConchkPro,BMUnitID,ChkLimitHi,ChkLimitLo FROM [DBx].[dbo].[BMTEDetail],[DBx].[dbo].[BMMaintenance] WHERE ID=BM_ID  AND ID = @bmid";
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.DBxConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(strSQLbm, con))
                {
                    cmd.Parameters.AddWithValue("@bmid", bmid);
                    con.Open();
                    tblbm.Load(cmd.ExecuteReader());
                    con.Close();
                }
            }
            return tblbm;
        }

        public DataTable PullHistory(string Process, string MCNo, string LotNo)
        {
            var tbl = new DataTable();
            string strSQL = "SELECT *,CONVERT(varchar, RequestDate, 111) As IssueDate FROM dbo.LowYieldActionHistory WHERE Process = @Process AND HandlerNo = @MCNo AND LotNo = @LotNo";
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.DBxConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(strSQL, con))
                {
                    cmd.Parameters.AddWithValue("@Process", Process);
                    cmd.Parameters.AddWithValue("@MCNo", MCNo);
                    cmd.Parameters.AddWithValue("@LotNo", LotNo);
                    con.Open();
                    tbl.Load(cmd.ExecuteReader());
                    con.Close();
                }
            }
            return tbl;
        }


        public void UpdatePageUser1(string Process, string HandlerNo, string LotNo, string Status, int AmountNG, string PackageName, string DeviceName,
                string Flow, string MNo, string TesterNo, string BoxNo, string TRank, string WaferLotNo, string WaferSheetNo, string TPRank, string Shipment, string ShipmentDate,
                int InputQuantity, string ControlYield, string InitialYield, string CheckValue, int ActionPCS, string ActionPercent,
                string S2TestNoA1, string S2TestNoA2, string S2TestNoA3, string S2TestNoA4, string S2TestNoA5,
                int S2NG_A1, int S2NG_A2, int S2NG_A3, int S2NG_A4, int S2NG_A5,
                string S2TestNoB1, string S2TestNoB2, string S2TestNoB3, string S2TestNoB4, string S2TestNoB5,
                int S2NG_B1, int S2NG_B2, int S2NG_B3, int S2NG_B4, int S2NG_B5,
                string SetupCheck, string ManaulCheck1, string Result1_1,string ManaulCheck1_2, string Result1_2,string ManaulCheck1_3,  string Result1_3, 
                string ManaulCheck2, string Result2, string ManaulCheck3, string Result3, string SocketChangeHist, string SocketChangeLastDate, string IsRestartStep3,
                string CheckLowYieldKanban,string CheckAlarmBin,string OPName1_ID, string OPName1_Sign, string OPName1_SignDate,string RequestDate,int Mode,string RequestType,
                string FinalYield,string ControlLCL,string IssueNo, string CheckSocket, string ContactNG)
        {
            string strSQL = " INSERT INTO dbo.LowYieldActionReport (Process,HandlerNo,LotNo,Status,AmountNG,PackageName,DeviceName,Flow,MNo,TesterNo,BoxNo,TRank" +
                ",WaferLotNo,WaferSheetNo,TPRank,Shipment,InputQuantity,ControlYield,InitialYield,CheckValue,ActionPCS,ActionPercent" +
                ",S2TestNoA1,S2TestNoA2,S2TestNoA3,S2TestNoA4,S2TestNoA5,S2NG_A1,S2NG_A2,S2NG_A3,S2NG_A4,S2NG_A5,S2TestNoB1,S2TestNoB2,S2TestNoB3,S2TestNoB4,S2TestNoB5" +
                ",S2NG_B1,S2NG_B2,S2NG_B3,S2NG_B4,S2NG_B5,S10TestNoA1,S10TestNoA2,S10TestNoA3,S10TestNoA4,S10TestNoA5,S10NGA1,S10NGA2,S10NGA3,S10NGA4,S10NGA5" +
                ",S10TestNoB1,S10TestNoB2,S10TestNoB3,S10TestNoB4,S10TestNoB5,S10NGB1,S10NGB2,S10NGB3,S10NGB4,S10NGB5,SetupCheck,ManaulCheck1,Result1_1,ManaulCheck1_2" +
                ",Result1_2,ManaulCheck1_3,Result1_3,ManaulCheck2,Result2,ManaulCheck3,Result3,SocketChangeHist,SocketChangeLastDate,IsRestartStep3,CheckLowYieldKanban" +
                ",CheckAlarmBin,OPName1_ID,OPName1_Sign,ShipmentDate,OPName1_SignDate,RequestDate,Mode,RequestType,FinalYield,ControlLCL,IssueNo,CheckSocket,ContactNG" +
                ")" +
                " VALUES (@Process,@HandlerNo,@LotNo,@Status,@AmountNG,@PackageName,@DeviceName,@Flow,@MNo,@TesterNo,@BoxNo,@TRank,@WaferLotNo,@WaferSheetNo,@TPRank,@Shipment,@InputQuantity" +
                ",@ControlYield,@InitialYield,@CheckValue,@ActionPCS,@ActionPercent,@S2TestNoA1,@S2TestNoA2,@S2TestNoA3,@S2TestNoA4,@S2TestNoA5,@S2NG_A1,@S2NG_A2,@S2NG_A3,@S2NG_A4,@S2NG_A5"+
                ",@S2TestNoB1,@S2TestNoB2,@S2TestNoB3,@S2TestNoB4,@S2TestNoB5,@S2NG_B1,@S2NG_B2,@S2NG_B3,@S2NG_B4,@S2NG_B5,@S2TestNoA1,@S2TestNoA2,@S2TestNoA3,@S2TestNoA4,@S2TestNoA5"+
                ",@S2NG_A1,@S2NG_A2,@S2NG_A3,@S2NG_A4,@S2NG_A5,@S2TestNoB1,@S2TestNoB2,@S2TestNoB3,@S2TestNoB4,@S2TestNoB5,@S2NG_B1,@S2NG_B2,@S2NG_B3,@S2NG_B4,@S2NG_B5,@SetupCheck, @ManaulCheck1"+
                ",@Result1_1,@ManaulCheck1_2,@Result1_2,@ManaulCheck1_3,@Result1_3,@ManaulCheck2,@Result2,@ManaulCheck3,@Result3,@SocketChangeHist,@SocketChangeLastDate,@IsRestartStep3,@CheckLowYieldKanban"+
                ",@CheckAlarmBin,@OPName1_ID,@OPName1_Sign,@ShipmentDate,@OPName1_SignDate,@RequestDate,@Mode,@RequestType,@FinalYield,@ControlLCL,@IssueNo,@CheckSocket,@ContactNG)";

            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.DBxConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(strSQL, con))
                {
                    cmd.Parameters.AddWithValue("@Process", Process);
                    cmd.Parameters.AddWithValue("@HandlerNo", HandlerNo); 
                    cmd.Parameters.AddWithValue("@LotNo", LotNo);
                    cmd.Parameters.AddWithValue("@Status", Status);
                    cmd.Parameters.AddWithValue("@AmountNG", AmountNG);
                    cmd.Parameters.AddWithValue("@PackageName", PackageName);
                    cmd.Parameters.AddWithValue("@DeviceName", DeviceName);
                    cmd.Parameters.AddWithValue("@Flow", Flow);
                    cmd.Parameters.AddWithValue("@MNo", MNo);
                    cmd.Parameters.AddWithValue("@TesterNo", TesterNo);
                    cmd.Parameters.AddWithValue("@BoxNo", BoxNo);
                    cmd.Parameters.AddWithValue("@TRank", TRank);
                    cmd.Parameters.AddWithValue("@WaferLotNo", WaferLotNo);
                    cmd.Parameters.AddWithValue("@WaferSheetNo", WaferSheetNo);
                    cmd.Parameters.AddWithValue("@TPRank", TPRank);
                    cmd.Parameters.AddWithValue("@Shipment", Shipment);
                    cmd.Parameters.AddWithValue("@InputQuantity", InputQuantity);
                    cmd.Parameters.AddWithValue("@ControlYield", ControlYield);
                    cmd.Parameters.AddWithValue("@InitialYield", InitialYield);
                    cmd.Parameters.AddWithValue("@CheckValue", CheckValue);
                    cmd.Parameters.AddWithValue("@ActionPCS", ActionPCS);
                    cmd.Parameters.AddWithValue("@ActionPercent", ActionPercent);
                    cmd.Parameters.AddWithValue("@S2TestNoA1", S2TestNoA1);
                    cmd.Parameters.AddWithValue("@S2TestNoA2", S2TestNoA2);
                    cmd.Parameters.AddWithValue("@S2TestNoA3", S2TestNoA3);
                    cmd.Parameters.AddWithValue("@S2TestNoA4", S2TestNoA4);
                    cmd.Parameters.AddWithValue("@S2TestNoA5", S2TestNoA5);
                    cmd.Parameters.AddWithValue("@S2NG_A1", S2NG_A1);
                    cmd.Parameters.AddWithValue("@S2NG_A2", S2NG_A2);
                    cmd.Parameters.AddWithValue("@S2NG_A3", S2NG_A3);
                    cmd.Parameters.AddWithValue("@S2NG_A4", S2NG_A4);
                    cmd.Parameters.AddWithValue("@S2NG_A5", S2NG_A5);
                    cmd.Parameters.AddWithValue("@S2TestNoB1", S2TestNoB1);
                    cmd.Parameters.AddWithValue("@S2TestNoB2", S2TestNoB2);
                    cmd.Parameters.AddWithValue("@S2TestNoB3", S2TestNoB3);
                    cmd.Parameters.AddWithValue("@S2TestNoB4", S2TestNoB4);
                    cmd.Parameters.AddWithValue("@S2TestNoB5", S2TestNoB5);
                    cmd.Parameters.AddWithValue("@S2NG_B1", S2NG_B1);
                    cmd.Parameters.AddWithValue("@S2NG_B2", S2NG_B2);
                    cmd.Parameters.AddWithValue("@S2NG_B3", S2NG_B3);
                    cmd.Parameters.AddWithValue("@S2NG_B4", S2NG_B4);
                    cmd.Parameters.AddWithValue("@S2NG_B5", S2NG_B5);
                    cmd.Parameters.AddWithValue("@SetupCheck", SetupCheck);
                    cmd.Parameters.AddWithValue("@ManaulCheck1", ManaulCheck1);
                    cmd.Parameters.AddWithValue("@Result1_1", Result1_1);
                    cmd.Parameters.AddWithValue("@ManaulCheck1_2", ManaulCheck1_2);
                    cmd.Parameters.AddWithValue("@Result1_2", Result1_2);
                    cmd.Parameters.AddWithValue("@ManaulCheck1_3", ManaulCheck1_3);
                    cmd.Parameters.AddWithValue("@Result1_3", Result1_3);
                    cmd.Parameters.AddWithValue("@ManaulCheck2", ManaulCheck2);
                    cmd.Parameters.AddWithValue("@Result2", Result2);
                    cmd.Parameters.AddWithValue("@ManaulCheck3", ManaulCheck3);
                    cmd.Parameters.AddWithValue("@Result3", Result3);
                    cmd.Parameters.AddWithValue("@SocketChangeHist", SocketChangeHist);
                    cmd.Parameters.AddWithValue("@SocketChangeLastDate", SocketChangeLastDate);
                    cmd.Parameters.AddWithValue("@IsRestartStep3", IsRestartStep3);
                    cmd.Parameters.AddWithValue("@CheckLowYieldKanban", CheckLowYieldKanban);
                    cmd.Parameters.AddWithValue("@CheckAlarmBin", CheckAlarmBin);
                    cmd.Parameters.AddWithValue("@OPName1_ID",OPName1_ID);
                    cmd.Parameters.AddWithValue("@OPName1_Sign", OPName1_Sign);
                    cmd.Parameters.AddWithValue("@OPName1_SignDate", OPName1_SignDate);
                    cmd.Parameters.AddWithValue("@ShipmentDate", ShipmentDate);
                    cmd.Parameters.AddWithValue("@RequestDate", RequestDate);
                    cmd.Parameters.AddWithValue("@Mode", Mode);
                    cmd.Parameters.AddWithValue("@RequestType", RequestType);
                    cmd.Parameters.AddWithValue("@FinalYield", FinalYield);
                    cmd.Parameters.AddWithValue("@ControlLCL", ControlLCL);
                    cmd.Parameters.AddWithValue("@IssueNo", IssueNo);
                    cmd.Parameters.AddWithValue("@CheckSocket", CheckSocket);
                    cmd.Parameters.AddWithValue("@ContactNG", ContactNG);


                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }


        public void UpdatePageUser2(string Process, string HandlerNo, string LotNo, string Status, string TesterChecker,
                string Setup, string LowYieldMode, string TNo1, string TNo2, string TNo3, string TNo4, string TNo5,
                string LimitLow1, string LimitLow2, string LimitLow3, string LimitLow4, string LimitLow5,
                string LimitHigh1, string LimitHigh2, string LimitHigh3, string LimitHigh4, string LimitHigh5,
                string MassProductNG1, string MassProductNG2, string MassProductNG3, string MassProductNG4, string MassProductNG5,
                string GoodSample1, string GoodSample2, string GoodSample3, string GoodSample4, string GoodSample5,
                string TesterETC1, string TesterETC2, string TesterETC3, string TesterETC4, string TesterETC5,
                string CheckRepeat1, string CheckRepeat2, string CheckRepeat3, string CheckRepeat4, string CheckRepeat5,
                string ProgramName, int UseMassProductGood, int UseMassProductNG, int ScrapAmountGood, int ScrapAmountNG,
                string Cause,string TestIncharge_ID, string TestIncharge_Sign, string TestIncharge_SignDate)
        {
            string strSQL = "UPDATE dbo.LowYieldActionReport SET Status = @Status," +
                "TesterChecker = @TesterChecker," +
                "Setup = @Setup," +
                "TNo1 = @TNo1," +
                "TNo2 = @TNo2," +
                "TNo3 = @TNo3," +
                "TNo4 = @TNo4," +
                "TNo5 = @TNo5," +
                "LimitLow1 = @LimitLow1," +
                "LimitLow2 = @LimitLow2," +
                "LimitLow3 = @LimitLow3," +
                "LimitLow4 = @LimitLow4," +
                "LimitLow5 = @LimitLow5," +
                "LimitHigh1 = @LimitHigh1," +
                "LimitHigh2 = @LimitHigh2," +
                "LimitHigh3 = @LimitHigh3," +
                "LimitHigh4 = @LimitHigh4," +
                "LimitHigh5 = @LimitHigh5," +
                "MassProductNG1 = @MassProductNG1," +
                "MassProductNG2 = @MassProductNG2," +
                "MassProductNG3 = @MassProductNG3," +
                "MassProductNG4 = @MassProductNG4," +
                "MassProductNG5 = @MassProductNG5," +
                "GoodSample1 = @GoodSample1," +
                "GoodSample2 = @GoodSample2," +
                "GoodSample3 = @GoodSample3," +
                "GoodSample4 = @GoodSample4," +
                "GoodSample5 = @GoodSample5," +
                "TesterETC1 = @TesterETC1," +
                "TesterETC2 = @TesterETC2," +
                "TesterETC3 = @TesterETC3," +
                "TesterETC4 = @TesterETC4," +
                "TesterETC5 = @TesterETC5," +
                "CheckRepeat1 = @CheckRepeat1," +
                "CheckRepeat2 = @CheckRepeat2," +
                "CheckRepeat3 = @CheckRepeat3," +
                "CheckRepeat4 = @CheckRepeat4," +
                "CheckRepeat5 = @CheckRepeat5," +
                "ProgramName = @ProgramName," +
                "UseMassProductGood = @UseMassProductGood," +
                "UseMassProductNG = @UseMassProductNG," +
                "ScrapAmountGood = @ScrapAmountGood," +
                "ScrapAmountNG = @ScrapAmountNG," +
                "Cause = @Cause," +
                "TestIncharge_ID = @TestIncharge_ID," +
                "TestIncharge_Sign = @TestIncharge_Sign," +
                "LowYieldMode =@LowYieldMode," +
                "TestIncharge_SignDate = @TestIncharge_SignDate WHERE Process = @Process AND HandlerNo = @HandlerNo AND LotNo = @LotNo";


            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.DBxConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(strSQL, con))
                {
                    cmd.Parameters.AddWithValue("@Process", Process);
                    cmd.Parameters.AddWithValue("@HandlerNo", HandlerNo);
                    cmd.Parameters.AddWithValue("@LotNo", LotNo);
                    cmd.Parameters.AddWithValue("@Status", Status);

                    cmd.Parameters.AddWithValue("@TesterChecker", TesterChecker);
                    cmd.Parameters.AddWithValue("@Setup", Setup);

                    cmd.Parameters.AddWithValue("@TNo1", TNo1);
                    cmd.Parameters.AddWithValue("@TNo2", TNo2);
                    cmd.Parameters.AddWithValue("@TNo3", TNo3);
                    cmd.Parameters.AddWithValue("@TNo4", TNo4);
                    cmd.Parameters.AddWithValue("@TNo5", TNo5);

                    cmd.Parameters.AddWithValue("@LimitLow1", LimitLow1);
                    cmd.Parameters.AddWithValue("@LimitLow2", LimitLow2);
                    cmd.Parameters.AddWithValue("@LimitLow3", LimitLow3);
                    cmd.Parameters.AddWithValue("@LimitLow4", LimitLow4);
                    cmd.Parameters.AddWithValue("@LimitLow5", LimitLow5);

                    cmd.Parameters.AddWithValue("@LimitHigh1", LimitHigh1);
                    cmd.Parameters.AddWithValue("@LimitHigh2", LimitHigh2);
                    cmd.Parameters.AddWithValue("@LimitHigh3", LimitHigh3);
                    cmd.Parameters.AddWithValue("@LimitHigh4", LimitHigh4);
                    cmd.Parameters.AddWithValue("@LimitHigh5", LimitHigh5);

                    cmd.Parameters.AddWithValue("@MassProductNG1", MassProductNG1);
                    cmd.Parameters.AddWithValue("@MassProductNG2", MassProductNG2);
                    cmd.Parameters.AddWithValue("@MassProductNG3", MassProductNG3);
                    cmd.Parameters.AddWithValue("@MassProductNG4", MassProductNG4);
                    cmd.Parameters.AddWithValue("@MassProductNG5", MassProductNG5);

                    cmd.Parameters.AddWithValue("@GoodSample1", GoodSample1);
                    cmd.Parameters.AddWithValue("@GoodSample2", GoodSample2);
                    cmd.Parameters.AddWithValue("@GoodSample3", GoodSample3);
                    cmd.Parameters.AddWithValue("@GoodSample4", GoodSample4);
                    cmd.Parameters.AddWithValue("@GoodSample5", GoodSample5);

                    cmd.Parameters.AddWithValue("@TesterETC1", TesterETC1);
                    cmd.Parameters.AddWithValue("@TesterETC2", TesterETC2);
                    cmd.Parameters.AddWithValue("@TesterETC3", TesterETC3);
                    cmd.Parameters.AddWithValue("@TesterETC4", TesterETC4);
                    cmd.Parameters.AddWithValue("@TesterETC5", TesterETC5);

                    cmd.Parameters.AddWithValue("@CheckRepeat1", CheckRepeat1);
                    cmd.Parameters.AddWithValue("@CheckRepeat2", CheckRepeat2);
                    cmd.Parameters.AddWithValue("@CheckRepeat3", CheckRepeat3);
                    cmd.Parameters.AddWithValue("@CheckRepeat4", CheckRepeat4);
                    cmd.Parameters.AddWithValue("@CheckRepeat5", CheckRepeat5);

                    cmd.Parameters.AddWithValue("@ProgramName", ProgramName);
                    cmd.Parameters.AddWithValue("@UseMassProductGood", UseMassProductGood);
                    cmd.Parameters.AddWithValue("@UseMassProductNG", UseMassProductNG);
                    cmd.Parameters.AddWithValue("@ScrapAmountGood", ScrapAmountGood);
                    cmd.Parameters.AddWithValue("@ScrapAmountNG", ScrapAmountNG);
                    cmd.Parameters.AddWithValue("@Cause", Cause);

                    cmd.Parameters.AddWithValue("@TestIncharge_ID", TestIncharge_ID);
                    cmd.Parameters.AddWithValue("@TestIncharge_Sign", TestIncharge_Sign);
                    cmd.Parameters.AddWithValue("@TestIncharge_SignDate", TestIncharge_SignDate);
                    cmd.Parameters.AddWithValue("@LowYieldMode", LowYieldMode);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }



        public void UpdatePageUser3(string Process, string HandlerNo, string LotNo, string Status,
                string S10TestNoA1, string S10TestNoA2, string S10TestNoA3, string S10TestNoA4, string S10TestNoA5,
                int S10NGA1, int S10NGA2, int S10NGA3, int S10NGA4, int S10NGA5,
                string S10TestNoB1, string S10TestNoB2, string S10TestNoB3, string S10TestNoB4, string S10TestNoB5,
                int S10NGB1, int S10NGB2, int S10NGB3, int S10NGB4, int S10NGB5, string FinalYield, string ControlLCL,
                string AsiGood, string AsiNG, string AddOn, string AndonManage, string AndonWho, string AndonManageDetail,
                string OPName2_ID ,string OPName2_Sign, string OPName2_SignDate)
        {
            string strSQL = "UPDATE dbo.LowYieldActionReport SET Status = @Status," +
                "S10TestNoA1 = @S10TestNoA1," +
                "S10TestNoA2 = @S10TestNoA2," +
                "S10TestNoA3 = @S10TestNoA3," +
                "S10TestNoA4 = @S10TestNoA4," +
                "S10TestNoA5 = @S10TestNoA5," +
                "S10NGA1 = @S10NGA1," +
                "S10NGA2 = @S10NGA2," +
                "S10NGA3 = @S10NGA3," +
                "S10NGA4 = @S10NGA4," +
                "S10NGA5 = @S10NGA5," +
                "S10TestNoB1 = @S10TestNoB1," +
                "S10TestNoB2 = @S10TestNoB2," +
                "S10TestNoB3 = @S10TestNoB3," +
                "S10TestNoB4 = @S10TestNoB4," +
                "S10TestNoB5 = @S10TestNoB5," +
                "S10NGB1 = @S10NGB1," +
                "S10NGB2 = @S10NGB2," +
                "S10NGB3 = @S10NGB3," +
                "S10NGB4 = @S10NGB4," +
                "S10NGB5 = @S10NGB5," +
                "FinalYield = @FinalYield," +
                "ControlLCL = @ControlLCL," +
                "AsiGood = @AsiGood," +
                "AsiNG = @AsiNG," +
                "AddOn = @AddOn," +
                "AndonManage = @AndonManage," +
                "AndonWho = @AndonWho," +
                "AndonManageDetail = @AndonManageDetail," +
                "OPName2_ID = @OPName2_ID," +
                "OPName2_Sign = @OPName2_Sign," +
                "OPName2_SignDate = @OPName2_SignDate WHERE Process = @Process AND HandlerNo = @HandlerNo AND LotNo = @LotNo";


            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.DBxConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(strSQL, con))
                {
                    cmd.Parameters.AddWithValue("@Process", Process);
                    cmd.Parameters.AddWithValue("@HandlerNo", HandlerNo);
                    cmd.Parameters.AddWithValue("@LotNo", LotNo);
                    cmd.Parameters.AddWithValue("@Status", Status);
                    cmd.Parameters.AddWithValue("@S10TestNoA1", S10TestNoA1);
                    cmd.Parameters.AddWithValue("@S10TestNoA2", S10TestNoA2);
                    cmd.Parameters.AddWithValue("@S10TestNoA3", S10TestNoA3);
                    cmd.Parameters.AddWithValue("@S10TestNoA4", S10TestNoA4);
                    cmd.Parameters.AddWithValue("@S10TestNoA5", S10TestNoA5);
                    cmd.Parameters.AddWithValue("@S10NGA1", S10NGA1);
                    cmd.Parameters.AddWithValue("@S10NGA2", S10NGA2);
                    cmd.Parameters.AddWithValue("@S10NGA3", S10NGA3);
                    cmd.Parameters.AddWithValue("@S10NGA4", S10NGA4);
                    cmd.Parameters.AddWithValue("@S10NGA5", S10NGA5);
                    cmd.Parameters.AddWithValue("@S10TestNoB1", S10TestNoB1);
                    cmd.Parameters.AddWithValue("@S10TestNoB2", S10TestNoB2);
                    cmd.Parameters.AddWithValue("@S10TestNoB3", S10TestNoB3);
                    cmd.Parameters.AddWithValue("@S10TestNoB4", S10TestNoB4);
                    cmd.Parameters.AddWithValue("@S10TestNoB5", S10TestNoB5);
                    cmd.Parameters.AddWithValue("@S10NGB1", S10NGB1);
                    cmd.Parameters.AddWithValue("@S10NGB2", S10NGB2);
                    cmd.Parameters.AddWithValue("@S10NGB3", S10NGB3);
                    cmd.Parameters.AddWithValue("@S10NGB4", S10NGB4);
                    cmd.Parameters.AddWithValue("@S10NGB5", S10NGB5);
                    cmd.Parameters.AddWithValue("@FinalYield", FinalYield);
                    cmd.Parameters.AddWithValue("@ControlLCL", ControlLCL);
                    cmd.Parameters.AddWithValue("@AsiGood", AsiGood);
                    cmd.Parameters.AddWithValue("@AsiNG", AsiNG);
                    cmd.Parameters.AddWithValue("@AddOn", AddOn);
                    cmd.Parameters.AddWithValue("@AndonManage", AndonManage);
                    cmd.Parameters.AddWithValue("@AndonWho", AndonWho);
                    cmd.Parameters.AddWithValue("@AndonManageDetail", AndonManageDetail);

                    cmd.Parameters.AddWithValue("@OPName2_ID", OPName2_ID);
                    cmd.Parameters.AddWithValue("@OPName2_Sign", OPName2_Sign);
                    cmd.Parameters.AddWithValue("@OPName2_SignDate", OPName2_SignDate);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }


        public void UpdatePageUser4(string Process, string HandlerNo, string LotNo, string Status,
                string S10TestNoA1, string S10TestNoA2, string S10TestNoA3, string S10TestNoA4, string S10TestNoA5,
                int S10NGA1, int S10NGA2, int S10NGA3, int S10NGA4, int S10NGA5,
                string S10TestNoB1, string S10TestNoB2, string S10TestNoB3, string S10TestNoB4, string S10TestNoB5,
                int S10NGB1, int S10NGB2, int S10NGB3, int S10NGB4, int S10NGB5, string FinalYield, string ControlLCL,
                string AsiGood, string AsiNG, string AddOn, string AndonManage, string AndonWho, string AndonManageDetail,
                string RequestAQIS15, string StopShipObjDevice, string StopLabel, string JudgementResult, string FTRetestGood, string FTRetestNG, string ObjectScope,
                string StopRecallShipment, string StopShipmentPKG, string Assy,
                string GL_ID,string GL_Sign, string GL_SignDate)
        {
            string strSQL = "UPDATE dbo.LowYieldActionReport SET Status = @Status," +
                "S10TestNoA1 = @S10TestNoA1," +
                "S10TestNoA2 = @S10TestNoA2," +
                "S10TestNoA3 = @S10TestNoA3," +
                "S10TestNoA4 = @S10TestNoA4," +
                "S10TestNoA5 = @S10TestNoA5," +
                "S10NGA1 = @S10NGA1," +
                "S10NGA2 = @S10NGA2," +
                "S10NGA3 = @S10NGA3," +
                "S10NGA4 = @S10NGA4," +
                "S10NGA5 = @S10NGA5," +
                "S10TestNoB1 = @S10TestNoB1," +
                "S10TestNoB2 = @S10TestNoB2," +
                "S10TestNoB3 = @S10TestNoB3," +
                "S10TestNoB4 = @S10TestNoB4," +
                "S10TestNoB5 = @S10TestNoB5," +
                "S10NGB1 = @S10NGB1," +
                "S10NGB2 = @S10NGB2," +
                "S10NGB3 = @S10NGB3," +
                "S10NGB4 = @S10NGB4," +
                "S10NGB5 = @S10NGB5," +
                "FinalYield = @FinalYield," +
                "ControlLCL = @ControlLCL," +
                "AsiGood = @AsiGood," +
                "AsiNG = @AsiNG," +
                "AddOn = @AddOn," +
                "AndonManage = @AndonManage," +
                "AndonWho = @AndonWho," +
                "AndonManageDetail = @AndonManageDetail," +
                "RequestAQIS15 = @RequestAQIS15," +
                "StopShipObjDevice = @StopShipObjDevice," +
                "StopLabel = @StopLabel,"+
                "FTRetestGood = @FTRetestGood," +
                "FTRetestNG = @FTRetestNG," +
                "ObjectScope = @ObjectScope," +
                "StopRecallShipment = @StopRecallShipment," +
                "StopShipmentPKG = @StopShipmentPKG," +
                "Assy = @Assy," +
                "GL_ID = @GL_ID," +
                "GL_Sign = @GL_Sign," +
                "GL_SignDate = @GL_SignDate WHERE Process = @Process AND HandlerNo = @HandlerNo AND LotNo = @LotNo";


            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.DBxConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(strSQL, con))
                {
                    cmd.Parameters.AddWithValue("@Process", Process);
                    cmd.Parameters.AddWithValue("@HandlerNo", HandlerNo);
                    cmd.Parameters.AddWithValue("@LotNo", LotNo);
                    cmd.Parameters.AddWithValue("@Status", Status);
                    cmd.Parameters.AddWithValue("@S10TestNoA1", S10TestNoA1);
                    cmd.Parameters.AddWithValue("@S10TestNoA2", S10TestNoA2);
                    cmd.Parameters.AddWithValue("@S10TestNoA3", S10TestNoA3);
                    cmd.Parameters.AddWithValue("@S10TestNoA4", S10TestNoA4);
                    cmd.Parameters.AddWithValue("@S10TestNoA5", S10TestNoA5);
                    cmd.Parameters.AddWithValue("@S10NGA1", S10NGA1);
                    cmd.Parameters.AddWithValue("@S10NGA2", S10NGA2);
                    cmd.Parameters.AddWithValue("@S10NGA3", S10NGA3);
                    cmd.Parameters.AddWithValue("@S10NGA4", S10NGA4);
                    cmd.Parameters.AddWithValue("@S10NGA5", S10NGA5);
                    cmd.Parameters.AddWithValue("@S10TestNoB1", S10TestNoB1);
                    cmd.Parameters.AddWithValue("@S10TestNoB2", S10TestNoB2);
                    cmd.Parameters.AddWithValue("@S10TestNoB3", S10TestNoB3);
                    cmd.Parameters.AddWithValue("@S10TestNoB4", S10TestNoB4);
                    cmd.Parameters.AddWithValue("@S10TestNoB5", S10TestNoB5);
                    cmd.Parameters.AddWithValue("@S10NGB1", S10NGB1);
                    cmd.Parameters.AddWithValue("@S10NGB2", S10NGB2);
                    cmd.Parameters.AddWithValue("@S10NGB3", S10NGB3);
                    cmd.Parameters.AddWithValue("@S10NGB4", S10NGB4);
                    cmd.Parameters.AddWithValue("@S10NGB5", S10NGB5);
                    cmd.Parameters.AddWithValue("@FinalYield", FinalYield);
                    cmd.Parameters.AddWithValue("@ControlLCL", ControlLCL);
                    cmd.Parameters.AddWithValue("@AsiGood", AsiGood);
                    cmd.Parameters.AddWithValue("@AsiNG", AsiNG);
                    cmd.Parameters.AddWithValue("@AddOn", AddOn);
                    cmd.Parameters.AddWithValue("@AndonManage", AndonManage);
                    cmd.Parameters.AddWithValue("@AndonWho", AndonWho);
                    cmd.Parameters.AddWithValue("@AndonManageDetail", AndonManageDetail);
                    cmd.Parameters.AddWithValue("@RequestAQIS15", RequestAQIS15);
                    cmd.Parameters.AddWithValue("@StopShipObjDevice", StopShipObjDevice);
                    cmd.Parameters.AddWithValue("@StopLabel", StopLabel);
                    cmd.Parameters.AddWithValue("@JudgementResult", JudgementResult);
                    cmd.Parameters.AddWithValue("@FTRetestGood", FTRetestGood);
                    cmd.Parameters.AddWithValue("@FTRetestNG", FTRetestNG);
                    cmd.Parameters.AddWithValue("@ObjectScope", ObjectScope);
                    cmd.Parameters.AddWithValue("@StopRecallShipment", StopRecallShipment);
                    cmd.Parameters.AddWithValue("@StopShipmentPKG", StopShipmentPKG);
                    cmd.Parameters.AddWithValue("@Assy", Assy);

                    cmd.Parameters.AddWithValue("@GL_ID", GL_ID);
                    cmd.Parameters.AddWithValue("@GL_Sign", GL_Sign);
                    cmd.Parameters.AddWithValue("@GL_SignDate", GL_SignDate);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }




        public void UpdatePageUser5(string Process, string HandlerNo, string LotNo, string Status, int TestTotalAmount, int TestResultGood, int TestResultNG, string RequestAQIS13,
                string StopNextLotS13, string KanbanCtrlNo, string KanbanTestNo, string KanbanExpireDate, string ResultBurnGood, string ResultBurnNG, string ResultChipCrackGood,
                string ResultChipCrackNG, int ResultChipMixGood, int ResultChipMixNG, string RequestAQIS14, string StopNextLotS14, string StopPKGS14,
                string RequestAQIS15, string StopShipObjDevice, string StopLabel, string JudgementResult, string FTRetestGood, string FTRetestNG, string ObjectScope,
                string StopRecallShipment, string StopShipmentPKG, string Assy, string SelectS16,
                string AnalysisIncharge_ID, string AnalysisIncharge_Sign, string AnalysisIncharge_SignDate, string FYIFQIIncharge_ID, string FYIFQIIncharge_Sign, string FYIFQIIncharge_SignDate)
        {
            string strSQL = "UPDATE dbo.LowYieldActionReport SET Status = @Status," +
               "TestTotalAmount = @TestTotalAmount," +
               "TestResultGood = @TestResultGood," +
               "TestResultNG = @TestResultNG," +
               "RequestAQIS13 = @RequestAQIS13," +
               "StopNextLotS13 = @StopNextLotS13," +
               "KanbanCtrlNo = @KanbanCtrlNo," +
               "KanbanTestNo = @KanbanTestNo," +
               "KanbanExpireDate = @KanbanExpireDate," +
               "ResultBurnGood = @ResultBurnGood," +
               "ResultBurnNG = @ResultBurnNG," +
               "ResultChipCrackGood = @ResultChipCrackGood," +
               "ResultChipCrackNG = @ResultChipCrackNG," +
               "ResultChipMixGood = @ResultChipMixGood," +
               "ResultChipMixNG = @ResultChipMixNG," +
               "RequestAQIS14 = @RequestAQIS14," +
               "StopNextLotS14 = @StopNextLotS14," +
               "StopPKGS14 = @StopPKGS14," +
               "RequestAQIS15 = @RequestAQIS15," +
               "StopShipObjDevice = @StopShipObjDevice," +
               "StopLabel = @StopLabel," +
               "JudgementResult = @JudgementResult," +
               "FTRetestGood = @FTRetestGood," +
               "FTRetestNG = @FTRetestNG," +
               "ObjectScope = @ObjectScope," +
               "StopRecallShipment = @StopRecallShipment," +
               "StopShipmentPKG = @StopShipmentPKG," +
               "Assy = @Assy," +
               "SelectS16 = @SelectS16," +
               "AnalysisIncharge_ID = @AnalysisIncharge_ID," +
               "AnalysisIncharge_Sign = @AnalysisIncharge_Sign," +
               "AnalysisIncharge_SignDate = @AnalysisIncharge_SignDate,"+
               "FYIFQIIncharge_ID = @FYIFQIIncharge_ID," +
               "FYIFQIIncharge_Sign = @FYIFQIIncharge_Sign," +
               "FYIFQIIncharge_SignDate = @FYIFQIIncharge_SignDate WHERE Process = @Process AND HandlerNo = @HandlerNo AND LotNo = @LotNo";

            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.DBxConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(strSQL, con))
                {
                    cmd.Parameters.AddWithValue("@Process", Process);
                    cmd.Parameters.AddWithValue("@HandlerNo", HandlerNo);
                    cmd.Parameters.AddWithValue("@LotNo", LotNo);
                    cmd.Parameters.AddWithValue("@Status", Status);
                    cmd.Parameters.AddWithValue("@TestTotalAmount", TestTotalAmount);
                    cmd.Parameters.AddWithValue("@TestResultGood", TestResultGood);
                    cmd.Parameters.AddWithValue("@TestResultNG", TestResultNG);
                    cmd.Parameters.AddWithValue("@RequestAQIS13", RequestAQIS13);
                    cmd.Parameters.AddWithValue("@StopNextLotS13", StopNextLotS13);
                    cmd.Parameters.AddWithValue("@KanbanCtrlNo", KanbanCtrlNo);
                    cmd.Parameters.AddWithValue("@KanbanTestNo", KanbanTestNo);
                    cmd.Parameters.AddWithValue("@KanbanExpireDate", KanbanExpireDate);
                    cmd.Parameters.AddWithValue("@ResultBurnGood", ResultBurnGood);
                    cmd.Parameters.AddWithValue("@ResultBurnNG", ResultBurnNG);
                    cmd.Parameters.AddWithValue("@ResultChipCrackGood", ResultChipCrackGood);
                    cmd.Parameters.AddWithValue("@ResultChipCrackNG", ResultChipCrackNG);
                    cmd.Parameters.AddWithValue("@ResultChipMixGood", ResultChipMixGood);
                    cmd.Parameters.AddWithValue("@ResultChipMixNG", ResultChipMixNG);
                    cmd.Parameters.AddWithValue("@RequestAQIS14", RequestAQIS14);
                    cmd.Parameters.AddWithValue("@StopNextLotS14", StopNextLotS14);
                    cmd.Parameters.AddWithValue("@StopPKGS14", StopPKGS14);
                    cmd.Parameters.AddWithValue("@RequestAQIS15", RequestAQIS15);
                    cmd.Parameters.AddWithValue("@StopShipObjDevice", StopShipObjDevice);
                    cmd.Parameters.AddWithValue("@StopLabel", StopLabel);
                    cmd.Parameters.AddWithValue("@JudgementResult", JudgementResult);
                    cmd.Parameters.AddWithValue("@FTRetestGood", FTRetestGood);
                    cmd.Parameters.AddWithValue("@FTRetestNG", FTRetestNG);
                    cmd.Parameters.AddWithValue("@ObjectScope", ObjectScope);
                    cmd.Parameters.AddWithValue("@StopRecallShipment", StopRecallShipment);
                    cmd.Parameters.AddWithValue("@StopShipmentPKG", StopShipmentPKG);
                    cmd.Parameters.AddWithValue("@Assy", Assy);
                    cmd.Parameters.AddWithValue("@SelectS16", SelectS16);

                    cmd.Parameters.AddWithValue("@AnalysisIncharge_ID", AnalysisIncharge_ID);
                    cmd.Parameters.AddWithValue("@AnalysisIncharge_Sign", AnalysisIncharge_Sign);
                    cmd.Parameters.AddWithValue("@AnalysisIncharge_SignDate", AnalysisIncharge_SignDate);

                    cmd.Parameters.AddWithValue("@FYIFQIIncharge_ID", FYIFQIIncharge_ID);
                    cmd.Parameters.AddWithValue("@FYIFQIIncharge_Sign", FYIFQIIncharge_Sign);
                    cmd.Parameters.AddWithValue("@FYIFQIIncharge_SignDate", FYIFQIIncharge_SignDate);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }


        public void UpdatePageUser6(string Process, string HandlerNo, string LotNo, string Status, string JudgementResult, string LowYieldAnalysis,
            string FYIFQIIncharge_ID, string FYIFQIIncharge_Sign, string FYIFQIIncharge_SignDate)
        {
            string strSQL = "UPDATE dbo.LowYieldActionReport SET Status = @Status," +
               "JudgementResult = @JudgementResult," +
               "LowYieldAnalysis = @LowYieldAnalysis," +
               "FYIFQIIncharge_ID = @FYIFQIIncharge_ID," +
               "FYIFQIIncharge_Sign = @FYIFQIIncharge_Sign," +
               "FYIFQIIncharge_SignDate = @FYIFQIIncharge_SignDate WHERE Process = @Process AND HandlerNo = @HandlerNo AND LotNo = @LotNo";

            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.DBxConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(strSQL, con))
                {
                    cmd.Parameters.AddWithValue("@Process", Process);
                    cmd.Parameters.AddWithValue("@HandlerNo", HandlerNo);
                    cmd.Parameters.AddWithValue("@LotNo", LotNo);
                    cmd.Parameters.AddWithValue("@Status", Status);
                    cmd.Parameters.AddWithValue("@JudgementResult", JudgementResult);
                    cmd.Parameters.AddWithValue("@LowYieldAnalysis", LowYieldAnalysis);

                    cmd.Parameters.AddWithValue("@FYIFQIIncharge_ID", FYIFQIIncharge_ID);
                    cmd.Parameters.AddWithValue("@FYIFQIIncharge_Sign", FYIFQIIncharge_Sign);
                    cmd.Parameters.AddWithValue("@FYIFQIIncharge_SignDate", FYIFQIIncharge_SignDate);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }



        public void UpdatePageUser7(string Process, string HandlerNo, string LotNo, string Status, 
            string PDMgr_ID, string PDMgr_Sign, string PDMgr_SignDate)
        {
            string strSQL = "UPDATE dbo.LowYieldActionReport SET Status = @Status," +
                "PDMgr_ID = @PDMgr_ID," +
                "PDMgr_Sign = @PDMgr_Sign," +
                "PDMgr_SignDate = @PDMgr_SignDate WHERE Process = @Process AND HandlerNo = @HandlerNo AND LotNo = @LotNo";

            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.DBxConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(strSQL, con))
                {
                    cmd.Parameters.AddWithValue("@Process", Process);
                    cmd.Parameters.AddWithValue("@HandlerNo", HandlerNo);
                    cmd.Parameters.AddWithValue("@LotNo", LotNo);
                    cmd.Parameters.AddWithValue("@Status", Status);

                    cmd.Parameters.AddWithValue("@PDMgr_ID", PDMgr_ID);
                    cmd.Parameters.AddWithValue("@PDMgr_Sign", PDMgr_Sign);
                    cmd.Parameters.AddWithValue("@PDMgr_SignDate", PDMgr_SignDate);


                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }


        public void UpdatePageUser8(string Process, string HandlerNo, string LotNo, string Status, string RequestAQIS15, string StopShipObjDevice, string StopLabel,
            string FTRetestGood, string FTRetestNG, string ObjectScope, string StopRecallShipment, string StopShipmentPKG, string Assy, string QCJudgement,
            string QCIncharge_ID,string QCIncharge_Sign, string QCIncharge_SignDate, string QCApprove_ID, string QCApprove_Sign, string QCApprove_Date)
        {
            string strSQL = "UPDATE dbo.LowYieldActionReport SET Status = @Status," +
                "RequestAQIS15 = @RequestAQIS15," +
                "StopShipObjDevice = @StopShipObjDevice," +
                "StopLabel = @StopLabel," +
                "FTRetestGood = @FTRetestGood," +
                "FTRetestNG = @FTRetestNG," +
                "ObjectScope = @ObjectScope," +
                "StopRecallShipment = @StopRecallShipment," +
                "StopShipmentPKG = @StopShipmentPKG," +
                "Assy = @Assy," +
                "QCJudgement = @QCJudgement," +
                "QCIncharge_ID = @QCIncharge_ID," +
                "QCIncharge_Sign = @QCIncharge_Sign," +
                "QCIncharge_SignDate = @QCIncharge_SignDate," +
                "QCApprove_ID = @QCApprove_ID," +
                "QCApprove_Sign = @QCApprove_Sign," +
                "QCApprove_Date = @QCApprove_Date WHERE Process = @Process AND HandlerNo = @HandlerNo AND LotNo = @LotNo";

            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.DBxConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(strSQL, con))
                {
                    cmd.Parameters.AddWithValue("@Process", Process);
                    cmd.Parameters.AddWithValue("@HandlerNo", HandlerNo);
                    cmd.Parameters.AddWithValue("@LotNo", LotNo);
                    cmd.Parameters.AddWithValue("@Status", Status);
                    cmd.Parameters.AddWithValue("@RequestAQIS15", RequestAQIS15);
                    cmd.Parameters.AddWithValue("@StopShipObjDevice", StopShipObjDevice);
                    cmd.Parameters.AddWithValue("@StopLabel", StopLabel);
                    cmd.Parameters.AddWithValue("@FTRetestGood", FTRetestGood);
                    cmd.Parameters.AddWithValue("@FTRetestNG", FTRetestNG);
                    cmd.Parameters.AddWithValue("@ObjectScope", ObjectScope);
                    cmd.Parameters.AddWithValue("@StopRecallShipment", StopRecallShipment);
                    cmd.Parameters.AddWithValue("@StopShipmentPKG", StopShipmentPKG);
                    cmd.Parameters.AddWithValue("@Assy", Assy);
                    cmd.Parameters.AddWithValue("@QCJudgement", QCJudgement);

                    cmd.Parameters.AddWithValue("@QCIncharge_ID", QCIncharge_ID);
                    cmd.Parameters.AddWithValue("@QCIncharge_Sign", QCIncharge_Sign);
                    cmd.Parameters.AddWithValue("@QCIncharge_SignDate", QCIncharge_SignDate);

                    cmd.Parameters.AddWithValue("@QCApprove_ID", QCApprove_ID);
                    cmd.Parameters.AddWithValue("@QCApprove_Sign", QCApprove_Sign);
                    cmd.Parameters.AddWithValue("@QCApprove_Date", QCApprove_Date);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }


        //Add 2020-03-12 By Unsaya
        public void UpdatePageUser9(string Process, string HandlerNo, string LotNo, string Status, string SelectS16,
            string FTRetestGood, string FTRetestNG, string ObjectScope, string StopRecallShipment, string TEIncharge_ID, string TEIncharge_Sign, string TEIncharge_SignDate)
        {
            string strSQL = "UPDATE dbo.LowYieldActionReport SET Status = @Status," +
               "SelectS16 = @SelectS16," +
               "FTRetestGood = @FTRetestGood," +
               "FTRetestNG = @FTRetestNG," +
               "ObjectScope = @ObjectScope," +
               "StopRecallShipment = @StopRecallShipment," +
               "TEIncharge_ID = @TEIncharge_ID," +
               "TEIncharge_Sign = @TEIncharge_Sign," +
               "TEIncharge_SignDate = @TEIncharge_SignDate WHERE Process = @Process AND HandlerNo = @HandlerNo AND LotNo = @LotNo";

            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.DBxConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(strSQL, con))
                {
                    cmd.Parameters.AddWithValue("@Process", Process);
                    cmd.Parameters.AddWithValue("@HandlerNo", HandlerNo);
                    cmd.Parameters.AddWithValue("@LotNo", LotNo);
                    cmd.Parameters.AddWithValue("@Status", Status);
                    cmd.Parameters.AddWithValue("@SelectS16", SelectS16);
                    cmd.Parameters.AddWithValue("@FTRetestGood", FTRetestGood);
                    cmd.Parameters.AddWithValue("@FTRetestNG", FTRetestNG);
                    cmd.Parameters.AddWithValue("@ObjectScope", ObjectScope);
                    cmd.Parameters.AddWithValue("@StopRecallShipment", StopRecallShipment);


                    cmd.Parameters.AddWithValue("@TEIncharge_ID", TEIncharge_ID);
                    cmd.Parameters.AddWithValue("@TEIncharge_Sign", TEIncharge_Sign);
                    cmd.Parameters.AddWithValue("@TEIncharge_SignDate", TEIncharge_SignDate);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        //Add 2020-10-15 By Unsaya
        public void UpdatePageUser10(string Process, string HandlerNo, string LotNo, string Status,string QCApprove_ID, string QCApprove_Sign, string QCApprove_Date)
        {
            string strSQL = "UPDATE dbo.LowYieldActionReport SET Status = @Status," +
                "QCApprove_ID = @QCApprove_ID," +
                "QCApprove_Sign = @QCApprove_Sign," +
                "QCApprove_Date = @QCApprove_Date WHERE Process = @Process AND HandlerNo = @HandlerNo AND LotNo = @LotNo";

            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.DBxConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(strSQL, con))
                {
                    cmd.Parameters.AddWithValue("@Process", Process);
                    cmd.Parameters.AddWithValue("@HandlerNo", HandlerNo);
                    cmd.Parameters.AddWithValue("@LotNo", LotNo);
                    cmd.Parameters.AddWithValue("@Status", Status);

                    cmd.Parameters.AddWithValue("@QCApprove_ID", QCApprove_ID);
                    cmd.Parameters.AddWithValue("@QCApprove_Sign", QCApprove_Sign);
                    cmd.Parameters.AddWithValue("@QCApprove_Date", QCApprove_Date);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }


        //Add 2020-06-18 By Unsaya 
        public void UpdatePageUser10(string Process, string HandlerNo, string LotNo, string Status)
        {
            string strSQL = "UPDATE dbo.LowYieldActionReport SET Status = @Status WHERE Process = @Process AND HandlerNo = @HandlerNo AND LotNo = @LotNo";

            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.DBxConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(strSQL, con))
                {
                    cmd.Parameters.AddWithValue("@Process", Process);
                    cmd.Parameters.AddWithValue("@HandlerNo", HandlerNo);
                    cmd.Parameters.AddWithValue("@LotNo", LotNo);
                    cmd.Parameters.AddWithValue("@Status", Status);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        //Add 2020-09-02 By Unsaya
        public void UpdateAmountNG(string LotNo, int AmountNG)
        {
            string strSQL = "UPDATE dbo.LowYieldActionReport SET AmountNG = @AmountNG WHERE LotNo = @LotNo";

            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.DBxConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(strSQL, con))
                {
                    cmd.Parameters.AddWithValue("@LotNo", LotNo);
                    cmd.Parameters.AddWithValue("@AmountNG", AmountNG);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }


        //this method is update only status value 
        public void UpdateStatusOnly(string Process, string MCNo, string LotNo, string Status) 
        {
            string strSQL = "UPDATE dbo.LowYieldActionReport SET Status = @Status WHERE Process = @Process AND HandlerNo = @HandlerNo AND LotNo = @LotNo";

            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.DBxConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(strSQL, con))
                {
                    cmd.Parameters.AddWithValue("@Status", Status);
                    cmd.Parameters.AddWithValue("@Process", Process);
                    cmd.Parameters.AddWithValue("@HandlerNo", MCNo);
                    cmd.Parameters.AddWithValue("@LotNo", LotNo);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }


        public void MoveLotS1(string MCNo, string DeviceName, string LotNo, string MoveLotReason, string RequestMoveDate, string Bfb1, int Bfb1_TgBefore,
            string Bfb2, int Bfb2_Good, int Bfb2_StdReel, int Bfb2_HasuuReel, string Bfb3, int Bfb3_QTy, int Bfb3_Unit, int Bfb3_Result, string Bfb4, int Bfb4_OS,
            string Bfb5, int Bfb5_FT, string Bfb6, int Bfb6_Make, string Bfb7, int Bfb7_Marker, string Bfb8, int Bfb8_TP, string Bfb9, int Bfb9_Missing,
            string Bfb10, int BfbTotal,string OP1_ID, string OP1_Sign, string OP1_SignDate)
        {
            string strSQL = "INSERT INTO [dbo].[LowYieldMoveLot] ([MCNo],[DeviceName],[LotNo],[MoveLotReason],[RequestMoveDate]" +
                        ",[Bfb1],[Bfb1_TgBefore]" +
                        ",[Bfb2],[Bfb2_Good],[Bfb2_StdReel],[Bfb2_HasuuReel]" +
                        ",[Bfb3],[Bfb3_QTy],[Bfb3_Unit],[Bfb3_Result]" +
                        ",[Bfb4],[Bfb4_OS]" +
                        ",[Bfb5],[Bfb5_FT]" +
                        ",[Bfb6],[Bfb6_Make]" +
                        ",[Bfb7],[Bfb7_Marker]" +
                        ",[Bfb8],[Bfb8_TP]" +
                        ",[Bfb9],[Bfb9_Missing]" +
                        ",[Bfb10],[BfbTotal]" +
                        ",[OP1_ID],[OP1_Sign],[OP1_SignDate]" +
                        ")" +
                        " VALUES (@MCNo,@DeviceName,@LotNo,@MoveLotReason,@RequestMoveDate" +
                        ",@Bfb1,@Bfb1_TgBefore" +
                        ",@Bfb2,@Bfb2_Good,@Bfb2_StdReel,@Bfb2_HasuuReel" +
                        ",@Bfb3,@Bfb3_QTy,@Bfb3_Unit,@Bfb3_Result" +
                        ",@Bfb4,@Bfb4_OS" +
                        ",@Bfb5,@Bfb5_FT" +
                        ",@Bfb6,@Bfb6_Make" +
                        ",@Bfb7,@Bfb7_Marker" +
                        ",@Bfb8,@Bfb8_TP" +
                        ",@Bfb9,@Bfb9_Missing" +
                        ",@Bfb10,@BfbTotal" +
                        ",@OP1_ID,@OP1_Sign,@OP1_SignDate" +
                        ")";

            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.DBxConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(strSQL, con))
                {
                    cmd.Parameters.AddWithValue("@MCNo", MCNo);
                    cmd.Parameters.AddWithValue("@DeviceName", DeviceName);
                    cmd.Parameters.AddWithValue("@LotNo", LotNo);
                    cmd.Parameters.AddWithValue("@MoveLotReason", MoveLotReason);
                    cmd.Parameters.AddWithValue("@RequestMoveDate", RequestMoveDate);

                    cmd.Parameters.AddWithValue("@Bfb1", Bfb1);
                    cmd.Parameters.AddWithValue("@Bfb1_TgBefore", Bfb1_TgBefore);
                    cmd.Parameters.AddWithValue("@Bfb2", Bfb2);
                    cmd.Parameters.AddWithValue("@Bfb2_Good", Bfb2_Good);
                    cmd.Parameters.AddWithValue("@Bfb2_StdReel", Bfb2_StdReel);
                    cmd.Parameters.AddWithValue("@Bfb2_HasuuReel", Bfb2_HasuuReel);
                    cmd.Parameters.AddWithValue("@Bfb3", Bfb3);
                    cmd.Parameters.AddWithValue("@Bfb3_QTy", Bfb3_QTy);
                    cmd.Parameters.AddWithValue("@Bfb3_Unit", Bfb3_Unit);
                    cmd.Parameters.AddWithValue("@Bfb3_Result", Bfb3_Result);
                    cmd.Parameters.AddWithValue("@Bfb4", Bfb4);
                    cmd.Parameters.AddWithValue("@Bfb4_OS", Bfb4_OS);
                    cmd.Parameters.AddWithValue("@Bfb5", Bfb5);
                    cmd.Parameters.AddWithValue("@Bfb5_FT", Bfb5_FT);
                    cmd.Parameters.AddWithValue("@Bfb6", Bfb6);
                    cmd.Parameters.AddWithValue("@Bfb6_Make", Bfb6_Make);
                    cmd.Parameters.AddWithValue("@Bfb7", Bfb7);
                    cmd.Parameters.AddWithValue("@Bfb7_Marker", Bfb7_Marker);
                    cmd.Parameters.AddWithValue("@Bfb8", Bfb8);
                    cmd.Parameters.AddWithValue("@Bfb8_TP", Bfb8_TP);
                    cmd.Parameters.AddWithValue("@Bfb9", Bfb9);
                    cmd.Parameters.AddWithValue("@Bfb9_Missing", Bfb9_Missing);
                    cmd.Parameters.AddWithValue("@Bfb10", Bfb10);
                    cmd.Parameters.AddWithValue("@BfbTotal", BfbTotal);
                    cmd.Parameters.AddWithValue("@OP1_ID", OP1_ID);
                    cmd.Parameters.AddWithValue("@OP1_Sign", OP1_Sign);
                    cmd.Parameters.AddWithValue("@OP1_SignDate", OP1_SignDate);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

        }

        internal void MoveToHistory8(string process, string handlerNo, string lotNo, string packageName, string deviceName, string requestDate, int mode, string status, string describe, string requestType, int amountNG, string flow, string mNo, string testerNo, string boxNo, string rank, string waferLotNo, string waferSheetNo, string tPRank, string shipment, int inputQuantity, string controlYield, string initialYield, string checkValue, int actionPCS, string actionPercent, string s2TestNoA1, string s2TestNoA2, string s2TestNoA3, string s2TestNoA4, string s2TestNoA5, int s2NG_A1, int s2NG_A2, int s2NG_A3, int s2NG_A4, int s2NG_A5, string s2TestNoB1, string s2TestNoB2, string s2TestNoB3, string s2TestNoB4, string s2TestNoB5, int s2NG_B1, int s2NG_B2, int s2NG_B3, int s2NG_B4, int s2NG_B5, string setupCheck, string manaulCheck1, string result1_1, string manaulCheck1_2, string result1_2, string manaulCheck1_3, string result1_3, string manaulCheck2, string result2, string manaulCheck3, string result3, string socketChangeHist, string socketChangeLastDate, string isRestartStep3, string checkLowYieldKanban, string checkAlarmBin, string testerChecker, string setup, string no1, string no2, string no3, string no4, string no5, string limitLow1, string limitLow2, string limitLow3, string limitLow4, string limitLow5, string limitHigh1, string limitHigh2, string limitHigh3, string limitHigh4, string limitHigh5, string massProductNG1, string massProductNG2, string massProductNG3, string massProductNG4, string massProductNG5, string goodSample1, string goodSample2, string goodSample3, string goodSample4, string goodSample5, string testerETC1, string testerETC2, string testerETC3, string testerETC4, string testerETC5, string checkRepeat1, string checkRepeat2, string checkRepeat3, string checkRepeat4, string checkRepeat5, string programName, int useMassProductGood, int useMassProductNG, int scrapAmountGood, int scrapAmountNG, string cause, string s10TestNoA1, string s10TestNoA2, string s10TestNoA3, string s10TestNoA4, string s10TestNoA5, int s10NGA1, int s10NGA2, int s10NGA3, int s10NGA4, int s10NGA5, string s10TestNoB1, string s10TestNoB2, string s10TestNoB3, string s10TestNoB4, string s10TestNoB5, int s10NGB1, int s10NGB2, int s10NGB3, int s10NGB4, int s10NGB5, string finalYield, string controlLCL, string asiGood, string asiNG, string addOn, string andonManage, string andonWho, string andonManageDetail, int testResultGood, int testResultNG, string requestAQIS13, string stopNextLotS13, string kanbanCtrlNo, string kanbanTestNo, string kanbanExpireDate, string resultBurnGood, string resultBurnNG, string resultChipCrackGood, string resultChipCrackNG, int resultChipMixGood, int resultChipMixNG, string requestAQIS14, string stopNextLotS14, string stopPKGS14, string requestAQIS15, string stopShipObjDevice, string stopLabel, string systemInspection, string judgementResult, string fTRetestGood, string fTRetestNG, string objectScope, string stopRecallShipment, string lowYieldAnalysis, string stopShipmentPKG, string assy, string qCJudgement, string oPName1_ID, string testIncharge_ID, string oPName2_ID, string gL_ID, string analysisIncharge_ID, string fYIFQIIncharge_ID, string pDMgr_ID, string qCIncharge_ID, string oPName1_Sign, string testIncharge_Sign, string oPName2_Sign, string gL_Sign, string analysisIncharge_Sign, string fYIFQIIncharge_Sign, string pDMgr_Sign, string qCIncharge_Sign, string oPName1_SignDate, string testIncharge_SignDate, string oPName2_SignDate, string gL_SignDate, string analysisIncharge_SignDate, string fYIFQIIncharge_SignDate, string pDMgr_SignDate, string qCIncharge_SignDate, int testtotalAmount, string selectS16, string tEIncharge_ID, string tEIncharge_Sign, string tEIncharge_SignDate, string shipmentdate, string lowYieldMode, string ControlBMNo, int BMID, object issueNo,string CheckSocket)
        {
            throw new NotImplementedException();
        }

        public void MoveLotS1Edit(string MCNo, string DeviceName, string LotNo, string MoveLotReason, string RequestMoveDate, string Bfb1, int Bfb1_TgBefore,
            string Bfb2, int Bfb2_Good, int Bfb2_StdReel, int Bfb2_HasuuReel, string Bfb3, int Bfb3_QTy, int Bfb3_Unit, int Bfb3_Result, string Bfb4, int Bfb4_OS,
            string Bfb5, int Bfb5_FT, string Bfb6, int Bfb6_Make, string Bfb7, int Bfb7_Marker, string Bfb8, int Bfb8_TP, string Bfb9, int Bfb9_Missing,
            string Bfb10, int BfbTotal,string OP1_ID, string OP1_Sign, string OP1_SignDate)
        {
            string strSQL = "UPDATE [dbo].[LowYieldMoveLot] SET [Bfb1] = @Bfb1" +
                        ",[Bfb1_TgBefore] = @Bfb1_TgBefore" +
                        ",[Bfb2] = @Bfb2" +
                        ",[Bfb2_Good] = @Bfb2_Good" +
                        ",[Bfb2_StdReel] = Bfb2_StdReel" +
                        ",[Bfb2_HasuuReel] = @Bfb2_HasuuReel" +
                        ",[Bfb3] = @Bfb3" +
                        ",[Bfb3_QTy] = @Bfb3_QTy" +
                        ",[Bfb3_Unit] = @Bfb3_Unit" +
                        ",[Bfb3_Result] = @Bfb3_Result" +
                        ",[Bfb4] = @Bfb4" +
                        ",[Bfb4_OS] = @Bfb4_OS" +
                        ",[Bfb5] = @Bfb5" +
                        ",[Bfb5_FT] = @Bfb5_FT" +
                        ",[Bfb6] = @Bfb6" +
                        ",[Bfb6_Make] = @Bfb6_Make" +
                        ",[Bfb7] = @Bfb7" +
                        ",[Bfb7_Marker] = @Bfb7_Marker" +
                        ",[Bfb8] = @Bfb8" +
                        ",[Bfb8_TP] = @Bfb8_TP" +
                        ",[Bfb9] = @Bfb9" +
                        ",[Bfb9_Missing] = @Bfb9_Missing" +
                        ",[Bfb10] = @Bfb10" +
                        ",[BfbTotal] = @BfbTotal" +
                        ",[OP1_ID] = @OP1_ID" +
                        ",[OP1_Sign] = @OP1_Sign" +
                        ",[OP1_SignDate] = @OP1_SignDate" +
                        " WHERE MCNo = @MCNo AND LotNo = @LotNo";

            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.DBxConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(strSQL, con))
                {
                    cmd.Parameters.AddWithValue("@MCNo", MCNo);
                    //cmd.Parameters.AddWithValue("@DeviceName", DeviceName);
                    cmd.Parameters.AddWithValue("@LotNo", LotNo);
                    cmd.Parameters.AddWithValue("@MoveLotReason", MoveLotReason);
                    //cmd.Parameters.AddWithValue("@RequestMoveDate", RequestMoveDate);

                    cmd.Parameters.AddWithValue("@Bfb1", Bfb1);
                    cmd.Parameters.AddWithValue("@Bfb1_TgBefore", Bfb1_TgBefore);
                    cmd.Parameters.AddWithValue("@Bfb2", Bfb2);
                    cmd.Parameters.AddWithValue("@Bfb2_Good", Bfb2_Good);
                    cmd.Parameters.AddWithValue("@Bfb2_StdReel", Bfb2_StdReel);
                    cmd.Parameters.AddWithValue("@Bfb2_HasuuReel", Bfb2_HasuuReel);
                    cmd.Parameters.AddWithValue("@Bfb3", Bfb3);
                    cmd.Parameters.AddWithValue("@Bfb3_QTy", Bfb3_QTy);
                    cmd.Parameters.AddWithValue("@Bfb3_Unit", Bfb3_Unit);
                    cmd.Parameters.AddWithValue("@Bfb3_Result", Bfb3_Result);
                    cmd.Parameters.AddWithValue("@Bfb4", Bfb4);
                    cmd.Parameters.AddWithValue("@Bfb4_OS", Bfb4_OS);
                    cmd.Parameters.AddWithValue("@Bfb5", Bfb5);
                    cmd.Parameters.AddWithValue("@Bfb5_FT", Bfb5_FT);
                    cmd.Parameters.AddWithValue("@Bfb6", Bfb6);
                    cmd.Parameters.AddWithValue("@Bfb6_Make", Bfb6_Make);
                    cmd.Parameters.AddWithValue("@Bfb7", Bfb7);
                    cmd.Parameters.AddWithValue("@Bfb7_Marker", Bfb7_Marker);
                    cmd.Parameters.AddWithValue("@Bfb8", Bfb8);
                    cmd.Parameters.AddWithValue("@Bfb8_TP", Bfb8_TP);
                    cmd.Parameters.AddWithValue("@Bfb9", Bfb9);
                    cmd.Parameters.AddWithValue("@Bfb9_Missing", Bfb9_Missing);
                    cmd.Parameters.AddWithValue("@Bfb10", Bfb10);
                    cmd.Parameters.AddWithValue("@BfbTotal", BfbTotal);
                    cmd.Parameters.AddWithValue("@OP1_ID", OP1_ID);
                    cmd.Parameters.AddWithValue("@OP1_Sign", OP1_Sign);
                    cmd.Parameters.AddWithValue("@OP1_SignDate", OP1_SignDate);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

        }



        public void MoveLotS2(string MCNo, string DeviceName, string LotNo, string MoveLotReason, string RequestMoveDate, string Bfb1, int Bfb1_TgBefore,
           string Bfb2, int Bfb2_Good, int Bfb2_StdReel, int Bfb2_HasuuReel, string Bfb3, int Bfb3_QTy, int Bfb3_Unit, int Bfb3_Result, string Bfb4, int Bfb4_OS,
           string Bfb5, int Bfb5_FT, string Bfb6, int Bfb6_Make, string Bfb7, int Bfb7_Marker, string Bfb8, int Bfb8_TP, string Bfb9, int Bfb9_Missing,
           string Bfb10, int BfbTotal,string GL1_ID, string GL1_Sign, string GL1_SignDate)
        {
            string strSQL = "UPDATE [dbo].[LowYieldMoveLot] SET [Bfb1] = @Bfb1" +
                        ",[Bfb1_TgBefore] = @Bfb1_TgBefore" +
                        ",[Bfb2] = @Bfb2" +
                        ",[Bfb2_Good] = @Bfb2_Good" +
                        ",[Bfb2_StdReel] = Bfb2_StdReel" +
                        ",[Bfb2_HasuuReel] = @Bfb2_HasuuReel" +
                        ",[Bfb3] = @Bfb3" +
                        ",[Bfb3_QTy] = @Bfb3_QTy" +
                        ",[Bfb3_Unit] = @Bfb3_Unit" +
                        ",[Bfb3_Result] = @Bfb3_Result" +
                        ",[Bfb4] = @Bfb4" +
                        ",[Bfb4_OS] = @Bfb4_OS" +
                        ",[Bfb5] = @Bfb5" +
                        ",[Bfb5_FT] = @Bfb5_FT" +
                        ",[Bfb6] = @Bfb6" +
                        ",[Bfb6_Make] = @Bfb6_Make" +
                        ",[Bfb7] = @Bfb7" +
                        ",[Bfb7_Marker] = @Bfb7_Marker" +
                        ",[Bfb8] = @Bfb8" +
                        ",[Bfb8_TP] = @Bfb8_TP" +
                        ",[Bfb9] = @Bfb9" +
                        ",[Bfb9_Missing] = @Bfb9_Missing" +
                        ",[Bfb10] = @Bfb10" +
                        ",[BfbTotal] = @BfbTotal" +
                        ",[GL1_ID] = @GL1_ID" +
                        ",[GL1_Sign] = @GL1_Sign" +
                        ",[GL1_SignDate] = @GL1_SignDate" +
                        " WHERE MCNo = @MCNo AND LotNo = @LotNo";

            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.DBxConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(strSQL, con))
                {
                    cmd.Parameters.AddWithValue("@MCNo", MCNo);
                    //cmd.Parameters.AddWithValue("@DeviceName", DeviceName);
                    cmd.Parameters.AddWithValue("@LotNo", LotNo);
                    cmd.Parameters.AddWithValue("@MoveLotReason", MoveLotReason);
                    //cmd.Parameters.AddWithValue("@RequestMoveDate", RequestMoveDate);

                    cmd.Parameters.AddWithValue("@Bfb1", Bfb1);
                    cmd.Parameters.AddWithValue("@Bfb1_TgBefore", Bfb1_TgBefore);
                    cmd.Parameters.AddWithValue("@Bfb2", Bfb2);
                    cmd.Parameters.AddWithValue("@Bfb2_Good", Bfb2_Good);
                    cmd.Parameters.AddWithValue("@Bfb2_StdReel", Bfb2_StdReel);
                    cmd.Parameters.AddWithValue("@Bfb2_HasuuReel", Bfb2_HasuuReel);
                    cmd.Parameters.AddWithValue("@Bfb3", Bfb3);
                    cmd.Parameters.AddWithValue("@Bfb3_QTy", Bfb3_QTy);
                    cmd.Parameters.AddWithValue("@Bfb3_Unit", Bfb3_Unit);
                    cmd.Parameters.AddWithValue("@Bfb3_Result", Bfb3_Result);
                    cmd.Parameters.AddWithValue("@Bfb4", Bfb4);
                    cmd.Parameters.AddWithValue("@Bfb4_OS", Bfb4_OS);
                    cmd.Parameters.AddWithValue("@Bfb5", Bfb5);
                    cmd.Parameters.AddWithValue("@Bfb5_FT", Bfb5_FT);
                    cmd.Parameters.AddWithValue("@Bfb6", Bfb6);
                    cmd.Parameters.AddWithValue("@Bfb6_Make", Bfb6_Make);
                    cmd.Parameters.AddWithValue("@Bfb7", Bfb7);
                    cmd.Parameters.AddWithValue("@Bfb7_Marker", Bfb7_Marker);
                    cmd.Parameters.AddWithValue("@Bfb8", Bfb8);
                    cmd.Parameters.AddWithValue("@Bfb8_TP", Bfb8_TP);
                    cmd.Parameters.AddWithValue("@Bfb9", Bfb9);
                    cmd.Parameters.AddWithValue("@Bfb9_Missing", Bfb9_Missing);
                    cmd.Parameters.AddWithValue("@Bfb10", Bfb10);
                    cmd.Parameters.AddWithValue("@BfbTotal", BfbTotal);
                    cmd.Parameters.AddWithValue("@GL1_ID", GL1_ID);
                    cmd.Parameters.AddWithValue("@GL1_Sign", GL1_Sign);
                    cmd.Parameters.AddWithValue("@GL1_SignDate", GL1_SignDate);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

        }



        public void MoveLotS3(string MCNo, string LotNo, string Bsr1, int Bsr1_TgBefore, 
           string Bsr2, int Bsr2_Good, int Bsr2_StdReel, int Bsr2_HasuuReel, string Bsr3, int Bsr3_QTy, int Bsr3_Unit, int Bsr3_Result, string Bsr4, int Bsr4_OS,
           string Bsr5, int Bsr5_FT, string Bsr6, int Bsr6_Make, string Bsr7, int Bsr7_Marker, string Bsr8, int Bsr8_TP, string Bsr9, int Bsr9_Missing,
           string Bsr10, int BsrTotal,string OP2_ID, string OP2_Sign, string OP2_SignDate)
        {
            string strSQL = "UPDATE [dbo].[LowYieldMoveLot] SET [Bsr1] = @Bsr1" +
                        ",[Bsr1_TgBefore] = @Bsr1_TgBefore" +
                        ",[Bsr2] = @Bsr2" +
                        ",[Bsr2_Good] = @Bsr2_Good" +
                        ",[Bsr2_StdReel] = Bsr2_StdReel" +
                        ",[Bsr2_HasuuReel] = @Bsr2_HasuuReel" +
                        ",[Bsr3] = @Bsr3" +
                        ",[Bsr3_QTy] = @Bsr3_QTy" +
                        ",[Bsr3_Unit] = @Bsr3_Unit" +
                        ",[Bsr3_Result] = @Bsr3_Result" +
                        ",[Bsr4] = @Bsr4" +
                        ",[Bsr4_OS] = @Bsr4_OS" +
                        ",[Bsr5] = @Bsr5" +
                        ",[Bsr5_FT] = @Bsr5_FT" +
                        ",[Bsr6] = @Bsr6" +
                        ",[Bsr6_Make] = @Bsr6_Make" +
                        ",[Bsr7] = @Bsr7" +
                        ",[Bsr7_Marker] = @Bsr7_Marker" +
                        ",[Bsr8] = @Bsr8" +
                        ",[Bsr8_TP] = @Bsr8_TP" +
                        ",[Bsr9] = @Bsr9" +
                        ",[Bsr9_Missing] = @Bsr9_Missing" +
                        ",[Bsr10] = @Bsr10" +
                        ",[BsrTotal] = @BsrTotal" +
                        ",[OP2_ID] = @OP2_ID" +
                        ",[OP2_Sign] = @OP2_Sign" +
                        ",[OP2_SignDate] = @OP2_SignDate" +
                        " WHERE MCNo = @MCNo AND LotNo = @LotNo";

            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.DBxConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(strSQL, con))
                {
                    cmd.Parameters.AddWithValue("@MCNo", MCNo);
                    //cmd.Parameters.AddWithValue("@DeviceName", DeviceName);
                    cmd.Parameters.AddWithValue("@LotNo", LotNo);

                    cmd.Parameters.AddWithValue("@Bsr1", Bsr1);
                    cmd.Parameters.AddWithValue("@Bsr1_TgBefore", Bsr1_TgBefore);
                    cmd.Parameters.AddWithValue("@Bsr2", Bsr2);
                    cmd.Parameters.AddWithValue("@Bsr2_Good", Bsr2_Good);
                    cmd.Parameters.AddWithValue("@Bsr2_StdReel", Bsr2_StdReel);
                    cmd.Parameters.AddWithValue("@Bsr2_HasuuReel", Bsr2_HasuuReel);
                    cmd.Parameters.AddWithValue("@Bsr3", Bsr3);
                    cmd.Parameters.AddWithValue("@Bsr3_QTy", Bsr3_QTy);
                    cmd.Parameters.AddWithValue("@Bsr3_Unit", Bsr3_Unit);
                    cmd.Parameters.AddWithValue("@Bsr3_Result", Bsr3_Result);
                    cmd.Parameters.AddWithValue("@Bsr4", Bsr4);
                    cmd.Parameters.AddWithValue("@Bsr4_OS", Bsr4_OS);
                    cmd.Parameters.AddWithValue("@Bsr5", Bsr5);
                    cmd.Parameters.AddWithValue("@Bsr5_FT", Bsr5_FT);
                    cmd.Parameters.AddWithValue("@Bsr6", Bsr6);
                    cmd.Parameters.AddWithValue("@Bsr6_Make", Bsr6_Make);
                    cmd.Parameters.AddWithValue("@Bsr7", Bsr7);
                    cmd.Parameters.AddWithValue("@Bsr7_Marker", Bsr7_Marker);
                    cmd.Parameters.AddWithValue("@Bsr8", Bsr8);
                    cmd.Parameters.AddWithValue("@Bsr8_TP", Bsr8_TP);
                    cmd.Parameters.AddWithValue("@Bsr9", Bsr9);
                    cmd.Parameters.AddWithValue("@Bsr9_Missing", Bsr9_Missing);
                    cmd.Parameters.AddWithValue("@Bsr10", Bsr10);
                    cmd.Parameters.AddWithValue("@BsrTotal", BsrTotal);
                    cmd.Parameters.AddWithValue("@OP2_ID", OP2_ID);
                    cmd.Parameters.AddWithValue("@OP2_Sign", OP2_Sign);
                    cmd.Parameters.AddWithValue("@OP2_SignDate", OP2_SignDate);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

        }

        public void MoveLotS4(string MCNo, string LotNo, string Bsr1, int Bsr1_TgBefore,
           string Bsr2, int Bsr2_Good, int Bsr2_StdReel, int Bsr2_HasuuReel, string Bsr3, int Bsr3_QTy, int Bsr3_Unit, int Bsr3_Result, string Bsr4, int Bsr4_OS,
           string Bsr5, int Bsr5_FT, string Bsr6, int Bsr6_Make, string Bsr7, int Bsr7_Marker, string Bsr8, int Bsr8_TP, string Bsr9, int Bsr9_Missing,
           string Bsr10, int BsrTotal,string GL2_ID, string GL2_Sign, string GL2_SignDate)
        {
            string strSQL = "UPDATE [dbo].[LowYieldMoveLot] SET [Bsr1] = @Bsr1" +
                        ",[Bsr1_TgBefore] = @Bsr1_TgBefore" +
                        ",[Bsr2] = @Bsr2" +
                        ",[Bsr2_Good] = @Bsr2_Good" +
                        ",[Bsr2_StdReel] = Bsr2_StdReel" +
                        ",[Bsr2_HasuuReel] = @Bsr2_HasuuReel" +
                        ",[Bsr3] = @Bsr3" +
                        ",[Bsr3_QTy] = @Bsr3_QTy" +
                        ",[Bsr3_Unit] = @Bsr3_Unit" +
                        ",[Bsr3_Result] = @Bsr3_Result" +
                        ",[Bsr4] = @Bsr4" +
                        ",[Bsr4_OS] = @Bsr4_OS" +
                        ",[Bsr5] = @Bsr5" +
                        ",[Bsr5_FT] = @Bsr5_FT" +
                        ",[Bsr6] = @Bsr6" +
                        ",[Bsr6_Make] = @Bsr6_Make" +
                        ",[Bsr7] = @Bsr7" +
                        ",[Bsr7_Marker] = @Bsr7_Marker" +
                        ",[Bsr8] = @Bsr8" +
                        ",[Bsr8_TP] = @Bsr8_TP" +
                        ",[Bsr9] = @Bsr9" +
                        ",[Bsr9_Missing] = @Bsr9_Missing" +
                        ",[Bsr10] = @Bsr10" +
                        ",[BsrTotal] = @BsrTotal" +
                        ",[GL2_ID] = @GL2_ID" +
                        ",[GL2_Sign] = @GL2_Sign" +
                        ",[GL2_SignDate] = @GL2_SignDate" +
                        " WHERE MCNo = @MCNo AND LotNo = @LotNo";

            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.DBxConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(strSQL, con))
                {
                    cmd.Parameters.AddWithValue("@MCNo", MCNo);
                    //cmd.Parameters.AddWithValue("@DeviceName", DeviceName);
                    cmd.Parameters.AddWithValue("@LotNo", LotNo);

                    cmd.Parameters.AddWithValue("@Bsr1", Bsr1);
                    cmd.Parameters.AddWithValue("@Bsr1_TgBefore", Bsr1_TgBefore);
                    cmd.Parameters.AddWithValue("@Bsr2", Bsr2);
                    cmd.Parameters.AddWithValue("@Bsr2_Good", Bsr2_Good);
                    cmd.Parameters.AddWithValue("@Bsr2_StdReel", Bsr2_StdReel);
                    cmd.Parameters.AddWithValue("@Bsr2_HasuuReel", Bsr2_HasuuReel);
                    cmd.Parameters.AddWithValue("@Bsr3", Bsr3);
                    cmd.Parameters.AddWithValue("@Bsr3_QTy", Bsr3_QTy);
                    cmd.Parameters.AddWithValue("@Bsr3_Unit", Bsr3_Unit);
                    cmd.Parameters.AddWithValue("@Bsr3_Result", Bsr3_Result);
                    cmd.Parameters.AddWithValue("@Bsr4", Bsr4);
                    cmd.Parameters.AddWithValue("@Bsr4_OS", Bsr4_OS);
                    cmd.Parameters.AddWithValue("@Bsr5", Bsr5);
                    cmd.Parameters.AddWithValue("@Bsr5_FT", Bsr5_FT);
                    cmd.Parameters.AddWithValue("@Bsr6", Bsr6);
                    cmd.Parameters.AddWithValue("@Bsr6_Make", Bsr6_Make);
                    cmd.Parameters.AddWithValue("@Bsr7", Bsr7);
                    cmd.Parameters.AddWithValue("@Bsr7_Marker", Bsr7_Marker);
                    cmd.Parameters.AddWithValue("@Bsr8", Bsr8);
                    cmd.Parameters.AddWithValue("@Bsr8_TP", Bsr8_TP);
                    cmd.Parameters.AddWithValue("@Bsr9", Bsr9);
                    cmd.Parameters.AddWithValue("@Bsr9_Missing", Bsr9_Missing);
                    cmd.Parameters.AddWithValue("@Bsr10", Bsr10);
                    cmd.Parameters.AddWithValue("@BsrTotal", BsrTotal);
                    cmd.Parameters.AddWithValue("@GL2_ID", GL2_ID);
                    cmd.Parameters.AddWithValue("@GL2_Sign", GL2_Sign);
                    cmd.Parameters.AddWithValue("@GL2_SignDate", GL2_SignDate);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

        }



        public DataTable PullMoveLotData(string MCNo, string LotNo)
        {
            var tbl = new DataTable();
            string strSQL = "SELECT * FROM dbo.LowYieldMoveLot WHERE MCNo = @MCNo AND LotNo = @LotNo";
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.DBxConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(strSQL, con))
                {
                    cmd.Parameters.AddWithValue("@MCNo", MCNo);
                    cmd.Parameters.AddWithValue("@LotNo", LotNo);
                    con.Open();
                    tbl.Load(cmd.ExecuteReader());
                    con.Close();
                }
            }
            return tbl;
        }


        public DataTable Login(string emp_num)
        {
            var tbl = new DataTable();
            string strSQL = "SELECT * From [APCSProDB].[man].[users] WHERE emp_num=@emp_num";

            using (SqlConnection APCScon = new SqlConnection(Properties.Settings.Default.ApcsProConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(strSQL, APCScon))
                {
                    cmd.Parameters.AddWithValue("@emp_num", emp_num);
                    APCScon.Open();
                    tbl.Load(cmd.ExecuteReader());
                    APCScon.Close();
                }
            }

            return tbl;
        }

        public DataTable LoginDefault(string emp_num)
        {
            var tbl = new DataTable();
            string strSQL = "Select * From [APCSProDB].[man].[users],[APCSProDB].[man].[user_roles] Where users.id=user_roles.user_id and  emp_num=@emp_num";

            using (SqlConnection APCScon = new SqlConnection(Properties.Settings.Default.ApcsProConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(strSQL, APCScon))
                {
                    cmd.Parameters.AddWithValue("@emp_num", emp_num);
                    APCScon.Open();
                    tbl.Load(cmd.ExecuteReader());
                    APCScon.Close();
                }
            }

            return tbl;
        }

        public DataTable CheckPermissionOP(string emp_num)
        {
            //role_id='8' คือ PDFLOP
            var tblOP = new DataTable();
            string strSQL = "Select * From [APCSProDB].[man].[users],[APCSProDB].[man].[user_roles] Where users.id=user_roles.user_id and role_id='8' and  emp_num=@emp_num ";

            using (SqlConnection APCScon = new SqlConnection(Properties.Settings.Default.ApcsProConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(strSQL, APCScon))
                {
                    cmd.Parameters.AddWithValue("@emp_num", emp_num);
                    APCScon.Open();
                    tblOP.Load(cmd.ExecuteReader());
                    APCScon.Close();
                }
            }

            return tblOP;
        }

        public DataTable CheckPermissionQYI(string emp_num)
        {
            //role_id='37' คือ PETEOP
            var tblQYI = new DataTable();
            string strSQL = "Select * From [APCSProDB].[man].[users],[APCSProDB].[man].[user_roles] Where users.id=user_roles.user_id and (role_id='37'or role_id='38' or role_id='39') and  emp_num=@emp_num ";

            using (SqlConnection APCScon = new SqlConnection(Properties.Settings.Default.ApcsProConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(strSQL, APCScon))
                {
                    cmd.Parameters.AddWithValue("@emp_num", emp_num);
                    APCScon.Open();
                    tblQYI.Load(cmd.ExecuteReader());
                    APCScon.Close();
                }
            }

            return tblQYI;
        }

        public DataTable CheckPermissionGL(string emp_num)
        {
            //role_id='18' คือ PETEGL
            var tblGL = new DataTable();
            string strSQL = "Select * From [APCSProDB].[man].[users],[APCSProDB].[man].[user_roles] Where users.id=user_roles.user_id and role_id='16' and  emp_num=@emp_num ";

            using (SqlConnection APCScon = new SqlConnection(Properties.Settings.Default.ApcsProConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(strSQL, APCScon))
                {
                    cmd.Parameters.AddWithValue("@emp_num", emp_num);
                    APCScon.Open();
                    tblGL.Load(cmd.ExecuteReader());
                    APCScon.Close();
                }
            }

            return tblGL;
        }

        public DataTable CheckPermissionMGR(string emp_num)
        {
            //role_id='18' คือ PETEGL
            var tblMGR = new DataTable();
            string strSQL = "Select * From [APCSProDB].[man].[users],[APCSProDB].[man].[user_roles] Where users.id=user_roles.user_id and role_id='26' and  emp_num=@emp_num ";

            using (SqlConnection APCScon = new SqlConnection(Properties.Settings.Default.ApcsProConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(strSQL, APCScon))
                {
                    cmd.Parameters.AddWithValue("@emp_num", emp_num);
                    APCScon.Open();
                    tblMGR.Load(cmd.ExecuteReader());
                    APCScon.Close();
                }
            }

            return tblMGR;
        }

        public DataTable CheckPermissionQC(string emp_num)
        {
            //role_id='18' คือ PETEGL
            var tblQC = new DataTable();
            string strSQL = "Select * From [APCSProDB].[man].[users],[APCSProDB].[man].[user_roles] Where users.id=user_roles.user_id and  (role_id='34' or role_id='104')  and  emp_num=@emp_num ";

            using (SqlConnection APCScon = new SqlConnection(Properties.Settings.Default.ApcsProConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(strSQL, APCScon))
                {
                    cmd.Parameters.AddWithValue("@emp_num", emp_num);
                    APCScon.Open();
                    tblQC.Load(cmd.ExecuteReader());
                    APCScon.Close();
                }
            }

            return tblQC;
        }

        public void MoveToHistory8(string Process, string MCNo, string LotNo, string PackageName, string DeviceName, string RequestDate, int Mode, string Status, string Describe, string RequestType, int AmountNG, string Flow, string MNo, string TesterNo, string BoxNo, string TRank, string WaferLotNo, string WaferSheetNo,
                    string TPRank, string Shipment, int InputQuantity, string ControlYield, string InitialYield, string CheckValue, int ActionPCS, string ActionPercent, string S2TestNoA1, string S2TestNoA2, string S2TestNoA3, string S2TestNoA4, string S2TestNoA5, int S2NG_A1, int S2NG_A2, int S2NG_A3, int S2NG_A4, int S2NG_A5,
                    string S2TestNoB1, string S2TestNoB2, string S2TestNoB3, string S2TestNoB4, string S2TestNoB5, int S2NG_B1, int S2NG_B2, int S2NG_B3, int S2NG_B4, int S2NG_B5, string SetupCheck, string ManaulCheck1, string Result1_1, string ManaulCheck1_2, string Result1_2, string ManaulCheck1_3, string Result1_3, string ManaulCheck2, string Result2, string ManaulCheck3, string Result3,
                    string SocketChangeHist, string SocketChangeLastDate, string IsRestartStep3, string CheckLowYieldKanban, string CheckAlarmBin, string TesterChecker, string Setup, string TNo1, string TNo2, string TNo3, string TNo4, string TNo5, string LimitLow1, string LimitLow2, string LimitLow3, string LimitLow4, string LimitLow5, string LimitHigh1, string LimitHigh2, string LimitHigh3, string LimitHigh4, string LimitHigh5,
                    string MassProductNG1, string MassProductNG2, string MassProductNG3, string MassProductNG4, string MassProductNG5, string GoodSample1, string GoodSample2, string GoodSample3, string GoodSample4, string GoodSample5, string TesterETC1, string TesterETC2, string TesterETC3, string TesterETC4, string TesterETC5, string CheckRepeat1, string CheckRepeat2, string CheckRepeat3, string CheckRepeat4, string CheckRepeat5,
                    string ProgramName, int UseMassProductGood, int UseMassProductNG, int ScrapAmountGood, int ScrapAmountNG, string Cause, string S10TestNoA1, string S10TestNoA2, string S10TestNoA3, string S10TestNoA4, string S10TestNoA5, int S10NGA1, int S10NGA2, int S10NGA3, int S10NGA4, int S10NGA5, string S10TestNoB1, string S10TestNoB2, string S10TestNoB3, string S10TestNoB4, string S10TestNoB5,
                    int S10NGB1, int S10NGB2, int S10NGB3, int S10NGB4, int S10NGB5, string FinalYield, string ControlLCL, string AsiGood, string AsiNG, string AddOn, string AndonManage, string AndonWho, string AndonManageDetail, int TestResultGood, int TestResultNG, string RequestAQIS13, string StopNextLotS13, string KanbanCtrlNo, string KanbanTestNo, string KanbanExpireDate,
                    string ResultBurnGood, string ResultBurnNG, string ResultChipCrackGood, string ResultChipCrackNG, int ResultChipMixGood, int ResultChipMixNG, string RequestAQIS14, string StopNextLotS14, string StopPKGS14, string RequestAQIS15, string StopShipObjDevice, string StopLabel, string SystemInspection, string JudgementResult, string FTRetestGood,
                    string FTRetestNG, string ObjectScope, string StopRecallShipment, string LowYieldAnalysis, string StopShipmentPKG, string Assy, string QCJudgement, string OPName1_ID, string TestIncharge_ID, string OPName2_ID, string GL_ID, string AnalysisIncharge_ID, string FYIFQIIncharge_ID, string PDMgr_ID, string QCIncharge_ID, string OPName1_Sign, string TestIncharge_Sign,
                    string OPName2_Sign, string GL_Sign, string AnalysisIncharge_Sign, string FYIFQIIncharge_Sign, string PDMgr_Sign, string QCIncharge_Sign, string OPName1_SignDate, string TestIncharge_SignDate, string OPName2_SignDate, string GL_SignDate, string AnalysisIncharge_SignDate, string FYIFQIIncharge_SignDate, string PDMgr_SignDate, string QCIncharge_SignDate,int TesttotalAmount,
                    string SelectS16, string TEIncharge_ID, string TEIncharge_Sign, string TEIncharge_SignDate, string ShipmentDate, string LowYieldMode, string ControlBMNo, int BMID, string IssueNo, string CheckSocket, string QCApprove_ID, string QCApprove_Sign, string QCApprove_Date)
        {
            {


                string strSQL = "INSERT INTO [dbo].[LowYieldActionHistory] ([Process],[HandlerNo],[LotNo],[PackageName],[DeviceName],[RequestDate],[Mode],[Status],[Describe],[RequestType]" +
      ",[AmountNG],[Flow],[MNo],[TesterNo],[BoxNo],[TRank],[WaferLotNo],[WaferSheetNo],[TPRank],[Shipment],[InputQuantity],[ControlYield],[InitialYield],[CheckValue],[ActionPCS],[ActionPercent]" +
      ",[S2TestNoA1],[S2TestNoA2],[S2TestNoA3],[S2TestNoA4],[S2TestNoA5],[S2NG_A1],[S2NG_A2],[S2NG_A3],[S2NG_A4],[S2NG_A5],[S2TestNoB1],[S2TestNoB2],[S2TestNoB3],[S2TestNoB4],[S2TestNoB5],[S2NG_B1],[S2NG_B2],[S2NG_B3]" +
      ",[S2NG_B4],[S2NG_B5],[SetupCheck],[ManaulCheck1],[Result1_1],[ManaulCheck1_2],[Result1_2],[ManaulCheck1_3],[Result1_3],[ManaulCheck2],[Result2],[ManaulCheck3],[Result3],[SocketChangeHist],[SocketChangeLastDate]" +
      ",[IsRestartStep3],[CheckLowYieldKanban],[CheckAlarmBin],[TesterChecker],[Setup],[TNo1],[TNo2],[TNo3],[TNo4],[TNo5],[LimitLow1],[LimitLow2],[LimitLow3],[LimitLow4],[LimitLow5],[LimitHigh1],[LimitHigh2],[LimitHigh3]" +
      ",[LimitHigh4],[LimitHigh5],[MassProductNG1],[MassProductNG2],[MassProductNG3],[MassProductNG4],[MassProductNG5],[GoodSample1],[GoodSample2],[GoodSample3],[GoodSample4],[GoodSample5],[TesterETC1],[TesterETC2],[TesterETC3]" +
      ",[TesterETC4],[TesterETC5],[CheckRepeat1],[CheckRepeat2],[CheckRepeat3],[CheckRepeat4],[CheckRepeat5],[ProgramName],[UseMassProductGood],[UseMassProductNG],[ScrapAmountGood],[ScrapAmountNG],[Cause],[S10TestNoA1]" +
      ",[S10TestNoA2],[S10TestNoA3],[S10TestNoA4],[S10TestNoA5],[S10NGA1],[S10NGA2],[S10NGA3],[S10NGA4],[S10NGA5],[S10TestNoB1],[S10TestNoB2],[S10TestNoB3],[S10TestNoB4],[S10TestNoB5],[S10NGB1],[S10NGB2],[S10NGB3]" +
      ",[S10NGB4],[S10NGB5],[FinalYield],[ControlLCL],[AsiGood],[AsiNG],[AddOn],[AndonManage],[AndonWho],[AndonManageDetail],[TestResultGood],[TestResultNG],[RequestAQIS13],[StopNextLotS13],[KanbanCtrlNo]" +
      ",[KanbanTestNo],[KanbanExpireDate],[ResultBurnGood],[ResultBurnNG],[ResultChipCrackGood],[ResultChipCrackNG],[ResultChipMixGood],[ResultChipMixNG],[RequestAQIS14],[StopNextLotS14],[StopPKGS14],[RequestAQIS15]" +
      ",[StopShipObjDevice],[StopLabel],[SystemInspection],[JudgementResult],[FTRetestGood],[FTRetestNG],[ObjectScope],[StopRecallShipment],[LowYieldAnalysis],[StopShipmentPKG],[Assy],[QCJudgement],[OPName1_ID],[TestIncharge_ID]" +
      ",[OPName2_ID],[GL_ID],[AnalysisIncharge_ID],[FYIFQIIncharge_ID],[PDMgr_ID],[QCIncharge_ID],[OPName1_Sign],[TestIncharge_Sign],[OPName2_Sign],[GL_Sign],[AnalysisIncharge_Sign],[FYIFQIIncharge_Sign],[PDMgr_Sign]" +
      ",[QCIncharge_Sign],[OPName1_SignDate],[TestIncharge_SignDate],[OPName2_SignDate],[GL_SignDate],[AnalysisIncharge_SignDate],[FYIFQIIncharge_SignDate],[PDMgr_SignDate],[QCIncharge_SignDate],[TesttotalAmount]"+
      ",[SelectS16], [TEIncharge_ID], [TEIncharge_Sign], [TEIncharge_SignDate], [Shipmentdate], [LowYieldMode],[ControlBMNo],[BMID],[IssueNo],[CheckSocket],[QCApprove_ID],[QCApprove_Sing],[QCApprove_Date])" +

                            " VALUES (@Process,@MCNo,@LotNo, @PackageName , @DeviceName, @RequestDate, @Mode, @Status, @Describe, @RequestType, @AmountNG, @Flow, @MNo, @TesterNo, @BoxNo, @TRank, @WaferLotNo, @WaferSheetNo" +
                    ", @TPRank,@Shipment, @InputQuantity, @ControlYield, @InitialYield, @CheckValue, @ActionPCS, @ActionPercent, @S2TestNoA1, @S2TestNoA2, @S2TestNoA3, @S2TestNoA4, @S2TestNoA5,@S2NG_A1,@S2NG_A2, @S2NG_A3" +
                    ", @S2NG_A4,@S2NG_A5,@S2TestNoB1, @S2TestNoB2, @S2TestNoB3, @S2TestNoB4, @S2TestNoB5, @S2NG_B1, @S2NG_B2, @S2NG_B3, @S2NG_B4, @S2NG_B5, @SetupCheck, @ManaulCheck1, @Result1_1, @ManaulCheck1_2, @Result1_2" +
                    ", @ManaulCheck1_3, @Result1_3, @ManaulCheck2, @Result2, @ManaulCheck3, @Result3,@SocketChangeHist, @SocketChangeLastDate, @IsRestartStep3, @CheckLowYieldKanban,@CheckAlarmBin, @TesterChecker, @Setup, @TNo1" +
                    ", @TNo2, @TNo3, @TNo4, @TNo5, @LimitLow1, @LimitLow2,@LimitLow3, @LimitLow4, @LimitLow5, @LimitHigh1, @LimitHigh2, @LimitHigh3, @LimitHigh4, @LimitHigh5,@MassProductNG1, @MassProductNG2, @MassProductNG3" +
                    ", @MassProductNG4, @MassProductNG5, @GoodSample1, @GoodSample2, @GoodSample3, @GoodSample4, @GoodSample5, @TesterETC1, @TesterETC2, @TesterETC3, @TesterETC4, @TesterETC5, @CheckRepeat1, @CheckRepeat2,@CheckRepeat3" +
                    ", @CheckRepeat4, @CheckRepeat5, @ProgramName, @UseMassProductGood, @UseMassProductNG, @ScrapAmountGood, @ScrapAmountNG, @Cause, @S10TestNoA1, @S10TestNoA2,@S10TestNoA3, @S10TestNoA4, @S10TestNoA5, @S10NGA1, @S10NGA2" +
                    ", @S10NGA3, @S10NGA4, @S10NGA5, @S10TestNoB1, @S10TestNoB2, @S10TestNoB3, @S10TestNoB4, @S10TestNoB5,@S10NGB1, @S10NGB2, @S10NGB3, @S10NGB4, @S10NGB5, @FinalYield, @ControlLCL, @AsiGood, @AsiNG, @AddOn, @AndonManage" +
                    ", @AndonWho,@AndonManageDetail,@TestResultGood, @TestResultNG, @RequestAQIS13,@StopNextLotS13, @KanbanCtrlNo, @KanbanTestNo, @KanbanExpireDate,@ResultBurnGood, @ResultBurnNG, @ResultChipCrackGood" +
                    ", @ResultChipCrackNG, @stringResultChipMixGood, @ResultChipMixNG, @RequestAQIS14, @StopNextLotS14, @StopPKGS14, @RequestAQIS15, @StopShipObjDevice, @StopLabel, @SystemInspection, @JudgementResult, @FTRetestGood" +
                    ", @FTRetestNG, @ObjectScope, @StopRecallShipment, @LowYieldAnalysis, @StopShipmentPKG, @Assy, @QCJudgement, @OPName1_ID, @TestIncharge_ID, @OPName2_ID, @GL_ID, @AnalysisIncharge_ID, @FYIFQIIncharge_ID, @PDMgr_ID" +
                    ", @QCIncharge_ID, @OPName1_Sign, @TestIncharge_Sign,@OPName2_Sign, @GL_Sign, @AnalysisIncharge_Sign, @FYIFQIIncharge_Sign, @PDMgr_Sign, @QCIncharge_Sign, @OPName1_SignDate, @TestIncharge_SignDate, @OPName2_SignDate" +
                    ", @GL_SignDate, @AnalysisIncharge_SignDate, @FYIFQIIncharge_SignDate, @PDMgr_SignDate, @QCIncharge_SignDate,@TesttotalAmount,@SelectS16, @TEIncharge_ID, @TEIncharge_Sign, @TEIncharge_SignDate, @Shipmentdate, @LowYieldMode" +
                    ", @ControlBMNo, @BMID, @IssueNo,@CheckSocket,@QCApprove_ID,@QCApprove_Sing@QCApprove_Date)";

                using (SqlConnection con = new SqlConnection(Properties.Settings.Default.DBxConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(strSQL, con))
                    {
                        cmd.Parameters.AddWithValue("@Process", Process);
                        cmd.Parameters.AddWithValue("@MCNo", MCNo);
                        cmd.Parameters.AddWithValue("@LotNo", LotNo);
                        cmd.Parameters.AddWithValue("@PackageName", PackageName);
                        cmd.Parameters.AddWithValue("@DeviceName", DeviceName);
                        cmd.Parameters.AddWithValue("@RequestDate", RequestDate);
                        cmd.Parameters.AddWithValue("@Mode", Mode);
                        cmd.Parameters.AddWithValue("@Status", Status);
                        cmd.Parameters.AddWithValue("@Describe", Describe);
                        cmd.Parameters.AddWithValue("@RequestType", RequestType);
                        cmd.Parameters.AddWithValue("@AmountNG", AmountNG);
                        cmd.Parameters.AddWithValue("@Flow", Flow);
                        cmd.Parameters.AddWithValue("@MNo", MNo);
                        cmd.Parameters.AddWithValue("@TesterNo", TesterNo);
                        cmd.Parameters.AddWithValue("@BoxNo", BoxNo);
                        cmd.Parameters.AddWithValue("@TRank", TRank);
                        cmd.Parameters.AddWithValue("@WaferLotNo", WaferLotNo);
                        cmd.Parameters.AddWithValue("@WaferSheetNo", WaferSheetNo);
                        cmd.Parameters.AddWithValue("@TPRank", TPRank);
                        cmd.Parameters.AddWithValue("@Shipment", Shipment);
                        cmd.Parameters.AddWithValue("@InputQuantity", InputQuantity);
                        cmd.Parameters.AddWithValue("@ControlYield", ControlYield);
                        cmd.Parameters.AddWithValue("@InitialYield", InitialYield);
                        cmd.Parameters.AddWithValue("@CheckValue", CheckValue);
                        cmd.Parameters.AddWithValue("@ActionPCS", ActionPCS);
                        cmd.Parameters.AddWithValue("@ActionPercent", ActionPercent);
                        cmd.Parameters.AddWithValue("@S2TestNoA1", S2TestNoA1);
                        cmd.Parameters.AddWithValue("@S2TestNoA2", S2TestNoA2);
                        cmd.Parameters.AddWithValue("@S2TestNoA3", S2TestNoA3);
                        cmd.Parameters.AddWithValue("@S2TestNoA4", S2TestNoA4);
                        cmd.Parameters.AddWithValue("@S2TestNoA5", S2TestNoA5);
                        cmd.Parameters.AddWithValue("@S2NG_A1", S2NG_A1);
                        cmd.Parameters.AddWithValue("@S2NG_A2", S2NG_A2);
                        cmd.Parameters.AddWithValue("@S2NG_A3", S2NG_A3);
                        cmd.Parameters.AddWithValue("@S2NG_A4", S2NG_A4);
                        cmd.Parameters.AddWithValue("@S2NG_A5", S2NG_A5);
                        cmd.Parameters.AddWithValue("@S2TestNoB1", S2TestNoB1);
                        cmd.Parameters.AddWithValue("@S2TestNoB2", S2TestNoB2);
                        cmd.Parameters.AddWithValue("@S2TestNoB3", S2TestNoB3);
                        cmd.Parameters.AddWithValue("@S2TestNoB4", S2TestNoB4);
                        cmd.Parameters.AddWithValue("@S2TestNoB5", S2TestNoB5);
                        cmd.Parameters.AddWithValue("@S2NG_B1", S2NG_B1);
                        cmd.Parameters.AddWithValue("@S2NG_B2", S2NG_B2);
                        cmd.Parameters.AddWithValue("@S2NG_B3", S2NG_B3);
                        cmd.Parameters.AddWithValue("@S2NG_B4", S2NG_B4);
                        cmd.Parameters.AddWithValue("@S2NG_B5", S2NG_B5);
                        cmd.Parameters.AddWithValue("@SetupCheck", SetupCheck);
                        cmd.Parameters.AddWithValue("@ManaulCheck1", ManaulCheck1);
                        cmd.Parameters.AddWithValue("@Result1_1", Result1_1);
                        cmd.Parameters.AddWithValue("@ManaulCheck1_2", ManaulCheck1_2);
                        cmd.Parameters.AddWithValue("@Result1_2", Result1_2);
                        cmd.Parameters.AddWithValue("@ManaulCheck1_3", ManaulCheck1_3);
                        cmd.Parameters.AddWithValue("@Result1_3", Result1_3);
                        cmd.Parameters.AddWithValue("@ManaulCheck2", ManaulCheck2);
                        cmd.Parameters.AddWithValue("@Result2", Result2);
                        cmd.Parameters.AddWithValue("@ManaulCheck3", ManaulCheck3);
                        cmd.Parameters.AddWithValue("@Result3", Result3);
                        cmd.Parameters.AddWithValue("@SocketChangeHist", SocketChangeHist);
                        cmd.Parameters.AddWithValue("@SocketChangeLastDate", SocketChangeLastDate);
                        cmd.Parameters.AddWithValue("@IsRestartStep3", IsRestartStep3);
                        cmd.Parameters.AddWithValue("@CheckLowYieldKanban", CheckLowYieldKanban);
                        cmd.Parameters.AddWithValue("@CheckAlarmBin", CheckAlarmBin);
                        cmd.Parameters.AddWithValue("@TesterChecker", TesterChecker);
                        cmd.Parameters.AddWithValue("@Setup", Setup);
                        cmd.Parameters.AddWithValue("@TNo1", TNo1);
                        cmd.Parameters.AddWithValue("@TNo2", TNo2);
                        cmd.Parameters.AddWithValue("@TNo3", TNo3);
                        cmd.Parameters.AddWithValue("@TNo4", TNo4);
                        cmd.Parameters.AddWithValue("@TNo5", TNo5);
                        cmd.Parameters.AddWithValue("@LimitLow1", LimitLow1);
                        cmd.Parameters.AddWithValue("@LimitLow2", LimitLow2);
                        cmd.Parameters.AddWithValue("@LimitLow3", LimitLow3);
                        cmd.Parameters.AddWithValue("@LimitLow4", LimitLow4);
                        cmd.Parameters.AddWithValue("@LimitLow5", LimitLow5);
                        cmd.Parameters.AddWithValue("@LimitHigh1", LimitHigh1);
                        cmd.Parameters.AddWithValue("@LimitHigh2", LimitHigh2);
                        cmd.Parameters.AddWithValue("@LimitHigh3", LimitHigh3);
                        cmd.Parameters.AddWithValue("@LimitHigh4", LimitHigh4);
                        cmd.Parameters.AddWithValue("@LimitHigh5", LimitHigh5);
                        cmd.Parameters.AddWithValue("@MassProductNG1", MassProductNG1);
                        cmd.Parameters.AddWithValue("@MassProductNG2", MassProductNG2);
                        cmd.Parameters.AddWithValue("@MassProductNG3", MassProductNG3);
                        cmd.Parameters.AddWithValue("@MassProductNG4", MassProductNG4);
                        cmd.Parameters.AddWithValue("@MassProductNG5", MassProductNG5);
                        cmd.Parameters.AddWithValue("@GoodSample1", GoodSample1);
                        cmd.Parameters.AddWithValue("@GoodSample2", GoodSample2);
                        cmd.Parameters.AddWithValue("@GoodSample3", GoodSample3);
                        cmd.Parameters.AddWithValue("@GoodSample4", GoodSample4);
                        cmd.Parameters.AddWithValue("@GoodSample5", GoodSample5);
                        cmd.Parameters.AddWithValue("@TesterETC1", TesterETC1);
                        cmd.Parameters.AddWithValue("@TesterETC2", TesterETC2);
                        cmd.Parameters.AddWithValue("@TesterETC3", TesterETC3);
                        cmd.Parameters.AddWithValue("@TesterETC4", TesterETC4);
                        cmd.Parameters.AddWithValue("@TesterETC5", TesterETC5);
                        cmd.Parameters.AddWithValue("@CheckRepeat1", CheckRepeat1);
                        cmd.Parameters.AddWithValue("@CheckRepeat2", CheckRepeat2);
                        cmd.Parameters.AddWithValue("@CheckRepeat3", CheckRepeat3);
                        cmd.Parameters.AddWithValue("@CheckRepeat4", CheckRepeat4);
                        cmd.Parameters.AddWithValue("@CheckRepeat5", CheckRepeat5);
                        cmd.Parameters.AddWithValue("@ProgramName", ProgramName);
                        cmd.Parameters.AddWithValue("@UseMassProductGood", UseMassProductGood);
                        cmd.Parameters.AddWithValue("@UseMassProductNG", UseMassProductNG);
                        cmd.Parameters.AddWithValue("@ScrapAmountGood", ScrapAmountGood);
                        cmd.Parameters.AddWithValue("@ScrapAmountNG", ScrapAmountNG);
                        cmd.Parameters.AddWithValue("@Cause", Cause);
                        cmd.Parameters.AddWithValue("@S10TestNoA1", S10TestNoA1);
                        cmd.Parameters.AddWithValue("@S10TestNoA2", S10TestNoA2);
                        cmd.Parameters.AddWithValue("@S10TestNoA3", S10TestNoA3);
                        cmd.Parameters.AddWithValue("@S10TestNoA4", S10TestNoA4);
                        cmd.Parameters.AddWithValue("@S10TestNoA5", S10TestNoA5);
                        cmd.Parameters.AddWithValue("@S10NGA1", S10NGA1);
                        cmd.Parameters.AddWithValue("@S10NGA2", S10NGA2);
                        cmd.Parameters.AddWithValue("@S10NGA3", S10NGA3);
                        cmd.Parameters.AddWithValue("@S10NGA4", S10NGA4);
                        cmd.Parameters.AddWithValue("@S10NGA5", S10NGA5);
                        cmd.Parameters.AddWithValue("@S10TestNoB1", S10TestNoB1);
                        cmd.Parameters.AddWithValue("@S10TestNoB2", S10TestNoB2);
                        cmd.Parameters.AddWithValue("@S10TestNoB3", S10TestNoB3);
                        cmd.Parameters.AddWithValue("@S10TestNoB4", S10TestNoB4);
                        cmd.Parameters.AddWithValue("@S10TestNoB5", S10TestNoB5);
                        cmd.Parameters.AddWithValue("@S10NGB1", S10NGB1);
                        cmd.Parameters.AddWithValue("@S10NGB2", S10NGB2);
                        cmd.Parameters.AddWithValue("@S10NGB3", S10NGB3);
                        cmd.Parameters.AddWithValue("@S10NGB4", S10NGB4);
                        cmd.Parameters.AddWithValue("@S10NGB5", S10NGB5);
                        cmd.Parameters.AddWithValue("@FinalYield", FinalYield);
                        cmd.Parameters.AddWithValue("@ControlLCL", ControlLCL);
                        cmd.Parameters.AddWithValue("@AsiGood", AsiGood);
                        cmd.Parameters.AddWithValue("@AsiNG", AsiNG);
                        cmd.Parameters.AddWithValue("@AddOn", AddOn);
                        cmd.Parameters.AddWithValue("@AndonManage", AndonManage);
                        cmd.Parameters.AddWithValue("@AndonWho", AndonWho);
                        cmd.Parameters.AddWithValue("@AndonManageDetail", AndonManageDetail);
                        //cmd.Parameters.AddWithValue("@TesttotalAmount", TestTotalAmount);
                        cmd.Parameters.AddWithValue("@TestResultGood", TestResultGood);
                        cmd.Parameters.AddWithValue("@TestResultNG", TestResultNG);
                        cmd.Parameters.AddWithValue("@RequestAQIS13", RequestAQIS13);
                        cmd.Parameters.AddWithValue("@StopNextLotS13", StopNextLotS13);
                        cmd.Parameters.AddWithValue("@KanbanCtrlNo", KanbanCtrlNo);
                        cmd.Parameters.AddWithValue("@KanbanTestNo", KanbanTestNo);
                        cmd.Parameters.AddWithValue("@KanbanExpireDate", KanbanExpireDate);
                        cmd.Parameters.AddWithValue("@ResultBurnGood", ResultBurnGood);
                        cmd.Parameters.AddWithValue("@ResultBurnNG", ResultBurnNG);
                        cmd.Parameters.AddWithValue("@ResultChipCrackGood", ResultChipCrackGood);
                        cmd.Parameters.AddWithValue("@ResultChipCrackNG", ResultChipCrackNG);
                        cmd.Parameters.AddWithValue("@stringResultChipMixGood", ResultChipMixGood);
                        cmd.Parameters.AddWithValue("@ResultChipMixNG", ResultChipMixNG);
                        cmd.Parameters.AddWithValue("@RequestAQIS14", RequestAQIS14);
                        cmd.Parameters.AddWithValue("@StopNextLotS14", StopNextLotS14);
                        cmd.Parameters.AddWithValue("@StopPKGS14", StopPKGS14);
                        cmd.Parameters.AddWithValue("@RequestAQIS15", RequestAQIS15);
                        cmd.Parameters.AddWithValue("@StopShipObjDevice", StopShipObjDevice);
                        cmd.Parameters.AddWithValue("@StopLabel", StopLabel);
                        cmd.Parameters.AddWithValue("@SystemInspection", SystemInspection);
                        cmd.Parameters.AddWithValue("@JudgementResult", JudgementResult);
                        cmd.Parameters.AddWithValue("@FTRetestGood", FTRetestGood);
                        cmd.Parameters.AddWithValue("@FTRetestNG", FTRetestNG);
                        cmd.Parameters.AddWithValue("@ObjectScope", ObjectScope);
                        cmd.Parameters.AddWithValue("@StopRecallShipment", StopRecallShipment);
                        cmd.Parameters.AddWithValue("@LowYieldAnalysis", LowYieldAnalysis);
                        cmd.Parameters.AddWithValue("@StopShipmentPKG", StopShipmentPKG);
                        cmd.Parameters.AddWithValue("@Assy", Assy);
                        cmd.Parameters.AddWithValue("@QCJudgement", QCJudgement);
                        cmd.Parameters.AddWithValue("@OPName1_ID", OPName1_ID);
                        cmd.Parameters.AddWithValue("@TestIncharge_ID", TestIncharge_ID);
                        cmd.Parameters.AddWithValue("@OPName2_ID", OPName2_ID);
                        cmd.Parameters.AddWithValue("@GL_ID", GL_ID);
                        cmd.Parameters.AddWithValue("@AnalysisIncharge_ID", AnalysisIncharge_ID);
                        cmd.Parameters.AddWithValue("@FYIFQIIncharge_ID", FYIFQIIncharge_ID);
                        cmd.Parameters.AddWithValue("@PDMgr_ID", PDMgr_ID);
                        cmd.Parameters.AddWithValue("@QCIncharge_ID", QCIncharge_ID);
                        cmd.Parameters.AddWithValue("@OPName1_Sign", OPName1_Sign);
                        cmd.Parameters.AddWithValue("@TestIncharge_Sign", TestIncharge_Sign);
                        cmd.Parameters.AddWithValue("@OPName2_Sign", OPName2_Sign);
                        cmd.Parameters.AddWithValue("@GL_Sign", GL_Sign);
                        cmd.Parameters.AddWithValue("@AnalysisIncharge_Sign", AnalysisIncharge_Sign);
                        cmd.Parameters.AddWithValue("@FYIFQIIncharge_Sign", FYIFQIIncharge_Sign);
                        cmd.Parameters.AddWithValue("@PDMgr_Sign", PDMgr_Sign);
                        cmd.Parameters.AddWithValue("@QCIncharge_Sign", QCIncharge_Sign);
                        cmd.Parameters.AddWithValue("@OPName1_SignDate", OPName1_SignDate);
                        cmd.Parameters.AddWithValue("@TestIncharge_SignDate", TestIncharge_SignDate);
                        cmd.Parameters.AddWithValue("@OPName2_SignDate", OPName2_SignDate);
                        cmd.Parameters.AddWithValue("@GL_SignDate", GL_SignDate);
                        cmd.Parameters.AddWithValue("@AnalysisIncharge_SignDate", AnalysisIncharge_SignDate);
                        cmd.Parameters.AddWithValue("@FYIFQIIncharge_SignDate", FYIFQIIncharge_SignDate);
                        cmd.Parameters.AddWithValue("@PDMgr_SignDate", PDMgr_SignDate);
                        cmd.Parameters.AddWithValue("@QCIncharge_SignDate", QCIncharge_SignDate);
                        cmd.Parameters.AddWithValue("@TesttotalAmount", TesttotalAmount);
                        //Add 2020-03-12
                        cmd.Parameters.AddWithValue("@ShipmentDate", ShipmentDate);
                        cmd.Parameters.AddWithValue("@LowYieldMode", LowYieldMode);
                        cmd.Parameters.AddWithValue("@SelectS16", SelectS16);
                        cmd.Parameters.AddWithValue("@TEIncharge_ID", TEIncharge_ID);
                        cmd.Parameters.AddWithValue("@TEIncharge_Sign", TEIncharge_Sign);
                        cmd.Parameters.AddWithValue("@TEIncharge_SignDate", TEIncharge_SignDate);
                        //Add 2020-06-23
                        cmd.Parameters.AddWithValue("@ControlBMNo", ControlBMNo);
                        cmd.Parameters.AddWithValue("@BMID", BMID);
                        //Add 2020-08-28
                        cmd.Parameters.AddWithValue("@IssueNo", IssueNo);
                        //Add 2020-10-20
                        cmd.Parameters.AddWithValue("@CheckSocket", CheckSocket);
                        //Add 2020-11-27
                        cmd.Parameters.AddWithValue("@QCApprove_ID", QCApprove_ID);
                        cmd.Parameters.AddWithValue("@QCApprove_Sign", QCApprove_Sign);
                        cmd.Parameters.AddWithValue("@QCApprove_Date", QCApprove_Date);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

            }
        }


        public void MoveToHistory(string Process, string MCNo, string LotNo)
        {
            //This function use sqlBulkCopy to use Copy from rows datatable what you select and store rows to destination as you set.
            string strSQL = "SELECT * FROM [dbo].[LowYieldActionReport] WHERE Process = @Process AND HandlerNo = @MCNo AND LotNo = @LotNo";


            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.DBxConnectionString))
            {
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@Process", Process);
                cmd.Parameters.AddWithValue("@MCNo", MCNo);
                cmd.Parameters.AddWithValue("@LotNo", LotNo);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(con.ConnectionString))
                {
                    bulkCopy.DestinationTableName = "[dbo].[LowYieldActionHistory]"; //destination table as your need.
                    bulkCopy.WriteToServer(reader); //write reader(your selected rows)
                }

                reader.Close();
            }
        }

        public void DeleteReportRow(string Process, string MCNo, string LotNo)
        {
            string strSQL = "DELETE FROM [dbo].[LowYieldActionReport] WHERE Process = @Process AND HandlerNo = @MCNo AND LotNo = @LotNo";

            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.DBxConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(strSQL, con))
                {
                    cmd.Parameters.AddWithValue("@Process", Process);
                    cmd.Parameters.AddWithValue("@MCNo", MCNo);
                    cmd.Parameters.AddWithValue("@LotNo", LotNo);

                    con.Open();
                    cmd.ExecuteReader();
                    con.Close();
                }
            }
        }


        public void UpdateCancelStatus(string Process,string MCNo,string LotNo,string Status,string Describe)
        {
            string strSQL = "UPDATE dbo.LowYieldActionReport SET Status = @Status," +
                "Describe = @Describe WHERE Process = @Process AND HandlerNo = @HandlerNo AND LotNo = @LotNo";

            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.DBxConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(strSQL,con))
                {
                    cmd.Parameters.AddWithValue("@Process", Process);
                    cmd.Parameters.AddWithValue("@HandlerNo", MCNo);
                    cmd.Parameters.AddWithValue("@LotNo", LotNo);
                    cmd.Parameters.AddWithValue("@Status", Status);
                    cmd.Parameters.AddWithValue("@Describe",Describe);

                    con.Open();
                    cmd.ExecuteReader();
                    con.Close();
                }

            }
        }

    }
}