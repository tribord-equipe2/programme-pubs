using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ProjectEle400
{
    public partial class frmMain : Form
    {
        //Initialisation des variables globales
        string progPath = Directory.GetCurrentDirectory();
        string pythonPath = Directory.GetCurrentDirectory() + "\\python.exe";
        string pyScript = Directory.GetCurrentDirectory() + "\\scriptGetLast.py";
        //string pythonPath = Environment.GetEnvironmentVariable("Path");
        //string pythonPath = "C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Programs\\Python\\Python37-32\\python.exe";
        //string pythonPath = progPath + "\\python.exe";
        int checkPanClick = 0;
        Choix frmChoix = new Choix();
        public frmMain()
        {
            InitializeComponent();
        }        
        //Fonction qui execute le script
        string run_cmd(string script, string args)
        {
            string result;//Declaration de variable de retour
            ProcessStartInfo start = new ProcessStartInfo();//Commencer une nouvelle commande cmd
            start.FileName = pythonPath;//variable global qui retourn le chemin de l'executable python pour rouler le script
            start.Arguments = string.Format("\"{0}\" \"{1}\"", script, args);//Determine le format pour executer le script
            start.UseShellExecute = false;// Ne pas utiliser le shell de l'OS
            start.CreateNoWindow = true; // Pas besoin de fenetre supplementaire
            start.RedirectStandardOutput = true;
            start.RedirectStandardError = true; 
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string stderr = process.StandardError.ReadToEnd(); // Here are the exceptions from our Python script
                    result = reader.ReadLine(); // Here is the result of StdOut(for example: print "test")

                }
            }
            return result;
        }
        //Cacher les images des QrCodes
        void clearQrCode()
        {
            picQr10.Visible = false;
            picQr20.Visible = false;
            picQr30.Visible = false;
        }
        //Active le choix selon le nombre de visites
        //Tim Horton pour 10 et plus
        //McDo et Tim Horton pour 20 et plus
        //Levi's, McDo et Tim pour 30 et plus
        void checkVisites(int iVisites)
        {
            if (iVisites >= 10 && iVisites < 20)
            {
                frmChoix.lblTim.Enabled = true;
            }
            else if (iVisites >= 20 && iVisites < 30)
            {
                frmChoix.lblTim.Enabled = true;
                frmChoix.lblMcDo.Enabled = true;
            }
            else if (iVisites >= 30)
            {
                frmChoix.lblTim.Enabled = true;
                frmChoix.lblMcDo.Enabled = true;
                frmChoix.lblLevis.Enabled = true;
            }
        }
        //Affiche le QrCode du choix fait selon l'option de rabais choisi
        void showQr()
        {
            if (frmChoix.getiQr() == 1)
            {
                picQr10.Visible = true;
            }
            else if (frmChoix.getiQr() == 2)
            {
                picQr20.Visible = true;
            }
            else if (frmChoix.getiQr() == 3)
            {
                picQr30.Visible = true;
            }
            else
            {
                clearQrCode();
            }
        }
        //Execute le script recu par la fonction run_cmd avec le parametre routeur1
        //Sauvegarde le nombre de visite generer par le script
        //Verifie le nombre de visites avec des conditions
        //Si Visites >= 10 afficher la fenetre avec les choix disponibles selon le nombre de visites
        //Affiche la fenetre avec les recompenses disponible 
        //Relocalise la fenetre au point (0,0)
        private void btnReco_Click(object sender, EventArgs e)
        {
            checkPanClick = 1;
            picTrophy.Size = picWifiReco.Size;
            picTrophy.Location = new Point(this.Width - picTrophy.Width - 30, 0);
            lblRecoTitre.Location = new Point((this.Width / 2) - (lblRecoTitre.Width / 2), 0);
            lbl10V.Location = new Point(lblRecoTitre.Location.X, picWifiReco.Height);
            lbl20V.Location = new Point(lblRecoTitre.Location.X, lbl10V.Location.Y + lbl10V.Height + picTim.Height);
            lbl30V.Location = new Point(lblRecoTitre.Location.X - 96, lbl20V.Location.Y + lbl20V.Height + picMcDo.Height);
            picTim.Location = new Point(lblRecoTitre.Location.X + lbl10V.Width, lbl10V.Location.Y - 39);
            picQr10.Location = new Point(picTim.Location.X + picTim.Width, lbl10V.Location.Y - 39);
            picMcDo.Location = new Point(picTim.Location.X, lbl20V.Location.Y - 39);
            picQr20.Location = new Point(picMcDo.Location.X + picMcDo.Width, lbl20V.Location.Y - 39);
            picLevis.Location = new Point(picTim.Location.X, lbl30V.Location.Y - 39);
            picQr30.Location = new Point(picTim.Location.X + picLevis.Width - 17, lbl30V.Location.Y - 39);
            string visites = run_cmd(pyScript, "Routeur1");
            if (visites == "")
                visites = "0";
            int iVisites = 0;
            Int32.TryParse(visites, out iVisites);
            checkVisites(iVisites);
            pnlReco.Visible = true;
            pnlReco.Location = new Point(0, 0);
            pnlReco.Size = new Size(this.Width, this.Height);
            if (iVisites >= 10)
            {
                MessageBox.Show("Vous êtes rendu à " + visites + " visites sur notre réseau.\nAppuyez sur Ok et veuillez cliquer sur la compagnie dans laquelle vous désirez un rabais.");
                frmChoix.ShowDialog();
                showQr();
            }
            else
            {
                MessageBox.Show("Vous n'êtes pas éligible pour un rabais. Vous avez " + visites + " visites.");
                //frmChoix.ShowDialog();
            }
        }
        //Affiche la fenetre avec tous les boutons pour les rabais
        //Relocalise la fenetre au point (0,0)
        private void btnRecharge_Click(object sender, EventArgs e)
        {
            checkPanClick = 2;
            pnlRecharge.Visible = true;
            pnlRecharge.Location = new Point(0, 0);
            pnlRecharge.Size = new Size(this.Width, this.Height);
            picWifiRech.Location = new Point(this.Width - picWifiRech.Width - 30,0);
            lblRechTitre.Location = new Point((this.Width / 2) - (lblRechTitre.Width / 2), 0);
            lblRech1.Location = new Point((this.Width / 2) - (lblRech1.Width / 2), 0 + picWifiRech.Height);
            lblRech3.Location = new Point((this.Width / 2) - (lblRech3.Width / 2), lblRech1.Location.Y + lblRech1.Height + 100);
            picInduction.Location = new Point((this.Width / 2) - (picInduction.Width / 2), lblRech3.Location.Y + lblRech3.Height);
        }
        //Affiche la fenetre a propos de nous
        //Relocalise la fenetre au point (0,0)
        private void btnAprop_Click(object sender, EventArgs e)
        {
            checkPanClick = 4;
            pnlAprop.Visible = true;
            pnlAprop.Location = new Point(0, 0);
            axVideo.Size = new Size(this.Width - picWifiApropos.Width - 100, this.Height - btnAcc4.Height - 200);
            pnlAprop.Size = new Size(this.Width, this.Height);
            lblApropTitre.Location = new Point((this.Width / 2) - (lblApropTitre.Width / 2), 0);
        }
        //Affiche la fenetre avec tous les boutons pour les rabais du jour
        //Relocalise la fenetre au point (0,0)
        private void btnDivertissement_Click(object sender, EventArgs e)
        {
            checkPanClick = 3;
            pnlRabais.Visible = true;
            pnlRabais.Location = new Point(0, 0);
            pnlRabais.Size = new Size(this.Width, this.Height);
            picWifiRabais.Location = new Point(0, this.Height - picWifiRabais.Height -100);
            lblRabTitre.Location = new Point((this.Width / 2) - (lblRabTitre.Width / 2), this.Height - picWifiRabais.Height);
            button1.Location = new Point(0, 0);
            button2.Location = new Point(0, button1.Height + 100);
            button3.Location = new Point(0, button2.Location.Y + button2.Height + 100);
            button4.Location = new Point((this.Width / 2) - (button4.Width / 2), 0);
            button5.Location = new Point((this.Width / 2) - (button5.Width / 2), button4.Height + 100);
            button6.Location = new Point((this.Width / 2) - (button6.Width / 2), button5.Location.Y + button5.Height + 100);
            button7.Location = new Point(this.Width - button7.Width - 30, 0);
            button8.Location = new Point(this.Width - button8.Width - 30, button7.Height + 100);
            button9.Location = new Point(this.Width - button9.Width - 30, button8.Location.Y + button8.Height + 100);

        }
        //Ferme la fenetre Recompenses
        //Reinitialise les valeurs pour les QrCodes
        //Cache les images des QrCodes
        private void btnAccueil_Click(object sender, EventArgs e)
        {
            if (checkPanClick == 1)
            {
                pnlReco.Visible = false;
                checkPanClick = 0;
            }
            else if (checkPanClick == 2)
            {
                pnlRecharge.Visible = false;
                checkPanClick = 0;
            }
            else if (checkPanClick == 3)
            {
                pnlRabais.Visible = false;
                checkPanClick = 0;
            }
            else if (checkPanClick == 4)
            {
                pnlAprop.Visible = false;
                axVideo.Ctlcontrols.stop();
                checkPanClick = 0;
            }
            frmChoix.initiQr();
            clearQrCode();
        }        
        //Ferme la fenetre du rabais selectionne
        private void btnAcc5_Click(object sender, EventArgs e)
        {
            pnlRab.Visible = false;
        }
        //Recupere le nom du bouton choisi
        //Selon le nom, repositionne la fenetre, la rendre visible et affiche l'image de la pub choisi.
        private void btnRabaisClick(object sender, EventArgs e)
        {
            string buttonText = ((Button)sender).Text;
            pnlRab.Size = new Size(this.Width, this.Height);
            Image myimage = new Bitmap(progPath + "\\Pubs\\" + buttonText + ".jpg");
            pnlRab.BackgroundImageLayout = ImageLayout.Zoom;

            switch (buttonText)
            {
                case "American Eagle":
                    pnlRab.Location = new Point(0, 0);
                    pnlRab.Visible = true;
                    pnlRab.BackgroundImage = myimage;
                    break;
                case "BulkBarn":
                    pnlRab.Location = new Point(0, 0);
                    pnlRab.Visible = true;
                    pnlRab.BackgroundImage = myimage;
                    break;
                case "Cineplex":
                    pnlRab.Location = new Point(0, 0);
                    pnlRab.Visible = true;
                    pnlRab.BackgroundImage = myimage;
                    break;
                case "Forever21":
                    pnlRab.Location = new Point(0, 0);
                    pnlRab.Visible = true;
                    pnlRab.BackgroundImage = myimage;
                    break;
                case "Metro":
                    pnlRab.Location = new Point(0, 0);
                    pnlRab.Visible = true;
                    pnlRab.BackgroundImage = myimage;
                    break;
                case "Kraft":
                    pnlRab.Location = new Point(0, 0);
                    pnlRab.Visible = true;
                    pnlRab.BackgroundImage = myimage;
                    break;
                case "McDonald":
                    pnlRab.Location = new Point(0, 0);
                    pnlRab.Visible = true;
                    pnlRab.BackgroundImage = myimage;
                    break;
                case "PFK":
                    pnlRab.Location = new Point(0, 0);
                    pnlRab.Visible = true;
                    pnlRab.BackgroundImage = myimage;
                    break;
                case "Jean Coutu":
                    pnlRab.Location = new Point(0, 0);
                    pnlRab.Visible = true;
                    pnlRab.BackgroundImage = myimage;
                    break;
            }
        }
        //Determine le URL du video de tribor pour la fenetre a propos de nous
        private void frmMain_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            btnReco.Location = new Point(0, 0);
            btnRecharge.Location = new Point(this.Width - btnRecharge.Width - 30, 0);
            btnDivertissement.Location = new Point(0, this.Height - btnDivertissement.Height-100);
            btnAprop.Location = new Point(this.Width - btnRecharge.Width - 30, this.Height - btnDivertissement.Height-100);
            btnAccueil.Location = new Point(this.Width - btnRecharge.Width - 30, this.Height - btnDivertissement.Height - 100);
            btnAcc2.Location = new Point(this.Width - btnRecharge.Width - 30, this.Height - btnDivertissement.Height - 100);
            btnAcc3.Location = new Point(this.Width - btnRecharge.Width - 30, this.Height - btnDivertissement.Height - 100);
            btnAcc4.Location = new Point(this.Width - btnRecharge.Width - 30, this.Height - btnDivertissement.Height - 100);
            btnAcc5.Location = new Point(this.Width - btnRecharge.Width - 30, this.Height - btnDivertissement.Height - 100);
            axVideo.URL = progPath + "\\Tribor Design.mp4";
            axVideo.Ctlcontrols.stop();
        }
    }

}
