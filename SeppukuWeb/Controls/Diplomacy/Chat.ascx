<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Chat.ascx.cs" Inherits="Controls_Diplomacy_Opponent" %>

<asp:ListView ID="DvOpponent" runat="server" DataSourceID="OdsMessage" 
    EnableModelValidation="True">

   
    <EmptyDataTemplate>
        <span>Nie prowadzono czatu z tym użytkownikiem</span>
    </EmptyDataTemplate>
    
    <ItemTemplate>
        <span style=""> 
        [
        <asp:Label ID="SendDateLabel" runat="server" Text='<%# Eval("SendDate") %>' />
        ]
        <b>
        <asp:Label ID="MainUserNameLabel" runat="server" 
            Text='<%# Eval("MainUserName") %>' />
        </b>
        :
        <asp:Label ID="TextLabel" runat="server" Text='<%# Eval("Text") %>' />
        <br />
        </span>
    </ItemTemplate>
        

    <LayoutTemplate>
        <div ID="itemPlaceholderContainer" runat="server" style="">
            <span runat="server" id="itemPlaceholder" />
        </div>
        <div style="">
            <asp:DataPager ID="DataPager1" runat="server">
                <Fields>
                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" 
                        ShowLastPageButton="True" />
                </Fields>
            </asp:DataPager>
        </div>
    </LayoutTemplate>
   
</asp:ListView>

<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
<asp:Button ID="Send" runat="server" Text="Wyślij wiadomość" OnClick="Click_SendMessage" />

<asp:ObjectDataSource ID="OdsMessage"
    TypeName="Seppuku.Services.MessageService" SelectMethod="GetUserChatWith" 
    runat="server" onselecting="OdsDiplomacy_Selecting">
</asp:ObjectDataSource>
