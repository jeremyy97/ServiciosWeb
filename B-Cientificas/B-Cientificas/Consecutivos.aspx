<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Consecutivos.aspx.cs" Inherits="B_Cientificas.Consecutivos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <form class="card">
            <fieldset>
                <legend>Lista de consecutivos</legend>
                <asp:GridView class="table" ID="gvConsecutivos" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:ButtonField Text="Editar" />
                    </Columns>
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
                <table id="idTable" class="table">
                    <thead class="thead-dark">
                        <tr>
                            <th>Codigo</th>
                            <th>Descripcion</th>
                            <th>Consecutivo</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>1</td>
                            <td>Proyectos</td>
                            <td>1</td>
                            <td><a href="InformacionConsecutivo.aspx">Editar</a></td>
                        </tr>
                        <tr>
                            <td>2</td>
                            <td>Bitácora Experimental</td>
                            <td>2</td>
                            <td><a href="InformacionConsecutivo.aspx">Editar</a></td>
                        </tr>
                        <tr>
                            <td>3</td>
                            <td>Roles</td>
                            <td>5</td>
                            <td><a href="InformacionConsecutivo.aspx">Editar</a></td>
                        </tr>
                    </tbody>
                </table>
                <div class="form-group">
                    <label class="col-md-4 control-label" for="nuevo"></label>
                    <div class="col-md-4">
                        <button id="nuevo" name="nuevo" class="btn btn-primary" onclick="{this.mostrarNuevoConsecutivo}">Nuevo</button>
                    </div>
                </div>
            </fieldset>
        </form>
        <form class="card">
            <fieldset>
                <hr class="sidebar-divider" />
                <legend>Editar Consecutivo</legend>
                <label class="col-md-4 control-label" for="usuario"></label>
                <br></br>
                <div>
                    <table align="center">
                        <tr>
                            <td align="left">
                                <label class="" for="selectDescripcion">Descripción</label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlDescripcion" class="form-control" runat="server">
                                        <asp:ListItem Value="1">Proyectos</asp:ListItem>
                                        <asp:ListItem Value="2">Bitácora Experimental</asp:ListItem>
                                        <asp:ListItem Value="3">Roles</asp:ListItem>
                                        <asp:ListItem Value="4">Ramas Científicas</asp:ListItem>
                                        <asp:ListItem Value="5">Puestos</asp:ListItem>
                                        <asp:ListItem Value="6">Nivel Académico</asp:ListItem>
                                        <asp:ListItem Value="7">Bitácora</asp:ListItem>
                                        <asp:ListItem Value="8">Errores</asp:ListItem>
                                        <asp:ListItem Value="9">Usuarios</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="consecutivo">Consecutivo:</label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <input id="consecutivo" name="consecutivo1"  type="text" placeholder="" class="form-control input-md" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="prefijoCheck">Posee prefijo:</label>
                            </td>
                            <td align="left">
                                <div class="form-group">
                                    <label class="checkbox-inline" for="prefijoCheck-0">
                                        <input type="checkbox" name="prefijoCheck" value="1" />
                                        Sí
                                    </label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="prefijo">Prefijo:</label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <input id="prefijo"  name="prefijo" type="text"  placeholder="" class="form-control input-md" disabled="true"/>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="rangoCheck">Posee Rango:</label>
                            </td>
                            <td align="left">
                                <div class="form-group">
                                    <label class="checkbox-inline" for="rangoCheck-0">
                                        <input type="checkbox" name="rangoCheck" id="rangoCheck-0" value="false" />
                                        Sí
                                    </label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="rangoInicial">Rango Inicial:</label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <input id="rangoInicial" name="rango_inicial" type="text"  placeholder="" class="form-control input-md"/>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="rangoFinal">Rango Final:</label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <input id="rangoFinal"  name="rango_final" type="text" placeholder="" class="form-control input-md" disabled="true" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div class="form-group">
                                    <asp:Button id="aceptar" name="aceptar" class="btn btn-primary"  runat="server" Text="Actualizar Consecutivo" />
                                    <asp:Button id="cancelar" name="cancelar" class="btn btn-default" runat="server" Text="Cancelar" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </fieldset>
        </form>
    </div>

</asp:Content>
