using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ed2_project8
{
    class Program
    {   
        static void Continue ()
        {
            Console.Write("Aperte qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }            
        static void Main(string[] args)
        {

            Controller controller = new Controller();
            int idVeiculo = 1;
            int idGaragem = 1;
            int idViagem = 1;

            try
            {
                controller.addGaragem(idGaragem, "Congonhas");
                idGaragem++;
                Console.WriteLine("-Garagem de Congonhas adicionado com sucesso no ID 1");
                controller.addGaragem(idGaragem, "Guarulhos");
                idGaragem++;
                Console.WriteLine("-Garagem de Guarulhos adicionado com sucesso no ID 2");
                controller.addVeiculo(idVeiculo, "ABC 0001", 12);
                idVeiculo++;
                controller.addVeiculo(idVeiculo, "ABC 0002", 12);
                idVeiculo++;
                controller.addVeiculo(idVeiculo, "ABC 0003", 12);
                idVeiculo++;
                controller.addVeiculo(idVeiculo, "ABC 0004", 12);
                idVeiculo++;
                controller.addVeiculo(idVeiculo, "ABC 0005", 12);
                idVeiculo++;
                controller.addVeiculo(idVeiculo, "ABC 0006", 12);
                idVeiculo++;
                controller.addVeiculo(idVeiculo, "ABC 0007", 12);
                idVeiculo++;
                controller.addVeiculo(idVeiculo, "ABC 0008", 12);
                idVeiculo++;
                Console.WriteLine("-Vans cadastradas com sucesso ID 1 a 8, com lotação para 12 pessoas");
                Continue();
            }
            catch(Exception e)
            {
                Console.WriteLine("Não foi possível adicionar a garagem ou veículos\nErro: " + e.Message);
            }
           

            int op;
            do
            { 
                if(controller.Garagens.JornadaAtiva)
                {
                    Console.WriteLine("---Jornada ativa---");
                }
                else
                {
                    Console.WriteLine("---Jornada inativa---");
                }
                Console.WriteLine("0. Finalizar");
                Console.WriteLine("1. Cadastrar veículo");
                Console.WriteLine("2. Cadastrar garagem");
                Console.WriteLine("3. Iniciar jornada ");
                Console.WriteLine("4. Encerrar jornada");
                Console.WriteLine("5. Liberar viagem de uma determinada origem para um determinado destino ");
                Console.WriteLine("6. Listar veículos em determinada garagem (informando a qtde de veículos e seu potencial de transporte)");
                Console.WriteLine("7. Informar qtde de viagens efetuadas de uma determinada origem para um determinado destino");
                Console.WriteLine("8. Listar viagens efetuadas de uma determinada origem para um determinado destino ");
                Console.WriteLine("9. Informar qtde de passageiros transportados de uma determinada origem para um determinado destino");
                string input = "0";
                do
                {
                    Console.Write("Escolha a opção desejada: ");
                    input = Console.ReadLine();

                    if((input=="1" || input=="2") && controller.Garagens.JornadaAtiva)
                    {
                        Console.WriteLine("Não é possível adicionar veículos ou garagens com a jornada ativa");
                        input = "10";
                    }
                    else if(input=="5" &&  !controller.Garagens.JornadaAtiva )
                    {
                        Console.WriteLine("Não é possível liberar uma viagem com a jornada inativa");
                        input = "10";
                    }
                    else if(input == "4" && !controller.Garagens.JornadaAtiva)
                    {
                        Console.WriteLine("Não é possível encerrar a jornada se a mesma se encontra inativa");
                        input = "10";
                    }
                   
                } while (input == "10");

                op = Convert.ToInt16(input);

                switch (op)
                {
                    case 1:                        
                        try
                        {
                            Console.WriteLine("Id do veículo é: " + idVeiculo);
                            int id = idVeiculo;
                            Console.Write("Insira a placa do veículo : ");
                            string placa = Console.ReadLine();
                            Console.Write("Insira a lotação do veículo : ");
                            int lotacao = Convert.ToInt16(Console.ReadLine());

                            controller.addVeiculo(id, placa, lotacao);
                            idVeiculo++;
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine("Não foi possível adicionar o veículo\nErro: "+ e.Message);
                        }
                        Continue();
                        break;
                    case 2:                        
                        try
                        {
                            Console.WriteLine("Id da garagem é : "+ idGaragem);
                            int id = idGaragem;
                            Console.Write("Insira o local da garagem : ");
                            string local = Console.ReadLine();

                            controller.addGaragem(id, local);
                            idGaragem++;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Não foi possível adicionar a garagem\nErro: " + e.Message);
                        }
                        Continue();
                        break;
                    case 3:
                        try
                        {
                            controller.iniciarJornada();
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine("Não foi possível iniciar a jornada\nErro: " + e.Message);
                        }
                        Console.Clear();                     
                        break;
                    case 4:
                        try
                        {
                            controller.encerrarJornada();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Não foi possível encerrar a jornada\nErro: " + e.Message);
                        }
                        Console.Clear();
                        break;
                    case 5:
                        try
                        {
                            Console.WriteLine("Id da viagem é : "+ idViagem);
                            int idVi = idViagem;
                            Console.Write("Insira o id da origem : ");
                            int idOr = Convert.ToInt16(Console.ReadLine());
                            Console.Write("Insira o id do destino : ");
                            int idDe = Convert.ToInt16(Console.ReadLine());
                            Console.Write("Insira o id do veículo : ");
                            int idVe = Convert.ToInt16(Console.ReadLine());
                            controller.addViagem(idVi, idOr, idDe, idVe);
                            Veiculo veiculo = new Veiculo();
                            foreach (var v in controller.Veiculos.Lveiculos)
                            {
                                if(v.Id == idVe)
                                {
                                    veiculo = v;
                                }                                
                            }                            
                            controller.Garagens.addVeiculo(idDe, veiculo);
                            idViagem++;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Não foi possível efetuar a viagem\nErro: " + e.Message);
                        }
                        Continue();
                        break;
                    case 6:
                        try
                        {
                            Console.Write("Insira o id da garagem : ");
                            int id = Convert.ToInt16(Console.ReadLine());
                            Console.WriteLine(controller.listarVeiculosGaragem(id));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Não foi possível encontrar a garagem\nErro: " + e.Message);
                        }
                        Continue();
                        break;
                    case 7:
                        try
                        {
                            Console.Write("Insira o id da origem : ");
                            int idOr = Convert.ToInt16(Console.ReadLine());
                            Console.Write("Insira o id do destino : ");
                            int idDe = Convert.ToInt16(Console.ReadLine());
                            int qtd = controller.listarQtdViagens(idOr,idDe);
                            Console.WriteLine("Foram realizadas " + qtd +" Viagens");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Não foi possível encontrar a garagem\nErro: " + e.Message);
                        }
                        Continue();
                        break;
                    case 8:
                        try
                        {
                            Console.Write("Insira o id da origem : ");
                            int idOr = Convert.ToInt16(Console.ReadLine());
                            Console.Write("Insira o id do destino : ");
                            int idDe = Convert.ToInt16(Console.ReadLine());
                            List<Viagem> viagens = controller.listarViagens(idOr, idDe);
                            if(viagens.Count != 0)
                            {
                                foreach (var v in viagens)
                                {
                                    Console.WriteLine("Id : " + v.Id);
                                    Console.WriteLine("Origem : " + v.Origem.Local);
                                    Console.WriteLine("Destino : " + v.Destino.Local);
                                    Console.WriteLine("Veículo ID : " + v.Veiculo.Id);
                                    Console.WriteLine("Veículo Placa : " + v.Veiculo.Placa);
                                    Console.WriteLine("Veículo Lotação : " + v.Veiculo.Lotacao);
                                    Console.WriteLine("-----------------------------------------------------");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Não foram efetuadas viagens nessas condições");
                            }
                            
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Não foi possível encontrar a garagem\nErro: " + e.Message);
                        }
                        Continue();
                        break;
                    case 9:
                        try
                        {
                            Console.Write("Insira o id da origem : ");
                            int idOr = Convert.ToInt16(Console.ReadLine());
                            Console.Write("Insira o id do destino : ");
                            int idDe = Convert.ToInt16(Console.ReadLine());

                            int transportados = controller.qtdPassageirosViagem(idOr, idDe);

                            Console.WriteLine("Foram transportadas " + transportados + " Pessoas");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Não foi possível encontrar a garagem\nErro: " + e.Message);
                        }
                        Continue();
                        break;                    
                }
            }
            while (op != 0);
      }
   }
}
