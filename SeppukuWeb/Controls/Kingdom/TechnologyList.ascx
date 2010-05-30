<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TechnologyList.ascx.cs" Inherits="Controls_Kingdom_TechnologyList" %>
<%@ Register Src="Technology.ascx" TagName="technology" TagPrefix="uc1" %>

<asp:Panel ID="PnlTechnologyList" runat="server" >
    <asp:GridView ID="GvTechnologies" runat="server" AutoGenerateColumns="false" 
        DataSourceID="OdsTechnologies" DataKeyNames="TechnologyId" 
        EmptyDataText="Brak technologii" 
        onselectedindexchanged="GvTechnologies_SelectedIndexChanged" 
        onprerender="GvTechnologies_PreRender" 
        onrowcommand="GvTechnologies_RowCommand" >
        <Columns>
            <asp:TemplateField HeaderText="Nazwa technologii">
                <ItemTemplate>
                    <asp:LinkButton CommandName="Select" ID="BtnTechnology" Text='<%# Eval("TechnologyName") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Koszt">
                <ItemTemplate>
                    <asp:Label ID="LblCost" Text='<%# Eval("TechnologyCost") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <asp:Label ID="LblStatus" Text='<%# Eval("TechnologyStatus") %>' runat="server" />
                    <asp:LinkButton CommandName="Buy" CommandArgument='<%# Container.DataItemIndex %>' ID="BtnTechnologyBuy" Text="Kup" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="OdsTechnologies" DataObjectTypeName="Seppuku.Domain.Technology"
     TypeName="Seppuku.Services.TechnologyService" SelectMethod="GetAll" runat="server">
    </asp:ObjectDataSource>
</asp:Panel>
<br />
<asp:Panel ID="PnlTechnology" Visible="false" runat="server">
    <uc1:technology ID="UcTechnology" runat="server" />
</asp:Panel>


