<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="BitacoraExperimental.aspx.cs" Inherits="B_Cientificas.BitacoraExperimental" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <form class="card">
            <fieldset>
                <legend>Bitacora Experimental</legend>
                <label class="col-md-4 control-label" for="usuario">Administracion de experimentos</label>
                <br></br>
                <div>
                    <table align="center">
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">Proyecto: </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="ddlProyectos" runat="server">
                                        <asp:ListItem Value="0">Seleccione un Proyecto</asp:ListItem>
                                        <asp:ListItem>Prueba</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td align="left">
                                <label class="" for="usuario">Codigo del proyecto: </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <input
                                        type="text"
                                        placeholder=""
                                        class="form-control"
                                        name="usuario1" disabled/>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">Codigo del experimento: </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <input
                                        type="text"
                                        placeholder=""
                                        class="form-control"
                                        name="usuario1" disabled/>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>Datos del responsable</td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="rama">Nombre del responsable: </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="ddlResponsables" runat="server">
                                        <asp:ListItem Value="0">Seleccione un usuario</asp:ListItem>
                                        <asp:ListItem>Usuario De Prueba</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="" for="rama">Firma del responsable</label>
                            </td>
                            <td>
                                <asp:Image ID="imgFirmaResponsable" runat="server" />
                            </td>
                        </tr>
                         <tr>
                            <td align="left">
                                <label class="" for="usuario">Nombre del experimento: </label>
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
                                <label class="" for="usuario">Fecha: </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:Calendar ID="calendario" runat="server"></asp:Calendar>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">Muestra 1: </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:FileUpload ID="fileupMuestra1" runat="server" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">Muestra 2: </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:FileUpload ID="fileupMuestra2" runat="server" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">Muestra 3: </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:FileUpload ID="fileupMuestra3" runat="server" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">Muestra 4: </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:FileUpload ID="fileupMuestra4" runat="server" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">Muestra 5: </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:FileUpload ID="fileupMuestra5" runat="server" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">Detalle: </label>
                            </td>
                            <td colspan="2"> 
                                <div class="form-group">
                                    <asp:TextBox ID="txtDetalle" TextMode="MultiLine" runat="server" Height="198px" Width="403px"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">Firma del testigo: </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="ddlTestigos" runat="server">
                                        <asp:ListItem Value="0">Seleccione un usuario</asp:ListItem>
                                        <asp:ListItem>Usuario De Prueba</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">Nombre del testigo: </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server">
                                        <asp:ListItem Value="0">Seleccione un usuario</asp:ListItem>
                                        <asp:ListItem>Usuario De Prueba</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">Firma del testigo: </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:Image ID="Image1" runat="server" />
                                </div>
                            </td>
                        </tr>
                            <td></td>
                            <td>
                                <div class="form-group">
                                    <button id="crearUsuario"  name="crearUsuario" class="btn btn-primary">Guardar Experimento</button>
                                </div>
                            </td>
                            
                            <td>
                                <div class="form-group">
                                    <button id="limpiar" name="limpiar" class="btn btn-primary">Limpiar</button>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <div class="card">
                        <div class="form-group">
                            <button id="ActualizarTabla" name="ActualizarTabla" class="btn btn-primary">Actualizar Tabla</button>
                        </div>
                        <table class="table">
                            <thead class="thead-dark">
                                <tr>
                                    <th>Codigo</th>
                                    <th>Proyecto</th>
                                    <th>Nombre</th>
                                    <th>Responsable</th>
                                    <th>Testigo</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>1</td>
                                    <td>Proyecto de Prueba</td>
                                    <td>Experimento de Prueba</td>
                                    <td>Usuario de Prueba</td>
                                    <td>Otro Usuario</td>
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

    </div>
</asp:Content>
