using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PFXConverter
{
    public partial class frmPfxConverter : Form
    {
        private string sourceFile = "", destinationFile = "";

        public frmPfxConverter()
        {
            InitializeComponent();
            this.cmbOutputFormat.SelectedIndex = 0;
        }

        private bool ExtractResource(string resourceName)
        {
            try
            {
                object obj = Properties.Resources.ResourceManager.GetObject(resourceName);
                byte[] resourceBytes = (byte[])obj;
                using (FileStream fs = new FileStream(Path.GetTempPath() + resourceName, FileMode.Create, FileAccess.Write))
                {
                    byte[] bytes = resourceBytes;
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();
                    fs.Dispose();
                }
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error extracting " + resourceName + " to your temporary folder (" + Path.GetTempPath() + resourceName + ")" + Environment.NewLine + "Details: " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        private string RunExecutable(string filename, string arguments)
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = filename;
            p.StartInfo.Arguments = arguments;
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            return output;
        }

        private bool VerifyPfxPassword()
        {
            try
            {
                X509Certificate2 certificate = new X509Certificate2(File.ReadAllBytes(this.sourceFile), this.txtSourcePassword.Text);
                return true;
            }
            catch (CryptographicException ex)
            {
                if ((ex.HResult & 0xFFFF) == 0x56)
                {
                    return false;
                };
            }

            return false;
        }

        private void ToggleConvertButton()
        {
            bool enabled = false;
            if (this.sourceFile != string.Empty && this.txtSourcePassword.Text != string.Empty && this.destinationFile != string.Empty && this.VerifyPfxPassword())
            {
                if (this.cmbOutputFormat.Text != "JKS (Java Keystore)" || this.txtDestinationPassword.Text.Length >= 6) enabled = true;
            }
            this.btnConvert.Enabled = enabled;
        }

        private void btnBrowseSource_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "PKCS#12 Files|*.pfx;*.p12";
            ofd.ShowDialog();
            if (ofd.FileName != string.Empty) sourceFile = ofd.FileName;
            this.txtSourcePassword_TextChanged(sender, e);
        }

        private void btnBrowseDestination_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            string filter = "PEM & Key Files|*.pem;*.key";
            if (this.cmbOutputFormat.Text == "JKS (Java Keystore)") filter = "Java Keystore Files|*.jks";
            else if (this.cmbOutputFormat.Text == "PSE (SAP Proprietary)") filter = "PSE Files|*.pse";
            sfd.Filter = filter;
            sfd.ShowDialog();
            if (sfd.FileName != string.Empty) destinationFile = sfd.FileName;
            this.ToggleConvertButton();
        }

        private void txtSourcePassword_TextChanged(object sender, EventArgs e)
        {
            if (sourceFile != string.Empty) if (this.VerifyPfxPassword()) this.txtSourcePassword.BackColor = Color.White; else this.txtSourcePassword.BackColor = Color.Red;
            this.ToggleConvertButton();
        }

        private void cmbOutputFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtDestinationPassword_TextChanged(sender, e);
        }

        private void txtDestinationPassword_TextChanged(object sender, EventArgs e)
        {
            if (this.cmbOutputFormat.Text == "JKS (Java Keystore)" && this.txtDestinationPassword.Text.Length < 6) this.txtDestinationPassword.BackColor = Color.Red; else this.txtDestinationPassword.BackColor = Color.White;
            this.ToggleConvertButton();
        }

        private void frmPfxConverter_DragDrop(object sender, DragEventArgs e)
        {
            if (IsDroppedFileSupported(e))
            {
                this.sourceFile = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
                MessageBox.Show("Selected PFX file: " + this.sourceFile, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmPfxConverter_DragEnter(object sender, DragEventArgs e)
        {
            if (IsDroppedFileSupported(e)) e.Effect = DragDropEffects.Copy;
        }

        private bool IsDroppedFileSupported(DragEventArgs e)
        {
            string[] supportedExtensions = new string[] { ".pfx", ".p12" };

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length == 1) if (Path.HasExtension(files[0])) foreach (string supportedExtension in supportedExtensions) if (Path.GetExtension(files[0]).ToLower().Equals(supportedExtension.ToLower())) return true;
            }

            return false;
        }       

        private void btnConvert_Click(object sender, EventArgs e)
        {
            this.btnConvert.Enabled = false;
            bool succeeded = false;
            switch(this.cmbOutputFormat.Text)
            {
                case "PEM (Base64)":
                    if (this.ExtractResource("openssl.exe"))
                    {
                        this.destinationFile = this.destinationFile.Substring(0, this.destinationFile.Length - 4);
                        string outputFile = this.destinationFile + ".key";
                        if (File.Exists(outputFile)) File.Delete(outputFile);
                        this.RunExecutable(Path.GetTempPath() + "openssl.exe", "pkcs12 -in \"" + this.sourceFile + "\" -out \"" + outputFile + "\" -nocerts -passin pass:" + this.txtSourcePassword.Text + (this.txtDestinationPassword.Text == string.Empty ? " -nodes" : " -passout pass:" + this.txtDestinationPassword.Text));
                        if (!File.Exists(outputFile) || File.ReadAllText(outputFile).Length == 0)
                        {
                            MessageBox.Show("Error extracting the private key from " + this.sourceFile, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            outputFile = this.destinationFile + ".pem";
                            if (File.Exists(outputFile)) File.Delete(outputFile);
                            this.RunExecutable(Path.GetTempPath() + "openssl.exe", "pkcs12 -in \"" + this.sourceFile + "\" -out \"" + outputFile + "\" -nokeys -clcerts -passin pass:" + this.txtSourcePassword.Text);
                            if (!File.Exists(outputFile) || File.ReadAllText(outputFile).Length == 0)
                            {
                                MessageBox.Show("Error extracting the certificate from " + this.sourceFile, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                outputFile = this.destinationFile + "-chain.pem";
                                if (File.Exists(outputFile)) File.Delete(outputFile);
                                this.RunExecutable(Path.GetTempPath() + "openssl.exe", "pkcs12 -in \"" + this.sourceFile + "\" -out \"" + outputFile + "\" -nokeys -cacerts -passin pass:" + this.txtSourcePassword.Text);
                                if (File.ReadAllText(outputFile).Length == 0) File.Delete(outputFile);
                                succeeded = true;
                            }
                        }
                    }
                    break;
                case "JKS (Java Keystore)":
                    if (this.ExtractResource("keytool.exe") && this.ExtractResource("jli.dll"))
                    {
                        if (File.Exists(this.destinationFile)) File.Delete(this.destinationFile);
                        this.RunExecutable(Path.GetTempPath() + "keytool.exe", "-importkeystore -srckeystore \"" + this.sourceFile + "\" -srcstoretype PKCS12 -srcstorepass \"" + this.txtSourcePassword.Text + "\" -destkeystore \"" + this.destinationFile + "\" -deststoretype JKS -deststorepass \"" + this.txtDestinationPassword.Text + "\" -destkeypass \"" + this.txtDestinationPassword.Text + "\"");
                        if (!File.Exists(this.destinationFile) || File.ReadAllText(this.destinationFile).Length == 0) MessageBox.Show("Error generating a JKS file from " + this.sourceFile, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else succeeded = true;
                    }
                    break;
                case "PSE (SAP Proprietary)":
                    bool sapDependenciesResolved = false;
                    if (File.Exists(Path.GetTempPath() + "sapgenpse.exe") && File.Exists(Path.GetTempPath() + "sapcrypto.dll")) sapDependenciesResolved = true;
                    else
                    {
                        OpenFileDialog ofd = new OpenFileDialog();
                        ofd.Multiselect = false;
                        ofd.Title = "Please locate the 'sapgenpse.exe' dependency file.";
                        ofd.Filter = "SAP 'sapgenpse.exe' binary|sapgenpse.exe";
                        ofd.ShowDialog();
                        if (ofd.FileName == string.Empty) MessageBox.Show("In order to convert the file to PSE format, you have to load the dependency (sapgenpse.exe) from your SAP runtime binaries path.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                        {
                            File.Copy(ofd.FileName, Path.GetTempPath() + "sapgenpse.exe", true);
                            ofd.FileName = string.Empty;
                            ofd.Title = "Please locate the 'sapcrypto.dll' dependency file.";
                            ofd.Filter = "SAP 'sapcrypto.dll' binary|sapcrypto.dll";
                            ofd.ShowDialog();
                            if (ofd.FileName == string.Empty) MessageBox.Show("In order to convert the file to PSE format, you have to load the dependency (sapcrypto.dll) from your SAP runtime binaries path.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            else
                            {
                                File.Copy(ofd.FileName, Path.GetTempPath() + "sapcrypto.dll", true);
                                sapDependenciesResolved = true;
                            }
                        }
                    }

                    if (sapDependenciesResolved)
                    {
                        if (File.Exists(this.destinationFile)) File.Delete(this.destinationFile);
                        this.RunExecutable(Path.GetTempPath() + "sapgenpse.exe", "import_p12 -z " + this.txtSourcePassword.Text + " -x \"" + this.txtDestinationPassword.Text + "\"" + " -p \"" + this.destinationFile + "\" \"" + this.sourceFile + "\"");
                        if (!File.Exists(this.destinationFile) || File.ReadAllText(this.destinationFile).Length == 0) MessageBox.Show("Error generating a PSE file from " + this.sourceFile + Environment.NewLine + Environment.NewLine + "Make sure your PFX file contains the full issuance chain.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else succeeded = true;
                    }
                    break;
            }
            if (succeeded) MessageBox.Show("Converted succesfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.btnConvert.Enabled = true;
        }
    }
}
