using ProvaAdmissionalApisul.Models;
using ProvaAdmissionalCSharpApisul;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ProvaAdmissionalApisul.Services
{
    public class ElevadorService : IElevadorService
    {

        public List<ElevadorServiceModel> Elevador { get; set; }

        public List<int> andarMenosUtilizado()
        {
            List<int> retorno = new List<int>();

            var list = from e in Elevador
                       group new
                       {
                           e.Andar
                       }
                       by new
                       {
                           e.Andar
                       } into g
                       select new
                       {
                           g.Key.Andar,
                           qtde = g.Count()
                       };

            foreach (var l in list.OrderBy(l => l.qtde).ThenBy(l => l.Andar))
            {
                retorno.Add(l.Andar);
            }
            return retorno;
        }

        public List<char> elevadorMaisFrequentado()
        {
            List<char> retorno = new List<char>();

            var list = from e in Elevador
                       group new
                       {
                           e.Elevador
                       }
                       by new
                       {
                           e.Elevador
                       } into g
                       select new
                       {
                           g.Key.Elevador,
                           qtde = g.Count()
                       };

            foreach (var e in list.OrderByDescending(e => e.qtde))
            {
                retorno.Add(e.Elevador);
            }

            return retorno;
        }

        public List<char> elevadorMenosFrequentado()
        {
            List<char> retorno = new List<char>();

            var list = from e in Elevador
                       group new
                       {
                           e.Elevador
                       }
                       by new
                       {
                           e.Elevador
                       } into g
                       select new
                       {
                           g.Key.Elevador,
                           qtde = g.Count()
                       };

            foreach (var e in list.OrderBy(e => e.qtde))
            {
                retorno.Add(e.Elevador);
            }

            return retorno;
        }

        private float calculaPercentual(float x, float y)
        {
            return (x / y) * 100;
        }

        public float percentualDeUsoElevadorA()
        {
            float qtdeA = Elevador.Count(e => e.Elevador == 'A');
            return (float)Math.Round(calculaPercentual(qtdeA, Elevador.Count()), 2);
        }

        public float percentualDeUsoElevadorB()
        {
            float qtdeB = Elevador.Count(e => e.Elevador == 'B');
            return (float)Math.Round(calculaPercentual(qtdeB, Elevador.Count()), 2);
        }

        public float percentualDeUsoElevadorC()
        {
            float qtdeC = Elevador.Count(e => e.Elevador == 'C');
            return (float)Math.Round(calculaPercentual(qtdeC, Elevador.Count()), 2);
        }

        public float percentualDeUsoElevadorD()
        {
            int qtdeD = Elevador.Count(e => e.Elevador == 'D');
            return (float)Math.Round(calculaPercentual(qtdeD, Elevador.Count()), 2);
        }

        public float percentualDeUsoElevadorE()
        {
            float qtdeE = Elevador.Count(e => e.Elevador == 'E');
            return (float)Math.Round(calculaPercentual(qtdeE, Elevador.Count()), 2);
        }

        public List<char> periodoMaiorFluxoElevadorMaisFrequentado()
        {
            List<char> listaMaisFrequentado = elevadorMaisFrequentado();
            List<ElevadorServiceModel> novaListaElevadores = new List<ElevadorServiceModel>();

            NovaListaElevadores(novaListaElevadores, listaMaisFrequentado);

            var list = from e in Elevador
                       join n in novaListaElevadores on e.Elevador equals n.Elevador
                       group new
                       {
                           e.Turno
                       }
                       by new
                       {
                           e.Turno
                       } into g
                       select new
                       {
                           g.Key.Turno,
                           qtde = g.Count()
                       };

            List<char> retorno = new List<char>();

            foreach (var e in list.OrderByDescending(e => e.qtde))
            {
                retorno.Add(e.Turno);
            }

            return retorno;

        }

        public List<char> periodoMaiorUtilizacaoConjuntoElevadores()
        {
            var list = from e in Elevador
                       group new
                       {
                           e.Elevador,
                           e.Turno
                       }
                       by new
                       {
                           e.Elevador,
                           e.Turno
                       } into g
                       select new
                       {
                           g.Key.Turno,
                           qtde = g.Count()
                       };

            List<char> retorno = new List<char>();

            foreach (var e in list.OrderByDescending(e => e.qtde))
            {
                retorno.Add(e.Turno);
            }

            return retorno;

        }

        public List<char> periodoMenorFluxoElevadorMenosFrequentado()
        {
            List<char> listaMenosFrequentado = elevadorMenosFrequentado();
            List<ElevadorServiceModel> novaListaElevadores = new List<ElevadorServiceModel>();

            NovaListaElevadores(novaListaElevadores, listaMenosFrequentado);

            var list = from e in Elevador
                       join n in novaListaElevadores on e.Elevador equals n.Elevador
                       group new
                       {
                           e.Elevador,
                           e.Turno
                       }
                       by new
                       {
                           e.Elevador,
                           e.Turno
                       } into g
                       select new
                       {
                           g.Key.Turno,
                           qtde = g.Count()
                       };

            List<char> retorno = new List<char>();

            foreach (var e in list.OrderBy(e => e.qtde))
            {
                retorno.Add(e.Turno);
            }

            return retorno;
        }

        private void NovaListaElevadores(List<ElevadorServiceModel> list, List<char> listChar)
        {
            foreach (var m in listChar)
            {
                list.Add(new ElevadorServiceModel()
                {
                    Elevador = m
                });
            }
        }
    }
}
