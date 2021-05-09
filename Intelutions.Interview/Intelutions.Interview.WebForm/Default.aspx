<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Intelutions.Interview.WebForm._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron text-center">
        <h1>Test Intelutions</h1>
        <p class="lead">Aplicación Web para registrar solicitudes de permisos para la empresa X.</p>
        <p><a href="About" class="btn btn-primary btn-lg">Acerca de &raquo;</a></p>
    </div>

    <div class="row">
        <div class="panel panel-primary">
          <div class="panel-heading">
            <h1 class="panel-title">Listado de permisos</h1>
          </div>
          <div class="panel-body">
            <a href="Permission" class="btn btn-primary">Agregar permiso</a>
            <br />
            <br />
            <asp:GridView ID="GridViewPermissions" runat="server" AutoGenerateColumns="false" 
                AllowPaging="true" PageSize="10" Width="100%" 
                CssClass="table table-responsive table-hover" BorderStyle="Groove" 
                OnPageIndexChanging="GridViewPermissions_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="PermissionID" HeaderText="ID" Visible="false" />
                    <asp:BoundField DataField="EmployeeFirstName" HeaderText="Nombre" />
                    <asp:BoundField DataField="EmployeeFamilyName" HeaderText="Apellidos" />
                    <asp:BoundField DataField="PermissionType" HeaderText="Tipo de permiso" />
                    <asp:BoundField DataField="PermissionDate" HeaderText="Fecha del permiso" DataFormatString="{0:dd-MM-yyyy}" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" CommandArgument='<%# Eval("PermissionID") %>' 
                                OnCommand="Edit_Click" CssClass="btn default btn-xs purple" 
                                Text="<i aria-hidden='true' class='glyphicon glyphicon-edit'></i">
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" CommandArgument='<%# Eval("PermissionID") %>' 
                                OnClientClick="if(!confirm('¿Estas segur@ de eliminar el permiso?')) return false;"
                                OnCommand="Delete_Click" CssClass="btn default btn-xs purple" 
                                Text="<i aria-hidden='true' class='glyphicon glyphicon-trash'></i">
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
          </div>
        </div>

    </div>
</asp:Content>
