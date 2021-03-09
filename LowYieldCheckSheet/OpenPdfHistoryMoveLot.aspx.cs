using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LowYieldCheckSheet
{
    public partial class OpenPdfMoveLot : System.Web.UI.Page
    {
        DBAccess dba = new DBAccess();
        GlobalClass gc = new GlobalClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Get data and keep by tbl
            var tbl = new DataTable();

            //Pull Data from table
            tbl = dba.PullMoveLotData(Request.Params["MCNo"], Request.Params["LotNo"]);
            //tbl = dba.PullMoveLotData("FL-F-001", "1817A2290V");


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
                var ReportImg = iTextSharp.text.Image.GetInstance(Server.MapPath("Images") + "/MoveLot.jpg");
                ReportImg.ScalePercent(24);
                ReportImg.SetAbsolutePosition(1, 0); //Position of Image template
                pdf.Add(ReportImg);

                //Picture Tick
                var TickImg = iTextSharp.text.Image.GetInstance(Server.MapPath("Images") + "/tick.png");
                TickImg.ScalePercent(5); //Percent Size of original image


                //#################################### WRITE DATA ################################################
                PdfContentByte aPCB = writer.DirectContent;
                foreach (DataRow row in tbl.Rows)
                {
                    iTextSharp.text.Font iTextFont = FontFactory.GetFont("c:\\windows\\fonts\\Arial.ttf", "Identity-H", 5, iTextSharp.text.Font.BOLD);


                    //############# HEADER #####################
                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 7);
                    aPCB.SetTextMatrix(90, 763);
                    aPCB.ShowText(row["RequestMoveDate"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 7);
                    aPCB.SetTextMatrix(110, 746);
                    aPCB.ShowText(row["DeviceName"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 7);
                    aPCB.SetTextMatrix(110, 731);
                    aPCB.ShowText(row["LotNo"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 7);
                    aPCB.SetTextMatrix(110, 717);
                    aPCB.ShowText(row["MCNo"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 7);
                    aPCB.SetTextMatrix(160, 703);
                    aPCB.ShowText(row["MoveLotReason"].ToString());
                    aPCB.EndText();

                    //######### Bfb ######################################################################

                    // 1
                    if (row["Bfb1"].ToString() == "YES")
                    {
                        TickImg.SetAbsolutePosition(95, 642);
                        pdf.Add(TickImg);

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 7);
                        aPCB.SetTextMatrix(240, 645);
                        aPCB.ShowText(row["Bfb1_TgBefore"].ToString());
                        aPCB.EndText();
                    }
                    else if (row["Bfb1"].ToString() == "NO")
                    {
                        TickImg.SetAbsolutePosition(140, 642);
                        pdf.Add(TickImg);
                    }


                    // 2
                    if (row["Bfb2"].ToString() == "YES")
                    {
                        TickImg.SetAbsolutePosition(95, 628);
                        pdf.Add(TickImg);

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 7);
                        aPCB.SetTextMatrix(240, 631);
                        aPCB.ShowText(row["Bfb2_Good"].ToString());
                        aPCB.EndText();

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 7);
                        aPCB.SetTextMatrix(340, 631);
                        aPCB.ShowText(row["Bfb2_StdReel"].ToString());
                        aPCB.EndText();

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 7);
                        aPCB.SetTextMatrix(450, 631);
                        aPCB.ShowText(row["Bfb2_HasuuReel"].ToString());
                        aPCB.EndText();
                    }
                    else if (row["Bfb2"].ToString() == "NO")
                    {
                        TickImg.SetAbsolutePosition(140, 628);
                        pdf.Add(TickImg);
                    }



                    //3
                    if (row["Bfb3"].ToString() == "YES")
                    {
                        TickImg.SetAbsolutePosition(95, 614);
                        pdf.Add(TickImg);

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 7);
                        aPCB.SetTextMatrix(240, 617);
                        aPCB.ShowText(row["Bfb3_Result"].ToString());
                        aPCB.EndText();
                    }
                    else if (row["Bfb3"].ToString() == "NO")
                    {
                        TickImg.SetAbsolutePosition(140, 614);
                        pdf.Add(TickImg);
                    }



                    //4
                    if (row["Bfb4"].ToString() == "YES")
                    {
                        TickImg.SetAbsolutePosition(95, 600);
                        pdf.Add(TickImg);

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 7);
                        aPCB.SetTextMatrix(240, 603);
                        aPCB.ShowText(row["Bfb4_OS"].ToString());
                        aPCB.EndText();
                    }
                    else if (row["Bfb4"].ToString() == "NO")
                    {
                        TickImg.SetAbsolutePosition(140, 600);
                        pdf.Add(TickImg);
                    }



                    //5
                    if (row["Bfb5"].ToString() == "YES")
                    {
                        TickImg.SetAbsolutePosition(95, 585);
                        pdf.Add(TickImg);

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 7);
                        aPCB.SetTextMatrix(240, 588);
                        aPCB.ShowText(row["Bfb5_FT"].ToString());
                        aPCB.EndText();
                    }
                    else if (row["Bfb5"].ToString() == "NO")
                    {
                        TickImg.SetAbsolutePosition(140, 585);
                        pdf.Add(TickImg);
                    }



                    //6
                    if (row["Bfb6"].ToString() == "YES")
                    {
                        TickImg.SetAbsolutePosition(95, 571);
                        pdf.Add(TickImg);

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 7);
                        aPCB.SetTextMatrix(240, 574);
                        aPCB.ShowText(row["Bfb6_Make"].ToString());
                        aPCB.EndText();
                    }
                    else if (row["Bfb6"].ToString() == "NO")
                    {
                        TickImg.SetAbsolutePosition(140, 571);
                        pdf.Add(TickImg);
                    }



                    //7
                    if (row["Bfb7"].ToString() == "YES")
                    {
                        TickImg.SetAbsolutePosition(95, 557);
                        pdf.Add(TickImg);

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 7);
                        aPCB.SetTextMatrix(240, 560);
                        aPCB.ShowText(row["Bfb7_Marker"].ToString());
                        aPCB.EndText();
                    }
                    else if (row["Bfb7"].ToString() == "NO")
                    {
                        TickImg.SetAbsolutePosition(140, 557);
                        pdf.Add(TickImg);
                    }



                    //8
                    if (row["Bfb8"].ToString() == "YES")
                    {
                        TickImg.SetAbsolutePosition(95, 542);
                        pdf.Add(TickImg);

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 7);
                        aPCB.SetTextMatrix(240, 545);
                        aPCB.ShowText(row["Bfb8_TP"].ToString());
                        aPCB.EndText();
                    }
                    else if (row["Bfb8"].ToString() == "NO")
                    {
                        TickImg.SetAbsolutePosition(140, 542);
                        pdf.Add(TickImg);
                    }



                    //9
                    if (row["Bfb9"].ToString() == "YES")
                    {
                        TickImg.SetAbsolutePosition(95, 528);
                        pdf.Add(TickImg);

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 7);
                        aPCB.SetTextMatrix(240, 531);
                        aPCB.ShowText(row["Bfb9_Missing"].ToString());
                        aPCB.EndText();
                    }
                    else if (row["Bfb9"].ToString() == "NO")
                    {
                        TickImg.SetAbsolutePosition(140, 528);
                        pdf.Add(TickImg);
                    }



                    // 10
                    if (row["Bfb10"].ToString() == "YES")
                    {
                        TickImg.SetAbsolutePosition(95, 514);
                        pdf.Add(TickImg);
                    }
                    else if (row["Bfb10"].ToString() == "NO")
                    {
                        TickImg.SetAbsolutePosition(140, 514);
                        pdf.Add(TickImg);
                    }

                    //Total
                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 7);
                    aPCB.SetTextMatrix(200, 489);
                    aPCB.ShowText(row["BfbTotal"].ToString());
                    aPCB.EndText();




                    //######### Bsr ################################################################

                    // 1
                    if (row["Bsr1"].ToString() == "YES")
                    {
                        TickImg.SetAbsolutePosition(95, 385);
                        pdf.Add(TickImg);

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 7);
                        aPCB.SetTextMatrix(240, 388);
                        aPCB.ShowText(row["Bsr1_TgBefore"].ToString());
                        aPCB.EndText();
                    }
                    else if (row["Bsr1"].ToString() == "NO")
                    {
                        TickImg.SetAbsolutePosition(140, 385);
                        pdf.Add(TickImg);
                    }




                    // 2
                    if (row["Bsr2"].ToString() == "YES")
                    {
                        TickImg.SetAbsolutePosition(95, 371);
                        pdf.Add(TickImg);

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 7);
                        aPCB.SetTextMatrix(240, 374);
                        aPCB.ShowText(row["Bsr2_Good"].ToString());
                        aPCB.EndText();

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 7);
                        aPCB.SetTextMatrix(340, 374);
                        aPCB.ShowText(row["Bsr2_StdReel"].ToString());
                        aPCB.EndText();

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 7);
                        aPCB.SetTextMatrix(450, 374);
                        aPCB.ShowText(row["Bsr2_HasuuReel"].ToString());
                        aPCB.EndText();
                    }
                    else if (row["Bsr2"].ToString() == "NO")
                    {
                        TickImg.SetAbsolutePosition(140, 371);
                        pdf.Add(TickImg);
                    }



                    //3
                    if (row["Bsr3"].ToString() == "YES")
                    {
                        TickImg.SetAbsolutePosition(95, 357);
                        pdf.Add(TickImg);

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 7);
                        aPCB.SetTextMatrix(240, 360);
                        aPCB.ShowText(row["Bsr3_Result"].ToString());
                        aPCB.EndText();
                    }
                    else if (row["Bsr3"].ToString() == "NO")
                    {
                        TickImg.SetAbsolutePosition(140, 357);
                        pdf.Add(TickImg);
                    }



                    //4
                    if (row["Bsr4"].ToString() == "YES")
                    {
                        TickImg.SetAbsolutePosition(95, 343);
                        pdf.Add(TickImg);

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 7);
                        aPCB.SetTextMatrix(240, 346);
                        aPCB.ShowText(row["Bsr4_OS"].ToString());
                        aPCB.EndText();
                    }
                    else if (row["Bsr4"].ToString() == "NO")
                    {
                        TickImg.SetAbsolutePosition(140, 343);
                        pdf.Add(TickImg);
                    }



                    //5
                    if (row["Bsr5"].ToString() == "YES")
                    {
                        TickImg.SetAbsolutePosition(95, 328);
                        pdf.Add(TickImg);

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 7);
                        aPCB.SetTextMatrix(240, 331);
                        aPCB.ShowText(row["Bsr5_FT"].ToString());
                        aPCB.EndText();
                    }
                    else if (row["Bsr5"].ToString() == "NO")
                    {
                        TickImg.SetAbsolutePosition(140, 328);
                        pdf.Add(TickImg);
                    }



                    //6
                    if (row["Bsr6"].ToString() == "YES")
                    {
                        TickImg.SetAbsolutePosition(95, 314);
                        pdf.Add(TickImg);

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 7);
                        aPCB.SetTextMatrix(240, 317);
                        aPCB.ShowText(row["Bsr6_Make"].ToString());
                        aPCB.EndText();
                    }
                    else if (row["Bsr6"].ToString() == "NO")
                    {
                        TickImg.SetAbsolutePosition(140, 314);
                        pdf.Add(TickImg);
                    }



                    //7
                    if (row["Bsr7"].ToString() == "YES")
                    {
                        TickImg.SetAbsolutePosition(95, 300);
                        pdf.Add(TickImg);

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 7);
                        aPCB.SetTextMatrix(240, 303);
                        aPCB.ShowText(row["Bsr7_Marker"].ToString());
                        aPCB.EndText();
                    }
                    else if (row["Bsr7"].ToString() == "NO")
                    {
                        TickImg.SetAbsolutePosition(140, 300);
                        pdf.Add(TickImg);
                    }



                    //8
                    if (row["Bsr8"].ToString() == "YES")
                    {
                        TickImg.SetAbsolutePosition(95, 286);
                        pdf.Add(TickImg);

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 7);
                        aPCB.SetTextMatrix(240, 289);
                        aPCB.ShowText(row["Bsr8_TP"].ToString());
                        aPCB.EndText();
                    }
                    else if (row["Bsr8"].ToString() == "NO")
                    {
                        TickImg.SetAbsolutePosition(140, 286);
                        pdf.Add(TickImg);
                    }



                    //9
                    if (row["Bsr9"].ToString() == "YES")
                    {
                        TickImg.SetAbsolutePosition(95, 271);
                        pdf.Add(TickImg);

                        aPCB.BeginText();
                        aPCB.SetColorFill(GrayColor.BLUE);
                        aPCB.SetFontAndSize(iTextFont.BaseFont, 7);
                        aPCB.SetTextMatrix(240, 274);
                        aPCB.ShowText(row["Bsr9_Missing"].ToString());
                        aPCB.EndText();
                    }
                    else if (row["Bsr9"].ToString() == "NO")
                    {
                        TickImg.SetAbsolutePosition(140, 271);
                        pdf.Add(TickImg);
                    }


                    // 10
                    if (row["Bsr10"].ToString() == "YES")
                    {
                        TickImg.SetAbsolutePosition(95, 257);
                        pdf.Add(TickImg);
                    }
                    else if (row["Bsr10"].ToString() == "NO")
                    {
                        TickImg.SetAbsolutePosition(140, 257);
                        pdf.Add(TickImg);
                    }

                    //Total
                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 7);
                    aPCB.SetTextMatrix(200, 232);
                    aPCB.ShowText(row["BsrTotal"].ToString());
                    aPCB.EndText();



                    //################################## User Sign ###########################

                    //OP1 TOP Right
                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 4);
                    aPCB.SetTextMatrix(445, 740);
                    aPCB.ShowText(row["OP1_Sign"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(445, 730);
                    aPCB.ShowText(row["OP1_ID"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(445, 720);
                    if (!(string.IsNullOrEmpty(row["OP1_SignDate"].ToString())))
                    {
                        aPCB.ShowText(row["OP1_SignDate"].ToString().Substring(0, 11));
                    }
                    aPCB.EndText();

                    //OP1 move lot no
                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 7);
                    aPCB.SetTextMatrix(145, 461);
                    aPCB.ShowText(row["OP1_ID"].ToString());
                    aPCB.EndText();

                    //OP1
                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 7);
                    aPCB.SetTextMatrix(232, 461);
                    aPCB.ShowText(row["OP1_Sign"].ToString());
                    aPCB.EndText();

                    //GL1
                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 7);
                    aPCB.SetTextMatrix(410, 461);
                    aPCB.ShowText(row["GL1_Sign"].ToString());
                    aPCB.EndText();

                    //OP2 TOP Right
                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 4);
                    aPCB.SetTextMatrix(498, 740);
                    aPCB.ShowText(row["OP2_Sign"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(498, 730);
                    aPCB.ShowText(row["OP2_ID"].ToString());
                    aPCB.EndText();

                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 5);
                    aPCB.SetTextMatrix(498, 720);
                    if (!(string.IsNullOrEmpty(row["OP2_SignDate"].ToString())))
                    {
                        aPCB.ShowText(row["OP2_SignDate"].ToString().Substring(0, 11));
                    }
                    aPCB.EndText();

                    //OP2 move lot no
                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 7);
                    aPCB.SetTextMatrix(145, 203);
                    aPCB.ShowText(row["OP2_ID"].ToString());
                    aPCB.EndText();

                    //OP2
                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 7);
                    aPCB.SetTextMatrix(232, 203);
                    aPCB.ShowText(row["OP2_Sign"].ToString());
                    aPCB.EndText();

                    //GL2
                    aPCB.BeginText();
                    aPCB.SetColorFill(GrayColor.BLUE);
                    aPCB.SetFontAndSize(iTextFont.BaseFont, 7);
                    aPCB.SetTextMatrix(410, 203);
                    aPCB.ShowText(row["GL2_Sign"].ToString());
                    aPCB.EndText();


                }


                //############## CLOSE PDF ######################
                pdf.Close();

                Response.ClearContent();
                Response.ClearHeaders();
                Response.AddHeader("Content-Disposition", "inline;filename=" + "ML_" + Request.Params["MCNo"] + "_" + Request.Params["LotNo"] + ".pdf");
                Response.ContentType = "application/pdf";
                Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
                Response.Flush();
                Response.Clear();

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('This lot not has move lot data !!!!!')", true);
            }





        }
    }
}