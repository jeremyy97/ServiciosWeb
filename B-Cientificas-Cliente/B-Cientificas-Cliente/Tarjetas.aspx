<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Tarjetas.aspx.cs" Inherits="B_Cientificas_Cliente.Tarjetas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
       
        <asp:Panel ID="Panel1" class="card" runat="server">
            <fieldset>
                <!-- Form Name -->
                <legend>Actualizar Tarjetas</legend>
                    <table>
                        <tr>
                            <td>
                                <label>ID: </label>
                            </td>
                            <td colspan="2">
                                <div class="form-group">
                                    <div class="col-md-12">
                                        <asp:TextBox ID="txtId" runat="server" class="form-control" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                            </td>
                        
                        </tr>
                        <tr>
                            <td>
                                <label>Numero de tarjeta: </label>
                            </td>
                            <td colspan="2">
                                <div class="form-group">
                                    <div class="col-md-12">
                                        <asp:TextBox ID="txtNumeroTarjeta" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </td>
                        
                        </tr>
                        <tr>
                            <td>
                                <label>Mes vencimiento:</label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtMes" runat="server" class="form-control input-md-6"></asp:TextBox>
                                    </div>
                                </div>
                            </td>
                            <td>
                                <label>Año vencimiento:</label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtAnno" runat="server" class="form-control input-md-6"></asp:TextBox>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Nombre en la tarjeta:</label>
                            </td>
                            <td colspan="2">
                                <div class="form-group">
                                    <div class="col-md-12">
                                        <asp:TextBox ID="txtNombre" runat="server" class="form-control input-md-12"></asp:TextBox>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>CVV:</label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtCVV" runat="server" class="form-control input-md-6"></asp:TextBox>
                                    </div>
                                </div>
                            </td>
                         </tr>
                    </table>
                
                    <!-- Button -->
                    <div class="form-group">
                        <label class="col-md-4 control-label" for="buscar"></label>
                        <div class="col-md-4">
                            <asp:Button ID="btnActualizar" class="btn btn-primary" runat="server" Text="Actualizar Tarjeta" OnClick="btnActualizar_Click" />
                            <asp:Button ID="btnEliminar" class="btn btn-primary" runat="server" Text="Eliminar Tarjeta" OnClick="btnEliminar_Click" />
                        </div>
                    </div>

            </fieldset>

        </asp:Panel>

         <asp:Panel ID="Panel2" runat="server">
            <fieldset>
                <legend>Listado Tarjetas</legend>
                <asp:GridView class="table" ID="gvTarjetas" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false" OnRowCommand="gvTarjetas_RowCommand">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:ButtonField Text="Editar" />
                        <asp:BoundField DataField="TarjetaCredito_Id" HeaderText="ID" SortExpression="TarjetaCredito_Id" />
                        <asp:BoundField DataField="NumeroTarjeta" HeaderText="Numero Tarjeta" SortExpression="NumeroTarjeta" />
                        <asp:BoundField DataField="NombreTarjeta" HeaderText="Nombre Tarjeta" SortExpression="NombreTarjeta" />
                        <asp:BoundField DataField="MesVencimiento" HeaderText="Mes Vencimiento" SortExpression="MesVencimiento" />
                        <asp:BoundField DataField="AnnoVencimiento" HeaderText="Año Vencimiento" SortExpression="AnnoVencimiento" />

                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#0067c6" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB"  />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#24526b" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
                <!-- Button -->
                <div class="form-group">
                    <label class="col-md-4 control-label" for="buscar"></label>
                    <div class="col-md-4">
                        <asp:Button ID="btnNuevaTarjeta" class="btn btn-primary" runat="server" Text="Agregar una nueva tarjeta" OnClick="btnNuevaTarjeta_Click" />
                    </div>
                </div>
            </fieldset>
        </asp:Panel>
    
    </div>
</asp:Content>
