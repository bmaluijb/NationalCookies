<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderDetails.aspx.cs" Inherits="NationalCookies.Forms.OrderDetails" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<% if (Model == null){%>

    <h2>No order was found.</h2>
<%} else { %>

    <h2>Details for order with Id <%= Model.Id%></h2>

    <fieldset>
        <legend>Order</legend>
        Date: <%=Model.Date.LocalDateTime.ToString("d")%> <br />
        Total Price: € <%=Model.Price.ToString(System.Globalization.CultureInfo.CurrentCulture)%> <br />
        Status: <%=Model.Status%> <br />
        <%if (Model.Status == "New")
            { %>
            <a href="Orders.aspx?action=PlaceOrder&id=<%=Model.Id%>">Place order</a><br />
        <%} %>


        <a href="Orders.aspx?action=CancelOrder&id=<%=Model.Id%>">Cancel order</a>

    </fieldset>

    <h3>Order lines:</h3>
    <table>
        <tr>
            <td>Cookie name</td>
            <td># cookies</td>
        </tr>
        <% foreach (var line in Model.OrderLines)
                                        { %>
            <tr>
                <td><%= line.Cookie.Name%></td>
                <td><%=line.Quantity%></td>
            </tr>
        <%} %>

    </table>
<%} %>

    </asp:Content>
