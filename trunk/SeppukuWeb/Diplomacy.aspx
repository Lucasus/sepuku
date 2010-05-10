<%@ Page Title="" Language="C#" MasterPageFile="~/PageLayouts/TwoColumnLayout.master" AutoEventWireup="true" CodeFile="Diplomacy.aspx.cs" Inherits="Dyplomacja" %>
<%@ Register Src="Controls/Navigation/LoggedInMenu.ascx" TagName="loggedInMenu" TagPrefix="uc1" %>
<%@ Register Src="Controls/Diplomacy/OpponentList.ascx" TagName="opponentList" TagPrefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Diplomacy</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menu" runat="server">
	<uc1:loggedInMenu ID="UcLoggedInMenu" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContextColumn1" Runat="Server">
    Dyplomacja:
    <br />
    <uc1:opponentList ID="UcOpponentListList" runat="server" />
</asp:Content>


