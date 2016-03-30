<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Entity Framework</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    



        <br />
        <br />
        <br />
        <asp:DropDownList ID="ddlCompanies" runat="server" AppendDataBoundItems="True" AutoPostBack="True" 
            DataSourceID="EntityDataSource1" DataTextField="CompanyName" DataValueField="SupplierID" 
            Height="16px" OnSelectedIndexChanged="ddlCompanies_SelectedIndexChanged" Width="180px">
            <asp:ListItem Value="0">Select Supplier</asp:ListItem>
        </asp:DropDownList>
        <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=NorthwindEntities" 
            DefaultContainerName="NorthwindEntities" EnableFlattening="False" EntitySetName="Suppliers" Select="it.[SupplierID], it.[CompanyName]">
        </asp:EntityDataSource>
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblOutput" runat="server"></asp:Label>
    



    </div>
    </form>
</body>
</html>
