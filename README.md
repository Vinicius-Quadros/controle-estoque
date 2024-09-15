# Controle Estoque

## Descrição

É um sistema de controle de estoque desenvolvido em C#. O programa permite gerenciar peças, realizar a montagem de computadores e gerar relatórios de inventário e montagens. Ele oferece um menu interativo para o usuário inserir, modificar e listar peças, além de funcionalidades para inclusão de montagens e geração de relatórios detalhados.

## Funcionalidades

- **Gerenciamento de Peças:**
  - Inclusão de novas peças ao estoque.
  - Alteração de informações de peças existentes.
  - Listagem completa de todas as peças no estoque.

- **Montagem de Computadores:**
  - Inclusão de novos registros de montagem de computadores.
  - Relatórios detalhados das montagens realizadas.

- **Geração de Relatórios:**
  - Relatório de listagem de peças.
  - Relatório de computadores montados.

## Como Usar

1. **Executar o programa:**
   - Ao iniciar o programa, um menu principal será exibido com as seguintes opções:
     - **1 - Peças**: Acessa o submenu para gerenciar peças.
     - **2 - Montagem de Computador**: Acessa o submenu para registrar montagens de computadores.
     - **3 - Relatórios**: Acessa o submenu para gerar relatórios.
     - **4 - Sair**: Encerra o programa.

2. **Navegar pelos Submenus:**
   - Cada submenu oferece opções específicas para a ação desejada, como inclusão, alteração, listagem e geração de relatórios.

3. **Gerenciar Arquivos:**
   - O programa salva e lê dados dos arquivos `pecas.txt` e `montagem.txt`, localizados na pasta especificada no código (`C:\_VisualStudioProgramas\NovoControleEstoque\`).

## Requisitos

- .NET SDK (Core ou Framework) instalado na máquina.
- Ambiente de desenvolvimento C# (como Visual Studio ou VS Code).
- Sistema operacional Windows para compatibilidade com os caminhos de arquivo especificados.

## Instalação e Execução

1. **Clone o repositório:**
   ```sh
   git clone https://github.com/seu_usuario/NovoControleEstoque.git
   cd NovoControleEstoque
