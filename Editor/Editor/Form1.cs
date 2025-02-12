using System.Runtime.CompilerServices;

namespace Editor
{
    public partial class Form1 : Form
    {
        bool archivoguardado = false;
        String filepatch = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r;
            if (archivoguardado == false)
            {
                r = saveFileDialogeditor.ShowDialog();
                if (r == DialogResult.OK)
                {
                    filepatch = saveFileDialogeditor.FileName;
                    String texto = richTextBox1.Text;
                    try
                    {
                        File.WriteAllText(filepatch, texto);
                        MessageBox.Show("Archivo Guardado correctamente");
                        archivoguardado |= true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al Guardar el archivo " + ex.Message);

                    }

                }
            }
            else
            {
                try
                {
                    String texto = richTextBox1.Text;
                    File.WriteAllText(filepatch, texto);
                    MessageBox.Show("Archivo guardado correctamente");
                    archivoguardado = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el archivo " + ex.Message);
                }
            }
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resultado;
            resultado = openFileDialogEditor.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                filepatch = openFileDialogEditor.FileName;
                try
                {
                    String texto = File.ReadAllText(filepatch);
                    richTextBox1.Text = texto;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al Guardar el archivo " + ex.Message);

                }

            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Deseas salir?", "Sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resultado;
            if (archivoguardado == false)
            {
                resultado = saveFileDialogeditor.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    filepatch = saveFileDialogeditor.FileName;
                    String texto = richTextBox1.Text;
                    try
                    {
                        File.WriteAllText(filepatch, texto);
                        MessageBox.Show("Archivo Guardado correctamente");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al Guardar el archivo " + ex.Message);

                    }

                }
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            archivoguardado = false;
            richTextBox1.Text = "";
        }
    }
}

