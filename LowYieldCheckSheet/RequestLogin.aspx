<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RequestLogin.aspx.cs" Inherits="LowYieldCheckSheet.RequestLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .set1 {
            padding-top: 2em;
            width:90%;
            margin:auto;
            max-width:1636px; /*PS.Fit For Image Width Size*/
        }
        
        .auto-style1 {
            text-align: center;
        }
        
    </style>
   <%-- <script type="text/javascript">
        function openLoginModal() {
            $('#LoginModal').modal('show');
        }
    </script>--%>



    <!-- Modal HTML   LOGIN   -->
    <%--<div id="LoginModal" class="modal fade">
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
    </div>--%>
    
     <div class="auto-style1">
        <div class="col-sm">
            <%--<img src="Images/header2.jpg" class="img-fluid" alt="Responsive image">--%>
            <br />
            <br />
             <h3 class="text-center login-title" style="font-family: 'Waffle Regular'; font-weight: bold;">LOGIN</h3>
            <br />
            <input type="text" runat="server" id="tbUserID"  placeholder="User ID" autocomplete="off">
            <br />
            <br />
            <button type="button" runat="server" class="btn btn-outline-primary" name="BtnSubmitLogin" id="Button1" onserverclick="BtnSubmitLogin_ServerClick">Login</button>
        </div>

        
    </div>

</asp:Content>
