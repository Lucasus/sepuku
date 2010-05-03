<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RecoverySendMail.ascx.cs" Inherits="Controls_Membership_RecoverySendMail" %>
<div class="outer-login-box2">
    <table id="TableBefore" class="register-table" runat="server" >
        <tr>
            <td style="text-align:center;"  colspan="2">
                <span style="text-align:center;"  class="big-green2">Przypomnienie hasła</span>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div style="float: left;" class="regulamin-text">
                    <span>
                        Podaj swój adres email, który podałeś przy rejestracji. Otrzymasz e-mail ze swoim loginem oraz linkiem do generacji nowego hasła.
                    </span>
                </div>
            </td>
        </tr>
        <tr>
            <td  class="middle"><span class="medium-green3">E-mail</span></td>
            <td class="middle"><asp:TextBox ID="Email" CssClass="login-input-box"  runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="default" 
                 ErrorMessage="*" ControlToValidate="Email" Disply="Dynamic" runat="server" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" EnableClientScript="false" Display="Dynamic" ControlToValidate="Email" ValidationGroup="default"
                 runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Text="<br />Wprowadzony E-mail nie jest prawidłowy" />                                
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1"  Display="Dynamic" ControlToValidate="Email" ValidationGroup="default"
                 runat="server" ValidationExpression="^[\s\S]{0,255}$" Text="<br />Dozwolone nie więcej niż 255 znaków" />                                
            </td>
        </tr>
        <tr>
            <td colspan="2"><asp:Literal ID="Message" runat="server" EnableViewState="False" /></td>
        </tr>
        <tr>
            <td colspan="2">
                <div style="text-align: center;width: 100%; border-bottom: 1px solid #C8D1B3; padding-bottom: 10px;" >
                     <asp:LinkButton ID="ContinueButton" ValidationGroup="default"  Text="Wyślij" 
                         CssClass="medium-button" runat="server" onclick="ContinueButton_Click" />
                </div>
            </td>
        </tr>
    </table>
    <table id="TableAfter" class="register-table" runat="server" visible="false" style="padding-left: 115px;" >
        <tr>
            <td colspan="2">
                <div style="text-align: center;width: 100%; padding-bottom: 10px;" >
                    Email został wysłany na podany adres
                </div>
            </td>
        </tr>
    </table>
</div>