<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Errores.aspx.cs" Inherits="B_Cientificas.Errores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <form class="">
            <fieldset>
                <legend>Errores</legend>
            </fieldset>
        </form>
        <asp:Panel class="card" ID="Panel1" runat="server">
            <fieldset>
                <hr class="sidebar-divider" />
                <legend>Filtrar Errores</legend>
                <label class="col-md-4 control-label" for="usuario"></label>
                <div>
                    <table align="center">
                        <tr>
                            <td align="left">
                                <label class="" for="fechaInicio">Fecha Inicio:</label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="txtFechaInicio" placeholder="12/31/2018" class="form-control input-md" runat="server"></asp:TextBox>
                                </div>
                            </td>
                            <td align="left">
                                &nbsp;
                                <label class="" for="fechaFinal">Fecha Final:</label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="txtFechaFinal"  placeholder="12/31/2019" class="form-control input-md" runat="server"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div class="form-group">
                                    <asp:Button ID="btnConsultar"  class="btn btn-primary"  runat="server" Text="Consultar" OnClick="btnConsultar_Click"/>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </fieldset>
        </asp:Panel>
        <br />
        <asp:Panel class="card" ID="panelResultados" runat="server" Visible="false">
            <asp:GridView ID="gvErrores" class="table" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
                
        </asp:Panel>
    </div>

</asp:Content>
