<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="NuevaTarjeta.aspx.cs" Inherits="B_Cientificas_Cliente.NuevaTarjeta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
       
        <asp:Panel ID="Panel1" class="card" runat="server">
            <fieldset>
                <!-- Form Name -->
                <legend>Crear Tarjeta<br />
                    <asp:Label ID="txtMensaje" runat="server"></asp:Label>
                </legend>
                    <table>
    
                        <tr>
                            <td>
                                <label>Numero de tarjeta: </label>
                            </td>
                            <td colspan="2">
                                <div class="form-group">
                                    <div class="col-md-12">
                                        <asp:TextBox ID="txtNumeroTarjeta" runat="server" class="form-control" MaxLength="16" OnTextChanged="txtNumeroTarjeta_TextChanged" TextMode="Number" AutoPostBack="True"></asp:TextBox>
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
                                        <asp:CheckBox ID="chkBoxDebito" runat="server" AutoPostBack="True" class="checkbox-inline" Text="Sí" />
                                    </div>
                                </div>
                            </td>
                         </tr>
                    </table>
                
                    <!-- Button -->
                    <div class="form-group">
                        <label class="col-md-4 control-label" for="buscar"></label>
                        <div class="col-md-4">
                            <asp:Button ID="btnCrear" class="btn btn-primary" runat="server" Text="Crear Tarjeta" OnClick="btnActualizar_Click" />
                            <asp:Button ID="btnCancelar" class="btn btn-primary" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                        </div>
                    </div>

            </fieldset>

        </asp:Panel>
   
    </div>
</asp:Content>
