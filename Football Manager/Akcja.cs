using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Football_Manager
{
    public class Akcja
    {
        public int id { get; private set; }
        public int minuta { get; private set; }
        public string komentarz { get; private set; }
        public bool pilkePosiadaGospodarz { get; private set; }

        public Akcja(int id)
        {
            this.id = id;
            this.minuta = id + 1;
        }

        public void dodajKomentarz(string komentarz)
        {
            this.komentarz += komentarz;
        }

        public void ustalPilkePosiadaGospodarz(bool pilkePosiadaGospodarz)
        {
            this.pilkePosiadaGospodarz = pilkePosiadaGospodarz;
        }
    }
}
