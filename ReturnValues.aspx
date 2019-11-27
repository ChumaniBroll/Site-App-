<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReturnValues.aspx.cs" Inherits="ReturnValues" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:TextBox ID="TextBox1" Width="300px" runat="server"></asp:TextBox><asp:Button ID="ButtonSearch" runat="server" OnClick="ButtonSearch_Click" Text="Find" />

    <asp:ListView ID="ListView1" runat="server">
        <ItemTemplate>
            <br />
            <br />
            <table>
                <tr>
                    <td>
                       <b><%#Eval("ColName") %></b> 
                    </td>
                </tr>
                <tr>
                    <td>
                        <%#Eval("ColValue") %>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:ListView>


</asp:Content>

