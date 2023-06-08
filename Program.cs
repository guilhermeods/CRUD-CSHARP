namespace TechoneDesafio{
    class App{
        static void Main(){
            while(true){
                PessoaRepo pessoaRepo = new PessoaRepo();
                string nome,email,tel;

                Console.WriteLine("Digite a opcao desejada:\n1-Criar novo cadastro\n2-Mostrar todos\n3-Mostrar dado atraves do ID\n4-Atualizar\n5-Excluir\n0-sair");
                string input = Console.ReadLine(); // Lê a entrada do usuário como uma string
                int op = int.Parse(input);
                
                //Criar novos dados
                if(op==1){
                    Console.WriteLine("Entre com os novos dados:");
                    Console.WriteLine("Nome:");
                    nome= Console.ReadLine();
                    Console.WriteLine("E-mail:");
                    email= Console.ReadLine();
                    Console.WriteLine("Telefone:");
                    tel= Console.ReadLine();
                    
                    Pessoa p = new Pessoa{
                        Nome = nome,
                        Email = email,
                        Tel = tel
                    };

                    pessoaRepo.CriarPessoa(p);
                }
                //Lista todos os dados
                else if(op==2){
                    List<Pessoa> pessoas = pessoaRepo.ListarPessoas();
                    foreach(Pessoa pessoa in pessoas){
                        Console.WriteLine($"Id:{pessoa.Id};Nome:{pessoa.Nome}\n");
                    }
                }
                //Busca um id fixo
                else if(op==3){
                    List<Pessoa> pessoas = pessoaRepo.ListarPessoas();
                    foreach(Pessoa pessoa in pessoas){
                        Console.WriteLine($"Id:{pessoa.Id};Nome:{pessoa.Nome}\n");
                    }
                    Console.WriteLine("Escolha um id dos apresentados acima");
                    string dado = Console.ReadLine(); // Lê a entrada do usuário como uma string
                    int id = int.Parse(dado);
                    Pessoa pessoa1=pessoaRepo.ObterPessoaPorId(id);
                    if(pessoa1!=null)Console.WriteLine($"Pesquisa::Id:{pessoa1.Id}\nNome:{pessoa1.Nome}\nE-MAIL:{pessoa1.Email}\nTel:{pessoa1.Tel}");

                }
                //Atualizar um dado
                else if(op==4){
                    List<Pessoa> pessoas = pessoaRepo.ListarPessoas();
                    foreach(Pessoa pessoa in pessoas){
                        Console.WriteLine($"Id:{pessoa.Id};Nome:{pessoa.Nome}\n");
                    }
                    Console.WriteLine("Escolha um id dos apresentados acima");
                    string dado = Console.ReadLine(); // Lê a entrada do usuário como uma string
                    int id = int.Parse(dado);
                    Pessoa pessoa1=pessoaRepo.ObterPessoaPorId(id);
                    //Verificando se o id é valido
                    if(pessoa1!=null){
                        Console.WriteLine($"Pessoa sendo Atualizada:\nId:{pessoa1.Id}\nNome:{pessoa1.Nome}\nE-MAIL:{pessoa1.Email}\nTel:{pessoa1.Tel}");
                        Console.WriteLine("Entre com os novos dados:");
                        Console.WriteLine("Nome:");
                        pessoa1.Nome= Console.ReadLine();
                        Console.WriteLine("E-mail:");
                        pessoa1.Email= Console.ReadLine();
                        Console.WriteLine("Telefone:");
                        pessoa1.Tel= Console.ReadLine();
                        pessoaRepo.AtualizarPessoa(pessoa1);
                    }
                }
                //Excluir um dado
                else if(op==5){
                    List<Pessoa> pessoas = pessoaRepo.ListarPessoas();
                    foreach(Pessoa pessoa in pessoas){
                        Console.WriteLine($"Id:{pessoa.Id};Nome:{pessoa.Nome}\n");
                    }
                    Console.WriteLine("Escolha um id dos apresentados acima");
                    string dado = Console.ReadLine(); 
                    int id = int.Parse(dado);
                    Pessoa pessoa1=pessoaRepo.ObterPessoaPorId(id);
                    //Verificando se o id é valido 
                    if(pessoa1!=null){
                        Console.WriteLine($"Pessoa sendo Excluida:\nId:{pessoa1.Id}\nNome:{pessoa1.Nome}\nE-MAIL:{pessoa1.Email}\nTel:{pessoa1.Tel}");
                        Console.Write("Confirma a exclusao:\n1-Sim.\noutro valor-Nao.");
                        dado = Console.ReadLine(); 
                        int resp = int.Parse(dado);
                        if(resp==1)pessoaRepo.ExcluirPessoa(id);
                        else
                            Console.WriteLine("Nada realisado\n");
                    }
                }
                else if(op==0)break;
                
                else 
                    Console.WriteLine("Opcao Invalida\n");
               
            }

        }
    }
}