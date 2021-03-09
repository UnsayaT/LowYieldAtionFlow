<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="LotMoveStep3.aspx.cs" Inherits="LowYieldCheckSheet.LotMoveStep3_Test" %>

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

        /* Create two unequal columns that floats next to each other */
        .column {
            float: left;
            padding: 10px;
        }

        .left {
            width: 50%;
        }

        .right {
            width: 50%;
        }
    </style>


    <script>
        function Multiply() {
            var n1 = 0;
            var n2 = 0;
            var text1 = document.getElementById('<%= tbR3B1.ClientID %>');
            var text2 = document.getElementById('<%= tbR3B2.ClientID %>');
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

            document.getElementById('<%= tbR3B3.ClientID %>').value = n1 * n2;
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

            var text1 = document.getElementById('<%= tbR1B.ClientID %>');
            var text2 = document.getElementById('<%= tbR2B1.ClientID %>');
            var text3 = document.getElementById('<%= tbR3B3.ClientID %>');
            var text4 = document.getElementById('<%= tbR4B.ClientID %>');
            var text5 = document.getElementById('<%= tbR5B.ClientID %>');
            var text6 = document.getElementById('<%= tbR6B.ClientID %>');
            var text7 = document.getElementById('<%= tbR7B.ClientID %>');
            var text8 = document.getElementById('<%= tbR8B.ClientID %>');
            var text9 = document.getElementById('<%= tbR9B.ClientID %>');

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


            document.getElementById('<%= tbTotalB.ClientID %>').value = (n1 + n2 + n3 + n4 + n5 + n6 + n7 + n8 + n9);
        }


        function Selectable1() {
            if (document.getElementById('<%=selectB1.ClientID %>').selectedIndex == 1) {
                document.getElementById('<%= tbR1B.ClientID %>').disabled = false;
                document.getElementById('<%= tbR1B.ClientID %>').value = 0;
                   getTotal();
            }
            else {
                document.getElementById('<%= tbR1B.ClientID %>').value = null;
                document.getElementById('<%= tbR1B.ClientID %>').disabled = true;
                   getTotal();
            }
        }

        function Selectable2() {
            if (document.getElementById('<%=selectB2.ClientID %>').selectedIndex == 1) {
                document.getElementById('<%= tbR2B1.ClientID %>').disabled = false;
                document.getElementById('<%= tbR2B2.ClientID %>').disabled = false;
                   document.getElementById('<%= tbR2B3.ClientID %>').disabled = false;
                   document.getElementById('<%= tbR2B1.ClientID %>').value = 0;
                document.getElementById('<%= tbR2B2.ClientID %>').value = 0;
                document.getElementById('<%= tbR2B3.ClientID %>').value = 0;
                getTotal();
            }
            else {
                document.getElementById('<%= tbR2B1.ClientID %>').value = null;
                document.getElementById('<%= tbR2B1.ClientID %>').disabled = true;

                   document.getElementById('<%= tbR2B2.ClientID %>').value = null;
                   document.getElementById('<%= tbR2B2.ClientID %>').disabled = true;

                document.getElementById('<%= tbR2B3.ClientID %>').value = null;
                document.getElementById('<%= tbR2B3.ClientID %>').disabled = true;
                getTotal();
            }
        }

        function Selectable3() {
            if (document.getElementById('<%=selectB3.ClientID %>').selectedIndex == 1) {
                   document.getElementById('<%= tbR3B1.ClientID %>').disabled = false;
                   document.getElementById('<%= tbR3B2.ClientID %>').disabled = false;
                   document.getElementById('<%= tbR3B3.ClientID %>').disabled = false
                document.getElementById('<%= tbR3B1.ClientID %>').value = 0;
                document.getElementById('<%= tbR3B2.ClientID %>').value = 0;
                document.getElementById('<%= tbR3B3.ClientID %>').value = 0;
                getTotal();
               }
               else {
                   document.getElementById('<%= tbR3B1.ClientID %>').value = null;
                   document.getElementById('<%= tbR3B1.ClientID %>').disabled = true;

                   document.getElementById('<%= tbR3B2.ClientID %>').value = null;
                   document.getElementById('<%= tbR3B2.ClientID %>').disabled = true;

                   document.getElementById('<%= tbR3B3.ClientID %>').value = null;
                   document.getElementById('<%= tbR3B3.ClientID %>').disabled = true;

                    getTotal();
            }
        }

        function Selectable4() {
            if (document.getElementById('<%=selectB4.ClientID %>').selectedIndex == 1) {
                   document.getElementById('<%= tbR4B.ClientID %>').disabled = false;
                   document.getElementById('<%= tbR4B.ClientID %>').value = 0;
                   getTotal();
               }
               else {
                   document.getElementById('<%= tbR4B.ClientID %>').value = null;
                   document.getElementById('<%= tbR4B.ClientID %>').disabled = true;
                   getTotal();
               }
           }

           function Selectable5() {
               if (document.getElementById('<%=selectB5.ClientID %>').selectedIndex == 1) {
                   document.getElementById('<%= tbR5B.ClientID %>').disabled = false;
                   document.getElementById('<%= tbR5B.ClientID %>').value = 0;
                   getTotal();
               }
               else {
                   document.getElementById('<%= tbR5B.ClientID %>').value = null;
                   document.getElementById('<%= tbR5B.ClientID %>').disabled = true;
                   getTotal();
               }
           }

           function Selectable6() {
               if (document.getElementById('<%=selectB6.ClientID %>').selectedIndex == 1) {
                   document.getElementById('<%= tbR6B.ClientID %>').disabled = false;
                   document.getElementById('<%= tbR6B.ClientID %>').value = 0;
                   getTotal();
               }
               else {
                   document.getElementById('<%= tbR6B.ClientID %>').value = null;
                   document.getElementById('<%= tbR6B.ClientID %>').disabled = true;
                   getTotal();
               }
           }

           function Selectable7() {
               if (document.getElementById('<%=selectB7.ClientID %>').selectedIndex == 1) {
                   document.getElementById('<%= tbR7B.ClientID %>').disabled = false;
                   document.getElementById('<%= tbR7B.ClientID %>').value = 0;
                   getTotal();
               }
               else {
                   document.getElementById('<%= tbR7B.ClientID %>').value = null;
                   document.getElementById('<%= tbR7B.ClientID %>').disabled = true;
                   getTotal();
               }
           }

           function Selectable8() {
               if (document.getElementById('<%=selectB8.ClientID %>').selectedIndex == 1) {
                   document.getElementById('<%= tbR8B.ClientID %>').disabled = false;
                   document.getElementById('<%= tbR8B.ClientID %>').value = 0;
                   getTotal();
               }
               else {
                   document.getElementById('<%= tbR8B.ClientID %>').value = null;
                   document.getElementById('<%= tbR8B.ClientID %>').disabled = true;
                   getTotal();
               }
           }

           function Selectable9() {
               if (document.getElementById('<%=selectB9.ClientID %>').selectedIndex == 1) {
                   document.getElementById('<%= tbR9B.ClientID %>').disabled = false;
                   document.getElementById('<%= tbR9B.ClientID %>').value = 0;
                   getTotal();
               }
               else {
                   document.getElementById('<%= tbR9B.ClientID %>').value = null;
                   document.getElementById('<%= tbR9B.ClientID %>').disabled = true;
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
        <input type="text" id="tbReason" runat="server" class="wide" disabled/>
    </div>

    <br />


    <div class="row">
        <div class="column left">
            <div class="card blackLine">
                <div class="card-header bg-dark text-white">
                    <h5>หัวข้อตรวจสอบ(Before feed back)</h5>
                </div>
                <div class="card-body">

                    <div class="card">
                        <h5 class="bg-dark text-white text-center">หัวข้อที่ 1</h5>
                        <select class="custom-select wide" id="select1" name="select1" runat="server" disabled>
                            <option selected>Please Select</option>
                            <option>มี</option>
                            <option>ไม่มี</option>
                        </select>
                        <br />
                        <b>TG Before (Pcs)</b>
                        <input type="text" id="tbR1" runat="server" class="wide" disabled />
                    </div>

                    <br />

                    <div class="card">
                        <h5 class="bg-dark text-white text-center">หัวข้อที่ 2</h5>
                        <select class="custom-select wide" id="select2" name="select2" runat="server" disabled>
                            <option selected>Please Select</option>
                            <option>มี</option>
                            <option>ไม่มี</option>
                        </select>
                        <br />
                        <b>Good (Pcs)</b>
                        <input type="text" id="tbR2A1" runat="server" class="wide" disabled />

                        <b>Std Reel</b>
                        <input type="text" id="tbR2A2" runat="server" class="wide" disabled />

                        <b>Hasuu reel</b>
                        <input type="text" id="tbR2A3" runat="server" class="wide" disabled />
                    </div>


                    <br />

                    <div class="card">
                        <h5 class="bg-dark text-white text-center">หัวข้อที่ 3</h5>
                        <select class="custom-select wide" id="select3" name="select3" runat="server" disabled>
                            <option selected>Please Select</option>
                            <option>มี</option>
                            <option>ไม่มี</option>
                        </select>
                        <br />
                        <b>Q'Ty (Frame)</b>
                        <input type="text" id="tbR3A1" runat="server" class="wide" disabled />

                        <b>Unit (Pcs/Frame)</b>
                        <input type="text" id="tbR3A2" runat="server" class="wide" disabled />

                        <b>Result (Pcs)</b>
                        <input type="text" id="tbR3A3" runat="server" class="wide" disabled />
                    </div>

                    <br />

                    <div class="card">
                        <h5 class="bg-dark text-white text-center">หัวข้อที่ 4</h5>
                        <select class="custom-select wide" id="select4" name="select4" runat="server" disabled>
                            <option selected>Please Select</option>
                            <option>มี</option>
                            <option>ไม่มี</option>
                        </select>
                        <br />
                        <b>O/S (Pcs)</b>
                        <input type="text" id="tbR4" runat="server" class="wide" disabled />
                    </div>

                    <br />

                    <div class="card">
                        <h5 class="bg-dark text-white text-center">หัวข้อที่ 5</h5>
                        <select class="custom-select wide" id="select5" name="select5" runat="server" disabled>
                            <option selected>Please Select</option>
                            <option>มี</option>
                            <option>ไม่มี</option>
                        </select>
                        <br />
                        <b>F/T (Pcs)</b>
                        <input type="text" id="tbR5" runat="server" class="wide" disabled />

                    </div>

                    <br />

                    <div class="card">
                        <h5 class="bg-dark text-white text-center">หัวข้อที่ 6</h5>
                        <select class="custom-select wide" id="select6" name="select6" runat="server" disabled>
                            <option selected>Please Select</option>
                            <option>มี</option>
                            <option>ไม่มี</option>
                        </select>
                        <br />
                        <b>Make (Pcs)</b>
                        <input type="text" id="tbR6" runat="server" class="wide" disabled />

                    </div>

                    <br />

                    <div class="card">
                        <h5 class="bg-dark text-white text-center">หัวข้อที่ 7</h5>
                        <select class="custom-select wide" id="select7" name="select7" runat="server" disabled>
                            <option selected>Please Select</option>
                            <option>มี</option>
                            <option>ไม่มี</option>
                        </select>
                        <br />
                        <b>Marker (Pcs)</b>
                        <input type="text" id="tbR7" runat="server" class="wide" disabled />

                    </div>

                    <br />

                    <div class="card">
                        <h5 class="bg-dark text-white text-center">หัวข้อที่ 8</h5>
                        <select class="custom-select wide" id="select8" name="select8" runat="server" disabled>
                            <option selected>Please Select</option>
                            <option>มี</option>
                            <option>ไม่มี</option>
                        </select>
                        <br />
                        <b>TP (Pcs)</b>
                        <input type="text" id="tbR8" runat="server" class="wide" disabled />

                    </div>

                    <br />

                    <div class="card">
                        <h5 class="bg-dark text-white text-center">หัวข้อที่ 9</h5>
                        <select class="custom-select wide" id="select9" name="select9" runat="server" disabled>
                            <option selected>Please Select</option>
                            <option>มี</option>
                            <option>ไม่มี</option>
                        </select>
                        <br />
                        <b>Missing (Pcs)</b>
                        <input type="text" id="tbR9" runat="server" class="wide" disabled />

                    </div>

                    <br />

                    <div class="card">
                        <h5 class="bg-dark text-white text-center">หัวข้อที่ 10</h5>
                        <select class="custom-select wide" id="select10" name="select10" runat="server" disabled>
                            <option selected>Please Select</option>
                            <option>มี</option>
                            <option>ไม่มี</option>
                        </select>
                        <br />
                        <b>Data Print</b>
                    </div>

                    <br />

                    <div class="card">
                        <h5 class="bg-dark text-white text-center">Total (Pcs)</h5>
                        <input type="text" id="tbTotal" runat="server" class="wide" disabled />
                    </div>



                </div>

            </div>
        </div>

        <div class="column right">
            <div class="card blackLine">
                <div class="card-header bg-info text-white">
                    <h5>หัวข้อตรวจสอบ(Before start run)</h5>
                </div>
                <div class="card-body">

                    <div class="card">
                        <h5 class="bg-info text-white text-center">หัวข้อที่ 1</h5>
                        <select class="custom-select wide" id="selectB1" name="selectB1" runat="server" onchange="Selectable1()">
                            <option selected>Please Select</option>
                            <option>มี</option>
                            <option>ไม่มี</option>
                        </select>
                        <br />
                        <b>TG Before (Pcs)</b>
                        <input type="text" id="tbR1B" runat="server" class="wide" onchange="getTotal()" onkeypress="return validatenumerics(event);" disabled/>
                    </div>

                    <br />

                    <div class="card">
                        <h5 class="bg-info text-white text-center">หัวข้อที่ 2</h5>
                        <select class="custom-select wide" id="selectB2" name="selectB2" runat="server" onchange="Selectable2()">
                            <option selected>Please Select</option>
                            <option>มี</option>
                            <option>ไม่มี</option>
                        </select>
                        <br />
                        <b>Good (Pcs)</b>
                        <input type="text" id="tbR2B1" runat="server" class="wide" onchange="getTotal()" onkeypress="return validatenumerics(event);" disabled/>

                        <b>Std Reel</b>
                        <input type="text" id="tbR2B2" runat="server" class="wide" onkeypress="return validatenumerics(event);" disabled />

                        <b>Hasuu reel</b>
                        <input type="text" id="tbR2B3" runat="server" class="wide" onkeypress="return validatenumerics(event);" disabled />
                    </div>


                    <br />

                    <div class="card">
                        <h5 class="bg-info text-white text-center">หัวข้อที่ 3</h5>
                        <select class="custom-select wide" id="selectB3" name="selectB3" runat="server" onchange="Selectable3()">
                            <option selected>Please Select</option>
                            <option>มี</option>
                            <option>ไม่มี</option>
                        </select>
                        <br />
                        <b>Q'Ty (Frame)</b>
                        <input type="text" id="tbR3B1" runat="server" class="wide" onchange="Multiply(),getTotal()" onkeypress="return validatenumerics(event);" disabled/>

                        <b>Unit (Pcs/Frame)</b>
                        <input type="text" id="tbR3B2" runat="server" class="wide" onchange="Multiply(),getTotal()" onkeypress="return validatenumerics(event);" disabled/>

                        <b>Result (Pcs)</b>
                        <input type="text" id="tbR3B3" runat="server" class="wide" onblur="getTotal()" onkeypress="return validatenumerics(event);" disabled />
                    </div>

                    <br />

                    <div class="card">
                        <h5 class="bg-info text-white text-center">หัวข้อที่ 4</h5>
                        <select class="custom-select wide" id="selectB4" name="selectB4" runat="server" onchange="Selectable4()">
                            <option selected>Please Select</option>
                            <option>มี</option>
                            <option>ไม่มี</option>
                        </select>
                        <br />
                        <b>O/S (Pcs)</b>
                        <input type="text" id="tbR4B" runat="server" class="wide" onblur="getTotal()" onkeypress="return validatenumerics(event);" disabled/>
                    </div>

                    <br />

                    <div class="card">
                        <h5 class="bg-info text-white text-center">หัวข้อที่ 5</h5>
                        <select class="custom-select wide" id="selectB5" name="selectB5" runat="server" onchange="Selectable5()">
                            <option selected>Please Select</option>
                            <option>มี</option>
                            <option>ไม่มี</option>
                        </select>
                        <br />
                        <b>F/T (Pcs)</b>
                        <input type="text" id="tbR5B" runat="server" class="wide" onchange="getTotal()" onkeypress="return validatenumerics(event);" disabled />

                    </div>

                    <br />

                    <div class="card">
                        <h5 class="bg-info text-white text-center">หัวข้อที่ 6</h5>
                        <select class="custom-select wide" id="selectB6" name="selectB6" runat="server" onchange="Selectable6()">
                            <option selected>Please Select</option>
                            <option>มี</option>
                            <option>ไม่มี</option>
                        </select>
                        <br />
                        <b>Make (Pcs)</b>
                        <input type="text" id="tbR6B" runat="server" class="wide" onchange="getTotal()" onkeypress="return validatenumerics(event);" disabled/>

                    </div>

                    <br />

                    <div class="card">
                        <h5 class="bg-info text-white text-center">หัวข้อที่ 7</h5>
                        <select class="custom-select wide" id="selectB7" name="selectB7" runat="server" onchange="Selectable7()">
                            <option selected>Please Select</option>
                            <option>มี</option>
                            <option>ไม่มี</option>
                        </select>
                        <br />
                        <b>Marker (Pcs)</b>
                        <input type="text" id="tbR7B" runat="server" class="wide" onchange="getTotal()" onkeypress="return validatenumerics(event);" disabled />

                    </div>

                    <br />

                    <div class="card">
                        <h5 class="bg-info text-white text-center">หัวข้อที่ 8</h5>
                        <select class="custom-select wide" id="selectB8" name="selectB8" runat="server" onchange="Selectable8()">
                            <option selected>Please Select</option>
                            <option>มี</option>
                            <option>ไม่มี</option>
                        </select>
                        <br />
                        <b>TP (Pcs)</b>
                        <input type="text" id="tbR8B" runat="server" class="wide" onchange="getTotal()" onkeypress="return validatenumerics(event);" disabled />

                    </div>

                    <br />

                    <div class="card">
                        <h5 class="bg-info text-white text-center">หัวข้อที่ 9</h5>
                        <select class="custom-select wide" id="selectB9" name="selectB9" runat="server" onchange="Selectable9()">
                            <option selected>Please Select</option>
                            <option>มี</option>
                            <option>ไม่มี</option>
                        </select>
                        <br />
                        <b>Missing (Pcs)</b>
                        <input type="text" id="tbR9B" runat="server" class="wide" onchange="getTotal()" onkeypress="return validatenumerics(event);" disabled />

                    </div>

                    <br />

                    <div class="card">
                        <h5 class="bg-info text-white text-center">หัวข้อที่ 10</h5>
                        <select class="custom-select wide" id="selectB10" name="selectB10" runat="server">
                            <option selected>Please Select</option>
                            <option>มี</option>
                            <option>ไม่มี</option>
                        </select>
                        <br />
                        <b>Data Print</b>
                    </div>

                    <br />

                    <div class="card">
                        <h5 class="bg-info text-white text-center">Total (Pcs)</h5>
                        <input type="text" id="tbTotalB" runat="server" class="wide" onfocus="getTotal()" onkeypress="return validatenumerics(event);" />
                    </div>



                </div>

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

