using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LowYieldCheckSheet
{
    public class GlobalClass
    {
        public string Process = "";
        public int AmountNG;
        public int TotalNG;
        public string HandlerNo = "";
        public string LotNo = "";
        public string PackageName = "";
        public string DeviceName = "";
        public string Flow = "";
        public string RequestDate = "";
        public string RequestType = "";
        public string Status = "";
        public string Describe = "";
        public string MNo = "";
        public string TesterNo = "";
        public string BoxNo = "";
        public string TRank = "";
        public string WaferLotNo = "";
        public string WaferSheetNo = "";
        public int Mode;
        public string Shipmentdate = "";

        public string TPRank = "";
        public string Shipment = "";
        public int InputQuantity;
        public string ControlYield;
        public string InitialYield;
        public string CheckValue;
        public int ActionPCS;
        public string ActionPercent;
        public string S2TestNoA1 = "";
        public string S2TestNoA2 = "";
        public string S2TestNoA3 = "";
        public string S2TestNoA4 = "";
        public string S2TestNoA5 = "";
        public int S2NG_A1;
        public int S2NG_A2;
        public int S2NG_A3;
        public int S2NG_A4;
        public int S2NG_A5;
        public string S2TestNoB1 = "";
        public string S2TestNoB2 = "";
        public string S2TestNoB3 = "";
        public string S2TestNoB4 = "";
        public string S2TestNoB5 = "";
        public int S2NG_B1;
        public int S2NG_B2;
        public int S2NG_B3;
        public int S2NG_B4;
        public int S2NG_B5;
        public string SetupCheck = "";
        public string ManaulCheck1 = "";
        public string Result1_1 = "";
        public string ManaulCheck1_2 = "";
        public string Result1_2 = "";
        public string ManaulCheck1_3 = "";
        public string Result1_3 = "";
        public string ManaulCheck2 = "";
        public string Result2 = "";
        public string ManaulCheck3 = "";
        public string Result3 = "";
        public string SocketChangeHist = "";
        public string SocketChangeLastDate = "";
        public string IsRestartStep3 = "";
        public string CheckLowYieldKanban = "";
        public string CheckAlarmBin = "";
        public string TesterChecker = "";
        public string Setup = "";
        public string LowYieldMode = "";
        public string TNo1 = "";
        public string TNo2 = "";
        public string TNo3 = "";
        public string TNo4 = "";
        public string TNo5 = "";
        public string LimitLow1 = "";
        public string LimitLow2 = "";
        public string LimitLow3 = "";
        public string LimitLow4 = "";
        public string LimitLow5 = "";
        public string LimitHigh1 = "";
        public string LimitHigh2 = "";
        public string LimitHigh3 = "";
        public string LimitHigh4 = "";
        public string LimitHigh5 = "";
        public string MassProductNG1 = "";
        public string MassProductNG2 = "";
        public string MassProductNG3 = "";
        public string MassProductNG4 = "";
        public string MassProductNG5 = "";
        public string GoodSample1 = "";
        public string GoodSample2 = "";
        public string GoodSample3 = "";
        public string GoodSample4 = "";
        public string GoodSample5 = "";
        public string TesterETC1 = "";
        public string TesterETC2 = "";
        public string TesterETC3 = "";
        public string TesterETC4 = "";
        public string TesterETC5 = "";
        public string CheckRepeat1 = "";
        public string CheckRepeat2 = "";
        public string CheckRepeat3 = "";
        public string CheckRepeat4 = "";
        public string CheckRepeat5 = "";
        public string ProgramName = "";
        public int UseMassProductGood;
        public int UseMassProductNG;
        public int ScrapAmountGood;
        public int ScrapAmountNG;
        public string Cause = "";
        public string S10TestNoA1 = "";
        public string S10TestNoA2 = "";
        public string S10TestNoA3 = "";
        public string S10TestNoA4 = "";
        public string S10TestNoA5 = "";
        public int S10NGA1;
        public int S10NGA2;
        public int S10NGA3;
        public int S10NGA4;
        public int S10NGA5;
        public string S10TestNoB1 = "";
        public string S10TestNoB2 = "";
        public string S10TestNoB3 = "";
        public string S10TestNoB4 = "";
        public string S10TestNoB5 = "";
        public int S10NGB1;
        public int S10NGB2;
        public int S10NGB3;
        public int S10NGB4;
        public int S10NGB5;
        public string FinalYield;
        public string ControlLCL;
        public string AsiGood;
        public string AsiNG;
        public string AddOn = "";
        public string AndonManage = "";
        public string AndonWho = "";
        public string AndonManageDetail = "";
        public int TesttotalAmount;
        public int TestResultGood;
        public int TestResultNG;
        public string RequestAQIS13 = "";
        public string StopNextLotS13 = "";
        public string KanbanCtrlNo = "";
        public string KanbanTestNo = "";
        public string KanbanExpireDate = "";
        public string ResultBurnGood = "";
        public string ResultBurnNG = "";
        public string ResultChipCrackGood = "";
        public string ResultChipCrackNG = "";
        public int ResultChipMixGood;
        public int ResultChipMixNG;
        public string RequestAQIS14 = "";
        public string StopNextLotS14 = "";
        public string StopPKGS14 = "";
        public string RequestAQIS15 = "";
        public string StopShipObjDevice = "";
        public string StopLabel = "";
        public string SystemInspection = "";
        public string JudgementResult = "";
        public string FTRetestGood = "";
        public string FTRetestNG = "";
        public string ObjectScope = "";
        public string StopRecallShipment = "";
        public string LowYieldAnalysis = "";
        public string StopShipmentPKG = "";
        public string Assy = "";
        public string QCJudgement = "";

        public string FYIFQI_Sign = "";
        public string PDMgr_Sign = "";
        public string QC_Sign = "";
        public string OPName1_Sign = "";
        public string TestIncharge_Sign = "";
        public string OPName2_Sign = "";
        public string GL_Sign = "";
        public string AnalysisIncharge_Sign = "";
        public string TEIncharge_Sign = "";
        public string FYIFQIIncharge_Sign = "";
        public string QCIncharge_Sign = "";

        public string FYIFQI_ID = "";
        public string PDMgr_ID = "";
        public string QC_ID = "";
        public string OPName1_ID = "";
        public string TestIncharge_ID = "";
        public string OPName2_ID = "";
        public string GL_ID = "";
        public string AnalysisIncharge_ID = "";
        public string FYIFQIIncharge_ID = "";
        public string QCIncharge_ID = "";

        public string FYIFQI_SignDate = "";
        public string PDMgr_SignDate = "";
        public string QC_SignDate = "";
        public string OPName1_SignDate = "";
        public string TestIncharge_SignDate = "";
        public string OPName2_SignDate = "";
        public string GL_SignDate = "";
        public string AnalysisIncharge_SignDate = "";
        public string FYIFQIIncharge_SignDate = "";
        public string QCIncharge_SignDate = "";
        public string SelectS16 = "";
        public string TEIncharge_ID = "";
        public string TEIncharge_SignDate = "";

        //Add 2020-06-23
        public string ControlBMNo = "";
        public int BMID;
        public string IssueNo = "" ;

        //Add 2020-10-20
        public string CheckSocket = "";




        //Variable for MoveLot Page
        public string RequestMoveDate = "";
        public string MoveLotReason = "";
        public string Bfb1 = "";
        public int Bfb1_TgBefore;
        public string Bfb2 = "";
        public int Bfb2_Good;
        public int Bfb2_StdReel;
        public int Bfb2_HasuuReel;
        public string Bfb3 = "";
        public int Bfb3_QTy;
        public int Bfb3_Unit;
        public int Bfb3_Result;
        public string Bfb4 = "";
        public int Bfb4_OS;
        public string Bfb5 = "";
        public int Bfb5_FT;
        public string Bfb6 = "";
        public int Bfb6_Make;
        public string Bfb7 = "";
        public int Bfb7_Marker;
        public string Bfb8 = "";
        public int Bfb8_TP;
        public string Bfb9 = "";
        public int Bfb9_Missing;
        public string Bfb10 = "";
        public int BfbTotal;


        public string Bsr1 = "";
        public int Bsr1_TgBefore;
        public string Bsr2 = "";
        public int Bsr2_Good;
        public int Bsr2_StdReel;
        public int Bsr2_HasuuReel;
        public string Bsr3 = "";
        public int Bsr3_QTy;
        public int Bsr3_Unit;
        public int Bsr3_Result;
        public string Bsr4 = "";
        public int Bsr4_OS;
        public string Bsr5 = "";
        public int Bsr5_FT;
        public string Bsr6 = "";
        public int Bsr6_Make;
        public string Bsr7 = "";
        public int Bsr7_Marker;
        public string Bsr8 = "";
        public int Bsr8_TP;
        public string Bsr9 = "";
        public int Bsr9_Missing;
        public string Bsr10 = "";
        public int BsrTotal;
        public string ContactNG = "";


        public string User;
        public string Edit;

        public string QCApprove_Sign { get; internal set; }
        public string QCApprove_SignDate { get; internal set; }
        public string QCApprove_ID { get; internal set; }
        public string QCApprove_Date { get; internal set; }
    }
}