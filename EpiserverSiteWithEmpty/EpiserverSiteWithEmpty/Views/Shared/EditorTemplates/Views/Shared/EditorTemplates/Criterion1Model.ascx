<%@ Control Language="C#" 
    Inherits="System.Web.Mvc.ViewUserControl<EpiserverSiteWithEmpty.Views.Shared.EditorTemplates.Criterion1Model>" %>
<%@ Import Namespace="EPiServer.Personalization.VisitorGroups" %>

  <div>
     <span>
         <%= Html.DojoEditorFor(p => p.MyInt) %>
     </span>
     <span>
         <% = Html.DojoEditorFor(p => p.MyString, 
               new {
                     @class = "WidgetCssClass", 
                     @someOtherHtmlAttribute = "value" },
                         "WidgetLabelText",
                         "WidgetLabelCssClass",
                     DojoHtmlExtensions.LabelPosition.Right) %>
          
     </span>
  </div>