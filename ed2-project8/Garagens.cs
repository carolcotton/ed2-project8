using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ed2_project8
{
    class Garagens
    {
        private List<Garagem> garagens;
        private bool jornadaAtiva;

        public bool JornadaAtiva
        {
            get
            {
                return jornadaAtiva;
            }

            set
            {
                jornadaAtiva = value;
            }
        }

        internal List<Garagem> lGaragens
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

        public Garagens()
        {
            lGaragens = new List<Garagem>();
            jornadaAtiva = false;
        }

        public void Incluir(int id, string local)
        {
            garagens.Add(new Garagem(id, local));
        }
        public void iniciarJornada()
        {
            jornadaAtiva = true;
        }
        public List<Transporte> encerrarJornada()
        {
            jornadaAtiva = false;
            //verificar

            List<Transporte> listTransporte = new List<Transporte>();            
            return listTransporte;
        }
        public void addVeiculo(int idGaragem, Veiculo veiculo)
        {
           foreach(var g in lGaragens)
            {
                if(g.Id == idGaragem)
                {                    
                    g.addVeiculo(veiculo);
                }
            }
        }
    }
}
