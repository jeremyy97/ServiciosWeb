<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Pagar.aspx.cs" Inherits="B_Cientificas_Cliente.Pagar" %>
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
        <asp:Panel ID="tarjetas" class="card" runat="server">
            <fieldset>
                <!-- Form Name -->
                <legend>Pagar con tarjeta crédito/débito registrada</legend>
                <table>
                    <tr>
                        <td>
                            <label>Seleccion su tarjeta:</label>
                        </td>
                        <td>
                            <div class="form-group">
                                <div class="col-md-12">
                                    <asp:DropDownList ID="ddlTarjetas" runat="server">
                                        <asp:ListItem>Tarjeta Crédito o Débito</asp:ListItem>
                                        <asp:ListItem>Easy Pay</asp:ListItem>

                                    </asp:DropDownList>
                                </div>
                            </div>
                        </td>
                    </tr>        
                </table>
            </fieldset>
        </asp:Panel>
    
        <asp:Panel ID="easyPay" class="card" runat="server">
            <fieldset>
                <!-- Form Name -->
                <legend>Pagar con EasyPay</legend>
                <table>
                    <tr>
                        <td>
                            <label>Numero de cuenta: </label>
                        </td>
                        <td colspan="2">
                            <div class="form-group">
                                <div class="col-md-12">
                                    <asp:TextBox ID="txtNumCuenta" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </td>
                        
                    </tr>
                    <tr>
                        <td>
                            <label>Código Seguridad:</label>
                        </td>
                        <td>
                            <div class="form-group">
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtCodSeguridad" runat="server" class="form-control input-md-6"></asp:TextBox>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>Contraseña</label>
                        </td>
                        <td colspan="2">
                            <div class="form-group">
                                <div class="col-md-12">
                                    <asp:TextBox ID="txtContrasenna" runat="server" class="form-control input-md-12" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </asp:Panel>

        <!-- Button -->
        <div class="form-group">
            <label class="col-md-4 control-label" for="buscar"></label>
            <div class="col-md-4">
                <asp:Button ID="btnPagar" class="btn btn-primary" runat="server" Text="Pagar" />
            </div>
        </div>
    </div>
</asp:Content>
