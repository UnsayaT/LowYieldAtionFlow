<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PortalPdfPage.aspx.cs" Inherits="LowYieldCheckSheet.HistoryPdfPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="jumbotron">
        <h1 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold;">LOW YIELD PDF SHEET</h1>
    </div>

    <br />

    <div class="mr-auto">
        <button type="button" class="btn btn-outline-danger" style="width: 200px" runat="server" id="btnBack" onserverclick="btnBack_ServerClick">Back</button>
    </div>

    <br />

    <div class ="row" style ="margin-top :10px">
      <%--  <div class ="col-md-12 " style ="width :100%;height:1000px; left: 0px; top: 5px;">--%>
        <div class ="col-md-12 " style ="width :100%;height:1200px; left: 0px; top: 5px;">
            <iframe id="OpenReport" runat ="server" style ="width :100%;height :60%"></iframe>
        </div>
    </div>


</asp:Content>
