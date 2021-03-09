using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace LowYieldCheckSheet
{
    public partial class OpenPdfHistory : System.Web.UI.Page
    {
        DBAccess dba = new DBAccess();
        GlobalClass gc = new GlobalClass();

        string[] strSplit;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Get data and keep by tbl
            var tbl = new DataTable();

            //Pull Data from table
            tbl = dba.PullHistory(Request.Params["Process"], Request.Params["MCNo"], Request.Params["LotNo"]);
            //tbl = dba.PullHistory("FL", "FL-F-001", "1817A2290V");

            if (tbl.Rows.Count == 1)
            {
                //Create File PDF
                Document pdf = new Document(PageSize.A4, 0, 0, 0, 0);
                MemoryStream ms = new MemoryStream();
                PdfWriter writer = null;
                writer = PdfWriter.GetInstance(pdf, ms);

                //############## OPEN PDF ######################
                pdf.Open();

                //Picture Writer to PDF (Template of PDF)
                var ReportImg = iTextSharp.text.Image.GetInstance(Server.MapPath("Images") + "/Report1.jpg");
                ReportImg.ScalePercent(24);
                ReportImg.SetAbsolutePosition(1, 0); //margin of Image template
                pdf.Add(ReportImg);


                //#################################### WRITE DATA ################################################
                PdfContentByte aPCB = writer.DirectContent;
                foreach (DataRow row in tbl.Rows)
                {
                    iTextSharp.text.Font iTextFont = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD);

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(60, 780);
                    aPCB.ShowText(row["IssueNo"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    //iTextSharp.text.Font iTextFont = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD);
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(60, 766);
                    aPCB.ShowText(row["IssueDate"].ToString());
                    aPCB.EndText();

                    //############################# Head #######################################################
                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 10);
                    aPCB.SetTextMatrix(37, 729);
                    aPCB.ShowText(row["AmountNG"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(135, 750);
                    aPCB.ShowText(row["PackageName"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(240, 750);
                    aPCB.ShowText(row["DeviceName"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(365, 750);
                    aPCB.ShowText(row["LotNo"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(475, 750);
                    aPCB.ShowText(row["MNo"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(120, 737);
                    aPCB.ShowText(row["TesterNo"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(220, 737);
                    aPCB.ShowText(row["BoxNo"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(285, 737);
                    aPCB.ShowText(row["TRank"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(372, 736);
                    aPCB.ShowText(row["WaferLotNo"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(475, 736);
                    aPCB.ShowText(row["WaferSheetNo"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(120, 720);
                    aPCB.ShowText(row["HandlerNo"].ToString());
                    aPCB.EndText();

                    // Condition Flow (Draw a circle)#################
                    if (row["Flow"].ToString() == "AUTO1")
                    {
                        aPCB.Circle(188, 723, 5);
                        aPCB.SetColorStroke(GrayColor.BLUE);
                    }
                    else if (row["Flow"].ToString() == "AUTO2")
                    {
                        aPCB.Circle(205, 723, 5);
                        aPCB.SetColorStroke(GrayColor.BLUE);
                    }
                    else if (row["Flow"].ToString() == "AUTO3")
                    {
                        aPCB.Circle(225, 723, 5);
                        aPCB.SetColorStroke(GrayColor.BLUE);
                    }
                    else if (row["Flow"].ToString() == "AUTO4")
                    {
                        aPCB.Circle(244, 723, 5);
                        aPCB.SetColorStroke(GrayColor.BLUE);
                    }
                    aPCB.Stroke();


                    //ตัวอย่าง วาด รูปวงกลม
                    //aPCB.Circle(244, 723, 5);
                    //aPCB.SetColorStroke(GrayColor.BLUE);
                    //aPCB.Stroke();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(333, 720);
                    aPCB.ShowText(row["TPRank"].ToString());
                    aPCB.EndText();

                    //Condition Shipment
                    if (row["Shipment"].ToString() == "JAPAN")
                    {
                        aPCB.Circle(433, 723, 9);
                        aPCB.SetColorStroke(GrayColor.BLUE);
                    }
                    else if (row["Shipment"].ToString() == "OVERSEA")
                    {
                        aPCB.Circle(473, 723, 9);
                        aPCB.SetColorStroke(GrayColor.BLUE);
                    }
                    aPCB.Stroke();



                    //########################### step 1 ####################################
                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(450, 693);
                    aPCB.ShowText(row["InputQuantity"].ToString());
                    aPCB.EndText();


                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(450, 683);
                    aPCB.ShowText(row["ControlYield"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(415, 673);
                    aPCB.ShowText(row["InitialYield"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(480, 673);
                    aPCB.ShowText(row["CheckValue"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(430, 662);
                    aPCB.ShowText(row["ActionPCS"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(480, 662);
                    aPCB.ShowText(row["ActionPercent"].ToString());
                    aPCB.EndText();

                    //######################### step 2 3 ############################

                    //######################### ACH ##################################
                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(408, 645);
                    aPCB.ShowText(row["S2TestNoA1"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(429, 645);
                    aPCB.ShowText(row["S2TestNoA2"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(450, 645);
                    aPCB.ShowText(row["S2TestNoA3"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(471, 645);
                    aPCB.ShowText(row["S2TestNoA4"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(492, 645);
                    aPCB.ShowText(row["S2TestNoA5"].ToString());
                    aPCB.EndText();


                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(408, 638);
                    if (row["S2NG_A1"].ToString() == "0")
                    {

                    }
                    else
                    {
                        aPCB.ShowText(row["S2NG_A1"].ToString());
                    }
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(429, 638);
                    if (row["S2NG_A2"].ToString() == "0")
                    {

                    }
                    else
                    {
                        aPCB.ShowText(row["S2NG_A2"].ToString());
                    }
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(450, 638);
                    if (row["S2NG_A3"].ToString() == "0")
                    {

                    }
                    else
                    {
                        aPCB.ShowText(row["S2NG_A3"].ToString());
                    }

                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(471, 638);
                    aPCB.ShowText(row["S2NG_A4"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(492, 638);
                    aPCB.ShowText(row["S2NG_A5"].ToString());
                    aPCB.EndText();

                    //######################### BCH ##################################
                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(408, 631);
                    aPCB.ShowText(row["S2TestNoA1"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(429, 631);
                    aPCB.ShowText(row["S2TestNoA2"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(450, 631);
                    aPCB.ShowText(row["S2TestNoA3"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(471, 631);
                    aPCB.ShowText(row["S2TestNoA4"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(492, 631);
                    aPCB.ShowText(row["S2TestNoA5"].ToString());
                    aPCB.EndText();


                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(408, 625);
                    aPCB.ShowText(row["S2NG_A1"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(429, 625);
                    aPCB.ShowText(row["S2NG_A2"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(450, 625);
                    aPCB.ShowText(row["S2NG_A3"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(471, 625);
                    aPCB.ShowText(row["S2NG_A4"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(492, 625);
                    aPCB.ShowText(row["S2NG_A5"].ToString());
                    aPCB.EndText();


                    //############################# step 4 ##############################
                    if (row["SetupCheck"].ToString() == "OK")
                    {
                        aPCB.Circle(390, 615, 4.5);
                        aPCB.SetColorStroke(GrayColor.BLUE);
                    }
                    else if (row["SetupCheck"].ToString() == "NG")
                    {
                        aPCB.Circle(405, 615, 4.5);
                        aPCB.SetColorStroke(GrayColor.BLUE);
                    }
                    aPCB.Stroke();



                    //############################## step 5 ############################
                    if (!(string.IsNullOrEmpty(row["ManaulCheck1"].ToString())))
                    {
                        if (row["ManaulCheck1"].ToString() == "SOCKETCHANGE")
                        {
                            //วาดวงรี Draw Oval
                            aPCB.Ellipse(384, 589, 415, 598);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                        else if (row["ManaulCheck1"].ToString() == "REQUESTPM")
                        {
                            //วาดวงรี Draw Oval
                            aPCB.Ellipse(418, 589, 445, 598);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                        else
                        {
                            aPCB.Circle(394, 586, 5);
                            aPCB.SetColorStroke(GrayColor.BLUE);

                            //ข้อความ อื่นๆ
                            aPCB.BeginText();
                            aPCB.SetColorFill(GrayColor.BLUE);
                            aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                            aPCB.SetTextMatrix(408, 585);
                            aPCB.ShowText(row["ManaulCheck1"].ToString());
                            aPCB.EndText();
                        }
                    }
                    aPCB.Stroke();

                    if (!(string.IsNullOrEmpty(row["ManaulCheck2"].ToString())))
                    {
                        //วาดวงรี Draw Oval
                        aPCB.Ellipse(375, 572, 403, 579);
                        aPCB.SetColorStroke(GrayColor.BLUE);
                        aPCB.Stroke();
                    }


                    if (!(string.IsNullOrEmpty(row["ManaulCheck3"].ToString())))
                    {
                        //วาดวงรี Draw Oval
                        aPCB.Ellipse(401, 562, 429, 569);
                        aPCB.SetColorStroke(GrayColor.BLUE);
                        aPCB.Stroke();
                    }



                    //############################### step 6 ################################
                    if (!(string.IsNullOrEmpty(row["SocketChangeHist"].ToString())))
                    {
                        if (row["SocketChangeHist"].ToString() == "WEEK")
                        {
                            //วาดวงรี Draw Oval
                            aPCB.Ellipse(411, 549, 447, 556);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                        else if (row["SocketChangeHist"].ToString() == "OVERWEEK")
                        {
                            //วาดวงรี Draw Oval
                            aPCB.Ellipse(448, 549, 480, 556);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                    }
                    aPCB.Stroke();





                    if (!(string.IsNullOrEmpty(row["SocketChangeLastDate"].ToString())))
                    {
                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                        aPCB.SetTextMatrix(405, 543);
                        aPCB.ShowText(row["SocketChangeLastDate"].ToString());
                        aPCB.EndText();
                    }


                    if (!(string.IsNullOrEmpty(row["IsRestartStep3"].ToString())))
                    {
                        if (row["IsRestartStep3"].ToString() == "YES")
                        {
                            //วาดวงรี Draw Oval
                            aPCB.Ellipse(430, 531, 446, 539);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                        else if (row["IsRestartStep3"].ToString() == "NO")
                        {
                            //วาดวงรี Draw Oval
                            aPCB.Ellipse(448, 531, 465, 539);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                    }
                    aPCB.Stroke();


                    //############################## step 7 #################################
                    if (!(string.IsNullOrEmpty(row["CheckLowYieldKanban"].ToString())))
                    {
                        if (row["CheckLowYieldKanban"].ToString() != "NO" && row["CheckLowYieldKanban"].ToString() != "EXP")
                        {
                            //วาด วงกลม
                            aPCB.Circle(421, 522, 5);
                            aPCB.SetColorStroke(GrayColor.BLUE);


                            //เลข tester
                            aPCB.BeginText();
                            aPCB.SetColorFill(GrayColor.BLUE);
                            aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                            aPCB.SetTextMatrix(475, 520);
                            aPCB.ShowText(row["CheckLowYieldKanban"].ToString());
                            aPCB.EndText();
                        }
                        else if (row["CheckLowYieldKanban"].ToString() == "NO")
                        {
                            //วาด วงกลม
                            aPCB.Circle(448, 522, 5);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                        else if (row["CheckLowYieldKanban"].ToString() == "EXP")
                        {
                            //ข้อวความ หมดอายุ EXP
                            aPCB.BeginText();
                            aPCB.SetColorFill(GrayColor.BLUE);
                            aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                            aPCB.SetTextMatrix(475, 520);
                            aPCB.ShowText(row["CheckLowYieldKanban"].ToString());
                            aPCB.EndText();
                        }
                    }
                    aPCB.Stroke();



                    if (!(string.IsNullOrEmpty(row["CheckAlarmBin"].ToString())))
                    {
                        if (row["CheckAlarmBin"].ToString() == "NO")
                        {
                            //ข้อวความ
                            aPCB.BeginText();
                            aPCB.SetColorFill(GrayColor.BLUE);
                            aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                            aPCB.SetTextMatrix(400, 510);
                            aPCB.ShowText("ไม่มี");
                            aPCB.EndText();
                        }
                        else //if BIN28 - BIN31
                        {
                            //ข้อวความ
                            aPCB.BeginText();
                            aPCB.SetColorFill(GrayColor.BLUE);
                            aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                            aPCB.SetTextMatrix(400, 510);
                            aPCB.ShowText("ไม่มี");
                            aPCB.EndText();

                            aPCB.BeginText();
                            aPCB.SetColorFill(GrayColor.BLUE);
                            aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                            aPCB.SetTextMatrix(480, 510);
                            aPCB.ShowText(row["CheckAlarmBin"].ToString());
                            aPCB.EndText();
                        }
                    }


                    //############################## step 8 #################################
                    if (!(string.IsNullOrEmpty(row["TesterChecker"].ToString())))
                    {
                        if (row["TesterChecker"].ToString() == "OK")
                        {
                            //วาด วงกลม
                            aPCB.Circle(379, 498, 3.5);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                        else if (row["TesterChecker"].ToString() == "NG")
                        {
                            //วาด วงกลม
                            aPCB.Circle(392, 498, 3.5);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                        else if (row["TesterChecker"].ToString() == "NO")
                        {
                            //วาดวงรี Draw Oval
                            aPCB.Ellipse(400, 495, 419, 502);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                    }
                    aPCB.Stroke();



                    if (!(string.IsNullOrEmpty(row["Setup"].ToString())))
                    {
                        if (row["Setup"].ToString() == "OK")
                        {
                            //วาด วงกลม
                            aPCB.Circle(383, 492, 3.5);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                        else if (row["Setup"].ToString() == "NG")
                        {
                            //วาด วงกลม
                            aPCB.Circle(394, 492, 3.5);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                        else if (row["Setup"].ToString() == "NO")
                        {
                            //วาดวงรี Draw Oval
                            aPCB.Ellipse(399, 489, 412, 495);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                    }
                    aPCB.Stroke();

                    //รอ No จาก Web BM 
                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(430, 486);
                    aPCB.ShowText("Refer BM No : ");
                    aPCB.ShowText(row["ControlBMNo"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(379, 479);
                    aPCB.ShowText(row["TNo1"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(406, 479);
                    aPCB.ShowText(row["TNo2"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(431, 479);
                    aPCB.ShowText(row["TNo3"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(458, 479);
                    aPCB.ShowText(row["TNo4"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(484, 479);
                    aPCB.ShowText(row["TNo5"].ToString());
                    aPCB.EndText();


                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(379, 471);
                    aPCB.ShowText(row["LimitLow1"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(406, 471);
                    aPCB.ShowText(row["LimitLow2"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(431, 471);
                    aPCB.ShowText(row["LimitLow3"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(458, 471);
                    aPCB.ShowText(row["LimitLow4"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(484, 471);
                    aPCB.ShowText(row["LimitLow5"].ToString());
                    aPCB.EndText();


                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(379, 463);
                    aPCB.ShowText(row["LimitHigh1"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(406, 463);
                    aPCB.ShowText(row["LimitHigh2"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(431, 463);
                    aPCB.ShowText(row["LimitHigh3"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(458, 463);
                    aPCB.ShowText(row["LimitHigh4"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(484, 463);
                    aPCB.ShowText(row["LimitHigh5"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(379, 455);
                    aPCB.ShowText(row["MassProductNG1"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(406, 455);
                    aPCB.ShowText(row["MassProductNG2"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(431, 455);
                    aPCB.ShowText(row["MassProductNG3"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(458, 455);
                    aPCB.ShowText(row["MassProductNG4"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(484, 455);
                    aPCB.ShowText(row["MassProductNG5"].ToString());
                    aPCB.EndText();


                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(379, 446);
                    aPCB.ShowText(row["GoodSample1"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(406, 446);
                    aPCB.ShowText(row["GoodSample2"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(431, 446);
                    aPCB.ShowText(row["GoodSample3"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(458, 446);
                    aPCB.ShowText(row["GoodSample4"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(484, 446);
                    aPCB.ShowText(row["GoodSample5"].ToString());
                    aPCB.EndText();


                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(379, 438);
                    aPCB.ShowText(row["TesterETC1"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(406, 438);
                    aPCB.ShowText(row["TesterETC2"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(431, 438);
                    aPCB.ShowText(row["TesterETC3"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(458, 438);
                    aPCB.ShowText(row["TesterETC4"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(484, 438);
                    aPCB.ShowText(row["TesterETC5"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(379, 430);
                    aPCB.ShowText(row["CheckRepeat1"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(406, 430);
                    aPCB.ShowText(row["CheckRepeat2"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(431, 430);
                    aPCB.ShowText(row["CheckRepeat3"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(458, 430);
                    aPCB.ShowText(row["CheckRepeat4"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(484, 430);
                    aPCB.ShowText(row["CheckRepeat5"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(379, 422);
                    aPCB.ShowText(row["ProgramName"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(379, 422);
                    aPCB.ShowText(row["ProgramName"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(417, 411);
                    aPCB.ShowText(row["UseMassProductGood"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(463, 411);
                    aPCB.ShowText(row["UseMassProductNG"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(416, 405);
                    aPCB.ShowText(row["ScrapAmountGood"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(462, 405);
                    aPCB.ShowText(row["ScrapAmountNG"].ToString());
                    aPCB.EndText();

                    //########################## step 9 #############################
                    if (!(string.IsNullOrEmpty(row["Cause"].ToString())))
                    {
                        if (row["Cause"].ToString() == "TESTER")
                        {
                            //วาด วงกลม
                            aPCB.Circle(376, 393, 8);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                        else if (row["Cause"].ToString() == "BOX")
                        {
                            //วาด วงกลม
                            aPCB.Circle(397, 393, 8);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                        else if (row["Cause"].ToString() == "OPTION")
                        {
                            //วาด วงกลม
                            aPCB.Circle(418, 393, 8);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                        else if (row["Cause"].ToString() == "OPMISS")
                        {
                            //วาด วงกลม
                            aPCB.Circle(439, 393, 8);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                        else if (row["Cause"].ToString() == "TAKEBACK")
                        {
                            //วาด วงกลม
                            aPCB.Circle(460, 393, 8);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                        else if (row["Cause"].ToString() == "ICBURN")
                        {
                            //วาด วงกลม
                            aPCB.Circle(481, 393, 8);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                        else if (row["Cause"].ToString() == "ETC")
                        {
                            //วาด วงกลม
                            aPCB.Circle(502, 393, 8);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                    }
                    aPCB.Stroke();




                    //########################### step 10 ############################
                    //######################### ACH ##################################
                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(406, 367);
                    aPCB.ShowText(row["S10TestNoA1"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(427, 367);
                    aPCB.ShowText(row["S10TestNoA2"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(448, 367);
                    aPCB.ShowText(row["S10TestNoA3"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(469, 367);
                    aPCB.ShowText(row["S10TestNoA4"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(490, 367);
                    aPCB.ShowText(row["S10TestNoA5"].ToString());
                    aPCB.EndText();


                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(406, 360);
                    aPCB.ShowText(row["S10NGA1"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(427, 360);
                    aPCB.ShowText(row["S10NGA2"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(448, 360);
                    aPCB.ShowText(row["S10NGA3"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(469, 360);
                    aPCB.ShowText(row["S10NGA4"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(490, 360);
                    aPCB.ShowText(row["S10NGA5"].ToString());
                    aPCB.EndText();

                    //#################################### BCH ###########################
                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(406, 354);
                    aPCB.ShowText(row["S10TestNoB1"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(427, 354);
                    aPCB.ShowText(row["S10TestNoB2"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(448, 354);
                    aPCB.ShowText(row["S10TestNoB3"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(469, 354);
                    aPCB.ShowText(row["S10TestNoB4"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(490, 354);
                    aPCB.ShowText(row["S10TestNoB5"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(406, 347);
                    aPCB.ShowText(row["S10NGB1"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(427, 347);
                    aPCB.ShowText(row["S10NGB2"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(448, 347);
                    aPCB.ShowText(row["S10NGB3"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(469, 347);
                    aPCB.ShowText(row["S10NGB4"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(490, 347);
                    aPCB.ShowText(row["S10NGB5"].ToString());
                    aPCB.EndText();


                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 6);
                    aPCB.SetTextMatrix(390, 332);
                    aPCB.ShowText(row["FinalYield"].ToString());
                    aPCB.EndText();


                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 6);
                    aPCB.SetTextMatrix(485, 332);
                    aPCB.ShowText(row["ControlLCL"].ToString());
                    aPCB.EndText();

                    //####################################### step 11 ###########################
                    strSplit = row["AsiGood"].ToString().Split('/');

                    if (strSplit.Length > 1)
                    {
                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                        aPCB.SetTextMatrix(404, 316);
                        aPCB.ShowText(strSplit[0]);
                        aPCB.EndText();

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                        aPCB.SetTextMatrix(420, 316);
                        aPCB.ShowText(strSplit[1]);
                        aPCB.EndText();
                    }



                    strSplit = row["AsiNG"].ToString().Split('/');

                    if (strSplit.Length > 1)
                    {
                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                        aPCB.SetTextMatrix(466, 316);
                        aPCB.ShowText(strSplit[0]);
                        aPCB.EndText();

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                        aPCB.SetTextMatrix(482, 316);
                        aPCB.ShowText(strSplit[1]);
                        aPCB.EndText();
                    }


                    //###### Andon condition ####
                    if (!(string.IsNullOrEmpty(row["AddOn"].ToString())))
                    {
                        if (row["AddOn"].ToString() == "YES")
                        {
                            //วาด วงกลม
                            aPCB.Circle(420, 311, 3.5);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                        else if (row["AddOn"].ToString() == "NO")
                        {
                            //วาด วงกลม
                            aPCB.Circle(441, 311, 3.5);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                    }
                    aPCB.Stroke();


                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(429, 304);
                    aPCB.ShowText(row["AndonManage"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(372, 298);
                    aPCB.ShowText(row["AndonWho"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(380, 280);
                    aPCB.ShowText(row["AndonManageDetail"].ToString());
                    aPCB.EndText();




                    //#################### step 13 #####################
                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(380, 255);
                    aPCB.ShowText(row["KanbanCtrlNo"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(380, 243);
                    aPCB.ShowText(row["KanbanTestNo"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(452, 243);
                    aPCB.ShowText(row["KanbanExpireDate"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(448, 234);
                    aPCB.ShowText(row["TestTotalAmount"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(420, 228);
                    aPCB.ShowText(row["TestResultGood"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(465, 228);
                    aPCB.ShowText(row["TestResultNG"].ToString());
                    aPCB.EndText();

                    // Request AQI Condition
                    if (!(string.IsNullOrEmpty(row["RequestAQIS13"].ToString())))
                    {
                        if (row["RequestAQIS13"].ToString() == "YES")
                        {
                            //วาด วงกลม
                            aPCB.Circle(400, 223, 4);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                        else if (row["RequestAQIS13"].ToString() == "NO")
                        {
                            //วาด วงกลม
                            aPCB.Circle(428, 223, 4);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                    }
                    aPCB.Stroke();

                    //Stop Lot Condition
                    if (!(string.IsNullOrEmpty(row["StopNextLotS13"].ToString())))
                    {
                        if (row["StopNextLotS13"].ToString() == "YES")
                        {
                            //วาดวงรี Draw Oval
                            aPCB.Ellipse(442, 213, 461, 221);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                        else if (row["StopNextLotS13"].ToString() == "NO")
                        {
                            //วาดวงรี Draw Oval
                            aPCB.Ellipse(465, 213, 488, 221);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                    }
                    aPCB.Stroke();

                    //############################ step 14 ##################
                    strSplit = row["ResultBurnGood"].ToString().Split('/');

                    if (strSplit.Length > 1)
                    {
                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                        aPCB.SetTextMatrix(381, 201);
                        aPCB.ShowText(strSplit[0]);
                        aPCB.EndText();

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                        aPCB.SetTextMatrix(391, 201);
                        aPCB.ShowText(strSplit[1]);
                        aPCB.EndText();
                    }


                    strSplit = row["ResultBurnNG"].ToString().Split('/');

                    if (strSplit.Length > 1)
                    {
                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                        aPCB.SetTextMatrix(430, 201);
                        aPCB.ShowText(strSplit[0]);
                        aPCB.EndText();

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                        aPCB.SetTextMatrix(439, 201);
                        aPCB.ShowText(strSplit[1]);
                        aPCB.EndText();
                    }



                    strSplit = row["ResultChipCrackGood"].ToString().Split('/');

                    if (strSplit.Length > 1)
                    {
                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                        aPCB.SetTextMatrix(381, 189);
                        aPCB.ShowText(strSplit[0]);
                        aPCB.EndText();

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                        aPCB.SetTextMatrix(391, 189);
                        aPCB.ShowText(strSplit[1]);
                        aPCB.EndText();
                    }



                    strSplit = row["ResultChipCrackNG"].ToString().Split('/');

                    if (strSplit.Length > 1)
                    {
                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                        aPCB.SetTextMatrix(430, 189);
                        aPCB.ShowText(strSplit[0]);
                        aPCB.EndText();

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                        aPCB.SetTextMatrix(439, 189);
                        aPCB.ShowText(strSplit[1]);
                        aPCB.EndText();
                    }



                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(395, 178);
                    aPCB.ShowText(row["ResultChipMixGood"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(457, 178);
                    aPCB.ShowText(row["ResultChipMixNG"].ToString());
                    aPCB.EndText();

                    //RequestAQIS14 Condition
                    if (!(string.IsNullOrEmpty(row["RequestAQIS14"].ToString())))
                    {
                        if (row["RequestAQIS14"].ToString() == "YES")
                        {
                            //วาด วงกลม
                            aPCB.Circle(409, 174, 3.5);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                        else if (row["RequestAQIS14"].ToString() == "NO")
                        {
                            //วาด วงกลม
                            aPCB.Circle(436, 174, 3.5);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                    }
                    aPCB.Stroke();

                    //StopNextLotS14 Condition
                    if (!(string.IsNullOrEmpty(row["StopNextLotS14"].ToString())))
                    {
                        if (row["StopNextLotS14"].ToString() == "YES")
                        {
                            //วาดวงรี Draw Oval
                            aPCB.Ellipse(443, 164, 462, 172);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                        else if (row["StopNextLotS14"].ToString() == "NO")
                        {
                            //วาดวงรี Draw Oval
                            aPCB.Ellipse(467, 164, 489, 172);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                    }
                    aPCB.Stroke();

                    if (!(string.IsNullOrEmpty(row["StopPKGS14"].ToString())))
                    {
                        if (row["StopPKGS14"].ToString() == "YES")
                        {
                            //วาดวงรี Draw Oval
                            aPCB.Ellipse(406, 158, 424, 164);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                        else if (row["StopPKGS14"].ToString() == "NO")
                        {
                            //วาดวงรี Draw Oval
                            aPCB.Ellipse(435, 158, 454, 164);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                    }
                    aPCB.Stroke();

                    //################ step 15 #######################
                    //RequestAQIS15 Condition
                    if (!(string.IsNullOrEmpty(row["RequestAQIS15"].ToString())))
                    {
                        if (row["RequestAQIS15"].ToString() == "YES")
                        {
                            //วาด วงกลม
                            aPCB.Circle(419, 154, 3.5);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                        else if (row["RequestAQIS15"].ToString() == "NO")
                        {
                            //วาด วงกลม
                            aPCB.Circle(445, 154, 3.5);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                    }
                    aPCB.Stroke();


                    //StopShipObjDevice Condition
                    if (!(string.IsNullOrEmpty(row["StopShipObjDevice"].ToString())))
                    {
                        if (row["StopShipObjDevice"].ToString() == "YES")
                        {
                            //วาด วงกลม
                            aPCB.Circle(450.5, 148.5, 3.5);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                        else if (row["StopShipObjDevice"].ToString() == "NO")
                        {
                            //วาด วงกลม
                            aPCB.Circle(477, 148.5, 3.5);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                    }
                    aPCB.Stroke();


                    //StopLabel Condition
                    if (!(string.IsNullOrEmpty(row["StopLabel"].ToString())))
                    {
                        if (row["StopLabel"].ToString() == "YES")
                        {
                            //วาดวงรี Draw Oval
                            aPCB.Ellipse(417, 139, 436, 145);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                        else if (row["StopLabel"].ToString() == "NO")
                        {
                            //วาดวงรี Draw Oval
                            aPCB.Ellipse(447, 139, 467, 145);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                    }
                    aPCB.Stroke();


                    //################ step 16 ######################
                    if (!(string.IsNullOrEmpty(row["SystemInspection"].ToString())))
                    {
                        if (row["SystemInspection"].ToString() == "OK")
                        {
                            //วาด วงกลม
                            aPCB.Circle(448, 131, 5);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                        else if (row["SystemInspection"].ToString() == "NG")
                        {
                            //วาด วงกลม
                            aPCB.Circle(470, 131, 5);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                    }
                    aPCB.Stroke();


                    //################ step 17 #####################
                    if (!(string.IsNullOrEmpty(row["JudgementResult"].ToString())))
                    {
                        if (row["JudgementResult"].ToString() == "FLOW")
                        {
                            //วาดวงรี Draw Oval
                            aPCB.Ellipse(405, 110, 422, 118);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                        else
                        {
                            //วาดวงรี Draw Oval
                            aPCB.Ellipse(442, 110, 459, 118);
                            aPCB.SetColorStroke(GrayColor.BLUE);

                            //Hold ?
                            aPCB.BeginText();
                            aPCB.SetColorFill(GrayColor.BLUE);
                            aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                            aPCB.SetTextMatrix(465, 112);
                            aPCB.ShowText(row["JudgementResult"].ToString());
                            aPCB.EndText();
                        }
                    }
                    aPCB.Stroke();



                    //################ step 18 #####################
                    strSplit = row["FTRetestGood"].ToString().Split('/');

                    if (strSplit.Length > 1)
                    {
                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                        aPCB.SetTextMatrix(380, 94);
                        aPCB.ShowText(strSplit[0]);
                        aPCB.EndText();

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                        aPCB.SetTextMatrix(395, 94);
                        aPCB.ShowText(strSplit[1]);
                        aPCB.EndText();
                    }



                    strSplit = row["FTRetestGood"].ToString().Split('/');

                    if (strSplit.Length > 1)
                    {
                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                        aPCB.SetTextMatrix(441, 94);
                        aPCB.ShowText(strSplit[0]);
                        aPCB.EndText();

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                        aPCB.SetTextMatrix(456, 94);
                        aPCB.ShowText(strSplit[1]);
                        aPCB.EndText();
                    }



                    if (!(string.IsNullOrEmpty(row["ObjectScope"].ToString())))
                    {
                        if (row["ObjectScope"].ToString() == "YES")
                        {
                            //วาดวงรี Draw Oval
                            aPCB.Ellipse(440, 87, 457, 93);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                        else if (row["ObjectScope"].ToString() == "NO")
                        {
                            //วาดวงรี Draw Oval
                            aPCB.Ellipse(463, 87, 482, 93);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                    }
                    aPCB.Stroke();


                    if (!(string.IsNullOrEmpty(row["StopRecallShipment"].ToString())))
                    {
                        if (row["StopRecallShipment"].ToString() == "YES")
                        {
                            //วาดวงรี Draw Oval
                            aPCB.Ellipse(437, 81, 454, 87);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                        else if (row["StopRecallShipment"].ToString() == "NO")
                        {
                            //วาดวงรี Draw Oval
                            aPCB.Ellipse(459, 81, 478, 87);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                    }
                    aPCB.Stroke();


                    //######################## step 19 ########################
                    if (!(string.IsNullOrEmpty(row["LowYieldAnalysis"].ToString())))
                    {
                        if (row["LowYieldAnalysis"].ToString() == "YES")
                        {
                            //วาด วงกลม
                            aPCB.Circle(453, 71, 4);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                        else if (row["LowYieldAnalysis"].ToString() == "NO")
                        {
                            //วาด วงกลม
                            aPCB.Circle(473, 71, 4);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                    }
                    aPCB.Stroke();


                    //######################### step 20 #########################
                    if (!(string.IsNullOrEmpty(row["StopShipmentPKG"].ToString())))
                    {
                        if (row["StopShipmentPKG"].ToString() == "YES")
                        {
                            //วาดวงรี Draw Oval
                            aPCB.Ellipse(440, 56, 457, 61);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                        else if (row["StopShipmentPKG"].ToString() == "NO")
                        {
                            //วาดวงรี Draw Oval
                            aPCB.Ellipse(463, 56, 482, 61);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                    }
                    aPCB.Stroke();



                    if (!(string.IsNullOrEmpty(row["Assy"].ToString())))
                    {
                        if (row["Assy"].ToString() == "YES")
                        {
                            //วาด วงกลม
                            aPCB.Circle(445, 52, 3.5);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                        else if (row["Assy"].ToString() == "NO")
                        {
                            //วาด วงกลม
                            aPCB.Circle(467, 52, 3.5);
                            aPCB.SetColorStroke(GrayColor.BLUE);
                        }
                    }
                    aPCB.Stroke();



                    //######################### step 21 ###########################
                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(401, 38);
                    aPCB.ShowText(row["QCJudgement"].ToString());
                    aPCB.EndText();


                    //###################### OP1 sign #############################
                    if (string.IsNullOrEmpty(row["OPName1_ID"].ToString()))
                    {
                        //aPCB.EndText();
                        aPCB.SetLineWidth(0.5);
                        aPCB.MoveTo(520, 450);
                        aPCB.LineTo(575, 490);
                        aPCB.SetColorStroke(GrayColor.BLACK);
                        aPCB.Stroke();
                        //aPCB.BeginText();
                    }
                    else
                    {
                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 4);
                        aPCB.SetTextMatrix(528, 733);
                        aPCB.ShowText(row["OPName1_Sign"].ToString());
                        aPCB.EndText();


                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 4);
                        aPCB.SetTextMatrix(540, 723);
                        aPCB.ShowText(row["OPName1_ID"].ToString());
                        aPCB.EndText();


                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 4);
                        aPCB.SetTextMatrix(537, 713);
                        if (!(string.IsNullOrEmpty(row["OPName1_SignDate"].ToString())))
                        {
                            aPCB.ShowText(row["OPName1_SignDate"].ToString().Substring(0, 11));
                        }
                        aPCB.EndText();
                    }


                    //###################### BM sign #############################
                    if (string.IsNullOrEmpty(row["TestIncharge_ID"].ToString()))
                    {
                        //aPCB.EndText();
                        aPCB.SetLineWidth(0.5);
                        aPCB.MoveTo(520, 450);
                        aPCB.LineTo(575, 490);
                        aPCB.SetColorStroke(GrayColor.BLACK);
                        aPCB.Stroke();
                        //aPCB.BeginText();
                    }
                    else
                    {
                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 4);
                        aPCB.SetTextMatrix(528, 478);
                        aPCB.ShowText(row["TestIncharge_Sign"].ToString());
                        aPCB.EndText();

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 4);
                        aPCB.SetTextMatrix(540, 468);
                        aPCB.ShowText(row["TestIncharge_ID"].ToString());
                        aPCB.EndText();


                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 4);
                        aPCB.SetTextMatrix(537, 458);
                        if (!(string.IsNullOrEmpty(row["TestIncharge_SignDate"].ToString())))
                        {
                            aPCB.ShowText(row["TestIncharge_SignDate"].ToString().Substring(0, 11));
                        }
                        aPCB.EndText();

                    }
                    //###################### OP2 sign #############################
                    if (string.IsNullOrEmpty(row["OPName2_ID"].ToString()))
                    {
                        //aPCB.EndText();
                        aPCB.SetLineWidth(0.5);
                        aPCB.MoveTo(520, 348);
                        aPCB.LineTo(575, 386);
                        aPCB.SetColorStroke(GrayColor.BLACK);
                        aPCB.Stroke();
                        //aPCB.BeginText();
                    }
                    else
                    {
                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 4);
                        aPCB.SetTextMatrix(528, 375);
                        aPCB.ShowText(row["OPName2_Sign"].ToString());
                        aPCB.EndText();

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 4);
                        aPCB.SetTextMatrix(540, 365);
                        aPCB.ShowText(row["OPName2_ID"].ToString());
                        aPCB.EndText();

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 4);
                        aPCB.SetTextMatrix(537, 355);
                        if (!(string.IsNullOrEmpty(row["OPName2_SignDate"].ToString())))
                        {
                            aPCB.ShowText(row["OPName2_SignDate"].ToString().Substring(0, 11));
                        }
                        aPCB.EndText();
                    }

                    //###################### GL sign #############################
                    if (string.IsNullOrEmpty(row["GL_ID"].ToString()))
                    {
                        //aPCB.EndText();
                        aPCB.SetLineWidth(0.5);
                        aPCB.MoveTo(520, 285);
                        aPCB.LineTo(575, 322);
                        aPCB.SetColorStroke(GrayColor.BLACK);
                        aPCB.Stroke();
                        //aPCB.BeginText();
                    }
                    else
                    {
                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 4);
                        aPCB.SetTextMatrix(528, 305);
                        aPCB.ShowText(row["GL_Sign"].ToString());
                        aPCB.EndText();


                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 4);
                        aPCB.SetTextMatrix(540, 298);
                        aPCB.ShowText(row["GL_ID"].ToString());
                        aPCB.EndText();


                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 4);
                        aPCB.SetTextMatrix(537, 288);
                        if (!(string.IsNullOrEmpty(row["GL_SignDate"].ToString())))
                        {
                            aPCB.ShowText(row["GL_SignDate"].ToString().Substring(0, 11));
                        }
                        aPCB.EndText();
                    }

                    //###################### QYI1 sign #############################
                    if (string.IsNullOrEmpty(row["AnalysisIncharge_ID"].ToString()))
                    {
                        //aPCB.EndText();
                        aPCB.SetLineWidth(0.5);
                        aPCB.MoveTo(520, 218);
                        aPCB.LineTo(575, 256);
                        aPCB.SetColorStroke(GrayColor.BLACK);
                        aPCB.Stroke();
                        //aPCB.BeginText();
                    }
                    else
                    {
                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 4);
                        aPCB.SetTextMatrix(528, 243);
                        aPCB.ShowText(row["AnalysisIncharge_Sign"].ToString());
                        aPCB.EndText();

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 4);
                        aPCB.SetTextMatrix(540, 233);
                        aPCB.ShowText(row["AnalysisIncharge_ID"].ToString());
                        aPCB.EndText();

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 4);
                        aPCB.SetTextMatrix(537, 223);
                        if (!(string.IsNullOrEmpty(row["AnalysisIncharge_SignDate"].ToString())))
                        {
                            aPCB.ShowText(row["AnalysisIncharge_SignDate"].ToString().Substring(0, 11));
                        }
                        aPCB.EndText();

                    }
                    //###################### QYI2 sign #############################
                    if (string.IsNullOrEmpty(row["TEIncharge_ID"].ToString()))
                    {
                        //aPCB.EndText();
                        aPCB.SetLineWidth(0.5);
                        aPCB.MoveTo(520, 158);
                        aPCB.LineTo(575, 195);
                        aPCB.SetColorStroke(GrayColor.BLACK);
                        aPCB.Stroke();
                        //aPCB.BeginText();
                    }
                    else
                    {
                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 4);
                        aPCB.SetTextMatrix(528, 180);
                        aPCB.ShowText(row["TEIncharge_Sign"].ToString());
                        aPCB.EndText();

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 4);
                        aPCB.SetTextMatrix(540, 170);
                        aPCB.ShowText(row["TEIncharge_ID"].ToString());
                        aPCB.EndText();


                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 4);
                        aPCB.SetTextMatrix(537, 160);
                        if (!(string.IsNullOrEmpty(row["TEIncharge_SignDate"].ToString())))
                        {
                            aPCB.ShowText(row["TEIncharge_SignDate"].ToString().Substring(0, 11));
                        }
                        aPCB.EndText();
                    }

                    //###################### QYI3 sign #############################
                    if (string.IsNullOrEmpty(row["FYIFQIIncharge_ID"].ToString()))
                    {
                        //aPCB.EndText();
                        aPCB.SetLineWidth(0.5);
                        aPCB.MoveTo(520, 92);
                        aPCB.LineTo(575, 132);
                        aPCB.SetColorStroke(GrayColor.BLACK);
                        aPCB.Stroke();
                        //aPCB.BeginText();

                        //QYI3 Top Sign
                        aPCB.SetLineWidth(0.5);
                        aPCB.MoveTo(380, 763);
                        aPCB.LineTo(425, 806);
                        aPCB.SetColorStroke(GrayColor.BLACK);
                        aPCB.Stroke();
                    }
                    else
                    {
                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 4);
                        aPCB.SetTextMatrix(528, 118);
                        aPCB.ShowText(row["FYIFQIIncharge_Sign"].ToString());
                        aPCB.EndText();

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 4);
                        aPCB.SetTextMatrix(540, 108);
                        aPCB.ShowText(row["FYIFQIIncharge_ID"].ToString());
                        aPCB.EndText();

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 4);
                        aPCB.SetTextMatrix(537, 98);
                        if (!(string.IsNullOrEmpty(row["FYIFQIIncharge_SignDate"].ToString())))
                        {
                            aPCB.ShowText(row["FYIFQIIncharge_SignDate"].ToString().Substring(0, 11));
                        }
                        aPCB.EndText();


                        //QYI3 Top Sign
                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 4);
                        aPCB.SetTextMatrix(384, 793);
                        aPCB.ShowText(row["FYIFQIIncharge_Sign"].ToString());
                        aPCB.EndText();

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 4);
                        aPCB.SetTextMatrix(396, 783);
                        aPCB.ShowText(row["FYIFQIIncharge_ID"].ToString());
                        aPCB.EndText();

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 4);
                        aPCB.SetTextMatrix(393, 773);
                        if (!(string.IsNullOrEmpty(row["FYIFQIIncharge_SignDate"].ToString())))
                        {
                            aPCB.ShowText(row["FYIFQIIncharge_SignDate"].ToString().Substring(0, 11));
                        }
                        aPCB.EndText();

                    }
                    //######################## PD Mgr Sign ############################
                    if (string.IsNullOrEmpty(row["PDMgr_ID"].ToString()))
                    {
                        //Top sign
                        //aPCB.EndText();
                        aPCB.SetLineWidth(0.5);
                        aPCB.MoveTo(425, 763);
                        aPCB.LineTo(470, 806);
                        aPCB.SetColorStroke(GrayColor.BLACK);
                        aPCB.Stroke();
                        //aPCB.BeginText();
                    }
                    else
                    {
                        //Top sign
                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 4);
                        aPCB.SetTextMatrix(430, 793);
                        aPCB.ShowText(row["PDMgr_Sign"].ToString());
                        aPCB.EndText();

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 4);
                        aPCB.SetTextMatrix(442, 783);
                        aPCB.ShowText(row["PDMgr_ID"].ToString());
                        aPCB.EndText();

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 4);
                        aPCB.SetTextMatrix(439, 773);
                        if (!(string.IsNullOrEmpty(row["PDMgr_SignDate"].ToString())))
                        {
                            aPCB.ShowText(row["PDMgr_SignDate"].ToString().Substring(0, 11));
                        }
                        aPCB.EndText();
                    }
                    //###################### QC sign #############################
                    if (string.IsNullOrEmpty(row["QCIncharge_ID"].ToString()))
                    {
                        //aPCB.EndText();
                        aPCB.SetLineWidth(0.5);
                        aPCB.MoveTo(520, 30);
                        aPCB.LineTo(575, 70);
                        aPCB.SetColorStroke(GrayColor.BLACK);
                        aPCB.Stroke();
                        //aPCB.BeginText();
                    }
                    else
                    {
                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 4);
                        aPCB.SetTextMatrix(528, 58);
                        aPCB.ShowText(row["QCIncharge_Sign"].ToString());
                        aPCB.EndText();

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 4);
                        aPCB.SetTextMatrix(540, 48);
                        aPCB.ShowText(row["QCIncharge_ID"].ToString());
                        aPCB.EndText();

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 4);
                        aPCB.SetTextMatrix(537, 38);
                        if (!(string.IsNullOrEmpty(row["QCIncharge_SignDate"].ToString())))
                        {
                            aPCB.ShowText(row["QCIncharge_SignDate"].ToString().Substring(0, 11));
                        }
                        aPCB.EndText();

                    }
                    //###################### QC Approve #############################
                    if (string.IsNullOrEmpty(row["QCApprove_ID"].ToString()))
                    {
                        //Top sign
                        aPCB.SetLineWidth(0.5);
                        aPCB.MoveTo(470, 763);
                        aPCB.LineTo(518, 806);
                        aPCB.SetColorStroke(GrayColor.BLACK);
                        aPCB.Stroke();
                    }
                    else
                    {
                        //QC TOP sign
                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 4);
                        aPCB.SetTextMatrix(476, 793);
                        aPCB.ShowText(row["QCApprove_Sing"].ToString());
                        aPCB.EndText();

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 4);
                        aPCB.SetTextMatrix(488, 783);
                        aPCB.ShowText(row["QCApprove_ID"].ToString());
                        aPCB.EndText();

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 4);
                        aPCB.SetTextMatrix(485, 773);
                        if (!(string.IsNullOrEmpty(row["QCApprove_Date"].ToString())))
                        {
                            aPCB.ShowText(row["QCApprove_Date"].ToString().Substring(0, 11));
                        }
                        aPCB.EndText();
                    }
                
            }
            //############## CLOSE PDF ######################
            pdf.Close();
                Response.ClearContent();
                Response.ClearHeaders();
                Response.AddHeader("Content-Disposition", "inline;filename=" + "H_" + Request.Params["MCNo"] + "_" + Request.Params["LotNo"] + ".pdf");
                Response.ContentType = "application/pdf";
                Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
                Response.Flush();
                Response.Clear();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data error ! //n Please contact system.')", true);
            }



        }
    }
}