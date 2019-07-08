<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="CrearUsuarios.aspx.cs" Inherits="B_Cientificas.CrearUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <form class="card">
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
                                    <input
                                        type="text"
                                        placeholder=""
                                        class="form-control"
                                        name="id" disabled/>
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td align="left">
                                <label class="" for="usuario">Nombre: </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <input
                                        type="text"
                                        placeholder=""
                                        class="form-control"
                                        name="usuario1"/>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">Primer apellido: </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <input
                                        type="text"
                                        placeholder=""
                                        class="form-control"
                                        name="nombre"/>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">Segundo Apellido: </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <input
                                        type="text"
                                        placeholder=""
                                        class="form-control"
                                        name="primer_apellido" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">Telefono Celular: </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <input
                                        type="text"
                                        placeholder=""
                                        class="form-control"
                                        name="segundo_apellido" />
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
                                    <input
                                        type="text"
                                        placeholder=""
                                        class="form-control"
                                        name="nombreUsuario" />
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
                                    <input
                                        type="password"
                                        placeholder=""
                                        class="form-control"
                                        name="contrasenna" disabled/>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="contrasenna">Confirmar Contraseña: </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <input
                                        type="password"
                                        placeholder=""
                                        class="form-control"
                                        name="contrasenna" disabled />
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
                                    <input
                                        type="text"
                                        placeholder=""
                                        class="form-control"
                                        name="respuesta" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="" for="respuestaSeguridad">Puesto: </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <input
                                        type="text"
                                        placeholder=""
                                        class="form-control"
                                        name="respuesta" />
                                </div>
                            </td>
                        </tr>
                        
                            <tr>
                                <td colspan="2">
                                    <div class="form-group">
                                        <button id="crearUsuario" name="crearUsuario" class="btn btn-primary" onclick="{this.controlarSubmit}">Crear Usuario</button>
                                    </div>
                                </td>
                            </tr>
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
        </form>
        <script src="vendor/jquery/jquery.min.js"></script>
        <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

        <script src="vendor/jquery-easing/jquery.easing.min.js"></script>

        <script src="js/sb-admin-2.min.js"></script>

    </div>

</asp:Content>
