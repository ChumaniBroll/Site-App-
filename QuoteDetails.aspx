<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="QuoteDetails.aspx.cs" Inherits="QuoteDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .label {
            font: bold;
            color: black;
            font-style: normal;
            text-transform: uppercase;
            color: red;
        }

        .text {
            height: 20%;
            border-radius: 3px;
            margin-left: 2%;
            border-bottom-style: ridge;
        }

        .word {
            font-size: 30px;
            font-style: normal;
            font-family: Corbel;
            color: black;
            text-align: center;
            font: bold;
        }

        .auto-style1 {
            width: auto;
        }

        .auto-style2 {
            width: 508px;
        }

        .text {
            border-radius: 4px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="margin-left: 2px; background-color: #ededed; border-style: ridge; border-radius: 8px; border-color: white; border-width: 12px; border-spacing: 2px; border-left-style: ridge;">
        <table class="auto-style1">
            <tr>
                <td style="padding: 5px;">
                    <asp:TextBox ID="TextBoxDcoumentId" CssClass="text" Width="350px" Height="25px" runat="server"></asp:TextBox>
                </td>
                <td style="padding: 5px;">
                    <h4>Find</h4>
                </td>
                <td style="padding: 5px;">
                    <asp:ImageButton ID="ImageButton1" runat="server" OnClick="ImageButton1_Click" ImageUrl="~/Images/Click-PNG.png" Width="50px" />
                </td>
                <td style="padding: 5px;">
                    <h5>Save to Database</h5>
                </td>
                <td style="padding: 5px;">
                    <asp:ImageButton ID="ImageButton3" runat="server" OnClick="ImageButton3_Click" ImageUrl="~/Images/database.jpg" Width="50px" />
                </td>
                <td style="padding: 5px;">
                    <h5>Save to PDF</h5>
                </td>
                <td style="padding: 5px;">
                    <asp:ImageButton ID="ImageButton2" runat="server" OnClick="ImageButton2_Click" ImageUrl="~/Images/download.jpg" Width="50px" />
                </td>
            </tr>
        </table>
        <br />
        <div style="float: left; width: 300px; margin-top: 0%;">
            <p>Select file..</p>
            <asp:FileUpload ID="FileUploadResult" runat="server" />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Upload" OnClick="Button1_Click" />
            <br />
            <iframe runat="server" width="350" id="myFrame" style="height: 534px;"></iframe>
        </div>
        <h4>Quotation for Co-location Infomation:</h4>
        <br />
        <div style="width: 400px; padding: 10px 20px 10px 350px;">
            <asp:Panel ID="panelResult" runat="server">
                <asp:ListView ID="ListViewResult" runat="server" GroupPlaceholderID="group" ItemPlaceholderID="itemPlaceHolder">
                    <LayoutTemplate>
                        <table>
                            <tr>
                                <th>
                                    <%--<asp:LinkButton ID="LinkButton1" runat="server" CommandName="Sort" CommandArgument="value">Sort Values..</asp:LinkButton>--%>
                                </th>
                            </tr>
                            <asp:PlaceHolder ID="group" runat="server"></asp:PlaceHolder>
                        </table>
                    </LayoutTemplate>
                    <GroupTemplate>
                        <tr>
                            <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                        </tr>
                    </GroupTemplate>
                    <ItemTemplate>
                        <td class="label">
                            <%# Eval("name") %>
                        </td>
                        <td class="text">
                            <%# Eval("value") %>
                        </td>
                        <%--<aside>
                    <asp:Label ID="LabelText" runat="server" CssClass="label" Text='<%# Eval("name") %>'></asp:Label></aside>
                    <asp:TextBox ID="TextBoxSwifnet" CssClass="text" Width="900px" Height="30px" Text='<%# Eval("value") %>' runat="server"></asp:TextBox>--%>
                    </ItemTemplate>
                </asp:ListView>
            </asp:Panel>
        </div>
    </div>
</asp:Content>

