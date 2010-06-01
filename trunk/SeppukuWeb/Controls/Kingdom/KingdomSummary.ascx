<%@ Control Language="C#" AutoEventWireup="true" CodeFile="KingdomSummary.ascx.cs" Inherits="Controls_Kingdom_KingdomSummary" %>
<table>
    <tr>
        <td style="width: 250px;">Ilość dostępnych surowców: </td>
        <td style="width: 250px;">Wielkość królestwa: </td>
        <td style="width: 250px;">Wielkość armii: </td>
    </tr>
    <tr>
        <td><asp:Label ID="LblKingdomResources" Text="0" runat="server" /> jednostek ryżu</td>
        <td><asp:Label ID="LblKingdomSize" Text="0" runat="server" /> pól</td>
        <td><asp:Label ID="LblKingdomArmy" runat="server" Text="0" /> wojowników</td>
    </tr>
</table>
