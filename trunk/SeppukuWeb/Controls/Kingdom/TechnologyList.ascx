﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TechnologyList.ascx.cs" Inherits="Controls_Kingdom_TechnologyList" %>
<%@ Register Src="Technology.ascx" TagName="technology" TagPrefix="uc1" %>

<asp:Panel ID="PnlTechnologyList" runat="server" >
    <asp:GridView ID="GvTechnologies" runat="server" AutoGenerateColumns="false" 
        DataSourceID="OdsTechnologies" DataKeyNames="TechnologyId" 
        EmptyDataText="Brak technologii" 
        onselectedindexchanged="GvTechnologies_SelectedIndexChanged" >
        <Columns>
            <asp:TemplateField HeaderText="Nazwa technologii">
                <ItemTemplate>
                    <asp:LinkButton CommandName="Select" ID="BtnTechnology" Text='<%# Eval("TechnologyName") %>' runat="server" />
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

