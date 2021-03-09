<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HistoryDailyPage.aspx.cs" Inherits="LowYieldCheckSheet.HistoryDailyPage" %>

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


    <div class="jumbotron">
        <h1 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold;">LOW YIELD ACTION FLOW</h1>
        <h1 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold;">History Daily</h1>
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
        <div class="card card-body align-content-center">

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
                    <label><b>MC No :</b></label>
                    <input type="text" runat="server" id="tbMCNo" class="form-control CustomHeight wide" name="tbMCNo" style="border: 1px solid black;" />
                </div>


                <div class="col-sm">
                    <label><b>Date :</b></label>
                    <div class="input-group date" id="datetimepicker2" data-target-input="nearest">
                        <input type="text" runat="server" id="SearchDate" class="form-control datetimepicker-input CustomHeight wide" data-target="#datetimepicker2" name="SearchDate" style="border: 1px solid black;" />
                        <div class="input-group-append" data-target="#datetimepicker2" data-toggle="datetimepicker">
                            <div class="input-group-text"><i class="fa fa-calendar"></i></div>
                        </div>
                    </div>
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

                        <asp:TemplateField HeaderText ="RequestType">
                            <ItemTemplate>
                                <asp:Label ID="lblColumnRequestType" runat="server" Font-Size="Small" Text='<%# GetRequestType((string)Eval("RequestType"),Eval("Mode"),Eval("CheckAlarmBin"))%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

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

    <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBxConnectionString %>" SelectCommand="SELECT [Process], [HandlerNo], [LotNo], [PackageName], [DeviceName], [RequestDate], [RequestType], [Flow], [InitialYield], [ControlYield], [FinalYield], [ControlLCL], [CheckLowYieldKanban], [Cause] FROM [LowYieldActionHistory]"></asp:SqlDataSource>--%>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBxConnectionString %>" SelectCommand=""></asp:SqlDataSource>

</asp:Content>
