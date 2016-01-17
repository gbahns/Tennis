<%@ Page Language="C#" MasterPageFile="~/Tennis.Master" AutoEventWireup="true" CodeBehind="NewUser.aspx.cs" Inherits="Tennis.Account.NewUser" Title="New User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:CreateUserWizard ID="CreateUserWizard1" runat="server" DisableCreatedUser="true" LoginCreatedUser="false" OnCreatedUser="CreateUserWizard1_CreatedUser" OnSendingMail="CreateUserWizard1_SendingMail" >
		<MailDefinition From="support@personaltracker.bahns.com" Subject="Account Created" BodyFileName="~/Account/NewUser.txt" />

		<WizardSteps>
			<asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server" >
			</asp:CreateUserWizardStep>
			
			<asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
			</asp:CompleteWizardStep>
		</WizardSteps>
	</asp:CreateUserWizard>
</asp:Content>
