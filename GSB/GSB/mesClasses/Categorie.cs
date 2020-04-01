using System;
using System.Collections.Generic;
using System.Text;

namespace GSB
{
    public class Categorie
    {
        public int Id;
        public String libelle;

        public Categorie(int pId, String pLibelle)
        {
            this.libelle = pLibelle;
            this.Id = pId;
         
        }
        public String getLibelle()
        {
            return this.libelle;
        }
        public int getId()
        {
            return this.Id;
        }

        override public string ToString()
        {
            return libelle;
        }
    }

}
