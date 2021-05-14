using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProvaAdmissionalApisul.Models;
using ProvaAdmissionalApisul.Services;
using System;
using System.Collections.Generic;
using System.IO;

namespace ProvaAdmissionalApisul
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string startupPath = AppDomain.CurrentDomain.BaseDirectory;
                string arquivo = Path.Combine(startupPath, "input.json");

                string json = new StreamReader(arquivo).ReadToEnd();

                JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
                serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

                List<ElevadorServiceModel> resposta = JsonConvert.DeserializeObject<List<ElevadorServiceModel>>(json, serializerSettings);

                ElevadorService elevador = new ElevadorService();

                elevador.Elevador = resposta;

                string opc = "";
                Console.WriteLine("Bem vindo!");
                while (!opc.Equals("z"))
                {
                    Console.WriteLine("Escolha uma das opções do menu: ");

                    Console.WriteLine("a. Qual é o andar menos utilizado pelos usuários");
                    Console.WriteLine("b. Qual é o elevador mais frequentado e o período que se encontra maior fluxo");
                    Console.WriteLine("c. Qual é o elevador menos frequentado e o período que se encontra menor fluxo");
                    Console.WriteLine("d. Qual o período de maior utilização do conjunto de elevadores");
                    Console.WriteLine("e. Qual o percentual de uso de cada elevador com relação a todos os serviços prestados \n");
                    Console.WriteLine("z. Pressione z para sair do menu \n");

                    opc = Console.ReadLine();

                    switch (opc)
                    {
                        case "a":
                            Console.WriteLine("\nAndar menos utilizado pelos usuários: " + elevador.andarMenosUtilizado()[0]);
                            break;
                        case "b":
                            Console.WriteLine("\nElevador mais frequentado e o período que se encontra maior fluxo: " +
                                elevador.elevadorMaisFrequentado()[0] + " " + elevador.periodoMaiorFluxoElevadorMaisFrequentado()[0]);
                            break;
                        case "c":
                            Console.WriteLine("\nElevador menos frequentado e o período que se encontra menor fluxo: " +
                            elevador.elevadorMenosFrequentado()[0] + " " + elevador.periodoMenorFluxoElevadorMenosFrequentado()[0]);
                            break;
                        case "d":
                            Console.WriteLine("Período de maior utilização do conjunto de elevadores: " +
                            elevador.periodoMaiorUtilizacaoConjuntoElevadores()[0]);
                            break;
                        case "e":
                            Console.WriteLine("\nPercentual de uso de cada elevador com relação a todos os serviços prestados: \n" +
                                "A - " + elevador.percentualDeUsoElevadorA() + "\n" +
                                "B - " + elevador.percentualDeUsoElevadorB() + "\n" +
                                "C - " + elevador.percentualDeUsoElevadorC() + "\n" +
                                "D - " + elevador.percentualDeUsoElevadorD() + "\n" +
                                "E - " + elevador.percentualDeUsoElevadorE());
                            break;
                        case "z":
                            return;
                        default:
                            Console.WriteLine("\nOpção inválida tente novamente");
                            break;
                    }

                }
            }
            catch (Exception e)
            {
                throw new Exception("Houve um erro inesperado " + e.Message);
            }

        }
    }
}
