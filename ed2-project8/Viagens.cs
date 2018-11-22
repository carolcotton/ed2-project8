using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ed2_project8
{
    class Viagens
    {
        private Queue<Viagem> viagens;

        internal Queue<Viagem> LViagens
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

        public void Incluir (Viagem viagem)
        {
            viagens.Enqueue(viagem);
        }

        public Viagens()
        {
            viagens = new Queue<Viagem>();
        }
    }
}
