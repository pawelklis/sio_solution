<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="sio_wnet.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .editpanel{
            display:inline-grid;
        }
        .editpanelrow{

        }
        .editpanellabel{
            margin:5px;
        }
        .editpaneltx{
            margin:5px;
        }
    </style>


</head>
<body>
    <form id="form1" runat="server">
        <div>
            nowy raport
                <asp:DropDownList ID="ddlshifts" runat="server"></asp:DropDownList>
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server"></asp:Panel>

        </ContentTemplate></asp:UpdatePanel>

        </div>
    </form>
</body>
</html>
