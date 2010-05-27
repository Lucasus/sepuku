<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="~/Global.master" CodeFile="AdministrationMaps.aspx.cs" Inherits="Maps_Page" %>
<%@ Register Src="~/Controls/Navigation/AdministrationMenu.ascx" TagName="administrationMenu" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/Administration/MapList.ascx" TagName="mapList" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Zarządzanie mapami</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainMenu" runat="server">
	<uc1:administrationMenu ID="UcLoggedInMenu" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContent" Runat="Server">
    Lista światów:
    <br />
    <uc1:mapList ID="UcMapList" runat="server" />
</asp:Content>

