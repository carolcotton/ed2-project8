using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ed2_project8
{
    class Viagem
    {
        private int id;
        private Garagem origem;
        private Garagem destino;
        private Veiculo veiculo;

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

        internal Garagem Origem
        {
            get
            {
                return origem;
            }

            set
            {
                origem = value;
            }
        }

        internal Garagem Destino
        {
            get
            {
                return destino;
            }

            set
            {
                destino = value;
            }
        }

        internal Veiculo Veiculo
        {
            get
            {
                return veiculo;
            }

            set
            {
                veiculo = value;
            }
        }

        public Viagem (int id, Garagem origem, Garagem destino, Veiculo veiculo)
        {
            this.id = id;
            this.origem = origem;
            this.destino = destino;
            this.veiculo = veiculo;
        }
    }
}
