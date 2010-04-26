<%@ Page Title="" Language="C#" MasterPageFile="~/Global.master" AutoEventWireup="true" CodeFile="Ustawienia.aspx.cs" Inherits="Ustawienia" %>
<%@ Register Src="Controls/LoggedInMenu.ascx" TagName="loggedInMenu" TagPrefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainMenu" Runat="Server">
    <uc1:loggedInMenu ID="UcLoggedInMenu" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContent" Runat="Server">
    Strona z ustawieniami użytkownika
</asp:Content>

