﻿using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;

public partial class Module_Admin_Index : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!Equals(Request.Cookies["UserName"], null))
            {
                //创建一个Cookie对象，实现记录用户名
                HttpCookie readcookie = Request.Cookies["UserName"];
                txtUid.Text = readcookie.Value;
            }
        }
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["CheckCode"];
        //判断验证码是否有误
        if (cookie.Value != txtVali.Text.Trim())
        {
            Response.Write("<script lanuage=javascript>alert('验证码错误');location='javascript:history.go(-1)'</script>");
        }
        else
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
            con.Open();
            string strsql = "select count(*) from tb_Admin where UserName='" + txtUid.Text + "'and PassWord='" +
                            txtPwd.Text + "' and SuperAdmin='True'";
            SqlCommand com = new SqlCommand(strsql, con);
            SqlData da = new SqlData();
            SqlDataReader read =
                da.ExceRead("select * from tb_Admin where UserName='" + txtUid.Text + "' and PassWord='" + txtPwd.Text +
                            "'");
            read.Read();
            if (read.HasRows)
            {
                Session["SuperAdmin"] = read["SuperAdmin"].ToString();
            }
            read.Close();
            int count = Convert.ToInt32(com.ExecuteScalar());
            if (count > 0)
            {
                if (Equals(Request.Cookies["UserName"], null))
                {
                    CreateCookie();
                }
                else
                {
                    CreateCookie();
                }
                Session["UserName"] = txtUid.Text;
                Session["PassWord"] = txtPwd.Text;
                Page.Response.Redirect("ST_BlogIndex.aspx");
            }
            else
            {
                Response.Write(
                    "<script lanuage=javascript>alert('用户名或密码有误！');location='javascript:history.go(-1)'</script>");
                return;
            }
        }
    }

    private void CreateCookie()
    {
        //创建一个Cookie对象
        HttpCookie cookie = new HttpCookie("UserName");
        //判断CheckBox控件是否被选中
        if (cbxRemeberUser.Checked)
        {
            cookie.Value = txtUid.Text;
        }
        //获取创建的Cookie对象的过期时间
        cookie.Expires = DateTime.Now.AddMonths(1);
        //将创建的Cookie对象添加到内部Cookie集合中
        Response.AppendCookie(cookie);
    }

    protected void btnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("../../BlogIndex.aspx");
    }
}