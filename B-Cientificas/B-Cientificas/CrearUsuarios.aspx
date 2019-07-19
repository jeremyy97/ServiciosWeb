<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="CrearUsuarios.aspx.cs" Inherits="B_Cientificas.CrearUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:Panel ID="Panel1" class="card" runat="server">
            <fieldset>
                <legend>Usuarios</legend>
                <label class="col-md-4 control-label" for="usuario">Crear nueva cuenta </label>
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
                                <label class="" for="usuario">Primer apellido: </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="txtPrimerApellido" runat="server"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">Segundo Apellido: </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="txtSegundoApellido" runat="server"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">Telefono Celular: </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="txtCelular" runat="server"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="" for="respuestaSeguridad">Rol: </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlRoles" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="1">Administrador</asp:ListItem>
                                        <asp:ListItem Value="2">Seguridad</asp:ListItem>
                                        <asp:ListItem Value="3">Consecutivo</asp:ListItem>
                                        <asp:ListItem Value="4">Mantenimiento</asp:ListItem>
                                        <asp:ListItem Value="5">Consulta</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        
                        <tr>
                            <td align="left">
                                <label class="" for="nombreUsuario">Nombre de usuario: </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="txtNombreUsuario" runat="server"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="left">
                                <asp:CheckBox ID="chkBoxCambiarContrasenna" Text=" Cambiar contraseña" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="contrasenna">Contraseña: </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="txtPassword" runat="server"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="contrasenna">Confirmar Contraseña: </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="txtConfirmarPassword" runat="server"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="email">Firma:</label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:FileUpload ID="fileupFirma" runat="server" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="preguntaSeguridad">Foto: </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:FileUpload ID="fileupFoto" runat="server" />
                                </div>
                            </td>
                        </tr>
                        
                        <tr>
                            <td>
                                <label class="" for="respuestaSeguridad">Nivel academico: </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="ddlNivelesAcademicos" runat="server"></asp:DropDownList>                                        
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="" for="respuestaSeguridad">Puesto: </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="ddlPuestos" runat="server"></asp:DropDownList>                                        
                                </div>
                            </td>
                        </tr>
                        
                            <tr>
                                <td colspan="2">
                                    <div class="form-group">
                                        <asp:Button ID="btnCrearUsuario" class="btn btn-primary" runat="server" Text="Crear Usuario" />
                                    </div>
                                </td>
                            </tr>
                        <asp:GridView ID="gvUsuarios" runat="server"></asp:GridView>
                    </table>
                    <table class="table">
                        <thead class="thead-dark">
                            <tr>
                                <th>Codigo</th>
                                <th>Nombre</th>
                                <th>Primer apellido</th>
                                <th>Segundo apellido</th>
                                <th>Telefono</th>
                                <th>Nickname</th>
                                <th>Rol</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>1</td>
                                <td>Usuario</td>
                                <td>De</td>
                                <td>Prueba</td>
                                <td>1234-5678</td>
                                <td>usuario</td>
                                <td>Administrador</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </fieldset>
       </asp:Panel>
        <script src="vendor/jquery/jquery.min.js"></script>
        <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

        <script src="vendor/jquery-easing/jquery.easing.min.js"></script>

        <script src="js/sb-admin-2.min.js"></script>

    </div>

</asp:Content>
