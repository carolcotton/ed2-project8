using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ed2_project8
{
    class Garagem
    {
        private int id;
        private string local;
        private Stack<Veiculo> veiculos;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Local
        {
            get
            {
                return local;
            }

            set
            {
                local = value;
            }
        }

        internal Stack<Veiculo> Veiculos
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

        public Garagem()
        {

        }

        public Garagem(int id, string local)
        {
            this.id = id;
            this.local = local;            
            veiculos = new Stack<Veiculo>();
        }
        public void addVeiculo(Veiculo veiculo)
        {
            veiculos.Push(veiculo);
        }
        public int qtdeDeVeiculos()
        {
            if (veiculos.Count() != 0)
            {
                return veiculos.Count();
            }
            else
            {
                return 0;
            }    
        }
        public int potencialDeTransporte()
        {
            int potencial = 0;
            if (veiculos.Count() != 0)
            {
                foreach(var v in veiculos)
                {
                    potencial += v.Lotacao;
                }
            }
            return potencial;
        }
    }
}
