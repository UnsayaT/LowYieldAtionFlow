<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="InputPageUser1.aspx.cs" Inherits="LowYieldCheckSheet.InputPageUser1_Test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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

        .SetCenter {
            margin-left: auto;
            margin-right: auto;
            text-align:center
        }
        .auto-style1 {
            color: #0000FF;
        }
        .auto-style2 {
            color: #FF0000;
        }
    </style>



    <script type="text/javascript">
        function validatenumerics(key) {
            //this function use to check input from input or textbox if not number,its will alert

            //getting key code of pressed key
            var keycode = (key.which) ? key.which : key.keyCode;
            //comparing pressed keycodes

            if (keycode > 31 && (keycode < 48 || keycode > 57)) {
                alert(" Please input only number. ");
                return false;
            }
            else return true;

        }

        function onlyNumbersWithDot(event, value) {
            var charCode;
            if (event.keyCode > 0) {
                charCode = event.which || event.keyCode;
            }
            else if (typeof (event.charCode) != "undefined") {
                charCode = event.which || event.keyCode;
            }

            //if input dot "."
            if (charCode == 46) {
                //check value if value.indexOf(".") == -1     it's mean no "." in value
                if (value.indexOf(".") == -1) {
                    return true;
                }
            }

            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                alert(" Please input number or single dot('.') !!");
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


    <button class="btn btn btn-primary btn-lg btn-block" type="button" data-toggle="collapse" data-target="#CL5" aria-expanded="false" aria-controls="collapseExample">
        <h3>Input Data</h3>
    </button>
    <div class="collapse show" id="CL5">
        <div class="card card-body">

            <div class="card">
                <div class="card-header"><b>NG (PCS) :</b></div>
                <asp:TextBox ID="tbHead1" runat="server" CssClass="form-control wide" onkeypress="return validatenumerics(event);"></asp:TextBox>
            </div>


            <br />
            <div class="card">
                <div class="card-header"><b>Handler No. :</b></div>
                <asp:TextBox ID="tbHead2" runat="server" CssClass="form-control wide"></asp:TextBox>
            </div>

            <br />

            <div class="card">
                <div class="card-header"><b>Lot No. :</b></div>
                <asp:TextBox ID="tbHead3" runat="server" CssClass="form-control wide"></asp:TextBox>
            </div>

            <br />

            <div class="card">
                <div class="card-header"><b>Package Name :</b></div>
                <asp:TextBox ID="tbHead4" runat="server" CssClass="form-control wide"></asp:TextBox>
            </div>

            <br />

            <div class="card">
                <div class="card-header"><b>Device Name :</b></div>
                <asp:TextBox ID="tbHead5" runat="server" CssClass="form-control wide"></asp:TextBox>
            </div>


            <br />
            <div class="card">
                <div class="card-header"><b>Flow :</b></div>

                <asp:DropDownList CssClass="form-control wide" ID="headSelect1" runat="server">
                    <asp:ListItem Enabled="true" Text="Please Select"></asp:ListItem>
                    <asp:ListItem Text="Auto 1"></asp:ListItem>
                    <asp:ListItem Text="Auto 2"></asp:ListItem>
                    <asp:ListItem Text="Auto 3"></asp:ListItem>
                    <asp:ListItem Text="Auto 4"></asp:ListItem>
                </asp:DropDownList>

            </div>


            <br />
            <div class="card">
                <div class="card-header"><b>M No. :</b></div>
                <asp:TextBox ID="tbHead6" runat="server" CssClass="form-control wide"></asp:TextBox>
            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>Tester No. :</b></div>
                <asp:TextBox ID="tbHead7" runat="server" CssClass="form-control wide"></asp:TextBox>
            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>Box No. :</b></div>
                <asp:TextBox ID="tbHead8" runat="server" CssClass="form-control wide"></asp:TextBox>
            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>T Rank :</b></div>
                <asp:TextBox ID="tbHead9" runat="server" CssClass="form-control wide"></asp:TextBox>
            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>Wafer Lot No. :</b></div>
                <asp:TextBox ID="tbHead10" runat="server" CssClass="form-control wide"></asp:TextBox>
            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>Wafer แผ่นที่ :</b></div>
                <asp:TextBox ID="tbHead11" runat="server" CssClass="form-control wide"></asp:TextBox>
            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>T/P Rank :</b></div>
                <asp:TextBox ID="tbHead12" runat="server" CssClass="form-control wide"></asp:TextBox>
            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>Shipment :</b></div>
                <asp:DropDownList CssClass="form-control wide" ID="headSelect2" runat="server">
                    <asp:ListItem Enabled="true" Text="Please Select"></asp:ListItem>
                    <asp:ListItem Text="Japan"></asp:ListItem>
                    <asp:ListItem Text="Oversea"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>Shipment Date :</b></div>
                <div class="form-control wide">
                    <select id="DateS1" runat="server">
                            <option selected>Date</option>
                            <option>01</option>
                            <option>02</option>
                            <option>03</option>
                            <option>04</option>
                            <option>05</option>
                            <option>06</option>
                            <option>07</option>
                            <option>08</option>
                            <option>09</option>
                            <option>10</option>
                            <option>11</option>
                            <option>12</option>
                            <option>13</option>
                            <option>14</option>
                            <option>15</option>
                            <option>16</option>
                            <option>17</option>
                            <option>18</option>
                            <option>19</option>
                            <option>20</option>
                            <option>21</option>
                            <option>22</option>
                            <option>23</option>
                            <option>24</option>
                            <option>25</option>
                            <option>26</option>
                            <option>27</option>
                            <option>28</option>
                            <option>29</option>
                            <option>30</option>
                            <option>31</option>
                    </select>
                        &nbsp;&nbsp;
                    <select id="DateS2" runat="server">
                            <option selected>Month</option>
                            <option>01</option>
                            <option>02</option>
                            <option>03</option>
                            <option>04</option>
                            <option>05</option>
                            <option>06</option>
                            <option>07</option>
                            <option>08</option>
                            <option>09</option>
                            <option>10</option>
                            <option>11</option>
                            <option>12</option>
                     </select>
                        &nbsp;&nbsp;
                     <select id="DateS3" runat="server">
                            <option selected>Year</option>
                            <option>2017</option>
                            <option>2018</option>
                            <option>2019</option>
                            <option>2020</option>
                            <option>2021</option>
                            <option>2022</option>
                            <option>2023</option>
                            <option>2024</option>
                            <option>2025</option>
                            <option>2026</option>
                            <option>2027</option>
                            <option>2028</option>
                     </select>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    <select id="DateS4" runat="server">
                            <option selected>Hour</option>
                            <option>00</option>
                            <option>01</option>
                            <option>02</option>
                            <option>03</option>
                            <option>04</option>
                            <option>05</option>
                            <option>06</option>
                            <option>07</option>
                            <option>08</option>
                            <option>09</option>
                            <option>10</option>
                            <option>11</option>
                            <option>12</option>
                            <option>13</option>
                            <option>14</option>
                            <option>15</option>
                            <option>16</option>
                            <option>17</option>
                            <option>18</option>
                            <option>19</option>
                            <option>20</option>
                            <option>21</option>
                            <option>22</option>
                            <option>23</option>
                            <option>24</option>
                     </select>
                        &nbsp;&nbsp;
                     <select id="DateS5" runat="server">
                            <option selected>Minute</option>
                            <option>00</option>
                            <option>01</option>
                            <option>02</option>
                            <option>03</option>
                            <option>04</option>
                            <option>05</option>
                            <option>06</option>
                            <option>07</option>
                            <option>08</option>
                            <option>09</option>
                            <option>10</option>
                            <option>11</option>
                            <option>12</option>
                            <option>13</option>
                            <option>14</option>
                            <option>15</option>
                            <option>16</option>
                            <option>17</option>
                            <option>18</option>
                            <option>19</option>
                            <option>20</option>
                            <option>21</option>
                            <option>22</option>
                            <option>23</option>
                            <option>24</option>
                            <option>25</option>
                            <option>26</option>
                            <option>27</option>
                            <option>28</option>
                            <option>29</option>
                            <option>30</option>
                            <option>31</option>
                            <option>32</option>
                            <option>33</option>
                            <option>34</option>
                            <option>35</option>
                            <option>36</option>
                            <option>37</option>
                            <option>38</option>
                            <option>39</option>
                            <option>40</option>
                            <option>41</option>
                            <option>42</option>
                            <option>43</option>
                            <option>44</option>
                            <option>45</option>
                            <option>46</option>
                            <option>47</option>
                            <option>48</option>
                            <option>49</option>
                            <option>50</option>
                            <option>51</option>
                            <option>52</option>
                            <option>53</option>
                            <option>54</option>
                            <option>55</option>
                            <option>56</option>
                            <option>57</option>
                            <option>58</option>
                            <option>59</option>
                     </select>
                    </div>
            </div>

            <br />

            <div class="p-3 mb-2 bg-info text-white">
                <h4>STEP 1</h4>
            </div>

            <div class="card">
                <div class="card-header"><b>Input Quantity (PCS)</b></div>
                <asp:TextBox ID="tbS1A1" runat="server" CssClass="form-control wide" placeholder="PCS" onkeypress="return validatenumerics(event);"></asp:TextBox>
            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>Control Yield (%)</b></div>
                <asp:TextBox ID="tbS1A2" runat="server" CssClass="form-control wide" placeholder="%" onkeypress="return onlyNumbersWithDot(event,value);"></asp:TextBox>
            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>Initial Yield (%) :</b></div>
                <asp:TextBox ID="tbS1A3" runat="server" CssClass="form-control wide" placeholder="%" ></asp:TextBox>

            </div>


            <br />
            <div class="card">
                <div class="card-header"><b>Check (%) :</b></div>
                <asp:TextBox ID="tbS1A4" runat="server" CssClass="form-control wide" placeholder="%" ></asp:TextBox>
            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>Action (PCS)</b></div>
                <asp:TextBox ID="tbS1A5" runat="server" CssClass="form-control wide" placeholder="PCS" ></asp:TextBox>
            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>Action (%)</b></div>
                <asp:TextBox ID="tbS1A6" runat="server" CssClass="form-control wide" placeholder="%" ></asp:TextBox>
            </div>

            <br />
            <div class="p-3 mb-2 bg-info text-white">
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
                            <asp:TextBox ID="tbS2r1c1" runat="server" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS2r1c2" runat="server" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS2r1c3" runat="server" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS2r1c4" runat="server" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS2r1c5" runat="server" CssClass="form-control"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th scope="col">จำนวน NG (PCS)</th>
                        <td>
                            <asp:TextBox ID="tbS2r2c1" runat="server" CssClass="form-control" placeholder="pcs" onkeypress="return validatenumerics(event);"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS2r2c2" runat="server" CssClass="form-control" placeholder="pcs" onkeypress="return validatenumerics(event);"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS2r2c3" runat="server" CssClass="form-control" placeholder="pcs" onkeypress="return validatenumerics(event);"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS2r2c4" runat="server" CssClass="form-control" placeholder="pcs" onkeypress="return validatenumerics(event);"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS2r2c5" runat="server" CssClass="form-control" placeholder="pcs" onkeypress="return validatenumerics(event);"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th rowspan="2" class="align-middle">Bch</th>
                        <th scope="col">Test No.</th>
                        <td>
                            <asp:TextBox ID="tbS2r3c1" runat="server" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS2r3c2" runat="server" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS2r3c3" runat="server" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS2r3c4" runat="server" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS2r3c5" runat="server" CssClass="form-control"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th scope="col">จำนวน NG (PCS)</th>
                        <td>
                            <asp:TextBox ID="tbS2r4c1" runat="server" CssClass="form-control" placeholder="pcs" onkeypress="return validatenumerics(event);"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS2r4c2" runat="server" CssClass="form-control" placeholder="pcs" onkeypress="return validatenumerics(event);"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS2r4c3" runat="server" CssClass="form-control" placeholder="pcs" onkeypress="return validatenumerics(event);"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS2r4c4" runat="server" CssClass="form-control" placeholder="pcs" onkeypress="return validatenumerics(event);"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbS2r4c5" runat="server" CssClass="form-control" placeholder="pcs" onkeypress="return validatenumerics(event);"></asp:TextBox></td>
                    </tr>
                </tbody>
            </table>

            <br />
            <div class="p-3 mb-2 bg-info text-white">
                <h4>STEP 4</h4>
            </div>
            <div class="card">
                <div class="card-header"><b>SET UP CHECK</b></div>
                <select class="custom-select wide" id="SelectS4" name="SelectS4" runat="server">
                    <option selected>Please Select</option>
                    <option>OK</option>
                    <option>NG</option>
                </select>
            </div>

            <br />
            <div class="p-3 mb-2 bg-info text-white">
                <h4>STEP 5</h4>
            </div>
            <div class="card">
                <div class="card-header"><b>Manual Check</b></div>
            </div>

            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="card">
                        <div class="card-header">
                            <asp:CheckBox ID="cbStep5_1" runat="server" Text="  1.Mass NG --> Good" AutoPostBack="true" OnCheckedChanged="cbStep5_1_CheckedChanged" />
                        </div>
                        <div class="card-header">
                            <asp:RadioButton ID="rbStep5A1" runat="server" Text="เปลี่ยน Socket"  AutoPostBack="true" Enabled="false" OnCheckedChanged="rbStep5A1_CheckedChanged"/>
                            <br />&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="Step5A1chkok" runat="server" AutoPostBack="true" CssClass="auto-style1" Enabled="false" GroupName="Manualcheck1" OnCheckedChanged="Step5A1chkng_CheckedChanged" Text="Mass NG --&gt; Good" />
                            <br />&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="Step5A1chkng" runat="server" AutoPostBack="true" CssClass="auto-style2" Enabled="false" GroupName="Manualcheck1" OnCheckedChanged="Step5A1chkng_CheckedChanged" Text="Mass NG --&gt; NG" />
                        </div>
                        <div class="card-header">
                             <asp:RadioButton ID="rbStep5A2" runat="server" Text="Request PM"  AutoPostBack="true" Enabled="false" OnCheckedChanged="rbStep5A2_CheckedChanged"/>
                             <br />&nbsp;&nbsp;&nbsp;
                             <asp:RadioButton ID="Step5A2chkok" runat="server" AutoPostBack="true" CssClass="auto-style1" Enabled="false" GroupName="Manualcheck2" OnCheckedChanged="Step5A2chkng_CheckedChanged" Text="Mass NG --&gt; Good" />
                             <br />&nbsp;&nbsp;&nbsp;
                             <asp:RadioButton ID="Step5A2chkng" runat="server" AutoPostBack="true" CssClass="auto-style2" Enabled="false" GroupName="Manualcheck2" OnCheckedChanged="Step5A2chkng_CheckedChanged" Text="Mass NG --&gt; NG" />
                        </div>  
                        <div class="card-header">
                             <asp:RadioButton ID="rbStep5A3" runat="server" Text="อื่นๆ"  AutoPostBack="true" Enabled="false" OnCheckedChanged="rbStep5A3_CheckedChanged"/>
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
                    <asp:CheckBox ID="cbStep5_2" runat="server" Text="  2.Good --> NG" AutoPostBack="true" OnCheckedChanged="cbStep5_2_CheckedChanged"/>
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
                    <asp:CheckBox ID="cbStep5_3" runat="server" Text="  3.NG --> NG , Good --> Good" AutoPostBack="true" OnCheckedChanged="cbStep5_3_CheckedChanged"/>
                    <br />&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="cbStep5_3chkok" runat="server" Text="NG --> NG , Good --> Good" GroupName="cbStep5_3"  CssClass="auto-style1" Enabled="false" />
                    <br />&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="cbStep5_3chkng" runat="server" Text="NG --> Good ,Good --> Good" GroupName="cbStep5_3" CssClass="auto-style2" Enabled="false" />
                </div>
                <div>
                    <p>&nbsp;&nbsp;&nbsp;&nbsp;Request TE</p>
                </div>
            </div>
             <div class="card">
                <div class="card-header"><b>Check Socket</b></div>
            </div>
            <select class="custom-select wide" id="SelectS5A1" runat="server">
                    <option selected>Please Select</option>
                    <option>A</option>
                    <option>B</option>
                    <option>C</option>
            </select>


            <br />
            <div class="p-3 mb-2 bg-info text-white">
                <h4>STEP 6</h4>
            </div>
            <div class="card">
                <div class="card-header"><b>ประวัติการเปลี่ยน Socket เมื่อไหร่ ?</b></div>
                <select class="custom-select wide" id="SelectS6A1" runat="server">
                    <option selected>Please Select</option>
                    <option>ภายใน 1 สัปดาห์</option>
                    <option>เกิน 1 สัปดาห์</option>
                </select>
            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>เปลี่ยนครั้งสุดท้ายวันที่ ?</b></div>
                <div class="form-control wide">
                    <select id="DateS6" runat="server">
                            <option selected>Date</option>
                            <option>01</option>
                            <option>02</option>
                            <option>03</option>
                            <option>04</option>
                            <option>05</option>
                            <option>06</option>
                            <option>07</option>
                            <option>08</option>
                            <option>09</option>
                            <option>10</option>
                            <option>11</option>
                            <option>12</option>
                            <option>13</option>
                            <option>14</option>
                            <option>15</option>
                            <option>16</option>
                            <option>17</option>
                            <option>18</option>
                            <option>19</option>
                            <option>20</option>
                            <option>21</option>
                            <option>22</option>
                            <option>23</option>
                            <option>24</option>
                            <option>25</option>
                            <option>26</option>
                            <option>27</option>
                            <option>28</option>
                            <option>29</option>
                            <option>30</option>
                            <option>31</option>
                    </select>
                        &nbsp;&nbsp;
                    <select id="DateS7" runat="server">
                            <option selected>Month</option>
                            <option>01</option>
                            <option>02</option>
                            <option>03</option>
                            <option>04</option>
                            <option>05</option>
                            <option>06</option>
                            <option>07</option>
                            <option>08</option>
                            <option>09</option>
                            <option>10</option>
                            <option>11</option>
                            <option>12</option>
                     </select>
                        &nbsp;&nbsp;
                     <select id="DateS8" runat="server">
                            <option selected>Year</option>
                            <option>2017</option>
                            <option>2018</option>
                            <option>2019</option>
                            <option>2020</option>
                            <option>2021</option>
                            <option>2022</option>
                            <option>2023</option>
                            <option>2024</option>
                            <option>2025</option>
                            <option>2026</option>
                            <option>2027</option>
                            <option>2028</option>
                     </select>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    <select id="DateS9" runat="server">
                            <option selected>Hour</option>
                            <option>00</option>
                            <option>01</option>
                            <option>02</option>
                            <option>03</option>
                            <option>04</option>
                            <option>05</option>
                            <option>06</option>
                            <option>07</option>
                            <option>08</option>
                            <option>09</option>
                            <option>10</option>
                            <option>11</option>
                            <option>12</option>
                            <option>13</option>
                            <option>14</option>
                            <option>15</option>
                            <option>16</option>
                            <option>17</option>
                            <option>18</option>
                            <option>19</option>
                            <option>20</option>
                            <option>21</option>
                            <option>22</option>
                            <option>23</option>
                            <option>24</option>
                     </select>
                        &nbsp;&nbsp;
                     <select id="DateS10" runat="server">
                            <option selected>Minute</option>
                            <option>00</option>
                            <option>01</option>
                            <option>02</option>
                            <option>03</option>
                            <option>04</option>
                            <option>05</option>
                            <option>06</option>
                            <option>07</option>
                            <option>08</option>
                            <option>09</option>
                            <option>10</option>
                            <option>11</option>
                            <option>12</option>
                            <option>13</option>
                            <option>14</option>
                            <option>15</option>
                            <option>16</option>
                            <option>17</option>
                            <option>18</option>
                            <option>19</option>
                            <option>20</option>
                            <option>21</option>
                            <option>22</option>
                            <option>23</option>
                            <option>24</option>
                            <option>25</option>
                            <option>26</option>
                            <option>27</option>
                            <option>28</option>
                            <option>29</option>
                            <option>30</option>
                            <option>31</option>
                            <option>32</option>
                            <option>33</option>
                            <option>34</option>
                            <option>35</option>
                            <option>36</option>
                            <option>37</option>
                            <option>38</option>
                            <option>39</option>
                            <option>40</option>
                            <option>41</option>
                            <option>42</option>
                            <option>43</option>
                            <option>44</option>
                            <option>45</option>
                            <option>46</option>
                            <option>47</option>
                            <option>48</option>
                            <option>49</option>
                            <option>50</option>
                            <option>51</option>
                            <option>52</option>
                            <option>53</option>
                            <option>54</option>
                            <option>55</option>
                            <option>56</option>
                            <option>57</option>
                            <option>58</option>
                            <option>59</option>
                     </select>
                    </div>
                </div>

            <br />
            <div class="card">
                <div class="card-header"><b>จากสาเหตุใน STEP 3 ได้ทำการ Retest หรือไม่ ?</b></div>
                <select class="custom-select wide" id="SelectS6A2" runat="server">
                    <option selected>Please Select</option>
                    <option>ทำแล้ว</option>
                    <option>ไม่ได้ทำ</option>
                </select>
            </div>

            <br />
            <div class="p-3 mb-2 bg-info text-white">
                <h4>STEP 7</h4>
            </div>
            <div class="card">
                <div class="card-header"><b>Check Low Yield Kanban ledger ?</b></div>
                <asp:DropDownList CssClass="form-control wide" ID="SelectS7" runat="server">
                    <asp:ListItem Enabled="true" Text="Please Select"></asp:ListItem>
                    <asp:ListItem Text="มี"></asp:ListItem>
                    <asp:ListItem Text="ไม่มี"></asp:ListItem>
                    <asp:ListItem Text="หมดอายุ"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <br />
            <div class="card">
                <div class="card-header"><b>Contact NG?</b></div>
                <asp:DropDownList CssClass="form-control wide" ID="SelectS7_1" runat="server">
                    <asp:ListItem Enabled="true" Text="Please Select"></asp:ListItem>
                    <asp:ListItem Text="YES"></asp:ListItem>
                    <asp:ListItem Text="NO"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <br />
            <div class="card">
                <div class="card-header"><b>Test No. :(กรณีที่มี)</b></div>
                <asp:TextBox ID="tbS7" runat="server" CssClass="form-control wide"></asp:TextBox>
            </div>

            <br />
            <div class="card">
                <div class="card-header"><b>Check alarm Bin (28-31) ?</b></div>
                    <br />
                    <div class="row mx-2">
                        <asp:CheckBox CssClass="mx-auto" runat="server" ID="CheckS7A1" Text="Bin 28"/>
                        <asp:CheckBox CssClass="mx-auto" runat="server" ID="CheckS7A2" Text="Bin 29"/>
                        <asp:CheckBox CssClass="mx-auto" runat="server" ID="CheckS7A3" Text="Bin 30"/>
                        <asp:CheckBox CssClass="mx-auto" runat="server" ID="CheckS7A4" Text="Bin 31"/>
                        <asp:CheckBox CssClass="mx-auto" runat="server" ID="CheckS7A5" Text="ไม่มี"/>
                    </div>
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