using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ed2_project8
{
    class Transporte
    {
        private Veiculo veiculo;
        private int qtdeTransportada;

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

        public int QtdeTransportada
        {
            get
            {
                return qtdeTransportada;
            }

            set
            {
                qtdeTransportada = value;
            }
        }
    }
}
