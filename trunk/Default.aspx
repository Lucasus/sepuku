<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Global.master" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Src="Controls/AnonymousMenu.ascx" TagName="anonymousMenu" TagPrefix="uc1" %>
<%@ Register Src="Controls/LoggedInMenu.ascx" TagName="loggedInMenu" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Seppuku Online </title>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainMenu" runat="server">
 <asp:LoginView ID="LoginView1" runat="server">
    <AnonymousTemplate>
        <uc1:anonymousMenu ID="UcAnonymousMenu" runat="server" />
    </AnonymousTemplate>
    <LoggedInTemplate>
        <uc1:loggedInMenu ID="UcLoggedInMenu" runat="server" />
    </LoggedInTemplate>
 </asp:LoginView>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
 <asp:LoginView runat="server">
    <AnonymousTemplate>
        <a href="Login.aspx">Zaloguj siê</a>
        <br />
        <a href="Register.aspx">Zarejestruj siê</a>
    </AnonymousTemplate>
    <LoggedInTemplate>
        Twoje królestwo.
    </LoggedInTemplate>
 </asp:LoginView>
</asp:Content>