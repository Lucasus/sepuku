<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RecoveryChangePassword.ascx.cs" Inherits="Controls_Membership_RecoveryChangePassword" %>
<div class="outer-login-box2">
    <table id="TableBefore" class="register-table" runat="server" >
        <tr>
            <td style="text-align:center;"  colspan="2">
                <span style="text-align:center;"  class="big-green2">Tworzenie nowego hasła</span>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div style="float: left;" class="regulamin-text">
                    <span>
                        Utwórz nowe hasło dla swojego konta:
                    </span>
                </div>
            </td>
        </tr>
        <tr>
            <td><span class="medium-green3">Podaj hasło</span></td>
            <td><asp:TextBox ID="Password" TextMode="Password" CssClass="login-input-box"  runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="default" 
                 ErrorMessage="*" ControlToValidate="Password" Disply="Dynamic" runat="server" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="Dynamic" ControlToValidate="Password" ValidationGroup="default"
                 runat="server" ValidationExpression="^[\s\S]{0,255}$" Text="<br />Dozwolone nie więcej niż 255 znaków" />                                
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" Display="Dynamic" ControlToValidate="Password" ValidationGroup="default"
                 runat="server" ValidationExpression="^[\s\S]{6,}$" Text="<br />Hasło musi zawierać co najmniej 6 znaków" />                                
            </td>
        </tr>
        <tr>
            <td><span class="medium-green3">Powtórz hasło</span></td>
            <td><asp:TextBox ID="ConfirmPassword" TextMode="Password" CssClass="login-input-box"  runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="default" 
                 ErrorMessage="*" ControlToValidate="ConfirmPassword" Disply="Dynamic" runat="server" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" Display="Dynamic" ControlToValidate="ConfirmPassword" ValidationGroup="default"
                 runat="server" ValidationExpression="^[\s\S]{0,255}$" Text="<br />Dozwolone nie więcej niż 255 znaków" />                                
            <asp:CompareValidator ID="CmpConfirmPassword" ValidationGroup="default" ControlToCompare="Password" 
                 ErrorMessage="<br />Hasła nie są zgodne" ControlToValidate="ConfirmPassword" Disply="Dynamic" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2"><asp:Literal ID="Message" runat="server" EnableViewState="False" /></td>
        </tr>
        <tr>
            <td colspan="2">
                <div style="text-align: center;width: 100%; border-bottom: 1px solid #C8D1B3; padding-bottom: 10px;" >
                     <asp:LinkButton ID="ContinueButton" ValidationGroup="default"  Text="Zmień" 
                         CssClass="medium-button" runat="server" onclick="ContinueButton_Click" />
                </div>
            </td>
        </tr>
    </table>
    <table id="TableAfter" class="register-table" visible="false" style="padding-left: 150px;" runat="server" >
        <tr>
            <td colspan="2">
                <div style="text-align: center;width: 100%; padding-bottom: 10px;" >
                    Twoje hasło zostało zmienione.
                </div>
            </td>
        </tr>
    </table>
</div>