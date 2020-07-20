<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SynchronizationContext.AspNet.WebForms._Default" %>

<%@ Import Namespace="System.Threading.Tasks" %>

<!DOCTYPE html>

<html>
<head>
    <title>My ASP.NET Application</title>
</head>
<body runat="server">
    <p>
        <%=
            "SynchronizationContext: " +
            (System.Threading.SynchronizationContext.Current?.ToString() ?? "null") +
            " TaskScheduler: " + TaskScheduler.Current
        %>
    </p>
</body>
</html>
