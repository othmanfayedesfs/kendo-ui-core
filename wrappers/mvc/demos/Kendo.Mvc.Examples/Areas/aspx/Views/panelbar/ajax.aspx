<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/aspx/Views/Shared/Web.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="wrapper">
    <%= Html.Kendo().PanelBar()
        .Name("panelbar")
        .ExpandMode(PanelBarExpandMode.Single)
        .Items(panelbar =>
        {
            panelbar.Add().Text("BODY")
                .LoadContentFrom(Url.Content("~/Content/web/panelbar/ajax/ajaxContent1.html"));

            panelbar.Add().Text("ENGINE")
                .LoadContentFrom(Url.Content("~/Content/web/panelbar/ajax/ajaxContent2.html"));

            panelbar.Add().Text("TRANSMISSION")
                .LoadContentFrom(Url.Content("~/Content/web/panelbar/ajax/ajaxContent3.html"));

            panelbar.Add().Text("PERFORMANCE")
                .LoadContentFrom(Url.Content("~/Content/web/panelbar/ajax/ajaxContent4.html"));
        })
    %>
</div>

<style>
    .wrapper {
        height: 320px;
        margin: 20px auto;
        padding: 20px 0 0;
        background: url('<%= Url.Content("~/Content/web/panelbar/astonmartin.png")%>') no-repeat center 50px transparent;
    }
    #panelbar {
        width: 250px;
        float: right;
        margin-bottom: 20px;
    }
    #panelbar p {
        padding: 1em;
    }
</style>

</asp:Content>