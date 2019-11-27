<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateSitSchedule.aspx.cs" Inherits="CreateSitSchedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <style type="text/css">
        .word {
            font-size: 30px;
            font-style: normal;
            font-family: Corbel;
            color: black;
            text-align: center;
            font: bold;
        }

        .text {
            width: auto;
            height: 30px;
            border-radius: 4px;
        }

        .modal {
            position: fixed;
            top: 0;
            left: 0;
            background-color: black;
            z-index: 99;
            opacity: 0.8;
            filter: alpha(opacity=80);
            -moz-opacity: 0.8;
            min-height: 100%;
            width: 100%;
        }

        .loading {
            font-family: Arial;
            font-size: 10pt;
            width: 500px;
            height: 30px;
            display: none;
            position: fixed;
            z-index: 999;
        }
    </style>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/blitzer/jquery-ui.css"
        rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        function ShowProgress() {
            setTimeout(function () {
                var modal = $('<div />');
                modal.addClass("modal");
                $('body').append(modal);
                var loading = $(".loading");
                loading.show();
                var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
                var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
                loading.css({ top: top, left: left });
            }, 200);
        }
        $('form').live("submit", function () {
            ShowProgress();
        });

        $(function () {
            $("[id*Button1]").removeAttr("onclick");
            $("#dialog").dialog({
                modal: true,
                autoOpen: false,
                title: "Confirmation",
                width: 450,
                height: 200,
                buttons: [
                    {
                        id: "Yes",
                        text: "Yes",
                        click: function () {
                            $("[id*=Button1]").attr("rel", "delete");
                            $("[id*=Button1]").click();
                        }
                    },
                    {
                        id: "No",
                        text: "No",
                        click: function () {
                            $(this).dialog('close');
                        }
                    }
                ]
            });
            $("[id*=Button1]").click(function () {
                if ($(this).attr("rel") != "delete") {
                    $('#dialog').dialog('open');
                    return false;
                } else {
                    __doPostBack(this.name, '');
                }
            });
        });


    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div style="margin-left: 2px; background-color: #ededed; border-style: ridge; border-radius: 8px; border-color: white; border-width: 12px; border-spacing: 2px; border-left-style: ridge;">
        <br />
        <br />
        <table>
            <tr>
                <td style="padding: 5px;">Create Template
                </td>
                <td style="padding: 5px;">
                    <asp:ImageButton ID="ImageButton1" OnClick="ImageButton1_Click" runat="server" ImageAlign="AbsBottom" ImageUrl="~/Images/temp.jpg" Width="40px" />
                    <div id="dialog" style="display: none" align="center">
                        Do you
                    </div>
                </td>
                <td style="padding: 5px;">Refresh 
                </td>
                <td style="padding: 5px;">
                    <asp:ImageButton ID="ImageButton2" OnClick="ImageButton2_Click" runat="server" ImageAlign="AbsBottom" ImageUrl="~/Images/refresh.png" Width="40px" />
                </td>
                <td style="padding: 5px;">Convert
                </td>
                <td>
                    <asp:ImageButton ID="ImageButton3" OnClick="ImageButton3_Click" runat="server" ImageAlign="AbsBottom" ImageUrl="~/Images/images.jpg" Width="40px" />
                </td>
            </tr>
        </table>
        <br />
        <div>
            <p style="font-size: medium;">Document Id:<asp:TextBox CssClass="text" ID="TextBoxDcoumentId" runat="server" Width="300px" Height="25px"></asp:TextBox></p>
            &nbsp&nbsp&nbsp
        </div>

        <div>
            <%--<iframe src="https://docs.google.com/gview?url=http://remote.url.tld/path/to/MyFile.doc&embedded=true"></iframe>--%>
        </div>
        <div>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
        <div class="loading" align="center">
            <img src="Images/straight-loader.gif" alt="" style="border: none; background-color: transparent;" width="350" height="20" />
            <br />
        </div>
        <div style="margin-left: 2%; margin-top: 3%;">
            <div style="width: 100%;">
                <table style="border: thin solid #C0C0C0; background-color: #3399FF">
                    <tr>
                        <td style="width: 55px">Index<br />
                        </td>
                        <td style="width: 200px">Processing Time<br />
                        </td>
                        <td style="width: 200px">Date & Time<br />
                        </td>
                        <td style="width: 250px">Document ID</td>
                    </tr>
                </table>
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>

                        <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick"></asp:Timer>


                        <asp:DataList ID="DataList1" runat="server" BorderStyle="Solid" OnItemDataBound="DataList1_ItemDataBound" OnItemCreated="DataList1_ItemCreated">
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td style="width: 50px">
                                            <%# DataBinder.Eval(Container.DataItem,"Indx") %>
                                        </td>
                                        <td style="width: 200px">
                                            <%# DataBinder.Eval(Container.DataItem,"processedAt") %>
                                        </td>
                                        <td style="width: 200px">
                                            <%# DataBinder.Eval(Container.DataItem,"timeZone") %>
                                        </td>
                                        <td style="width: 250px">
                                            <%# DataBinder.Eval(Container.DataItem, "documentId") %>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <br />
        <br />
    </div>
    <div>
        <br />
        <h4>Document Infomation</h4>
        <table>
            <tr>
                <td>

                </td>
            </tr>
            <tr>

            </tr>
        </table>
    </div>
</asp:Content>

