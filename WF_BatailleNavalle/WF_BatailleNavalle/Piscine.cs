/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Auteurs    : Alan Devaud
 * Desription : Class de gestion des piscines (Affichage)
 * Date       : 02.12.2015
 * Version    : 1.0
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WF_BatailleNavalle
{
    class Piscine
    {
        #region Champs
        private int _width;
        private int _height;
        private List<Rectangle> _listRects;
        private Point _location;
        #endregion

        #region Proriétés
        /// <summary>
        /// Hauteur de la grille (nombre de carré)
        /// </summary>
        private int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        /// <summary>
        /// Largeur de la grille (nombre de carré)
        /// </summary>
        private int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        /// <summary>
        /// Liste des carrés constituant la grille
        /// </summary>
        private List<Rectangle> ListRects
        {
            get { return _listRects; }
            set { _listRects = value; }
        }

        /// <summary>
        /// Position x, y de la grille
        /// </summary>
        public Point Location
        {
            get { return _location; }
            set { _location = value; }
        }
        #endregion

        #region Constructeur
        /// <summary>
        /// Instancie une nouvelle piscine de taille 10x10
        /// </summary>
        public Piscine()
        {
            this.Width = 10;
            this.Height = 10;
            this.Location = new Point(0, 0);
            this.ListRects = new List<Rectangle>();
            this.InitialisationGrille();
        }
        #endregion

        #region Methodes
        private void InitialisationGrille()
        {
            for (int i = 0; i < this.Width; ++i)
            {
                for (int j = 0; j < this.Height; ++j)
                {
                    this.ListRects.Add(new Rectangle(this.Location.X + 50 * i, this.Location.Y + 50 * j, 50, 50));
                }
            }
        }

        public void Draw(PaintEventArgs pe)
        {
            Pen pen = new Pen(Color.Black);

            foreach(Rectangle rec in this.ListRects)
                pe.Graphics.DrawRectangle(pen, rec);
        }
        #endregion
    }
}
