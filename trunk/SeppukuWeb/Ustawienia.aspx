<%@ Page Title="" Language="C#" MasterPageFile="~/Global.master" AutoEventWireup="true" CodeFile="Ustawienia.aspx.cs" Inherits="Ustawienia" %>
<%@ Register Src="Controls/Navigation/LoggedInMenu.ascx" TagName="loggedInMenu" TagPrefix="uc1" %>
<%@ Register Src="Controls/Membership/ChangePassword.ascx" TagName="changePassword" TagPrefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainMenu" Runat="Server">
    <uc1:loggedInMenu ID="UcLoggedInMenu" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContent" Runat="Server">
<div class="outer-login-box2" style="width: 550px; text-align: center; margin-left: 150px;">
    <div style="width: 480px; padding-bottom: 20px;">
        <span style="text-align:center;"  class="big-green2">Twoje ustawienia konta</span>
    </div>
    <uc1:changePassword ID="UcChangePassword" runat="server" />
    <div style="clear: both;" />
</div>
</asp:Content>

