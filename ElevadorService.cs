using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace desafio_dot_net
{
    public class ElevadorService : IElevadorService
    {
        private readonly List<Levantamento> Levantamentos;

        public ElevadorService()
        {
            Levantamentos = JsonConvert.DeserializeObject<List<Levantamento>>(File.ReadAllText(@"input.json"));
        }
        public List<int> andarMenosUtilizado()
        {
            var andaresUtilizados = new List<(int andar,int qtd)>();
            var maxAndares = Levantamentos.Select(l => l.andar).Max();
            var minAndares = Levantamentos.Select(l => l.andar).Min();
            for(int andar = minAndares; andar <= maxAndares; andar++)
            {
                var andarUilizacao = Levantamentos.Count(l => l.andar == andar);
                andaresUtilizados.Add((andar,andarUilizacao));
            }
            return andaresUtilizados.OrderBy(a => a.qtd).Select(b => b.andar).ToList();
        }

        public List<char> elevadorMaisFrequentado()
        {
            var elevadoresUtilizados = new List<(char elevador,int qtd)>();
            var elevadores = Levantamentos.Select(l => l.elevador).Distinct().ToList();     
            elevadores.ForEach(e =>{
                var elevadorUilizacao = Levantamentos.Where(l => l.elevador == e).Count();
                elevadoresUtilizados.Add((e,elevadorUilizacao));
            });
            return elevadoresUtilizados.OrderByDescending(el => el.qtd).Select(e => e.elevador).ToList();
        }

        public List<char> elevadorMenosFrequentado()
        {
            var elevadoresUtilizados = new List<(char,int)>();
            var elevadores = Levantamentos.Select(l => l.elevador).Distinct().ToList();
            elevadores.ForEach(e =>{
                var elevadorUilizacao = Levantamentos.Where(l => l.elevador == e).Count();
                elevadoresUtilizados.Add((e,elevadorUilizacao));
            });
            return elevadoresUtilizados.OrderBy(el => el.Item2).Select(e => e.Item1).ToList();
        }

        public float percentualDeUsoElevadorA()
        {
            var usoTotal = (float)Levantamentos.Count;
            var usoElevadorA = (float)Levantamentos.Where(l => l.elevador.Equals('A')).Count();

            return usoElevadorA * 100/usoTotal;
        }

        public float percentualDeUsoElevadorB()
        {
            var usoTotal = (float)Levantamentos.Count;
            var usoElevadorB = (float)Levantamentos.Where(l => l.elevador.Equals('B')).Count();

            return usoElevadorB * 100/usoTotal;
        }

        public float percentualDeUsoElevadorC()
        {
            var usoTotal = (float)Levantamentos.Count;
            var usoElevadorC = (float)Levantamentos.Where(l => l.elevador.Equals('C')).Count();

            return usoElevadorC * 100/usoTotal;
        }

        public float percentualDeUsoElevadorD()
        {
            var usoTotal = (float)Levantamentos.Count;
            var usoElevadorD = (float)Levantamentos.Where(l => l.elevador.Equals('D')).Count();

            return usoElevadorD * 100/usoTotal;
        }

        public float percentualDeUsoElevadorE()
        {
            var usoTotal = (float)Levantamentos.Count;
            var usoElevadorE = (float)Levantamentos.Where(l => l.elevador.Equals('E')).Count();

            return usoElevadorE * 100/usoTotal;;
        }

        public List<char> periodoMaiorFluxoElevadorMaisFrequentado()
        {
            var elevadoresUtilizados = new List<(char turno,int qtd)>();
            var turnos = Levantamentos.Select(l => l.turno).Distinct().ToList();
            var elevadorMaisFrequentado = this.elevadorMaisFrequentado()[0];
            var utilizacoes = Levantamentos.Where(l => l.elevador == elevadorMaisFrequentado);
            turnos.ForEach(t =>{
                var qtd = utilizacoes.Count(u => u.turno == t);
                elevadoresUtilizados.Add((t,qtd));
            });
            return elevadoresUtilizados.OrderByDescending(o => o.qtd).Select(s => s.turno).ToList();
        }

        public List<char> periodoMaiorUtilizacaoConjuntoElevadores()
        {
            var elevadoresUtilizados = new List<(char turno,int qtd)>();
            var turnos = Levantamentos.Select(l => l.turno).Distinct().ToList();

            turnos.ForEach(t =>{
                var qtd = Levantamentos.Count(l => l.turno == t);
                elevadoresUtilizados.Add((t,qtd));
            });

            return elevadoresUtilizados.OrderByDescending(e => e.qtd).Select(t => t.turno).ToList();
        }

        public List<char> periodoMenorFluxoElevadorMenosFrequentado()
        {
            var elevadoresUtilizados = new List<(char turno,int qtd)>();
            var turnos = Levantamentos.Select(l => l.turno).Distinct().ToList();
            var elevadorMaisFrequentado = this.elevadorMenosFrequentado()[0];
            var utilizacoes = Levantamentos.Where(l => l.elevador == elevadorMaisFrequentado);
            turnos.ForEach(t =>{
                var qtd = utilizacoes.Count(u => u.turno == t);
                elevadoresUtilizados.Add((t,qtd));
            });
            return elevadoresUtilizados.OrderBy(o => o.qtd).Select(s => s.turno).ToList();
        }
    }
}