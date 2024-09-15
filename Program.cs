using System;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace NovoControleEstoque
{
    class Program
    {
        public static void Main(string[] args)
        {
            int opcao = 0;
            while (opcao != 4)
            {
                Console.Clear();
                Console.WriteLine("Menu Principal");
                Console.WriteLine("==============");
                Console.WriteLine("");
                Console.WriteLine("1 - Peças ");
                Console.WriteLine("2 - Montagem de Computador");
                Console.WriteLine("3 - Relatórios");
                Console.WriteLine("4 - Sair");
                Console.WriteLine("");
                Console.Write("Sua Opção: ");
                opcao = int.Parse(lerNumeros());
                switch (opcao)
                {
                    case 1:
                        pecas();
                        break;
                    case 2:
                        montagem();
                        break;
                    case 3:
                        relatorio();
                        break;
                }
            }
            Console.Clear();
            Console.WriteLine("*** Programa encerrado pelo usuário ***");
            Console.WriteLine("");
        }
        public static void pecas()
        {
            int opcaopeca = 0;
            while (opcaopeca != 4)
            {
                Console.Clear();
                Console.WriteLine("Menu de Peças");
                Console.WriteLine("=============");
                Console.WriteLine("");
                Console.WriteLine("1 - Inclusão de Peças");
                Console.WriteLine("2 - Alteração de Peças");
                Console.WriteLine("3 - Listagem de Peças");
                Console.WriteLine("4 - Voltar ao Menu Principal");
                Console.WriteLine("");
                Console.Write("Sua Opção: ");
                opcaopeca = int.Parse(lerNumeros());
                switch (opcaopeca)
                {
                    case 1:
                        incluirpecas();
                        break;
                    case 2:
                        alterarpecas();
                        break;
                    case 3:
                        listarpecas();
                        break;
                }
            }
        }
        public static void montagem()
        {
            int opcaomonta = 0;
            while (opcaomonta != 3)
            {
                Console.Clear();
                Console.WriteLine("Menu de Montagem");
                Console.WriteLine("================");
                Console.WriteLine("");
                Console.WriteLine("1 - Inclusão de Montagem");
                Console.WriteLine("2 - Relatório de Montagem");
                Console.WriteLine("3 - Voltar ao Menu Principal");
                Console.WriteLine("");
                Console.Write("Sua Opção: ");
                opcaomonta = int.Parse(lerNumeros());
                switch (opcaomonta)
                {
                    case 1:
                        incluirmontagem();
                        break;
                    case 2:
                        Console.Write("\n");
                        relatoriomontagem();
                        break;
                }
            }
        }
        public static void relatorio()
        {
            int opcaorelat = 0;
            while (opcaorelat != 3)
            {
                Console.Clear();
                Console.WriteLine("Menu de Relatório");
                Console.WriteLine("=================");
                Console.WriteLine("");
                Console.WriteLine("1 - Listagem de Peças");
                Console.WriteLine("2 - Relatório de Computadores Montados");
                Console.WriteLine("3 - Voltar ao Menu Principal");
                Console.WriteLine("");
                Console.Write("Sua Opção: ");
                opcaorelat = int.Parse(lerNumeros());
                switch (opcaorelat)
                {
                    case 1:
                        listarpecas();
                        break;
                    case 2:
                        Console.Write("\n");
                        relatoriomontagem();
                        break;
                }
            }
        }
        public static void incluirpecas()
        {
            String cIncluir = "";
            String idpeca, descrpeca, dtmov, nomearquivo;
            int qtdpeca;
            idpeca = "";
            descrpeca = "";
            qtdpeca = 0;
            dtmov = "";
            do
            {
                if (cIncluir == "n" || cIncluir == "N")
                    break;
                idpeca = "";
                descrpeca = "";
                qtdpeca = 0;
                dtmov = "";
                Console.Clear();
                Console.WriteLine("Inclusão de Peças");
                Console.WriteLine("=================");
                Console.WriteLine("");
                Console.Write("ID da Peça: ");
                idpeca = AjustaId(lerNumeros());
                Console.Write("\n");
                Console.Write("Descrição da Peça: ");
                descrpeca = Console.ReadLine();
                Console.Write("Quantidade de Peças: ");
                qtdpeca = int.Parse(lerNumeros());
                Console.Write("\n");
                Console.Write("Data da Movimentação: ");
                dtmov = AjustaMov(Console.ReadLine());
                Console.Write("Quer Incluir estas peças (S/N) ? ");
                cIncluir = lerSimNao();
                Console.Write("\n");
                if (idpeca == "0000000" || descrpeca == "" || qtdpeca==0)
                {
                    Console.WriteLine("Um dado essencial não digitado. Id, Descrição ou Quantidade de Peça");
                    Console.ReadKey();
                    cIncluir = "";
                }
            } while (!(cIncluir == "S"|| cIncluir == "s"));
            if (cIncluir == "s" || cIncluir == "S")
            {
                nomearquivo = "C:\\_VisualStudioProgramas\\NovoControleEstoque\\pecas.txt";
                var basePecas = new BasePecas(nomearquivo);
                var pecasnovas = new RegPecas(idpeca, descrpeca, qtdpeca, dtmov);
                basePecas.AdicionarPeca(pecasnovas);
                basePecas.Serializar();
                basePecas.Salvar();
                basePecas.OrdenaArqPecas();
                Console.WriteLine("Registro foi adicionado ao arquivo pecas.txt em ordem de Id - Pressione qualquer tecla ...");
                Console.ReadKey();
            }
        }
        public static void alterarpecas()
        {
            String cAlterar = "";
            String idpeca, descrpeca, dtmov, nomearquivo;
            int qtdpeca;
            idpeca = "";
            descrpeca = "";
            qtdpeca = 0;
            dtmov = "";
            nomearquivo = "C:\\_VisualStudioProgramas\\NovoControleEstoque\\pecas.txt";
            var basePecas=new BasePecas(nomearquivo);
            do
            {
                if (cAlterar == "n" || cAlterar == "N")
                    break;
                idpeca = "";
                descrpeca = "";
                qtdpeca = 0;
                dtmov = "";
                Console.Clear();
                Console.WriteLine("Alteração de Peças");
                Console.WriteLine("==================");
                Console.WriteLine("");
                Console.Write("ID da Peça: ");
                idpeca = AjustaId(lerNumeros());
                Console.Write("\n");
                // Buscar Id no arquivo
                var pecabuscada = basePecas.BuscarPoridPeca(idpeca);
                descrpeca = pecabuscada.GetDescPeca(); // Carrega a descrição 
                qtdpeca = pecabuscada.GetQtdePeca(); //Carrega a quantidade de peças existentes
                dtmov = MovAjusta(pecabuscada.GetMovPeca()); // Carrega a data de movimento e transforma em DD/MM/YYYY
                // Se não encontrar o código deve sair
                if (pecabuscada.GetIdPeca() == "")
                {
                    Console.WriteLine("*** Item não encontrado ***.\n" +
                                      "Retornando ao Menu de Peças.\n" +
                                      "Pressione qualquer tecla ...");
                    Console.ReadKey();
                    break;
                }
                // continuar a edição com os dados recuperados
                Console.WriteLine("Descrição da Peça: ");
                Console.WriteLine("Anterior : " + descrpeca);
                Console.Write("Alteração: ");
                descrpeca = Console.ReadLine();
                Console.WriteLine("Quantidade de Peças: ");
                Console.WriteLine("Anterior : "+qtdpeca);
                Console.Write("Alteração: ");
                qtdpeca = int.Parse(lerNumeros());
                Console.Write("\n");
                Console.WriteLine("Data da Movimentação: ");
                Console.WriteLine("Anterior : " + dtmov);
                Console.Write("Alteração: ");
                dtmov = AjustaMov(Console.ReadLine());
                Console.Write("Quer alterar os dados destas peças (S/N) ? ");
                cAlterar = lerSimNao();
                Console.Write("\n");
                if (idpeca == "0000000" || descrpeca == "" || qtdpeca == 0)
                {
                    Console.WriteLine("Um dado essencial não digitado. Id, Descrição ou Quantidade de Peça");
                    Console.ReadKey();
                    cAlterar = "";
                }
            } while (!(cAlterar == "S" || cAlterar == "s"));
            if (cAlterar == "s" || cAlterar == "S")
            {
                var pecaalterar = basePecas.BuscarPoridPeca(idpeca);
                pecaalterar.SetDesc(descrpeca);
                pecaalterar.SetQuant(qtdpeca);
                pecaalterar.SetMov(dtmov);
                basePecas.AtualizarPeca(pecaalterar);
                basePecas.Serializar();
                basePecas.Salvar();
                basePecas.OrdenaArqPecas();
                Console.WriteLine("Registro foi alterado e posicionado conforme seu Id no arquivo pecas.txt - Pressione qualquer tecla ...");
                Console.ReadKey();
            }
        }
        public static void listarpecas()
        {
            Console.Write("\n");
            string nomearquivo,nomerelatorio;
            nomearquivo = "C:\\_VisualStudioProgramas\\NovoControleEstoque\\pecas.txt";
            nomerelatorio = "C:\\_VisualStudioProgramas\\NovoControleEstoque\\listagempecas.txt";
            String linha;
            String ListaPecas = "";
            if (!File.Exists(nomearquivo))
            {
                Console.WriteLine("Arquivo de Peças Inexistente. Impossível gerar relatório. Pressione qualquer tecla ...");
                Console.ReadKey();
                return;
            }
            try
            {
                StreamReader sr = new StreamReader
                    (nomearquivo);
                ListaPecas += "============= INÍCIO DO RELATÓRIO ===============\n-------------------------------------------------";
                Console.WriteLine("============= INÍCIO DO RELATÓRIO ===============");
                Console.WriteLine("-------------------------------------------------");
                do
                {
                    linha = sr.ReadLine();
                    if (linha != null)
                    {
                        string[] camposPecas= linha.Split(';');
                        ListaPecas+= "\nId Peca ...: " + camposPecas[0]+
                                     "\nDescrição .: " + camposPecas[1]+
                                     "\nQuantidade : " + camposPecas[2]+
                                     "\nData Mov ..: " + MovAjusta(camposPecas[3])+
                                     "\n-------------------------------------------------";
                        Console.WriteLine("Id Peca ...: "+camposPecas[0]);
                        Console.WriteLine("Descrição .: "+camposPecas[1]);
                        Console.WriteLine("Quantidade : "+camposPecas[2]);
                        Console.WriteLine("Data Mov ..: "+MovAjusta(camposPecas[3]));
                        Console.WriteLine("-------------------------------------------------");
                    }
                } while (linha != null);
                ListaPecas += "\n============== FIM DO RELATÓRIO =================";
                StreamWriter sw = new StreamWriter(nomerelatorio, append: false);
                sw.WriteLine(ListaPecas);
                sw.Close();
                Console.WriteLine("============== FIM DO RELATÓRIO =================");
                Console.WriteLine("*** LISTAGEM DE PEÇAS GERADO *** (listagempecas.txt) - Pressione qualquer tecla...");
                Console.ReadKey();
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu algum problema durante a leitura do arquivo!\n" +
                    "Envie este texto ao suporte técnico: ", e.Message);
            }
        }
        public static void incluirmontagem()
        {
            String cIncluir,cConfirma, nrMontagem, cDescMicro, cPlacaMae, cModMem, cTipHd, cModTeclado, cResMonitor, cCapFonte, cCaboLuz, cCaboHdmi, cDtMontagem, cArqPecas, cArqMicro;
            int qtdePentMem;
            cIncluir = "";
            nrMontagem = "";
            cDescMicro = "";
            cPlacaMae = "";
            cModMem = "";
            cTipHd = "";
            cModTeclado = "";
            cResMonitor = "";
            cCapFonte = "";
            cCaboLuz = "";
            cCaboHdmi = "";
            cDtMontagem = "";
            cArqPecas = "C:\\_VisualStudioProgramas\\NovoControleEstoque\\pecas.txt";
            cArqMicro = "C:\\_VisualStudioProgramas\\NovoControleEstoque\\montagem.txt";
            qtdePentMem = 0;
            var basePecas = new BasePecas(cArqPecas);
            string[] LinhasArqMicro = File.ReadAllLines(cArqMicro);
            string[] CodPecas = new string[9];
            string[] DescPecas = new string[9];
            int[] QtdPecas = new int[9];
            do
            {
                if (cIncluir == "n" || cIncluir == "N")
                    break;
                Console.Clear();
                Console.WriteLine("Inclusão de Montagem");
                Console.WriteLine("====================");
                Console.WriteLine("");
                Console.Write("ID da Montagem [Esc - Sai]: ");
                nrMontagem = AjustaId(lerNumerosEsc());
                if (nrMontagem == "0000000") break;
                // procurar id da montagem
                int nfim = 0;
                foreach(var linha in LinhasArqMicro)
                {
                    string ctestar;
                    ctestar = "Montagem nº " + nrMontagem;
                    if (ctestar == $"{linha}")
                    {
                        ++nfim;
                        break;
                    }
                }

                if (nfim > 0)
                {
                    Console.WriteLine("\nId de Montagem já existe.\nPressione qualquer tecla...");
                    Console.ReadKey();
                    break;
                }

                Console.Write("\n");
                Console.Write("Descrição do Micro: ");
                cDescMicro = Console.ReadLine();
                // Comeca o problema .... 
                cConfirma = "";
                do
                {
                    Console.Write("Código de Gabinete com Placa Mãe [Esc - Sai]: ");
                    cPlacaMae = AjustaId(lerNumerosEsc());
                    if (cPlacaMae == "0000000")
                    {
                        cIncluir = "N";
                        break;
                    }
                    var pecabuscada1 = basePecas.BuscarPoridPeca(cPlacaMae);
                    if (pecabuscada1.GetIdPeca() == "")
                    {
                        Console.WriteLine("\n*** Código de Gabinete com Placa Mãe não encontrado ***.\n" +
                                            "                 Retornando ao Início.     \n" +
                                            "                 Pressione qualquer tecla ... ");
                        Console.ReadKey();
                        break;
                    }
                    Console.Write(" - " + pecabuscada1.GetDescPeca() + "\n");
                    Console.Write("Confirma esse Gabinete com Placa Mãe (S/N) ? ");
                    cConfirma = lerSimNao();
                    Console.Write("\n");
                    if (cConfirma == "S" || cConfirma == "s")
                    {
                        CodPecas[0] = cPlacaMae;
                        DescPecas[0] = pecabuscada1.GetDescPeca();
                        QtdPecas[0] = 1;
                        do
                        {
                            Console.Write("Código do Modelo de Memória [Esc - Sai]: ");
                            cModMem = AjustaId(lerNumerosEsc());
                            if (cModMem == "0000000")
                            {
                                Console.Write("\n");
                                cIncluir = "N";
                                break;
                            }
                            var pecabuscada2 = basePecas.BuscarPoridPeca(cModMem);
                            if (pecabuscada2.GetIdPeca() != "")
                            {
                                Console.Write(" - " + pecabuscada2.GetDescPeca() + "\n");
                                Console.Write("Confirma esse Modelo de Memória (S/N) ? ");
                                cConfirma = lerSimNao();
                                Console.Write("\n");
                                if (cConfirma == "S" || cConfirma == "s")
                                {
                                    bool bFicar;
                                    do
                                    {
                                        bFicar = true;
                                        Console.Write("Quantos pentes de Memória (1, 2 ou 4): ");
                                        qtdePentMem = int.Parse(lerNumeros());
                                        Console.Write("\n");
                                        switch (qtdePentMem)
                                        {
                                            case 1:
                                                bFicar = false;
                                                break;
                                            case 2:
                                                bFicar = false;
                                                break;
                                            case 4:
                                                bFicar = false;
                                                break;
                                        }
                                    } while (bFicar);
                                    CodPecas[1] = cModMem;
                                    DescPecas[1] = pecabuscada2.GetDescPeca();
                                    QtdPecas[1] = qtdePentMem;
                                    do
                                    {
                                        Console.Write("Código do tipo de armazenamento [Esc - Sai]: ");
                                        cTipHd = AjustaId(lerNumerosEsc());
                                        if (cTipHd == "0000000")
                                        {
                                            Console.Write("\n");
                                            cIncluir = "N";
                                            break;
                                        }
                                        var pecabuscada3 = basePecas.BuscarPoridPeca(cTipHd);
                                        if (pecabuscada3.GetIdPeca() != "")
                                        {
                                            Console.Write(" - " + pecabuscada3.GetDescPeca() + "\n");
                                            Console.Write("Confirma esse tipo de armazenamento (S/N) ? ");
                                            cConfirma = lerSimNao();
                                            Console.Write("\n");
                                            if (cConfirma == "S" || cConfirma == "s")
                                            {
                                                CodPecas[2] = cTipHd;
                                                DescPecas[2] = pecabuscada3.GetDescPeca();
                                                QtdPecas[2] = 1;
                                                do
                                                {
                                                    Console.Write("Código de Modelo de teclado [Esc - Sai]: ");
                                                    cModTeclado = AjustaId(lerNumerosEsc());
                                                    if (cModTeclado=="0000000")
                                                    {
                                                        Console.Write("\n");
                                                        cIncluir = "N";
                                                        break;
                                                    }
                                                    var pecabuscada4 = basePecas.BuscarPoridPeca(cModTeclado);
                                                    if (pecabuscada4.GetIdPeca() != "")
                                                    {
                                                        Console.Write(" - " + pecabuscada4.GetDescPeca() + "\n");
                                                        Console.Write("Confirma esse modelo de teclado (S/N) ? ");
                                                        cConfirma = lerSimNao();
                                                        Console.Write("\n");
                                                        if (cConfirma == "S" || cConfirma == "s")
                                                        {
                                                            CodPecas[3] = cModTeclado;
                                                            DescPecas[3] = pecabuscada4.GetDescPeca();
                                                            QtdPecas[3] = 1;
                                                            do
                                                            {
                                                                Console.Write("Código de Monitor (resolução) [Esc - Sai]: ");
                                                                cResMonitor = AjustaId(lerNumerosEsc());
                                                                if (cResMonitor == "0000000")
                                                                {
                                                                    Console.Write("\n");
                                                                    cIncluir = "N";
                                                                    break;
                                                                }
                                                                var pecabuscada5 = basePecas.BuscarPoridPeca(cResMonitor);
                                                                if (pecabuscada5.GetIdPeca() != "")
                                                                {
                                                                    Console.Write(" - " + pecabuscada5.GetDescPeca() + "\n");
                                                                    Console.Write("Confirma esse monitor (S/N) ? ");
                                                                    cConfirma = lerSimNao();
                                                                    Console.Write("\n");
                                                                    if (cConfirma == "S" || cConfirma == "s")
                                                                    {
                                                                        CodPecas[4] = cResMonitor;
                                                                        DescPecas[4] = pecabuscada5.GetDescPeca();
                                                                        QtdPecas[4] = 1;
                                                                        do
                                                                        {
                                                                            Console.Write("Código da Fonte (potencia) [Esc - Sai]: ");
                                                                            cCapFonte = AjustaId(lerNumerosEsc());
                                                                            if (cCapFonte == "0000000")
                                                                            {
                                                                                Console.Write("\n");
                                                                                cIncluir = "N";
                                                                                break;
                                                                            }
                                                                            var pecabuscada6 = basePecas.BuscarPoridPeca(cCapFonte);
                                                                            if (pecabuscada6.GetIdPeca() != "")
                                                                            {
                                                                                Console.Write(" - " + pecabuscada6.GetDescPeca() + "\n");
                                                                                Console.Write("Confirma essa fonte (S/N) ? ");
                                                                                cConfirma = lerSimNao();
                                                                                Console.Write("\n");
                                                                                if (cConfirma == "S" || cConfirma == "s")
                                                                                {
                                                                                    CodPecas[5] = cCapFonte;
                                                                                    DescPecas[5] = pecabuscada6.GetDescPeca();
                                                                                    QtdPecas[5] = 1;
                                                                                    do
                                                                                    {
                                                                                        Console.Write("Código do Cabo de Energia [Esc - Sai]: ");
                                                                                        cCaboLuz = AjustaId(lerNumerosEsc());
                                                                                        if (cCaboLuz == "0000000")
                                                                                        {
                                                                                            Console.Write("\n");
                                                                                            cIncluir = "N";
                                                                                            break;
                                                                                        }
                                                                                        var pecabuscada7 = basePecas.BuscarPoridPeca(cCaboLuz);
                                                                                        if (pecabuscada7.GetIdPeca() != "")
                                                                                        {
                                                                                            Console.Write(" - " + pecabuscada7.GetDescPeca() + "\n");
                                                                                            Console.Write("Confirma esse cabo de energia (S/N) ? ");
                                                                                            cConfirma = lerSimNao();
                                                                                            Console.Write("\n");
                                                                                            if (cConfirma == "S" || cConfirma == "s")
                                                                                            {
                                                                                                CodPecas[6] = cCaboLuz;
                                                                                                DescPecas[6] = pecabuscada7.GetDescPeca();
                                                                                                QtdPecas[6] = 1;
                                                                                                do
                                                                                                {
                                                                                                    Console.Write("Código do Cabo HDMI [Esc - Sai]: ");
                                                                                                    cCaboHdmi = AjustaId(lerNumerosEsc());
                                                                                                    if (cCaboHdmi == "0000000")
                                                                                                    {
                                                                                                        Console.Write("\n");
                                                                                                        cIncluir = "N";
                                                                                                        break;
                                                                                                    }
                                                                                                    var pecabuscada8 = basePecas.BuscarPoridPeca(cCaboHdmi);
                                                                                                    if (pecabuscada8.GetIdPeca() != "")
                                                                                                    {
                                                                                                        Console.Write(" - " + pecabuscada8.GetDescPeca() + "\n");
                                                                                                        Console.Write("Confirma esse cabo HDMI (S/N) ? ");
                                                                                                        cConfirma = lerSimNao();
                                                                                                        Console.Write("\n");
                                                                                                        if (cConfirma == "S" || cConfirma == "s")
                                                                                                        {
                                                                                                            CodPecas[7] = cCaboHdmi;
                                                                                                            DescPecas[7] = pecabuscada8.GetDescPeca();
                                                                                                            QtdPecas[7] = 1;
                                                                                                            do
                                                                                                            {
                                                                                                                Console.Write("Data de Montagem: ");
                                                                                                                cDtMontagem = AjustaMov(Console.ReadLine());
                                                                                                                Console.Write("Confirma essa data de montagem (S/N) ? ");
                                                                                                                cConfirma = lerSimNao();
                                                                                                                Console.Write("\n");
                                                                                                                if (cConfirma == "S" || cConfirma == "s")
                                                                                                                {
                                                                                                                    CodPecas[8] = cDtMontagem;
                                                                                                                    DescPecas[8] = MovAjusta(cDtMontagem);
                                                                                                                    QtdPecas[8] = 0;
                                                                                                                    int[] TotPecas = new int[9];
                                                                                                                    int n= 0;
                                                                                                                    do
                                                                                                                    {
                                                                                                                        var pecaalterar = basePecas.BuscarPoridPeca(CodPecas[n]);
                                                                                                                        TotPecas[n] = pecaalterar.GetQtdePeca();
                                                                                                                        TotPecas[n]-= QtdPecas[n];
                                                                                                                        pecaalterar.SetQuant(TotPecas[n]);
                                                                                                                        pecaalterar.SetMov(CodPecas[8]);
                                                                                                                        basePecas.AtualizarPeca(pecaalterar);
                                                                                                                        basePecas.Serializar();
                                                                                                                        basePecas.Salvar();
                                                                                                                        ++n;
                                                                                                                    } while (n < 8);
                                                                                                                    basePecas.OrdenaArqPecas();
                                                                                                                    Console.WriteLine("Arquivo de pecas devidamente alterado, após a montagem do Micro.");
                                                                                                                    string cGravar;
                                                                                                                    cGravar = "Montagem nº " + nrMontagem +
                                                                                                                         "\n    Descrição: " + cDescMicro +
                                                                                                                         "\n               " + QtdPecas[0] + " - " + DescPecas[0] +
                                                                                                                         "\n               " + QtdPecas[1] + " - " + DescPecas[1] +
                                                                                                                         "\n               " + QtdPecas[2] + " - " + DescPecas[2] +
                                                                                                                         "\n               " + QtdPecas[3] + " - " + DescPecas[3] +
                                                                                                                         "\n               " + QtdPecas[4] + " - " + DescPecas[4] +
                                                                                                                         "\n               " + QtdPecas[5] + " - " + DescPecas[5] +
                                                                                                                         "\n               " + QtdPecas[6] + " - " + DescPecas[6] +
                                                                                                                         "\n               " + QtdPecas[7] + " - " + DescPecas[7] +
                                                                                                                         "\nMontado em " + DescPecas[8]+
                                                                                                                         "\n-------------------------------------------------\n";
                                                                                                                    if (!File.Exists(cArqMicro))
                                                                                                                    {
                                                                                                                        File.WriteAllText(cArqMicro, "\n");
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        cGravar = File.ReadAllText(cArqMicro) + cGravar;
                                                                                                                    }
                                                                                                                    File.WriteAllText(cArqMicro, cGravar);
                                                                                                                    Console.WriteLine("Registro de montagem foi adicionado ao final do arquivo montagem.txt - Pressione qualquer tecla ...");
                                                                                                                    Console.ReadKey();
                                                                                                                }
                                                                                                            } while (!(cConfirma == "S" || cConfirma == "s"));
                                                                                                        }
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        Console.WriteLine("\n*** Código de Cabo HDMI não encontrado ***.\n" +
                                                                                                                            "        Insira um código existente.     \n" +
                                                                                                                            "       Pressione qualquer tecla ... ");
                                                                                                        Console.ReadKey();
                                                                                                        cConfirma = "";
                                                                                                    }
                                                                                                } while (!(cConfirma == "S" || cConfirma == "s"));
                                                                                            }
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            Console.WriteLine("\n*** Código de Cabo de Energia não encontrado ***.\n" +
                                                                                                                "           Insira um código existente.     \n" +
                                                                                                                "          Pressione qualquer tecla ... ");
                                                                                            Console.ReadKey();
                                                                                            cConfirma = "";
                                                                                        }
                                                                                    } while (!(cConfirma == "S" || cConfirma == "s"));
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                Console.WriteLine("\n*** Código de Tipo de Fonte não encontrado ***.\n" +
                                                                                                    "          Insira um código existemte.     \n" +
                                                                                                    "          Pressione qualquer tecla ... ");
                                                                                Console.ReadKey();
                                                                                cConfirma = "";
                                                                            }
                                                                        } while (!(cConfirma == "S" || cConfirma == "s"));
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("\n*** Código de Tipo de Monitor não encontrado ***.\n" +
                                                                                        "           Insira um código existente.     \n" +
                                                                                        "          Pressione qualquer tecla ... ");
                                                                    Console.ReadKey();
                                                                    cConfirma = "";
                                                                }
                                                            } while (!(cConfirma == "S" || cConfirma == "s"));
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("\n*** Código de Combo de teclado não encontrado ***.\n" +
                                                                            "            Insira um código existente.     \n" +
                                                                            "           Pressione qualquer tecla ... ");
                                                        Console.ReadKey();
                                                        cConfirma = "";
                                                    }
                                                } while (!(cConfirma == "S" || cConfirma == "s"));
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("\n*** Código de Tipo de Armazenamento não encontrado ***.\n" +
                                                                "             Insira um código existente.     \n" +
                                                                "            Pressione qualquer tecla ... ");
                                            Console.ReadKey();
                                            cConfirma = "";
                                        }
                                    } while (!(cConfirma == "S" || cConfirma == "s"));
                                }
                            }
                            else
                            {
                                Console.WriteLine("\n*** Código de memória não encontrado ***.\n" +
                                                  "       Insira um código existente.     \n" +
                                                  "      Pressione qualquer tecla ... ");
                                Console.ReadKey();
                                cConfirma="";
                            }
                        } while (!(cConfirma == "S" || cConfirma == "s"));
                    }
                } while (!(cConfirma == "S" || cConfirma == "s"));
            } while (!(cIncluir == "S" || cIncluir == "s"));
        }
        public static void relatoriomontagem()
        {
            string cArquivo,cRelat;
            cArquivo = "C:\\_VisualStudioProgramas\\NovoControleEstoque\\montagem.txt";
            cRelat= "C:\\_VisualStudioProgramas\\NovoControleEstoque\\listamontados.txt";
            if (!File.Exists(cArquivo))
            {
                Console.WriteLine("Arquivo de Montagem Inexistente. Pressione qualquer tecla ...");
                Console.ReadKey();
                return;
            }

            string[] cTodasLinhas = File.ReadAllLines(cArquivo);
            int nLin, nTotLin;
            nLin = 0;
            nTotLin = cTodasLinhas.Length;
            string cRelatMicro = "";
            cRelatMicro+="===== INÍCIO DO RELATÓRIO DE MICROS MONTADOS ====\n-------------------------------------------------\n";
            Console.WriteLine("===== INÍCIO DO RELATÓRIO DE MICROS MONTADOS ====\n-------------------------------------------------");
            while (nLin < nTotLin)
            {
                Console.WriteLine(cTodasLinhas[nLin]);
                cRelatMicro+= cTodasLinhas[nLin++] + "\n";
            }
            Console.WriteLine("============== FIM DO RELATÓRIO =================");
            cRelatMicro+= "============== FIM DO RELATÓRIO =================\n";
            if (!File.Exists(cRelat))
            {
                File.WriteAllText(cRelat, "\n");
            }
            File.WriteAllText(cRelat, cRelatMicro);
            Console.WriteLine("*** RELATÓRIO DE MONTAGEM DE MICROS GERADO *** (listamontados.txt) - Pressione qualquer tecla...");
            Console.ReadKey();
        }

        public static String AjustaId(string i)
        {
            string id = "";
            id = "0000000" + i;
            id = id.Remove(0, id.Length - 7);
            return id;
        }
        public static string AjustaMov(string mvt)
        {
            string movy = "";
            string movm = "";
            string movd = "";
            movy = mvt.Remove(0, mvt.Length - 4);  // Ano do string
            movm = mvt.Remove(0, mvt.Length - 7);  // Inicia a retirada do mês da string
            movm = movm.Remove(2, movm.Length - 2);   // Mês da string
            movd = mvt.Remove(2, mvt.Length - 2);    // Dia da String
            return (movy + movm + movd);     // ordena em yyyymmdd - Ano, mês e dia
        }
        public static string MovAjusta(string mvt)
        {
            string movy = "";
            string movm = "";
            string movd = "";
            string movs = "/";
            movd = mvt.Remove(0, mvt.Length - 2);  // Dia da string
            movm = mvt.Remove(0, mvt.Length - 4);  // Inicia a retirada do mês da string
            movm = movm.Remove(2, movm.Length - 2);   // Mês da string
            movy = mvt.Remove(4, mvt.Length - 4);    // Ano  da String
            return (movd + movs + movm + movs + movy);     // reordena e insere  / - dia/mês/ano
        }
        public static string lerNumeros()
        {
            ConsoleKeyInfo cTecla;
            string digitacao = "";
            bool continuarLoop = true;
            while (continuarLoop)
                if (Console.KeyAvailable)
                {
                    cTecla = Console.ReadKey(true);
                    switch (cTecla.Key)
                    {
                        case ConsoleKey key when ((ConsoleKey.Backspace == key) || key == ConsoleKey.Delete):
                            if (digitacao.Length == 0) continue;
                            digitacao = digitacao.Remove(digitacao.Length - 1);
                            Console.Write("\b \b"); //Remove o último caractere digitado
                            break;
                        case ConsoleKey.Enter:
                            if (digitacao.Length == 0) continue;
                            continuarLoop = false;
                            break;                        
                        case ConsoleKey key when ((ConsoleKey.D0 <= key) && (key <= ConsoleKey.D9) ||
                                                  (ConsoleKey.NumPad0 <= key) && (key <= ConsoleKey.NumPad9)):
                            digitacao += cTecla.KeyChar;
                            Console.Write(cTecla.KeyChar);
                            break;
                    }
                }
            return digitacao;
        }
        public static string lerNumerosEsc()
        {
            ConsoleKeyInfo cTecla;
            string digitacao = "";
            bool continuarLoop = true;
            while (continuarLoop)
                if (Console.KeyAvailable)
                {
                    cTecla = Console.ReadKey(true);
                    switch (cTecla.Key)
                    {
                        case ConsoleKey key when ((ConsoleKey.Backspace == key) || key == ConsoleKey.Delete):
                            if (digitacao.Length == 0) continue;
                            digitacao = digitacao.Remove(digitacao.Length - 1);
                            Console.Write("\b \b"); //Remove o último caractere digitado
                            break;
                        case ConsoleKey.Enter:
                            if (digitacao.Length == 0) continue;
                            continuarLoop = false;
                            break;
                        case ConsoleKey.Escape:
                            digitacao = "";
                            continuarLoop = false;
                            break;
                        case ConsoleKey key when ((ConsoleKey.D0 <= key) && (key <= ConsoleKey.D9) ||
                                                  (ConsoleKey.NumPad0 <= key) && (key <= ConsoleKey.NumPad9)):
                            digitacao += cTecla.KeyChar;
                            Console.Write(cTecla.KeyChar);
                            break;
                    }
                }
            return digitacao;
        }
        public static string lerSimNao()
        {
            ConsoleKeyInfo cTecla;
            string digitacao = "";
            bool continuarLoop = true;
            while (continuarLoop)
                if (Console.KeyAvailable)
                {
                    cTecla = Console.ReadKey(true);
                    switch (cTecla.Key)
                    {
                        case ConsoleKey key when ((ConsoleKey.Backspace == key) || key == ConsoleKey.Delete):
                            if (digitacao.Length == 0) continue;
                            digitacao = digitacao.Remove(digitacao.Length - 1);
                            Console.Write("\b \b"); //Remove o último caractere digitado
                            break;
                        case ConsoleKey.Enter:
                            if (digitacao.Length == 0) continue;
                            continuarLoop = false;
                            break;
                        case ConsoleKey key when ((ConsoleKey.S == key) || (key == ConsoleKey.N)):
                            digitacao += cTecla.KeyChar;
                            Console.Write(cTecla.KeyChar);
                            if (digitacao.Length>1)
                            {
                                digitacao = digitacao.Remove(digitacao.Length - 1);
                                Console.Write("\b \b"); //Remove o último caractere digitado
                            }
                            break;
                    }
                }
            return digitacao;
        }
    }
    // Início Classe RegPecas
    class RegPecas
    {
        string idPeca;
        string descPeca;
        int qtdePeca;
        string movPeca;
        public RegPecas(string i, string n, int q, string m)
        {
            idPeca = i;
            descPeca = n;
            qtdePeca = q;
            movPeca = m;
        }
        public string GetIdPeca()
        {
            return idPeca;
        }
        public string GetDescPeca()
        {
            return descPeca;
        }
        public int GetQtdePeca()
        {
            return qtdePeca;
        }
        public string GetMovPeca()
        {
            return movPeca;
        }
        public void SetDesc(string n)
        {
            descPeca = n;
        }        
        public void SetQuant(int  q)
        {
            qtdePeca = q;
        }
        public void SetIdPeca(string i)
        {
            idPeca = i;
        }
        public void SetMov(string i)
        {
            movPeca = i;
        }
        public string Serializar()
        {
            return idPeca + ";" + descPeca + ";" + qtdePeca + ";" + movPeca;
        }
    }
    // Fim Classe RegPecas

    // Inicio de Base de Pecas
    class BasePecas
    {
        string filename;
        List<RegPecas> registropecas;
        public BasePecas(string f = "c:\\_VisualStudioProgramas\\NovoControleEstoque\\pecas.txt")
        {
            filename = f;
            registropecas = new List<RegPecas>();
            Carregar();
        }
        public void Carregar()
        {
            if (!File.Exists(filename))
            {
                File.CreateText(filename);
            }
            string input = File.ReadAllText(filename);
            string[] linhas = input.Split("\n");
            foreach (var linha in linhas)
            {
                if (linha.Length > 0)
                {
                    string[] valores = linha.Split(";");
                    RegPecas regpecas = new RegPecas(valores[0], valores[1], int.Parse(valores[2]), valores[3]);
                    registropecas.Add(regpecas);
                }
            }
        }
        public string Serializar()
        {
            string output = "";
            foreach (var regpecas in registropecas)
            {
                output += regpecas.Serializar() + "\n";
            }
            return output;
        }
        public void Salvar()
        {
            string output = Serializar();
            File.WriteAllText(filename, output);
        }
        public void Limpar()
        {
            registropecas.Clear();
        }
        public void AdicionarPeca(RegPecas p)
        {
            foreach (var regpecas in registropecas)
            {
                if (regpecas.GetIdPeca() == p.GetIdPeca())
                {
                    throw new Exception($"Peça '{p.GetIdPeca()}' já está na lista");
                }
            }
            registropecas.Add(p);
        }
        public void AtualizarPeca(RegPecas p)
        {
            foreach (var regpecas in registropecas)
            {
                if (regpecas.GetIdPeca() == p.GetIdPeca())
                {
                    registropecas.Remove(regpecas);
                    registropecas.Add(p);
                    return;
                }
            }
            //caso nao encontre a peça, lanca erro
            throw new Exception($"Peça código '{p.GetIdPeca()}' não foi encontrada na base");
        }
        public void RemoverPeca(RegPecas p)
        {
            foreach (var regpecas in registropecas)
            {
                if (regpecas.GetIdPeca() == p.GetIdPeca())
                {
                    registropecas.Remove(regpecas);
                    return;
                }
            }
        }
         public RegPecas BuscarPoridPeca(string idPeca)
        {
            foreach (var regpecas in registropecas)
            {
                if (regpecas.GetIdPeca() == idPeca)
                {
                    return regpecas;
                }
            }
            //caso nao encontre, lanca erro
            return new RegPecas("", "", 0, "00000000");
        }
        public void OrdenaArqPecas()
        {
            string cArquivo;
            cArquivo = "C:\\_VisualStudioProgramas\\NovoControleEstoque\\pecas.txt";
            string[] cTodasLinhas = File.ReadAllLines(cArquivo);
            Array.Sort(cTodasLinhas);
            File.WriteAllLines(cArquivo, cTodasLinhas);
        }
    }
    // Fim de Base de Pecas 

}