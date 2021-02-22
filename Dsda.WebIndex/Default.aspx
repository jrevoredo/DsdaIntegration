<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Dsda.WebIndex._Default" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="Content/Site.css" />
</head>
<body>
    <form id="form1" runat="server">
    <dx:ASPxSplitter ID="splRoot" runat="server" AllowResize="False" Orientation="Vertical"
        FullscreenMode="True" SeparatorVisible="False" Height="100%" Width="100%" Theme="PlasticBlue">
        <Styles>
            <Pane>
                <Paddings Padding="0px" />
                <Border BorderWidth="0px" />
            </Pane>
        </Styles>
        <Panes>
            <dx:SplitterPane Name="Header" Size="83px" MinSize="83px">
                <PaneStyle CssClass="headerPane">
                    <BorderBottom BorderWidth="1px" />
                </PaneStyle>
                <ContentCollection>
                    <dx:SplitterContentControl ID="SplitterContentControl1" runat="server">
                        <div class="headerTop">
                            <div class="templateTitle">
                                <a href="~/">DSDA Web Sites</a>
                            </div>
                        </div>
                    </dx:SplitterContentControl>
                </ContentCollection>
            </dx:SplitterPane>
            <dx:SplitterPane Name="Content" MinSize="375px" ScrollBars="Auto">
				<PaneStyle CssClass="mainContentPane">
                    <BorderBottom BorderWidth="1px"></BorderBottom>
                </PaneStyle>
                <ContentCollection>
                    <dx:SplitterContentControl ID="SplitterContentControl3" runat="server" SupportsDisabledAttribute="True">

    <table class="OptionsTable" style="background-color: #F1F1F1; width: 100%;">
      <tr>
            <td style="width: 2.5%;"></td>
            <td style="width: 95%; vertical-align: top;">
                <br /><b>ADP Upload Errors</b>
                <br /><asp:HyperLink ID="hypUploadStatistics" runat="server"></asp:HyperLink>
                <br />
                <br /><b>ADP Upload Statistics</b>
                <br /><asp:HyperLink ID="hypADPUpload" runat="server"></asp:HyperLink>
                <br />
                <br /><b>ADP Upload RO Statistics</b>
                <br /><asp:HyperLink ID="hypADPUploadRO" runat="server"></asp:HyperLink>
                <br />
            </td>
            <td style="width: 2.5%;"></td>
        </tr>
        <tr>
            <td colspan="3">
                <br />
                <br />
            </td>
        </tr>
    </table>

                    </dx:SplitterContentControl>
                </ContentCollection>
                <PaneStyle BackColor="white">
                    <BorderBottom BorderWidth="1px" />
                </PaneStyle>
            </dx:SplitterPane>

        </Panes>
    </dx:ASPxSplitter>
    </form>
</body>
</html>
