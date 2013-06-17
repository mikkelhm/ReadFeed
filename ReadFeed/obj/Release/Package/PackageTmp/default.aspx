<%@ Page Language="C#" Async="true"  AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="ReadFeed._default" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <!-- Bootstrap -->
    <link href="/css/style.min.css" rel="stylesheet" media="screen">
</head>
<body>
    <h1>Read Feed</h1>
    <form id="form1" runat="server">
        <div><asp:Label runat="server" ID="lblElapsedTime"></asp:Label></div>
            <asp:Repeater runat="server" ID="rptFeedEntries">
        <HeaderTemplate>
            <div>
        </HeaderTemplate>
        <ItemTemplate>
            <div style="padding:5px;border-bottom:1px solid #ccc" class='feed_<%# Eval("FeedID") %>'>
                <div onclick="jQuery('#description_<%# Container.ItemIndex %>').toggle();" style="overflow:hidden;cursor:pointer;">
                    <div style="font-size:10px;padding:0 0 5px;">
                        <%# Eval("FeedName") %> <%# Eval("Published") %>
                    </div>
                    <div style="font-size:12px;font-weight:bold;">
                        <%# Eval("Title") %> [<a href='<%#Eval("Url") %>' target="_blank">Source</a>]
                    </div>
                </div>
                <div style="display:none;" id="description_<%# Container.ItemIndex %>"><%# Eval("Description") %></div>
            </div>
        </ItemTemplate>
        <FooterTemplate>
            </div>
        </FooterTemplate>
    </asp:Repeater>

    </form>
    <script src="http://code.jquery.com/jquery.js"></script>
    <script src="/js/main.min.js"></script>
</body>
</html>
