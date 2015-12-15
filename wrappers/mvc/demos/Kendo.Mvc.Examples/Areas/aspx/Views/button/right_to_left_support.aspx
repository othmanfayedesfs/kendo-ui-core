﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/aspx/Views/Shared/Web.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

<div class="demo-section k-rtl k-content">
    <h4>Basic Button</h4>
    <p>
<%= Html.Kendo().Button()
    .Name("textButton")
    .HtmlAttributes( new {type = "button"} )
    .Content("Submit") %>
    </p>
    
    <h4>Buttons with icons</h4>
    <p>
<%= Html.Kendo().Button()
    .Name("iconTextButton")
    .Tag("a")
    .Icon("funnel")
    .Content("Filter") %>

<%= Html.Kendo().Button()
    .Name("iconButton")
    .Tag("em")
    .Icon("refresh")
    .Content("<span class='k-icon'>Refresh</span>") %>
    </p>
    
    <h4>Disabled Button</h4>
    <p>
<%= Html.Kendo().Button()
    .Name("disabledButton")
    .Tag("span")
    .Enable(false)
    .Content("Disabled") %>

    </p>
</div>

<style>
    .demo-section p {
        margin: 0 0 30px;
        line-height: 4em;
    }
    .demo-section .k-button {
        margin-left: 10px;
    }
    #textButton, #disabledButton {
        width: 150px;
    }
</style>

</asp:Content>