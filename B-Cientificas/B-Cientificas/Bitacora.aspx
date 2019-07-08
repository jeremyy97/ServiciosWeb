<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Bitacora.aspx.cs" Inherits="B_Cientificas.Bitacora" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <form class="">
            <fieldset>
                <legend>Bitacora</legend>
            </fieldset>
        </form>
        <form class="card">
            <fieldset>
                <hr class="sidebar-divider" />
                <legend>Consultar acciones en bitacora</legend>
                <label class="col-md-4 control-label" for="usuario"></label>
                <br></br>
                <div>
                    <table align="center">
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">Usuario:</label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="txtUsuario" class="form-control input-md" runat="server"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="fechaInicio">Fecha Inicio:</label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="txtFechaInicio" placeholder="12/31/2018" class="form-control input-md" runat="server"></asp:TextBox>
                                </div>
                            </td>
                            <td align="left">
                                &nbsp;
                                <label class="" for="fechaFinal">Fecha Final:</label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="txtFechaFinal"  placeholder="12/31/2019" class="form-control input-md" runat="server"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="tipo">Tipo:</label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="1">Agregar</asp:ListItem>
                                        <asp:ListItem Value="2">Eliminar</asp:ListItem>
                                        <asp:ListItem Value="3">Modificar</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="4">Todas</asp:ListItem>
                                    </asp:DropDownList>     
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div class="form-group">
                                    <asp:Button ID="btnConsultar"  class="btn btn-primary"  runat="server" Text="Consultar" OnClick="btnConsultar_Click" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </fieldset>
        </form>
        <asp:Panel ID="panelResultados" runat="server" Visible="true">
            <form class="card">
                <table class="table ">
                    <thead class="thead-dark">
                        <tr>
                            <th>Codigo</th>
                            <th>Fecha y hora</th>
                            <th>Descripcion</th>
                            <th>Detalle Registro</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <th>1</th>
                            <td>1/1/2019 11:59</td>
                            <td>Se modificó...</td>
                            <td><a href="#">Ver Detalle</a></td>
                        </tr>
                        <tr>
                            <th>1</th>
                            <td>2/1/2019 11:59</td>
                            <td>Se eliminó...</td>
                            <td><a href="#">Ver Detalle</a></td>
                        </tr>
                        <tr>
                            <th>1</th>
                            <td>3/1/2019 11:59</td>
                            <td>Se agregó...</td>
                            <td><a href="#">Ver Detalle</a></td>
                        </tr>
                    </tbody>
                </table>
            </form>
        </asp:Panel>
    </div>

</asp:Content>
