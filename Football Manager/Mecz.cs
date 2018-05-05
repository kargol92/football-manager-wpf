using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Football_Manager
{
    public enum StanMeczu { nierozpoczety, rozgrywany, zakonczony }

    public class Mecz
    {
        public static Mecz ostatnioRozegranyMecz { get; set; }

        public StanMeczu stanMeczu { get; private set; }
        public Klub gospodarz { get; private set; }
        public Klub gosc { get; private set; }
        public string sezon { get; private set; }
        public int kolejka { get; private set; }

        public string druzyny { get; private set; }
        public string wynik { get; private set; }
        public string druzynyWynik { get; private set; }
        public int punktyGospodarz { get; private set; }
        public int punktyGosc { get; private set; }
        public int goleGospodarz { get; private set; }
        public int goleGosc { get; private set; }
        public int posiadaniePilkiGospodarz { get; private set; }
        public int posiadaniePilkiGosc { get; private set; }
        public int iloscAkcjiGospodarz { get; private set; }
        public int iloscAkcjiGosc { get; private set; }
        public int skutecznoscAtakuGospodarz { get; private set; }
        public int skutecznoscAtakuGosc { get; private set; }

        public Akcja[] akcje { get; private set; }
        public Pilkarz[] gospodarz11 { get; private set; }
        public Pilkarz[] gosc11 { get; private set; } 
        public List<Zdarzenie> zdarzeniaGospodarz { get; private set; }
        public List<Zdarzenie> zdarzeniaGosc { get; private set; }

        public Mecz(Klub gospodarz, Klub gosc) // MECZ TOWARZYSKI
        {
            stanMeczu = StanMeczu.nierozpoczety;
            this.gospodarz = gospodarz;
            this.gosc = gosc;

            druzyny = this.gospodarz.nazwa + " - " + this.gosc.nazwa;
            wynik = "  -  ";
            druzynyWynik = this.gospodarz.nazwa + "   -   " + this.gosc.nazwa;
            posiadaniePilkiGospodarz = 50;
            posiadaniePilkiGosc = 50;

            zdarzeniaGospodarz = new List<Zdarzenie>();
            zdarzeniaGosc = new List<Zdarzenie>();
            akcje = new Akcja[90];
        }

        public Mecz(Klub gospodarz, Klub gosc, string sezon, int kolejka) // MECZ LIGOWY
        {
            stanMeczu = StanMeczu.nierozpoczety;
            if (kolejka % 2 == 0)
            {
                this.gospodarz = gospodarz;
                this.gosc = gosc;
            }
            else if (kolejka % 2 == 1)
            {
                this.gospodarz = gosc;
                this.gosc = gospodarz;
            }
            else
            {
                this.gospodarz = gospodarz;
                this.gosc = gosc;
            }
            this.sezon = sezon;
            this.kolejka = kolejka + 1;
            druzyny = this.gospodarz.nazwa + " - " + this.gosc.nazwa;
            wynik = "  -  ";
            druzynyWynik = this.gospodarz.nazwa + "   -   " + this.gosc.nazwa;
            posiadaniePilkiGospodarz = 50;
            posiadaniePilkiGosc = 50;

            zdarzeniaGospodarz = new List<Zdarzenie>();
            zdarzeniaGosc = new List<Zdarzenie>();
            akcje = new Akcja[90];
        }

        public Mecz(Klub gospodarz, Klub gosc, string stanMeczu, int goleGospodarz, int goleGosc, string sezon, int kolejka) // WCZYTANIE MECZU LIGOWEGO
        {
            if (stanMeczu == "nierozpoczety")
                this.stanMeczu = StanMeczu.nierozpoczety;
            else if (stanMeczu == "zakonczony")
                this.stanMeczu = StanMeczu.zakonczony;

            this.gospodarz = gospodarz;
            this.gosc = gosc;
            this.sezon = sezon;
            this.kolejka = kolejka;

            this.goleGospodarz = goleGospodarz;
            this.goleGosc = goleGosc;

            if (goleGospodarz >  goleGosc) { punktyGospodarz = 3; punktyGosc = 0; }
            if (goleGospodarz == goleGosc) { punktyGospodarz = 1; punktyGosc = 1; }
            if (goleGospodarz <  goleGosc) { punktyGospodarz = 0; punktyGosc = 3; }

            if (this.stanMeczu == StanMeczu.nierozpoczety)
            {
                wynik = "  -  ";
                druzyny = this.gospodarz.nazwa + " - " + this.gosc.nazwa;
                druzynyWynik = this.gospodarz.nazwa + "   -   " + this.gosc.nazwa;
            }
            else if (this.stanMeczu == StanMeczu.zakonczony)
            {
                wynik = goleGospodarz + " - " + goleGosc;
                druzyny = this.gospodarz.nazwa + " - " + this.gosc.nazwa;
                druzynyWynik = this.gospodarz.nazwa + " " + goleGospodarz + " - " + goleGosc + " " + this.gosc.nazwa;
            }

            zdarzeniaGospodarz = new List<Zdarzenie>();
            zdarzeniaGosc = new List<Zdarzenie>();
            akcje = new Akcja[90];
        }

        public void wyczysc() // WYKORZYSTYWANE W TRYBIE MENEDZERA
        {
            stanMeczu = StanMeczu.nierozpoczety;
            wynik = "  -  ";

            punktyGospodarz = 0;
            punktyGosc = 0;
            goleGospodarz = 0;
            goleGosc = 0;
            posiadaniePilkiGospodarz = 50;
            posiadaniePilkiGosc = 50;
            iloscAkcjiGospodarz = 0;
            iloscAkcjiGosc = 0;
            skutecznoscAtakuGospodarz = 0;
            skutecznoscAtakuGosc = 0;

            zdarzeniaGospodarz = new List<Zdarzenie>();
            zdarzeniaGosc = new List<Zdarzenie>();
            akcje = new Akcja[90];
        }

        public void rozegrajBezRelacji() // WYKORZYSTYWANE W TRYBIE MENEDŻERA DLA MECZÓW INNYCH DRUŻYN W LIDZE
        {
            for (int i = 0; i < 90; i++)
                rozegrajAkcje(i);
        }

        public void zakoncz()
        {
            stanMeczu = StanMeczu.zakonczony;
            if (goleGospodarz >  goleGosc) { punktyGospodarz = 3; punktyGosc = 0; }
            if (goleGospodarz == goleGosc) { punktyGospodarz = 1; punktyGosc = 1; }
            if (goleGospodarz <  goleGosc) { punktyGospodarz = 0; punktyGosc = 3; }
            wynik = goleGospodarz + " - " + goleGosc;
            druzynyWynik = gospodarz.nazwa + " " + goleGospodarz + " - " + goleGosc + " " + gosc.nazwa;
        }

        public void rozegrajAkcje(int minuta)
        {
            akcje[minuta] = new Akcja(minuta);

            if (minuta == 0)
            {
                stanMeczu = StanMeczu.rozgrywany;
                uzupelnijKomentarze();
                uaktualnijWyjsciowa11();
                obliczRoznicePoziomow();
                obliczSzanseNaRzutKarny();
                obliczRoznicePoziomowBramkarzWykonawacaKarnego();

                akcje[minuta].dodajKomentarz(rozpoczecieMeczu[generator.Next(rozpoczecieMeczu.Count)] + " ");
            }
            if (minuta == 45)
                akcje[minuta].dodajKomentarz(rozpoczecie2Polowy[generator.Next(rozpoczecie2Polowy.Count)] + " ");
            if (minuta >= 0 && minuta < 90)
            {
                if (generator.Next(100) <= posiadaniePilkiGospodarzOgolnie)
                {
                    akcje[minuta].ustalPilkePosiadaGospodarz(true);
                    druzynaAtakujaca = gospodarz;
                    druzynaBroniaca = gosc;
                    iloscAkcjiGospodarz++;

                    if (generator.Next(1000) <= skutecznoscAtakuGospodarzOgolnie)
                    {
                        goleGospodarz++;
                        nr = generator.Next(1, 11);
                        zdarzeniaGospodarz.Add(new Zdarzenie(druzynaAtakujaca.pilkarze[nr], minuta + 1, RodzajZdarzenia.gol));
                        uzupelnijKomentarze();
                        akcje[minuta].dodajKomentarz(gol[generator.Next(gol.Count)] + " ");
                    }
                    if (generator.Next(szansaNaRzutKarnyGospodarz) == 0)
                    {
                        nr = generator.Next(1, 11);
                        zdarzeniaGospodarz.Add(new Zdarzenie(druzynaAtakujaca.pilkarze[nr], minuta + 1, RodzajZdarzenia.rzutKarny));
                        uzupelnijKomentarze();
                        akcje[minuta].dodajKomentarz(rzutKarny[generator.Next(rzutKarny.Count)] + " ");

                        if (generator.Next(100) <= skutecznoscRzutuKarnegoGospodarz)
                        {
                            goleGospodarz++;
                            zdarzeniaGospodarz.Add(new Zdarzenie(druzynaAtakujaca.pilkarze[druzynaAtakujaca.staleFragmentyGry], minuta + 1, RodzajZdarzenia.gol));
                            akcje[minuta].dodajKomentarz(rzutKarnyGol[generator.Next(rzutKarnyGol.Count)] + " ");
                        }
                        else
                            akcje[minuta].dodajKomentarz(rzutKarnyNieGol[generator.Next(rzutKarnyNieGol.Count)] + " ");
                    }
                }
                else
                {
                    akcje[minuta].ustalPilkePosiadaGospodarz(false);
                    druzynaAtakujaca = gosc;
                    druzynaBroniaca = gospodarz;
                    iloscAkcjiGosc++;

                    if (generator.Next(1000) <= skutecznoscAtakuGoscOgolnie)
                    {
                        goleGosc++;
                        nr = generator.Next(1, 11);
                        zdarzeniaGosc.Add(new Zdarzenie(druzynaAtakujaca.pilkarze[nr], minuta + 1, RodzajZdarzenia.gol));
                        uzupelnijKomentarze();
                        akcje[minuta].dodajKomentarz(gol[generator.Next(gol.Count)] + " ");
                    }
                    if (generator.Next(szansaNaRzutKarnyGosc) == 0)
                    {
                        nr = generator.Next(1, 11);
                        zdarzeniaGosc.Add(new Zdarzenie(druzynaAtakujaca.pilkarze[nr], minuta + 1, RodzajZdarzenia.rzutKarny));
                        uzupelnijKomentarze();
                        akcje[minuta].dodajKomentarz(rzutKarny[generator.Next(rzutKarny.Count)] + " ");

                        if (generator.Next(100) <= skutecznoscRzutuKarnegoGosc)
                        {
                            goleGosc++;
                            zdarzeniaGosc.Add(new Zdarzenie(druzynaAtakujaca.pilkarze[druzynaAtakujaca.staleFragmentyGry], minuta + 1, RodzajZdarzenia.gol));
                            akcje[minuta].dodajKomentarz(rzutKarnyGol[generator.Next(rzutKarnyGol.Count)] + " ");
                        }
                        else
                            akcje[minuta].dodajKomentarz(rzutKarnyNieGol[generator.Next(rzutKarnyNieGol.Count)] + " ");
                    }
                }

                posiadaniePilkiGospodarz = (int)(iloscAkcjiGospodarz / (double)(minuta + 1) * 100);
                posiadaniePilkiGosc = 100 - posiadaniePilkiGospodarz;
                if (iloscAkcjiGospodarz > 0)
                    skutecznoscAtakuGospodarz = (int)(goleGospodarz / (double)iloscAkcjiGospodarz * 100);
                if (iloscAkcjiGosc > 0)
                    skutecznoscAtakuGosc = (int)(goleGosc / (double)iloscAkcjiGosc * 100);

                wynik = goleGospodarz + " - " + goleGosc;
            }
            if (minuta == 44)
            {
                uzupelnijKomentarze();
                akcje[minuta].dodajKomentarz(zakonczeniePolowy[generator.Next(zakonczeniePolowy.Count)] + ". ");
                akcje[minuta].dodajKomentarz(posiadaniePilki[generator.Next(posiadaniePilki.Count)]);
            }
            if (minuta == 89)
            {
                uzupelnijKomentarze();
                akcje[minuta].dodajKomentarz(zakonczenieMeczu[generator.Next(zakonczenieMeczu.Count)] + ". ");
                akcje[minuta].dodajKomentarz(posiadaniePilki[generator.Next(posiadaniePilki.Count)]);
                zakoncz();
            }
        }




        public int roznicaPomoc;
        public int roznicaAtakGospodarzObronaGosc;
        public int roznicaAtakGoscObronaGospodarz;
        int posiadaniePilkiGospodarzOgolnie;
        int posiadaniePilkiGoscOgolnie;
        double skutecznoscAtakuGospodarzOgolnie;
        double skutecznoscAtakuGoscOgolnie;

        int szansaNaRzutKarnyGospodarz;
        int szansaNaRzutKarnyGosc;
        int roznicaWykonawcaGospodarzBramkarzGosc;
        int roznicaWykonawcaGoscBramkarzGospodarz;
        int skutecznoscRzutuKarnegoGospodarz;
        int skutecznoscRzutuKarnegoGosc;

        // do relacji
        Klub druzynaAtakujaca;
        Klub druzynaBroniaca;
        int nr;
        static Random generator = new Random();
        //List<string> wynikMeczu;
        List<string> posiadaniePilki;
        List<string> rozpoczecieMeczu;
        List<string> zakonczeniePolowy;
        List<string> rozpoczecie2Polowy;
        List<string> zakonczenieMeczu;
        List<string> rzutKarny;
        List<string> rzutKarnyGol;
        List<string> rzutKarnyNieGol;
        List<string> gol;

        void uaktualnijWyjsciowa11()
        {
            gospodarz11 = new Pilkarz[11];
            gosc11 = new Pilkarz[11];
            for (int i = 0; i < 11; i++)
            {
                gospodarz11[i] = gospodarz.pilkarze[i];
                gosc11[i] = gosc.pilkarze[i];
            }
        }

        void obliczRoznicePoziomow()
        {
            roznicaPomoc = (gospodarz.pomoc - gosc.pomoc) / 10;
            roznicaAtakGospodarzObronaGosc = (gospodarz.atak - gosc.obrona) / 10;
            roznicaAtakGoscObronaGospodarz = (gosc.atak - gospodarz.obrona) / 10;

            // OBLICZANIE OGÓLNEGO POSIADANIA PIŁKI DLA GOSPODARZA W PROCENTACH
            if (roznicaPomoc == -9) { posiadaniePilkiGospodarzOgolnie = 15; }
            if (roznicaPomoc == -8) { posiadaniePilkiGospodarzOgolnie = 19; }
            if (roznicaPomoc == -7) { posiadaniePilkiGospodarzOgolnie = 23; }
            if (roznicaPomoc == -6) { posiadaniePilkiGospodarzOgolnie = 27; }
            if (roznicaPomoc == -5) { posiadaniePilkiGospodarzOgolnie = 31; }
            if (roznicaPomoc == -4) { posiadaniePilkiGospodarzOgolnie = 35; }
            if (roznicaPomoc == -3) { posiadaniePilkiGospodarzOgolnie = 39; }
            if (roznicaPomoc == -2) { posiadaniePilkiGospodarzOgolnie = 43; }
            if (roznicaPomoc == -1) { posiadaniePilkiGospodarzOgolnie = 47; }
            if (roznicaPomoc ==  0) { posiadaniePilkiGospodarzOgolnie = 50; }
            if (roznicaPomoc ==  1) { posiadaniePilkiGospodarzOgolnie = 53; }
            if (roznicaPomoc ==  2) { posiadaniePilkiGospodarzOgolnie = 57; }
            if (roznicaPomoc ==  3) { posiadaniePilkiGospodarzOgolnie = 61; }
            if (roznicaPomoc ==  4) { posiadaniePilkiGospodarzOgolnie = 65; }
            if (roznicaPomoc ==  5) { posiadaniePilkiGospodarzOgolnie = 69; }
            if (roznicaPomoc ==  6) { posiadaniePilkiGospodarzOgolnie = 73; }
            if (roznicaPomoc ==  7) { posiadaniePilkiGospodarzOgolnie = 77; }
            if (roznicaPomoc ==  8) { posiadaniePilkiGospodarzOgolnie = 81; }
            if (roznicaPomoc ==  9) { posiadaniePilkiGospodarzOgolnie = 85; }
            
            posiadaniePilkiGoscOgolnie = 100 - posiadaniePilkiGospodarzOgolnie;

            // OBLICZANIE SKUTECZNOSCI ATAKU GOSPODARZA W PROMILACH
            if (roznicaAtakGospodarzObronaGosc == -9) skutecznoscAtakuGospodarzOgolnie = 1;
            if (roznicaAtakGospodarzObronaGosc == -8) skutecznoscAtakuGospodarzOgolnie = 3;
            if (roznicaAtakGospodarzObronaGosc == -7) skutecznoscAtakuGospodarzOgolnie = 5;
            if (roznicaAtakGospodarzObronaGosc == -6) skutecznoscAtakuGospodarzOgolnie = 8;
            if (roznicaAtakGospodarzObronaGosc == -5) skutecznoscAtakuGospodarzOgolnie = 10;
            if (roznicaAtakGospodarzObronaGosc == -4) skutecznoscAtakuGospodarzOgolnie = 12;
            if (roznicaAtakGospodarzObronaGosc == -3) skutecznoscAtakuGospodarzOgolnie = 15;
            if (roznicaAtakGospodarzObronaGosc == -2) skutecznoscAtakuGospodarzOgolnie = 18;
            if (roznicaAtakGospodarzObronaGosc == -1) skutecznoscAtakuGospodarzOgolnie = 20;
            if (roznicaAtakGospodarzObronaGosc ==  0) skutecznoscAtakuGospodarzOgolnie = 23;
            if (roznicaAtakGospodarzObronaGosc ==  1) skutecznoscAtakuGospodarzOgolnie = 27;
            if (roznicaAtakGospodarzObronaGosc ==  2) skutecznoscAtakuGospodarzOgolnie = 30;
            if (roznicaAtakGospodarzObronaGosc ==  3) skutecznoscAtakuGospodarzOgolnie = 35;
            if (roznicaAtakGospodarzObronaGosc ==  4) skutecznoscAtakuGospodarzOgolnie = 40;
            if (roznicaAtakGospodarzObronaGosc ==  5) skutecznoscAtakuGospodarzOgolnie = 45;
            if (roznicaAtakGospodarzObronaGosc ==  6) skutecznoscAtakuGospodarzOgolnie = 50;
            if (roznicaAtakGospodarzObronaGosc ==  7) skutecznoscAtakuGospodarzOgolnie = 60;
            if (roznicaAtakGospodarzObronaGosc ==  8) skutecznoscAtakuGospodarzOgolnie = 60;
            if (roznicaAtakGospodarzObronaGosc ==  9) skutecznoscAtakuGospodarzOgolnie = 70;

            // OBLICZANIE SKUTECZNOSCI ATAKU GOSCI W PROMILACH
            if (roznicaAtakGoscObronaGospodarz == -9) skutecznoscAtakuGoscOgolnie = 1;
            if (roznicaAtakGoscObronaGospodarz == -8) skutecznoscAtakuGoscOgolnie = 3;
            if (roznicaAtakGoscObronaGospodarz == -7) skutecznoscAtakuGoscOgolnie = 5;
            if (roznicaAtakGoscObronaGospodarz == -6) skutecznoscAtakuGoscOgolnie = 8;
            if (roznicaAtakGoscObronaGospodarz == -5) skutecznoscAtakuGoscOgolnie = 10;
            if (roznicaAtakGoscObronaGospodarz == -4) skutecznoscAtakuGoscOgolnie = 12;
            if (roznicaAtakGoscObronaGospodarz == -3) skutecznoscAtakuGoscOgolnie = 15;
            if (roznicaAtakGoscObronaGospodarz == -2) skutecznoscAtakuGoscOgolnie = 18;
            if (roznicaAtakGoscObronaGospodarz == -1) skutecznoscAtakuGoscOgolnie = 20;
            if (roznicaAtakGoscObronaGospodarz ==  0) skutecznoscAtakuGoscOgolnie = 23;
            if (roznicaAtakGoscObronaGospodarz ==  1) skutecznoscAtakuGoscOgolnie = 27;
            if (roznicaAtakGoscObronaGospodarz ==  2) skutecznoscAtakuGoscOgolnie = 30;
            if (roznicaAtakGoscObronaGospodarz ==  3) skutecznoscAtakuGoscOgolnie = 35;
            if (roznicaAtakGoscObronaGospodarz ==  4) skutecznoscAtakuGoscOgolnie = 40;
            if (roznicaAtakGoscObronaGospodarz ==  5) skutecznoscAtakuGoscOgolnie = 45;
            if (roznicaAtakGoscObronaGospodarz ==  6) skutecznoscAtakuGoscOgolnie = 50;
            if (roznicaAtakGoscObronaGospodarz ==  7) skutecznoscAtakuGoscOgolnie = 60;
            if (roznicaAtakGoscObronaGospodarz ==  8) skutecznoscAtakuGoscOgolnie = 60;
            if (roznicaAtakGoscObronaGospodarz ==  9) skutecznoscAtakuGoscOgolnie = 70;
        }

        void obliczSzanseNaRzutKarny()
        {
            if (gospodarz.agresja == "bardzo słaby")    szansaNaRzutKarnyGosc = 270;
            if (gospodarz.agresja == "słaby")           szansaNaRzutKarnyGosc = 180;
            if (gospodarz.agresja == "zwykły")          szansaNaRzutKarnyGosc = 120;
            if (gospodarz.agresja == "mocny")           szansaNaRzutKarnyGosc = 90;
            if (gospodarz.agresja == "bardzo mocny")    szansaNaRzutKarnyGosc = 30;

            if (gosc.agresja == "bardzo słaby")    szansaNaRzutKarnyGospodarz = 270;
            if (gosc.agresja == "słaby")           szansaNaRzutKarnyGospodarz = 180;
            if (gosc.agresja == "zwykły")          szansaNaRzutKarnyGospodarz = 120;
            if (gosc.agresja == "mocny")           szansaNaRzutKarnyGospodarz = 90;
            if (gosc.agresja == "bardzo mocny")    szansaNaRzutKarnyGospodarz = 30;
        }

        void obliczRoznicePoziomowBramkarzWykonawacaKarnego()
        {
            roznicaWykonawcaGospodarzBramkarzGosc = gospodarz.pilkarze[gospodarz.staleFragmentyGry].skutecznosc - gosc.pilkarze[0].umBramkarskie;
            roznicaWykonawcaGoscBramkarzGospodarz = gosc.pilkarze[0].umBramkarskie - gospodarz.pilkarze[gospodarz.staleFragmentyGry].skutecznosc;

            roznicaWykonawcaGospodarzBramkarzGosc = roznicaWykonawcaGospodarzBramkarzGosc / 10;
            roznicaWykonawcaGoscBramkarzGospodarz = roznicaWykonawcaGoscBramkarzGospodarz / 10;

            if (roznicaWykonawcaGospodarzBramkarzGosc == -9) skutecznoscRzutuKarnegoGospodarz = 15;
            if (roznicaWykonawcaGospodarzBramkarzGosc == -8) skutecznoscRzutuKarnegoGospodarz = 23;
            if (roznicaWykonawcaGospodarzBramkarzGosc == -7) skutecznoscRzutuKarnegoGospodarz = 31;
            if (roznicaWykonawcaGospodarzBramkarzGosc == -6) skutecznoscRzutuKarnegoGospodarz = 39;
            if (roznicaWykonawcaGospodarzBramkarzGosc == -5) skutecznoscRzutuKarnegoGospodarz = 45;
            if (roznicaWykonawcaGospodarzBramkarzGosc == -4) skutecznoscRzutuKarnegoGospodarz = 51;
            if (roznicaWykonawcaGospodarzBramkarzGosc == -3) skutecznoscRzutuKarnegoGospodarz = 57;
            if (roznicaWykonawcaGospodarzBramkarzGosc == -2) skutecznoscRzutuKarnegoGospodarz = 61;
            if (roznicaWykonawcaGospodarzBramkarzGosc == -1) skutecznoscRzutuKarnegoGospodarz = 65;
            if (roznicaWykonawcaGospodarzBramkarzGosc ==  0) skutecznoscRzutuKarnegoGospodarz = 70;
            if (roznicaWykonawcaGospodarzBramkarzGosc ==  1) skutecznoscRzutuKarnegoGospodarz = 73;
            if (roznicaWykonawcaGospodarzBramkarzGosc ==  2) skutecznoscRzutuKarnegoGospodarz = 76;
            if (roznicaWykonawcaGospodarzBramkarzGosc ==  3) skutecznoscRzutuKarnegoGospodarz = 79;
            if (roznicaWykonawcaGospodarzBramkarzGosc ==  4) skutecznoscRzutuKarnegoGospodarz = 82;
            if (roznicaWykonawcaGospodarzBramkarzGosc ==  5) skutecznoscRzutuKarnegoGospodarz = 85;
            if (roznicaWykonawcaGospodarzBramkarzGosc ==  6) skutecznoscRzutuKarnegoGospodarz = 88;
            if (roznicaWykonawcaGospodarzBramkarzGosc ==  7) skutecznoscRzutuKarnegoGospodarz = 91;
            if (roznicaWykonawcaGospodarzBramkarzGosc ==  8) skutecznoscRzutuKarnegoGospodarz = 94;
            if (roznicaWykonawcaGospodarzBramkarzGosc ==  9) skutecznoscRzutuKarnegoGospodarz = 97;

            if (roznicaWykonawcaGoscBramkarzGospodarz == -9) skutecznoscRzutuKarnegoGosc = 15;
            if (roznicaWykonawcaGoscBramkarzGospodarz == -8) skutecznoscRzutuKarnegoGosc = 23;
            if (roznicaWykonawcaGoscBramkarzGospodarz == -7) skutecznoscRzutuKarnegoGosc = 31;
            if (roznicaWykonawcaGoscBramkarzGospodarz == -6) skutecznoscRzutuKarnegoGosc = 39;
            if (roznicaWykonawcaGoscBramkarzGospodarz == -5) skutecznoscRzutuKarnegoGosc = 45;
            if (roznicaWykonawcaGoscBramkarzGospodarz == -4) skutecznoscRzutuKarnegoGosc = 51;
            if (roznicaWykonawcaGoscBramkarzGospodarz == -3) skutecznoscRzutuKarnegoGosc = 57;
            if (roznicaWykonawcaGoscBramkarzGospodarz == -2) skutecznoscRzutuKarnegoGosc = 61;
            if (roznicaWykonawcaGoscBramkarzGospodarz == -1) skutecznoscRzutuKarnegoGosc = 65;
            if (roznicaWykonawcaGoscBramkarzGospodarz ==  0) skutecznoscRzutuKarnegoGosc = 70;
            if (roznicaWykonawcaGoscBramkarzGospodarz ==  1) skutecznoscRzutuKarnegoGosc = 73;
            if (roznicaWykonawcaGoscBramkarzGospodarz ==  2) skutecznoscRzutuKarnegoGosc = 76;
            if (roznicaWykonawcaGoscBramkarzGospodarz ==  3) skutecznoscRzutuKarnegoGosc = 79;
            if (roznicaWykonawcaGoscBramkarzGospodarz ==  4) skutecznoscRzutuKarnegoGosc = 82;
            if (roznicaWykonawcaGoscBramkarzGospodarz ==  5) skutecznoscRzutuKarnegoGosc = 85;
            if (roznicaWykonawcaGoscBramkarzGospodarz ==  6) skutecznoscRzutuKarnegoGosc = 88;
            if (roznicaWykonawcaGoscBramkarzGospodarz ==  7) skutecznoscRzutuKarnegoGosc = 91;
            if (roznicaWykonawcaGoscBramkarzGospodarz ==  8) skutecznoscRzutuKarnegoGosc = 94;
            if (roznicaWykonawcaGoscBramkarzGospodarz ==  9) skutecznoscRzutuKarnegoGosc = 97;
        }

        void uzupelnijKomentarze()
        {
            if (druzynaAtakujaca == null) druzynaAtakujaca = gospodarz;
            if (druzynaBroniaca == null) druzynaBroniaca = gosc;

            rozpoczecieMeczu = new List<string>();
            rozpoczecieMeczu.Add("Sędzia rozpoczyna mecz.");
            rozpoczecieMeczu.Add(gospodarz.nazwa + " rozpoczyna mecz.");
            rozpoczecieMeczu.Add("Zaczynamy 1. połowę.");
            rozpoczecieMeczu.Add("Sędzia zaczyna 1. połowę meczu.");

            rozpoczecie2Polowy = new List<string>();
            rozpoczecie2Polowy.Add("Zaczynamy drugą połowę meczu.");
            rozpoczecie2Polowy.Add("Sędzia rozpoczyna drugą połowę meczu.");
            rozpoczecie2Polowy.Add("Rozpoczynamy drugie 45 minut meczu.");
            rozpoczecie2Polowy.Add(gosc.nazwa + " rozpoczyna 2. połowę meczu.");

            zakonczeniePolowy = new List<string>();
            zakonczeniePolowy.Add("Koniec 1. połowy.");
            zakonczeniePolowy.Add("Wynik do przerwy " + wynik + ".");
            zakonczeniePolowy.Add("Sędzia kończy 1. połowę meczu.");
            zakonczeniePolowy.Add("Minęło 45 minut gry. Wynik " + wynik + ".");
            zakonczeniePolowy.Add("Po 45 minutach gry jest " + wynik + ".");

            zakonczenieMeczu = new List<string>();
            zakonczenieMeczu.Add("Sędzia odgwizduje koniec meczu.");
            zakonczenieMeczu.Add("Koniec meczu. Wynik " + wynik + ".");
            zakonczenieMeczu.Add("Sędzia kończy spotkanie. Wynik " + wynik + ".");

            posiadaniePilki = new List<string>();
            posiadaniePilki.Add("Posiadanie piłki " + posiadaniePilkiGospodarz + " - " + posiadaniePilkiGosc + ".");
            posiadaniePilki.Add("Gospodarz posiadał piłkę przez " + posiadaniePilkiGospodarz + "% czasu.");
            posiadaniePilki.Add("Piłkarze gości posiadali piłkę przez " + posiadaniePilkiGosc + "% czasu.");
            posiadaniePilki.Add("Gospodarze posiadali piłkę przez " + posiadaniePilkiGospodarz + "% czasu, a goście przez " + posiadaniePilkiGosc + "%.");

            gol = new List<string>();
            gol.Add(druzynaAtakujaca.pilkarze[nr].nazwisko + " zachowuje zimną krew będąc sam na sam z bramkarzem. Gol dla drużyny " + druzynaAtakujaca.nazwa + ".");
            gol.Add(druzynaAtakujaca.pilkarze[nr].nazwisko + " strzela gola. Gol dla drużyny " + druzynaAtakujaca.nazwa + ".");
            gol.Add(druzynaAtakujaca.pilkarze[nr].nazwisko + " strzela w samo okienko bramki i nie daje żadnych szans bramkarzowi. Gol dla drużyny " + druzynaAtakujaca.nazwa + ".");
            gol.Add("Przy tym strzale " + druzynaBroniaca.pilkarze[0].nazwisko + " nie miał żadnych szans. " + druzynaAtakujaca.nazwa + " strzela gola.");
            gol.Add(druzynaAtakujaca.pilkarze[nr + 1].nazwisko + " dośrodkowuje piłkę i " + druzynaAtakujaca.pilkarze[nr].nazwisko + " strzela gola głową. Gol dla drużyny " + druzynaAtakujaca.nazwa + ".");
            gol.Add(druzynaAtakujaca.pilkarze[nr].nazwisko + " mija kilku obrońców... w tym bramkarza. Piękna bramka piłkarza " + druzynaAtakujaca.nazwa + ".");
            gol.Add("Piękna kombinacyjna akcja piłkarzy " + druzynaAtakujaca.nazwa + ". Gola strzela " + druzynaAtakujaca.pilkarze[nr].nazwisko + ".");
            gol.Add(druzynaAtakujaca.pilkarze[nr + 1].nazwisko + " zagrywa prostopadłą piłkę do kolegi z zespołu. " + druzynaAtakujaca.pilkarze[nr].nazwisko + " mija bramkarza i strzela do pustej bramki.");

            rzutKarny = new List<string>();
            rzutKarny.Add("Sędzia dyktuje rzut karny dla " + druzynaAtakujaca.nazwa + ".");
            rzutKarny.Add("Piłkarz drużyny " + druzynaAtakujaca.nazwa + " został sfaulowany w polu karny. Sędzie wskazuje na 11 metr.");
            rzutKarny.Add(druzynaAtakujaca.pilkarze[nr].nazwisko + " został zfaulowany w polu karnym. Sędzia pokazuje na 11 metr.");
            rzutKarny.Add("Piłkarz drużyny " + druzynaBroniaca.nazwa + " fauluje przeciwnika w polu karnym. Sędzie odgwizduje rzut karny.");

            rzutKarnyGol = new List<string>();
            rzutKarnyGol.Add(druzynaAtakujaca.pilkarze[druzynaAtakujaca.staleFragmentyGry].nazwisko + " pewnie wykorzystuje jedenastkę.");
            rzutKarnyGol.Add(druzynaAtakujaca.pilkarze[druzynaAtakujaca.staleFragmentyGry].nazwisko + " strzela technicznie w lewy róg bramki. Gol dla " + druzynaAtakujaca.nazwa + ".");
            rzutKarnyGol.Add(druzynaAtakujaca.pilkarze[druzynaAtakujaca.staleFragmentyGry].nazwisko + " uderza mocno pod poprzeczkę. " + druzynaBroniaca.pilkarze[0].nazwisko + " był bez szans.");

            rzutKarnyNieGol = new List<string>();
            rzutKarnyNieGol.Add(druzynaAtakujaca.pilkarze[druzynaAtakujaca.staleFragmentyGry].nazwisko + " strzela w prawy dolny róg bramki. Jednak strzał był za słaby - bramkarz broni.");
            rzutKarnyNieGol.Add(druzynaAtakujaca.pilkarze[druzynaAtakujaca.staleFragmentyGry].nazwisko + " nie trafia w bramkę. Piłka ląduje daleko w trybunach.");
        }
    }
}
