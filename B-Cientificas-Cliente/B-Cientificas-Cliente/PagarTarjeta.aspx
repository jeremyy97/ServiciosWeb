<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="PagarTarjeta.aspx.cs" Inherits="B_Cientificas_Cliente.PagarTarjeta" %>
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
               
                    <asp:GridView class="table" ID="gvTarjetas" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false" OnRowCommand="gvTarjetas_RowCommand">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:ButtonField Text="Seleccionar" />
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



          
            </fieldset>
        </asp:Panel>

        <!-- Button -->
        <div class="form-group">
            <label class="col-md-4 control-label" for="buscar"></label>
            <div class="col-md-4">
                <asp:Button ID="btnNueva" class="btn btn-primary" runat="server" Text="Nueva Tarjeta" OnClick="btnPagar_Click" />
            </div>
        </div>
      
    </div>
</asp:Content>
