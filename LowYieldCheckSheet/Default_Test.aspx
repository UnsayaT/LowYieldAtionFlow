<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="Default_Test.aspx.cs" Inherits="LowYieldCheckSheet.Default_Test" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .set1 {
            padding-top: 2em;
            width:90%;
            margin:auto;
            max-width:1636px; /*PS.Fit For Image Width Size*/
        }
        
    </style>

    <div class="set1 ">
        <div>
            <%--<img src="Images/header2.jpg" class="img-fluid" alt="Responsive image">--%>
        </div>

        <div>
            <a href="PageMonitoring_Test.aspx" class="btn btn btn-primary btn-lg btn-block" role="button">Monitoring</a>
        </div>

    </div>
</asp:Content>
