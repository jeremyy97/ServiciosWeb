<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Tarjetas.aspx.cs" Inherits="B_Cientificas_Cliente.Tarjetas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:Panel ID="Panel2" runat="server">
            <fieldset>
                <legend>Administrar Tarjetas</legend>
                <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
                <!-- Button -->
                <div class="form-group">
                    <label class="col-md-4 control-label" for="buscar"></label>
                    <div class="col-md-4">
                        <asp:Button ID="btnNuevaTarjeta" class="btn btn-primary" runat="server" Text="Agregar una nueva tarjeta" />
                    </div>
                </div>
            </fieldset>
        </asp:Panel>
        <asp:Panel ID="Panel1" class="card" runat="server">
            <fieldset>
                <!-- Form Name -->
                <legend>Administrar Tarjetas</legend>
                    <table>
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
                                        <asp:TextBox ID="txtAutor" runat="server" class="form-control input-md-6"></asp:TextBox>
                                    </div>
                                </div>
                            </td>
                            <td>
                                <label>Año vencimiento:</label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtNivelEducativo" runat="server" class="form-control input-md-6"></asp:TextBox>
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
                                        <asp:TextBox ID="fechaInicio" runat="server" class="form-control input-md-12"></asp:TextBox>
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
                                        <asp:TextBox ID="txtNombreProyecto" runat="server" class="form-control input-md-6"></asp:TextBox>
                                    </div>
                                </div>
                            </td>
                         </tr>
                    </table>
                
                    <!-- Button -->
                    <div class="form-group">
                        <label class="col-md-4 control-label" for="buscar"></label>
                        <div class="col-md-4">
                            <asp:Button ID="btnRegistrarTarjeta" class="btn btn-primary" runat="server" Text="GuardarTarjeta" />
                        </div>
                    </div>

            </fieldset>

        </asp:Panel>
    
    </div>
</asp:Content>
