<%@ Page Title="" Language="C#" MasterPageFile="~/Global.master" AutoEventWireup="true" CodeFile="Mapa.aspx.cs" Inherits="Mapa" %>
<%@ Register Src="Controls/LoggedInMenu.ascx" TagName="loggedInMenu" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Mapa świata</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainMenu" Runat="Server">
    <uc1:loggedInMenu ID="UcLoggedInMenu" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContent" Runat="Server">
    Mapa świata
</asp:Content>


