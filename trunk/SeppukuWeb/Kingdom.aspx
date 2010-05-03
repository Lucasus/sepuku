<%@ Page Title="" Language="C#" MasterPageFile="~/PageLayouts/TwoColumnLayout.master" AutoEventWireup="true" CodeFile="Kingdom.aspx.cs" Inherits="Kingdom" %>
<%@ Register Src="Controls/Navigation/LoggedInMenu.ascx" TagName="loggedInMenu" TagPrefix="uc1" %>
<%@ Register Src="Controls/Kingdom/TechnologyList.ascx" TagName="technologyList" TagPrefix="uc1" %>
<%@ Register Src="Controls/Kingdom/LogList.ascx" TagName="logList" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Kingdom</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContextColumn1" Runat="Server">
    Odkryte technologie:
    <br />
    <uc1:technologyList ID="UcTechnologyList" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContextColumn2" Runat="Server">
    Poprzednie tury:
    <br />
    <uc1:logList ID="UcLogList" runat="server" />
</asp:Content>

