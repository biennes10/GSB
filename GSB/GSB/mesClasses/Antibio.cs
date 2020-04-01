using System;
using System.Collections.Generic;
using System.Text;

namespace GSB
{
    [Serializable]
    public abstract class Antibio
    {
        public String libelle;
        public  String unite;
        public Categorie laCategorie;
        public int nombreParJour;
        public Antibio(String pLibelle, String pUnite, Categorie pCategorie, int pNombre)
        {
            this.libelle = pLibelle;
            this.unite = pUnite;
            this.laCategorie = pCategorie;
            this.nombreParJour = pNombre;
        }
        public String getLibelle()
        {
            return this.libelle;
        }
        public String getUnite()
        {
            return this.unite;
        }
        public Categorie getCategorie()
        {
            return this.laCategorie;
        }

        public int getNombre()
        {
            return this.nombreParJour;
        }

        public override string ToString()
        {
            return libelle;
        }
    }
}
