/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Auteurs      : Alan Devaud
 * Desription   : Class de gestion des piscines (Affichage)
 * Date         : 02.12.2015
 * Version      : 1.2
 * Modification :
 *                - AD 08.12.2015 : Modification de la taille d'un carré pour avoir un espacement
 *                                  correction du bug de l'affichage quand la souris passe sur un carré.
 *                                  Ajout de l'intéraction avec les cases (Affichage d'une croix).
 *                - AD 16.12.2015 : Modification des noms de variable width et height en nbCaseLargeur et 
 *                                  nbCaseHauteur.    
 *                                  Ajout de la fonction pour calculer la taille de la grille en pixel
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WF_BatailleNavalle
{
    class Piscine
    {
        #region Champs
        private int _nbCaseLargeur;
        private int _nbCaseHauteur;
        private int _largeur;
        private int _hauteur;        
        private List<Case> _listCases;
        private Point _location;
        private const int TAILLE_CASE = 35;
        #endregion

        #region Proriétés
        /// <summary>
        /// Largeur de la grille
        /// </summary>
        public int Largeur
        {
            get { return _largeur; }
            set { _largeur = value; }
        }

        /// <summary>
        /// Hauteur de la grille
        /// </summary>
        public int Hauteur
        {
            get { return _hauteur; }
            set { _hauteur = value; }
        }

        /// <summary>
        /// Hauteur de la grille (nombre de case)
        /// </summary>
        private int NbCaseHauteur
        {
            get { return _nbCaseHauteur; }
            set { _nbCaseHauteur = value; }
        }

        /// <summary>
        /// Largeur de la grille (nombre de case)
        /// </summary>
        private int NbCaseLargeur
        {
            get { return _nbCaseLargeur; }
            set { _nbCaseLargeur = value; }
        }

        /// <summary>
        /// Liste des carrés constituant la grille
        /// </summary>
        private List<Case> ListCases
        {
            get { return _listCases; }
            set { _listCases = value; }
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
            this.NbCaseLargeur = 10;
            this.NbCaseHauteur = 10;
            this.Location = new Point(0, 0);
            this.ListCases = new List<Case>();
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
            this.InitialisationTaille();
        }
        #endregion

        #region Methodes
        /// <summary>
        /// Calcul la taille en pixel par rapport au nombre de carré et à leur taille
        /// </summary>
        private void InitialisationTaille()
        {
            this.Largeur = this.NbCaseLargeur * TAILLE_CASE;
            this.Hauteur = this.NbCaseHauteur * TAILLE_CASE;
        }
        /// <summary>
        /// Initialise chaque case de la grille
        /// </summary>
        private void InitialisationGrille()
        {
            for (int i = 0; i < this.NbCaseLargeur; ++i)
            {
                for (int j = 0; j < this.NbCaseHauteur; ++j)
                {
                    this.ListCases.Add(new Case(this.Location.X + TAILLE_CASE * j, this.Location.Y + TAILLE_CASE * i, TAILLE_CASE - 1));
                }
            }
        }

        /// <summary>
        /// Dessine la piscine
        /// </summary>
        /// <param name="pe">Element graphics</param>
        public void Dessine(PaintEventArgs pe)
        {
            Pen pen = new Pen(Color.Black);
            SolidBrush brush = new SolidBrush(Color.White);

            foreach (Case rec in this.ListCases)
            {
                rec.Dessine(pe);
            }
        }

        /// <summary>
        /// Verifie si la souris est sur un carré
        /// </summary>
        /// <param name="x">Position x de la souris</param>
        /// <param name="y">Position y de la souris</param>
        public void CarreVise(int x, int y)
        {
            foreach (Case rec in this.ListCases)
                rec.Dessu(x, y);
        }

        /// <summary>
        /// Verifie si un carré est touché
        /// </summary>
        /// <param name="x">Position x de la souris</param>
        /// <param name="y">Position y de la souris</param>
        public void CarreTouche(int x, int y)
        {
            foreach (Case rec in this.ListCases)
            {
                if (rec.Toucher(x, y))
                {
                    rec.AjouterCroix();
                }
            }

        }
        #endregion
    }
}
