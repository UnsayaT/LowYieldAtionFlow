<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HistoryAdvancePage.aspx.cs" Inherits="LowYieldCheckSheet.HistoryAdvancePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .auto-style1 {
            text-align: center;
        }

        .CustomHeight {
            height: 40px;
        }

        .wide {
            width: 100%;
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
            width:40%;
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
            $('#EditModal').modal('show');
        }
    </script>

    <div class="jumbotron">
        <h1 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold;">LOW YIELD ACTION FLOW</h1>
        <h1 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold;">History Advance</h1>
    </div>

    <br />

    <div class="mr-auto">
        <button type="button" class="btn btn-outline-danger" style="width: 200px" runat="server" id="btnBack" onserverclick="btnBack_ServerClick">Back</button>
    </div>

    <br />

    <button class="btn btn-primary btn-block" type="button" data-toggle="collapse" data-target="#CL1" aria-expanded="false" aria-controls="collapseExample">
        <h5>Fuction Search</h5>
    </button>
    <div class="collapse show" id="CL1">
        <div class="card card-body">

            <div class="row">
                <div class="col-sm">
                    <label><b>Process :</b></label>

                    <br />

                    <select class="custom-select custom-select-lg CustomHeight wide" id="SearchSelect1" name="SearchSelect1" runat="server" style="border: 1px solid black;">
                        <option selected>Please Select</option>
                        <option>FL</option>
                        <option>FT</option>
                        <option>MAPPING</option>
                    </select>
                </div>


                <div class="col-sm">
                    <label><b>MCNo :</b></label>
                    <input type="text" runat="server" id="tbMCNo" class="form-control CustomHeight wide" name="tbMCNo" style="border: 1px solid black;" />
                </div>

                <div class="col-sm">
                    <label><b>LotNo :</b></label>
                    <input type="text" runat="server" id="tbLotNo" class="form-control CustomHeight wide" name="tbLotNo" style="border: 1px solid black;" />
                </div>

            </div>

            <br />

            <div class="row">
                <div class="col-sm">
                    <label><b>Package :</b></label>
                    <input type="text" runat="server" id="tbPackage" class="form-control CustomHeight wide" name="tbPackage" style="border: 1px solid black;" />
                </div>

                <div class="col-sm">
                    <label><b>Device :</b></label>
                    <input type="text" runat="server" id="tbDevice" class="form-control CustomHeight wide" name="tbDevice" style="border: 1px solid black;" />
                </div>

                <div class="col-sm">
                </div>

            </div>


            <br />

            <div class="row">
                <div class="col-sm">
                    <label><b>Start Date :</b></label>
                    <div class="input-group date" id="datetimepicker2" data-target-input="nearest">
                        <input type="text" runat="server" id="SearchDate1" class="form-control datetimepicker-input CustomHeight wide" data-target="#datetimepicker2" name="SearchDate" style="border: 1px solid black;" />
                        <div class="input-group-append" data-target="#datetimepicker2" data-toggle="datetimepicker">
                            <div class="input-group-text"><i class="fa fa-calendar"></i></div>
                        </div>
                    </div>
                </div>

                <div class="col-sm">
                    <label><b>End Date :</b></label>
                    <div class="input-group date" id="datetimepicker3" data-target-input="nearest">
                        <input type="text" runat="server" id="SearchDate2" class="form-control datetimepicker-input CustomHeight wide" data-target="#datetimepicker3" name="SearchDate" style="border: 1px solid black;" />
                        <div class="input-group-append" data-target="#datetimepicker3" data-toggle="datetimepicker">
                            <div class="input-group-text"><i class="fa fa-calendar"></i></div>
                        </div>
                    </div>
                </div>

                <div class="col-sm">
                </div>

            </div>



            <br />


            <div class="SetCenter1">
                <button class="btn btn-success wide" runat="server" id="btnSearch" onserverclick="btnSearch_ServerClick">Search</button>
            </div>




        </div>
    </div>



    <br />


    <div class="auto-style1">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:GridView CssClass="gridviewFit" ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" BorderStyle="Inset" BorderWidth="3px"
                    GridLines="Vertical" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Width="100%" AllowPaging="True" PageSize="20"
                    OnRowCommand="GridView1_RowCommand">

                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="">
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
                        <asp:BoundField DataField="ControlYield" HeaderText="LCL" SortExpression="ControlYield" />

                        <asp:TemplateField HeaderText="Yield">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# GetYield((string)Eval("RequestType"),Eval("InitialYield"),Eval("FinalYield"))%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="RequestType">
                            <ItemTemplate>
                                <asp:Label ID="lblColumnRequestType" runat="server" Font-Size="Small" Text='<%# GetRequestType((string)Eval("RequestType"),Eval("Mode"),Eval("CheckAlarmBin"))%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="RequestType" HeaderText="RequestType" SortExpression="RequestType" />
                        <asp:BoundField DataField="RequestDate" HeaderText="RequestDate" SortExpression="RequestDate" />

                        <asp:TemplateField HeaderText="สาเหตุ">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# getCause(Eval("CheckLowYieldKanban"),Eval("Cause"))%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="CheckSheet">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnCheckSheet" runat="server" Height="42px" Width="42px" ImageUrl="~/Images/ViewSheet.png"
                                    CommandName="ViewSheet" CommandArgument='<%# Eval("Process") + "," + Eval("HandlerNo") + "," + Eval("LotNo") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="MoveLot">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnMoveLot" runat="server" Height="42px" Width="42px" ImageUrl="~/Images/Confirm.png"
                                    CommandName="ViewMoveLot" CommandArgument='<%# Eval("Process") + "," + Eval("HandlerNo") + "," + Eval("LotNo") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Option">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImBtnEditCheckSheet" runat="server" Height="42px" Width="42px" ImageUrl="~/Images/Option.png"
                                    CommandName="Option" CommandArgument='<%#Eval("Process")+","+Eval("HandlerNo")+ "," + Eval("LotNo")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>


                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBxConnectionString %>" SelectCommand=""></asp:SqlDataSource>
     <div>
        <asp:TextBox runat="server" Text="" ID="txtStoreValue" Visible="false"></asp:TextBox>
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
</asp:Content>
