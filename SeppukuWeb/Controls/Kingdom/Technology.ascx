<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Technology.ascx.cs" Inherits="Controls_Kingdom_Technology" %>

<asp:DetailsView ID="DvTechnology" runat="server" DataKeyNames="TechnologyId" DataSourceID="OdsTechnology"
 AutoGenerateRows="false">
    <Fields>
        <asp:TemplateField HeaderText="Nazwa technologii">
            <ItemTemplate>
                <asp:Label ID="LblTechnologyName" runat="server" Text='<%# Bind("TechnologyName") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Opis technologii">
            <ItemTemplate>
                <asp:Label ID="LblTechnologyDescription" runat="server" Text='<%# Bind("TechnologyDescription") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Opis efektów">
            <ItemTemplate>
                <asp:Label ID="LblTechnologyEffect" runat="server" Text='<%# Bind("TechnologyEffect") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Koszt">
            <ItemTemplate>
                <asp:Label ID="LblTechnologyCost" runat="server" Text='<%# Bind("TechnologyCost") %>' />
            </ItemTemplate>
        </asp:TemplateField>
    </Fields>
</asp:DetailsView>

<asp:ObjectDataSource ID="OdsTechnology" DataObjectTypeName="Seppuku.Domain.Technology"
     TypeName="Seppuku.Services.TechnologyService" SelectMethod="GetById" 
    runat="server" onselecting="OdsTechnology_Selecting">
</asp:ObjectDataSource>
