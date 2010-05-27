<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserList.ascx.cs" Inherits="Controls_Kingdom_UserList" %>

<asp:Panel ID="PnlUserList" runat="server" >
    <asp:GridView ID="GvUsers" runat="server" AutoGenerateColumns="false" 
        DataSourceID="OdsUsers" DataKeyNames="UserId" 
        EmptyDataText="Brak użytkowników" >
        <Columns>
            <asp:TemplateField HeaderText="Nazwa użytkownika">
                <ItemTemplate>
                    <asp:Label ID="LblUserName" Text='<%# Eval("UserName") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Adres email">
                <ItemTemplate>
                    <asp:Label ID="LblUserName" Text='<%# Eval("Email") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Data rejestracji">
                <ItemTemplate>
                    <asp:Label ID="LblUserName" Text='<%# Eval("CreateDateString") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Czy aktywowany">
                <ItemTemplate>
                    <asp:Label ID="LblUserName" Text='<%# Eval("IsApprovedString") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="OdsUsers" DataObjectTypeName="Seppuku.Domain.User"
     TypeName="Seppuku.Services.UserService" SelectMethod="GetAll" runat="server">
    </asp:ObjectDataSource>
</asp:Panel>


