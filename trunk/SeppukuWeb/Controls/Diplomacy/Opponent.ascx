<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Opponent.ascx.cs" Inherits="Controls_Diplomacy_Opponent" %>

<asp:GridView ID="DvOpponent" runat="server" DataKeyNames="DiplomacyId" DataSourceID="OdsDiplomacy"
 AutoGenerateColumns="false">
    <Columns>
        <asp:TemplateField HeaderText="Nazwa użytkownika">
            <ItemTemplate>
                <asp:Label ID="LblUserName" runat="server" Text='<%# Bind("SecondaryUserId") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status dyplomatyczny">
            <ItemTemplate>
                <asp:Label ID="LblDiplomacyStatus" runat="server" Text='<%# Bind("DiplomacyStatusId") %>' />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

<asp:ObjectDataSource ID="OdsDiplomacy" DataObjectTypeName="Seppuku.Domain.Diplomacy"
     TypeName="Seppuku.Services.DiplomacyService" SelectMethod="GetById" 
    runat="server" onselecting="OdsDiplomacy_Selecting">
</asp:ObjectDataSource>
