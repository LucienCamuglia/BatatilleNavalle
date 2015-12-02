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
        private List<Carre> _listRects;
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
        private List<Carre> ListRects
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
            this.ListRects = new List<Carre>();
            //this.InitialisationGrille();
        }

        /// <summary>
        /// Instancie une nouvelle piscine de taille 10x10 à une position donné
        /// </summary>
        /// <param name="posX">Position X</param>
        /// <param name="posY">Position Y</param>
        public Piscine(int posX, int posY)
            : this()
        {
            this.Location = new Point(posX, posY);
            this.InitialisationGrille();
        }
        #endregion

        #region Methodes
        /// <summary>
        /// Initialise chaque carré de la grille
        /// </summary>
        private void InitialisationGrille()
        {
            for (int i = 0; i < this.Width; ++i)
            {
                for (int j = 0; j < this.Height; ++j)
                {
                    this.ListRects.Add(new Carre(this.Location.X + 50 * j, this.Location.Y + 50 * i, 50));
                }
            }

            this.ListRects[2].Color = Color.Blue;
        }

        /// <summary>
        /// Dessine la piscine
        /// </summary>
        /// <param name="pe">Element graphics</param>
        public void Dessine(PaintEventArgs pe)
        {
            Pen pen = new Pen(Color.Black);
            SolidBrush brush = new SolidBrush(Color.White);
            
            foreach (Carre rec in this.ListRects)
            {
                rec.Dessine(pe);
            }

        }

        public void CarreVise(int x, int y)
        {
            foreach (Carre rec in this.ListRects)
                rec.Dessu(x, y);
        }
        #endregion
    }
}
