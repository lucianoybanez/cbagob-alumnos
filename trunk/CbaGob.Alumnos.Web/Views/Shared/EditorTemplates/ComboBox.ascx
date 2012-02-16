<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<CbaGob.Alumnos.Servicio.Vistas.Shared.ComboBox>" %>
<%= Html.DropDownList("Selected",new SelectList(Model.Combo, "id", "description", Model.Selected))%>    

