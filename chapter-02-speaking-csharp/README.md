# Hello C# - Entendendo o Básico da Linguagem

Linguagens de programaçao têm uma similaridade bem grande com as linguagens humanas, exceto pelo que você pode **>CRIAR<** suas próprias palavras.


## Vocabulário - C#

O vocabulário do C# é composto de **palavras-chaves**, **caracteres-simbolos** e **tipos**. Alguns já são pré-definidos, como por exemplo o **using**, **namespace**, **class**, **int**, etc.

Alguns caracteres-simbolos incluem o **"**, **+**, **@**, etc. 


## Tipos, campos e variável

Em C# **Tipos** podem ser representados por algo que nós podemos categorizar as coisas. Por exemplo, Animal e Carro são tipos, por que ele categorizam algo.

Seguindo nessa linha de raciocício Rabo e Motor seriam os **campos** que compõe os tipos Animal e Carro. Enquanto Fred e Bob (nome de cachorro) sao variáveis que se referencem a uma específico tipo, no caso Animal. 

Palavras chaves como string, que se parecem com tipos, são na verdade **alias**(apelido) que representam tipos fornecidos pela plataforma onde o C# roda, .NET. Na teoria, a plataforma .NET que prove para o C# centenas de tipos, incluindo System.Int32, onde o C# o mapea e dá a ele um apelido como **int**, existem também outro tipos mais complexos como System.Xml.Linq.XDocument por exemplo.

Há uma diferença também entre o termo **tipo** e **classe**. No C# todo tupo pode ser categorizado como class, struct, enum, interface ou delegate. A palavra string é uma class, porém int é uma struct, então o melhor modo de se referir a ambos é falando que elas são **tipos**.


## Verbatim string

Quando armazenamos textos em variáveis do tipo string, nós podemos incluir sequencias de espaces, como por exemplo o famoso \n ou \t.

Mas imagine que voce precise do caminho de um arquivo armazenado dentro dessa variável, como por exemplo: 
```c#
string path = "C:\temp\awesome.txt";
```
Nesse caso o compilador gerará um erro, pois ele converterá a sequencia \t em um caractere de espace.

Aí que entra em açao as verbatim string, que são utilizado utilizando o prefixo @ no começo do valor, como:
```c#
string path = @"C:\temp\awesome.txt";
```

Para sumarizar: 
  * **Literal strings**: string  que você pode usar caracteres de escapes.
  * **Verbatom string**: você desabilita os caracteres de espaces.
  * **Interpolated string**: string interpoladas que tem o prefixo $ antes de seu valor.


## Armazendo números

Números são dados que você deseja que eles sofram algum tipo de operação matemática, como a soma. Números de telefones, ceps **não são números**, são strings.

Números podem ser *números naturais*, como 42, ou **numeros reais**, com 3.9, onde são chamados de single ou double-precision floating point numbers na computação.


### Números reais

Computadores não conseguem representar exatamente números de pontos flutuantes. O float e double armazenam numeros reais utilizando single ou double precisao de pontos flutuantes.

Variáveis do tipo int acupam 4 bytes de memoria e podem armazenar valores positivos e negativos próximos dos 2 bilhos. O double usa 8 bytes e pode armazenar grandes valores. E o decimal usa 16 bytes e pode armazenar grandes valores tambem, mas nao tao grandes quanto o double.

Mas como isso????

#### Comparando double e decimal

Se você escrever o seguinte programa: 
```c#
double a = 0.1;
double b = 0.2;

if(a + b == 3.0)
```

Vai ver que p valor do resultado do if é falso, isso acontece porque o tipo double não garante a precisão porque ele literamente não podem ser representados como valores de ponto de flutuante. *[Referencia](https://www.exploringbinary.com/why-0-point-1-does-not-exist-in-floating-point/)*.

**Boas práticas:** Nunca compare valores double utilizando ==, isso pode custar vidas. Foi o que aconteceu durante a Primeira Guerra do Golfo, uma bateria de mísseis americanos utilizavam valores do tipo double para fazer seus calculos. Uma imprecisão causou a falha no rastreamento e interceptaçao de um míssel e 28 soldados foram mortos. *[Fonte](https://www-users.math.umn.edu/~arnold/disasters/patriot.html)*.

Se modifcar o programa anterior para: 
```c#
decimal a = 0.1M; 
decimal b = 0.2M;

if(a + b == 3.0)
```

O resultado é verdadeiro. Isso ocorre poir o tipo decimal é preciso, ele armazena como um bitint e desloca o pont decimal. Por exemplo, 0.1 é armzenado como 1, com uma nota para deslocar o ponto decimal uma casa para a esquerda. 12.75 é armazenado como 1275, com uma nota para deslocar a virgula dois para a esquerda.

**Boas práticas:** utilize **int** para números naturais, **double** para números reais que não precisem ser comparados com outros valores e também não precise de uma grande precisão, use **decimal** para quando a precisão do número real for importante, tipo dinheiro.

Tipo **double** tem uns valores especiais que podem ser úteis; double.Nan not-a-number, double.Epsilon que representa o menor numero positivo que uma variáveis do tipo double pode armazenar, e double.Infinity que é um valor muito grande, nao existe coisas infinitas em computação.


## Armazenando qualquer tipo de objeto

É possível utilizar o tipo **object** que está no C# desde sua primeira versão, mas a partir do C# 2.0 temos uma alternativa melhor chamada **generics** que prove maior flexibilidade, mas sem sobrecarga de desempenho.

```C#
object str = "Bob";

// int strLength = str.Length; // dá erro, precisa fazer o cast 

int strLength = ((string)str).Lenth 
```

## Armazenando tipos dinâmicos

Outro tipo que existe é o **dynamic** que também pode armazenar qualquer tipo de dados, mas ainda mais que um **object**, mas sua flexibilidade vem junto com custo do desempenho. **dynamic** foi introduzido no C# 4.0. Ao contrário de um **object** o valor armazenado na variável pod eter seus membros invocados sem uma conversão explícita.
```C#
dynamic str = "Bob";

int strLength = str.Length; // dá certo
```

## Variáveis locais

Variáveis locais são declaradas dentro de métodos, e ele só existem durante a execução daquele método, uma vez que o método retorna, a memória alocada para a variável local é liberada.


## Valores default para os tipos

A maioria dos tipos primitivos, exceto string, são **tipos de valores**, o que significa que eles devem ter um valor. É possível definir um valor defautlt using o operador **default()**.

A **string** é **tipo referência**, o que significa que ele nao armazena seu próprio valor, mas sim um endereço de memória do valor. Variaveis de tipo referência podem ter um valor nulo, que significa que ele nao armazena nenhum endereço de memória.

## Valores nulos para tipos de valor

Tipos de valores devem sempre ter um valor. Mas as vezes lemos dados de um banco de dados ou algo assim que permitem valor nulos. No C# utilizamos o **nullable** que permite valores nulos a variaveis do tipo de valor. 
```C#
int cannotBeNull = 4;
cannotBeNull = null; // Dá erro

int? couldBeNull = null; // Nao dá erro
```

Verificar se o valor de uma variável do tipo referencia ou valor nullable é nulo antes de usa-lá é muito importante, pois se tentar usa-lá tendo uma valor nulo ela vai lançar uma **NullReferenceException** e o resultado vai ser um erro.
```C#
int variableNull = null;

if(variableNull != null) 
{
  // TODO 
}

// null-condition operator

string authorName = null;

int x = authorName.Length; // Vai lançar uma exceção NullReferenceException

int? y = author.Length; // Em vez de lançar uma exceçao vai atribuir null a variável
```

*[Referencia Null-Condition operator](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-conditional-operators)*