# Capitulo 04

Neste capítulo será abordado sobre escrever funçoes, debugar erros durante  o desenvolvimento, monitorar exceçoes durante o runtime e testar seu codigo de forma unitária para remover bugs para garantir estabilidade e confiabilidade.

Abordaremos os seguintes tópico:
  * Escrever funçoes;
  * Debugar durante o processo de desenvolvimento;
  * Logging durante o runtime;
  * Testes unitários;


## Escrevendo funções
Um dos principios na programaçao é o **Don't Repeat Yourself (DRY)**.

Enquanto programamos, se voce ver que está escrevendo o mesmo trecho de código em diversas partes do sistema, é melhor voce isolar esse código em uma funçao. Funçoes são pequenos programas para uma pequena tarefa que podem ser utilizadas em diversas partes de um sistema.

## SharpPad

SharpPad é um biblioteca para debugar objetos seus, funciona similarmente ao LINQPad, porém ele é multiplataforma.


## Logging durante o desenvolvimento

Pode ser que voce tenha desenvolvido uma aplicaçao e pense em fazer o deploy dela para que as pessoas possam a utilizar, na sua cabeça ela está sem bugs e pronta para ser usada. Porém nenhuma aplicaçao está livre de bugs, coisas inesperadas podem ocorrer.

Usuário final nao sao tao bons em descrever o bug que encontrou no sistema, como o que ele fez para aquilo acontecer, etc. Entao é necessário que tenhamos algum forma de capturar quando e como esses ocorrem para que possamos corrigi-los.

Existem dois tipos de voce fazer o logging do seu código: **Debug** e **Trace**.
  * Debug: e utilizado para fazer o logging durante o processo de desenvolvimento.
  * Trace: utilizado para adicional logging durante o processo de desenvolvimento e tempo de execuçao.


## Teste Unitarios

Deixar o codigo livre de bugs nao é uma tarefa tao simples, muitas vezes nao cobrimos todos os casos e contextos que aquele codigo pode sofrer, e quanto mais cedo descobrir o bug melhor. Alguns programadores têm o principio de criar testes unitarios ate mesmo antes de escrever o código propriamente, isso é chamado de TDD.

Escrever um teste unitario envolve três partes: 
  * **Arrange**: Essa parte é para se declara/instanciar variaveis que serao utilizadas no teste.
  * **Act**: Essa parte executa o método que está sendo testado.
  * **Assert**: Verifica se o resultado do método testado está de acordo com o esperado.