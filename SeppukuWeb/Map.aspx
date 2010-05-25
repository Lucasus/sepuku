<%@ Page Title="" Language="C#" MasterPageFile="~/Global.master" AutoEventWireup="true" CodeFile="Map.aspx.cs" Inherits="Mapa" %>
<%@ Register Src="Controls/Navigation/LoggedInMenu.ascx" TagName="loggedInMenu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Mapa świata</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainMenu" runat="server">
	<uc1:loggedInMenu ID="UcLoggedInMenu" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContent" Runat="Server">
    Mapa świata<br />
	<object data="data:application/x-silverlight-2," type="application/x-silverlight-2" width="700" height="700">
		<param name="source" value="silverlight/SeppukuMap.xap"/>
		<param name="background" value="white" />
		<param name="minRuntimeVersion" value="3.0.40624.0" />
		<param name="autoUpgrade" value="true" />
		<param name="initParams" value="playerId=1" />
			<a href="http://go.microsoft.com/fwlink/?LinkID=149156&v=3.0.40624.0" style="text-decoration:none">
 			<img src="http://go.microsoft.com/fwlink/?LinkId=108181" alt="Get Microsoft Silverlight" style="border-style:none"/>
			</a>
	    </object>
</asp:Content>


