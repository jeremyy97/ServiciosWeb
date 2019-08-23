<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="PagarTarjetaSeleccionada.aspx.cs" Inherits="B_Cientificas_Cliente.PagarTarjetaSeleccionada" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:Panel ID="Panel2" runat="server">
            <fieldset>
                <legend>
                    <asp:Label ID="Label3" runat="server" Text="Total por pagar: "></asp:Label>
                    <asp:Label ID="lblMonto" runat="server" Text="0"></asp:Label>
                </legend>
            </fieldset>
        </asp:Panel>

       
        <asp:Panel ID="Panel1" class="card" runat="server">
            <fieldset>
                <!-- Form Name -->
                <legend>Pago con Tarjeta<br />
                   
                </legend>
                    <table>
    
                        <tr>
                            <td>
                                <label>Numero de tarjeta: </label>
                            </td>
                            <td colspan="2">
                                <div class="form-group">
                                    <div class="col-md-12">
                                        <asp:TextBox ID="txtNumeroTarjeta" runat="server" class="form-control" MaxLength="16"  ReadOnly="True"></asp:TextBox>
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
                                        <asp:TextBox ID="txtMes" runat="server" class="form-control input-md-6" MaxLength="2" TextMode="Number"></asp:TextBox>
                                    </div>
                                </div>
                            </td>
                            <td>
                                <label>Año vencimiento:</label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtAnno" runat="server" class="form-control input-md-6" MaxLength="4" TextMode="Number"></asp:TextBox>
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
                                        <asp:TextBox ID="txtNombre" runat="server" class="form-control input-md-12" ReadOnly="True"></asp:TextBox>
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
                                        <asp:TextBox ID="txtCVV" runat="server" class="form-control input-md-6" MaxLength="4" TextMode="Number"></asp:TextBox>
                                    </div>
                                </div>
                            </td>
                         </tr>
                         <tr>
                            <td>
                                <label>Tipo Tarjeta:</label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtTipoTarjeta" runat="server" class="form-control input-md-6" ReadOnly="True" Width="135px">Sin Seleccionar</asp:TextBox>
                                    </div>
                                </div>
                            </td>
                         </tr>
                         <tr>
                            <td>
                                <label>Débito:</label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <div class="col-md-6">
                                        <asp:CheckBox ID="chkBoxDebito" runat="server" AutoPostBack="True" class="checkbox-inline" Text="Sí" Enabled="False" />
                                    </div>
                                </div>
                            </td>
                         </tr>
                    </table>
                
                    <!-- Button -->
                     <div class="form-group">
            <label class="col-md-4 control-label" for="buscar"></label>
            <div class="col-md-4">
                <asp:Button ID="btnPagar" class="btn btn-primary" runat="server" Text="Pagar" OnClick="btnPagar_Click" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-md-4 control-label" for="buscar"></label>
            <div class="col-md-4">
                <asp:Label ID="lblResultado" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="Red"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:Button ID="btnDescargar" class="btn btn-primary" runat="server" Text="Descargar" OnClick="btnDescargar_Click" />
            </div>
        </div>

            </fieldset>

        </asp:Panel>
   
    </div>
</asp:Content>
