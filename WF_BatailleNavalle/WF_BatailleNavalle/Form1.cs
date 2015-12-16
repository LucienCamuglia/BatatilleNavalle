using System;
using System.Collections.Generic;
/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Auteurs    : Alan Devaud & Lucien Camuglia
 * Desription : Jeu de la bataille navalle
 * Date       : 02.12.2015
 * Version    : 1.0
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System.Windows.Forms;

namespace WF_BatailleNavalle
{
    public partial class FrmBatailleNavalle : Form
    {
        private Piscine piscine;
        private Bateau test;
        private Timer temps;

        public FrmBatailleNavalle()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            try
            {
                GestionFichiers.CreeFichier();
                MessageBox.Show("");
                List<string> joueurs  = new List<string>();
                joueurs = GestionFichiers.LireJoueurs();
                foreach(string joueur in joueurs){
                MessageBox.Show(joueur);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void FrmBatailleNavalle_Load(object sender, System.EventArgs e)
        {
            piscine = new Piscine(20, 20);
            test = new Bateau(400, 10);
            
            temps = new Timer();
            temps.Enabled = true;
            temps.Interval = 1;
            temps.Tick +=temps_tick;
        }

        private void temps_tick(object sender, System.EventArgs e)
        {
            Refresh();
        }

        private void FrmBatailleNavalle_Paint(object sender, PaintEventArgs e)
        {
            piscine.Dessine(e);
            test.Dessine(e);
        }

        private void FrmBatailleNavalle_MouseMove(object sender, MouseEventArgs e)
        {
            piscine.CarreVise(e.X, e.Y);     
        }

        private void FrmBatailleNavalle_MouseUp(object sender, MouseEventArgs e)
        {
            piscine.CarreTouche(e.X, e.Y);
        }

    }
}
