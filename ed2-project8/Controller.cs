using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ed2_project8
{
    class Controller
    {
        private Garagens garagens;
        internal Garagens Garagens
        {
            get
            {
                return garagens;
            }

            set
            {
                garagens = value;
            }
        }

        private Viagens viagens;
        internal Viagens Viagens
        {
            get
            {
                return viagens;
            }

            set
            {
                viagens = value;
            }
        }

        private Veiculos veiculos;
        internal Veiculos Veiculos
        {
            get
            {
                return veiculos;
            }

            set
            {
                veiculos = value;
            }
        }
        
        public Controller()
        {
            garagens = new Garagens();
            viagens = new Viagens();
            veiculos = new Veiculos();
        }

        public void addVeiculo(int id, string placa, int lotacao)
        {
            veiculos.Incluir(id, placa, lotacao);            
        }
        public void addGaragem(int id, string local)
        {
            garagens.Incluir(id, local);           
        }

        public void iniciarJornada()
        {
            garagens.iniciarJornada();
        }

        public List<Transporte> encerrarJornada()
        {
            return garagens.encerrarJornada();
        }

        public void addViagem(int id, int idOrigem, int idDestino, int idVeiculo)
        {   
            Garagem garagemOrigem = new Garagem();
            Garagem garagemDestino = new Garagem();
            Veiculo veiculo = new Veiculo();
                        
            foreach(var o in garagens.lGaragens)
            {
                if(o.Id == idOrigem)
                {
                    garagemOrigem = new Garagem(o.Id, o.Local);
                }
                else if(o.Id == idDestino)
                {                    
                    garagemDestino = new Garagem(o.Id, o.Local);
                }
            }
            foreach (var v in veiculos.Lveiculos)
            {
                if (v.Id == idVeiculo)
                {                    
                    veiculo = v;
                }
            }            
            viagens.Incluir(new Viagem(id, garagemOrigem, garagemDestino, veiculo));                
                        
        }        

        public string listarVeiculosGaragem(int idGaragem)
        {            
            foreach (var g in garagens.lGaragens)
            {
                if (g.Id == idGaragem)
                {
                    return "Garagem "+ g.Id +" Local "+ g.Local +", possui "+g.qtdeDeVeiculos()+
                        " veículo(s) e possui um potencial de transporte de "+g.potencialDeTransporte();
                }                
            }
            return "Garagem " + idGaragem + " não encontrada";
        }
        public int listarQtdViagens(int idOrigem, int idDestino)
        {
            Garagem garagemOrigem = new Garagem();
            Garagem garagemDestino = new Garagem();
            int qtdViagens = 0;            
            foreach (var o in garagens.lGaragens)
            {
                if (o.Id == idOrigem)                {
                   
                    garagemOrigem = new Garagem(o.Id, o.Local);
                }
                else if (o.Id == idDestino)                {
                    
                    garagemDestino = new Garagem(o.Id, o.Local);
                }
            }            
            if(viagens.LViagens.Count != 0)
            {                   
                foreach (var v in viagens.LViagens)
                {
                    if (v.Origem.Id == garagemOrigem.Id && v.Destino.Id == garagemDestino.Id)
                    {
                        qtdViagens++;
                    }
                }
            }                
            
            return qtdViagens;
        }
        public List<Viagem> listarViagens(int idOrigem, int idDestino)
        {
            Garagem garagemOrigem = new Garagem();
            Garagem garagemDestino = new Garagem();
            List<Viagem> lViagens = new List<Viagem>();
            foreach (var o in garagens.lGaragens)
            {
                if (o.Id == idOrigem)
                {

                    garagemOrigem = new Garagem(o.Id, o.Local);
                }
                else if (o.Id == idDestino)
                {

                    garagemDestino = new Garagem(o.Id, o.Local);
                }
            }

            if (viagens.LViagens.Count != 0)
            {
                foreach (var v in viagens.LViagens)
                {
                    if (v.Origem.Id == garagemOrigem.Id && v.Destino.Id == garagemDestino.Id)
                    {
                        lViagens.Add(v);
                    }
                }
            }               
            
            return lViagens;
        }

        public int qtdPassageirosViagem(int idOrigem, int idDestino)
        {
            int qtdPassageiros = 0;
            List<Viagem> lViagens = new List<Viagem>();
            if (listarViagens(idOrigem, idDestino).Count != 0)
            {
               lViagens = listarViagens(idOrigem, idDestino);
            }           
            foreach(var v in lViagens)
            {
                qtdPassageiros += v.Veiculo.Lotacao;
            }
            return qtdPassageiros;
        }
    }
}
