using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ed2_project8
{
    class Veiculo
    {
        private int id;
        private string placa;
        private int lotacao;

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

        public string Placa
        {
            get
            {
                return placa;
            }

            set
            {
                placa = value;
            }
        }

        public int Lotacao
        {
            get
            {
                return lotacao;
            }

            set
            {
                lotacao = value;
            }
        }

        public Veiculo()
        {

        }

        public Veiculo(int id, string placa, int lotacao)
        {
            this.id = id;
            this.placa = placa;
            this.lotacao = lotacao;
        }
    }
}
