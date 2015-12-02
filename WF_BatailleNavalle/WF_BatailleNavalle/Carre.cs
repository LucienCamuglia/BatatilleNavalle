/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Auteurs    : Alan Devaud
 * Desription : Class qui gère un carré
 * Date       : 02.12.2015
 * Version    : 1.0
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using System.Drawing;
using System.Windows.Forms;

namespace WF_BatailleNavalle
{
    class Carre
    {
        #region Champs
        private Rectangle _rectangle;
        private Color _color;
        private Color _bordure;
        #endregion

        #region Propriétés
        /// <summary>
        /// Obtient ou définit le rectangle
        /// </summary>
        public Rectangle Rectangle
        {
            get { return _rectangle; }
            set { _rectangle = value; }
        }

        /// <summary>
        /// Obtient ou définit la couleur de fond
        /// </summary>
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        /// <summary>
        /// Obtient ou définit la couleur de la bordure
        /// </summary>
        public Color Bordure
        {
            get { return _bordure; }
            set { _bordure = value; }
        }
        #endregion

        #region Constructeur
        /// <summary>
        /// Instancie un nouveau carré avec une position x, y et une taille
        /// </summary>
        /// <param name="x">Position X</param>
        /// <param name="y">Position Y</param>
        /// <param name="taille">Taille</param>
        public Carre(int x, int y, int taille)
        {
            this.Rectangle = new Rectangle(x, y, taille, taille);
            this.Color = Color.White;
            this.Bordure = Color.Black;
        }

        /// <summary>
        /// Instancie un nouveau carré avec une position x, y, une taille et une couleur
        /// </summary>
        /// <param name="x">Position X</param>
        /// <param name="y">Position Y</param>
        /// <param name="taille">Taille</param>
        /// <param name="color">Couleur de fond</param>
        public Carre(int x, int y, int taille, Color color)
            : this(x, y, taille)
        {
            this.Color = color;
        }
        #endregion

        #region Methodes
        /// <summary>
        /// Dessine le carre
        /// </summary>
        /// <param name="pe">Elements graphique</param>
        public void Dessine(PaintEventArgs pe)
        {
            Pen pen = new Pen(this.Bordure);
            SolidBrush brush = new SolidBrush(this.Color);

            pe.Graphics.FillRectangle(brush, this.Rectangle);
            pe.Graphics.DrawRectangle(pen, this.Rectangle);
        }

        /// <summary>
        /// Modifie la couleur de la bordure si la souris est dessu
        /// </summary>
        /// <param name="x">Position X de la souris</param>
        /// <param name="y">Poisition Y de la souris</param>
        public void Dessu(int x, int y)
        {
            if ((x >= this.Rectangle.X) && (x <= this.Rectangle.X + this.Rectangle.Width) && (y >= this.Rectangle.Y) && (y <= this.Rectangle.Y + this.Rectangle.Height))
            {
                this.Bordure = Color.Red;
            }
            else
            {
                this.Bordure = Color.Black;
            }
        }
        #endregion
    }
}
