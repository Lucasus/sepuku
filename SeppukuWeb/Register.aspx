<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Global.master" CodeFile="Register.aspx.cs" Inherits="Register" Title="Zakładanie konta" %>
<%@ Register Src="Controls/Navigation/AnonymousMenu.ascx" TagName="anonymousMenu" TagPrefix="uc1" %>
<%@ Register Src="Controls/Membership/Register.ascx" TagName="register" TagPrefix="uc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainMenu" runat="server">
    <uc1:anonymousMenu ID="UcAnonymousMenu" runat="server" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <uc1:register ID="UcRegister" runat="server" />
</asp:Content>