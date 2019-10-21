<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebForm.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>NewExperts BV</h3>
    <address>
        Haerstraat 125<br />
        7573 PA Oldenzaal<br />
        <abbr title="Phone">P:</abbr>
        +31 (0)88 - 584 889 2 
    </address>

    <address>
        <strong>Development:</strong>   <a href="mailto:brouwer@newexperts.nl">Bart-Jan Brouwer</a><br />
        <strong>Director:</strong> <a href="mailto:engelbertink@newexperts.nl">Floris Engelbertink</a>
    </address>
</asp:Content>
