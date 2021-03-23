<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MergeLog.aspx.cs" Inherits="WebApplication1.MergeLog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblSource" runat="server" Text="Select Log Files"></asp:Label>
            <asp:FileUpload runat="server" ID="SelectedLogFiles" AllowMultiple="true" accept=".txt" />
            <br />
            <%--            <asp:Label ID="lbldestination" runat="server" Text="Select Destination Folder"></asp:Label>
            <asp:FileUpload ID="FileUpload2" runat="server" webkitdirectory />--%>
            <asp:Button runat="server" ID="selectedFile" Text="Merge Files" OnClick="mergeFile_Click" />
        </div>
        <div>
            <asp:Label ID="outputMessage" runat="server" Text="" ForeColor="Blue"></asp:Label>
        </div>
    </form>
</body>
</html>
