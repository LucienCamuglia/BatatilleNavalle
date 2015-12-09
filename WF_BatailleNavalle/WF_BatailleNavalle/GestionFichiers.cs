/** * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 * Autheur : Lucien Camuglia                                                      *
 * Date    : 2015.12.02                                                           *
 * Description : Permet de lire et écrire dans le fichier de jeu                  *
 * Version : 1.0 LC Version de base                                               *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * **/
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WF_BatailleNavalle
{
    static class GestionFichiers
    {
        #region champs
        private const string LOCK = ".lock";
        private const string EXTENSION = ".bnav";
        private const string CHEMIN = "C:\\BnShare\\";
        static bool _lock;
        static string _nomFichier;
        #endregion
        #region proprietes
        static public bool Lock
        {
            get { return _lock; }
            set { _lock = value; }
        }

        static public string NomFichier
        {
            get { return _nomFichier; }
            set { _nomFichier = value; }
        }
        #endregion
        #region methodes
        /// <summary>
        /// Crée le fichier à la date et l'heure actuelle et stocke le nom dans le champs _nomfichier
        /// </summary>
        static public void CreeFichier()
        {
            NomFichier = "BN-V01-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");

            FileStream fichier = File.Create(CHEMIN + NomFichier + EXTENSION);
            fichier.Close();

        }



        /// <summary>
        /// Teste si le fichier est vérouillé
        /// </summary>
        /// <returns>Vrai ou faux</returns>
        static public bool PeutJouer()
        {
            if (File.Exists(NomFichier + LOCK))
            {
                return false;
            }
            return true;

        }



        /**************************************************PAS FINI****************************************************************************/
        /// <summary>
        /// Lecture de l'aire de jeu en fonction du joueur 
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        static public int[,] LireAireDeJeu(string player)
        {
            int[,] tableau = new int[10, 10];

            return tableau;
        }


        /// <summary>
        /// Lecture des joueurs depuis le fichier XML
        /// </summary>
        /// <returns> Liste de joueurs </returns>
        static public List<string> LireJoueurs()
        {
            List<String> joueurs = new List<string>();
            try
            {
                XmlDocument document = new XmlDocument();

                XmlDeclaration xmldecl;
                xmldecl = document.CreateXmlDeclaration("1.0", null, null);
                xmldecl.Encoding = "UTF-8";
                xmldecl.Standalone = "yes";

                FileStream stream = File.Open(CHEMIN + NomFichier + EXTENSION, FileMode.Open, FileAccess.Read, FileShare.Read);
                document.Load(stream);
                XmlElement root = document.DocumentElement;
                XmlNodeList XmlJoueurs = root.GetElementsByTagName("JOUEURS");
                IEnumerator ienum = XmlJoueurs.GetEnumerator();

                while (ienum.MoveNext())
                {
                    XmlNode joueur = (XmlNode)ienum.Current;
                    string JoueurTexte = joueur.InnerText;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return joueurs;

        }
        #endregion

    }
}
