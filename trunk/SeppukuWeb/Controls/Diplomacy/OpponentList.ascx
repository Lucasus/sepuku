<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OpponentList.ascx.cs" Inherits="Controls_Diplomacy_OpponentList" %>

<%@ Register Src="Opponent.ascx" TagName="opponent" TagPrefix="uc1" %>

<asp:Panel ID="PnlOpponentList" runat="server" >
    <asp:GridView ID="GvOpponents" runat="server" AutoGenerateColumns="false" 
        DataSourceID="OdsDiplomacy" DataKeyNames="DiplomacyId" 
        EmptyDataText=" Brak przeciwników" 
        onselectedindexchanged="GvOpponents_SelectedIndexChanged">
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


            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:Button CommandName="Select" ID="BtnTechnology" Text="Wyślij wiadomość" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:ObjectDataSource ID="OdsDiplomacy" DataObjectTypeName="Seppuku.Domain.Diplomacy"
     TypeName="Seppuku.Services.DiplomacyService" SelectMethod="GetUserDiplomacy" runat="server">
    </asp:ObjectDataSource>

</asp:Panel>
<br />


<asp:Panel ID="PnlOpponent" Visible="false" runat="server">
    <uc1:opponent ID="UcOpponent" runat="server" />
</asp:Panel>

