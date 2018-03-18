using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ST_GROUP.Blog
{
    /// <summary>
    ///   ST_admin_replay ��ժҪ˵����
    /// </summary>
    public partial class ST_admin_replay : Page
    {
        private static string ID;
        private readonly SqlData sd = new SqlData();
        protected DataGrid DataGrid1;
        private SqlConnection ST_myConn;

        protected void Page_Load(object sender, EventArgs e)
        {
            // �ڴ˴������û������Գ�ʼ��ҳ��
            /*�ж��Ƿ��¼*/
            //ST_check_Login();
            /*��������*/

            if (!Page.IsPostBack)
            {
                ST_Replay_Bind();
            }
            string ST_dns = ConfigurationSettings.AppSettings["conStr"];
            ST_myConn = new SqlConnection(ST_dns);
        }


        private void ST_Replay_Bind()
        {
            string ST_sql = "select * from ST_replay";
            //���ù�����SqlData�е�ExceDS����������һ��DataSet���͵����ݼ�
            ReplayList.DataSource = sd.ExceDS(ST_sql);
            ReplayList.DataKeyNames = new[] {"ST_r_id"};
            ReplayList.DataBind();
        }

        //public void ST_check_Login()
        //{

        //    if ((Session["UserName"] == null))
        //    {
        //        Response.Write("<script>alert('�Բ����������ǻ�Ա������ע���ٵ�¼��');location='../../BlogIndex.aspx'</script>");
        //        Response.End();
        //    }
        //}
        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i <= ReplayList.Rows.Count - 1; i++)
            {
                CheckBox cbox = (CheckBox) ReplayList.Rows[i].FindControl("CheckBox1");
                if (CheckBox2.Checked)
                {
                    cbox.Checked = true;
                }
                else
                {
                    cbox.Checked = false;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            CheckBox2.Checked = false;
            for (int i = 0; i <= ReplayList.Rows.Count - 1; i++)
            {
                CheckBox cbox = (CheckBox) ReplayList.Rows[i].FindControl("CheckBox1");
                cbox.Checked = false;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ST_myConn.Open();
            for (int i = 0; i <= ReplayList.Rows.Count - 1; i++)
            {
                CheckBox cbox = (CheckBox) ReplayList.Rows[i].FindControl("CheckBox1");
                if (cbox.Checked)
                {
                    string sqlstr = "delete from ST_replay where ST_r_id='" + ReplayList.DataKeys[i].Value + "'";
                    sd.ExceSQL(sqlstr);
                }
            }

            ST_Replay_Bind();
        }

        protected void ReplayList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ReplayList.PageIndex = e.NewPageIndex;
            ST_Replay_Bind();
        }

        protected void ReplayList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.Cells[2].Text).Length > 2)
                {
                    e.Row.Cells[2].Text = (e.Row.Cells[2].Text).Substring(0, 2) + "��";
                }
                ((LinkButton) e.Row.Cells[4].Controls[0]).Attributes.Add("onclick", "return confirm('ȷ��Ҫɾ����?')");
            }
        }

        protected void ReplayList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //����������SqlData��һ����ʵ������
            SqlData da = new SqlData();
            //���ù������е�ExceSQL,ִ��ɾ����SQL���
            bool delete =
                da.ExceSQL("delete from ST_replay where ST_r_id='" + ReplayList.DataKeys[e.RowIndex].Value + "'");
            if (delete)
            {
                Response.Write("<script language=javascript>alert('ɾ���ɹ���');location='ST_admin_replay.aspx'</script>");
            }
            else
            {
                Response.Write("<script language=javascript>alert('ɾ��ʧ�ܣ�');location='ST_admin_replay.aspxx'</script>");
            }
        }
    }
}