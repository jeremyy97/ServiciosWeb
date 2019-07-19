<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Puestos.aspx.cs" Inherits="B_Cientificas.Puestos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form class="card">
            <fieldset>
                <legend>Puestos</legend>
                <label class="col-md-4 control-label" for="usuario">Administracion de puestos</label>
                <br></br>
                <div>
                    <table align="center">
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">Código: </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="txtCodigo" runat="server"></asp:TextBox>
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td align="left">
                                <label class="" for="usuario">Nombre: </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="txtNombre" runat="server"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="rama">Rol: </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:DropDownList  CssClass="form-control" ID="ddlRoles" runat="server">
                                        <asp:ListItem Value="0">Seleccione un rol</asp:ListItem>
                                        <asp:ListItem>Rol de prueba</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <div class="form-group">
                                    <asp:Button class="btn btn-primary" ID="btnCrearUsuario" runat="server" Text="Crear Usuario" />
                                </div>
                            </td>
                            
                            <td>
                                <div class="form-group">
                                    <asp:Button class="btn btn-primary" ID="btnLimpiar" runat="server" Text="Limpiar" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <div class="form-group">
                                    <asp:Button class="btn btn-primary" ID="btnEliminarRegistro" runat="server" Text="Eliminar Registro" />
                                </div>
                            </td>
                        </tr>
                    </table>
                    <div class="card">
                        <div class="form-group">
                            <asp:Button class="btn btn-primary" ID="btnActualizar" runat="server" Text="Actualizar Tabla" />
                        </div>
                        <asp:GridView ID="gvPuestos" runat="server"></asp:GridView>
                        <table class="table">
                            <thead class="thead-dark">
                                <tr>
                                    <th>Codigo</th>
                                    <th>Nombre</th>
                                    <th>Rol</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>1</td>
                                    <td>Puesto 1</td>
                                    <td>Algun rol</td>
                                </tr>
                                <tr>
                                    <td>2</td>
                                    <td>Puesto 2</td>
                                    <td>Otro rol</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </fieldset>
        </form>
        <script src="vendor/jquery/jquery.min.js"></script>
        <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

        <script src="vendor/jquery-easing/jquery.easing.min.js"></script>

        <script src="js/sb-admin-2.min.js"></script>
</asp:Content>
