using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realtrend.Library.Models.API.DataFordeler
{
    public class DatafordelerGrundData
    {
        public string DatafordelerOpdateringstid { get; set; }
        public string Forretningshændelse { get; set; }
        public string Forretningsområde { get; set; }
        public string Forretningsproces { get; set; }
        public string Gru009Vandforsyning { get; set; }
        public string Gru010Afløbsforhold { get; set; }
        public string Husnummer { get; set; }
        public string Id_LokalId { get; set; }
        public string Id_Namespace { get; set; }
        public string Kommunekode { get; set; }
        public string RegistreringFra { get; set; }
        public string Registreringsaktør { get; set; }
        public string Status { get; set; }
        public string VirkningFra { get; set; }
        public string Virkningsaktør { get; set; }
        public List<string> JordstykkeList { get; set; }
        public BestemtFastEjendom BestemtFastEjendom { get; set; }
    }

    public class BestemtFastEjendom
    {
        public string DatafordelerOpdateringstid { get; set; }
        public int BfeNummer { get; set; }
        public string EjendommensEjerforholdskode { get; set; }
        public int Ejendomsnummer { get; set; }
        public string Ejendomstype { get; set; }
        public string Forretningshændelse { get; set; }
        public string Forretningsområde { get; set; }
        public string Forretningsproces { get; set; }
        public string Id_LokalId { get; set; }
        public string Id_Namespace { get; set; }
        public string Kommunekode { get; set; }
        public string RegistreringFra { get; set; }
        public string Registreringsaktør { get; set; }
        public int SamletFastEjendom { get; set; }
        public string Status { get; set; }
        public string VirkningFra { get; set; }
        public string Virkningsaktør { get; set; }
    }
}
