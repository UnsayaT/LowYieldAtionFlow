<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PageMonitoring_OP.aspx.cs" Inherits="LowYieldCheckSheet.PageMonitoring_OP" %>
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
        <h1 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold;">LOW YIELD ACTION FLOW</h1>
        <h1 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold;">MONITORING FOR OPERATOR</h1>
    </div>

    <div class="row">
        <div class="mx-auto">
            <button type="button" class="btn btn-outline-primary" style="width: 200px" runat="server" onserverclick="GoHistoryAdvance">History Advance</button>
        </div>

        <div class="mx-auto">
            <button type="button" class="btn btn-outline-primary" style="width: 200px" runat="server" onserverclick="GoHistoryDaily">History Daily</button>
        </div>
    </div>

    <br />

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
                    <asp:Image ID="Image5" runat="server" Height="46px" Width="46px" ImageUrl='~/Images/user5.png' />
                    <b><i class="fas fa-caret-right"></i>Analysis Incharge</b>
                </div>

                <div class="row col">
                    <asp:Image ID="Image6" runat="server" Height="46px" Width="46px" ImageUrl='~/Images/user5A.png' />
                    <b><i class="fas fa-caret-right"></i>QYI1 has not receive lot</b>
                </div>
            </div>

            <br />

            <div class="row">
                <div class="row col">
                    <asp:Image ID="Image13" runat="server" Height="46px" Width="46px" ImageUrl='~/Images/user5B.png' />
                    <b><i class="fas fa-caret-right"></i>QYI1 has receive lot</b>
                </div>

                <div class="row col">
                    <asp:Image ID="Image15" runat="server" Height="46px" Width="46px" ImageUrl='~/Images/user7.png' />
                    <b><i class="fas fa-caret-right"></i>FYI/FQI Incharge</b>
                </div>

                <div class="row col">
                    <asp:Image ID="Image7" runat="server" Height="46px" Width="46px" ImageUrl='~/Images/user8.png' />
                    <b><i class="fas fa-caret-right"></i>QC Incharge</b>
                </div>
            </div>

            <br />

            <div class="row">
                <div class="row col">
                    <asp:Image ID="Image8" runat="server" Height="46px" Width="46px" ImageUrl='~/Images/user9.png' />
                    <b><i class="fas fa-caret-right"></i>(PD Mgr.)Production Manager Incharge</b>
                </div>

                <div class="row col">
                    <asp:Image ID="Image9" runat="server" Height="46px" Width="46px" ImageUrl='~/Images/MLOP1.png' />
                    <b><i class="fas fa-caret-right"></i>Operator Move Lot</b>
                </div>

                <div class="row col">
                    <asp:Image ID="Image10" runat="server" Height="46px" Width="46px" ImageUrl='~/Images/MLOP2.png' />
                    <b><i class="fas fa-caret-right"></i>Operator Move Lot</b>
                </div>
            </div>

            <br />
            <div class="row">
                <div class="row col">
                    <asp:Image ID="Image11" runat="server" Height="46px" Width="46px" ImageUrl='~/Images/MLGL1.png' />
                    <b><i class="fas fa-caret-right"></i>Group Leader Move Lot</b>
                </div>

                <div class="row col">
                    <asp:Image ID="Image12" runat="server" Height="46px" Width="46px" ImageUrl='~/Images/MLGL2.png' />
                    <b><i class="fas fa-caret-right"></i>Group Leader Move Lot</b>
                </div>

                <div class="row col">
                </div>
            </div>

        </div>
    </div>


    <div>
        <%-- Timer Interval mSec --%>
        <asp:Timer ID="Timer1" runat="server" Interval="180000" OnTick="Timer1_Tick"></asp:Timer>
    </div>


    <div class="auto-style1">
        <asp:UpdatePanel runat="server" ID="UpdatePanel1">
            <ContentTemplate>
                <asp:GridView CssClass="gridviewFit" ID="GridViewPageMonitoring" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Inset" BorderWidth="3px" CellPadding="3"
                    ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" AllowPaging="True" DataSourceID="SqlDataSource1" OnRowCommand="GridView1_RowCommand" Width="100%" EnableViewState="False">
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

                        <asp:TemplateField HeaderText="Req-Type">
                            <ItemTemplate>
                                <asp:Label ID="lblColumnRequestType" runat="server" Font-Size="Small" Text='<%# GetRequestType((string)Eval("RequestType"),Eval("Mode"),Eval("CheckAlarmBin"))%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>


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
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBxConnectionString %>" SelectCommand="SELECT [Process], [HandlerNo], [LotNo], [PackageName], [DeviceName], [RequestDate], [Status], [RequestType], [Flow], [InitialYield], [ControlYield], [FinalYield], [ControlLCL],[CheckAlarmBin],[Mode] FROM [LowYieldActionReport] WHERE (Status='1' or Status='3' or Status='ML1' or Status='ML3') ORDER BY [RequestDate] DESC"></asp:SqlDataSource>

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
                            <asp:ImageButton ID="BtnEditUser5" runat="server" Height="46px" Width="46px" ImageUrl='~/Images/user5.png' OnClick="BtnEditUser5_Click" />
                        </div>

                        <div class="mx-auto">
                            <asp:ImageButton ID="BtnEditUser6" runat="server" Height="46px" Width="46px" ImageUrl='~/Images/user7.png' OnClick="BtnEditUser6_Click" />
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
