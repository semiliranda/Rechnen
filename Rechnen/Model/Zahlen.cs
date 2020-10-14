using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rechnen.Model
{
    class Zahlen
    {
        public decimal? Zahl1 { get; set; }
        public decimal? Zahl2 { get; set; }
        // so liegt das Ergebnis später noch vor
        private decimal? _zahlErg;
        public decimal? ZahlErg
        {
            get { return this._zahlErg; }
        }

        public decimal? Sub()
        {
            this._zahlErg = Zahl1 - Zahl2;
            return this._zahlErg;
        }

        public decimal? Add()
        {
            this._zahlErg = Zahl1 + Zahl2;
            return this._zahlErg;
        }
    }
}
