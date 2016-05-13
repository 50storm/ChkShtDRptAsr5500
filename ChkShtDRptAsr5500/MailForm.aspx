<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/SiteChkSheet.Master" CodeBehind="MailForm.aspx.vb" Inherits="ChkShtDRptAsr5500.MailForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ChkShtDRptAsr5500" runat="server">
   <div>
       
            <asp:RadioButton ID="MenuRequest" runat="server" GroupName="Menu" Text="ダブルチェック依頼" />
            <asp:RadioButton ID="MenuPass" runat="server" GroupName="Menu" Text="ダブルチェックOK" />
            <asp:RadioButton ID="MenuNotPass" runat="server" GroupName="Menu" Text="ダブルチェックNG" />
   </div>
    <div>
        <asp:Label ID="lblTo" runat="server" Text="To:"></asp:Label>
        <asp:DropDownList ID="ddListPersonTo" runat="server">
           <asp:ListItem Value="igarashi@hnps.co.jp">五十嵐</asp:ListItem>
        </asp:DropDownList>
        

        <asp:Label ID="lblFrom" runat="server" Text="FROM："></asp:Label>
       <asp:DropDownList ID="ddListPersonFrom" runat="server">
           <asp:ListItem Value="igarashi@hnps.co.jp">五十嵐</asp:ListItem>
       </asp:DropDownList>

    </div>
    <div>
        
        <asp:Label ID="lblTitle" runat="server" Text="タイトル"></asp:Label>
        <br/>
        <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
        
    <div>
         <asp:Label ID="lblBody" runat="server" Text="本文"></asp:Label>
        <br />
        <asp:TextBox ID="txtBody" runat="server" Rows="100" Width="500px" Height="500px"></asp:TextBox>

    </div>
    
    <div>
   
       
        <asp:Button ID="btnSubmitMail" runat="server" Text="メール送信" />
        <asp:Label ID="lblMsg" runat="server" Text="メッセージが表示されます"></asp:Label>
    </div>
</asp:Content>
