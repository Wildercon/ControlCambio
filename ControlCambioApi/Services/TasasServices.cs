using ControlCambioApi.Models;
using Microsoft.EntityFrameworkCore;
using Shared;
using System.Runtime.InteropServices;

namespace ControlCambioApi.Services
{
    public class TasasServices : ITasasServices
    {
        private readonly TasasDbContext _tasasContext;

        public TasasServices(TasasDbContext tasasContext)
        {
            _tasasContext = tasasContext;
        }
        public async Task<List<ResponseTasas>> GetTasas(decimal por, string pais)
        {           
            var Tasas = new List<ResponseTasas>();
            var paises = await _tasasContext.TasasPs.ToListAsync();
            var commission = await _tasasContext.Commissions.Where(x => x.Pais==pais).ToListAsync();
            var paisSeleccionado = paises.FirstOrDefault(x => x.Pais == pais);
            foreach (var paise in paises)
            {
                if(paise.Pais != pais)
                {
                    var listaC = commission.Find(x => x.PaisR == paise.Pais);
                    if(listaC != null)
                    {                       
                        decimal Porc = por == 0 ? listaC.Por : por; 
                        var tasa = CalculateTasa(paisSeleccionado!.ValorMoneda, paise.ValorMoneda, listaC.IsE, Porc, listaC.Decimals);
                        Tasas.Add(new ResponseTasas { pais = paise.Pais, tasa = tasa.ToString(), op = listaC.Op, porcentaje = Porc.ToString() });
                    }else
                        Tasas.Add(new ResponseTasas { pais = paise.Pais, tasa = "No Registrada",op = "No Registrada",porcentaje= "No Registrada" });
                }
            }
            return Tasas;
        }

        private decimal CalculateTasa(decimal paisE, decimal paisR, bool IsE, decimal por, int decimals)
        {
            decimal tasa;
            var porD = por / 2;
            paisE += ((paisE * porD) / 100);
            paisR -= ((paisR * porD) / 100);
            if (IsE)
                tasa = paisE / paisR;
            
            else
                tasa = paisR / paisE;
            return  decimal.Round(tasa,decimals);
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

        public async Task<List<TasaPreferencial>> GetTasaPreferencials()
        {
            List<TasaPreferencial> values = new();
            var paises = await _tasasContext.TasasPs.ToListAsync();
            var commission = await _tasasContext.Commissions.ToListAsync();

            var venezuela = paises.Find(x => x.Pais == "Venezuela");
            var eeuu = paises.Find(x => x.Pais == "EEUU");
            var mexico = paises.Find(x => x.Pais == "Mexico");
            var ecuador = paises.Find(x => x.Pais == "Ecuador");


            var VeEe = commission.Find(x => x.Pais == "Venezuela" & x.PaisR == "EEUU");
            var tasaVeee = CalculateTasa(venezuela!.ValorMoneda, eeuu!.ValorMoneda, VeEe!.IsE, VeEe.Por, VeEe.Decimals);
            values.Add( new TasaPreferencial("Venezuela", "EEUU", tasaVeee  )  );

            var MeVe = commission.Find(x => x.Pais == "Mexico" & x.PaisR == "Venezuela");
            var tasaMeve = CalculateTasa(mexico!.ValorMoneda, venezuela.ValorMoneda, MeVe!.IsE, MeVe.Por, MeVe.Decimals);
            values.Add(new TasaPreferencial("Mexico", "Venezuela", tasaMeve));

            var EcVe = commission.Find(x => x.Pais == "Ecuador" & x.PaisR == "Venezuela");
            var tasaEcVe = CalculateTasa(ecuador!.ValorMoneda, venezuela.ValorMoneda, EcVe!.IsE, EcVe.Por, EcVe.Decimals);
            values.Add(new TasaPreferencial("Ecuador", "Venezuela", tasaEcVe));

            return values;

         


        }
    }
}
