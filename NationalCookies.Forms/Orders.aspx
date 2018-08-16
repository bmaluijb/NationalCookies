<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="NationalCookies.Forms.Orders" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Here are your orders:</h2>

    <table>
        <tr>
            <td>Order date</td>
            <td># order lines</td>
            <td>Total price</td>
            <td>Status</td>
            <td></td>
            <td></td>

        </tr>
        <% foreach (var order in Model) { %>
    
            <td><%= order.Date.ToLocalTime().ToString("d")%></td>
            <td><%= order.OrderLines.Count%></td>
            <td>€ <%=order.Price.ToString(System.Globalization.CultureInfo.CurrentCulture)%></td>
            <td><%=order.Status%></td>
            <td><a href="OrderDetails.aspx?id=<%=order.Id%>">Details</a></td>

            <td><a href="Orders.aspx?action=CancelOrder&id=<%=order.Id%>">Cancel order</a></td>
           <%if (order.Status == "New") { %>
            
                <td><a href="Orders.aspx?action=PlaceOrder&id=<%=order.Id%>">Place order</a></td>
           <% } %>
        </tr>
        <% } %>

    </table>
</asp:Content>
