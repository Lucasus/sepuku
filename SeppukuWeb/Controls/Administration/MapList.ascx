<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MapList.ascx.cs" Inherits="Controls_Kingdom_MapList" %>
<%@ Register Src="Map.ascx" TagName="Map" TagPrefix="uc1" %>

<asp:Panel ID="PnlMapList" runat="server" >
    <asp:GridView ID="GvMaps" runat="server" AutoGenerateColumns="false" 
        DataSourceID="OdsMaps" DataKeyNames="MapId" 
        onselectedindexchanged="GvMaps_SelectedIndexChanged"
        EmptyDataText="Brak światów">
        <Columns>
            <asp:TemplateField HeaderText="Nazwa świata">
                <ItemTemplate>
                    <asp:LinkButton CommandName="Select" ID="BtnMap" Text='<%# Eval("MapName") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="OdsMaps" DataObjectTypeName="Seppuku.Domain.Map"
        TypeName="Seppuku.Services.MapService" SelectMethod="GetAll" runat="server">
    </asp:ObjectDataSource>
</asp:Panel>
<br />
<asp:LinkButton ID="BtnDodaj" Text="Dodaj nową mapę" runat="server" 
    onclick="BtnDodaj_Click" />
<br />
<asp:Panel ID="PnlMap" Visible="false" runat="server">
    <uc1:Map ID="UcMap" OnMapChanged="UcMap_Changed" runat="server" />
</asp:Panel>


