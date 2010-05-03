<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.ascx.cs" Inherits="Controls_Membership_ChangePassword" %>

    <table id="TableBefore" class="default-table" runat="server" >
        <tr>
            <td colspan="2">
                <div style="float: left; text-align: left; padding-bottom: 10px;" class="regulamin-text">
                    <span class="header2">
                        Zmiana hasła (pozostawienie pustych pól zachowa stare hasło):
                    </span>
                </div>
            </td>
        </tr>
        <tr>
            <td><div class="medium-green3" style="text-align: left; padding-left: 10px;">Podaj stare hasło</div></td>
            <td><asp:TextBox ID="Password" TextMode="Password" CssClass="default-textbox"  runat="server" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="Dynamic" ControlToValidate="Password" ValidationGroup="default"
                     runat="server" ValidationExpression="^[\s\S]{0,255}$" Text="<br />Dozwolone nie więcej niż 255 znaków" />                                
                <asp:CustomValidator id="CvRegulamin" runat="server" ValidationGroup="default" 
                    ErrorMessage="Podane hasło jest niepoprawne" ControlToValidate="Password" 
                    OnServerValidate="CvPassword_ServerValidate" Visible="false" />
            </td>
        </tr>
        <tr>
            <td><div style="padding-bottom: 10px;"></div></td>
        </tr>
        <tr>
            <td><div class="medium-green3" style="text-align: left; padding-left: 10px;">Podaj nowe hasło</div></td>
            <td><asp:TextBox ID="NewPassword" TextMode="Password" CssClass="default-textbox"  runat="server" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" ControlToValidate="NewPassword" ValidationGroup="default"
                     runat="server" ValidationExpression="^[\s\S]{0,255}$" Text="<br />Dozwolone nie więcej niż 255 znaków" />                                
            </td>
        </tr>
        <tr>
            <td><div class="medium-green3" style="text-align: left; padding-left: 10px;">Powtórz nowe hasło</div></td>
            <td><asp:TextBox ID="NewPasswordConfirm" TextMode="Password" CssClass="default-textbox"  runat="server" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" Display="Dynamic" ControlToValidate="NewPasswordConfirm" ValidationGroup="default"
                     runat="server" ValidationExpression="^[\s\S]{0,255}$" Text="<br />Dozwolone nie więcej niż 255 znaków" />                                
                <asp:CompareValidator ID="CmpConfirmPassword" ValidationGroup="default" ControlToCompare="NewPassword" 
                     ErrorMessage="<br />Hasła nie są zgodne" ControlToValidate="NewPasswordConfirm" Display="Dynamic" runat="server" />
            </td>
        </tr>
        <tr>
            <td><div style="padding-bottom: 20px;"></div></td>
        </tr>
        <tr>
            <td colspan="2">
                <div style="float: left; text-align: left; padding-bottom: 10px;" class="regulamin-text">
                    <span class="header2">
                        Zmiana adresu e-mail:
                    </span>
                </div>
            </td>
        </tr>
        <tr>
            <td class="middle"><div class="medium-green3" style="text-align: left; padding-left: 10px;">Adres e-mail</div></td>
            <td class="middle"><asp:TextBox ID="Email" CssClass="default-textbox"  runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="default" 
                     ErrorMessage="*" ControlToValidate="Email" Display="Dynamic" runat="server" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" EnableClientScript="false" Display="Dynamic" ControlToValidate="Email" ValidationGroup="default"
                     runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Text="<br />Wprowadzony E-mail nie jest prawidłowy" />                                
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5"  Display="Dynamic" ControlToValidate="Email" ValidationGroup="default"
                     runat="server" ValidationExpression="^[\s\S]{0,255}$" Text="<br />Dozwolone nie więcej niż 255 znaków" />                                
            </td>
        </tr>
        <tr>
            <td colspan="2"><asp:Literal ID="Message" runat="server" EnableViewState="False" /></td>
        </tr>
        <tr>
            <td colspan="3">
                <div style="text-align: right;width: 100%; border-bottom: 1px solid #C8D1B3; padding-top: 10px;" >
                     <asp:LinkButton ID="ContinueButton" ValidationGroup="default"  Text="Zapisz zmiany" 
                         CssClass="medium-button" runat="server" onclick="ContinueButton_Click"  />
                </div>
            </td>
        </tr>
    </table>
</div>