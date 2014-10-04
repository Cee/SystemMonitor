using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SystemMonitor;

namespace Lab_2
{
    public partial class index : System.Web.UI.Page
    {
        public SystemMonitor.SystemMonitor sm = new SystemMonitor.SystemMonitor();

        protected void Page_Load(object sender, EventArgs e)
        {
            sm.getProcess();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                sm.sortByName();
                ObjectDataSource1.SelectMethod = "sortByName";
            }
            catch (NotImplementedException)
            {
                ObjectDataSource1.SelectMethod = "getProcess";
            }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                sm.sortByName();
                ObjectDataSource1.SelectMethod = "sortByPid";
            }
            catch (NotImplementedException)
            {
                ObjectDataSource1.SelectMethod = "getProcess";
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                sm.sortByName();
                ObjectDataSource1.SelectMethod = "sortByOwner";
            }
            catch (NotImplementedException)
            {
                ObjectDataSource1.SelectMethod = "getProcess";
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                sm.sortByName();
                ObjectDataSource1.SelectMethod = "sortByMem";
            }
            catch (NotImplementedException)
            {
                ObjectDataSource1.SelectMethod = "getProcess";
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                sm.sortByName();
                ObjectDataSource1.SelectMethod = "sortByCpu";
            }
            catch (NotImplementedException)
            {
                ObjectDataSource1.SelectMethod = "getProcess";
            }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            try
            {
                sm.sortByName();
                ObjectDataSource1.SelectMethod = "sortByDes";
            }
            catch (NotImplementedException)
            {
                ObjectDataSource1.SelectMethod = "getProcess";
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            ObjectDataSource1.SelectMethod = "getProcess";
        }

        protected void Kill(object sender, EventArgs e)
        {
            int pid;
            try
            {
                pid = Int32.Parse(TextBox1.Text);
            }
            catch
            {
                Response.Write("<script>alert('Please Check Your Pid!');</script>");
                return;
            }

            try
            {
                if (sm.kill(pid))
                {
                    Response.Write("<script>alert('Success!');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Fail');</script>");
                }
            }
            catch (NotImplementedException)
            {
                Response.Write("<script>alert('Not Implemented');</script>");
            }

        }
    }
}