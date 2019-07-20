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
                                    <asp:TextBox  class="form-control" ID="txtCodigo" runat="server"></asp:TextBox>
                                 </div>
                            </td>
                        </tr>

                        <tr>
                            <td align="left">
                                <label class="" for="usuario">Nombre: </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox  class="form-control" ID="txtNombre" runat="server"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <div class="form-group">
                                    <asp:Button class="btn btn-primary" ID="btnGuardar" runat="server" Text="Guardar Registro" OnClick="btnGuardar_Click" />
                                </div>
                            </td>
                            
                            <td>
                                <div class="form-group">
                                    <asp:Button class="btn btn-primary" ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
                                    
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <div class="form-group">
                                    <asp:Button ID="btnEliminarRegistro" class="btn btn-primary" runat="server" Text="Eliminar Registro" OnClick="btnEliminarRegistro_Click" />
                                    <br />
                                    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <div class="card">
                        <div class="form-group">
                            <asp:Button  class="btn btn-primary" ID="btnActualizarTabla" runat="server" Text="Actualizar Tabla" OnClick="btnActualizarTabla_Click" />
                       </div>
                        <asp:GridView class="table" ID="gvRamasCientificas" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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
            </fieldset>
        </form>
        <script src="vendor/jquery/jquery.min.js"></script>
        <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

        <script src="vendor/jquery-easing/jquery.easing.min.js"></script>

        <script src="js/sb-admin-2.min.js"></script>

    </div>
</asp:Content>
