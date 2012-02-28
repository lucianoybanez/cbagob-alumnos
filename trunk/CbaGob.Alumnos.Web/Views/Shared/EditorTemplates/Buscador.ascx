<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<CbaGob.Alumnos.Servicio.Vistas.Shared.Buscador>" %>
<input type="text" id='<%= Model.Name + "txt" %>' value='<%= Model.Valor %>'  style="width: 300px" /> <input type="button" id='<%= Model.Name + "btn" %>' value="Buscar" class="btnIngresar" onclick="cbaAlumnosGlobal.Buscar('<%= Model.Name %>' ,'<%= Model.Tipo %>', $('#' + '<%= Model.Name + "txt" %>').val(), $('#' + '<%= Model.Relacionado + "txt" %>').val());" />

<div id='<%= Model.Name + "Div" %>' title='<%=Model.Tipo %>'>
    <table class="TablaPersonal" id='<%= Model.Name + "table" %>'>
    </table>
</div>
