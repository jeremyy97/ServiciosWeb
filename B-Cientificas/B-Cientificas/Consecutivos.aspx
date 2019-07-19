<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Consecutivos.aspx.cs" Inherits="B_Cientificas.Consecutivos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click1" />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" />
        <asp:Panel class="card" ID="Panel2" runat="server"></asp:Panel>
            <fieldset>
                <legend>Lista de consecutivos</legend>
                <asp:GridView class="table" ID="gvConsecutivos" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="gvConsecutivos_RowCommand">
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
        <asp:Panel class="card"  ID="Panel1" runat="server">
            <fieldset runat="server">
                <hr class="sidebar-divider" />
                <legend>Editar Consecutivo</legend>
                <label class="col-md-4 control-label" for="usuario"></label>
                <br>
                <br></br>
                <div>
                    <table runat="server" align="center">
                        <tr>
                            <td align="left">
                                <label class="" for="selectDescripcion">
                                Descripción</label> </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="txtDescripcion" runat="server" class="form-control input-md" ReadOnly="true"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="consecutivo">
                                Consecutivo:</label> </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="txtConsecutivo" runat="server" class="form-control input-md"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="prefijoCheck">
                                Posee prefijo:</label> </td>
                            <td align="left">
                                <div class="form-group">
                                    <asp:CheckBox ID="chkBoxPrefijo" runat="server" AutoPostBack="True" class="checkbox-inline" OnCheckedChanged="chkBoxPrefijo_CheckedChanged" OnLoad="chkBoxPrefijo_Load" Text="Sí" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="prefijo">
                                Prefijo:</label> </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="txtPrefijo" runat="server" class="form-control input-md"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="rangoCheck">
                                Posee Rango:</label> </td>
                            <td align="left">
                                <div class="form-group">
                                    <asp:CheckBox ID="chkBoxRango" runat="server" AutoPostBack="True" class="checkbox-inline" OnCheckedChanged="chkBoxRango_CheckedChanged" Text="Si" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="rangoInicial">
                                Rango Inicial:</label> </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="txtInicio" runat="server" class="form-control input-md"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="rangoFinal">
                                Rango Final:</label> </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="txtFinal" runat="server" class="form-control input-md"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div class="form-group">
                                    <asp:Button ID="aceptar" runat="server" class="btn btn-primary" name="aceptar" OnClick="aceptar_Click" Text="Actualizar Consecutivo" />
                                    <asp:Button ID="cancelar" runat="server" class="btn btn-default" name="cancelar" Text="Cancelar" />
                                    <br />
                                    <asp:Label ID="lblMensaje" runat="server" Text="Label"></asp:Label>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                </br>   
            </fieldset>
        </asp:Panel>
    </div>

</asp:Content>
