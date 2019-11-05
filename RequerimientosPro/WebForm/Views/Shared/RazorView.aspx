<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" 
    Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="RazorContent" ContentPlaceHolderID="MainContent" 
    runat="server">

  <% Html.RenderPartial((String)ViewBag.ViewName); %>

</asp:Content>
