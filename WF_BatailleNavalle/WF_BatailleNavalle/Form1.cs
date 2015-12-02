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
        private Timer temps;

        public FrmBatailleNavalle()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void FrmBatailleNavalle_Load(object sender, System.EventArgs e)
        {
            piscine = new Piscine(10, 10);
            
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
        }

        private void FrmBatailleNavalle_MouseMove(object sender, MouseEventArgs e)
        {
            piscine.CarreVise(e.X, e.Y);
        }

    }
}
