<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="AspNetWebFromHandler.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #tbList {
            border:1px solid #0094ff;
            width:300px;
            margin:10px auto;
            border-collapse:collapse;
        }
        #tbList tr,td,th{
            border:1px solid #0094ff;
            padding:5px;
           
        }
    </style>
    <script type="text/javascript">
            function dodel(cid)
        {
            if (confirm("你确定要删除id：" + cid+"吗？")) {
                window.location = "http://localhost:7534/DelForm.aspx";
            }
            else
            {
                alert("你没有删除！");
            }
            }
        </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%
            for (int i = 0; i < 10; i++)
            {
                Response.Write(DateTime.Now.ToString()+"</br>");
            }
             %>
    </div>
    </form>
        <table id="tbList">
        <tr>
            <th>ID</th>
            <th>班级</th>
            <th>操作</th>
        </tr>
        <%Response.Write(sbHtml.ToString()); %>
    </table>
</body>
</html>
