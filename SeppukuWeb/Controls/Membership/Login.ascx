<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Login.ascx.cs" Inherits="Controls_Membership_Login" %>
<div class="outer-login-box">
    <asp:Login ID="Login1" FailureText="Próba logowania nie powiodła się. Spróbuj ponownie<br />" 
                OnAuthenticate="Login1_Authenticate"  runat="server">
        <LayoutTemplate>
                <span class="small-green">Login albo email</span><br />
                <asp:TextBox ID="UserName" CssClass="login-input-box"  runat="server" />
                <br />
                <span class="small-green">Hasło</span><br />
                <asp:TextBox ID="Password" TextMode="Password"  CssClass="login-input-box"  runat="server" />
                <br />
                <a class="very-small-green" href="PasswordRecovery.aspx">Zapomniałeś hasła?</a><br /> 
                <div class="remember-data">
                <asp:CheckBox ID="RememberMe" runat="server" /> <span class="small-gray">Zapamiętaj moje dane</span>
                </div>
                <asp:Literal ID="FailureText" runat="server" EnableViewState="False" />
                <asp:LinkButton ID="ContinueButton" ValidationGroup="default" CommandName="Login" Text="Zaloguj się" CssClass="medium-button" runat="server" />

        </LayoutTemplate>
    </asp:Login>
</div>
