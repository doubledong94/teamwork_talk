using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace ST_GROUP.Blog
{
    /// <summary>
    ///   ST_message ��ժҪ˵����
    /// </summary>
    public partial class ST_message : Page
    {
        private readonly SqlData dataoperate = new SqlData();
        public string ST_bgcolor;
        private SqlConnection ST_myConn;
        public string ST_tcolor;
        protected HtmlForm show;

        protected void Page_Load(object sender, EventArgs e)
        {
            FreeTextBox1.FontFacesMenuList = dataoperate.strFont();
            // �ڴ˴������û������Գ�ʼ��ҳ��
            if (Request.Cookies["colors"] != null)
            {
                string ST_test = Request.Cookies["colors"].Value;
                String[] ST_colorList = ST_test.Split(new[] {','});
                ST_bgcolor = ST_colorList[0];
                ST_tcolor = ST_colorList[1];
            }
            else
            {
                ST_bgcolor = "#FFDE94";
                ST_tcolor = "#efe3ce";
            }

            ST_msg_Bind();
            Page.DataBind();
        }

        public void ST_msg_Bind()
        {
            string ST_dns = ConfigurationSettings.AppSettings["conStr"];
            string ST_msg_sql = "select  * from ST_message order by ST_mdate desc";

            ST_myConn = new SqlConnection(ST_dns);
            SqlDataAdapter ST_msgCmd = new SqlDataAdapter(ST_msg_sql, ST_myConn);

            DataSet ST_ds = new DataSet();
            ST_msgCmd.Fill(ST_ds, "�����б�");

            messagelist.DataSource = new DataView(ST_ds.Tables[0]);
            messagelist.DataBind();
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (nickname.Text.Trim() == "" || title.Text.Trim() == "" || FreeTextBox1.Text.Trim() == "")
                {
                    Response.Write(
                        "<div align=center><li>�ǳ�,����,���ݲ���Ϊ��!</li><li><a href=javascript:history.back()>��˷�������</a>");
                    Response.End();
                }
                else
                {
                    string ST_sql = "insert into ST_message (ST_nickname,ST_title,ST_homepage,ST_content) values ('" +
                                    nickname.Text + "','" + title.Text + "','" + homepage.Text + "','" +
                                    FreeTextBox1.Text + "')";
                    SqlCommand ST_myCmd = new SqlCommand(ST_sql, ST_myConn);
                    ST_myConn.Open();
                    ST_myCmd.ExecuteNonQuery();
                    ST_myConn.Close();
                    Response.Redirect("ST_message.aspx");
                }
            }
        }
    }
}