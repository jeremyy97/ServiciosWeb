<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Puestos.aspx.cs" Inherits="B_Cientificas.Puestos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
            <fieldset>
                <legend>Puestos</legend>
                <label class="col-md-4 control-label" for="usuario">Administracion de puestos</label>
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
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre" ErrorMessage="Campo requrido" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="rama">Rol: </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:DropDownList  CssClass="form-control" ID="ddlRoles" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <div class="form-group">
                                    <asp:Button class="btn btn-primary" ID="btnActualizar" runat="server" Text="Actualizar Puesto" OnClick="btnActualizar_Click" />
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
                                    <asp:Button class="btn btn-primary" ID="btnEliminar" runat="server" Text="Eliminar Puesto" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                
                            </td>
                            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                        </tr>
                    </table>
                    
                     <br /><br />
                     <asp:GridView class="table" ID="gvPuestos" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="gvPuestos_RowCommand">
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

        </div>

</asp:Content>
