<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Menu.Master" CodeBehind="CrearNivelAcademico.aspx.cs" Inherits="B_Cientificas.CrearNivelAcademico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">


        <asp:Panel class="card"  ID="Panel2" runat="server">
            <fieldset runat="server">
                <hr class="sidebar-divider" />
                <legend>Crear Nivel Académico</legend>
                <label class="col-md-4 control-label" for="usuario"></label>
                <br>
                <br>
                <br>
                <br>
                <br>
                <br></br>
                <div>
                    <table align="center">
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">
                                Código:
                                </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="txtCodigo" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="usuario">
                                Nivel Académico:
                                </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlNiveles" runat="server" CssClass="form-control">
                                        <asp:ListItem>Educación Secundaria</asp:ListItem>
                                        <asp:ListItem>Diplomado</asp:ListItem>
                                        <asp:ListItem>Profesorado</asp:ListItem>
                                        <asp:ListItem>Técnico</asp:ListItem>
                                        <asp:ListItem>Bachiller Universitario</asp:ListItem>
                                        <asp:ListItem>Licenciatura</asp:ListItem>
                                        <asp:ListItem>Especialidad</asp:ListItem>
                                        <asp:ListItem>Maestría</asp:ListItem>
                                        <asp:ListItem>Doctorado</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDetalle" ErrorMessage="Campo requerido" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="rama">
                                Detalle:
                                </label>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:TextBox ID="txtDetalle" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <label class="" for="prefijoCheck">
                                Completo:</label> </td>
                            <td align="left">
                                <div class="form-group">
                                    <asp:CheckBox ID="chkBoxCompleto" runat="server" AutoPostBack="True" class="checkbox-inline" Text="Sí" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <div class="form-group">
                                    <asp:Button ID="btnCrear" runat="server" class="btn btn-primary" OnClick="btnCrear_Click" Text="Crear" />
                                </div>
                            </td>
                            <td>
                                <div class="form-group">
                                    <asp:Button ID="btnLimpiar" runat="server" class="btn btn-primary" OnClick="btnLimpiar_Click" Text="Cancelar" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <br />
                                <div class="form-group">
                                    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                                </div>
                            </td>
                            <td></td>
                        </tr>
                    </table>
                </div>
                <br>
                <br>
                <br>
                <br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                </br>
                </br>
                </br>
                </br>
                </br>
                </br>
                                
     
            </fieldset>
        </asp:Panel>


    </div>

</asp:Content>