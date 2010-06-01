<%@ Page Title="" Language="C#" MasterPageFile="~/Global.master" AutoEventWireup="true" CodeFile="Kingdom.aspx.cs" Inherits="Kingdom_Page" %>
<%@ Register Src="Controls/Navigation/LoggedInMenu.ascx" TagName="loggedInMenu" TagPrefix="uc1" %>
<%@ Register Src="Controls/Kingdom/TechnologyList.ascx" TagName="technologyList" TagPrefix="uc1" %>
<%@ Register Src="Controls/Kingdom/LogList.ascx" TagName="logList" TagPrefix="uc1" %>
<%@ Register Src="Controls/Kingdom/KingdomSummary.ascx" TagName="kingdomSummary" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Kingdom</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainMenu" runat="server">
	<uc1:loggedInMenu ID="UcLoggedInMenu" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="mainContent" Runat="Server">
    <uc1:kingdomSummary ID="UcKingdomSummary" runat="server" />
    <br />
	<div class="left">
        Odkryte technologie:
        <br />
        <uc1:technologyList ID="UcTechnologyList" OnTechnologyListChanged="UcTechnologyList_Changed" runat="server" />
	</div>	
	<div class="left">
	    Jednostki do kupienia:
	    <br />
	</div>
	<div class="clear"></div>
    Poprzednie tury:
    <br />
    <uc1:logList ID="UcLogList" runat="server" />
</asp:Content>

