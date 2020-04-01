using System;
using System.Collections.Generic;
using System.Text;

namespace GSB
{
    [Serializable]
    public class AntibioParKilo : Antibio
    {
        
        public int doseKilo;
        public AntibioParKilo(String pLibelle, String pUnite, Categorie pCategorie, int pDoseKilo, int pNombre) : base(pLibelle, pUnite, pCategorie ,pNombre)
        {            
            this.doseKilo = pDoseKilo;
        }
        public int getDoseKilo()
        {
            return this.doseKilo;
        }

    }
}
