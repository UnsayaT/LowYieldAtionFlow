<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="LotMoveStep2.aspx.cs" Inherits="LowYieldCheckSheet.LotMoveStep2_Test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <style>
        .blackLine {
            border: 1px solid black;
        }

        .wide {
            height: 32px;
            width: 100%;
            min-width: 100%;
            border: 1px solid black;
        }
        .BgColData {
            background-color: #fffc6a
        }
    </style>


    <script type="text/javascript">
        function Multiply() {
            var n1 = 0;
            var n2 = 0;
            var text1 = document.getElementById('<%= tbR3A1.ClientID %>');
            var text2 = document.getElementById('<%= tbR3A2.ClientID %>');

            //if (text1.value.length == 0 || text2.value.length == 0) {
            //        alert('QTy and Unit should not be empty');
            //        return;
            //}
            if (text1.value.lenght != 0 && text1.value != "") {
                n1 = parseInt(text1.value);
            }

            if (text2.value.lenght != 0 && text2.value != "") {
                n2 = parseInt(text2.value);
            }

            document.getElementById('<%= tbR3A3.ClientID %>').value = n1 * n2;
        }

        function getTotal() {
            var n1 = parseInt(0);
            var n2 = parseInt(0);
            var n3 = parseInt(0);
            var n4 = parseInt(0);
            var n5 = parseInt(0);
            var n6 = parseInt(0);
            var n7 = parseInt(0);
            var n8 = parseInt(0);
            var n9 = parseInt(0);

            var text1 = document.getElementById('<%= tbR1.ClientID %>');
            var text2 = document.getElementById('<%= tbR2A1.ClientID %>');
            var text3 = document.getElementById('<%= tbR3A3.ClientID %>');
            var text4 = document.getElementById('<%= tbR4.ClientID %>');
            var text5 = document.getElementById('<%= tbR5.ClientID %>');
            var text6 = document.getElementById('<%= tbR6.ClientID %>');
            var text7 = document.getElementById('<%= tbR7.ClientID %>');
            var text8 = document.getElementById('<%= tbR8.ClientID %>');
            var text9 = document.getElementById('<%= tbR9.ClientID %>');

            if (text1.value.lenght != 0 && text1.value != "") {
                n1 = parseInt(text1.value);
            }

            if (text2.value.lenght != 0 && text2.value != "") {
                n2 = parseInt(text2.value);
            }

            if (text3.value.lenght != 0 && text3.value != "") {
                n3 = parseInt(text3.value);
            }

            if (text4.value.lenght != 0 && text4.value != "") {
                n4 = parseInt(text4.value);
            }

            if (text5.value.lenght != 0 && text5.value != "") {
                n5 = parseInt(text5.value);
            }

            if (text6.value.lenght != 0 && text6.value != "") {
                n6 = parseInt(text6.value);
            }

            if (text7.value.lenght != 0 && text7.value != "") {
                n7 = parseInt(text7.value);
            }

            if (text8.value.lenght != 0 && text8.value != "") {
                n8 = parseInt(text8.value);
            }

            if (text9.value.lenght != 0 && text9.value != "") {
                n9 = parseInt(text9.value);
            }

            document.getElementById('<%= tbTotal.ClientID %>').value = (n1 + n2 + n3 + n4 + n5 + n6 + n7 + n8 + n9);
        }


        function Selectable1() {
            if (document.getElementById('<%=select1.ClientID %>').selectedIndex == 1) {
                document.getElementById('<%= tbR1.ClientID %>').disabled = false;
                document.getElementById('<%= tbR1.ClientID %>').value = 0;
                getTotal();
            }
            else {
                document.getElementById('<%= tbR1.ClientID %>').value = null;
                document.getElementById('<%= tbR1.ClientID %>').disabled = true;
                getTotal();
            }
        }

        function Selectable2() {
            if (document.getElementById('<%=select2.ClientID %>').selectedIndex == 1) {
                document.getElementById('<%= tbR2A1.ClientID %>').disabled = false;
                document.getElementById('<%= tbR2A2.ClientID %>').disabled = false;
                document.getElementById('<%= tbR2A3.ClientID %>').disabled = false;
                document.getElementById('<%= tbR2A1.ClientID %>').value = 0;
                document.getElementById('<%= tbR2A2.ClientID %>').value = 0;
                document.getElementById('<%= tbR2A3.ClientID %>').value = 0;
                getTotal();
            }
            else {
                document.getElementById('<%= tbR2A1.ClientID %>').value = null;
                document.getElementById('<%= tbR2A1.ClientID %>').disabled = true;

                document.getElementById('<%= tbR2A2.ClientID %>').value = null;
                document.getElementById('<%= tbR2A2.ClientID %>').disabled = true;

                document.getElementById('<%= tbR2A3.ClientID %>').value = null;
                document.getElementById('<%= tbR2A3.ClientID %>').disabled = true;
                getTotal();
            }
        }

        function Selectable3() {
            if (document.getElementById('<%=select3.ClientID %>').selectedIndex == 1) {
                document.getElementById('<%= tbR3A1.ClientID %>').disabled = false;
                document.getElementById('<%= tbR3A2.ClientID %>').disabled = false;
                document.getElementById('<%= tbR3A3.ClientID %>').disabled = false
                document.getElementById('<%= tbR3A1.ClientID %>').value = 0;
                document.getElementById('<%= tbR3A2.ClientID %>').value = 0;
                document.getElementById('<%= tbR3A3.ClientID %>').value = 0;
                getTotal();
            }
            else {
                document.getElementById('<%= tbR3A1.ClientID %>').value = null;
                document.getElementById('<%= tbR3A1.ClientID %>').disabled = true;

                document.getElementById('<%= tbR3A2.ClientID %>').value = null;
                document.getElementById('<%= tbR3A2.ClientID %>').disabled = true;

                document.getElementById('<%= tbR3A3.ClientID %>').value = null;
                document.getElementById('<%= tbR3A3.ClientID %>').disabled = true;

                getTotal();
            }
        }

        function Selectable4() {
            if (document.getElementById('<%=select4.ClientID %>').selectedIndex == 1) {
                document.getElementById('<%= tbR4.ClientID %>').disabled = false;
                document.getElementById('<%= tbR4.ClientID %>').value = 0;
                getTotal();
            }
            else {
                document.getElementById('<%= tbR4.ClientID %>').value = null;
                document.getElementById('<%= tbR4.ClientID %>').disabled = true;
                getTotal();
            }
        }

        function Selectable5() {
            if (document.getElementById('<%=select5.ClientID %>').selectedIndex == 1) {
                document.getElementById('<%= tbR5.ClientID %>').disabled = false;
                document.getElementById('<%= tbR5.ClientID %>').value = 0;
                getTotal();
            }
            else {
                document.getElementById('<%= tbR5.ClientID %>').value = null;
                document.getElementById('<%= tbR5.ClientID %>').disabled = true;
                getTotal();
            }
        }

        function Selectable6() {
            if (document.getElementById('<%=select6.ClientID %>').selectedIndex == 1) {
                document.getElementById('<%= tbR6.ClientID %>').disabled = false;
                document.getElementById('<%= tbR6.ClientID %>').value = 0;
                getTotal();
            }
            else {
                document.getElementById('<%= tbR6.ClientID %>').value = null;
                document.getElementById('<%= tbR6.ClientID %>').disabled = true;
                getTotal();
            }
        }

        function Selectable7() {
            if (document.getElementById('<%=select7.ClientID %>').selectedIndex == 1) {
                document.getElementById('<%= tbR7.ClientID %>').disabled = false;
                document.getElementById('<%= tbR7.ClientID %>').value = 0;
                getTotal();
            }
            else {
                document.getElementById('<%= tbR7.ClientID %>').value = null;
                document.getElementById('<%= tbR7.ClientID %>').disabled = true;
                getTotal();
            }
        }

        function Selectable8() {
            if (document.getElementById('<%=select8.ClientID %>').selectedIndex == 1) {
                document.getElementById('<%= tbR8.ClientID %>').disabled = false;
                document.getElementById('<%= tbR8.ClientID %>').value = 0;
                getTotal();
            }
            else {
                document.getElementById('<%= tbR8.ClientID %>').value = null;
                document.getElementById('<%= tbR8.ClientID %>').disabled = true;
                getTotal();
            }
        }

        function Selectable9() {
            if (document.getElementById('<%=select9.ClientID %>').selectedIndex == 1) {
                document.getElementById('<%= tbR9.ClientID %>').disabled = false;
                document.getElementById('<%= tbR9.ClientID %>').value = 0;
                getTotal();
            }
            else {
                document.getElementById('<%= tbR9.ClientID %>').value = null;
                document.getElementById('<%= tbR9.ClientID %>').disabled = true;
                getTotal();
            }
        }


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


    </script>





    <div class="jumbotron">
        <h1 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold;">LOT MOVE CHECK SHEET</h1>
    </div>


    <div class="card">
        <h5 class="card-header bg-info text-white">Date</h5>
        <input type="text" id="tbDate" runat="server" class="wide" disabled />


        <br />
        <h5 class="card-header bg-info text-white">Device</h5>
        <input type="text" id="tbDevice" runat="server" class="wide" disabled />

        <br />
        <h5 class="card-header bg-info text-white">Lot No</h5>
        <input type="text" id="tbLotNo" runat="server" class="wide" disabled />

        <br />
        <h5 class="card-header bg-info text-white">MC No</h5>
        <input type="text" id="tbMCNo" runat="server" class="wide" disabled />

        <br />
        <h5 class="card-header bg-info text-white">สาเหตุการ Move Lot</h5>
        <input type="text" id="tbReason" runat="server" class="wide BgColData" />
    </div>

    <br />

    <div class="card blackLine">
        <div class="card-header bg-info text-white">
            <h5>หัวข้อตรวจสอบ(Before feed back)</h5>
        </div>
        <div class="card-body">

            <div class="card-body">
                <h5 class="bg-info text-white text-center">หัวข้อที่ 1</h5>
                <select class="custom-select wide BgColData" id="select1" name="select1" runat="server" onchange="Selectable1()">
                    <option selected>Please Select</option>
                    <option>มี</option>
                    <option>ไม่มี</option>
                </select>
                <br /><br />
                <b>TG Before (Pcs)</b>
                <input type="number" id="tbR1" runat="server" class="wide BgColData" onchange="getTotal()" onkeypress="return validatenumerics(event);" disabled />
            </div>

            <br />

            <div class="card-body">
                <h5 class="bg-info text-white text-center">หัวข้อที่ 2</h5>
                <select class="custom-select wide BgColData" id="select2" name="select2" runat="server" onchange="Selectable2()">
                    <option selected>Please Select</option>
                    <option>มี</option>
                    <option>ไม่มี</option>
                </select>
                <br /><br />
                <b>Good (Pcs)</b>
                <input type="number" id="tbR2A1" runat="server" class="wide BgColData" onchange="getTotal()" onkeypress="return validatenumerics(event);" disabled/>

                <b>Std Reel</b>
                <input type="number" id="tbR2A2" runat="server" class="wide BgColData" onkeypress="return validatenumerics(event);" disabled/>

                <b>Hasuu reel</b>
                <input type="number" id="tbR2A3" runat="server" class="wide BgColData" onkeypress="return validatenumerics(event);" disabled/>
            </div>


            <br />

            <div class="card-body">
                <h5 class="bg-info text-white text-center">หัวข้อที่ 3</h5>
                <select class="custom-select wide BgColData" id="select3" name="select3" runat="server" onchange="Selectable3()">
                    <option selected>Please Select</option>
                    <option>มี</option>
                    <option>ไม่มี</option>
                </select>
                <br /><br />
                <b>Q'Ty (Frame)</b>
                <input type="number" id="tbR3A1" runat="server" class="wide BgColData" onchange="Multiply(),getTotal()" onkeypress="return validatenumerics(event);" disabled/>

                <b>Unit (Pcs/Frame)</b>
                <input type="number" id="tbR3A2" runat="server" class="wide BgColData" onchange="Multiply(),getTotal()" onkeypress="return validatenumerics(event);" disabled/>

                <b>Result (Pcs)</b>
                <input type="number" id="tbR3A3" runat="server" class="wide" onblur="getTotal()" onkeypress="return validatenumerics(event);" disabled />
            </div>

            <br />

            <div class="card-body">
                <h5 class="bg-info text-white text-center">หัวข้อที่ 4</h5>
                <select class="custom-select wide BgColData" id="select4" name="select4" runat="server" onchange="Selectable4()">
                    <option selected>Please Select</option>
                    <option>มี</option>
                    <option>ไม่มี</option>
                </select>
                <br /><br />
                <b>O/S (Pcs)</b>
                <input type="number" id="tbR4" runat="server" class="wide BgColData" onchange="getTotal()" onkeypress="return validatenumerics(event);" disabled/>
            </div>

            <br />

            <div class="card-body">
                <h5 class="bg-info text-white text-center">หัวข้อที่ 5</h5>
                <select class="custom-select wide BgColData" id="select5" name="select5" runat="server" onchange="Selectable5()">
                    <option selected>Please Select</option>
                    <option>มี</option>
                    <option>ไม่มี</option>
                </select>
                <br /><br />
                <b>F/T (Pcs)</b>
                <input type="number" id="tbR5" runat="server" class="wide BgColData" onchange="getTotal()" onkeypress="return validatenumerics(event);" disabled/>

            </div>

            <br />

            <div class="card-body">
                <h5 class="bg-info text-white text-center">หัวข้อที่ 6</h5>
                <select class="custom-select wide BgColData" id="select6" name="select6" runat="server" onchange="Selectable6()">
                    <option selected>Please Select</option>
                    <option>มี</option>
                    <option>ไม่มี</option>
                </select>
                <br /><br />
                <b>Make (Pcs)</b>
                <input type="number" id="tbR6" runat="server" class="wide BgColData" onchange="getTotal()" onkeypress="return validatenumerics(event);" disabled/>

            </div>

            <br />

            <div class="card-body">
                <h5 class="bg-info text-white text-center">หัวข้อที่ 7</h5>
                <select class="custom-select wide BgColData" id="select7" name="select7" runat="server" onchange="Selectable7()">
                    <option selected>Please Select</option>
                    <option>มี</option>
                    <option>ไม่มี</option>
                </select>
                <br /><br />
                <b>Marker (Pcs)</b>
                <input type="number" id="tbR7" runat="server" class="wide BgColData" onchange="getTotal()" onkeypress="return validatenumerics(event);" disabled/>

            </div>

            <br />

            <div class="card-body">
                <h5 class="bg-info text-white text-center">หัวข้อที่ 8</h5>
                <select class="custom-select wide BgColData" id="select8" name="select8" runat="server" onchange="Selectable8()">
                    <option selected>Please Select</option>
                    <option>มี</option>
                    <option>ไม่มี</option>
                </select>
                <br /><br />
                <b>TP (Pcs)</b>
                <input type="number" id="tbR8" runat="server" class="wide BgColData" onchange="getTotal()" onkeypress="return validatenumerics(event);" disabled/>

            </div>

            <br />

            <div class="card-body">
                <h5 class="bg-info text-white text-center">หัวข้อที่ 9</h5>
                <select class="custom-select wide BgColData" id="select9" name="select9" runat="server" onchange="Selectable9()">
                    <option selected>Please Select</option>
                    <option>มี</option>
                    <option>ไม่มี</option>
                </select>
                <br /><br />
                <b>Missing (Pcs)</b>
                <input type="number" id="tbR9" runat="server" class="wide BgColData" onchange="getTotal()" onkeypress="return validatenumerics(event);" disabled/>

            </div>

            <br />

            <div class="card-body">
                <h5 class="bg-info text-white text-center">หัวข้อที่ 10</h5>
                <select class="custom-select wide BgColData" id="select10" name="select10" runat="server">
                    <option selected>Please Select</option>
                    <option>มี</option>
                    <option>ไม่มี</option>
                </select>
                <br /><br />
                <b>Data Print</b>
            </div>

            <br />

            <div class="card-body">
                <h5 class="bg-info text-white text-center">Total (Pcs)</h5>
                <input type="number" id="tbTotal" runat="server" class="wide BgColData" onfocus="getTotal()" onkeypress="return validatenumerics(event);"/>
            </div>


        </div>
    </div>

    <br />
    <br />
    <div>
        <button type="button" class="btn btn-success btn-lg btn-block" data-toggle="modal" data-target="#SaveModal">SAVE</button>
        <br />
        <button type="button" class="btn btn-danger btn-lg btn-block" runat="server" name ="btnClose" id="btnClose" onserverclick="btnClose_ServerClick">CLOSE</button>
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
                    <button type="button" class="btn btn-success" runat="server" name ="btnConfirm" id="btnConfirm" onserverclick="btnConfirm_ServerClick">Confirm</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cancel</button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

