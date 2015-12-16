/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Auteurs      : Alan Devaud
 * Desription   : Class pour la gestion des strings d'information
 * Date         : 16.12.2015
 * Version      : 1.0
 * Modification : /
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using System.Drawing;
using System.Windows.Forms;

namespace WF_BatailleNavalle
{
    class StringInformations
    {
        #region Champs
        private Point _location;
        private Font _font;
        private SolidBrush _brush;
        private StringFormat _format;
        private string _contenu;
        private const int TAILLE_FONT = 12;
        #endregion

        #region Propriétés
        /// <summary>
        /// Obtient ou définit la position X et Y du stringInformations
        /// </summary>
        public Point Location
        {
            get { return _location; }
            set { _location = value; }
        }

        /// <summary>
        /// Obtient ou définit la font du texte
        /// </summary>
        public Font Font
        {
            get { return _font; }
            set { _font = value; }
        }

        /// <summary>
        /// Obtient ou définit le brush
        /// </summary>
        public SolidBrush Brush
        {
            get { return _brush; }
            set { _brush = value; }
        }

        /// <summary>
        /// Obtient ou définit le format du texte
        /// </summary>
        public StringFormat Format
        {
            get { return _format; }
            set { _format = value; }
        }

        /// <summary>
        /// Obtient ou définit le contenu du stringInformations (Texte affiché)
        /// </summary>
        public string Contenu
        {
            get { return _contenu; }
            set { _contenu = value; }
        }
        #endregion

        #region Constructeur
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contenu"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public StringInformations(string contenu, int x, int y)
        {
            this.Contenu = contenu;
            this.Location = new Point(x, y);
            this.Brush = new SolidBrush(Color.Black);
            this.Format = new StringFormat();
            this.Font = new Font("Arial", TAILLE_FONT);
        }
        #endregion

        #region Methodes
        public void Dessine(PaintEventArgs pe)
        {
            pe.Graphics.DrawString(this.Contenu, this.Font, this.Brush, this.Location, this.Format);
        }
        #endregion
    }
}
