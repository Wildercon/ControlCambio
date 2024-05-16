using ControlCambioApi.Models;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace ControlCambioApi.Services
{
    public class TasasServices : ITasasServices
    {
        private readonly TasasDbContext _tasasContext;

        public TasasServices(TasasDbContext tasasContext)
        {
            _tasasContext = tasasContext;
        }
        public async Task<List<ResponseTasas>> GetTasasVenezuela()
        {
            var Tasas = new List<ResponseTasas>();
            var paises = await _tasasContext.TasasPs.ToListAsync();
            var venezuela = paises.FirstOrDefault(x => x.Pais == "Venezuela");
            var VES = venezuela?.ValorMoneda + ((venezuela?.ValorMoneda * 5) / 100);

            #region Colombia

            var colombia = paises.FirstOrDefault(x => x.Pais == "Colombia");
            var COP = colombia?.ValorMoneda - ((colombia!.ValorMoneda * 5) / 100);


            var tasa = COP / VES;


            Tasas.Add(new ResponseTasas { pais = "Colombia", tasa = decimal.Round((decimal)tasa!, 0).ToString(), op = "*" });

            #endregion

            #region Chile

            var chile = paises.FirstOrDefault(x => x.Pais == "Chile");
            var CLP = chile?.ValorMoneda - ((chile?.ValorMoneda * 5) / 100);

            var tasaC = VES / CLP;
            Tasas.Add(new ResponseTasas { pais = "Chile", tasa = decimal.Round((decimal)tasaC!, 3).ToString(), op = "/" });


            #endregion

            #region Peru

            var peru = paises.FirstOrDefault(x => x.Pais == "Peru");
            var PEN = peru?.ValorMoneda - ((peru?.ValorMoneda * 3) / 100);

            var tasaP = VES / PEN;
            Tasas.Add(new ResponseTasas { pais = "Peru", tasa = decimal.Round((decimal)tasaP!, 2).ToString(), op = "/" });
            #endregion

            #region Mexico
            var mexico = paises.FirstOrDefault(x => x.Pais == "Mexico");
            var MXN = mexico?.ValorMoneda - ((mexico?.ValorMoneda * 9) / 100);

            var tasaM = VES / MXN;
            Tasas.Add(new ResponseTasas { pais = "Mexico", tasa = decimal.Round((decimal)tasaM!, 1).ToString(), op = "/" });
            #endregion

            #region Argentina
            var argentina = paises.FirstOrDefault(x => x.Pais == "Argentina");
            var ARS = argentina?.ValorMoneda - ((argentina?.ValorMoneda * 5)/ 100);

            var tasaA = VES / ARS;
            Tasas.Add(new ResponseTasas { pais = "Argentina", tasa = decimal.Round((decimal)tasaA!, 3).ToString(), op = "/" });
            #endregion

            #region Brasil
            var brasil = paises.FirstOrDefault(x => x.Pais == "Brasil");
            var BRL = brasil?.ValorMoneda - ((brasil?.ValorMoneda * 5) / 100);

            var tasaB = VES / BRL;
            Tasas.Add(new ResponseTasas { pais = "Brasil", tasa = decimal.Round((decimal)tasaB!, 2).ToString(), op = "/" });
            #endregion

            #region Ecuador
            var ecuador = paises.FirstOrDefault(x => x.Pais == "Ecuador");
            var USD = ecuador?.ValorMoneda - ((ecuador?.ValorMoneda * 3) / 100);

            var tasaE = VES / USD;
            Tasas.Add(new ResponseTasas { pais = "Ecuador", tasa = decimal.Round((decimal)tasaE!, 2).ToString(), op = "/" });
            #endregion

            #region UUEE
            var EEUU = paises.FirstOrDefault(x => x.Pais == "EEUU");
            var USDEU = EEUU?.ValorMoneda;

            var tasaEU = VES / USDEU;
            Tasas.Add(new ResponseTasas { pais = "EEUU", tasa = decimal.Round((decimal)tasaEU!, 2).ToString(), op = "/" });
            #endregion

            return Tasas;


        }
        public async Task<List<ResponseTasas>> GetTasasColombia()
        {
            var Tasas = new List<ResponseTasas>();
            var paises = await _tasasContext.TasasPs.ToListAsync();
            var colombia = paises.FirstOrDefault(x => x.Pais == "Colombia");
            var COP = colombia?.ValorMoneda + ((colombia!.ValorMoneda * 5) / 100);

            #region Venezuela
            var venezuela = paises.FirstOrDefault(x => x.Pais == "Venezuela");
            var VES = venezuela?.ValorMoneda - ((venezuela?.ValorMoneda * 5) / 100);
            var tasa = COP / VES;


            Tasas.Add(new ResponseTasas { pais = "Venezuela", tasa = decimal.Round((decimal)tasa!, 0).ToString(), op = "/" });

            #endregion

            #region Ecuador
            var ecuador = paises.FirstOrDefault(x => x.Pais == "Ecuador");
            var USD = ecuador?.ValorMoneda - ((ecuador?.ValorMoneda * 3) / 100);

            var tasaE = COP / USD;
            Tasas.Add(new ResponseTasas { pais = "Ecuador", tasa = decimal.Round((decimal)tasaE!, 2).ToString(), op = "/" });
            #endregion

            #region Chile 
            var chile = paises.FirstOrDefault(x => x.Pais == "Chile");
            var CLP = chile?.ValorMoneda - ((chile?.ValorMoneda * 5) / 100);

            var tasaC = COP / CLP;
            Tasas.Add(new ResponseTasas { pais = "Chile", tasa = decimal.Round((decimal)tasaC!, 2).ToString(), op = "/" });
            #endregion

            #region Peru
            var peru = paises.FirstOrDefault(x => x.Pais == "Peru");
            var PEN = peru?.ValorMoneda - ((peru?.ValorMoneda * 5) / 100);

            var tasaP = COP / PEN;
            Tasas.Add(new ResponseTasas { pais = "Peru", tasa = decimal.Round((decimal)tasaP!, 0).ToString(), op = "/" });
            #endregion

            #region Mexico
            var mexico = paises.FirstOrDefault(x => x.Pais == "Mexico");
            var MXN = mexico?.ValorMoneda - ((mexico?.ValorMoneda * 9) / 100);

            var tasaM = COP / MXN;
            Tasas.Add(new ResponseTasas { pais = "Mexico", tasa = decimal.Round((decimal)tasaM!, 0).ToString(), op = "/" });
            #endregion

            #region Brasil
            var brasil = paises.FirstOrDefault(x => x.Pais == "Brasil");
            var BRL = brasil?.ValorMoneda - ((brasil?.ValorMoneda * 5) / 100);

            var tasaB = COP / BRL;
            Tasas.Add(new ResponseTasas { pais = "Brasil", tasa = decimal.Round((decimal)tasaB!, 0).ToString(), op = "/" });
            #endregion

            return Tasas;
        }

        public async Task<List<ResponseTasas>> GetTasasChile()
        {
            var Tasas = new List<ResponseTasas>();
            var paises = await _tasasContext.TasasPs.ToListAsync();
            var chile = paises.FirstOrDefault(x => x.Pais == "Chile");
            var CLP = chile?.ValorMoneda + ((chile?.ValorMoneda * 5) / 100);

            #region Venezuela
            var venezuela = paises.FirstOrDefault(x => x.Pais == "Venezuela");
            var VES = venezuela?.ValorMoneda - ((venezuela?.ValorMoneda * 5) / 100);
            var tasa = VES / CLP;


            Tasas.Add(new ResponseTasas { pais = "Venezuela", tasa = decimal.Round((decimal)tasa!, 4).ToString(), op = "*" });
            #endregion

            #region Colombia
            var colombia = paises.FirstOrDefault(x => x.Pais == "Colombia");
            var COP = colombia?.ValorMoneda - ((colombia!.ValorMoneda * 5) / 100);


            var tasaC = CLP / COP;


            Tasas.Add(new ResponseTasas { pais = "Colombia", tasa = decimal.Round((decimal)tasaC!, 3).ToString(), op = "/" });

            #endregion

            #region Ecuador
            var ecuador = paises.FirstOrDefault(x => x.Pais == "Ecuador");
            var USD = ecuador?.ValorMoneda - ((ecuador?.ValorMoneda * 3) / 100);

            var tasaE = CLP / USD;
            Tasas.Add(new ResponseTasas { pais = "Ecuador", tasa = decimal.Round((decimal)tasaE!, 2).ToString(), op = "/" });
            #endregion

            #region Peru
            var peru = paises.FirstOrDefault(x => x.Pais == "Peru");
            var PEN = peru?.ValorMoneda - ((peru?.ValorMoneda * 5) / 100);

            var tasaP = PEN / CLP;
            Tasas.Add(new ResponseTasas { pais = "Peru", tasa = decimal.Round((decimal)tasaP!, 4).ToString(), op = "*" });
            #endregion

            #region Brasil
            var brasil = paises.FirstOrDefault(x => x.Pais == "Brasil");
            var BRL = brasil?.ValorMoneda - ((brasil?.ValorMoneda * 5) / 100);

            var tasaB =  BRL/CLP;
            Tasas.Add(new ResponseTasas { pais = "Brasil", tasa = decimal.Round((decimal)tasaB!, 4).ToString(), op = "*" });
            #endregion

            #region Mexico
            var mexico = paises.FirstOrDefault(x => x.Pais == "Mexico");
            var MXN = mexico?.ValorMoneda - ((mexico?.ValorMoneda * 9) / 100);

            var tasaM = MXN / CLP;
            Tasas.Add(new ResponseTasas { pais = "Mexico", tasa = decimal.Round((decimal)tasaM!, 4).ToString(), op = "*" });
            #endregion

            #region Argentina
            var argentina = paises.FirstOrDefault(x => x.Pais == "Argentina");
            var ARS = argentina?.ValorMoneda - ((argentina?.ValorMoneda * 5) / 100);

            var tasaA = CLP / ARS;
            Tasas.Add(new ResponseTasas { pais = "Argentina", tasa = decimal.Round((decimal)tasaA!, 3).ToString(), op = "/" });
            #endregion


            return Tasas;
        }
        public async Task<List<ResponseTasas>> GetTasasPeru()
        {
            var Tasas = new List<ResponseTasas>();
            var paises = await _tasasContext.TasasPs.ToListAsync();
            var peru = paises.FirstOrDefault(x => x.Pais == "Peru");
            var PEN = peru?.ValorMoneda + ((peru?.ValorMoneda * 5) / 100);

            #region Venezuela
            var venezuela = paises.FirstOrDefault(x => x.Pais == "Venezuela");
            var VES = venezuela?.ValorMoneda - ((venezuela?.ValorMoneda * 3) / 100);
            var tasa = VES / PEN;


            Tasas.Add(new ResponseTasas { pais = "Venezuela", tasa = decimal.Round((decimal)tasa!, 2).ToString(), op = "*" });
            #endregion

            #region Colombia
            var colombia = paises.FirstOrDefault(x => x.Pais == "Colombia");
            var COP = colombia?.ValorMoneda - ((colombia!.ValorMoneda * 5) / 100);


            var tasaC = COP / PEN;


            Tasas.Add(new ResponseTasas { pais = "Colombia", tasa = decimal.Round((decimal)tasaC!, 0).ToString(), op = "*" });
            #endregion

            #region Chile
            var chile = paises.FirstOrDefault(x => x.Pais == "Chile");
            var CLP = chile?.ValorMoneda - ((chile?.ValorMoneda * 5) / 100);

            var tasaCh = PEN / CLP;
            Tasas.Add(new ResponseTasas { pais = "Chile", tasa = decimal.Round((decimal)tasaC!, 2).ToString(), op = "/" });
            #endregion

            #region Mexico
            var mexico = paises.FirstOrDefault(x => x.Pais == "Mexico");
            var MXN = mexico?.ValorMoneda - ((mexico?.ValorMoneda * 9) / 100);

            var tasaM = MXN /PEN;
            Tasas.Add(new ResponseTasas { pais = "Mexico", tasa = decimal.Round((decimal)tasaM!, 2).ToString(), op = "*" });
            #endregion

            #region Brasil
            var brasil = paises.FirstOrDefault(x => x.Pais == "Brasil");
            var BRL = brasil?.ValorMoneda - ((brasil?.ValorMoneda * 5) / 100);

            var tasaB = BRL / PEN;
            Tasas.Add(new ResponseTasas { pais = "Brasil", tasa = decimal.Round((decimal)tasaB!, 2).ToString(), op = "*" });
            #endregion

            #region Ecuador
            var ecuador = paises.FirstOrDefault(x => x.Pais == "Ecuador");
            var USD = ecuador?.ValorMoneda - ((ecuador?.ValorMoneda * 5) / 100);

            var tasaE = PEN/USD;
            Tasas.Add(new ResponseTasas { pais = "Ecuador", tasa = decimal.Round((decimal)tasaE!, 2).ToString(), op = "*" });
            #endregion
            return Tasas;
        }

        public async Task<List<ResponseTasas>> GetTasasMexico()
        {
            var Tasas = new List<ResponseTasas>();
            var paises = await _tasasContext.TasasPs.ToListAsync();
            var mexico = paises.FirstOrDefault(x => x.Pais == "Mexico");
            var MXN = mexico?.ValorMoneda + ((mexico?.ValorMoneda * 9) / 100);

            #region Venezuela

            var venezuela = paises.FirstOrDefault(x => x.Pais == "Venezuela");
            var VES = venezuela?.ValorMoneda - ((venezuela?.ValorMoneda * 5) / 100);

            var tasav = VES / MXN;
            Tasas.Add(new ResponseTasas { pais = "Venezuela", tasa = decimal.Round((decimal)tasav!, 2).ToString(), op = "*" });
            #endregion

            #region Colombia
            var colombia = paises.FirstOrDefault(x => x.Pais == "Colombia");
            var COP = colombia?.ValorMoneda - ((colombia!.ValorMoneda * 5) / 100);
            var tasaC =  COP/MXN  ;
            Tasas.Add(new ResponseTasas { pais = "Colombia", tasa = decimal.Round((decimal)tasaC!, 0).ToString(), op = "*" });
            #endregion

            #region Ecuador
            var ecuador = paises.FirstOrDefault(x => x.Pais == "Ecuador");
            var USD = ecuador?.ValorMoneda - ((ecuador?.ValorMoneda * 3) / 100);

            var tasaE = MXN / USD;
            Tasas.Add(new ResponseTasas { pais = "Ecuador", tasa = decimal.Round((decimal)tasaE!, 2).ToString(), op = "/" });
            #endregion

            #region Peru

            var peru = paises.FirstOrDefault(x => x.Pais == "Peru");
            var PEN = peru?.ValorMoneda - ((peru?.ValorMoneda * 5) / 100);

            var tasaP =   MXN / PEN ;
            Tasas.Add(new ResponseTasas { pais = "Peru", tasa = decimal.Round((decimal)tasaP!, 2).ToString(), op = "/" });
            #endregion

            #region Chile

            var chile = paises.FirstOrDefault(x => x.Pais == "Chile");
            var CLP = chile?.ValorMoneda - ((chile?.ValorMoneda * 5) / 100);

            var tasaCh =  CLP / MXN;
            Tasas.Add(new ResponseTasas { pais = "Chile", tasa = decimal.Round((decimal)tasaCh!, 0).ToString(), op = "*" });


            #endregion

            #region Brasil
            var brasil = paises.FirstOrDefault(x => x.Pais == "Brasil");
            var BRL = brasil?.ValorMoneda - ((brasil?.ValorMoneda * 5) / 100);

            var tasaB = MXN/BRL ;
            Tasas.Add(new ResponseTasas { pais = "Brasil", tasa = decimal.Round((decimal)tasaB!, 2).ToString(), op = "/" });
            #endregion
            return Tasas;
        }

        public async Task<List<ResponseTasas>> GetTasasEcuador()
        {
            var Tasas = new List<ResponseTasas>();
            var paises = await _tasasContext.TasasPs.ToListAsync();
            var ecuador = paises.FirstOrDefault(x => x.Pais == "Ecuador");
            var USD = ecuador?.ValorMoneda + ((ecuador?.ValorMoneda * 5) / 100);

            #region Colombia

            var colombia = paises.FirstOrDefault(x => x.Pais == "Colombia");
            var COP = colombia?.ValorMoneda - ((colombia!.ValorMoneda * 5) / 100);


            var tasa = COP / USD;


            Tasas.Add(new ResponseTasas { pais = "Colombia", tasa = decimal.Round((decimal)tasa!, 0).ToString(), op = "*" });

            #endregion

            #region Chile

            var chile = paises.FirstOrDefault(x => x.Pais == "Chile");
            var CLP = chile?.ValorMoneda - ((chile?.ValorMoneda * 5) / 100);

            var tasaC = CLP / USD;
            Tasas.Add(new ResponseTasas { pais = "Chile", tasa = decimal.Round((decimal)tasaC!, 0).ToString(), op = "*" });


            #endregion

            #region Peru

            var peru = paises.FirstOrDefault(x => x.Pais == "Peru");
            var PEN = peru?.ValorMoneda - ((peru?.ValorMoneda * 5) / 100);

            var tasaP = PEN / USD;
            Tasas.Add(new ResponseTasas { pais = "Peru", tasa = decimal.Round((decimal)tasaP!, 1).ToString(), op = "*" });
            #endregion

            #region Mexico
            var mexico = paises.FirstOrDefault(x => x.Pais == "Mexico");
            var MXN = mexico?.ValorMoneda - ((mexico?.ValorMoneda * 10) / 100);

            var tasaM = MXN / USD;
            Tasas.Add(new ResponseTasas { pais = "Mexico", tasa = decimal.Round((decimal)tasaM!, 0).ToString(), op = "*" });
            #endregion

            #region Venezuela

            var venezuela = paises.FirstOrDefault(x => x.Pais == "Venezuela");
            var VES = venezuela?.ValorMoneda - ((venezuela?.ValorMoneda * 3) / 100);

            var tasav = VES / MXN;
            Tasas.Add(new ResponseTasas { pais = "Venezuela", tasa = decimal.Round((decimal)tasav!, 2).ToString(), op = "*" });
            #endregion

            #region Brasil
            var brasil = paises.FirstOrDefault(x => x.Pais == "Brasil");
            var BRL = brasil?.ValorMoneda - ((brasil?.ValorMoneda * 5) / 100);

            var tasaB = BRL / USD;
            Tasas.Add(new ResponseTasas { pais = "Brasil", tasa = decimal.Round((decimal)tasaB!, 1).ToString(), op = "*" });
            #endregion
            

            return Tasas;
        }

        public async Task<List<ResponseTasas>> GetTasasPanama()
        {
            var Tasas = new List<ResponseTasas>();
            var paises = await _tasasContext.TasasPs.ToListAsync();
            var panama = paises.FirstOrDefault(x => x.Pais == "Panama");
            var USD = panama?.ValorMoneda + ((panama?.ValorMoneda * 5) / 100);

            #region Colombia

            var colombia = paises.FirstOrDefault(x => x.Pais == "Colombia");
            var COP = colombia?.ValorMoneda - ((colombia!.ValorMoneda * 5) / 100);


            var tasa = COP / USD;


            Tasas.Add(new ResponseTasas { pais = "Colombia", tasa = decimal.Round((decimal)tasa!, 0).ToString(), op = "*" });

            #endregion

            #region Chile

            var chile = paises.FirstOrDefault(x => x.Pais == "Chile");
            var CLP = chile?.ValorMoneda - ((chile?.ValorMoneda * 5) / 100);

            var tasaC = CLP / USD;
            Tasas.Add(new ResponseTasas { pais = "Chile", tasa = decimal.Round((decimal)tasaC!, 0).ToString(), op = "*" });


            #endregion

            #region Peru

            var peru = paises.FirstOrDefault(x => x.Pais == "Peru");
            var PEN = peru?.ValorMoneda - ((peru?.ValorMoneda * 5) / 100);

            var tasaP = PEN / USD;
            Tasas.Add(new ResponseTasas { pais = "Peru", tasa = decimal.Round((decimal)tasaP!, 1).ToString(), op = "*" });
            #endregion

            #region Mexico
            var mexico = paises.FirstOrDefault(x => x.Pais == "Mexico");
            var MXN = mexico?.ValorMoneda - ((mexico?.ValorMoneda * 9) / 100);

            var tasaM = MXN / USD;
            Tasas.Add(new ResponseTasas { pais = "Mexico", tasa = decimal.Round((decimal)tasaM!, 0).ToString(), op = "*" });
            #endregion

            #region Brasil
            var brasil = paises.FirstOrDefault(x => x.Pais == "Brasil");
            var BRL = brasil?.ValorMoneda - ((brasil?.ValorMoneda * 5) / 100);

            var tasaB = BRL / USD;
            Tasas.Add(new ResponseTasas { pais = "Brasil", tasa = decimal.Round((decimal)tasaB!, 1).ToString(), op = "*" });
            #endregion

            return Tasas;
        }

        public async Task<List<ResponseTasas>> GetTasasEEUU()
        {
            var Tasas = new List<ResponseTasas>();
            var paises = await _tasasContext.TasasPs.ToListAsync();
            var eeuu = paises.FirstOrDefault(x => x.Pais == "EEUU");
            var USD = eeuu?.ValorMoneda + ((eeuu?.ValorMoneda * 5)/100);

            #region Colombia

            var colombia = paises.FirstOrDefault(x => x.Pais == "Colombia");
            var COP = colombia?.ValorMoneda - ((colombia!.ValorMoneda * 5) / 100);


            var tasa = COP / USD;


            Tasas.Add(new ResponseTasas { pais = "Colombia", tasa = decimal.Round((decimal)tasa!, 0).ToString(), op = "*" });

            #endregion

            #region Chile

            var chile = paises.FirstOrDefault(x => x.Pais == "Chile");
            var CLP = chile?.ValorMoneda - ((chile?.ValorMoneda * 5) / 100);

            var tasaC =  CLP /USD;
            Tasas.Add(new ResponseTasas { pais = "Chile", tasa = decimal.Round((decimal)tasaC!, 0).ToString(), op = "*" });


            #endregion

            #region Peru

            var peru = paises.FirstOrDefault(x => x.Pais == "Peru");
            var PEN = peru?.ValorMoneda - ((peru?.ValorMoneda * 5) / 100);

            var tasaP = PEN / USD;
            Tasas.Add(new ResponseTasas { pais = "Peru", tasa = decimal.Round((decimal)tasaP!, 1).ToString(), op = "*" });
            #endregion

            #region Mexico
            var mexico = paises.FirstOrDefault(x => x.Pais == "Mexico");
            var MXN = mexico?.ValorMoneda - ((mexico?.ValorMoneda * 10) / 100);

            var tasaM = MXN / USD;
            Tasas.Add(new ResponseTasas { pais = "Mexico", tasa = decimal.Round((decimal)tasaM!, 0).ToString(), op = "*" });
            #endregion

            #region Argentina
            var argentina = paises.FirstOrDefault(x => x.Pais == "Argentina");
            var ARS = argentina?.ValorMoneda - ((argentina?.ValorMoneda * 5) / 100);

            var tasaA = ARS / USD;
            Tasas.Add(new ResponseTasas { pais = "Argentina", tasa = decimal.Round((decimal)tasaA!, 3).ToString(), op = "/" });
            #endregion

            #region Brasil
            var brasil = paises.FirstOrDefault(x => x.Pais == "Brasil");
            var BRL = brasil?.ValorMoneda - ((brasil?.ValorMoneda * 5) / 100);

            var tasaB = BRL / USD;
            Tasas.Add(new ResponseTasas { pais = "Brasil", tasa = decimal.Round((decimal)tasaB!, 1).ToString(), op = "*" });
            #endregion

            return Tasas;
        }

        public async Task<List<ResponseTasas>> GetTasasEspaña()
        {
            var Tasas = new List<ResponseTasas>();
            var paises = await _tasasContext.TasasPs.ToListAsync();
            var eeuu = paises.FirstOrDefault(x => x.Pais == "España");
            var EUR = eeuu?.ValorMoneda + ((eeuu?.ValorMoneda * 4) / 100);

            #region Colombia

            var colombia = paises.FirstOrDefault(x => x.Pais == "Colombia");
            var COP = colombia?.ValorMoneda - ((colombia!.ValorMoneda * 5) / 100);


            var tasa = COP / EUR;


            Tasas.Add(new ResponseTasas { pais = "Colombia", tasa = decimal.Round((decimal)tasa!, 0).ToString(), op = "*" });

            #endregion

            #region Chile

            var chile = paises.FirstOrDefault(x => x.Pais == "Chile");
            var CLP = chile?.ValorMoneda - ((chile?.ValorMoneda * 5) / 100);

            var tasaC = CLP / EUR;
            Tasas.Add(new ResponseTasas { pais = "Chile", tasa = decimal.Round((decimal)tasaC!, 0).ToString(), op = "*" });


            #endregion

            #region Peru

            var peru = paises.FirstOrDefault(x => x.Pais == "Peru");
            var PEN = peru?.ValorMoneda - ((peru?.ValorMoneda * 5) / 100);

            var tasaP = PEN / EUR;
            Tasas.Add(new ResponseTasas { pais = "Peru", tasa = decimal.Round((decimal)tasaP!, 1).ToString(), op = "*" });
            #endregion

            #region Mexico
            var mexico = paises.FirstOrDefault(x => x.Pais == "Mexico");
            var MXN = mexico?.ValorMoneda - ((mexico?.ValorMoneda * 10) / 100);

            var tasaM = MXN / EUR;
            Tasas.Add(new ResponseTasas { pais = "Mexico", tasa = decimal.Round((decimal)tasaM!, 0).ToString(), op = "*" });
            #endregion

            #region Argentina
            var argentina = paises.FirstOrDefault(x => x.Pais == "Argentina");
            var ARS = argentina?.ValorMoneda - ((argentina?.ValorMoneda * 5) / 100);

            var tasaA = ARS / EUR;
            Tasas.Add(new ResponseTasas { pais = "Argentina", tasa = decimal.Round((decimal)tasaA!, 3).ToString(), op = "/" });
            #endregion

            #region Brasil
            var brasil = paises.FirstOrDefault(x => x.Pais == "Brasil");
            var BRL = brasil?.ValorMoneda - ((brasil?.ValorMoneda * 5) / 100);

            var tasaB = BRL / EUR;
            Tasas.Add(new ResponseTasas { pais = "Brasil", tasa = decimal.Round((decimal)tasaB!, 1).ToString(), op = "*" });
            #endregion

            #region Ecuador
            var ecuador = paises.FirstOrDefault(x => x.Pais == "Ecuador");
            var USD = ecuador?.ValorMoneda - ((ecuador?.ValorMoneda * 3) / 100);

            var tasaE = EUR / USD;
            Tasas.Add(new ResponseTasas { pais = "Ecuador", tasa = decimal.Round((decimal)tasaE!, 2).ToString(), op = "/" });
            #endregion

            return Tasas;
        }

        public async Task<List<ResponseTasas>> GetTasasArgentina()
        {
            var Tasas = new List<ResponseTasas>();
            var paises = await _tasasContext.TasasPs.ToListAsync();
            var argentina = paises.FirstOrDefault(x => x.Pais == "Argentina");
            var ARS = argentina?.ValorMoneda + ((argentina?.ValorMoneda * 5) / 100);

            #region Venezuela
            var venezuela = paises.FirstOrDefault(x => x.Pais == "Venezuela");
            var VES = venezuela?.ValorMoneda - ((venezuela?.ValorMoneda * 5) / 100);
            var tasaV =  VES / ARS;

            Tasas.Add(new ResponseTasas { pais = "Venezuela", tasa = decimal.Round((decimal)tasaV!, 3).ToString(), op = "*" });

            #endregion

            #region Colombia

            var colombia = paises.FirstOrDefault(x => x.Pais == "Colombia");
            var COP = colombia?.ValorMoneda - ((colombia!.ValorMoneda * 5) / 100);


            var tasa = COP / ARS;


            Tasas.Add(new ResponseTasas { pais = "Colombia", tasa = decimal.Round((decimal)tasa!, 2).ToString(), op = "*" });

            #endregion

            #region Ecuador
            var ecuador = paises.FirstOrDefault(x => x.Pais == "Ecuador");
            var USD = ecuador?.ValorMoneda - ((ecuador?.ValorMoneda * 3) / 100);

            var tasaE = VES / USD;
            Tasas.Add(new ResponseTasas { pais = "Ecuador", tasa = decimal.Round((decimal)tasaE!, 2).ToString(), op = "/" });
            #endregion

            #region Peru

            var peru = paises.FirstOrDefault(x => x.Pais == "Peru");
            var PEN = peru?.ValorMoneda - ((peru?.ValorMoneda * 5) / 100);

            var tasaP = ARS / PEN;
            Tasas.Add(new ResponseTasas { pais = "Peru", tasa = decimal.Round((decimal)tasaP!, 0).ToString(), op = "/" });
            #endregion

            #region Chile

            var chile = paises.FirstOrDefault(x => x.Pais == "Chile");
            var CLP = chile?.ValorMoneda - ((chile?.ValorMoneda * 5) / 100);

            var tasaC =  CLP / ARS;
            Tasas.Add(new ResponseTasas { pais = "Chile", tasa = decimal.Round((decimal)tasaC!, 2).ToString(), op = "*" });


            #endregion

            #region Mexico
            var mexico = paises.FirstOrDefault(x => x.Pais == "Mexico");
            var MXN = mexico?.ValorMoneda - ((mexico?.ValorMoneda * 9) / 100);

            var tasaM = ARS / MXN;
            Tasas.Add(new ResponseTasas { pais = "Mexico", tasa = decimal.Round((decimal)tasaM!, 0).ToString(), op = "/" });
            #endregion

            #region Brasil
            var brasil = paises.FirstOrDefault(x => x.Pais == "Brasil");
            var BRL = brasil?.ValorMoneda - ((brasil?.ValorMoneda * 5) / 100);

            var tasaB = ARS/BRL ;
            Tasas.Add(new ResponseTasas { pais = "Brasil", tasa = decimal.Round((decimal)tasaB!, 0).ToString(), op = "/" });
            #endregion


            return Tasas;
        }

        public async Task<List<ResponseTasas>> GetTasasBrasil()
        {
            var Tasas = new List<ResponseTasas>();
            var paises = await _tasasContext.TasasPs.ToListAsync();
            var brasil = paises.FirstOrDefault(x => x.Pais == "Brasil");
            var BRL = brasil?.ValorMoneda + ((brasil?.ValorMoneda * 5) / 100);

            #region Venezuela
            var venezuela = paises.FirstOrDefault(x => x.Pais == "Venezuela");
            var VES = venezuela?.ValorMoneda - ((venezuela?.ValorMoneda * 5) / 100);
            var tasaV = VES/ BRL;

            Tasas.Add(new ResponseTasas { pais = "Venezuela", tasa = decimal.Round((decimal)tasaV!, 2).ToString(), op = "*" });

            #endregion

            #region Colombia

            var colombia = paises.FirstOrDefault(x => x.Pais == "Colombia");
            var COP = colombia?.ValorMoneda - ((colombia!.ValorMoneda * 5) / 100);


            var tasa = COP / BRL;


            Tasas.Add(new ResponseTasas { pais = "Colombia", tasa = decimal.Round((decimal)tasa!, 0).ToString(), op = "*" });

            #endregion

            #region Ecuador
            var ecuador = paises.FirstOrDefault(x => x.Pais == "Ecuador");
            var USD = ecuador?.ValorMoneda - ((ecuador?.ValorMoneda * 3) / 100);

            var tasaE = VES / USD;
            Tasas.Add(new ResponseTasas { pais = "Ecuador", tasa = decimal.Round((decimal)tasaE!, 2).ToString(), op = "/" });
            #endregion

            #region Peru

            var peru = paises.FirstOrDefault(x => x.Pais == "Peru");
            var PEN = peru?.ValorMoneda - ((peru?.ValorMoneda * 5) / 100);

            var tasaP = BRL / PEN;
            Tasas.Add(new ResponseTasas { pais = "Peru", tasa = decimal.Round((decimal)tasaP!, 2).ToString(), op = "/" });
            #endregion

            #region Chile

            var chile = paises.FirstOrDefault(x => x.Pais == "Chile");
            var CLP = chile?.ValorMoneda - ((chile?.ValorMoneda * 5) / 100);

            var tasaC = CLP / BRL;
            Tasas.Add(new ResponseTasas { pais = "Chile", tasa = decimal.Round((decimal)tasaC!, 0).ToString(), op = "*" });


            #endregion

            #region Mexico
            var mexico = paises.FirstOrDefault(x => x.Pais == "Mexico");
            var MXN = mexico?.ValorMoneda - ((mexico?.ValorMoneda * 9) / 100);

            var tasaM = MXN/BRL;
            Tasas.Add(new ResponseTasas { pais = "Mexico", tasa = decimal.Round((decimal)tasaM!, 2).ToString(), op = "/" });
            #endregion

            return Tasas;
        }

        public async Task<bool> UpdateTasas(Pais pais)
        {
            var paisU = _tasasContext.TasasPs.FirstOrDefault(x=> x.Pais.Equals(pais.pais));
            paisU!.ValorMoneda = pais.valorMoneda;

            _tasasContext?.Update(paisU);
            var result = await _tasasContext!.SaveChangesAsync();

            return result > 0;
        }

        public async Task<List<Pais>> GetPais()
        {
            List<Pais> pais = new();
            var listaPaises = await _tasasContext.TasasPs.Select(x => new { x.Pais, x.ValorMoneda }).ToListAsync();

            foreach (var item in listaPaises)
            {
                pais.Add(new Pais {
                    pais = item.Pais,
                    valorMoneda = item.ValorMoneda
                });
            }

            return pais;
        }
    }
}
