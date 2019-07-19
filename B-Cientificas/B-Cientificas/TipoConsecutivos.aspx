<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Menu.Master" CodeBehind="TipoConsecutivos.aspx.cs" Inherits="B_Cientificas.TipoConsecutivos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
         <asp:Panel class="card" ID="Panel2" runat="server"></asp:Panel>
            <fieldset>
                <legend>Lista de Tipos de Consecutivos</legend>
                <asp:GridView class="table" ID="gvTiposConsecutivos" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="gvTiposConsecutivos_RowCommand">
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
            </fieldset>
          <asp:Panel class="card"  ID="Panel1" runat="server">
            <fieldset runat="server">
                <hr class="sidebar-divider" />
                <legend>Editar Tipo Consecutivo</legend>
                <br>
                <br>
                </br>
                <div>
                    <table runat="server" align="center">
                        <tr>
                            <td align="left">
                                <label class="" for="selectDescripcion">
                                ID:</label> </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="txtID" runat="server" class="form-control input-md" ReadOnly="true"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="prefijo">
                                Nombre:</label> </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="txtNombre" runat="server" class="form-control input-md"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div class="form-group">
                                    <asp:Button ID="btnActualizar" runat="server" class="btn btn-primary" name="aceptar" OnClick="btnActualizar_Click" Text="Actualizar " />
                                    <asp:Button ID="cancelar" runat="server" class="btn btn-default" name="cancelar" Text="Cancelar" />
                                    <br />
                                    <br />
                                    <asp:Label ID="lblMensaje" runat="server" Text="Label"></asp:Label>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <br></br>
                </br>   
            </fieldset>
        </asp:Panel>

    </div>
</asp:Content>
