<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="CrearUsuarios.aspx.cs" Inherits="B_Cientificas.CrearUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:Panel ID="Panel1" class="card" runat="server">
            <fieldset>
                <legend>Usuarios</legend>
                <label class="col-md-4 control-label" for="usuario">Actualizar cuentas </label>
                <br>
                <br>
                <br>
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
                            <td align="left" colspan="2">
                                <asp:CheckBox ID="chkBoxCambiarContrasenna" runat="server" Text=" Cambiar contraseña" AutoPostBack="True" OnCheckedChanged="chkBoxCambiarContrasenna_CheckedChanged" />
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
                                    <br />
                                    <br />
                                    <asp:Image ID="imgFirma" runat="server" Height="200px" ImageAlign="Middle" Width="200px" />
                                    <br />
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
                                    <br />
                                    <br />
                                    <asp:Image ID="imgFoto" runat="server" Height="200px" ImageAlign="Middle" Width="200px" />
                                    <br />
                                    <br />
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
                                
                            </td>
                            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div class="form-group">
                                    <asp:Button ID="btnActualizar" runat="server" class="btn btn-primary" OnClick="btnActualizar_Click" Text="Actualizar Usuario" />
                                    <br />
                                    <br />
                                </div>
                                <div class="form-group">
                                    <asp:Button ID="btnLimpiar" runat="server" class="btn btn-primary" OnClick="btnLimpiar_Click" Text="Limpiar" />
                                    <br />
                                    <br />
                                </div>
                            </td>
                        </tr>
                    </table>
                    <asp:GridView  ID="gvUsuarios" runat="server" CellPadding="4" class="table" ForeColor="#333333" GridLines="None" OnRowCommand="gvUsuarios_RowCommand">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:ButtonField Text="Editar" />
                        </Columns>
                        <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#0067c6" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#E3EAEB" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                        <SortedAscendingHeaderStyle BackColor="#24526b" />
                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                    </asp:GridView>
                    <div class="form-group">
                        <label class="col-md-4 control-label" for="nuevo">
                        </label>
                        <div class="col-md-4">
                            <asp:Button ID="btnNuevo" runat="server" class="btn btn-primary" name="nuevo" OnClick="btnNuevo_Click" Text="Nuevo" />
                        </div>
                    </div>
                </div>
                <br>
                <br>
                <br>
                <br></br>
                <br>
                <br>
                <br></br>
                <br>
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
                      
            </fieldset>
       </asp:Panel>

    </div>

</asp:Content>
