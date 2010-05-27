<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="~/Global.master" CodeFile="AdministrationUsers.aspx.cs" Inherits="Users_Page" %>
<%@ Register Src="~/Controls/Navigation/AdministrationMenu.ascx" TagName="administrationMenu" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/Administration/UserList.ascx" TagName="userList" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Zarządzanie użytkownikami</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainMenu" runat="server">
	<uc1:administrationMenu ID="UcLoggedInMenu" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContent" Runat="Server">
    Lista użytkowników:
    <br />
    <uc1:userList ID="UcUserList" runat="server" />
</asp:Content>

