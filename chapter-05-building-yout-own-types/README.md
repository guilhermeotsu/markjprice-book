# Criando seus próprios tipos com OOP

Este capitulo abordará acerca de criar seus próprios tipos de dados usando programaçao orientada a objetos. Voce vai aprender sobre todas as diferentes categorias de membros que um tipo pode ter, incluindo campos para armazenar dados e métodos para executar açoes. Voce vai usar conceitos de OOP como agragação e encapsulamento.

Este capítulo abordará os seguintes capitulos:
 * Sobre OOP
 * Constuindo biblioteca de classes
 * Armazenando dados com campos
 * Escrevendo e chamando métodos
 * Controlando acessos com propriedades e indexers(?)


## Sobre OOP

No mundo real um objeto é uma **coisa**, como um carro ou uma pessoa, enquanto que um objeto em programaçao representa algo no mundo real, como um produto ou uma conta bancária, mas isso pode ser representado de uma forma mais abstrata.

Em C#, nós utilizamos as palavras chaves **class** (mais frequente) ou **struct** (as vezes) para definir um tipo de um objeto.

Alguns conceitos de OOP:
  * **Encapsulamento** é a combinaçao de um dado ou açao que é relacionado um objeto. Por exemplo, imagine uma televisão, uma televisão é um aparelho complexo com todos seus componentes internos etc. Mas para controlar ela nao precisamos saber nada disso, basta apenas clicar em alguns botoes para utiliza. Sendo assim, os projetistas encapsularam a complexidade interna dela para que seja mais facil manusea-la. Desse mesmo modo acontece na construçao de objeto, onde encapsulamos a possível complexidade dela e externamos apenas algumas funçoes para controla-lo.

  * **Composiçao** é sobre o que um objeto é construido. Por exemplo, um carro é compoto por pneus, motor, lataria, etc.

  * **Agregaçao** é sobre o que pode ser combinado com o objeto. Por exemplo, uma pessoas nao é parte de um objeto carro, porem ele pode sentar-se no banco do motorista e se tornar um Piloto. Dois objetos separados que são agregapos e formam um novo componente.

  * **Herança** é sobre reutilizaçao de codigo quando há uma subclasse que deriva de uma super classe ou classe base. Todas as funcionalidade presentes na classe base vao estar presentes na classe que a herdou.

  * **Abstraçao** é sobre capturar a ideia principal de um object e ignorar detalhes que nao sao importantes para o contexto da sua regra de negocio.

  * **Polimorfismo** é sobre permitir que classe derivadas sobrescrevam métodos da classe base para prover um comportamento custmizado.


## Entendendo membros

* **Campos** são utilizados para armazenar dados. Existem tres tipos especializados que categorizam um campo: 
  * Constantes: o dado nunca muda. O compilador copia literalmente os dados em qualquer código que os leia.

  * Read-Only: o dado nao pode mudar depois que a classe for instanciada, porem o dado pode ser calculado ou carregado de uma fonte externa no momento da instanciaçao.

  * Event: os dados fazem referencia um ou mais metodos que voce quer que execute quando algo acontece, como o clique em um botao, ou responder a requisicao de outro odigo.

* **Metodos** sao utilizados para executar sentenças. Existe tre tipos que categorizam um metodo:
  * Construtor: as declaraçoes executam quando voce use a palavra reservada **new** para alocar um espaço na memoria e instancia uma classe.

  * Propriedade: a sentença executando quando voce vai dar um get ou set no dados. O dado é comumente armazenado em um campo, mas poderia ser armazenado externamente, ou calcular no tempo de compilaçao. Propriedades sao as formas mais adequadas de encapsular dados, a menos que o endereço de memoria precise ser exposto.

  * Indexador: é a senteça executa quando voce vai dar um get ou set em dado utilizando uma sintaxe de array [].

  * Operador: a sentença executa quando voce usa o operador como por exemplo + e / em operadores do seu tipo.
