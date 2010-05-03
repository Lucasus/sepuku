<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Register.ascx.cs" Inherits="Controls_Membership_Register" %>
<div class="outer-login-box2">
    <asp:CreateUserWizard ID="RegistrationWizard" DisableCreatedUser="true" LoginCreatedUser="false" 
        NavigationStyle-HorizontalAlign="Center" runat="server" 
         DuplicateUserNameErrorMessage="Użytkownik o podanym loginie już istnieje. Wprowadź inną nazwę użytkownika"
        oncreateduser="RegistrationWizard_CreatedUser" 
        oncreatinguser="RegistrationWizard_CreatingUser" >
        <NavigationStyle HorizontalAlign="Center">
        </NavigationStyle>
        <WizardSteps>
            <asp:CreateUserWizardStep>
                <ContentTemplate>
                    <table class="register-table">
                        <tr style="text-align:center;">
                            <td colspan="2">
                                <span style="text-align:center;" class="big-green2">Aby się zarejestrować, wypełnij poniższy formularz</span>
                            </td>
                        </tr>
                        <tr>
                            <td><span class="medium-green3">Podaj swój login</span></td>
                            <td><asp:TextBox ID="UserName" CssClass="login-input-box"   runat="server" />
                            <asp:RequiredFieldValidator ID="RefUserName" ValidationGroup="default" 
                                 ErrorMessage="*" ControlToValidate="UserName" Disply="Dynamic" runat="server" />
                            <asp:RegularExpressionValidator ID="RevUserName" Display="Dynamic" ControlToValidate="UserName" ValidationGroup="default"
                                 runat="server" ValidationExpression="^[\s\S]{0,255}$" Text="<br />Dozwolone nie więcej niż 255 znaków" />                                
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" Display="Dynamic" ControlToValidate="UserName" ValidationGroup="default"
                                 runat="server" ValidationExpression="^([a-zA-Z])[a-zA-Z_-]*[\w_-]*[\S]$|^([a-zA-Z])[0-9_-]*[\S]$|^[a-zA-Z]*[\S]$" Text="<br />Wprowadzony login nie jest poprawny" />                                
                            </td>
                        </tr>
                        <tr>
                            <td class="middle"><span class="medium-green3">Podaj swój adres e-mail</span></td>
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
                            <td colspan="2"><asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False" /></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div style="float: left; margin-right: 5px;">
                                <asp:CheckBox ID="CkbRegulamin" runat="server" /> 
                                </div>
                                <div style="float: left;" class="regulamin-text">
                                <span>
                                    Akceptuję regulamin oraz wyrażam zgodę na przetwarzanie 
                                    moich danych osobowych w celu korzystania z serwisu dobrenawyki.pl
                                </span>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <asp:CustomValidator id="CvRegulamin" runat="server" ValidationGroup="default" 
                        ErrorMessage="<br />Aby dokonać rejestracji należy zaakceptować regulamin" 
                        OnServerValidate="CvRegulamin_ServerValidate" Visible="false" />
                </ContentTemplate>
                <CustomNavigationTemplate>
                    <div style="width: 100%; border-bottom: 1px solid #C8D1B3; padding-bottom: 10px;" >
                     <asp:LinkButton ID="ContinueButton" ValidationGroup="default" CssClass="start-button" CommandName="MoveNext" Text="Zarejestruj się" runat="server" />
                    </div>
                </CustomNavigationTemplate>
            </asp:CreateUserWizardStep>
            <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                <ContentTemplate>
                    Twoje konto zostało pomyślnie założone.</td>
                    <asp:Button ID="ContinueButton" CommandName="Continue"
                    runat="server" Text="Kontynuuj" />
                </ContentTemplate>
            </asp:CompleteWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
</div>