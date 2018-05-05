using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Football_Manager
{
    public class Liga
    {
        public static Liga instancja { get; set; }

        public string nazwa { get; private set; }
        public string sezon { get; private set; }
        public int nrKolejki { get; private set; }
        public int iloscKolejek { get; private set; }
        public Kolejka[] kolejki { get; private set; }

        public int iloscDruzyn { get; private set; }
        public Klub druzynaGracza { get; private set; }
        public Klub[] druzyny { get; private set; }
        public Tabela tabelaLigowa { get; private set; }

        public Liga(int iloscDruzyn, Klub[] druzyny, Klub druzyna, string sezon, int nrKolejki)
        {
            nazwa = "1. liga";
            this.sezon = sezon;
            this.nrKolejki = nrKolejki;
            this.iloscDruzyn = iloscDruzyn;
            this.druzyny = druzyny;
            this.druzynaGracza = druzyna;

            iloscKolejek = (iloscDruzyn - 1) * 2;
            nrKolejki = 0;
            kolejki = new Kolejka[iloscKolejek];
            for (int i = 0; i < iloscKolejek; i++)
                kolejki[i] = new Kolejka(this, i);

            tabelaLigowa = new Tabela(iloscDruzyn, druzyny);

            sprawdzMiejsce();

            for (int k = 0; k < iloscDruzyn; k++)
            {
                for (int j = 0; j < iloscKolejek; j++)
                {
                    for (int i = 0; i < Kolejka.iloscMeczow; i++)
                    {
                        if (druzyny[k].nazwa == kolejki[j].mecze[i].gospodarz.nazwa || druzyny[k].nazwa == kolejki[j].mecze[i].gosc.nazwa)
                            druzyny[k].mecze[j] = kolejki[j].mecze[i];
                    }
                }
            }
        }

        public void rozegrajKolejke()
        {
            if (nrKolejki < iloscKolejek)
            {
                kolejki[nrKolejki].rozegraj();
                nrKolejki++;
                sprawdzMiejsce();
            }
        }

        public void uaktualnijStatystyki()
        {
            kolejki[nrKolejki - 1].uaktualnijStatystyki();
        }

        public void wyczyscStatystykiLigowe()
        {
            for (int i = 0; i < iloscDruzyn; i++)
                druzyny[i].wyczyscStatystkiLigowe();
        }

        public int sprawdzMiejsce()
        {
            tabelaLigowa.sortuj();
            for (int i = 0; i < iloscDruzyn; i++)
            {
                if (druzynaGracza == tabelaLigowa.kluby[i])
                    return tabelaLigowa.kluby[i].miejsce;
            }
            return -1;
        }

        public string sprawdzOstatnie5Meczow()
        {
            string forma = "";

            for (int j = 0; j < 5; j++)
            {
                if ((nrKolejki - 1 - j) >= 0)
                {
                    if (druzynaGracza == druzynaGracza.mecze[nrKolejki - 1 - j].gospodarz)
                    {
                        if (druzynaGracza.mecze[nrKolejki - 1 - j].punktyGospodarz == 3) forma += "Z";
                        if (druzynaGracza.mecze[nrKolejki - 1 - j].punktyGospodarz == 1) forma += "R";
                        if (druzynaGracza.mecze[nrKolejki - 1 - j].punktyGospodarz == 0) forma += "P";
                    }
                    if (druzynaGracza == druzynaGracza.mecze[nrKolejki - 1 - j].gosc)
                    {
                        if (druzynaGracza.mecze[nrKolejki - 1 - j].punktyGosc == 3) forma += "Z";
                        if (druzynaGracza.mecze[nrKolejki - 1 - j].punktyGosc == 1) forma += "R";
                        if (druzynaGracza.mecze[nrKolejki - 1 - j].punktyGosc == 0) forma += "P";
                    }
                }
            }
            return forma;
        }

        public Mecz sprawdzPoprzedniMecz()
        {
            if (nrKolejki - 1 >= 0) return druzynaGracza.mecze[nrKolejki - 1];
            else return null;
        }

        public Mecz sprawdzNastepnyMecz()
        {
           if (nrKolejki < iloscKolejek) return druzynaGracza.mecze[nrKolejki];
           else return null;
        }
    }
}
