<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="RolesSimples.aspx.cs" Inherits="B_Cientificas.RolesSimples" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <h1>Lista de Usuarios</h1>
        <table>
            <tr>
                <td>
                    <asp:ListBox ID="lbxUsuarios" runat="server" Height="252px" Width="163px" OnSelectedIndexChanged="lbxUsuarios_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox>
                </td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                <td class="form-group">
                    <form class="form-horizontal">
                        <fieldset>
                        <legend>Lista de Roles</legend>
                        <div class="form-group">
                          
                            <asp:CheckBox ID="cbx1" runat="server" Text="Administrador"  /><br />
                            <asp:CheckBox ID="cbx2" runat="server" Text="Seguridad" /><br />
                            <asp:CheckBox ID="cbx3" runat="server" Text="Consecutivos" /><br />
                            <asp:CheckBox ID="cbx4" runat="server" Text="Mantenimiento" /><br />
                            <asp:CheckBox ID="cbx5" runat="server" Text="Consultas" />
                       
                        </div>

                        <div class="form-group">
                          <label class="col-md-4 control-label" for=""></label>
                          <div class="col-md-4">
                              <asp:Button ID="btnActualizar" class="btn btn-primary" runat="server" Text="Actualizar Roles" OnClick="btnActualizar_Click" />
                          </div>
                        </div>

                        </fieldset>
                        </form>

                   
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
