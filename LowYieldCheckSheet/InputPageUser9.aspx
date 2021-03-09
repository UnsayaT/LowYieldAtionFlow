<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="InputPageUser9.aspx.cs" Inherits="LowYieldCheckSheet.InputPageUser9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <%-- CSS --%>
    <style>
        .blackLine {
            border: 1px solid black;
            height: 32px;
        }

        .wide {
            height: 33px;
            width: 100%;
            min-width: 100%;
            border: 1px solid black;
        }

        .wide1 {
            width: 200px;
        }

        .wideOnly {
            width: 100%;
            min-width: 100%;
            border: 1px solid black;
        }

        .setReadOnly {
            pointer-events: none;
        }

        .BgColData {
            background-color: #fffc6a
        }

        .SetCenter {
            margin-left: auto;
            margin-right: auto;
            text-align: center
        }
    </style>

    <script type="text/javascript">

        function onlyNumbersWithSlash(event, value) {
            var charCode;
            if (event.keyCode > 0) {
                charCode = event.which || event.keyCode;
            }
            else if (typeof (event.charCode) != "undefined") {
                charCode = event.which || event.keyCode;
            }

            //if input Slash "/"
            if (charCode == 47) {
                //check value if value.indexOf("/") == -1     it's mean no "/" in value
                if (value.indexOf("/") == -1) {
                    return true;
                }
            }

            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                alert(" Please input number or single slash('/') !!");
                return false;
            }
            else return true;
        }
    </script>


    <div class="jumbotron">
        <h1 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold;">LOW YIELD/Burn (Bin 29-31) ACTION FLOW CHECK SHEET</h1>
    </div>

    <div class="SetCenter">
        <asp:Label CssClass="text-white bg-danger h1" runat="server" ID="lblRequestType"></asp:Label>
    </div>

    <br />

    <button class="btn btn-dark btn-lg btn-block" type="button" data-toggle="collapse" data-target="#CL1" aria-expanded="false" aria-controls="collapseExample">
        <h3>User Stamp</h3>
    </button>
    <div class="collapse" id="CL1">
        <div class="card card-body">

            <div class="row">
                <div class="card badge-primary text-center mb-3 wide1 mx-auto">
                    <div class="card-header">
                        <h5>OP Name</h5>
                        <p>(1 2 3 4 5 6 7)</p>
                    </div>
                    <asp:Label ID="lblStampOP1A1" runat="server" CssClass="form-control wide "></asp:Label>
                    <asp:Label ID="lblStampOP1A2" runat="server" CssClass="form-control wide "></asp:Label>
                    <asp:Label ID="lblStampOP1A3" runat="server" CssClass="form-control wide "></asp:Label>
                </div>


                <div class="card badge-primary text-center mb-3 wide1  mx-auto">
                    <div class="card-header">
                        <h5>Test Incharge</h5>
                        <p>(8 9)</p>
                    </div>
                    <asp:Label ID="lblStampBMA1" runat="server" CssClass="form-control wide"></asp:Label>
                    <asp:Label ID="lblStampBMA2" runat="server" CssClass="form-control wide"></asp:Label>
                    <asp:Label ID="lblStampBMA3" runat="server" CssClass="form-control wide"></asp:Label>
                </div>


                <div class="card badge-primary text-center mb-3 wide1 mx-auto">
                    <div class="card-header">
                        <h5>OP Name</h5>
                        <p>(10 11)</p>
                    </div>
                    <asp:Label ID="lblStampOP2A1" runat="server" CssClass="form-control wide"></asp:Label>
                    <asp:Label ID="lblStampOP2A2" runat="server" CssClass="form-control wide"></asp:Label>
                    <asp:Label ID="lblStampOP2A3" runat="server" CssClass="form-control wide"></asp:Label>
                </div>


                <div class="card badge-primary text-center mb-3 mx-auto">
                    <div class="card-header">
                        <h5>GL</h5>
                        <p>(10 11 15 18 20)</p>
                    </div>
                    <asp:Label ID="lblStampGLA1" runat="server" CssClass="form-control wide"></asp:Label>
                    <asp:Label ID="lblStampGLA2" runat="server" CssClass="form-control wide"></asp:Label>
                    <asp:Label ID="lblStampGLA3" runat="server" CssClass="form-control wide"></asp:Label>
                </div>

            </div>


            <div class="row">
                <div class="card badge-primary text-center mb-3 wide1 mx-auto">
                    <div class="card-header">
                        <h5>Analysis Incharge</h5>
                        <p>(13 14 15 17 18 20)</p>
                    </div>
                    <asp:Label ID="lblStampQYI1A1" runat="server" CssClass="form-control wide"></asp:Label>
                    <asp:Label ID="lblStampQYI1A2" runat="server" CssClass="form-control wide"></asp:Label>
                    <asp:Label ID="lblStampQYI1A3" runat="server" CssClass="form-control wide"></asp:Label>
                </div>


                <div class="card badge-primary text-center mb-3 wide1 mx-auto">
                    <div class="card-header">
                        <h5>FYI/FQI Incharge</h5>
                        <p>(17 19)</p>
                    </div>
                    <asp:Label ID="lblStampQYI3A1" runat="server" CssClass="form-control wide"></asp:Label>
                    <asp:Label ID="lblStampQYI3A2" runat="server" CssClass="form-control wide"></asp:Label>
                    <asp:Label ID="lblStampQYI3A3" runat="server" CssClass="form-control wide"></asp:Label>
                </div>


                <div class="card badge-primary text-center mb-3 wide1 mx-auto">
                    <div class="card-header">
                        <h5>PD Mgr.</h5>
                        <p>(Sign)</p>
                    </div>
                    <asp:Label ID="lblStampPDMGRA1" runat="server" CssClass="form-control wide"></asp:Label>
                    <asp:Label ID="lblStampPDMGRA2" runat="server" CssClass="form-control wide"></asp:Label>
                    <asp:Label ID="lblStampPDMGRA3" runat="server" CssClass="form-control wide"></asp:Label>
                </div>

            </div>
            <%--<div class="card badge-primary text-center mb-3 wide1">
                    <div class="card-header">
                        <h5>QC Incharge</h5>
                        <p>(15 18 20 21)</p>
                    </div>
                    <asp:Label ID="lblStamp15" runat="server" CssClass="form-control wide text-center"></asp:Label>
                    <asp:Label ID="lblStamp16" runat="server" CssClass="form-control wide text-center"></asp:Label>
                </div>--%>
        </div>

    </div>

    <button class="btn btn-dark btn-lg btn-block" type="button" data-toggle="collapse" data-target="#CL2" aria-expanded="false" aria-controls="collapseExample">
        <h3>Flow & Information</h3>
    </button>
    <div class="collapse" id="CL2">
        <div class="card card-body">
            <div class="table-responsive">
                <table class="table table-striped table-bordered">
                    <thead class="thead-dark">
                        <tr>
                            <th>Flow Chart</th>
                            <th>Details</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td rowspan="21">
                                <img src="Images/FlowChart20180216.png">
                            </td>
                            <td>1.)เช็คดูว่าในตอนแรกและในขณะที่ทำการ TEST นั้น Final Yield มีค่าเกิน Yield ที่ควบคุมอยู่หรือไม่
                            </td>
                        </tr>
                        <tr>
                            <td>2.)ให้เช็ค NG Test No. แล้วกรอก Test No. Worst 1,2,3,4,5
                            </td>
                        </tr>
                        <tr>
                            <td>3.)ให้เช็ค NG Tester No. เวลาที่เกิด NG ที่ต่างไปจากทุกครั้ง แล้วกรอก Test No. Worst 1,2,3,4,5 ลงในทุกๆ Channel
                            </td>
                        </tr>
                        <tr>
                            <td>4.)ตรวจสอบดูว่าได้ SET UP ถูกต้องหรือไม่
                            </td>
                        </tr>
                        <tr>
                            <td>5.)เช็ค Mass Production Good & NG ด้วย Manual Socket แล้วตรวจสอบดูว่า
                                        Socket Lead Press และ M/C นั้นมีปัญหาหรือไม่ ถ้ามีให้ Action ด้วย<br />
                                #กรณีงาน Good จากการทำ Manual Check เป็น NG ให้แนบชิ้นงานนั้นไปกับ PM Request Sheet
                            </td>
                        </tr>
                        <tr>
                            <td>6.)กรอก History การเปลี่ยน Socket และถ้ามี Good Mixing ให้ทำการ Retest แล้วกรอกเหตุผลนั้นๆ</td>
                        </tr>
                        <tr>
                            <td>7.)Check Tester ว่ามีการลงทะเบียนไว้ที่ Low Yield kanban Ledger</td>
                        </tr>
                        <tr>
                            <td>8.)เช็คดูว่ามีปัญหาเกี่ยวกับการ Tester หรือไม่
                                        <br />
                                &nbsp;&nbsp;
                                           1.NG Mass product
                                        <br />
                                &nbsp;&nbsp;
                                           2.Good Sample<br />
                                &nbsp;&nbsp;
                                           3.ตรวจสอบแยก Tester (งาน Mass Product NG)<br />
                                Retest ซ้ำ(Good Sample) เพื่อตรวจสอบ Program<br />
                                *3.Pass จากการตรวจสอบแยก Tester หรือเมื่อ Data มีความแตกต่างมาก</td>
                        </tr>
                        <tr>
                            <td>9.)เลือกสาเหตุที่เกี่ยวข้องหลังจากซ่อมบำรุงเสร็จ
                                        <br />
                                *ถ้าเป็นสาเหตุเกี่ยวกับ Tester,Test Box ให้ขอทำ Retest
                            </td>
                        </tr>
                        <tr>
                            <td>10.)ตอนจบ Lot ให้ Check Summary กับ Yield</td>
                        </tr>
                        <tr>
                            <td>11.)Lot ที่ Yield  <= 90% ให้นำ Good มา Retest !! (N=100pcs ขึ้นไป)<br />
                                *สำหรับ Good NG ให้นำไป Hold ไว้ที่ Low yield hold area
                                        *ในกรณีที่พบ NG แม้แต่ 1 ตัวให้กด Add on ทันที !
                            </td>
                        </tr>
                        <tr>
                            <td>12.)NG ที่เกิดขึ้นนั้น ให้นำมาตรวจสอบว่ามี IC Burn หรือไม่ (ให้ทดสอบไม่เกิน 100 pcs)</td>
                        </tr>
                        <tr>
                            <td>13.)นำ NG ทั้งหมดมาตรวจสอบแบบ Manual
                                        <br />
                                *ให้ทดสอบไม่เกิน 100 pcs
                                        <br />
                                *ในกรณีที่พบ NG แม้แต่ 1 ตัว ให้ออก AQI ทันที และให้ Stop Lot ที่จะผลิตต่อไป
                            </td>
                        </tr>
                        <tr>
                            <td>14.)ให้ทำการตรวจสอบว่ามี Chip Crack, Chip Kake และ Chip Surface
                                          FT Good 1 Pcs ขึ้นไป : NG อย่างละ = 5 pcs<br />
                                **ในกรณีที่มี Burn แม้แต่ 1 pcs ก็ตามให้ Request ตรวจสอบเครื่องจักรที่เกี่ยวข้องทันที<br />
                                *กรณีที่พบ Chip Crack, Chip Kake ให้ทำการ Stop Shipment PKG นั้นออก AQI และรายงาน QC อย่างทันที<br />
                                #เมื่อ Analysis Check ใน O/S NG กรณีที่ไม่สามารถพบโดยการเช็คด้วยกล้อง Microscope ให้ทำการวิเคราะห์ด้วย LCD ใน FT<br />
                                #เวลาที่ทำการตรวจสอบ Chip Mixingต้องตรวจสอบว่า Aluminum Pattern No. ของ FT Good เหมือนกับ Aluminum Pattern No. ของ NG ในกรณีไม่มี FT Good ให้ตรวจสอบกับ QC Spec.
                            </td>
                        </tr>
                        <tr>
                            <td>15.)เวลาที่เกิด IC Burn ที่นอกจากการเกิด Bin 31 ให้แจ้ง QC โดยด่วน (ออก AQI)
                                        <br />
                                จัดการ Stop Shipment ของ Object Device(Stop การออก Label)
                                        (QC,Production,IC Burn Analysis G)
                            </td>
                        </tr>
                        <tr>
                            <td>16.)ตรวจสอบว่ามีปัญหาหรือไม่ในการ Test ตาม "IC Burn Investigation Form"   
                                        รวมทั้งการทำการประกันชิ้นงาน Good
                            </td>
                        </tr>
                        <tr>
                            <td>17.)80% <= YLD <= LCL  ----> ให้ Flow งาน Good ได้        
                                        YLD <= 80%   ----> LOT HOLD
                            </td>
                        </tr>
                        <tr>
                            <td>18.)ตรวจสอบว่ามีชิ้นงาน IC Burn ปะปนอยู่ในชิ้นงานGood หรือไม่แล้วทำการ
                                         ประกัน Lot และชี้ขอบเขตเป้าหมายที่แน่นอน ที่จำเป็นต้อง Stop Shipment 
                                         กับ Recall (QC,Production,IC Burn Analysis G)
                            </td>
                        </tr>
                        <tr>
                            <td>19.)ให้ออกใบ FT Abnormal Lot Report Form แจ้งไป Rohm QC </td>
                        </tr>
                        <tr>
                            <td>20.)ดำเนินการตรวจสอบแนวโน้มของ  Assy ของ M/C แล้วตรวจเช็คว่า
                                        มีความผิดปกติหรือไม่ (QC,Production,IC Burn Analysis G)
                            </td>
                        </tr>
                        <tr>
                            <td>21.)QC ดำเนินการ Judgement (การสั่ง Flow,ชี้ขอบเขต,เป้าหมาย,
                                        การ Treatment Object Lot หรือ Lot ที่เข้าข่าย) สำหรับ Oversea Factory 
                                        นั้นการตัดสินขั้นสุดท้าย (Final Judgement) ให้ดำเนินการโดย R/K QC
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>


    <button class="btn btn-dark btn-lg btn-block" type="button" data-toggle="collapse" data-target="#CL3" aria-expanded="false" aria-controls="collapseExample">
        <h3>Pre Data</h3>
    </button>
    <div class="collapse" id="CL3">
        <div class="card card-body setReadOnly">

            <div class="card">
                <div class="card-header"><b>NG (PCS) :</b></div>
                <asp:TextBox ID="tbHead1" runat="server" CssClass="form-control wide" Enabled="false"></asp:TextBox>
            </div>


            <br />
            <div class="card">
                <div class="card-header"><b>Handler No. :</b></div>
                <asp:TextBox ID="tbHead2" runat="server" CssClass="form-control wide" Enabled="false"></asp:TextBox>
            </div>

            <br />

            <div class="card">
                <div class="card-header"><b>Lot No. :</b></div>
                <asp:TextBox ID="tbHead3" runat="server" CssClass="form-control wide" Enabled="false"></asp:TextBox>
            </div>

            <br />

            <div class="card">
                <div class="card-header"><b>Package Name :</b></div>
                <asp:TextBox ID="tbHead4" runat="server" BorderColor="Black" CssClass="form-control wide" Height="30px" Enabled="false"></asp:TextBox>
            </div>

            <br />

            <div class="card">
                <div class="card-header"><b>Device Name :</b></div>
                <asp:TextBox ID="tbHead5" runat="server" CssClass="form-control wide" Enabled="false"></asp:TextBox>
            </div>


            <br />
            <div class="card">
                <div class="card-header"><b>Flow :</b></div>
                <select class="custom-select wide" id="headSelect1" name="headSelect1" runat="server" disabled>
                    <option selected>Please Select</option>
                    <option>Auto 1</option>
                    <option>Auto 2</option>
                    <option>Auto 3</option>
                    <option>Auto 4</option>
                </select>
            </div>


            <br />
            <div class="card">
                <div class="card-header"><b>M No. :</b></div>
                <asp:TextBox ID="tbHead6" runat="server" CssClass="form-control wide" Enabled="false"></asp:TextBox>
            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>Tester No. :</b></div>
                <asp:TextBox ID="tbHead7" runat="server" CssClass="form-control wide" Enabled="false"></asp:TextBox>
            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>Box No. :</b></div>
                <asp:TextBox ID="tbHead8" runat="server" CssClass="form-control wide" Enabled="false"></asp:TextBox>
            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>T Rank :</b></div>
                <asp:TextBox ID="tbHead9" runat="server" CssClass="form-control wide" Enabled="false"></asp:TextBox>
            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>Wafer Lot No. :</b></div>
                <asp:TextBox ID="tbHead10" runat="server" CssClass="form-control wide" Enabled="false"></asp:TextBox>
            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>Wafer แผ่นที่ :</b></div>
                <asp:TextBox ID="tbHead11" runat="server" CssClass="form-control wide" Enabled="false"></asp:TextBox>
            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>T/P Rank :</b></div>
                <asp:TextBox ID="tbHead12" runat="server" CssClass="form-control wide" Enabled="false"></asp:TextBox>
            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>Shipment :</b></div>
                <select class="custom-select wide" id="headSelect2" name="headSelect2" runat="server" disabled>
                    <option selected>Please Select</option>
                    <option>Japan</option>
                    <option>Oversea</option>
                </select>
            </div>

            <br />


            <div class="p-3 mb-2 bg-dark text-white">
                <h4>STEP 1</h4>
            </div>

            <div class="card">
                <div class="card-header"><b>Input Quantity (PCS)</b></div>
                <asp:TextBox ID="tbS1A1" runat="server" CssClass="form-control wide" placeholder="PCS" Enabled="false"></asp:TextBox>
            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>Control Yield (%)</b></div>
                <asp:TextBox ID="tbS1A2" runat="server" CssClass="form-control wide" placeholder="%" Enabled="false"></asp:TextBox>
            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>Initial Yield (%) :</b></div>
                <asp:TextBox ID="tbS1A3" runat="server" CssClass="form-control wide" placeholder="%" Enabled="false"></asp:TextBox>

            </div>


            <br />
            <div class="card">
                <div class="card-header"><b>Check (%) :</b></div>
                <asp:TextBox ID="tbS1A4" runat="server" CssClass="form-control wide" placeholder="%" Enabled="false"></asp:TextBox>
            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>Action (PCS)</b></div>
                <asp:TextBox ID="tbS1A5" runat="server" CssClass="form-control wide" placeholder="PCS" Enabled="false"></asp:TextBox>
            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>Action (%)</b></div>
                <asp:TextBox ID="tbS1A6" runat="server" CssClass="form-control wide" placeholder="%" Enabled="false"></asp:TextBox>
            </div>

            <br />
            <div class="p-3 mb-2 bg-dark text-white">
                <h4>STEP 2,3</h4>
            </div>


            <h5 class="bg-dark text-white text-center">ตอน Action</h5>

            <table class="table table-striped">
                <thead class="thead-dark">
                    <tr>
                        <th scope="col"></th>
                        <th scope="col"></th>
                        <th scope="col" class="text-center">Worst 1</th>
                        <th scope="col" class="text-center">Worst 2</th>
                        <th scope="col" class="text-center">Worst 3</th>
                        <th scope="col" class="text-center">Worst 4</th>
                        <th scope="col" class="text-center">Worst 5</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <th rowspan="2" class="align-middle">Ach</th>
                        <th scope="col">Test No.</th>
                        <td>
                            <asp:TextBox ID="tbS2r1c1" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS2r1c2" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS2r1c3" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS2r1c4" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS2r1c5" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th scope="col">จำนวน NG (PCS)</th>
                        <td>
                            <asp:TextBox ID="tbS2r2c1" runat="server" CssClass="form-control blackLine" placeholder="pcs" Enabled="false"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS2r2c2" runat="server" CssClass="form-control blackLine" placeholder="pcs" Enabled="false"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS2r2c3" runat="server" CssClass="form-control blackLine" placeholder="pcs" Enabled="false"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS2r2c4" runat="server" CssClass="form-control blackLine" placeholder="pcs" Enabled="false"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS2r2c5" runat="server" CssClass="form-control blackLine" placeholder="pcs" Enabled="false"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th rowspan="2" class="align-middle">Bch</th>
                        <th scope="col">Test No.</th>
                        <td>
                            <asp:TextBox ID="tbS2r3c1" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS2r3c2" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS2r3c3" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS2r3c4" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS2r3c5" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th scope="col">จำนวน NG (PCS)</th>
                        <td>
                            <asp:TextBox ID="tbS2r4c1" runat="server" CssClass="form-control blackLine" placeholder="pcs" Enabled="false"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS2r4c2" runat="server" CssClass="form-control blackLine" placeholder="pcs" Enabled="false"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS2r4c3" runat="server" CssClass="form-control blackLine" placeholder="pcs" Enabled="false"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS2r4c4" runat="server" CssClass="form-control blackLine" placeholder="pcs" Enabled="false"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS2r4c5" runat="server" CssClass="form-control blackLine" placeholder="pcs" Enabled="false"></asp:TextBox></td>
                    </tr>
                </tbody>
            </table>

            <br />
            <div class="p-3 mb-2 bg-dark text-white">
                <h4>STEP 4</h4>
            </div>
            <div class="card">
                <div class="card-header"><b>SET UP CHECK</b></div>
                <select class="custom-select wide" id="SelectS4" name="SelectS4" runat="server" disabled>
                    <option selected>Please Select</option>
                    <option>OK</option>
                    <option>NG</option>
                </select>
            </div>

            <br />
            <div class="p-3 mb-2 bg-dark text-white">
                <h4>STEP 5</h4>
            </div>
            <div class="card">
                <div class="card-header"><b>Manual Check</b></div>
            </div>

            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="card">
                        <div class="card-header">
                            <asp:CheckBox ID="cbStep5_1" runat="server" Text="  1.Mass NG --> Good" AutoPostBack="true"  Enabled="false"/>
                        </div>
                        <div class="card-header">
                            <asp:RadioButton ID="rbStep5A1" runat="server" Text="เปลี่ยน Socket"  AutoPostBack="true" Enabled="false" />
                            <br />&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="Step5A1chkok" runat="server" AutoPostBack="true" CssClass="auto-style1" Enabled="false" GroupName="Manualcheck1"  Text="Mass NG --&gt; Good" />
                            <br />&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="Step5A1chkng" runat="server" AutoPostBack="true" CssClass="auto-style2" Enabled="false" GroupName="Manualcheck1"  Text="Mass NG --&gt; NG" />
                        </div>
                        <div class="card-header">
                             <asp:RadioButton ID="rbStep5A2" runat="server" Text="Request PM"  AutoPostBack="true" Enabled="false" />
                             <br />&nbsp;&nbsp;&nbsp;
                             <asp:RadioButton ID="Step5A2chkok" runat="server" AutoPostBack="true" CssClass="auto-style1" Enabled="false" GroupName="Manualcheck2"  Text="Mass NG --&gt; Good" />
                             <br />&nbsp;&nbsp;&nbsp;
                             <asp:RadioButton ID="Step5A2chkng" runat="server" AutoPostBack="true" CssClass="auto-style2" Enabled="false" GroupName="Manualcheck2"  Text="Mass NG --&gt; NG" />
                        </div>  
                        <div class="card-header">
                             <asp:RadioButton ID="rbStep5A3" runat="server" Text="อื่นๆ"  AutoPostBack="true" Enabled="false"/>
                             <asp:TextBox ID="tbS5" runat="server" CssClass="form-control blackLine"></asp:TextBox>
                             <br />&nbsp;&nbsp;&nbsp;
                             <asp:RadioButton ID="Step5A3chkok" runat="server" CssClass="auto-style1" Enabled="false" GroupName="Manualcheck3" Text="Mass NG --&gt; Good" />
                             <br />&nbsp;&nbsp;&nbsp;
                             <asp:RadioButton ID="Step5A3chkng" runat="server" CssClass="auto-style2" Enabled="false" GroupName="Manualcheck3" Text="Mass NG --&gt; NG" />
                          </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <br />
            <div class="card">
                <div class="card-header">
                    <asp:CheckBox ID="cbStep5_2" runat="server" Text="  2.Good --> NG" AutoPostBack="true" Enabled="false"/>
                    <br />&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="cbStep5_2chkok" runat="server" Text="Good --> NG" GroupName="cbStep5_2"  CssClass="auto-style1" Enabled="false" />
                    <br />&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="cbStep5_2chkng" runat="server" Text="Good --> Good" GroupName="cbStep5_2" CssClass="auto-style2" Enabled="false" />
                </div>
                <div>
                    <p>&nbsp;&nbsp;&nbsp;&nbsp;Request TE</p>
                </div>
            </div>

            <br />
            <div class="card">
                <div class="card-header">
                    <asp:CheckBox ID="cbStep5_3" runat="server" Text="  3.NG --> NG , Good --> Good" AutoPostBack="true" Enabled="false"/>
                    <br />&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="cbStep5_3chkok" runat="server" Text="NG --> NG , Good --> Good" GroupName="cbStep5_3"  CssClass="auto-style1" Enabled="false" />
                    <br />&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="cbStep5_3chkng" runat="server" Text="NG --> Good ,Good --> Good" GroupName="cbStep5_3" CssClass="auto-style2" Enabled="false" />
                </div>
                <div>
                    <p>&nbsp;&nbsp;&nbsp;&nbsp;Request TE</p>
                </div>
            </div>



            <br />
            <div class="p-3 mb-2 bg-dark text-white">
                <h4>STEP 6</h4>
            </div>
            <div class="card">
                <div class="card-header"><b>ประวัติการเปลี่ยน Socket เมื่อไหร่ ?</b></div>
                <select class="custom-select wide" id="SelectS6A1" runat="server" disabled>
                    <option selected>Please Select</option>
                    <option>ภายใน 1 สัปดาห์</option>
                    <option>เกิน 1 สัปดาห์</option>
                </select>
            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>เปลี่ยนครั้งสุดท้ายวันที่ ?</b></div>
                <div class="form-group">
                    <div class="input-group date" id="datetimepicker1" data-target-input="nearest">
                        <input type="text" runat="server" id="DateS6" class="form-control datetimepicker-input blackLine" data-target="#datetimepicker1" name="SocketChangeDateText" disabled />
                        <div class="input-group-text " data-target="#datetimepicker1" data-toggle="datetimepicker"><i class="fa fa-calendar"></i></div>
                    </div>
                </div>
            </div>


            <br />
            <div class="card">
                <div class="card-header"><b>จากสาเหตุใน STEP 3 ได้ทำการ Restart หรือไม่ ?</b></div>
                <select class="custom-select wide" id="SelectS6A2" runat="server" disabled>
                    <option selected>Please Select</option>
                    <option>ทำแล้ว</option>
                    <option>ไม่ได้ทำ</option>
                </select>
            </div>

            <br />
            <div class="p-3 mb-2 bg-dark text-white">
                <h4>STEP 7</h4>
            </div>
            <div class="card">
                <div class="card-header"><b>Check Low Yield Kanban ledger ?</b></div>
                <asp:DropDownList CssClass="form-control wide" ID="SelectS7" runat="server" Enabled="false">
                    <asp:ListItem Enabled="true" Text="Please Select"></asp:ListItem>
                    <asp:ListItem Text="มี"></asp:ListItem>
                    <asp:ListItem Text="ไม่มี"></asp:ListItem>
                    <asp:ListItem Text="หมดอายุ"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>Test No. :(กรณีที่มี)</b></div>
                <asp:TextBox ID="tbS7" runat="server" CssClass="form-control wide" Enabled="false"></asp:TextBox>
            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>Check alarm Bin (28-31) ?</b></div>
                <br />
                <div class="row mx-2">
                    <asp:CheckBox CssClass="mx-auto" runat="server" ID="CheckS7A1" Text="Bin 28" />
                    <asp:CheckBox CssClass="mx-auto" runat="server" ID="CheckS7A2" Text="Bin 29" />
                    <asp:CheckBox CssClass="mx-auto" runat="server" ID="CheckS7A3" Text="Bin 30" />
                    <asp:CheckBox CssClass="mx-auto" runat="server" ID="CheckS7A4" Text="Bin 31" />
                    <asp:CheckBox CssClass="mx-auto" runat="server" ID="CheckS7A5" Text="ไม่มี" />
                </div>
            </div>

            <br />
            <div class="p-3 mb-2 bg-dark text-white">
                <h4>STEP 8</h4>
            </div>
            <div class="card">
                <div class="card-header"><b>Tester Checker</b></div>
                <select class="custom-select wide" id="SelectS8A1" runat="server" disabled>
                    <option selected>Please Select</option>
                    <option>OK</option>
                    <option>NG</option>
                    <option>ไม่ได้ทำ</option>
                </select>
            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>Set up</b></div>
                <select class="custom-select wide" id="SelectS8A2" runat="server" disabled>
                    <option selected>Please Select</option>
                    <option>OK</option>
                    <option>NG</option>
                    <option>ไม่มี</option>
                </select>
            </div>

            <br />
            <table class="table table-bordered">
                <tr>
                    <th scope="row">T No.</th>
                    <td>
                        <asp:TextBox ID="tbS8r1c1" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="tbS8r1c2" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="tbS8r1c3" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="tbS8r1c4" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="tbS8r1c5" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                </tr>
                <tr>
                    <th scope="row">Limit-Low</th>
                    <td>
                        <asp:TextBox ID="tbS8r2c1" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="tbS8r2c2" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="tbS8r2c3" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="tbS8r2c4" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="tbS8r2c5" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                </tr>
                <tr>
                    <th scope="row">Limit-High</th>
                    <td>
                        <asp:TextBox ID="tbS8r3c1" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="tbS8r3c2" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="tbS8r3c3" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="tbS8r3c4" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="tbS8r3c5" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                </tr>

                <tr>
                    <th scope="row">STEP 1 Mass-Product NG</th>
                    <td>
                        <asp:TextBox ID="tbS8r4c1" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="tbS8r4c2" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="tbS8r4c3" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="tbS8r4c4" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="tbS8r4c5" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                </tr>

                <tr>
                    <th scope="row">STEP 2 Good Sample</th>
                    <td>
                        <asp:TextBox ID="tbS8r5c1" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="tbS8r5c2" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="tbS8r5c3" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="tbS8r5c4" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="tbS8r5c5" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                </tr>

                <tr>
                    <th scope="row">STEP 3 ยืนยัน Tester อื่นๆ</th>
                    <td>
                        <asp:TextBox ID="tbS8r6c1" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="tbS8r6c2" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="tbS8r6c3" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="tbS8r6c4" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="tbS8r6c5" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                </tr>

                <tr>
                    <th scope="row">เช็คซ้ำ (/5)</th>
                    <td>
                        <asp:TextBox ID="tbS8r7c1" runat="server" CssClass="form-control blackLine" placeholder="/5" Enabled="false"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="tbS8r7c2" runat="server" CssClass="form-control blackLine" placeholder="/5" Enabled="false"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="tbS8r7c3" runat="server" CssClass="form-control blackLine" placeholder="/5" Enabled="false"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="tbS8r7c4" runat="server" CssClass="form-control blackLine" placeholder="/5" Enabled="false"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="tbS8r7c5" runat="server" CssClass="form-control blackLine" placeholder="/5" Enabled="false"></asp:TextBox></td>
                </tr>

                <tr>
                    <th scope="row">ชื่อ Program</th>
                    <td rowspan="4">
                        <asp:TextBox ID="tbS8r8" runat="server" CssClass="form-control wide" Enabled="false"></asp:TextBox></td>
                </tr>
            </table>

            <br />
            <div class="card">
                <div class="card-header"><b>*จำนวน Mass Product ที่ใช้ ?</b></div>

                <div class="card-header"><b>Good (PCS)</b></div>
                <asp:TextBox ID="tbS8A1" runat="server" CssClass="form-control wide" Enabled="false"></asp:TextBox>


                <div class="card-header"><b>NG (PCS)</b></div>
                <asp:TextBox ID="tbS8A2" runat="server" CssClass="form-control wide" Enabled="false"></asp:TextBox>

            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>*จำนวนงานที่ Scrap ?</b></div>

                <div class="card-header"><b>Good (PCS)</b></div>
                <asp:TextBox ID="tbS8A3" runat="server" CssClass="form-control wide" Enabled="false"></asp:TextBox>


                <div class="card-header"><b>NG (PCS)</b></div>
                <asp:TextBox ID="tbS8A4" runat="server" CssClass="form-control wide" Enabled="false"></asp:TextBox>
            </div>

            <br />
            <div class="p-3 mb-2 bg-dark text-white">
                <h4>STEP 9</h4>
            </div>
            <div class="card">
                <div class="card-header"><b>สาเหตุ</b></div>
                <select class="custom-select wide" id="SelectS9" runat="server" disabled>
                    <option selected>Please Select</option>
                    <option>Tester</option>
                    <option>Box</option>
                    <option>Option</option>
                    <option>OP Miss</option>
                    <option>TE take back</option>
                    <option>IC Burn</option>
                    <option>อื่นๆ</option>
                </select>
            </div>

            <br />
            <div class="p-3 mb-2 bg-dark text-white">
                <h4>STEP 10</h4>
            </div>


            <h5 class="bg-dark text-white text-center">ตอน Action</h5>

            <table class="table table-striped">
                <thead class="thead-dark">
                    <tr>
                        <th scope="col"></th>
                        <th scope="col"></th>
                        <th scope="col" class="text-center">Worst 1</th>
                        <th scope="col" class="text-center">Worst 2</th>
                        <th scope="col" class="text-center">Worst 3</th>
                        <th scope="col" class="text-center">Worst 4</th>
                        <th scope="col" class="text-center">Worst 5</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <th rowspan="2" class="align-middle">Ach</th>
                        <th scope="col">Test No.</th>
                        <td>
                            <asp:TextBox ID="tbS10r1c1" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS10r1c2" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS10r1c3" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS10r1c4" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS10r1c5" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th scope="col">จำนวน NG (PCS)</th>
                        <td>
                            <asp:TextBox ID="tbS10r2c1" runat="server" CssClass="form-control blackLine" placeholder="pcs" Enabled="false"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS10r2c2" runat="server" CssClass="form-control blackLine" placeholder="pcs" Enabled="false"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS10r2c3" runat="server" CssClass="form-control blackLine" placeholder="pcs" Enabled="false"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS10r2c4" runat="server" CssClass="form-control blackLine" placeholder="pcs" Enabled="false"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS10r2c5" runat="server" CssClass="form-control blackLine" placeholder="pcs" Enabled="false"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th rowspan="2" class="align-middle">Bch</th>
                        <th scope="col">Test No.</th>
                        <td>
                            <asp:TextBox ID="tbS10r3c1" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS10r3c2" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS10r3c3" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS10r3c4" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS10r3c5" runat="server" CssClass="form-control blackLine" Enabled="false"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th scope="col">จำนวน NG (PCS)</th>
                        <td>
                            <asp:TextBox ID="tbS10r4c1" runat="server" CssClass="form-control blackLine" placeholder="pcs" Enabled="false"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS10r4c2" runat="server" CssClass="form-control blackLine" placeholder="pcs" Enabled="false"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS10r4c3" runat="server" CssClass="form-control blackLine" placeholder="pcs" Enabled="false"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS10r4c4" runat="server" CssClass="form-control blackLine" placeholder="pcs" Enabled="false"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS10r4c5" runat="server" CssClass="form-control blackLine" placeholder="pcs" Enabled="false"></asp:TextBox></td>
                    </tr>
                </tbody>
            </table>

            <br />
            <div class="card">
                <div class="card-header"><b>Final Yield (%)</b></div>
                <asp:TextBox ID="tbS10A1" runat="server" CssClass="form-control wide" Enabled="false"></asp:TextBox>
            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>ค่า Control LCL (%)</b></div>
                <asp:TextBox ID="tbS10A2" runat="server" CssClass="form-control wide" Enabled="false"></asp:TextBox>
            </div>

            <br />
            <div class="p-3 mb-2 bg-dark text-white">
                <h4>STEP 11</h4>
            </div>

            <div class="card">
                <div class="card-header"><b>ผลการ ASI ?</b></div>

                <div class="card-header"><b>Good [จำนวน/จำนวน](PCS)</b></div>
                <asp:TextBox ID="tbS11A1" runat="server" CssClass="form-control wide" placeholder="ตัวอย่าง: 5/10" Enabled="false"></asp:TextBox>


                <div class="card-header"><b>NG [จำนวน/จำนวน](PCS)</b></div>
                <asp:TextBox ID="tbS11A2" runat="server" CssClass="form-control wide" placeholder="ตัวอย่าง: 5/10" Enabled="false"></asp:TextBox>

            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>กด Andon หรือยัง ?</b></div>
                <select class="custom-select wide" id="SelectS11" runat="server" disabled>
                    <option selected>Please Select</option>
                    <option>Yes</option>
                    <option>No</option>
                </select>
            </div>
            <br />
            <div class="card">
                <div class="card-header"><b>ในกรณีที่กด Andon การจัดการคือ ?</b></div>
                <asp:TextBox ID="tbS11A3" runat="server" CssClass="form-control wide" Enabled="false"></asp:TextBox>

                <div class="card-header"><b>ใคร ?</b></div>
                <asp:TextBox ID="tbS11A4" runat="server" CssClass="form-control wide" Enabled="false"></asp:TextBox>


                <div class="card-header"><b>การจัดการอย่างไร ?</b></div>
                <asp:TextBox ID="tbS11A5" runat="server" CssClass="form-control wideOnly" TextMode="MultiLine" placeholder="รายละเอียดการจัดการ" Enabled="false"></asp:TextBox>

            </div>


            <br />
            <div class="p-3 mb-2 bg-dark text-white">
                <h4>STEP 13</h4>
            </div>

            <div class="card">
                <div class="card-header"><b>KANBAN ITEM : FQI NO ANALYSIS</b></div>
            </div>

            <div class="card">
                <div class="card-header"><b>CTRL NO</b></div>
                <asp:TextBox ID="tbS13A4" runat="server" CssClass="form-control wide" Enabled="false"></asp:TextBox>
            </div>

            <div class="card">
                <div class="card-header"><b>TEST NO</b></div>
                <asp:TextBox ID="tbS13A5" runat="server" CssClass="form-control wide" Enabled="false"></asp:TextBox>
            </div>

            <div class="card">
                <div class="card-header"><b>KANBAN EXPIRE DATE</b></div>
                <div class="form-group">
                    <div class="input-group date" id="datetimepicker2" data-target-input="nearest">
                        <input type="text" runat="server" id="dateS13" class="form-control datetimepicker-input blackLine" data-target="#datetimepicker2" name="KanbanExpDate" disabled />
                        <div class="input-group-append" data-target="#datetimepicker2" data-toggle="datetimepicker">
                            <div class="input-group-text"><i class="fa fa-calendar"></i></div>
                        </div>
                    </div>
                </div>
            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>*จำนวนงานที่ต้องทำการตรวจสอบ ? [Total(PCS)]</b></div>
                <asp:TextBox ID="tbS13A1" runat="server" CssClass="form-control wide" Enabled="false"></asp:TextBox>
            </div>
            <br />
            <div class="card">
                <div class="card-header"><b>*ผลการตรวจสอบ ?</b></div>
                <div class="card-header"><b>Good (PCS)</b></div>
                <asp:TextBox ID="tbS13A2" runat="server" CssClass="form-control wide" Enabled="false"></asp:TextBox>
                <div class="card-header"><b>NG (PCS)</b></div>
                <asp:TextBox ID="tbS13A3" runat="server" CssClass="form-control wide" Enabled="false"></asp:TextBox>
            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>*ออกใบ AQI ?</b></div>
                <select class="custom-select wide" id="SelectS13A1" runat="server" disabled>
                    <option selected>Please Select</option>
                    <option>Yes</option>
                    <option>No</option>
                </select>
            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>*ออกคำสั่ง Stop lot ที่จะผลิตต่อไปหรือยัง ?</b></div>
                <select class="custom-select wide" id="SelectS13A2" runat="server" disabled>
                    <option selected>Please Select</option>
                    <option>แจ้งแล้ว</option>
                    <option>ไม่ได้แจ้ง</option>
                </select>
            </div>


            <br />
            <div class="p-3 mb-2 bg-dark text-white">
                <h4>STEP 14</h4>
            </div>

            <div class="card">
                <div class="card-header"><b>*ผลการตรวจสอบ Burn ?</b></div>
                <div class="card-header"><b>Good      [จำนวน/จำนวน](PCS)</b></div>
                <asp:TextBox ID="tbS14A1" runat="server" CssClass="form-control wide" placeholder="ตัวอย่าง :: 5/10" Enabled="false"></asp:TextBox>
                <div class="card-header"><b>NG        [จำนวน/จำนวน](PCS)</b></div>
                <asp:TextBox ID="tbS14A2" runat="server" CssClass="form-control wide" placeholder="ตัวอย่าง :: 5/10" Enabled="false"></asp:TextBox>
            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>*ผลการตรวจสอบ Chip Crack ?</b></div>
                <div class="card-header"><b>Good      [จำนวน/จำนวน](PCS)</b></div>
                <asp:TextBox ID="tbS14A3" runat="server" CssClass="form-control wide" placeholder="ตัวอย่าง :: 5/10" Enabled="false"></asp:TextBox>
                <div class="card-header"><b>NG        [จำนวน/จำนวน](PCS)</b></div>
                <asp:TextBox ID="tbS14A4" runat="server" CssClass="form-control wide" placeholder="ตัวอย่าง :: 5/10" Enabled="false"></asp:TextBox>
            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>*ผลการตรวจสอบ Chip Mix ?</b></div>
                <div class="card-header"><b>Good No.</b></div>
                <asp:TextBox ID="tbS14A5" runat="server" CssClass="form-control wide" Enabled="false"></asp:TextBox>
                <div class="card-header"><b>NG No.</b></div>
                <asp:TextBox ID="tbS14A6" runat="server" CssClass="form-control wide" Enabled="false"></asp:TextBox>
            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>*ออกใบ AQI ?</b></div>
                <select class="custom-select wide" id="SelectS14A1" runat="server" disabled>
                    <option selected>Please Select</option>
                    <option>Yes</option>
                    <option>No</option>
                </select>
            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>*ออกคำสั่ง Stop lot ที่จะผลิตต่อไปหรือยัง ?</b></div>
                <select class="custom-select wide" id="SelectS14A2" runat="server" disabled>
                    <option selected>Please Select</option>
                    <option>แจ้งแล้ว</option>
                    <option>ไม่ได้แจ้ง</option>
                </select>
            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>*สั่ง Stop PKG ?</b></div>
                <select class="custom-select wide" id="SelectS14A3" runat="server" disabled>
                    <option selected>Please Select</option>
                    <option>ทำแล้ว</option>
                    <option>ไม่ได้ทำ</option>
                </select>
            </div>

            <br />
            <div class="p-3 mb-2 bg-dark text-white">
                <h4>STEP 15</h4>
            </div>

            <div class="card">
                <div class="card-header"><b>*ออกใบ AQI ?</b></div>
                <select class="custom-select wide" id="SelectS15A1" runat="server" >
                    <option selected>Please Select</option>
                    <option>Yes</option>
                    <option>No</option>
                </select>
            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>*มีคำสั่ง Stop Shipment ของ Object Device ?</b></div>
                <select class="custom-select wide" id="SelectS15A2" runat="server" disabled>
                    <option selected>Please Select</option>
                    <option>Yes</option>
                    <option>No</option>
                </select>
            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>*Stop การออก Label ?</b></div>
                <select class="custom-select wide" id="SelectS15A3" runat="server" disabled>
                    <option selected>Please Select</option>
                    <option>ทำแล้ว</option>
                    <option>ไม่ได้ทำ</option>
                </select>
            </div>

            <br />
            <div class="p-3 mb-2 bg-dark text-white">
                <h4>STEP 16</h4>
            </div>

            <div class="card">
                <div class="card-header"><b>*ผลการตรวจ Testing System Inspection ?</b></div>
                <select class="custom-select wide" id="SelectS16" runat="server" disabled>
                    <option selected>Please Select</option>
                    <option>OK</option>
                    <option>NG</option>
                </select>
            </div>

            <br />
            <div class="p-3 mb-2 bg-dark text-white">
                <h4>STEP 17</h4>
            </div>

            <div class="card">
                <div class="card-header"><b>*ผลการ Judgement ?</b></div>
                <select class="custom-select wide" id="SelectS17" runat="server" disabled>
                    <option selected>Please Select</option>
                    <option>Flow</option>
                    <option>Hold</option>
                </select>
                <br />
                <asp:TextBox ID="tbS17" runat="server" CssClass="form-control wide" placeholder="Hold ?" Enabled="false"></asp:TextBox>
            </div>

            <br />
            <div class="p-3 mb-2 bg-dark text-white">
                <h4>STEP 19</h4>
            </div>

            <div class="card">
                <div class="card-header"><b>*มีการออก Low Yield Analysis Request Sheet ?</b></div>
                <select class="custom-select wide" id="SelectS19" runat="server" disabled>
                    <option selected>Please Select</option>
                    <option>มี</option>
                    <option>ไม่มี</option>
                </select>
            </div>
            <br />

        </div>
    </div>


    <button class="btn btn btn-primary btn-lg btn-block" type="button" data-toggle="collapse" data-target="#CL5" aria-expanded="false" aria-controls="collapseExample">
        <h3>Input Data</h3>
    </button>
    <div class="collapse show" id="CL5">
        <div class="card card-body">

            <div class="p-3 mb-2 bg-info text-white">
                <h4>STEP 16</h4>
            </div>

            <div class="card">
                <div class="card-header"><b>.ผลการตรวจสอบ Testing System Inspection ?</b></div>
                <select class="custom-select wide BgColData" id="SelectS16A1" runat="server">
                    <option selected>Please Select</option>
                    <option>OK</option>
                    <option>NG</option>
                </select>
            </div>

            <br />
            <div class="p-3 mb-2 bg-info text-white">
                <h4>STEP 18</h4>
            </div>

            <div class="card">
                <div class="card-header"><b>*งาน Good FT O/S Retest(ทั้งจำนวน) ?</b></div>
                <div class="card-header"><b>Good      [จำนวน/จำนวน](PCS)</b></div>
                <asp:TextBox ID="tbS18A1" runat="server" CssClass="form-control wide BgColData" placeholder="ตัวอย่าง :: 5/10" onkeypress="return onlyNumbersWithSlash(event,value);"></asp:TextBox>
                <div class="card-header"><b>NG        [จำนวน/จำนวน](PCS)</b></div>
                <asp:TextBox ID="tbS18A2" runat="server" CssClass="form-control wide BgColData" placeholder="ตัวอย่าง :: 5/10" onkeypress="return onlyNumbersWithSlash(event,value);"></asp:TextBox>
            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>*การชี้ความแน่นอนของ Object Scope ?</b></div>
                <select class="custom-select wide BgColData" id="SelectS18A1" runat="server">
                    <option selected>Please Select</option>
                    <option>ทำแล้ว</option>
                    <option>ไม่ได้ทำ</option>
                </select>
            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>*คำสั่ง Stop Recall,Stop Shipment ?</b></div>
                <select class="custom-select wide BgColData" id="SelectS18A2" runat="server">
                    <option selected>Please Select</option>
                    <option>ทำแล้ว</option>
                    <option>ไม่ได้ทำ</option>
                </select>
            </div>

        </div>
    </div>


    <br />
    <br />
    <div>
        <button type="button" class="btn btn-success btn-lg btn-block" data-toggle="modal" data-target="#SaveModal">SAVE</button>
        <br />
        <button type="button" class="btn btn-danger btn-lg btn-block" runat="server" onserverclick="BtnClose_ServerClick">CLOSE</button>
    </div>


    <asp:TextBox runat="server" Text="" ID="txtStoreValue" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtRequestDate" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtMode" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtDescribe" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtRequestType" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtFlow" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtShipment" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtSetupCheck" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtManaulCheck1" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtResult1_1" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtManaulCheck1_2" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtResult1_2" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtManaulCheck1_3" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtResult1_3" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtManaulCheck2" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtResult2" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtManaulCheck3" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtResult3" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtSocketChangeHist" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtIsRestartStep3" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtCheckLowYieldKanban" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtCheckAlarmBin" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtTesterChecker" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtSetup" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtCause" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtAddOn" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtRequestAQIS13" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtStopNextLotS13" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtRequestAQIS14" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtStopNextLotS14" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtStopPKGS14" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtSystemInspection" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtJudgementResult" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtLowYieldAnalysis" Visible="false"></asp:TextBox>

    <!-- Modal -->
    <div class="modal fade" id="SaveModal" tabindex="-1" role="dialog" aria-labelledby="SaveModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="SaveModalLabel">Confirmation Dialog</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    Are you sure to save this data ?
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-success" runat="server" onserverclick="ConfirmBtnOnClick">Confirm</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
