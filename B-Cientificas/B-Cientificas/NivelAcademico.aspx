<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="NivelAcademico.aspx.cs" Inherits="B_Cientificas.NivelAcademico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form class="card">
            <fieldset>
                <legend>Nivel academico</legend>
                <label class="col-md-4 control-label" for="usuario">Administracion de niveles academicos</label>
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
                                <label class="" for="usuario">Nivel Académico: </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:DropDownList  CssClass="form-control" ID="ddlRoles" runat="server">
                                        <asp:ListItem>Educación Secundaria</asp:ListItem>
                                        <asp:ListItem>Diplomado</asp:ListItem>
                                        <asp:ListItem>Profesorado</asp:ListItem>
                                        <asp:ListItem>Técnico</asp:ListItem>
                                        <asp:ListItem>Bachiller Universitario</asp:ListItem>
                                        <asp:ListItem>Licenciatura</asp:ListItem>
                                        <asp:ListItem>Especialidad</asp:ListItem>
                                        <asp:ListItem>Maestría</asp:ListItem>
                                        <asp:ListItem>Doctorado</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="rama">Detalle: </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="txtDetalle" runat="server"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <div class="form-group">
                                    <asp:Button  class="btn btn-primary" ID="btnGuardar Registro" runat="server" Text="Button" />
                                </div>
                            </td>
                            
                            <td>
                                <div class="form-group">
                                    <asp:Button  class="btn btn-primary" ID="btnLimpiar" runat="server" Text="Limpiar" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <div class="form-group">
                                    <asp:Button  class="btn btn-primary" ID="btnEliminarRegistro" runat="server" Text="Eliminar Registro" />
                                </div>
                            </td>
                        </tr>
                    </table>
                    <div class="card">
                        <div class="form-group">
                            <asp:Button  class="btn btn-primary" ID="btnActualizar" runat="server" Text="Actualizar Tabla" />
                        </div>
                        <asp:GridView ID="gvNivelAcademico" runat="server"></asp:GridView>
                        <table class="table">
                            <thead class="thead-dark">
                                <tr>
                                    <th>Codigo</th>
                                    <th>Nivel academico</th>
                                    <th>Detalle</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>1</td>
                                    <td>Bachillerato</td>
                                    <td>Ingenieria en Sistemas</td>
                                </tr>
                                <tr>
                                    <td>2</td>
                                    <td>Maestria</td>
                                    <td>Administracion de proyectos</td>
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

        <script src="js/sb-admin-2.min.js"></script>b 
</asp:Content>
