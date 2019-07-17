<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Consecutivos.aspx.cs" Inherits="B_Cientificas.Consecutivos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        void Check_Clicked(Object sender, EventArgs e) 
      {

         // Calculate the subtotal and display the result in currency format.
         // Include tax if the check box is selected.
         Message.Text = CalculateTotal(checkbox1.Checked).ToString("c");

      }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <form class="card">
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
                                    <asp:TextBox  class="form-control input-md"  ID="txtDescripcion" runat="server" ReadOnly="true" ></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="consecutivo">Consecutivo:</label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox class="form-control input-md" ID="txtConsecutivo" runat="server"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="prefijoCheck">Posee prefijo:</label>
                            </td>
                            <td align="left">
                                <div class="form-group">
                                    <asp:CheckBox  ID="chkBoxPrefijo" class="checkbox-inline" runat="server" Text="Sí" OnCheckedChanged="chkBoxPrefijo_CheckedChanged" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="prefijo">Prefijo:</label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="txtPrefijo" class="form-control input-md" runat="server"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="rangoCheck">Posee Rango:</label>
                            </td>
                            <td align="left">
                                <div class="form-group">
                                    <asp:CheckBox class="checkbox-inline" Text="Si" ID="chkBoxRango" runat="server" OnCheckedChanged="chkBoxRango_CheckedChanged" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="rangoInicial">Rango Inicial:</label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox class="form-control input-md" ID="txtInicio" runat="server"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="rangoFinal">Rango Final:</label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox class="form-control input-md" ID="txtFinal" runat="server"></asp:TextBox>
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
