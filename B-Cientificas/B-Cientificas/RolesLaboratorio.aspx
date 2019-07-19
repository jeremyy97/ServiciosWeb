<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="RolesLaboratorio.aspx.cs" Inherits="B_Cientificas.RolesLaboratorio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:Panel class="card" ID="Panel2" runat="server"></asp:Panel>
            <fieldset>
                <legend>Roles Laboratorio</legend>
                <label class="col-md-4 control-label" for="usuario">Administracion roles de laboratorio</label>
                <br></br>
                <div>
                    <table align="center">
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">Código: </label>
                            </td>
                            <td>
                                <div class="form-group">
                                     <asp:TextBox ID="txtID" runat="server" class="form-control input-md" ReadOnly="true"></asp:TextBox>
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td align="left">
                                <label class="" for="usuario">Nombre: </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="txtNombre" runat="server" class="form-control input-md"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="rama">Detalle: </label>
                            </td>
                            <td>
                                <div class="form-group">
                                   <asp:TextBox ID="txtDetalle" runat="server" class="form-control input-md" Height="103px" TextMode="MultiLine" Width="194px"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <div class="form-group">
                                    <asp:Button ID="btnActualizar" runat="server"   name="crearUsuario" class="btn btn-primary" Text="Actualizar Registro" OnClick="btnActualizar_Click" />
                                </div>
                            </td>
                            
                            <td>
                                <div class="form-group">
                                    <asp:Button ID="btnLimpiar" runat="server"  name="limpiar" class="btn btn-primary" Text="Limpiar" OnClick="btnLimpiar_Click" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <div class="form-group">
                                    <asp:Button ID="btnEliminar" runat="server"  name="eliminarRegistro" class="btn btn-primary" Text="Eliminar" />
                                </div>
                            </td>
                            <asp:Label ID="lblMensaje" runat="server" Text="Label"></asp:Label>
                        </tr>
                    </table>
                    <br /><br />
                     <asp:GridView class="table" ID="gvRolLaboratorio" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="gvRolLaboratorio_RowCommand">
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
                    <label class="col-md-4 control-label" for="nuevo"></label>
                    <div class="col-md-4">
                        
                        <asp:Button ID="btnNuevo" runat="server" class="btn btn-primary" name="nuevo"  Text="Nuevo" OnClick="btnNuevo_Click" />
                    </div>
                </div>

                </div>
            </fieldset>
    
       <!-- <script src="vendor/jquery/jquery.min.js"></script>
        <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

        <script src="vendor/jquery-easing/jquery.easing.min.js"></script>

        <script src="js/sb-admin-2.min.js"></script>-->

    </div>

</asp:Content>
