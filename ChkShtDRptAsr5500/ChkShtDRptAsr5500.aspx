<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/SiteChkSheet.Master" CodeBehind="ChkShtDRptAsr5500.aspx.vb" Inherits="ChkShtDRptAsr5500.ChkShtDRptAsr5500" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ChkShtDRptAsr5500" runat="server">
    <script>
        $(function () {
           // $("#ChkShtDRptAsr5500_txtYear").val(getCurrentDate());

            $("#ChkShtDRptAsr5500_txtYear").datepicker({
                dateFormat: 'yy/mm/dd',
                showOn: "button",
                buttonImage: "img/calendar_button.png",
                buttonImageOnly: true
            });
        });
    </script>

    <h2>Daily Report ASR5500 CheckSheet</h2>
        <div>
            <asp:RadioButton ID="RBtnInsert" runat="server" GroupName="Menu" Text="登録" />
            <asp:RadioButton ID="RBtnUpdate" runat="server" GroupName="Menu" Text="修正" />
            <asp:RadioButton ID="RBtnDelete" runat="server" GroupName="Menu" Text="削除" />
         </div>
        <div>
            <asp:TextBox ID="txtYear" runat="server"></asp:TextBox>
            <asp:button runat="server" text="データ検索" ID="btnSearch" />
            <asp:button runat="server" text="メール送信" ID="btnMail" />
        </div>
    
        <table>
		<tr>
			<th>
				シート
			</th>
			
			<th>
				項目
			</th>
			<th>
				確認内容
			</th>
			<th>
				  <asp:DropDownList ID="ddListPerson1" runat="server">
                      <asp:ListItem>五十嵐</asp:ListItem>
                  </asp:DropDownList>
	
			</th>
          <th>
				  <asp:DropDownList ID="ddListPerson2" runat="server">
                      <asp:ListItem>五十嵐</asp:ListItem>
                  </asp:DropDownList>
			</th>
		</tr>
		<tr>
		
			<td rowspan="8" >
				<asp:Label ID="SheetName01" runat="server" Text="Label">ASR5500_Summary </asp:Label>
			</td>
			<td>
				<asp:Label ID="Category01" runat="server" Text="Label">タイトル </asp:Label>
			
			</td>
			<td>
                <asp:Label ID="Content01" runat="server" Text="Label">日付は当日になっているか？  </asp:Label>
			</td>
			<td>
			    <asp:CheckBox ID="ChkBoxMaker01" runat="server" />
            </td>
			<td>
			    <asp:CheckBox ID="ChkBoxChecker01" runat="server" />
    		</td>
		</tr>
	
            <tr>
                <td>
			    	<asp:Label ID="Category02" runat="server" Text="Label">本文 </asp:Label>
			    
			    </td>
			    <td>
                    <asp:Label ID="Content02" runat="server" Text="Label">【手動】コロンを付与したか？[Summary]CQAP:ASR5500~ </asp:Label>
			    </td>
			    <td>
			        <asp:CheckBox ID="ChkBoxMaker02" runat="server" />
                </td>
			    <td>
			        <asp:CheckBox ID="ChkBoxChecker02" runat="server" />
    		    </td>
            </tr>
            <tr>
                <td>
			    	<asp:Label ID="Category03" runat="server" Text="Label">本文 </asp:Label>
			    </td>
			    <td>
                    <asp:Label ID="Content03" runat="server" Text="Label">Inspection QTYの数量は正しいか？  </asp:Label>
			    </td>
			    <td>
			        <asp:CheckBox ID="ChkBoxMaker03" runat="server" />
                </td>
			    <td>
			        <asp:CheckBox ID="ChkBoxChecker03" runat="server" />
    		    </td>
            </tr>
            <tr>
                <td>
			    	<asp:Label ID="Category04" runat="server" Text="Label">本文 </asp:Label>
			    </td>
			    <td>
                    <asp:Label ID="Content04" runat="server" Text="Label">【手動】HWWNがあるときに、Defect QTYの数量から、HWWNを差し引いたか？  </asp:Label>
			    </td>
			    <td>
			        <asp:CheckBox ID="ChkBoxMaker04" runat="server" />
                </td>
			    <td>
			        <asp:CheckBox ID="ChkBoxChecker04" runat="server" />
    		    </td>
            </tr>
            <tr>
                <td>
			    	<asp:Label ID="Category05" runat="server" Text="Label">本文 </asp:Label>
			    </td>
			    <td>
                    <asp:Label ID="Content05" runat="server" Text="Label">Defect QTYの数量は正しいか？  </asp:Label>
			    </td>
			    <td>
			        <asp:CheckBox ID="ChkBoxMaker05" runat="server" />
                </td>
			    <td>
			        <asp:CheckBox ID="ChkBoxChecker05" runat="server" />
    		    </td>
            </tr>
            <tr>
                <td>
			    	<asp:Label ID="Category06" runat="server" Text="Label">本文 </asp:Label>
			    </td>
			    <td>
                    <asp:Label ID="Content06" runat="server" Text="Label"> FYI　QTYの数量は正しいか？ </asp:Label>
			    </td>
			    <td>
			        <asp:CheckBox ID="ChkBoxMaker06" runat="server" />
                </td>
			    <td>
			        <asp:CheckBox ID="ChkBoxChecker06" runat="server" />
    		    </td>
            </tr>
            <tr>
                <td>
			    	<asp:Label ID="Category07" runat="server" Text="Label">本文 </asp:Label>
			    </td>
			    <td>
                    <asp:Label ID="Content07" runat="server" Text="Label">検査した期間のFrom日付とTo日付は正しいか？  </asp:Label>
			    </td>
			    <td>
			        <asp:CheckBox ID="ChkBoxMaker07" runat="server" />
                </td>
			    <td>
			        <asp:CheckBox ID="ChkBoxChecker07" runat="server" />
    		    </td>
            </tr>
            <tr>
                <td>
			    	<asp:Label ID="Category08" runat="server" Text="Label">本文 </asp:Label>
			    </td>
			    <td>
                    <asp:Label ID="Content08" runat="server" Text="Label">【手動】HWWNがあるときに、Defect QTYの数量から、HWWNを差し引いたか？  </asp:Label>
			    </td>
			    <td>
			        <asp:CheckBox ID="ChkBoxMaker08" runat="server" />
                </td>
			    <td>
			        <asp:CheckBox ID="ChkBoxChecker08" runat="server" />
    		    </td>
            </tr>
		</table>
        <div>
         <asp:Button ID="btnSubmit" runat="server" Text="サーバーに送信" />    
            <asp:Label ID="lblMsg" runat="server" Text="メッセージが表示されます" ForeColor="#FF3300"></asp:Label>
        </div>
    			
   
</asp:Content>



