﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/aspx/Views/Shared/Web.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
    
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="demo-section k-content">
    <ul class="fieldlist">
        <li>
            <%: Html.Label("textbox") %>
            <%: Html.Kendo().TextBox().Name("textbox").HtmlAttributes(new { style = "width: 100%;" }) %>
        </li>
        <li>
            <%: Html.Label("textarea") %>
            <%: Html.TextArea("textarea", "", new { @class="k-textbox", style = "width: 100%;" }) %>
        </li>
        <li>
            <%: Html.Label("Input with icon left") %>
            <span class="k-textbox k-space-left" style="width:100%;">
                <%: Html.Kendo().TextBox().Name("textboxIconLeft") %>
                <a href="#" class="k-icon k-i-search">&nbsp;</a>
            </span>
        </li>
        <li>
            <%: Html.Label("Input with icon right") %>
            <span class="k-textbox k-space-right" style="width:100%;">
                 <%: Html.Kendo().TextBox().Name("textboxIconRight") %>
                <a href="#" class="k-icon k-i-search">&nbsp;</a>
            </span>
        </li>
        <li>
            <h4>Buttons</h4>
            <%: Html.Kendo().Button().Name("Default").Content("Default").HtmlAttributes(new { @class="k-button" }) %>
            <%: Html.Kendo().Button().Name("Primary").Content("Primary").HtmlAttributes(new { @class="k-button k-primary" }) %>
        </li>
        <li>
            <h4>Link as Button</h4>
            <a href="http://www.google.com" class="k-button">google.com</a>
        </li>
    </ul>
</div>

<style>
   .fieldlist {
        margin: 0 0 -2em;
        padding: 0;
    }

    .fieldlist li {
        list-style: none;
        padding-bottom: 2em;
    }

    .fieldlist label {
        display: block;
        padding-bottom: 1em;
        font-weight: bold;
        text-transform: uppercase;
        font-size: 12px;
        color: #444;
    }
</style>
</asp:Content>