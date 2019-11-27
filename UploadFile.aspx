<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UploadFile.aspx.cs" MaintainScrollPositionOnPostBack="true" Inherits="UploadFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .designTable {
            margin-left: 10px;
        }

        .mydatagrid {
            width: 20%;
            border: solid 2px black;
            min-width: 20%;
        }

        .header {
            background-color: #000;
            font-family: Arial;
            color: white;
            text-align: center;
            font-size: 16px;
        }

        .mydatagrid a {
            background-color: transparent;
            padding: 5px 5px 5px 5px;
            color: #fff;
            text-decoration: none;
            font-weight: bold;
        }

            .mydatagrid a:hover {
                background-color: #000;
                color: #fff;
            }

        .mydatagrid span {
            background-color: #fff;
            color: #000;
            padding: 5px 5px 5px 5px;
        }

        .pager {
            background-color: #5badff;
            font-family: Arial;
            color: white;
            height: 30px;
            text-align: left;
        }

        .mydatagrid td {
            padding: 1px;
        }

        .mydatagrid th {
            padding: 10px;
        }

        .buttonInsert {
            border-radius: 5px;
            border: none;
            padding: 1rem 2rem;
            margin: 0;
            text-decoration: none;
            background: #0069ed;
            color: #ffffff;
            font-family: sans-serif;
            font-size: 1rem;
            line-height: 1;
            cursor: pointer;
            text-align: center;
            transition: background 250ms ease-in-out, transform 150ms ease;
            -webkit-appearance: none;
            -moz-appearance: none;
        }

        .mydatagrid {
            width: 50%;
            border: solid 2px black;
            min-width: 50%;
        }

        .header {
            background-color: #000;
            font-family: Arial;
            color: white;
            text-align: center;
            font-size: 16px;
        }

        .rows {
            background-color: #fff;
            font-family: Arial;
            font-size: 12px;
            color: #000;
            min-height: 15px;
            width: 50%;
        }

            .rows:hover {
                background-color: #f24e4e;
            }

        .mydatagrid a {
            background-color: transparent;
            padding: 5px 5px 5px 5px;
            color: #fff;
            text-decoration: none;
            font-weight: bold;
        }

            .mydatagrid a:hover {
                background-color: #000;
                color: #fff;
            }

        .mydatagrid span {
            background-color: #fff;
            color: #000;
            padding: 5px 5px 5px 5px;
        }

        .word {
            font-size: 30px;
            font-style: normal;
            font-family: Corbel;
            color: black;
            text-align: center;
            font: bold;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
    <div style="margin-left: 1%;">
        <div style="float: left; width: 50%;">
            <asp:FileUpload ID="FileUpload" runat="server" Width="300px" />
            <br />
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/upload.png" OnClick="ImageButton1_Click" Width="48px" />
            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/refresh.png" OnClick="ImageButton2_Click" Width="48px" />
            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/display.png" OnClick="ImageButton3_Click" Width="48px" />

            <div style="margin-left: 0px">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="Add To Docparser" Visible="true" OnClick="Button1_Click" />
            </div>
            <asp:Label ID="lblComms" runat="server" Text="Label"></asp:Label><br />
            <table style="border: thin solid #C0C0C0; background-color: #3399FF">
                <tr>
                    <td style="width: 200px">Upload File</td>
                    <td style="width: 100px">FK Index </td>
                    <td style="width: 100px">OCR </td>
                    <td style="width: 100px">OCR<br />
                        Complete</td>
                    <td style="width: 100px">Processing<br />
                        complete</td>
                    <td style="width: auto;"></td>
                </tr>
            </table>
            <asp:DataList ID="dlStatus" runat="server" OnItemCommand="dlStatus_ItemCommand" OnSelectedIndexChanged="dlStatus_SelectedIndexChanged" BorderStyle="Solid">
                <ItemTemplate>
                    <table>
                        <tr>
                            <td style="width: 200px"><%# DataBinder.Eval(Container.DataItem, "FileName") %></td>
                            <td style="width: 100px">
                                <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"FK_Indx") %>'></asp:Label>
                            </td>
                            <td style="width: 100px">
                                <%--<asp:CheckBox ID="chkProcessing" runat="server" Checked='<%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem,"OCR_Processing")) %>' Enabled="false" />--%>
                            </td>
                            <td style="width: 100px">
                                <%--<asp:CheckBox ID="chkComplete" runat="server" Checked='<%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem,"OCR_Complete")) %>' Enabled="false" />--%>
                            </td>
                            <td style="width: 100px">
                                <%--<asp:CheckBox ID="chkProcessed" runat="server" Checked='<%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "Processed")) %>' Enabled="False" />--%>
                            </td>
                            <td>
                                <td style="width: auto;">                  
                                    <asp:ImageButton ID="btnView" runat="server" CommandName="Viewdoc" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"FK_Indx") %>' ImageUrl="~/Images/search.jpg" Width="20px" />
                                </td>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
            <br />
            <br />
        </div>
        <div style="float: right; width: 35%;">
            <div style="float: right; margin-top: 21%;">
                <iframe id="IframeDoc" runat="server" style="height: 500px; width: 450px;"></iframe>
            </div>
        </div>
    </div>
</asp:Content>

