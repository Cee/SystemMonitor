<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Lab_2.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>System Monitor</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <link href="assets/bootstrap-3.2.0/css/bootstrap.min.css" rel="stylesheet"/>
<%--    <script type="text/javascript" src="assests/bootstrap-3.2.0/js/bootstrap.min.js"></script>--%>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1 style="text-align:center;">System Monitor  <small>by Cee</small></h1>
            <div class="row" style="text-align:center;padding:10px 0">
                <div class="col-md-9">
                    <asp:Button ID="Button1" runat="server" class="btn btn-default" Text="Sort by Name" OnClick="Button1_Click" />
                    <asp:Button ID="Button2" runat="server" class="btn btn-primary" Text="Sort by Pid" OnClick="Button2_Click" />
                    <asp:Button ID="Button3" runat="server" class="btn btn-success" Text="Sort by Owner" OnClick="Button3_Click" />
                    <asp:Button ID="Button4" runat="server" class="btn btn-info" Text="Sort by Memory Usage" OnClick="Button4_Click" />
                    <asp:Button ID="Button5" runat="server" class="btn btn-warning" Text="Sort by CPU Usage" OnClick="Button5_Click" />
                    <asp:Button ID="Button7" runat="server" class="btn btn-danger" Text="Sort by Description" OnClick="Button7_Click" />
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="pid" style="max-width:50%;display: inline-block;"></asp:TextBox>
                    <asp:Button ID="Button8" runat="server" class="btn btn-danger" Text="Kill!" OnClick="Kill" />
                </div>
                <div class="col-md-1">
                    <asp:Button ID="Button6" runat="server" class="btn btn btn-link" Text="Refresh" OnClick="Button6_Click" />
                </div>
            </div>
            <div class="table-responsive" style="padding-top:10px;">
                <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource1" AutoGenerateColumns="False" class="table table-bordered table-hover">
                    <Columns>
                        <asp:BoundField DataField="Process_Name" HeaderText="Name" SortExpression="Process_Name" />
                        <asp:BoundField DataField="PID" HeaderText="PID" SortExpression="PID" />
                        <asp:BoundField DataField="Process_Owner" HeaderText="Owner" SortExpression="Process_Owner" />
                        <asp:BoundField DataField="Memory_Usage" HeaderText="Memory Usage" SortExpression="Memory_Usage" />
                        <asp:BoundField DataField="CPU_Usage" HeaderText="CPU Usage" SortExpression="CPU_Usage" />
                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getProcess" TypeName="SystemMonitor.SystemMonitor"></asp:ObjectDataSource>
            </div>
        </div>
    </form>
</body>
</html>
