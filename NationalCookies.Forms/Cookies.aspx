<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cookies.aspx.cs" Inherits="NationalCookies.Forms.Cookies" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Check out the awesome assortment of cookies:</h2>

    <% for (int i = 0; i < Model.Count; i++)
        { %>

    <% if (i == 0)
        { %>

    <div class="row">


        <% } %>
        <div class="col-md-2">
            <p>
                <strong><%= Model[i].Name %></strong>
            </p>
            <p>
                <img src="<%=Model[i].ImageUrl %>" alt="<%= Model[i].Name %>" width="110" height="110" />
            </p>
            <p>
                € <%= Model[i].Price.ToString(System.Globalization.CultureInfo.CurrentCulture) %> / piece
            </p>
            <p>
                <a href="Cookies.aspx?CookieId=<%= Model[i].Id %>">Add to order</a>
            </p>
        </div>



        <% if (i % 2 == 0 && i > 0)
            { %>
    </div>
    <div class="row">
        <% }
            } %>
    </div>
</asp:Content>
