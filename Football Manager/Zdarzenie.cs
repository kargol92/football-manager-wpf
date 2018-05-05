using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Football_Manager
{
    public enum RodzajZdarzenia { gol, rzutKarny }

    public class Zdarzenie
    {
        public Pilkarz pilkarz { get; private set; }
        public int minuta { get; private set; }
        public RodzajZdarzenia rodzaj { get; private set; }

        public Zdarzenie(Pilkarz pilkarz, int minuta, RodzajZdarzenia rodzaj)
        {
            this.pilkarz = pilkarz;
            this.minuta = minuta;
            this.rodzaj = rodzaj;
        }
    }
}
