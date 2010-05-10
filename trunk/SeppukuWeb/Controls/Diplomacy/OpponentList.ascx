<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OpponentList.ascx.cs" Inherits="Controls_Diplomacy_OpponentList" %>

<%@ Register Src="Chat.ascx" TagName="chat" TagPrefix="uc1" %>

<asp:Panel ID="PnlOpponentList" runat="server" >
    <asp:GridView ID="GvOpponents" runat="server" AutoGenerateColumns="false" 
        DataSourceID="OdsDiplomacy" DataKeyNames="DiplomacyId" 
        EmptyDataText=" Brak przeciwników" 
        onselectedindexchanged="GvOpponents_SelectedIndexChanged">
        <Columns>
            <asp:TemplateField HeaderText="Nazwa użytkownika">
                <ItemTemplate>
                    <asp:Button CommandName="Select" ID="BtnDiplomacy" runat="server" Text='<%# Bind("SecondaryUserName") %>' />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Status dyplomatyczny">
                <ItemTemplate>
                    <asp:Label ID="LblDiplomacyStatus" runat="server" Text='<%# Bind("DiplomacyStatusName") %>' />
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
    <uc1:chat ID="UcOpponent" runat="server" />
</asp:Panel>

