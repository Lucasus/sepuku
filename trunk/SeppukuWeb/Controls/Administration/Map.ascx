<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Map.ascx.cs" Inherits="Controls_Kingdom_Map" %>

<asp:DetailsView ID="DvMap" runat="server" DataKeyNames="MapId" DataSourceID="OdsMap"
 AutoGenerateRows="false">
    <Fields>
        <asp:TemplateField HeaderText="Nazwa świata">
            <ItemTemplate>
                <asp:Label ID="LblMapName" runat="server" Text='<%# Bind("MapName") %>' />
            </ItemTemplate>
            <InsertItemTemplate>
                <asp:TextBox ID="TxtMapName" runat="server" Text='<%# Bind("MapName") %>' />
            </InsertItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="TxtMapName" runat="server" Text='<%# Bind("MapName") %>' />
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ShowHeader="false">
            <EditItemTemplate>
                <asp:LinkButton ID="BtnZapisz" runat="server" Text="Zapisz" CommandName="Update" />
                <asp:LinkButton ID="BtnAnuluj" runat="server" Text="Anuluj" CommandName="Cancel" />                
            </EditItemTemplate>
            <InsertItemTemplate>
                <asp:LinkButton ID="BtnDodaj" runat="server" Text="Dodaj" CommandName="Insert" />                
                <asp:LinkButton ID="BtnAnuluj" runat="server" Text="Anuluj" CommandName="Cancel" />                
            </InsertItemTemplate>
            <ItemTemplate>
                <asp:LinkButton ID="BtnEdytuj" runat="server" Text="Edytuj" CommandName="Edit" />
                <asp:LinkButton ID="BtnUsun" runat="server" Text="Usuń" CommandName="Delete" />
                <asp:LinkButton ID="BtnNextEpoch" runat="server" Text="Następna tura" OnClick="BtnNextEpochOnClick" />
            </ItemTemplate>
        </asp:TemplateField>
    </Fields>
</asp:DetailsView>

<asp:ObjectDataSource ID="OdsMap" DataObjectTypeName="Seppuku.Domain.Map"
     TypeName="Seppuku.Services.MapService" SelectMethod="GetById" 
    InsertMethod="Add" DeleteMethod="Delete"
      UpdateMethod="Update"
    runat="server" onselecting="OdsMap_Selecting" ondeleted="OdsMap_Deleted" 
    ondeleting="OdsMap_Deleting" oninserted="OdsMap_Inserted" 
    onupdated="OdsMap_Updated">
</asp:ObjectDataSource>
