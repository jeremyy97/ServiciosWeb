<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="InformacionConsecutivo.aspx.cs" Inherits="B_Cientificas.InformacionConsecutivo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
         
         <asp:Panel class="card"  ID="Panel2" runat="server">
            <fieldset runat="server">
                <hr class="sidebar-divider" />
                <legend>Crear Consecutivo</legend>
                <label class="col-md-4 control-label" for="usuario"></label>
                <br>
                <br>
                </br>
                <div>
                    <table runat="server" align="center">
                         <tr>
                            <td align="left">
                                <label class="" for="selectDescripcion">
                                ID: </label> </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="txtID" runat="server" class="form-control input-md" MaxLength="10"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="selectDescripcion">
                                Nombre: </label> </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="txtNombre" runat="server" class="form-control input-md" MaxLength="50"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="selectDescripcion">
                                Descripción</label> </td>
                            <td>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlTipoConsecutivo" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="consecutivo">
                                Consecutivo:</label> </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="txtConsecutivo" runat="server" class="form-control input-md" MaxLength="10"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtConsecutivo" ErrorMessage="Ingrese únicamente números" Font-Size="Medium" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="prefijoCheck">
                                Posee prefijo:</label> </td>
                            <td align="left">
                                <div class="form-group">
                                    <asp:CheckBox ID="chkBoxPrefijo" runat="server" AutoPostBack="True" class="checkbox-inline" OnCheckedChanged="chkBoxPrefijo_CheckedChanged" Text="Sí" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="prefijo">
                                Prefijo:</label> </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="txtPrefijo" runat="server" class="form-control input-md"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="rangoCheck">
                                Posee Rango:</label> </td>
                            <td align="left">
                                <div class="form-group">
                                    <asp:CheckBox ID="chkBoxRango" runat="server" AutoPostBack="True" class="checkbox-inline" OnCheckedChanged="chkBoxRango_CheckedChanged" Text="Si" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="rangoInicial">
                                Rango Inicial:</label> </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="txtInicio" runat="server" class="form-control input-md"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="rangoFinal">
                                Rango Final:</label> </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="txtFinal" runat="server" class="form-control input-md"></asp:TextBox>
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
                <br>
                <br></br>
                <br></br>
                </br>
                </br>   
            </fieldset>
        </asp:Panel>
    </div>

    </div>

</asp:Content>
