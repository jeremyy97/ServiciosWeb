<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Menu.Master" CodeBehind="CrearPuesto.aspx.cs" Inherits="B_Cientificas.CrearPuesto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">


        <asp:Panel class="card"  ID="Panel2" runat="server">
            <fieldset runat="server">
                <hr class="sidebar-divider" />
                <legend>Crear Puesto</legend>
                <label class="col-md-4 control-label" for="usuario"></label>
                <br>
                <br>
                <br>
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
                                    <asp:Button class="btn btn-primary" ID="btnActualizar" runat="server" Text="Crear" OnClick="btnActualizar_Click" />
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
                                <br />
                             <div class="form-group">
                                   <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                                </div>
                            </td>
                            
                            <td>
                                
                            </td>

                        </tr>
                        
                    </table>
                </div>
                <br>
                <br>
                <br></br>
                <br></br>
                <br></br>
        
     
            </fieldset>
        </asp:Panel>


    </div>

</asp:Content>

