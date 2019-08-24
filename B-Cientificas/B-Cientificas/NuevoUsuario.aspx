<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Menu.Master" CodeBehind="NuevoUsuario.aspx.cs" Inherits="B_Cientificas.NuevoUsuario" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">


        <asp:Panel class="card"  ID="Panel2" runat="server">
            <fieldset runat="server">
                <hr class="sidebar-divider" />
                <legend>Crear Usuario</legend>
                <label class="col-md-4 control-label" for="usuario"></label>
                <br>
                <br>
                <br>
                <br>
                <br>
                <br></br>
                <div>
                    <table align="center">
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">
                                Código:
                                </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="txtCodigo" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">
                                Nombre:
                                </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="txtNombre" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre" ErrorMessage="Campo requrido" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">
                                Primer apellido:
                                </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="txtPrimerApellido" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPrimerApellido" ErrorMessage="Campo requrido" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">
                                Segundo Apellido:
                                </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="txtSegundoApellido" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">
                                Telefono Celular:
                                </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="txtCelular" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="nombreUsuario">
                                Nombre de usuario:
                                </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="txtNombreUsuario" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNombreUsuario" ErrorMessage="Campo requrido" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="contrasenna">
                                Contraseña:
                                </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="txtPassword" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPassword" ErrorMessage="Campo requrido" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="contrasenna">
                                Confirmar Contraseña:
                                </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="txtConfirmarPassword" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="email">
                                Firma:</label> </td>
                            <td>
                                <div class="form-group">
                                    <asp:FileUpload ID="fileupFirma" runat="server" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="preguntaSeguridad">
                                Foto:
                                </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:FileUpload ID="fileupFoto" runat="server" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="" for="respuestaSeguridad">
                                Nivel academico:
                                </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlNivelesAcademicos" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="" for="respuestaSeguridad">
                                Puesto:
                                </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlPuestos" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <div class="form-group">
                                    <asp:Button ID="btnActualizar" runat="server" class="btn btn-primary" OnClick="btnActualizar_Click" Text="Crear" />
                                </div>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:Button ID="btnLimpiar" runat="server" class="btn btn-primary" OnClick="btnLimpiar_Click" Text="Cancelar" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <br />
                                <div class="form-group">
                                    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                                </div>
                            </td>
                            <td></td>
                        </tr>
                    </table>
                </div>
                <br>
                <br>
                <br>
                <br>
                <br></br>
                <br>
                <br>
                <br></br>
                <br>
                <br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                        
     
            </fieldset>
        </asp:Panel>


    </div>

</asp:Content>

