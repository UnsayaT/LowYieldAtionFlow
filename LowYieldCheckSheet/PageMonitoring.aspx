  
<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PageMonitoring.aspx.cs" Inherits="LowYieldCheckSheet.PageMonitoring_Test" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .auto-style1 {
            text-align: center;
        }

        .gridviewFit {
            width: 100%;
            word-wrap: break-word;
            table-layout: fixed;
            font-size: 1vw;
            /*PS.Viewport is the browser window size. 1vw = 1% of viewport width. If the viewport is 50cm wide, 1vw is 0.5cm.*/
        }

        .SetCenter1 {
            margin: auto;
            width: 80%;
        }
    </style>


    <script type="text/javascript">

        function openLoginModal() {
            $('#LoginModal').modal('show');
        }

        function openDescribeModal() {
            $('#DescribeModal').modal('show');
        }

        function openOptionModal() {
            $('#OptionModal').modal('show');
        }

        function openEditModal() {
            $('#EditModal').modal('show');
        }
    </script>

    <div class="jumbotron">
        <h2 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold;">LOW YIELD ACTION FLOW ONLINE</h2>
    </div>

    <div class="row">
        <div class="mx-auto">
            <button type="button" class="btn btn-outline-primary" style="width: 200px" runat="server" onserverclick="GoHistoryAdvance">History Advance</button>
        </div>
        <div class="mx-auto">
            <button type="button" class="btn btn-outline-primary" style="width: 200px" runat="server" onserverclick="GoHistoryDaily">History Daily</button>
        </div>
    </div>
<%--    <button class="btn btn-primary btn-block" type="button" data-toggle="collapse" data-target="#CL2" aria-expanded="false" aria-controls="collapseExample">
        <h5>Fuction Search</h5>
    </button>--%>
    <br />
    <div class="collapse show" id="CL2">
        <div class="card card-body">
            <div class="row">
                <div class="col-sm">
                    <label><b>Package :</b></label>
                    <input type="text" runat="server" id="tbPackage" class="form-control CustomHeight wide" name="tbPackage" style="border: 1px solid black;" />
                </div>
                <div class="col-sm">
                    <label><b>MCNo :</b></label>
                    <input type="text" runat="server" id="tbMCNo" class="form-control CustomHeight wide" name="tbMCNo" style="border: 1px solid black;" />
                </div>
                <div class="col-sm">
                    <label><b>LotNo :</b></label>
                    <input type="text" runat="server" id="tbLotNo" class="form-control CustomHeight wide" name="tbLotNo" style="border: 1px solid black;" />
                </div>
                <div class="col-sm">
                    <label><b>Device :</b></label>
                    <input type="text" runat="server" id="tbDevice" class="form-control CustomHeight wide" name="tbDevice" style="border: 1px solid black;" />
                </div>
            </div>

            <br />

            <div class="row">
                <div class="col-sm">
                    <label><b>Process :</b></label>
                    <select class="form-control CustomHeight wide" id="SearchSelect1" name="SearchSelect1" runat="server" style="border: 1px solid black;">
                        <option selected>Please Select</option>
                        <option>FL</option>
                        <option>FT</option>
                        <option>MAPPING</option>
                    </select>
                </div>
                <div class="col-sm">
                    <label><b>Flow :</b></label>
                    <select class="form-control CustomHeight widee" id="SearchSelect2" name="SearchSelect2" runat="server" style="border: 1px solid black;">
                        <option selected>Please Select</option>
                        <option>AUTO1</option>
                        <option>AUTO2</option>
                        <option>AUTO3</option>
                        <option>AUTO4</option>
                    </select>
                </div>
                <div class="col-sm">
                    <label><b>Status :</b></label>
                    <select class="form-control CustomHeight wide" id="SearchSelect3" name="SearchSelect3" runat="server" style="border: 1px solid black;">
                        <option selected>Please Select</option>
                        <option>NEW</option>
                        <option>BM</option>
                        <option>OP2</option>
                        <option>GL</option>
                        <option>FQI</option>
                        <option>FYI</option>
                        <option>PD MGR</option>
                        <option>QC</option>
                    </select>
                </div>
                <div class="col-sm">
                    <label><b>Request Type :</b></label>
                    <select class="form-control CustomHeight wide" id="SearchSelect4" name="SearchSelect4" runat="server" style="border: 1px solid black;">
                        <option selected>Please Select</option>
                        <option>LOW YIELD</option>
                        <option>ALARM</option>
                        <option>LOW YIELD & ALARM</option>
                    </select>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-sm"></div>
                <div class="col-sm"></div>
                <div class="col-sm">
                        <button class="btn btn-success wide" runat="server" id="btnSearch" onserverclick="btnSearch_ServerClick">Search</button>
                </div>
                <div class="col-sm"></div>
            </div>
        </div>
    </div>

    <button class="btn btn-dark btn-block" type="button" data-toggle="collapse" data-target="#CL1" aria-expanded="false" aria-controls="collapseExample">
    <h5>Detail</h5>
    </button>
    <div class="collapse" id="CL1">
        <div class="card card-body">

            <div class="row">
                <div class="row col">
                    <asp:Image ID="Image1" runat="server" Height="46px" Width="46px" ImageUrl='~/Images/NEW_100px.gif' />
                    <b><i class="fas fa-caret-right"></i>New Request From Machine</b>
                </div>

                <div class="row col">
                    <asp:Image ID="Image2" runat="server" Height="46px" Width="46px" ImageUrl='~/Images/user2.png' />
                    <b><i class="fas fa-caret-right"></i>Test Incharge</b>
                </div>

                <div class="row col">
                    <asp:Image ID="Image3" runat="server" Height="46px" Width="46px" ImageUrl='~/Images/user3.png' />
                    <b><i class="fas fa-caret-right"></i>Operator Incharge</b>
                </div>
            </div>

            <br />

            <div class="row">
                <div class="row col">
                    <asp:Image ID="Image4" runat="server" Height="46px" Width="46px" ImageUrl='~/Images/user4.png' />
                    <b><i class="fas fa-caret-right"></i>(GL) Group Leader Incharge</b>
                </div>

                <div class="row col">
                    <asp:Image ID="Image6" runat="server" Height="46px" Width="46px" ImageUrl='~/Images/FQI.png' />
                    <b><i class="fas fa-caret-right"></i>FQI</b>
                </div>

                <div class="row col">
                    <asp:Image ID="Image13" runat="server" Height="46px" Width="46px" ImageUrl='~/Images/FYI.png' />
                    <b><i class="fas fa-caret-right"></i>FYI</b>
                </div>
            </div>

            <br />

            <div class="row">
                <div class="row col">
                    <asp:Image ID="Image7" runat="server" Height="46px" Width="46px" ImageUrl='~/Images/QCIn.png' />
                    <b><i class="fas fa-caret-right"></i>QC Incharge</b>
                </div>

                <div class="row col">
                    <asp:Image ID="Image5" runat="server" Height="46px" Width="46px" ImageUrl='~/Images/QAApp.png' />
                    <b><i class="fas fa-caret-right"></i>QC Approve</b>
                </div>

                <div class="row col">
                    <asp:Image ID="Image8" runat="server" Height="46px" Width="46px" ImageUrl='~/Images/user9.png' />
                    <b><i class="fas fa-caret-right"></i>(PD Mgr.)Production Manager Incharge</b>
                </div>
                
            </div>
        </div>
    </div>


    <div>
        <%-- Timer Interval mSec --%>
        <asp:Timer ID="Timer1" runat="server" Interval="180000" OnTick="Timer1_Tick"></asp:Timer>
    </div>


    <div class="auto-style1">
        
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:GridView CssClass="gridviewFit" ID="GridViewPageMonitoring" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Inset" BorderWidth="3px" CellPadding="3"
                    ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" AllowPaging="True" DataSourceID="SqlDataSource1" OnRowCommand="GridView1_RowCommand" Width="100%" PageSize="10" OnPageIndexChanging = "OnPaging">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />

                    <Columns>

                        <asp:TemplateField HeaderText="No.">
                            <ItemTemplate>
                                <asp:Label ID="labelNo" runat="server" Text='<%# Container.DataItemIndex + 1 %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="Process" HeaderText="Process" SortExpression="Process" />
                        <asp:BoundField DataField="HandlerNo" HeaderText="MCNo" SortExpression="HandlerNo" />
                        <asp:BoundField DataField="PackageName" HeaderText="Package" SortExpression="PackageName" />
                        <asp:BoundField DataField="DeviceName" HeaderText="Device" SortExpression="DeviceName" />
                        <asp:BoundField DataField="LotNo" HeaderText="LotNo" SortExpression="LotNo" />
                        <asp:BoundField DataField="Flow" HeaderText="Flow" SortExpression="Flow" />
                        <asp:BoundField DataField="PackageName" HeaderText="PackageName" SortExpression="PackageName" Visible="false"/>


                        <asp:TemplateField HeaderText="LCL">
                            <ItemTemplate>
                                <asp:Label ID="lblColumnLCL" runat="server" Text='<%# GetLCL((string)Eval("RequestType"),Eval("ControlYield"),Eval("ControlLCL"))%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Yield">
                            <ItemTemplate>
                                <asp:Label ID="lblColumnYield" runat="server" Text='<%# GetYield((string)Eval("RequestType"),Eval("InitialYield"),Eval("FinalYield"))%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                       <%-- <asp:TemplateField HeaderText="Req-Type">
                            <ItemTemplate>
                                <asp:Label ID="lblColumnRequestType" runat="server" Font-Size="Small" Text='<%# GetRequestType((string)Eval("RequestType"),Eval("Mode"),Eval("CheckAlarmBin"))%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                        <asp:BoundField DataField="AndonManageDetail" HeaderText="Req-Type" SortExpression="AndonManageDetail" />
                        <asp:BoundField DataField="RequestDate" HeaderText="Req-Date" SortExpression="RequestDate" />

                        <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" Visible="false" />

                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnStatus" runat="server" Height="56px" Width="56px" ImageUrl='<%# GetImage((string)Eval("Status"))%>'
                                    CommandName="EditSheet" CommandArgument='<%#Eval("Process")+","+Eval("HandlerNo")+ "," +Eval("DeviceName") + "," + Eval("LotNo") + "," + Eval("Status") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Option">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnCancel" runat="server" Height="42px" Width="42px" ImageUrl="~/Images/Option.png"
                                    CommandName="Option" CommandArgument='<%#Eval("Process")+","+Eval("HandlerNo")+ "," +Eval("DeviceName") + "," + Eval("LotNo") + "," + Eval("Status") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBxConnectionString %>" SelectCommand="SELECT [Process], [HandlerNo], [LotNo], [PackageName], [DeviceName], [RequestDate], [Status], [RequestType], [Flow], [InitialYield], [ControlYield], [FinalYield], [ControlLCL],[CheckAlarmBin],[Mode],[AndonManageDetail] FROM [LowYieldActionReport] WHERE [Status]!='CANCEL' ORDER BY [RequestDate] DESC"></asp:SqlDataSource>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <div>
        <asp:TextBox runat="server" Text="" ID="txtStoreValue" Visible="false"></asp:TextBox>
    </div>

    <!-- Modal HTML   LOGIN   -->
    <div id="LoginModal" class="modal fade">
        <div class="modal-dialog modal-login">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">User Login</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>

                <div class="modal-body">

                    <div class="form-group">
                        <i class="fa fa-user"></i>
                        <input type="text" runat="server" id="tbUserID" class="form-control" placeholder="User ID" autocomplete="off">
                    </div>

                    <br />

                    <div class="form-group">
                        <button type="button" class="btn btn-primary btn-block btn-lg" runat="server" name="BtnSubmitLogin" id="BtnSubmitLogin" onserverclick="BtnSubmitLogin_ServerClick">Login</button>
                    </div>

                </div>
            </div>
        </div>
    </div>


    <!-- Modal HTML Describe -->
    <div id="DescribeModal" class="modal fade">
        <div class="modal-dialog modal-login">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Input DeScribe</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>

                <div class="modal-body">

                    <div class="form-group">
                        <i class="far fa-keyboard"></i>
                        <input type="text" runat="server" id="txtDescribe" class="form-control" autocomplete="off">
                    </div>

                    <br />

                    <div class="form-group">
                        <button type="button" class="btn btn-primary btn-block btn-lg" runat="server" name="BtnSubmitDescribe" id="BtnSubmitDescribe" onserverclick="BtnSubmitDescribe_ServerClick">Confirm</button>
                    </div>

                </div>
            </div>
        </div>
    </div>


    <!-- Modal HTML Option-->
    <div id="OptionModal" class="modal fade">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Option Menu</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>

                <div class="modal-body SetCenter1">


                    <div class="mx-auto">
                        <asp:ImageButton ID="ImBtnCancelLot" runat="server" Height="46px" Width="46px" ImageUrl='~/Images/Cancel.png' OnClick="ImBtnCancelLot_Click" />
                        <b><i class="fas fa-caret-right"></i>Cancel Lot</b>
                    </div>

                    <br />

                    <div class="mx-auto">
                        <asp:ImageButton ID="ImBtnCheckSheet" runat="server" Height="46px" Width="46px" ImageUrl='~/Images/ViewSheet.png' OnClick="ImBtnCheckSheet_Click" />
                        <b><i class="fas fa-caret-right"></i>View Sheet</b>
                    </div>

                    <br />

                    <div class="mx-auto">
                        <asp:ImageButton ID="ImBtnEditCheckSheet" runat="server" Height="46px" Width="46px" ImageUrl='~/Images/CheckSheet.png' OnClick="ImBtnEditCheckSheet_Click" />
                        <b><i class="fas fa-caret-right"></i>Edit Data</b>
                    </div>





                </div>
            </div>
        </div>
    </div>

    <asp:TextBox runat="server" Text="" ID="txtPackageName" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtDeviceName" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtRequestDate" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtMode" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtStatus" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtRequestType" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtAmountNG" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtFlow" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtMNo" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtTesterNo" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtBoxNo" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtTRank" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtWaferLotNo" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtWaferSheetNo" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtTPRank" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtShipment" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtInputQuantity" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtControlYield" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtInitialYield" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtCheckValue" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtActionPCS" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtActionPercent" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtS2TestNoA1" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtS2TestNoA2" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtS2TestNoA3" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtS2TestNoA4" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtS2TestNoA5" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtS2NG_A1" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtS2NG_A2" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtS2NG_A3" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtS2NG_A4" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtS2NG_A5" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtS2TestNoB1" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtS2TestNoB2" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtS2TestNoB3" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtS2TestNoB4" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtS2TestNoB5" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtS2NG_B1" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtS2NG_B2" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtS2NG_B3" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtS2NG_B4" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtS2NG_B5" Visible="false"></asp:TextBox>
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
    <asp:TextBox runat="server" Text="" ID="txtSocketChangeLastDate" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtIsRestartStep3" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtCheckLowYieldKanban" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtCheckAlarmBin" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtTesterChecker" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtSetup" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtTNo1" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtTNo2" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtTNo3" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtTNo4" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtTNo5" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtLimitLow1" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtLimitLow2" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtLimitLow3" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtLimitLow4" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtLimitLow5" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtLimitHigh1" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtLimitHigh2" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtLimitHigh3" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtLimitHigh4" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtLimitHigh5" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtMassProductNG1" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtMassProductNG2" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtMassProductNG3" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtMassProductNG4" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtMassProductNG5" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtGoodSample1" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtGoodSample2" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtGoodSample3" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtGoodSample4" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtGoodSample5" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtTesterETC1" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtTesterETC2" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtTesterETC3" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtTesterETC4" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtTesterETC5" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtCheckRepeat1" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtCheckRepeat2" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtCheckRepeat3" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtCheckRepeat4" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtCheckRepeat5" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtProgramName" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtUseMassProductGood" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtUseMassProductNG" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtScrapAmountGood" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtScrapAmountNG" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtCause" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtS10TestNoA1" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtS10TestNoA2" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtS10TestNoA3" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtS10TestNoA4" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtS10TestNoA5" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtS10NGA1" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtS10NGA2" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtS10NGA3" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtS10NGA4" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtS10NGA5" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtS10TestNoB1" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtS10TestNoB2" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtS10TestNoB3" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtS10TestNoB4" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtS10TestNoB5" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtS10NGB1" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtS10NGB2" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtS10NGB3" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtS10NGB4" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtS10NGB5" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtFinalYield" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtControlLCL" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtAsiGood" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtAsiNG" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtAddOn" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtAndonManage" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtAndonWho" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtAndonManageDetail" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtTestTotalAmount" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtTestResultGood" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtTestResultNG" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtRequestAQIS13" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtStopNextLotS13" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtKanbanCtrlNo" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtKanbanTestNo" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtKanbanExpireDate" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtResultBurnGood" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtResultBurnNG" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtResultChipCrackGood" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtResultChipCrackNG" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtResultChipMixGood" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtResultChipMixNG" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtRequestAQIS14" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtStopNextLotS14" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtStopPKGS14" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtRequestAQIS15" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtStopShipObjDevice" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtStopLabel" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtSystemInspection" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtJudgementResult" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtFTRetestGood" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtFTRetestNG" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtObjectScope" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtStopRecallShipment" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtLowYieldAnalysis" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtStopShipmentPKG" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtAssy" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtQCJudgement" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtOPName1_ID" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtTestIncharge_ID" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtOPName2_ID" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtGL_ID" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtAnalysisIncharge_ID" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtFYIFQIIncharge_ID" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtPDMgr_ID" Visible="false"></asp:TextBox>   
    <asp:TextBox runat="server" Text="" ID="txtQCIncharge_ID" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtOPName1_Sign" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtTestIncharge_Sign" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtOPName2_Sign" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtGL_Sign" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtAnalysisIncharge_Sign" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtFYIFQIIncharge_Sign" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtPDMgr_Sign" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtQCIncharge_Sign" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtOPName1_SignDate" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtTestIncharge_SignDate" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtOPName2_SignDate" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtGL_SignDate" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtAnalysisIncharge_SignDate" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtFYIFQIIncharge_SignDate" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtPDMgr_SignDate" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtQCIncharge_SignDate" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtShipmentDate" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtLowYieldMode" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtSelectS16" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtTEIncharge_ID" Visible="false"></asp:TextBox>
    <asp:TextBox runat="server" Text="" ID="txtTEIncharge_Sign" Visible="false"></asp:TextBox> 
    <asp:TextBox runat="server" Text="" ID="txtTEIncharge_SignDate" Visible="false"></asp:TextBox> 

    <!-- Modal HTML Edit-->
    <div id="EditModal" class="modal fade">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Edit Menu</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>

                <div class="modal-body SetCenter1 ">

                    <div class="row">
                        <div class="mx-auto">
                            <asp:ImageButton ID="BtnEditUser1" runat="server" Height="46px" Width="46px" ImageUrl='~/Images/NEW_100px.gif' OnClick="BtnEditUser1_Click" />
                        </div>

                        <div class="mx-auto">
                            <asp:ImageButton ID="BtnEditUser2" runat="server" Height="46px" Width="46px" ImageUrl='~/Images/user2.png' OnClick="BtnEditUser2_Click" />
                        </div>

                        <div class="mx-auto">
                            <asp:ImageButton ID="BtnEditUser3" runat="server" Height="46px" Width="46px" ImageUrl='~/Images/user3.png' OnClick="BtnEditUser3_Click" />
                        </div>
                    </div>

                    <br />
                    <br />
                    <div class="row">
                        <div class="mx-auto">
                            <asp:ImageButton ID="BtnEditUser4" runat="server" Height="46px" Width="46px" ImageUrl='~/Images/user4.png' OnClick="BtnEditUser4_Click" />
                        </div>

                        <div class="mx-auto">
                            <asp:ImageButton ID="BtnEditUser5" runat="server" Height="46px" Width="46px" ImageUrl='~/Images/FQI.png' OnClick="BtnEditUser5_Click" />
                        </div>

                        <div class="mx-auto">
                            <asp:ImageButton ID="BtnEditUser6" runat="server" Height="46px" Width="46px" ImageUrl='~/Images/FYI.png' OnClick="BtnEditUser6_Click" />
                        </div>
                    </div>

                    <br />
                    <br />

                    <div class="row">
                        <div class="mx-auto">
                            <asp:ImageButton ID="BtnEditUser8" runat="server" Height="46px" Width="46px" ImageUrl='~/Images/user8.png' OnClick="BtnEditUser8_Click" />
                        </div>

                        <div class="mx-auto">
                            <asp:ImageButton ID="BtnEditMLOP1" runat="server" Height="46px" Width="46px" ImageUrl='~/Images/MLOP1.png' OnClick="BtnEditMLOP1_Click" />
                        </div>

                        <div class="mx-auto">
                            <asp:ImageButton ID="BtnEditMLOP2" runat="server" Height="46px" Width="46px" ImageUrl='~/Images/MLOP2.png' OnClick="BtnEditMLOP2_Click" />
                        </div>
                    </div>


                    <br />
                    <br />
                    <div class="row">
                        <div class="mx-auto">
                            <asp:ImageButton ID="BtnEditMLGL1" runat="server" Height="46px" Width="46px" ImageUrl='~/Images/MLGL1.png' OnClick="BtnEditMLGL1_Click" />
                        </div>

                        <div class="mx-auto">
                            <asp:ImageButton ID="BtnEditMLGL2" runat="server" Height="46px" Width="46px" ImageUrl='~/Images/MLGL2.png' OnClick="BtnEditMLGL2_Click" />
                        </div>

                        <div class="mx-auto">
                            <asp:Image ID="Image20" runat="server" Height="46px" Width="46px" ImageUrl='~/Images/WhiteSpace.png' />
                        </div>
                    </div>



                </div>
            </div>
        </div>
    </div>



</asp:Content>
