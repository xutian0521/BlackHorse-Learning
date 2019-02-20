<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HtmlEncode 编码转换.aspx.cs" Inherits="AspNetWebFromHandler.HtmlEncode_编码转换" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <%=Server.HtmlEncode("<a href='#'>你好</a>")%><br />
        <%=Server.HtmlDecode(" &lt;a href=&#39;#&#39;&gt;你好&lt;/a&gt;")  %>
    </div>
    </form>
</body>
</html>
