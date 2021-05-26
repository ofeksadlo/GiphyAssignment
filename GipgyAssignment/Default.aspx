<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GipgyAssignment.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="canonical" href="https://getbootstrap.com/docs/5.0/examples/checkout-rtl/">

    

    <!-- Bootstrap core CSS -->
    <link href="assets/dist/css/bootstrap.rtl.min.css" rel="stylesheet">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <%--<script src="assets/form-validation.js"></script>--%>

    <script src="assets/dist/js/jquery.min.js"></script>
    <script src="assets/dist/jquery-ui.min.js"></script>
    <link href="assets/dist/jquery-ui.min.css" rel="stylesheet" />
    <script type="text/javascript" src="assets/comboboxFeature.js"></script>
    <link href="assets/StyleSheet.css" rel="stylesheet" />
    <!-- Custom styles for this template -->

    <script src="assets/validation.js"></script>
    <style>
        #giphyGridView td
        {
            text-align: center; 
            vertical-align: middle;
        }
        #giphyGridView th
        {
            text-align: center; 
            vertical-align: middle;
        }
    </style>
</head>
<body>
    <div dir="rtl" class="container-fluid">
    <form dir="rtl" id="form1" runat="server">
        <div class="py-5 text-center">
            <h2>GIPHY</h2>
            <p class="lead">בדף הנ"ל ניתן לחפש גיפים וגם להציג את כל הגיפים החדשים להיום</p>
        </div>
        <center>
        <asp:RadioButtonList Width="12%" AutoPostBack="true" CssClass="form-control" ID="pickRadioButtonList" runat="server" OnSelectedIndexChanged="pickRadioButtonList_SelectedIndexChanged">
            <asp:ListItem Selected="True" Value="0">הצג טרנד יומי</asp:ListItem>
            <asp:ListItem Value="1">חפש</asp:ListItem>
            </asp:RadioButtonList>
        <asp:TextBox ID="queryTextBox" Width="12%" Visible="false" AutoPostBack="true" CssClass="form-control" placeholder="הזן קלט לחיפוש ולחץ אנטר" runat="server" OnTextChanged="queryTextBox_TextChanged"></asp:TextBox>
            <br />
        <div>
            <asp:GridView Width="70%" ID="giphyGridView" CssClass="table table-dark" runat="server" OnRowDataBound="giphyGridView_RowDataBound"></asp:GridView>
        </div>
        </center>
    </form>
    </div>
</body>
</html>