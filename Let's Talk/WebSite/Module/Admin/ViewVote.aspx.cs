﻿using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewVote : Page
{
    private int VoteCount;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
            conn.Open();
            //初始化投票项目操作类
            ItemOperation io = new ItemOperation();
            //获取总投票数
            VoteCount = io.GetVoteCount();
            conn.Close();
        }
    }

    public int FormatVoteCount(String itemCount)
    {
        //如果投票被投票
        if (itemCount.Length <= 0)
        {
            //返回0个百分比
            return (0);
        }
        if (VoteCount > 0)
        {
            //返回实际的百分比
            return ((Int32.Parse(itemCount)*100/VoteCount));
        }
        return (0);
    }

    public int FormatVoteImage(int itemCount)
    {
        //返回百分比的图像的长度
        return (itemCount*3);
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("ItemManager.aspx");
    }
}