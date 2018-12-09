using System;
using System.Windows.Forms;

namespace ProjectEle400
{
    public partial class Choix : Form
    {
        private int iQr = 0;
        public Choix()
        {
            InitializeComponent();
        }
        //Initialise les rabais disponible(Les desactives)
        public void initlabel()
        {
            lblTim.Enabled = false;
            lblMcDo.Enabled = false;
            lblLevis.Enabled = false;
        }
        //Attribu la valeur 1 a iQr pour dire qu'il a choisit le rabais de tim horton
        private void lblTim_Click(object sender, EventArgs e)
        {
            iQr = 1;
            Close();
        }
        //Attribu la valeur 2 a iQr pour dire qu'il a choisit le rabais de McDo
        private void lblMcDo_Click(object sender, EventArgs e)
        {
            iQr = 2;
            Close();
        }
        //Attribu la valeur 3 a iQr pour dire qu'il a choisit le rabais de Levi's
        private void lblLevis_Click(object sender, EventArgs e)
        {
            iQr = 3;
            Close();
        }
        //Retourne la valeur de iQr, car c'est une variable protege
        public int getiQr()
        {
            return iQr;
        }
        //Initialise la valeur de iQr a 0
        public void initiQr()
        {
            iQr = 0;
        }
    }
}
