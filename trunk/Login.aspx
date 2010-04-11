<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Global.master" CodeFile="Login.aspx.cs" Inherits="login" Title="Sign in" %>
<%@ Register Src="Controls/AnonymousMenu.ascx" TagName="anonymousMenu" TagPrefix="uc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainMenu" runat="server">
    <uc1:anonymousMenu ID="UcAnonymousMenu" runat="server" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="outer-login-box">
        <asp:Login ID="Login1" FailureText="Próba logowania nie powiodła się. Spróbuj ponownie<br />" 
                    OnAuthenticate="Login1_Authenticate"  runat="server">
            <LayoutTemplate>
                    <span class="small-green">Login albo email</span><br />
                    <asp:TextBox ID="UserName" CssClass="login-input-box"  runat="server" />
                    <br /><br />
                    <span class="small-green">Hasło</span><br />
                    <asp:TextBox ID="Password" TextMode="Password"  CssClass="login-input-box"  runat="server" />
                    <br />
                    <a class="very-small-green" href="PasswordRecovery.aspx">Zapomniałeś hasła?</a><br /> 
                    <div class="remember-data">
                    <asp:CheckBox ID="CkbRemember" runat="server" /> <span class="small-gray">Zapamiętaj moje dane</span>
                    </div>
                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False" />
                    <asp:Button ID="Login" CommandName="Login" Text="Zaloguj się" CssClass="login-text" runat="server" />
            </LayoutTemplate>
        </asp:Login>
    </div>

<%--<div style="text-align:center">
  <asp:changepassword runat="server" id="changepassword1" visible="false" />
  <br /><br />
  <asp:loginstatus runat="server" id="lsLogout" visible="false" />
</div>
--%>
</asp:Content>