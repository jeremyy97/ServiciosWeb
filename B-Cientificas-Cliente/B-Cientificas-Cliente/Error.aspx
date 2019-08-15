<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="B_Cientificas_Cliente.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table align=center style="border-right: gainsboro thin solid; border-top: gainsboro thin solid; border-left: gainsboro thin solid; width: 386px; border-bottom: gainsboro thin solid; height: 201px">
            <tr>
                <td style="width: 112px; height: 1px; background-color: #f7f6f3;" align="center" valign="middle">
                    &nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#00C000"
                        Text="Estado: Operación Fallida" Width="409px"></asp:Label></td>
            </tr>
            <tr>
                <td style="height: 1px; background-color: #f7f6f3;" align="center">
                    <asp:Label ID="lbl_msg" runat="server" ForeColor="Red" Font-Bold="True" Width="413px"></asp:Label>
                    </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 1px; background-color: #f7f6f3;" align="center" valign="top">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx" Width="175px">Click aqui para volver</asp:HyperLink></td>
            </tr>
        </table>
</asp:Content>
