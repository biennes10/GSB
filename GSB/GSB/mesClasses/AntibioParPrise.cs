using System;
using System.Collections.Generic;
using System.Text;

namespace GSB
{
    [Serializable]
    public class AntibioParPrise : Antibio
    {
        public int dosePrise;
       
        public AntibioParPrise(String pLibelle, String pUnite, Categorie pCategorie, int pDosePrise, int pNombre) : base(pLibelle, pUnite, pCategorie, pNombre)
        {
            
            this.dosePrise = pDosePrise;
           
        }
        public int getDosePrise()
        {
            return this.dosePrise;
        }
        

    }
}
