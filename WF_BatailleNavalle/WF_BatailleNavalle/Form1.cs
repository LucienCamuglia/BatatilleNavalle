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
        //private Piscine piscine;
        private List<Piscine> listPiscine;
        private Bateau test;
        private Timer temps;
        private List<string> PlateauP1= new List<string>(), PlateauP2 = new List<string>();

        public FrmBatailleNavalle()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            GestionFichiers.CreeFichier();
            PlateauP1 = GestionFichiers.LirePlateau(1);
            PlateauP2 = GestionFichiers.LirePlateau(2);

        }

        private void FrmBatailleNavalle_Load(object sender, System.EventArgs e)
        {
            this.listPiscine = new List<Piscine>();

            this.listPiscine.Add(new Piscine(20, 20));
            this.listPiscine.Add(new Piscine(500, 20));

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
            foreach (Piscine p in this.listPiscine)
            {
                p.Dessine(e);
            }
            
            test.Dessine(e);
        }

        private void FrmBatailleNavalle_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (Piscine p in this.listPiscine)
            {
                p.CarreVise(e.X, e.Y);
            }    
        }

        private void FrmBatailleNavalle_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (Piscine p in this.listPiscine)
            {
                p.CarreTouche(e.X, e.Y);
            }
        }

    }
}
