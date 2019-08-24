<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="B_Cientificas_Cliente.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:Panel ID="Panel2" runat="server">
            <fieldset>
                <legend>Carrito</legend>
                <asp:GridView ID="gvCarrito" class="table" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="gvCarrito_RowCommand" OnRowDeleting="gvCarrito_RowDeleting">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:ButtonField Text="Quitar del carrito" />
                    </Columns>
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
                <br />
                <asp:Label ID="Label1" runat="server" Text="Total por pagar: "></asp:Label>
                <asp:Label ID="lblmonto" runat="server" Text="0"></asp:Label>
            </fieldset>
        </asp:Panel>
        <asp:Panel ID="Panel1" class="card" runat="server">
            <fieldset>
                <!-- Form Name -->
                <legend>Pagar</legend>
                <table>
                    <tr>
                        <td>
                            <label>Seleccion el metodo de pago:</label>
                        </td>
                        <td>
                            <div class="form-group">
                                <div class="col-md-12">
                                    <asp:DropDownList class="form-control" ID="ddlMetodoPago" runat="server">
                                        <asp:ListItem>Seleccione</asp:ListItem>
                                        <asp:ListItem>Tarjeta Crédito o Débito</asp:ListItem>
                                        <asp:ListItem>Easy Pay</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </td>
                        
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblCaptcha" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <div class="form-group">
                                <div class="col-md-12">
                                    <asp:TextBox ID="txtCaptcha" runat="server" class="form-control input-md-12"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCaptcha" ErrorMessage="Digite el captcha "></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </td>
                        
                    </tr>
                    
                </table>
             
                <!-- Button -->
                <div class="form-group">
                    <label class="col-md-4 control-label" for="buscar"></label>
                    <div class="col-md-4">
                        <asp:Button ID="btnProceder" class="btn btn-primary" runat="server" Text="Proceder con el pago" OnClick="btnProceder_Click" />
                    </div>
                </div>

            </fieldset>

        </asp:Panel>
    
    </div>
</asp:Content>
