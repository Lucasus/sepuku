<%@ Page Title="" Language="C#" MasterPageFile="~/Global.master" AutoEventWireup="true" CodeFile="PasswordRecovery.aspx.cs" Inherits="PasswordRecovery" %>
<%@ Register Src="Controls/Navigation/AnonymousMenu.ascx" TagName="anonymousMenu" TagPrefix="uc1" %>
<%@ Register Src="Controls/Membership/RecoverySendMail.ascx" TagName="recoverySendMail" TagPrefix="uc1" %>
<%@ Register Src="Controls/Membership/RecoveryChangePassword.ascx" TagName="recoveryChangePassword" TagPrefix="uc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainMenu" runat="server">
    <uc1:anonymousMenu ID="UcAnonymousMenu" runat="server" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <uc1:recoverySendMail ID="UcSendMail" runat="server" />
    <uc1:recoveryChangePassword ID="UcChangePassword" runat="server" />
</asp:Content>