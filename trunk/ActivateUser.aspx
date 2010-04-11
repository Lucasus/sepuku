<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Global.master" CodeFile="ActivateUser.aspx.cs" Inherits="ActivateUser" %>
<%@ Register Src="Controls/AnonymousMenu.ascx" TagName="anonymousMenu" TagPrefix="uc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainMenu" runat="server">
    <uc1:anonymousMenu ID="UcAnonymousMenu" runat="server" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Label ID="LblResult" runat="server" />
</asp:Content>