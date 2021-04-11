<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GiveTest.aspx.cs" Inherits="Quiz_Project.GiveTest" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Test</title>
    <%--<link rel="stylesheet" href="new/css/GiveTest.css" />--%>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7/jquery.min.js" type="text/javascript"></script>

</head>
<body oncontextmenu="return false" style=" background: #59626b;">
    <form id="form1" runat="server">
        <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>

        <div style="background: #f5f6f7;margin:0 auto; width:1000px;">
            <%--<asp:UpdatePanel ID="updPanel" runat="server" UpdateMode="Always">
                <ContentTemplate>--%>
                    <table>
                        <%--<tr>
                            <td>
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="float: left;"><b><span id="timerText"></span><span id="spnthankyou"></span></b></td>
                                        <td style="float: right; background-color: yellow; color: black;"><b><span id="lbresult"></span></b></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>--%>
                        <tr>
                            <td style="margin-left: 40px">
                                 <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="False"   DataKeyNames="QuestionNo" Width="100%" BackColor="White" BorderStyle="None" BorderWidth="0px" CellPadding="5">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Online" >
                                                    <ItemTemplate>
                                                        <table id='<%#Eval("QuestionNo") %>'>
                                                            <tr>
                                                                <td>
                                                                    <b><%#Eval("QuestionNo") %>.</b>&nbsp;
                                                                     <asp:HiddenField ID="hdnquestionId" runat="server"/>
                                                                    <b><%#Eval("Question") %></b>
                                                                </td>
                                   
                                        
                                    
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    
                                                                    <table >
                                                                        <tr>
                                                                            
                                                                            <td>
                                                                                <asp:RadioButton ID="RadioButton1" runat="server" Text='<%#Eval("choice1") %>' GroupName='<%#Eval("QuestionNo") %>'/>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:RadioButton ID="RadioButton2" runat="server" Text='<%#Eval("choice2") %>' GroupName='<%#Eval("QuestionNo") %>'/>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:RadioButton ID="RadioButton3" runat="server" Text='<%#Eval("choice3") %>' GroupName='<%#Eval("QuestionNo") %>'/>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:RadioButton ID="RadioButton4" runat="server" Text='<%#Eval("choice4") %>' GroupName='<%#Eval("QuestionNo") %>'/>
                                                                            </td>
                                                                        </tr>

                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                            <RowStyle ForeColor="#000066" />
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                                        </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn"   OnClick="btnSubmit_Click" />
                            </td>
                        </tr>
                    </table>
              <%--  </ContentTemplate>
            </asp:UpdatePanel>--%>

             <%--<script src="new/js/GiveTest.js">   
            </script>--%>



       </div>
    </form>
</body>
</html>

