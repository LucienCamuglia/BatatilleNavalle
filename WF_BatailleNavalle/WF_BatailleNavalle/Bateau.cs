/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Auteurs      : Alan Devaud
 * Desription   : Class pour les bateaux
 * Date         : 08.12.2015
 * Version      : 1.0
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */


using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WF_BatailleNavalle
{
    class Bateau
    {
        #region Champs
        private Point _location;
        private List<Carre> _formBateau;
        private bool _selectionner;
        private const int TAILLE_CARRE = 35;
        #endregion

        #region Propriétés
        /// <summary>
        /// Obtient ou définit la position du bateau
        /// </summary>
        public Point Location
        {
            get { return _location; }
            set { _location = value; }
        }

        /// <summary>
        /// Obtient ou définit la form du bateau
        /// </summary>
        public List<Carre> FormBateau
        {
            get { return _formBateau; }
            set { _formBateau = value; }
        }

        /// <summary>
        /// Obtient ou définit si le bateau est sélectionner avec la souris
        /// </summary>
        public bool Selectionner
        {
            get { return _selectionner; }
            set { _selectionner = value; }
        }
        #endregion

        #region Constructeur
        public Bateau(int x, int y)
        {
            this.Location = new Point(x, y);
            this.FormBateau = new List<Carre>();
            this.InitialiseForm();
        }
        #endregion

        #region Methodes

        /// <summary>
        /// Initialise la forme
        /// </summary>
        private void InitialiseForm()
        {
            this.FormBateau.Add(new Carre(this.Location.X, this.Location.Y, TAILLE_CARRE, Color.Orange));
            this.FormBateau.Add(new Carre(this.Location.X + TAILLE_CARRE, this.Location.Y, TAILLE_CARRE, Color.Orange));
        }

        /// <summary>
        /// Dessine le bateau
        /// </summary>
        /// <param name="pe"></param>
        public void Dessine(PaintEventArgs pe)
        {
            foreach (Carre rec in this.FormBateau)
                rec.Dessine(pe);
        }

        public void CliquerBateau(int x, int y)
        {
            foreach(Carre rec in this.FormBateau)
            {
                if ((x >= rec.Rectangle.X) && (x <= rec.Rectangle.X + rec.Rectangle.Width) && (y >= rec.Rectangle.Y) && (y <= rec.Rectangle.Y + rec.Rectangle.Height))
                {
                    this.Selectionner = true;
                }
                else
                {
                    this.Selectionner = false;
                }
            }
            
        }
        #endregion
    }
}
