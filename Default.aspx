<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" EnableViewState="false" EnableSessionState="False" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Visual Galeria</title>
    <link href="visual_galeria.css" rel="stylesheet" type="text/css" />    
    <meta name="author" content="Cesar Quinteros" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="img_stage"></div>
    <div id="container">
    <br />
    <!-- Start image list -->
    <ul id="ul_images" runat="server"></ul>
    <!-- End image list -->
    <br />
    </div><!-- /container -->
    </form>
    <script type="text/javascript" src="<% Response.Expires = 3600 %>visual_galeria.js"></script> 
</body> 
</html>