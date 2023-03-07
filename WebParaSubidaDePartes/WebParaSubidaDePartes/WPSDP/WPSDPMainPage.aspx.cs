using System;
using System.Configuration;
using System.IO;

namespace WebParaSubidaDePartes.WPSDP
{
    public partial class WPSDPMainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (TbRutaFicheros.Text == "")
            {
                TbRutaFicheros.Text = ConfigurationManager.AppSettings["RutaFicheros"];
                this.TbNumFicherosProcesar.Text = ConfigurationManager.AppSettings["NumArchivos"];
                this.TbTiempoDeEspera.Text = ConfigurationManager.AppSettings["TempEspera"];
            }
            refrescarListadoFicheros();
        }

        void refrescarListadoFicheros()
        {
            DirectoryInfo di = new DirectoryInfo(TbRutaFicheros.Text);
            this.LbFicheros.Items.Clear();
            foreach (var fi in di.GetFiles())
            {
                Console.WriteLine(fi.Name);
                this.LbFicheros.Items.Add(fi.Name);
            }
        }
        protected void PbProcesarDocumentos_Click(object sender, EventArgs e)
        {
            TbLog.Text = "";
            string rutaFicherosOK = ConfigurationManager.AppSettings["RutaFicherosOK"];
            string rutaFicherosKO = ConfigurationManager.AppSettings["RutaFicherosKO"];
       //     GestorDocumentalAgent gestorDocumentalAgent01 = new GestorDocumentalAgent();
            string nombreFichero, tipo, campo4;
            //ParteInstalaciones_377141901_129067445_Y8123300J_X_Backoffice_X
            string strTipoDocumental;
            string strNumTiquet;
            string strTipoTiquet;
            string strIdCliente;
            string resultado;
            Int32 numFiles = 0;

            foreach (var fileName in LbFicheros.Items)
            {
                if (numFiles < Int32.Parse(TbNumFicherosProcesar.Text))
                {
                    nombreFichero = fileName.ToString();
                    TbLog.Text = TbLog.Text + "################################" + "\n";
                    TbLog.Text = TbLog.Text + "# PROCESANDO:" + DateTime.Now + " " + nombreFichero + "\n";
                    tipo = nombreFichero.Split('_')[0];
                    strNumTiquet = nombreFichero.Split('_')[1];
                    strTipoTiquet = nombreFichero.Split('_')[2];
                    strIdCliente = nombreFichero.Split('_')[3];
                    campo4 = nombreFichero.Split('_')[4];
                    strTipoDocumental = nombreFichero.Split('_')[5];
                    TbLog.Text = TbLog.Text + "# CAMPOS:\n";
                    TbLog.Text = TbLog.Text + "Tipo:" + tipo + "\n";
                    TbLog.Text = TbLog.Text + "TipoDocumental:" + strTipoDocumental + "\n";
                    TbLog.Text = TbLog.Text + "NumTiquet:" + strNumTiquet + "\n";
                    TbLog.Text = TbLog.Text + "TipoTiquet:" + strTipoTiquet + "\n";
                    TbLog.Text = TbLog.Text + "IdCliente:" + strIdCliente + "\n";
                    TbLog.Text = TbLog.Text + "RutaFicheros:" + TbRutaFicheros.Text + "\n";
                    TbLog.Text = TbLog.Text + "NombreFichero:" + nombreFichero.Split('.')[0] + "\n";
                    TbLog.Text = TbLog.Text + "Extension:" + nombreFichero.Split('.')[1] + "\n";

//                    gestorDocumentalAgent01.AltaDocumento(strTipoDocumental, strNumTiquet, strTipoTiquet, strIdCliente,TbRutaFicheros.Text, nombreFichero.Split('.')[0], nombreFichero.Split('.')[1]);
                    resultado = "ok";
                    // Espera
                    System.Threading.Thread.Sleep(100 * Int32.Parse(TbTiempoDeEspera.Text)); 
                    // Resultado
                    TbLog.Text = TbLog.Text + "Resultado:" + resultado + "\n";
                    if (resultado == "ok")
                    {
                        System.IO.File.Move(TbRutaFicheros.Text + nombreFichero, rutaFicherosOK + nombreFichero);
                        TbLog.Text = TbLog.Text + "Se movio a :" + rutaFicherosOK + "\n";
                    }
                    else
                    {
                        System.IO.File.Move(TbRutaFicheros.Text + nombreFichero, rutaFicherosKO + nombreFichero);
                        TbLog.Text = TbLog.Text + "Se movio a :" + rutaFicherosKO + "\n";
                    }
                }
                numFiles++;
            }
            refrescarListadoFicheros();
        }

        protected void PbCargarFicheros_Click(object sender, EventArgs e)
        {
            /*
            DirectoryInfo di = new DirectoryInfo(TbRutaFicheros.Text);
            this.LbFicheros.Items.Clear();
            foreach (var fi in di.GetFiles())
            {
                Console.WriteLine(fi.Name);
                this.LbFicheros.Items.Add(fi.Name);
            }
            */
            refrescarListadoFicheros();
        }
    }
}