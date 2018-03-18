﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Findpwd1.aspx.cs" Inherits="Module_Admin_Findpwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
        <title>找回密码</title>
        <link href="../../CSS/StyleSheet.css" rel="stylesheet" type="text/css" />
    </head>
    <body style="margin-top: 0px; padding-top: 0px">
        <form id="form1" runat="server">
            <div>
                <table align="center" style="text-align: center; width: 755px;" cellpadding="0" cellspacing="0">
                    <tr>
                        <td colspan="3" style="height: 8px">
                            &nbsp;<asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Skin/head.jpg" /></td>
                    </tr>
                    <tr>
                        <td style="background-image: url(../../Images/Skin/reg.jpg); height: 371px; text-align: center; vertical-align: middle;" 
                            colspan="3">
                            <table style="width: 392px">
                                <tr>
                                    <td colspan="3">
                                        <strong><span style="color: #993300; text-align: center;">找回密码</span></strong></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 149px;">
                                        <span style="font-size: 9pt">用户名:</span></td>
                                    <td style="text-align: left; width: 170px;">
                                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                                    <td style="width: 129px">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtName"
                                                                    ErrorMessage="请输入用户名">*</asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 149px;">
                                        <span style="font-size: 9pt">验证码:</span></td>
                                    <td style="text-align: left; width: 170px;">
                                        <asp:TextBox ID="txtVali" runat="server" Width="72px"></asp:TextBox>
                                        <asp:Label ID="labVial" runat="server" Font-Bold="False" Font-Size="12pt" ForeColor="#0000FF"
                                                   Width="68px"></asp:Label></td>
                                    <td style="width: 129px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 149px">
                                    </td>
                                    <td style="width: 170px">
                                        <asp:Button ID="btnOK" runat="server" Text="确定" OnClick="btnOK_Click" Font-Size="9pt" />
                                        <asp:Button ID="btnCancle" runat="server" CausesValidation="False" Text="取消" OnClick="Button2_Click" Font-Size="9pt" /></td>
                                    <td style="width: 129px">
                                    </td>
                                </tr>
                            </table>
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Size="9pt" ShowMessageBox="True" ShowSummary="False" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 21px">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Skin/bottom.jpg" />&nbsp;</td>
                    </tr>
                </table>
    
            </div>
        </form>
    </body>
</html>