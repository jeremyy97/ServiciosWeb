<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Proyectos.aspx.cs" Inherits="B_Cientificas.Proyectos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:Panel ID="Panel1" class="card" runat="server">
            <fieldset>
                <legend>Proyectos</legend>
                <label class="col-md-4 control-label" for="usuario">Administracion de proyectos</label>
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
                                    <asp:TextBox ID="txtCodigo" runat="server" class="form-control" MaxLength="10"></asp:TextBox>
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
                                    <asp:TextBox ID="txtNombre" runat="server" class="form-control" MaxLength="50"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="rama">
                                Rama cientifica:
                                </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlRamas" runat="server" class="form-control">
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">
                                Precio:
                                </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="txtPrecio" runat="server" class="form-control" MaxLength="20"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">
                                Idioma:
                                </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="txtIdioma" runat="server" class="form-control" MaxLength="20"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <div class="form-group">
                                    <asp:Button ID="btnGuardar" runat="server" class="btn btn-primary" OnClick="btnGuardar_Click" Text="Guardar Registro" />
                                </div>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:Button ID="btnLimpiar" runat="server" class="btn btn-primary" OnClick="btnLimpiar_Click" Text="Limpiar" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <div class="form-group">
                                    <asp:Button ID="btnEliminarRegistro" runat="server" class="btn btn-primary" OnClick="btnEliminarRegistro_Click" Text="Eliminar Registro" />
                                    <br />
                                    <asp:Label ID="lblMensaje" runat="server" Text="Label"></asp:Label>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <div class="card">
                        <div class="form-group">
                            <asp:Button ID="btnActualizar" runat="server" class="btn btn-primary" OnClick="btnActualizar_Click" Text="Actualizar Tabla" />
                        </div>
                        <asp:GridView ID="gvProyectos" runat="server" CellPadding="4" class="table" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#7C6F57" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#E3EAEB" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F8FAFA" />
                            <SortedAscendingHeaderStyle BackColor="#246B61" />
                            <SortedDescendingCellStyle BackColor="#D4DFE1" />
                            <SortedDescendingHeaderStyle BackColor="#15524A" />
                        </asp:GridView>
                    </div>
                </div>
                <br></br>
                </br>
                </br>
            </fieldset>
        </asp:Panel>
        <script src="vendor/jquery/jquery.min.js"></script>
        <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

        <script src="vendor/jquery-easing/jquery.easing.min.js"></script>

        <script src="js/sb-admin-2.min.js"></script>

    </div>
</asp:Content>
