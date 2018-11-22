using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ed2_project8
{
    class Veiculos
    {
        private List<Veiculo> veiculos;

        public List<Veiculo> Lveiculos
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

        public Veiculos()
        {
            Lveiculos = new List<Veiculo>();
        }

        public void Incluir(int id, string placa, int lotacao)
        {
            Lveiculos.Add(new Veiculo(id, placa, lotacao));
        }
    }
}
