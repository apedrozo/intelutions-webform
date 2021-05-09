<%@ Page Title="Permission" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Permission.aspx.cs" Inherits="Intelutions.Interview.WebForm.Permission" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" class="form-vertical">
    <div class="section content-title-group">
        <h2>Editar permiso</h2>
    </div>

    <div class="container well">
        <div class="form-group">
            <asp:Label ID="lblFirstName" runat="server" Text="Nombre" CssClass="control-label"></asp:Label>
                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="txtFirstNameRequired" CssClass="text-danger" ControlToValidate="txtFirstName" runat="server" ErrorMessage="El nombre es requerido"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Label ID="lblFamilyName" runat="server" Text="Apellidos" CssClass="control-label"></asp:Label>
            <asp:TextBox ID="txtFamilyName" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="txtFamilyNameRequired" CssClass="text-danger" ControlToValidate="txtFamilyName" runat="server" ErrorMessage="Los apellidos son requeridos"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Label ID="lblPermissionType" runat="server" Text="Tipo de permiso" CssClass="control-label"></asp:Label>
            <asp:DropDownList ID="drpPermissionType" runat="server" CssClass="form-control"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="drpPermissionTypeRequired" CssClass="text-danger" ControlToValidate="drpPermissionType" runat="server" ErrorMessage="El tipo de permiso es requerido"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Label ID="lblPermissionDate" runat="server" Text="Fecha del permiso" CssClass="control-label"></asp:Label>
            <asp:TextBox ID="txtPermissionDate" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="txtPermissionDateRequired" CssClass="text-danger" ControlToValidate="txtPermissionDate" runat="server" ErrorMessage="La fecha del permiso es requerida"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Button ID="btnSave" runat="server" Text="Guardar" CssClass="form-control btn btn-primary" OnClick="btnSave_Click" />
        </div>
    </div>
    
    <script type="text/javascript">
        $(function () {
            $('[id*=txtPermissionDate]').datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd-mm-yyyy",
                language: "tr"
            });
        });
    </script>
</asp:Content>
