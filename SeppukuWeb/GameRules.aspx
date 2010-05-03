<%@ Page Title="" Language="C#" MasterPageFile="~/Global.master" AutoEventWireup="true" CodeFile="GameRules.aspx.cs" Inherits="ZasadyGry" %>
<%@ Register Src="Controls/Navigation/LoggedInMenu.ascx" TagName="loggedInMenu" TagPrefix="uc1" %>
<%@ Register Src="Controls/Navigation/AnonymousMenu.ascx" TagName="anonymousMenu" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Zasady gry</title>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainMenu" runat="server">
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
    Strona z zasadami gry
</asp:Content>


