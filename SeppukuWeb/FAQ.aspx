<%@ Page Title="" Language="C#" MasterPageFile="~/Global.master" AutoEventWireup="true" CodeFile="FAQ.aspx.cs" Inherits="FAQ" %>
<%@ Register Src="Controls/AnonymousMenu.ascx" TagName="anonymousMenu" TagPrefix="uc1" %>
<%@ Register Src="Controls/LoggedInMenu.ascx" TagName="loggedInMenu" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Seppuku FAQ</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainMenu" runat="server">
 <asp:LoginView ID="LoginView1" runat="server">
    <AnonymousTemplate>
        <uc1:anonymousMenu ID="UcAnonymousMenu" runat="server" />
    </AnonymousTemplate>
    <LoggedInTemplate>
        <uc1:loggedInMenu ID="UcLoggedInMenu" runat="server" />
    </LoggedInTemplate>
 </asp:LoginView>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="mainContent" Runat="Server">
    Pytania i odpowiedzi
</asp:Content>

