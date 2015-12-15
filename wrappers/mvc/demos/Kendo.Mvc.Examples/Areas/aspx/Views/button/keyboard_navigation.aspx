﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/aspx/Views/Shared/Web.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

<div class="box">
    <div class="box-col">
        <h4>Focus</h4>
        <ul class="keyboard-legend">
            <li>
                <span class="button-preview">
                    <span class="key-button leftAlign">Alt</span>
                    +
                    <span class="key-button">W</span>
                </span>
                <span class="button-descr">
                    Focuses the first button (clicking on it or tabbing will also work).
                </span>
            </li>
        </ul>
    </div>
    <div class="box-col">
        <h4>Supported keys and user actions</h4>
        <ul class="keyboard-legend">
            <li>
                <span class="button-preview">
                    <span class="key-button">Enter</span> or <span class="key-button">Space</span>
                </span>
                <span class="button-descr">
                    Trigger click event.
                </span>
            </li>
        </ul>
    </div>
</div>

<div class="demo-section k-content">                
    <h4>Buttons</h4>
<%= Html.Kendo().Button()
    .Name("textButton")
    .Content("Text button")
    .HtmlAttributes( new {type = "button"} )
    .Events(ev => ev.Click("onClick")) %>

<%= Html.Kendo().Button()
    .Name("iconTextButton")
    .Tag("span")
    .Icon("ungroup")
    .Content("Icon and text")
    .Events(ev => ev.Click("onClick")) %>

<%= Html.Kendo().Button()
    .Name("iconButton")
    .Tag("em")
    .Icon("refresh")
    .Content("<span class='k-icon'>Refresh</span>")
    .Events(ev => ev.Click("onClick")) %>

<%= Html.Kendo().Button()
    .Name("disabledButton")
    .Tag("a")
    .Enable(false)
    .Content("Disabled button")
    .Events(ev => ev.Click("onClick")) %>

</div>

<div class="box">                
    <h4>Console log</h4>
    <div class="console"></div>
</div>

<script>
    function onClick(e) {
        kendoConsole.log("event :: click (" + $(e.event.target).closest(".k-button").attr("id") + ")");
    }

    $(document.body).keydown(function (e) {
        if (e.altKey && e.keyCode == 87) {
            $("#textButton")[0].focus();
        }
    });

</script>

<style>
    .demo-section {
        line-height: 4em;
    }

    .demo-section .k-button {
        margin-right: 10px;
    }
</style>

</asp:Content>