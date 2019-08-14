<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Proyectos.aspx.cs" Inherits="B_Cientificas_Cliente.Proyectos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:Panel ID="Panel1" class="card" runat="server">
            <fieldset>

                <!-- Form Name -->
                <legend>Buscar Proyectos</legend>

                <table>
                    <tr>
                        <td>
                            <label>Rama Científica:</label>
                        </td>
                        <td>
                            <div class="form-group">
                                <div class="col-md-12">
                                    <asp:DropDownList ID="ddlRamas" runat="server" class="form-control"></asp:DropDownList>
                                </div>
                            </div>
                        </td>
                        <td>
                            <label>Precio: </label>
                        </td>
                        <td>
                            <div class="form-group">
                                <div class="col-md-12">
                                    <asp:TextBox ID="txtPrecio" runat="server" class="form-control input-md-12"></asp:TextBox>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>Autor:</label>
                        </td>
                        <td>
                            <div class="form-group">
                                <div class="col-md-12">
                                    <asp:TextBox ID="txtAutor" runat="server" class="form-control input-md-12"></asp:TextBox>
                                </div>
                            </div>
                        </td>
                        <td>
                            <label>Nivel Educativo:</label>
                        </td>
                        <td>
                            <div class="form-group">
                                <div class="col-md-12">
                                    <asp:TextBox ID="txtNivelEducativo" runat="server" class="form-control input-md-12"></asp:TextBox>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>Fecha Inicio Creación:</label>
                        </td>
                        <td>
                            <div class="form-group">
                                <div class="col-md-12">
                                    <asp:TextBox ID="fechaInicio" runat="server" class="form-control input-md-12"></asp:TextBox>
                                </div>
                            </div>
                        </td>
                        <td>
                            <label>Fecha Final Creación:</label>
                        </td>
                        <td>
                            <div class="form-group">
                                <div class="col-md-12">
                                    <asp:TextBox ID="fechaFinal" runat="server" class="form-control input-md-12"></asp:TextBox>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>Nombre del proyecto:</label>
                        </td>
                        <td>
                            <div class="form-group">
                                <div class="col-md-12">
                                    <asp:TextBox ID="txtNombreProyecto" runat="server" class="form-control input-md-12"></asp:TextBox>
                                </div>
                            </div>
                        </td>
                        <td>
                            <label>Idioma:</label>
                        </td>
                        <td>
                            <div class="form-group">
                                <div class="col-md-12">
                                    <asp:TextBox ID="txtIdioma" runat="server" class="form-control input-md-12"></asp:TextBox>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
                
                <!-- Button -->
                <div class="form-group">
                    <label class="col-md-4 control-label" for="buscar"></label>
                    <div class="col-md-4">
                        <asp:Button ID="btnBuscar" class="btn btn-primary" runat="server" Text="Buscar Proyectos" />
                    </div>
                </div>

            </fieldset>

        </asp:Panel>
        <asp:Panel ID="Panel2" class="card" runat="server">
            
            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:ButtonField Text="Agregar al carrito" />
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

        </asp:Panel>
        <script src="vendor/jquery/jquery.min.js"></script>
        <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

        <script src="vendor/jquery-easing/jquery.easing.min.js"></script>

        <script src="js/sb-admin-2.min.js"></script>

    </div>

</asp:Content>
