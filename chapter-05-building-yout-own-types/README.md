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


## Objetos

Todos os objetos herdam direta ou indiretamente de um tipo especial chamado de System.Object.


## Modificadores de acesso

Parte do princípio de encapsulamento é a escolha na visibilidade dos membros de suas classe.

Existem quatro modificadores de acesso do C#, que são:

 * **private**: O membro só é visivel dentro da classe.
 * **internal**: O membro só é visível dentro da classe e no mesmo assembly.
 * **protected**: O membro só é visível dentro da classe e nas classes que herdam dela.
 * **public**: Membros sao visiveis em todos os lugares.
 * **internal protected**: O membro só é acessível dentro do tipo e no mesmo assembly, e em qualquer outro tipo que a herde. É equivalente a um nome fictício internal_or_protected.
 * **private protected**: O membro é acessível dentro do tipo e em outros tipos que a herdem e no mesmo assembly. Equivalente a  um nome fictício internal_and_protected.

## Combinando valores enum

É possível combinar dois ou mais valores em um atributos enum de uma classe ao invés de apenas um. É necessário que o enum esta com o atribute Flags, que este retornar nao o valor numerico, mas uma string separada por vírgula, em suas assinatura. Entao utilizamos o o operador |.
Ex:
```C#
[Flags]
public enum MyEnum
{
  dale,
  doly
}


public class MyClass
{
  public MyEnum MyEnum;
}

var myObj = new MyClass();
myObj.MyEnum = MyEnum.dale | MyEnum.doly;

```

Boas práticas para utilizaçao de enum: Use enum para armazenar combinações de opçãoes estáticas. Derive o tipo enum  de byte se ele nao tiver mais que oito opçoes, de short de ele nao tiver mais de 16 opçoes, int se nao tiver mais de 32 e long se nao tiver mais de 64 opçoes.


## Membros estáticos

As vezes queremos definir um campo com um valor único compartilhado em todas as instâncias daquela classe. Isso é chamado de membros estáticos porque os campos não são os únicos membros que podem ser estáticos. Exemplo:
```C#
public class BankAccount
{
    public string AccountName;
    public decimal Balance;
    public static decimal InterestRate; // Membro compartilhado
}
```
*Todas as instâncias da class BankAccount terão seus próprios AccountName e Balance, mas todas as instâncias terão um único InterestRate compartilhado em todas as instâncias.*


## Retornando multiplos valores de uma função

Sabemos que métodos retornam apenas um valor de um tipo específica, seja ele primitivo ou completo. Mas existem casos em que queremos retornar multiplos valores de uma função, e normalmente para isso criarmos classes ou struct com os valores que desejamos. Porém isso é desnecessário nesses casos, podemos utilizar **Tuplas** para esse tipo de situação. Exemplo:
```C#
public (string, int) GetFruit()
{
  return ("Apple", 4);
}

(string, int) fruit = GetFruit();

WriteLine(fruit.Item1);
```

Nomeando valores das Tuplas:
```C#
public (string Name, int Amount) GetFruit()
{
  return (Name: "Apple", Amount: 4);
}

var fruitNamed = GetFruit();

WriteLine(fruitNamed.Name);

```

## Construindo Tuplas a partir de outros objetos

Também é possível criar tuplas de outros tipos:
```C#
var bob = new Person();
bob.Age = 40;
bob.Name = "Bob";

var bobTuple = (bob.Name, bob.Age, Now: DateTime.Now);
```

## Desconstruindo Tuplas

Você pode desconstruir uma tupla separando em variáveis. A descontrução têm a mesma syntaxe da criação de uma tupla, mas sem a nomeação. Exemplo:"
```C#
public (string, int) GetPerson()
{
  return ("bob", 55);
}

(string name, int age) = GetPerson();

WriteLine(name);
```

## Passando valores para métodos

Existem três forma diferentes de passar valores para funções via parâmetros:
  *por **valor** (isso é o default): uma cópia do valor é passado, o valor original não é modificado.
  *por **referencia** com o parâmetro *ref*: passa a referência de um valor, ou seja, o endereço de memória é passado. O valor original é modificado também.
  *com o parametro *out*, que é passado via referência também, mas o valor original é substituído pelo valor do método. Necessário inicializar a variável dentro do método.

## Índices

Índices permitem que o acesso a uma propriedade utilizando a syntaxe de array. Por exemplo, um tipo string define um indíce para permitir o acesso a cada caractere.