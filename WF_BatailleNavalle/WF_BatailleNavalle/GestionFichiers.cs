/** * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 * Autheur : Lucien Camuglia                                                      *
 * Date    : 2015.12.02                                                           *
 * Description : Permet de lire et écrire dans le fichier de jeu                  *
 * Version : 1.0 LC Version de base                                               *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * **/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_BatailleNavalle
{
    static class GestionFichiers
    {
        #region champs
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
        static public bool PeutJouer() {
            if (File.Exists(Path.GetFileName(NomFichier)+".lock")) {
            
            }
            return true;
            
        }
        static public int[,] LireAireDeJeu(string player) {
            int[,] tableau = new int[10, 10];

            return tableau;
        }
        #endregion

    }
}
