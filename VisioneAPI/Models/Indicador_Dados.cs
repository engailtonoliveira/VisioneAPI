using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VisioneAPI.Models
{
    public class Indicador_Dados
    {
        public int Id { get; set; }
        public Nullable<int> IdEstabelecimento { get; set; }
        public int IdIndicador { get; set; }
        public Nullable<int> IdGestor { get; set; }
        public Nullable<int> IdUGB { get; set; }
        public System.DateTime Data { get; set; }
        public double Dado { get; set; }
        public Nullable<double> Meta { get; set; }
        public Nullable<double> ValorMinimo { get; set; }
        public Nullable<double> ValorMaximo { get; set; }
        public string Usuario { get; set; }
        public Nullable<double> Latitude { get; set; }
        public Nullable<double> Longitude { get; set; }
        public Nullable<int> IdCheckList { get; set; }
        public System.DateTime DataCriacao { get; set; }

    }
}

/*
 [
    {
      "IdEstabelecimento" : 21,
      "IdIndicador": 3396,
      "IdGestor": 7997,
      "IdUGB": 3366,
      "Data": "2019-11-27",
      "Dado": 78.69,
      "Meta": 60,
      "ValorMinimo": 100,
      "ValorMaximo": 0,
      "Usuario": "f02",
      "Latitude": 2.5448,
      "Longitude": 2.5448,
      "IdCheckList": 693,
      "DataCriacao": "2019-11-27T15:40:07.06"
    },
    {
      "IdEstabelecimento" : 21,
      "IdIndicador": 3396,
      "IdGestor": 7997,
      "IdUGB": 3366,
      "Data": "2019-11-27",
      "Dado": 46.93,
      "Meta": 60,
      "ValorMinimo": 100,
      "ValorMaximo": 0,
      "Usuario": "f02",
      "Latitude": 2.5448,
      "Longitude": 2.5448,
      "IdCheckList": 693,
      "DataCriacao": "2019-11-27T15:40:07.06"
    }
    
]
*/
