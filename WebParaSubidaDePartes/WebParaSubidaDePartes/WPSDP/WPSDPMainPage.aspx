<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WPSDPMainPage.aspx.cs" Inherits="WebParaSubidaDePartes.WPSDP.WPSDPMainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 374px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table border="1">
                <tr>
                    <td>Ruta:</td>
                    <td class="auto-style1"><asp:TextBox ID="TbRutaFicheros" runat="server" Width="700px"></asp:TextBox></td>
                    <td><asp:Button ID="PbCargarFicheros" runat="server" Text="Cargar Ficheros" Width="129px" OnClick="PbCargarFicheros_Click" /></td>
                </tr>
                <tr>
                    <td colspan="3">
                        <table>
                            <tr>
                                <td><asp:ListBox ID="LbFicheros" runat="server" Height="296px" Width="899px"></asp:ListBox></td>
                                <td valign="top">
                                    <table border="1">
                                        <tr>
                                            <td>Archivos a Procesar</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:TextBox ID="TbNumFicherosProcesar" runat="server" Width="232px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Segundos de espera entre intentos</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="TbTiempoDeEspera" runat="server" Width="236px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                
                                                <asp:Button ID="PbProcesarDocumentos" runat="server" OnClick="PbProcesarDocumentos_Click" Text="Procesar Documentos" />
                                                
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:TextBox ID="TbLog" runat="server" Height="296px" TextMode="MultiLine" Width="1183px"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>

    </form>
</body>
</html>
