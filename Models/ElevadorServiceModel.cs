using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProvaAdmissionalApisul.Models
{
    /// <summary>
    /// Modelo de Entidade de Service de Elevador
    /// </summary>
    public class ElevadorServiceModel
    {
        /// <summary>
        /// Andar
        /// </summary>
        /// 
        [JsonProperty(Order = 1)]
        public int Andar { get; set; }
        /// <summary>
        /// Elevador
        /// </summary>
        /// 
        [JsonProperty(Order = 2)]
        public char Elevador { get; set; }

        /// <summary>
        /// Turno
        /// </summary>
        /// 
        [JsonProperty(Order = 3)]
        public char Turno { get; set; }
    }
}
