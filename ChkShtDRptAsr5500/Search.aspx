<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/SiteChkSheet.Master" CodeBehind="Search.aspx.vb" Inherits="ChkShtDRptAsr5500.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ChkShtDRptAsr5500" runat="server">
        <script>
        $(function () {
            //$("#ChkShtDRptAsr5500_txtDateFrom").val(getCurrentDate());
            //$("#ChkShtDRptAsr5500_txtDateTo").val(getCurrentDate());
            $("#ChkShtDRptAsr5500_txtDateFrom").datepicker({
                dateFormat: 'yy/mm/dd',
                showOn: "button",
                buttonImage: "img/calendar_button.png",
                buttonImageOnly: true
            });
            $("#ChkShtDRptAsr5500_txtDateTo").datepicker({
                dateFormat: 'yy/mm/dd',
                showOn: "button",
                buttonImage: "img/calendar_button.png",
                buttonImageOnly: true
            });
        });
    </script>
    <h2>登録データ検索</h2>
    <div style="border:1px solid black; ">
    <asp:TextBox ID="txtDateFrom" runat="server"></asp:TextBox>～
    <asp:TextBox ID="txtDateTo" runat="server"></asp:TextBox>
    <asp:Button ID="btnSearch" runat="server" Text="検索" />
    <asp:Label ID="lblMsg" runat="server" Text="Label"></asp:Label>
    </div>
    <div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="id" HeaderText="ID" />
            <asp:BoundField DataField="date" HeaderText="日付" />
            <asp:BoundField DataField="name1" HeaderText="作成者" />
            <asp:BoundField DataField="name2" HeaderText="確認者" />
        </Columns>
    </asp:GridView>
    </div>
    <div>
        <asp:Button ID="btnToMainSys" runat="server" Text="戻る" />
    </div>
</asp:Content>