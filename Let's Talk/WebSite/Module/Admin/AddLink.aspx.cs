﻿using System;
using System.Web.UI;

public partial class Module_Blog_AddFriendLink : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["UserName"] == null)
        //{
        //    Response.Redirect("~/BlogIndex.aspx");
        //}
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        string P_str_Com = "insert into ST_link(ST_l_name,ST_l_url) values('" + txtNmae.Text + "','" + txtUrl.Text +
                           "')";
        SqlData da = new SqlData();
        bool add = da.ExceSQL(P_str_Com);
        if (add)
        {
            Response.Write("<script language=javascript>alert('链接添加成功!');location='LinkManage.aspx'</script>");
        }
        else
        {
            Response.Write("<script language=javascript>alert('链接添加失败！');location='javascript:history.go(-1)'</script>");
        }
    }

    protected void btnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("LinkManage.aspx");
    }
}