<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form1.aspx.cs" Inherits="LD5.Form1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LD5</title>
    <link href ="StyleSheet1.css" rel ="stylesheet" type ="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Pasirinkite pradinius dienų duomenis:"></asp:Label>
            <br />
            <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="True" />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Pasirinkite pradinius serverių duomenis:"></asp:Label>
            <br />
            <asp:FileUpload ID="FileUpload2" runat="server" />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
            <br />
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Pasirinkite serverį:"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Serverio stuktūra:"></asp:Label>
            <br />
            <asp:Table ID="Table1" runat="server">
            </asp:Table>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Pasirinkite dieną ir sužinokite į kurį kompiuterį buvo kreiptasi daugiausia: "></asp:Label>
            <asp:DropDownList ID="DropDownList2" runat="server">
            </asp:DropDownList>
            <br />
            <asp:Table ID="Table2" runat="server">
            </asp:Table>
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />
        </div>
    </form>
</body>
</html>
