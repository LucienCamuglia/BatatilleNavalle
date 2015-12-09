/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Auteurs      : Alan Devaud
 * Desription   : Class qui gère un carré
 * Date         : 02.12.2015
 * Version      : 1.1
 * Modification :
 *                - AD 08.12.2015 : Ajout de la croix
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
        private Croix _croix;
        private const int TAILLE_CROIX = 30;
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

        /// <summary>
        /// Obtient ou définit la croix
        /// </summary>
        public Croix Croix
        {
            get { return _croix; }
            set { _croix = value; }
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
            this.Croix = null;
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

            if (this.Croix != null)
            {
                Croix.Dessine(pe);
            }
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

        /// <summary>
        /// Vérifie si le carré est touché et qu'il n'y a pas de croix
        /// </summary>
        /// <param name="x">Position x de la souris</param>
        /// <param name="y">Position y de la souris</param>
        /// <returns></returns>
        public bool Toucher(int x, int y)
        {
            if ((x >= this.Rectangle.X) && (x <= this.Rectangle.X + this.Rectangle.Width) && (y >= this.Rectangle.Y) && (y <= this.Rectangle.Y + this.Rectangle.Height) && (this.Croix == null))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Ajout une croix sur le carré
        /// </summary>
        public void AjouterCroix()
        {
            this.Croix = new Croix(this.Rectangle.X + 10, this.Rectangle.Y + 10, TAILLE_CROIX);
        }
        #endregion
    }
}
