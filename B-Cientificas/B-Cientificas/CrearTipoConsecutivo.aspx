<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Menu.Master" CodeBehind="CrearTipoConsecutivo.aspx.cs" Inherits="B_Cientificas.CrearTipoConsecutivo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
         
         <asp:Panel class="card"  ID="Panel2" runat="server">
            <fieldset runat="server">
                <hr class="sidebar-divider" />
                <legend>Crear Tipo Consecutivo</legend>
                <label class="col-md-4 control-label" for="usuario"></label>
                <br>
                <br>
                </br>
                <div>
                    <table runat="server" align="center">
                        <tr>
                            <td align="left">
                                <label class="" for="selectDescripcion">
                                ID:
                                </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="txtID" runat="server" class="form-control input-md" MaxLength="10"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="selectDescripcion">
                                Nombre:
                                </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="txtNombre" runat="server" class="form-control input-md" MaxLength="50"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div class="form-group">
                                    <asp:Button ID="btnCrear" runat="server" class="btn btn-primary" name="aceptar" OnClick="btnCrear_Click" Text="Crear Consecutivo" />
                                    <asp:Button ID="Button2" runat="server" class="btn btn-default" name="cancelar" Text="Cancelar" />
                                    <br />
                                    <br />
                                    <asp:Label ID="lblMensaje" runat="server" Text="Label"></asp:Label>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <br></br>
                <br></br>
                </br>   
            </fieldset>
        </asp:Panel>
    </div>

</asp:Content>
