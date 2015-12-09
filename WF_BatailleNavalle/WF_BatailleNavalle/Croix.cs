/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Auteurs      : Alan Devaud
 * Desription   : Class croix
 * Date         : 08.12.2015
 * Version      : 1.0
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System.Drawing;
using System.Windows.Forms;

namespace WF_BatailleNavalle
{
    class Croix
    {
        #region Champs
        private int _taille;
        private Point _location;
        private Color _coleur;        
        #endregion

        #region Propriétés
        /// <summary>
        /// Obtient ou définit la taille de la croix
        /// </summary>
        public int Taille
        {
            get { return _taille; }
            set { _taille = value; }
        }

        /// <summary>
        /// Obtient ou définit la position de la croix
        /// </summary>
        public Point Location
        {
            get { return _location; }
            set { _location = value; }
        }

        /// <summary>
        /// Obtient ou définit la couleur de la croix
        /// </summary>
        public Color Coleur
        {
            get { return _coleur; }
            set { _coleur = value; }
        }
        #endregion

        #region Constructeur
        /// <summary>
        /// Instancie une nouvelle croix
        /// </summary>
        /// <param name="x">Position x</param>
        /// <param name="y">Position y</param>
        /// <param name="taille">taille de la croix</param>
        public Croix(int x, int y, int taille)
        {
            this.Location = new Point(x, y);
            this.Taille = taille;
            this.Coleur = Color.DarkCyan;
        }

        /// <summary>
        /// Instancie une nouvelle croix en précisant une couleur
        /// </summary>
        /// <param name="x">Position x</param>
        /// <param name="y">Position y</param>
        /// <param name="taille">Taille de la coix</param>
        /// <param name="couleur">Couleur de la croix</param>
        public Croix(int x, int y, int taille, Color couleur) : this(x, y, taille)
        {
            this.Coleur = couleur;
        }
        #endregion

        #region Methodes
        /// <summary>
        /// Dessine la croix
        /// </summary>
        /// <param name="pe">Element graphics</param>
        public void Dessine(PaintEventArgs pe)
        {
            Pen pen = new Pen(this.Coleur, 5);

            pe.Graphics.DrawLine(pen ,this.Location.X, this.Location.Y, this.Location.X + Taille, this.Location.Y + Taille);
            pe.Graphics.DrawLine(pen, this.Location.X + Taille, this.Location.Y, this.Location.X, this.Location.Y + Taille);
        }
        #endregion
    }
}
