﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CommonPage.aspx.cs" Inherits="Module_CommonPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
        <title>系统公告</title>
    </head>
    <body style="background-image: url(../../Images/SysSkin/right.jpg); text-align: center;">
        <form id="form1" runat="server">
            <div style="text-align: center">
                <br />
                &nbsp;</div>
            <table style="background-image: url(../../Images/Skin/reg0.jpg); border-bottom: #afafaf 0px dashed; border-left: #afafaf 0px dashed; border-right: #afafaf 0px dashed; border-top: #afafaf 0px dashed; height: 403px; text-align: center; vertical-align: middle; width: 510px;" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="3" rowspan="2" style="height: 264px; text-align: center; vertical-align: middle; width: 429px;">
                        <MARQUEE direction="up" onmouseout=" this.start() " onmouseover=" this.stop() " scrollAmount="2" scrollDelay="4" style="height: 237px; text-align: center; vertical-align: middle; width: 524px;">
                            <asp:DataList ID="DataList1" runat="server">
                                <ItemTemplate>
                                    &nbsp;<table width="100%">
                                              <tr>
                                                  <td colspan="2" rowspan="2" style="text-align: left; width: 415px;">
                                                      <asp:Label ID="Label1" runat="server" Text=<%#                                        DataBinder.Eval(Container, "DataItem.NoticeContent") %> Font-Size="9pt" Width="390px"></asp:Label></td>
                                                  <td>
                                                  </td>
                                              </tr>
                                              <tr>
                                                  <td>
                                                      <asp:Label ID="Label2" runat="server" Font-Size="9pt" Text='<%#                                        DataBinder.Eval(Container, "DataItem.NoticeTime", "{0:yyyy-MM-dd}") %>' Width="88px"></asp:Label></td>
                                              </tr>
                                          </table>
                                </ItemTemplate>
                            </asp:DataList></ MARQUEE >
                    </td>
                </tr>
                <tr>
                </tr>
            </table> 
        </form>
    </body>
</html>