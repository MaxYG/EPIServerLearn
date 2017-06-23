<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<CodeSamples.EPiServerNET.Web.Mvc.EditSampleViewModel>

    " %>
    <%@ Import Namespace="EPiServer.Web.Mvc.Html" %>

    <%: Html.FullRefreshPropertiesMetaData() %>

    <h1 <%: Html.EditAttributes(m => m.Heading) %>>
    <%: Model.Heading %>
</h1>

    <% if (Model.ShowBanner) { %>
    <div <%: Html.EditAttributes(m => m.BannerUrl) %>>
        <img src="<%: Model.BannerUrl %>" />
    </div>
    <% } %>

    <%: Html.PropertyFor(m => m.Body, new EPiServer.Web.Mvc.EditHint() { ContentDataPropertyName = "MainBody" } ) %>
    <%: Html.PropertyFor(m => m.SecondaryBody) %>

    <%: Html.BeginEditSection("div", p => p.TextBlock) %>>
    <%: Html.Partial("TextBlock", Model.TextBlock )%>
    <%: Html.EndEditSection("div")%>>
