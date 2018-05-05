using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Football_Manager
{
    public class Kolejka
    {
        public Mecz[] mecze { get; set; }
        public static int iloscMeczow { get; private set; }
        public string kolejka { get; private set; }

        public Kolejka(Liga liga, int nrKolejki)
        {
            this.liga = liga;
            kolejka = "Kolejka " + (nrKolejki + 1) + ".";

            iloscMeczow = liga.iloscDruzyn / 2;
            mecze = new Mecz[iloscMeczow];

            if (nrKolejki == 0)
            {
                for (int i = 0; i < iloscMeczow; i++)
                    mecze[i] = new Mecz(liga.druzyny[i*2], liga.druzyny[i*2+1], liga.sezon, nrKolejki);
            }
            if (nrKolejki == 1)
            {
                mecze[0] = new Mecz(liga.druzyny[0], liga.druzyny[2], liga.sezon, nrKolejki);
                mecze[1] = new Mecz(liga.druzyny[1], liga.druzyny[3], liga.sezon, nrKolejki);
                mecze[2] = new Mecz(liga.druzyny[4], liga.druzyny[6], liga.sezon, nrKolejki);
                mecze[3] = new Mecz(liga.druzyny[5], liga.druzyny[7], liga.sezon, nrKolejki);
                mecze[4] = new Mecz(liga.druzyny[8], liga.druzyny[10], liga.sezon, nrKolejki);
                mecze[5] = new Mecz(liga.druzyny[9], liga.druzyny[11], liga.sezon, nrKolejki);
                mecze[6] = new Mecz(liga.druzyny[12], liga.druzyny[14], liga.sezon, nrKolejki);
                mecze[7] = new Mecz(liga.druzyny[13], liga.druzyny[15], liga.sezon, nrKolejki);
            }
            if (nrKolejki == 2)
            {
                mecze[0] = new Mecz(liga.druzyny[0], liga.druzyny[3], liga.sezon, nrKolejki);
                mecze[1] = new Mecz(liga.druzyny[1], liga.druzyny[2], liga.sezon, nrKolejki);
                mecze[2] = new Mecz(liga.druzyny[4], liga.druzyny[7], liga.sezon, nrKolejki);
                mecze[3] = new Mecz(liga.druzyny[5], liga.druzyny[6], liga.sezon, nrKolejki);
                mecze[4] = new Mecz(liga.druzyny[8], liga.druzyny[11], liga.sezon, nrKolejki);
                mecze[5] = new Mecz(liga.druzyny[9], liga.druzyny[10], liga.sezon, nrKolejki);
                mecze[6] = new Mecz(liga.druzyny[12], liga.druzyny[15], liga.sezon, nrKolejki);
                mecze[7] = new Mecz(liga.druzyny[13], liga.druzyny[14], liga.sezon, nrKolejki);
            }
            if (nrKolejki == 3)
            {
                mecze[0] = new Mecz(liga.druzyny[0], liga.druzyny[4], liga.sezon, nrKolejki);
                mecze[1] = new Mecz(liga.druzyny[1], liga.druzyny[5], liga.sezon, nrKolejki);
                mecze[2] = new Mecz(liga.druzyny[2], liga.druzyny[6], liga.sezon, nrKolejki);
                mecze[3] = new Mecz(liga.druzyny[3], liga.druzyny[7], liga.sezon, nrKolejki);
                mecze[4] = new Mecz(liga.druzyny[8], liga.druzyny[12], liga.sezon, nrKolejki);
                mecze[5] = new Mecz(liga.druzyny[9], liga.druzyny[13], liga.sezon, nrKolejki);
                mecze[6] = new Mecz(liga.druzyny[10], liga.druzyny[14], liga.sezon, nrKolejki);
                mecze[7] = new Mecz(liga.druzyny[11], liga.druzyny[15], liga.sezon, nrKolejki);
            }
            if (nrKolejki == 4)
            {
                mecze[0] = new Mecz(liga.druzyny[0], liga.druzyny[5], liga.sezon, nrKolejki);
                mecze[1] = new Mecz(liga.druzyny[1], liga.druzyny[6], liga.sezon, nrKolejki);
                mecze[2] = new Mecz(liga.druzyny[2], liga.druzyny[7], liga.sezon, nrKolejki);
                mecze[3] = new Mecz(liga.druzyny[3], liga.druzyny[8], liga.sezon, nrKolejki);
                mecze[4] = new Mecz(liga.druzyny[4], liga.druzyny[9], liga.sezon, nrKolejki);
                mecze[5] = new Mecz(liga.druzyny[10], liga.druzyny[13], liga.sezon, nrKolejki);
                mecze[6] = new Mecz(liga.druzyny[11], liga.druzyny[14], liga.sezon, nrKolejki);
                mecze[7] = new Mecz(liga.druzyny[12], liga.druzyny[15], liga.sezon, nrKolejki);
            }
            if (nrKolejki == 5)
            {
                mecze[0] = new Mecz(liga.druzyny[0], liga.druzyny[6], liga.sezon, nrKolejki);
                mecze[1] = new Mecz(liga.druzyny[1], liga.druzyny[7], liga.sezon, nrKolejki);
                mecze[2] = new Mecz(liga.druzyny[2], liga.druzyny[8], liga.sezon, nrKolejki);
                mecze[3] = new Mecz(liga.druzyny[3], liga.druzyny[9], liga.sezon, nrKolejki);
                mecze[4] = new Mecz(liga.druzyny[4], liga.druzyny[10], liga.sezon, nrKolejki);
                mecze[5] = new Mecz(liga.druzyny[5], liga.druzyny[11], liga.sezon, nrKolejki);
                mecze[6] = new Mecz(liga.druzyny[12], liga.druzyny[14], liga.sezon, nrKolejki);
                mecze[7] = new Mecz(liga.druzyny[13], liga.druzyny[15], liga.sezon, nrKolejki);
            }
            if (nrKolejki == 6)
            {
                mecze[0] = new Mecz(liga.druzyny[0], liga.druzyny[7], liga.sezon, nrKolejki);
                mecze[1] = new Mecz(liga.druzyny[1], liga.druzyny[8], liga.sezon, nrKolejki);
                mecze[2] = new Mecz(liga.druzyny[2], liga.druzyny[9], liga.sezon, nrKolejki);
                mecze[3] = new Mecz(liga.druzyny[3], liga.druzyny[10], liga.sezon, nrKolejki);
                mecze[4] = new Mecz(liga.druzyny[4], liga.druzyny[11], liga.sezon, nrKolejki);
                mecze[5] = new Mecz(liga.druzyny[5], liga.druzyny[12], liga.sezon, nrKolejki);
                mecze[6] = new Mecz(liga.druzyny[6], liga.druzyny[13], liga.sezon, nrKolejki);
                mecze[7] = new Mecz(liga.druzyny[14], liga.druzyny[15], liga.sezon, nrKolejki);
            }
            if (nrKolejki == 7)
            {
                mecze[0] = new Mecz(liga.druzyny[0], liga.druzyny[8], liga.sezon, nrKolejki);
                mecze[1] = new Mecz(liga.druzyny[1], liga.druzyny[9], liga.sezon, nrKolejki);
                mecze[2] = new Mecz(liga.druzyny[2], liga.druzyny[10], liga.sezon, nrKolejki);
                mecze[3] = new Mecz(liga.druzyny[3], liga.druzyny[11], liga.sezon, nrKolejki);
                mecze[4] = new Mecz(liga.druzyny[4], liga.druzyny[12], liga.sezon, nrKolejki);
                mecze[5] = new Mecz(liga.druzyny[5], liga.druzyny[13], liga.sezon, nrKolejki);
                mecze[6] = new Mecz(liga.druzyny[6], liga.druzyny[14], liga.sezon, nrKolejki);
                mecze[7] = new Mecz(liga.druzyny[7], liga.druzyny[15], liga.sezon, nrKolejki);
            }
            if (nrKolejki == 8)
            {
                mecze[0] = new Mecz(liga.druzyny[0], liga.druzyny[9], liga.sezon, nrKolejki);
                mecze[1] = new Mecz(liga.druzyny[1], liga.druzyny[10], liga.sezon, nrKolejki);
                mecze[2] = new Mecz(liga.druzyny[2], liga.druzyny[11], liga.sezon, nrKolejki);
                mecze[3] = new Mecz(liga.druzyny[3], liga.druzyny[12], liga.sezon, nrKolejki);
                mecze[4] = new Mecz(liga.druzyny[4], liga.druzyny[13], liga.sezon, nrKolejki);
                mecze[5] = new Mecz(liga.druzyny[5], liga.druzyny[14], liga.sezon, nrKolejki);
                mecze[6] = new Mecz(liga.druzyny[6], liga.druzyny[15], liga.sezon, nrKolejki);
                mecze[7] = new Mecz(liga.druzyny[7], liga.druzyny[8], liga.sezon, nrKolejki);
            }
            if (nrKolejki == 9)
            {
                mecze[0] = new Mecz(liga.druzyny[0], liga.druzyny[10], liga.sezon, nrKolejki);
                mecze[1] = new Mecz(liga.druzyny[1], liga.druzyny[11], liga.sezon, nrKolejki);
                mecze[2] = new Mecz(liga.druzyny[2], liga.druzyny[12], liga.sezon, nrKolejki);
                mecze[3] = new Mecz(liga.druzyny[3], liga.druzyny[13], liga.sezon, nrKolejki);
                mecze[4] = new Mecz(liga.druzyny[4], liga.druzyny[14], liga.sezon, nrKolejki);
                mecze[5] = new Mecz(liga.druzyny[5], liga.druzyny[15], liga.sezon, nrKolejki);
                mecze[6] = new Mecz(liga.druzyny[6], liga.druzyny[8], liga.sezon, nrKolejki);
                mecze[7] = new Mecz(liga.druzyny[7], liga.druzyny[9], liga.sezon, nrKolejki);
            }
            if (nrKolejki == 10)
            {
                mecze[0] = new Mecz(liga.druzyny[0], liga.druzyny[11], liga.sezon, nrKolejki);
                mecze[1] = new Mecz(liga.druzyny[1], liga.druzyny[12], liga.sezon, nrKolejki);
                mecze[2] = new Mecz(liga.druzyny[2], liga.druzyny[13], liga.sezon, nrKolejki);
                mecze[3] = new Mecz(liga.druzyny[3], liga.druzyny[14], liga.sezon, nrKolejki);
                mecze[4] = new Mecz(liga.druzyny[4], liga.druzyny[15], liga.sezon, nrKolejki);
                mecze[5] = new Mecz(liga.druzyny[5], liga.druzyny[8], liga.sezon, nrKolejki);
                mecze[6] = new Mecz(liga.druzyny[6], liga.druzyny[9], liga.sezon, nrKolejki);
                mecze[7] = new Mecz(liga.druzyny[7], liga.druzyny[10], liga.sezon, nrKolejki);
            }
            if (nrKolejki == 11)
            {
                mecze[0] = new Mecz(liga.druzyny[0], liga.druzyny[12], liga.sezon, nrKolejki);
                mecze[1] = new Mecz(liga.druzyny[1], liga.druzyny[13], liga.sezon, nrKolejki);
                mecze[2] = new Mecz(liga.druzyny[2], liga.druzyny[14], liga.sezon, nrKolejki);
                mecze[3] = new Mecz(liga.druzyny[3], liga.druzyny[15], liga.sezon, nrKolejki);
                mecze[4] = new Mecz(liga.druzyny[4], liga.druzyny[8], liga.sezon, nrKolejki);
                mecze[5] = new Mecz(liga.druzyny[5], liga.druzyny[9], liga.sezon, nrKolejki);
                mecze[6] = new Mecz(liga.druzyny[6], liga.druzyny[10], liga.sezon, nrKolejki);
                mecze[7] = new Mecz(liga.druzyny[7], liga.druzyny[11], liga.sezon, nrKolejki);
            }
            if (nrKolejki == 12)
            {
                mecze[0] = new Mecz(liga.druzyny[0], liga.druzyny[13], liga.sezon, nrKolejki);
                mecze[1] = new Mecz(liga.druzyny[1], liga.druzyny[14], liga.sezon, nrKolejki);
                mecze[2] = new Mecz(liga.druzyny[2], liga.druzyny[15], liga.sezon, nrKolejki);
                mecze[3] = new Mecz(liga.druzyny[3], liga.druzyny[8], liga.sezon, nrKolejki);
                mecze[4] = new Mecz(liga.druzyny[4], liga.druzyny[9], liga.sezon, nrKolejki);
                mecze[5] = new Mecz(liga.druzyny[5], liga.druzyny[10], liga.sezon, nrKolejki);
                mecze[6] = new Mecz(liga.druzyny[6], liga.druzyny[11], liga.sezon, nrKolejki);
                mecze[7] = new Mecz(liga.druzyny[7], liga.druzyny[12], liga.sezon, nrKolejki);
            }
            if (nrKolejki == 13)
            {
                mecze[0] = new Mecz(liga.druzyny[0], liga.druzyny[14], liga.sezon, nrKolejki);
                mecze[1] = new Mecz(liga.druzyny[1], liga.druzyny[15], liga.sezon, nrKolejki);
                mecze[2] = new Mecz(liga.druzyny[2], liga.druzyny[8], liga.sezon, nrKolejki);
                mecze[3] = new Mecz(liga.druzyny[3], liga.druzyny[9], liga.sezon, nrKolejki);
                mecze[4] = new Mecz(liga.druzyny[4], liga.druzyny[10], liga.sezon, nrKolejki);
                mecze[5] = new Mecz(liga.druzyny[5], liga.druzyny[11], liga.sezon, nrKolejki);
                mecze[6] = new Mecz(liga.druzyny[6], liga.druzyny[12], liga.sezon, nrKolejki);
                mecze[7] = new Mecz(liga.druzyny[7], liga.druzyny[13], liga.sezon, nrKolejki);
            }
            if (nrKolejki == 14)
            {
                mecze[0] = new Mecz(liga.druzyny[0], liga.druzyny[15], liga.sezon, nrKolejki);
                mecze[1] = new Mecz(liga.druzyny[1], liga.druzyny[8], liga.sezon, nrKolejki);
                mecze[2] = new Mecz(liga.druzyny[2], liga.druzyny[9], liga.sezon, nrKolejki);
                mecze[3] = new Mecz(liga.druzyny[3], liga.druzyny[10], liga.sezon, nrKolejki);
                mecze[4] = new Mecz(liga.druzyny[4], liga.druzyny[11], liga.sezon, nrKolejki);
                mecze[5] = new Mecz(liga.druzyny[5], liga.druzyny[12], liga.sezon, nrKolejki);
                mecze[6] = new Mecz(liga.druzyny[6], liga.druzyny[13], liga.sezon, nrKolejki);
                mecze[7] = new Mecz(liga.druzyny[7], liga.druzyny[14], liga.sezon, nrKolejki);
            }

            int k = 15;

            if (nrKolejki == 0 + k)
            {
                for (int i = 0; i < iloscMeczow; i++)
                    mecze[i] = new Mecz(liga.druzyny[i * 2], liga.druzyny[i * 2 + 1], liga.sezon, nrKolejki);
            }
            if (nrKolejki == 1 + k)
            {
                mecze[0] = new Mecz(liga.druzyny[0], liga.druzyny[2], liga.sezon, nrKolejki);
                mecze[1] = new Mecz(liga.druzyny[1], liga.druzyny[3], liga.sezon, nrKolejki);
                mecze[2] = new Mecz(liga.druzyny[4], liga.druzyny[6], liga.sezon, nrKolejki);
                mecze[3] = new Mecz(liga.druzyny[5], liga.druzyny[7], liga.sezon, nrKolejki);
                mecze[4] = new Mecz(liga.druzyny[8], liga.druzyny[10], liga.sezon, nrKolejki);
                mecze[5] = new Mecz(liga.druzyny[9], liga.druzyny[11], liga.sezon, nrKolejki);
                mecze[6] = new Mecz(liga.druzyny[12], liga.druzyny[14], liga.sezon, nrKolejki);
                mecze[7] = new Mecz(liga.druzyny[13], liga.druzyny[15], liga.sezon, nrKolejki);
            }
            if (nrKolejki == 2 + k)
            {
                mecze[0] = new Mecz(liga.druzyny[0], liga.druzyny[3], liga.sezon, nrKolejki);
                mecze[1] = new Mecz(liga.druzyny[1], liga.druzyny[2], liga.sezon, nrKolejki);
                mecze[2] = new Mecz(liga.druzyny[4], liga.druzyny[7], liga.sezon, nrKolejki);
                mecze[3] = new Mecz(liga.druzyny[5], liga.druzyny[6], liga.sezon, nrKolejki);
                mecze[4] = new Mecz(liga.druzyny[8], liga.druzyny[11], liga.sezon, nrKolejki);
                mecze[5] = new Mecz(liga.druzyny[9], liga.druzyny[10], liga.sezon, nrKolejki);
                mecze[6] = new Mecz(liga.druzyny[12], liga.druzyny[15], liga.sezon, nrKolejki);
                mecze[7] = new Mecz(liga.druzyny[13], liga.druzyny[14], liga.sezon, nrKolejki);
            }
            if (nrKolejki == 3 + k)
            {
                mecze[0] = new Mecz(liga.druzyny[0], liga.druzyny[4], liga.sezon, nrKolejki);
                mecze[1] = new Mecz(liga.druzyny[1], liga.druzyny[5], liga.sezon, nrKolejki);
                mecze[2] = new Mecz(liga.druzyny[2], liga.druzyny[6], liga.sezon, nrKolejki);
                mecze[3] = new Mecz(liga.druzyny[3], liga.druzyny[7], liga.sezon, nrKolejki);
                mecze[4] = new Mecz(liga.druzyny[8], liga.druzyny[12], liga.sezon, nrKolejki);
                mecze[5] = new Mecz(liga.druzyny[9], liga.druzyny[13], liga.sezon, nrKolejki);
                mecze[6] = new Mecz(liga.druzyny[10], liga.druzyny[14], liga.sezon, nrKolejki);
                mecze[7] = new Mecz(liga.druzyny[11], liga.druzyny[15], liga.sezon, nrKolejki);
            }
            if (nrKolejki == 4 + k)
            {
                mecze[0] = new Mecz(liga.druzyny[0], liga.druzyny[5], liga.sezon, nrKolejki);
                mecze[1] = new Mecz(liga.druzyny[1], liga.druzyny[6], liga.sezon, nrKolejki);
                mecze[2] = new Mecz(liga.druzyny[2], liga.druzyny[7], liga.sezon, nrKolejki);
                mecze[3] = new Mecz(liga.druzyny[3], liga.druzyny[8], liga.sezon, nrKolejki);
                mecze[4] = new Mecz(liga.druzyny[4], liga.druzyny[9], liga.sezon, nrKolejki);
                mecze[5] = new Mecz(liga.druzyny[10], liga.druzyny[13], liga.sezon, nrKolejki);
                mecze[6] = new Mecz(liga.druzyny[11], liga.druzyny[14], liga.sezon, nrKolejki);
                mecze[7] = new Mecz(liga.druzyny[12], liga.druzyny[15], liga.sezon, nrKolejki);
            }
            if (nrKolejki == 5 + k)
            {
                mecze[0] = new Mecz(liga.druzyny[0], liga.druzyny[6], liga.sezon, nrKolejki);
                mecze[1] = new Mecz(liga.druzyny[1], liga.druzyny[7], liga.sezon, nrKolejki);
                mecze[2] = new Mecz(liga.druzyny[2], liga.druzyny[8], liga.sezon, nrKolejki);
                mecze[3] = new Mecz(liga.druzyny[3], liga.druzyny[9], liga.sezon, nrKolejki);
                mecze[4] = new Mecz(liga.druzyny[4], liga.druzyny[10], liga.sezon, nrKolejki);
                mecze[5] = new Mecz(liga.druzyny[5], liga.druzyny[11], liga.sezon, nrKolejki);
                mecze[6] = new Mecz(liga.druzyny[12], liga.druzyny[14], liga.sezon, nrKolejki);
                mecze[7] = new Mecz(liga.druzyny[13], liga.druzyny[15], liga.sezon, nrKolejki);
            }
            if (nrKolejki == 6 + k)
            {
                mecze[0] = new Mecz(liga.druzyny[0], liga.druzyny[7], liga.sezon, nrKolejki);
                mecze[1] = new Mecz(liga.druzyny[1], liga.druzyny[8], liga.sezon, nrKolejki);
                mecze[2] = new Mecz(liga.druzyny[2], liga.druzyny[9], liga.sezon, nrKolejki);
                mecze[3] = new Mecz(liga.druzyny[3], liga.druzyny[10], liga.sezon, nrKolejki);
                mecze[4] = new Mecz(liga.druzyny[4], liga.druzyny[11], liga.sezon, nrKolejki);
                mecze[5] = new Mecz(liga.druzyny[5], liga.druzyny[12], liga.sezon, nrKolejki);
                mecze[6] = new Mecz(liga.druzyny[6], liga.druzyny[13], liga.sezon, nrKolejki);
                mecze[7] = new Mecz(liga.druzyny[14], liga.druzyny[15], liga.sezon, nrKolejki);
            }
            if (nrKolejki == 7 + k)
            {
                mecze[0] = new Mecz(liga.druzyny[0], liga.druzyny[8], liga.sezon, nrKolejki);
                mecze[1] = new Mecz(liga.druzyny[1], liga.druzyny[9], liga.sezon, nrKolejki);
                mecze[2] = new Mecz(liga.druzyny[2], liga.druzyny[10], liga.sezon, nrKolejki);
                mecze[3] = new Mecz(liga.druzyny[3], liga.druzyny[11], liga.sezon, nrKolejki);
                mecze[4] = new Mecz(liga.druzyny[4], liga.druzyny[12], liga.sezon, nrKolejki);
                mecze[5] = new Mecz(liga.druzyny[5], liga.druzyny[13], liga.sezon, nrKolejki);
                mecze[6] = new Mecz(liga.druzyny[6], liga.druzyny[14], liga.sezon, nrKolejki);
                mecze[7] = new Mecz(liga.druzyny[7], liga.druzyny[15], liga.sezon, nrKolejki);
            }
            if (nrKolejki == 8 + k)
            {
                mecze[0] = new Mecz(liga.druzyny[0], liga.druzyny[9], liga.sezon, nrKolejki);
                mecze[1] = new Mecz(liga.druzyny[1], liga.druzyny[10], liga.sezon, nrKolejki);
                mecze[2] = new Mecz(liga.druzyny[2], liga.druzyny[11], liga.sezon, nrKolejki);
                mecze[3] = new Mecz(liga.druzyny[3], liga.druzyny[12], liga.sezon, nrKolejki);
                mecze[4] = new Mecz(liga.druzyny[4], liga.druzyny[13], liga.sezon, nrKolejki);
                mecze[5] = new Mecz(liga.druzyny[5], liga.druzyny[14], liga.sezon, nrKolejki);
                mecze[6] = new Mecz(liga.druzyny[6], liga.druzyny[15], liga.sezon, nrKolejki);
                mecze[7] = new Mecz(liga.druzyny[7], liga.druzyny[8], liga.sezon, nrKolejki);
            }
            if (nrKolejki == 9 + k)
            {
                mecze[0] = new Mecz(liga.druzyny[0], liga.druzyny[10], liga.sezon, nrKolejki);
                mecze[1] = new Mecz(liga.druzyny[1], liga.druzyny[11], liga.sezon, nrKolejki);
                mecze[2] = new Mecz(liga.druzyny[2], liga.druzyny[12], liga.sezon, nrKolejki);
                mecze[3] = new Mecz(liga.druzyny[3], liga.druzyny[13], liga.sezon, nrKolejki);
                mecze[4] = new Mecz(liga.druzyny[4], liga.druzyny[14], liga.sezon, nrKolejki);
                mecze[5] = new Mecz(liga.druzyny[5], liga.druzyny[15], liga.sezon, nrKolejki);
                mecze[6] = new Mecz(liga.druzyny[6], liga.druzyny[8], liga.sezon, nrKolejki);
                mecze[7] = new Mecz(liga.druzyny[7], liga.druzyny[9], liga.sezon, nrKolejki);
            }
            if (nrKolejki == 10 + k)
            {
                mecze[0] = new Mecz(liga.druzyny[0], liga.druzyny[11], liga.sezon, nrKolejki);
                mecze[1] = new Mecz(liga.druzyny[1], liga.druzyny[12], liga.sezon, nrKolejki);
                mecze[2] = new Mecz(liga.druzyny[2], liga.druzyny[13], liga.sezon, nrKolejki);
                mecze[3] = new Mecz(liga.druzyny[3], liga.druzyny[14], liga.sezon, nrKolejki);
                mecze[4] = new Mecz(liga.druzyny[4], liga.druzyny[15], liga.sezon, nrKolejki);
                mecze[5] = new Mecz(liga.druzyny[5], liga.druzyny[8], liga.sezon, nrKolejki);
                mecze[6] = new Mecz(liga.druzyny[6], liga.druzyny[9], liga.sezon, nrKolejki);
                mecze[7] = new Mecz(liga.druzyny[7], liga.druzyny[10], liga.sezon, nrKolejki);
            }
            if (nrKolejki == 11 + k)
            {
                mecze[0] = new Mecz(liga.druzyny[0], liga.druzyny[12], liga.sezon, nrKolejki);
                mecze[1] = new Mecz(liga.druzyny[1], liga.druzyny[13], liga.sezon, nrKolejki);
                mecze[2] = new Mecz(liga.druzyny[2], liga.druzyny[14], liga.sezon, nrKolejki);
                mecze[3] = new Mecz(liga.druzyny[3], liga.druzyny[15], liga.sezon, nrKolejki);
                mecze[4] = new Mecz(liga.druzyny[4], liga.druzyny[8], liga.sezon, nrKolejki);
                mecze[5] = new Mecz(liga.druzyny[5], liga.druzyny[9], liga.sezon, nrKolejki);
                mecze[6] = new Mecz(liga.druzyny[6], liga.druzyny[10], liga.sezon, nrKolejki);
                mecze[7] = new Mecz(liga.druzyny[7], liga.druzyny[11], liga.sezon, nrKolejki);
            }
            if (nrKolejki == 12 + k)
            {
                mecze[0] = new Mecz(liga.druzyny[0], liga.druzyny[13], liga.sezon, nrKolejki);
                mecze[1] = new Mecz(liga.druzyny[1], liga.druzyny[14], liga.sezon, nrKolejki);
                mecze[2] = new Mecz(liga.druzyny[2], liga.druzyny[15], liga.sezon, nrKolejki);
                mecze[3] = new Mecz(liga.druzyny[3], liga.druzyny[8], liga.sezon, nrKolejki);
                mecze[4] = new Mecz(liga.druzyny[4], liga.druzyny[9], liga.sezon, nrKolejki);
                mecze[5] = new Mecz(liga.druzyny[5], liga.druzyny[10], liga.sezon, nrKolejki);
                mecze[6] = new Mecz(liga.druzyny[6], liga.druzyny[11], liga.sezon, nrKolejki);
                mecze[7] = new Mecz(liga.druzyny[7], liga.druzyny[12], liga.sezon, nrKolejki);
            }
            if (nrKolejki == 13 + k)
            {
                mecze[0] = new Mecz(liga.druzyny[0], liga.druzyny[14], liga.sezon, nrKolejki);
                mecze[1] = new Mecz(liga.druzyny[1], liga.druzyny[15], liga.sezon, nrKolejki);
                mecze[2] = new Mecz(liga.druzyny[2], liga.druzyny[8], liga.sezon, nrKolejki);
                mecze[3] = new Mecz(liga.druzyny[3], liga.druzyny[9], liga.sezon, nrKolejki);
                mecze[4] = new Mecz(liga.druzyny[4], liga.druzyny[10], liga.sezon, nrKolejki);
                mecze[5] = new Mecz(liga.druzyny[5], liga.druzyny[11], liga.sezon, nrKolejki);
                mecze[6] = new Mecz(liga.druzyny[6], liga.druzyny[12], liga.sezon, nrKolejki);
                mecze[7] = new Mecz(liga.druzyny[7], liga.druzyny[13], liga.sezon, nrKolejki);
            }
            if (nrKolejki == 14 + k)
            {
                mecze[0] = new Mecz(liga.druzyny[0], liga.druzyny[15], liga.sezon, nrKolejki);
                mecze[1] = new Mecz(liga.druzyny[1], liga.druzyny[8], liga.sezon, nrKolejki);
                mecze[2] = new Mecz(liga.druzyny[2], liga.druzyny[9], liga.sezon, nrKolejki);
                mecze[3] = new Mecz(liga.druzyny[3], liga.druzyny[10], liga.sezon, nrKolejki);
                mecze[4] = new Mecz(liga.druzyny[4], liga.druzyny[11], liga.sezon, nrKolejki);
                mecze[5] = new Mecz(liga.druzyny[5], liga.druzyny[12], liga.sezon, nrKolejki);
                mecze[6] = new Mecz(liga.druzyny[6], liga.druzyny[13], liga.sezon, nrKolejki);
                mecze[7] = new Mecz(liga.druzyny[7], liga.druzyny[14], liga.sezon, nrKolejki);
            }
        }

        public void rozegraj()
        {
            for (int i = 0; i < iloscMeczow; i++)
                mecze[i].rozegrajBezRelacji();
        }

        public void uaktualnijStatystyki() // UAKTUALNIENIE TABELI LIGOWEJ
        {
            for (int i = 0; i < iloscMeczow; i++)
            {
                for (int j = 0; j < liga.iloscDruzyn; j++)
                {
                    if (liga.tabelaLigowa.kluby[j] == mecze[i].gospodarz || liga.tabelaLigowa.kluby[j] == mecze[i].gosc)
                        liga.tabelaLigowa.kluby[j].uaktualnijStatystyki(mecze[i]);
                }
            }
            liga.tabelaLigowa.sortuj();
        }

        Liga liga;
    }
}
