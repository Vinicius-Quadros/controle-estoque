# Controle Estoque

## Descri��o

� um sistema de controle de estoque desenvolvido em C#. O programa permite gerenciar pe�as, realizar a montagem de computadores e gerar relat�rios de invent�rio e montagens. Ele oferece um menu interativo para o usu�rio inserir, modificar e listar pe�as, al�m de funcionalidades para inclus�o de montagens e gera��o de relat�rios detalhados.

## Funcionalidades

- **Gerenciamento de Pe�as:**
  - Inclus�o de novas pe�as ao estoque.
  - Altera��o de informa��es de pe�as existentes.
  - Listagem completa de todas as pe�as no estoque.

- **Montagem de Computadores:**
  - Inclus�o de novos registros de montagem de computadores.
  - Relat�rios detalhados das montagens realizadas.

- **Gera��o de Relat�rios:**
  - Relat�rio de listagem de pe�as.
  - Relat�rio de computadores montados.

## Como Usar

1. **Executar o programa:**
   - Ao iniciar o programa, um menu principal ser� exibido com as seguintes op��es:
     - **1 - Pe�as**: Acessa o submenu para gerenciar pe�as.
     - **2 - Montagem de Computador**: Acessa o submenu para registrar montagens de computadores.
     - **3 - Relat�rios**: Acessa o submenu para gerar relat�rios.
     - **4 - Sair**: Encerra o programa.

2. **Navegar pelos Submenus:**
   - Cada submenu oferece op��es espec�ficas para a a��o desejada, como inclus�o, altera��o, listagem e gera��o de relat�rios.

3. **Gerenciar Arquivos:**
   - O programa salva e l� dados dos arquivos `pecas.txt` e `montagem.txt`, localizados na pasta especificada no c�digo (`C:\_VisualStudioProgramas\NovoControleEstoque\`).

## Requisitos

- .NET SDK (Core ou Framework) instalado na m�quina.
- Ambiente de desenvolvimento C# (como Visual Studio ou VS Code).
- Sistema operacional Windows para compatibilidade com os caminhos de arquivo especificados.

## Instala��o e Execu��o

1. **Clone o reposit�rio:**
   ```sh
   git clone https://github.com/seu_usuario/NovoControleEstoque.git
   cd NovoControleEstoque
