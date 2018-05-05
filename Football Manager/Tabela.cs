using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Football_Manager
{
    public class Tabela
    {
        public Klub[] kluby { get; set; }

        public Tabela(int iloscDruzyn, Klub[] kluby)
        {
            this.iloscDruzyn = iloscDruzyn;
            this.kluby = new Klub[iloscDruzyn];

            for (int i = 0; i < iloscDruzyn; i++)
                this.kluby[i] = kluby[i];
            for (int i = 0; i < iloscDruzyn; i++)
                kluby[i].ustalMiejsce(i + 1);
        }

        public void wyczysc()
        {
            for (int i = 0; i < iloscDruzyn; i++)
                kluby[i].wyczyscStatystkiLigowe();
        }

        public void sortuj()
        {
            int n = iloscDruzyn;
            do
            {
                for (int i = 0; i < n - 1; i++)
                {
                    if (kluby[i].punkty < kluby[i + 1].punkty)
                    {
                        Klub tmp = kluby[i];
                        kluby[i] = kluby[i + 1];
                        kluby[i + 1] = tmp;
                    }
                    else if (kluby[i].punkty == kluby[i + 1].punkty)
                    {
                        if (kluby[i].goleRoznica < kluby[i + 1].goleRoznica)
                        {
                            Klub tmp = kluby[i];
                            kluby[i] = kluby[i + 1];
                            kluby[i + 1] = tmp;
                        }
                    }
                }
                n--;
            }
            while (n > 1);

            for (int i = 0; i < iloscDruzyn; i++)
            {
                kluby[i].ustalMiejsce(i+1);
            }
        }

        int iloscDruzyn;
    }
}
