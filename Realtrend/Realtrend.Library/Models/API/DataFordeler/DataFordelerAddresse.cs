using System;

public class DataFordelerAddresse
{
    public string DatafordelerOpdateringstid { get; set; }
    public string Adressebetegnelse { get; set; }
    public string Etagebetegnelse { get; set; }
    public string Forretningshændelse { get; set; }
    public string Forretningsområde { get; set; }
    public string Forretningsproces { get; set; }
    public string Id_LokalId { get; set; }
    public string Id_Namespace { get; set; }
    public string RegistreringFra { get; set; }
    public string Registreringsaktør { get; set; }
    public string Status { get; set; }
    public string VirkningFra { get; set; }
    public string Virkningsaktør { get; set; }
    public HusnummerData Husnummer { get; set; }
    public NavngivenVej NavngivenVej { get; set; }
    public Postnummer Postnummer { get; set; }
}

public class HusnummerData
{
    public string DatafordelerOpdateringstid { get; set; }
    public string Adgangsadressebetegnelse { get; set; }
    public string AdgangTilBygning { get; set; }
    public Afstemningsområde Afstemningsområde { get; set; }
    public string GeoDanmarkBygning { get; set; }
    public string Husnummerretning { get; set; }
    public string Husnummertekst { get; set; }
    public string Jordstykke { get; set; }
    public Kommuneinddeling Kommuneinddeling { get; set; }
    public Sogneinddeling Sogneinddeling { get; set; }
    public Adgangspunkt Adgangspunkt { get; set; }
    public Vejpunkt Vejpunkt { get; set; }
}

public class Afstemningsområde
{
    public string Id { get; set; }
    public string Afstemningsområdenummer { get; set; }
    public string Navn { get; set; }
}

public class Kommuneinddeling
{
    public string Id { get; set; }
    public string Kommunekode { get; set; }
    public string Navn { get; set; }
}

public class Sogneinddeling
{
    public string Id { get; set; }
    public string Sognekode { get; set; }
    public string Navn { get; set; }
}

public class Adgangspunkt
{
    public string DatafordelerOpdateringstid { get; set; }
    public string Oprindelse_kilde { get; set; }
    public string Oprindelse_nøjagtighedsklasse { get; set; }
    public string Oprindelse_registrering { get; set; }
    public string Oprindelse_tekniskStandard { get; set; }
    public string Position { get; set; }
    public string Status { get; set; }
}

public class Vejpunkt
{
    public string DatafordelerOpdateringstid { get; set; }
    public string Oprindelse_kilde { get; set; }
    public string Status { get; set; }
    public string Oprindelse_nøjagtighedsklasse { get; set; }
    public string Oprindelse_registrering { get; set; }
    public string Oprindelse_tekniskStandard { get; set; }
    public string Position { get; set; }
}

public class NavngivenVej
{
    public string DatafordelerOpdateringstid { get; set; }
    public string AdministreresAfKommune { get; set; }
    public string Forretningshændelse { get; set; }
    public string Forretningsområde { get; set; }
    public string Forretningsproces { get; set; }
    public string Id_LokalId { get; set; }
    public string Id_Namespace { get; set; }
    public string RegistreringFra { get; set; }
    public string Registreringsaktør { get; set; }
    public string Status { get; set; }
    public string UdtaltVejnavn { get; set; }
    public string Vejadresseringsnavn { get; set; }
    public string Vejnavn { get; set; }
    public string Vejnavnebeliggenhed_oprindelse_kilde { get; set; }
    public string Vejnavnebeliggenhed_oprindelse_nøjagtighedsklasse { get; set; }
    public string Vejnavnebeliggenhed_oprindelse_registrering { get; set; }
    public string Vejnavnebeliggenhed_oprindelse_tekniskStandard { get; set; }
    public string Vejnavnebeliggenhed_vejnavnelinje { get; set; }
    public string VirkningFra { get; set; }
    public string Virkningsaktør { get; set; }
}

public class Postnummer
{
    public string DatafordelerOpdateringstid { get; set; }
    public string Forretningshændelse { get; set; }
    public string Forretningsområde { get; set; }
    public string Forretningsproces { get; set; }
    public string Id_LokalId { get; set; }
    public string Id_Namespace { get; set; }
    public string Navn { get; set; }
    public string Postnr { get; set; }
    public string Postnummerinddeling { get; set; }
    public string RegistreringFra { get; set; }
    public string Registreringsaktør { get; set; }
    public string Status { get; set; }
    public string VirkningFra { get; set; }
    public string Virkningsaktør { get; set; }
}
