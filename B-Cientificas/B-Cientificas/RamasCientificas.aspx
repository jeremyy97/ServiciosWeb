<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="RamasCientificas.aspx.cs" Inherits="B_Cientificas.RamasCientificas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <form class="card">
            <fieldset>
                <legend>Ramas Cientificas</legend>
                <label class="col-md-4 control-label" for="usuario">Administracion de ramas cientificas</label>
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
                            <td></td>
                            <td>
                                <div class="form-group">
                                    <button id="crearUsuario"  name="crearUsuario" class="btn btn-primary">Guardar Registro</button>
                                </div>
                            </td>
                            
                            <td>
                                <div class="form-group">
                                    <button id="limpiar" name="limpiar" class="btn btn-primary">Limpiar</button>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <div class="form-group">
                                    <button id="eliminarRegistro" name="eliminarRegistro" class="btn btn-primary">Eliminar Registro</button>
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
                                    <th>Nombre</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>1</td>
                                    <td>Rama de Prueba</td>
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
