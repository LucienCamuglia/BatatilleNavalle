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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WF_BatailleNavalle
{
    static class GestionFichiers
    {
        #region champs
        private const string REGEXJOUEURS = @"P\d;(\w+)";
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
            //var Source = Properties.Resources.reference;
            System.IO.File.Copy("./properties/reference.bnav", CHEMIN + NomFichier + EXTENSION, true);
            //fichier.Close();

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

        /// <summary>
        /// Lecture des joueurs depuis le fichier XML
        /// </summary>
        /// <returns> Liste de joueurs </returns>
        static public List<string> LireJoueurs()
        {
            List<String> joueurs = new List<string>();
            string JoueurTexte = "";
            XmlDocument document = new XmlDocument();
            FileStream stream;
            XmlElement root;
            XmlNodeList XmlJoueurs;
            IEnumerator ienum;

            //ouvre le fichier XML
            stream = File.Open(CHEMIN + NomFichier + EXTENSION, FileMode.Open);
            //charge le fichier XML
            document.Load(stream);
            //Défini le root du fichier XML
            root = document.DocumentElement;
            //Défini les élèments a récupèrer
            XmlJoueurs = root.GetElementsByTagName("JOUEURS");
            //Récupère toutes les valeurs
            ienum = XmlJoueurs.GetEnumerator();

            //extrai chaque valeurs aux format texte
            while (ienum.MoveNext())
            {
                XmlNode joueur = (XmlNode)ienum.Current;
                JoueurTexte += joueur.InnerText;
            }

            //défini l'expression régulière
            Regex r = new Regex(REGEXJOUEURS);
            //extrait les valeurs selon l'expréssion regulière
            foreach (Match m in r.Matches(JoueurTexte))
            {
                joueurs.Add((m.Groups[1]).ToString());
            }

            return joueurs;
        }

        static public List<string> LirePlateaux()
        {
            List<String> joueurs = new List<string>();
            string JoueurTexte = "";
            XmlDocument document = new XmlDocument();
            FileStream stream;
            XmlElement root;
            XmlNodeList XmlJoueurs;
            IEnumerator ienum;

            //ouvre le fichier XML
            stream = File.Open(CHEMIN + NomFichier + EXTENSION, FileMode.Open);
            //charge le fichier XML
            document.Load(stream);
            //Défini le root du fichier XML
            root = document.DocumentElement;
            //Défini les élèments a récupèrer
            XmlJoueurs = root.GetElementsByTagName("JOUEURS");
            //Récupère toutes les valeurs
            ienum = XmlJoueurs.GetEnumerator();

            //extrai chaque valeurs aux format texte
            while (ienum.MoveNext())
            {
                XmlNode joueur = (XmlNode)ienum.Current;
                JoueurTexte += joueur.InnerText;
            }

            //défini l'expression régulière
            Regex r = new Regex(REGEXJOUEURS);
            //extrait les valeurs selon l'expréssion regulière
            foreach (Match m in r.Matches(JoueurTexte))
            {
                joueurs.Add((m.Groups[1]).ToString());
            }

            return joueurs;
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





        #endregion

    }
}
