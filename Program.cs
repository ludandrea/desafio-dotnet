using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;

namespace desafio_dot_net
{
    class Program
    {
        static void Main(string[] args)
        {
            var elevadorService = new ElevadorService();

            var andarMenosUtilizado = elevadorService.andarMenosUtilizado()[0];

            var elevadorMaisFrequentado = elevadorService.elevadorMaisFrequentado()[0];

            var turnoMaisUtilizado = elevadorService.periodoMaiorFluxoElevadorMaisFrequentado()[0];

            var elevadorMenosFrequentado = elevadorService.elevadorMenosFrequentado()[0];

            var turnoMenosUtilizado = elevadorService.periodoMenorFluxoElevadorMenosFrequentado()[0];

            var turnoMaisUtilizadoConjunto = elevadorService.periodoMaiorUtilizacaoConjuntoElevadores()[0];

            var usoElevadorA = elevadorService.percentualDeUsoElevadorA();

            var usoElevadorB = elevadorService.percentualDeUsoElevadorB();

            var usoElevadorC = elevadorService.percentualDeUsoElevadorC();

            // a. Qual é o andar menos utilizado pelos usuários; 
            Console.WriteLine($"{andarMenosUtilizado} é o andar menos utilizado pelos usuários");

            // b. Qual é o elevador mais frequentado e o período que se encontra maior fluxo;
            Console.WriteLine($"{elevadorMaisFrequentado} é o elevador mais frequentado e {turnoMaisUtilizado} é o período que se encontra maior fluxo");
            
            // c. Qual é o elevador menos frequentado e o período que se encontra menor fluxo;
            Console.WriteLine($"{elevadorMenosFrequentado} é o elevador menos frequentado e {turnoMenosUtilizado} é o período que se encontra menor fluxo");

            // d. Qual o período de maior utilização do conjunto de elevadores;
            Console.WriteLine($"{turnoMaisUtilizadoConjunto} é o período de maior utilização do conjunto de elevadores");

            // e. Qual o percentual de uso de cada elevador com relação a todos os serviços prestados; 
            Console.WriteLine($"uso do elevador A: {usoElevadorA}%, uso do elevador B: {usoElevadorB}%, uso do elevador C: {usoElevadorC}% ");

            string fim = Console.ReadLine();
        }
    }
}
