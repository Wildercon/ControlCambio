﻿using ControlCambioApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
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
                        Tasas.Add(new ResponseTasas { pais = paise.Pais, tasa = tasa.ToString(), op = listaC.Op, porcentaje = Porc.ToString() ,tipomoneda = paise.TipoMoneda,tipomonedaE = paisSeleccionado.TipoMoneda});
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
        

        public async Task<bool> UpdateTasas(TasasPDTO pais)
        {
            var paisU = _tasasContext.TasasPs.FirstOrDefault(x=> x.Pais.Equals(pais.Pais));
            paisU!.ValorMoneda = pais.ValorMoneda;
            paisU.FechaA = pais.FechaA;

            _tasasContext?.Update(paisU);
            var result = await _tasasContext!.SaveChangesAsync();

            return result > 0;
        }

        public async Task<List<TasasPDTO>> GetPais()
        {
            return await _tasasContext.TasasPs.Select( t => new TasasPDTO(t.Pais,t.ValorMoneda,t.FechaA,t.TipoMoneda)).ToListAsync();

        }

        public async Task<RateOfDay> GetTasaPreferencials()
        {
            

            var paises = await _tasasContext.TasasPs
                .Where(t => t.Pais == "Venezuela" || t.Pais == "EEUU")
                .ToListAsync();

            var commision = await _tasasContext.Commissions
                        .Where(c => c.Pais == "Venezuela" & c.PaisR == "EEUU").FirstOrDefaultAsync(); 

            var venezuela = paises.Find(x => x.Pais == "Venezuela");
            var eeuu = paises.Find(x => x.Pais == "EEUU");
           
            var tasaVeee = CalculateTasa(venezuela!.ValorMoneda, eeuu!.ValorMoneda, commision!.IsE, commision.Por, commision.Decimals);
            

            

            return new RateOfDay(venezuela.Pais,eeuu.Pais,nameof(tasaVeee),venezuela.TipoMoneda,eeuu.TipoMoneda);

         


        }
    }
}
