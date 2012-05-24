<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<CbaGob.Alumnos.Servicio.Vistas.Shared.ComboBox>" %>
<% if (Model.Enabled){ %>
       <%=Html.DropDownList("Selected", new SelectList(Model.Combo, "id", "description", Model.Selected)) %>
   <%}else
   {%>
       <%=Html.DropDownList("Selected", new SelectList(Model.Combo, "id", "description", Model.Selected), new { disabled = "disabled" })%>
   <%} %>
    

