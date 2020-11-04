# Capítulo 8 - Trabalhando com tipos do .NET

Esse capítulo abordará sobre algums tipos comuns do .NET Standard que estão incluídos no .NET Core. Isso inclui tiipos para manipular números, textos, coleções, acesso à rede, reflextion, atributos, melhorando o trabalho com spans, indices, e ranges e internacionalização.

Esse capítulo abordará os seguintes tópicos:

* Trabalhando com números
* Trabalhando com textos
* Pattern matching com Regex
* Armazenado multiplos objetos em coleções
* Trabalhando com span, indexes e ranges
* Trabalhando com acessos à rede
* Trabalhando com tipos e atributos
* Internacionalizando seu código


## Trabalhando com Regex

Expressoes regulares são muito úteis, mas podem adicionar uma complexidade bem grande no seu código. Elas são bastante utilizadas para validar um input de um usuário por exemplo.


## Entendendo a sintaxe de Regex

Aqui alguns simbolos que sao utilizados em expressoes regular

| **Símbolo** | **Significado** 
|:-----------:|:---------------:
|     ^       | Começo do Input
|     \d      | Digito unico    
|     \w      | Espaço em branco
| [A-Za-z0-9] | Range de caracteres
|   [aeiou]   | Conjunto de caracteres
|      .      | Qualquer caractere
|      $      | Fim do Input
|     \D      | Um único não-digito
|     \W      | Espaço não em branco 
|     \^      | ^ caractere
|   [^aeiou]  | Não em um conjunto de caractere
|     \.      | . Caractere


Alguns símbolos **quantificadores** de expressoes regulares

| **Símbolo** | **Significado**
|:-----------:|:---------------:
|      +      | Um or mais
|     {3}     | Exatamente e
|     ?       | Um ou mais
|    {3, 5}   | Entre 3 e 5
|    {3,}     | Pelo menos tres
|    {, 3}    | No máximo 3


Muito dificil Regex slc.


## Entendendo coleções

Há diferenças severas para a escolha de uma coleção, cada uma delas têm diferentes propósitos.

**Lists** é uma boa escolhar quando voce quer controlar manualmente a ordem dos itens da sua coleção. Cada item da lista tem um índice único (ou posição) que é atribuida automaticamente.

**Dictionaries** são uma boa escolha quando cada valor (ou objeto) tem um único sub-valor que pode ser usado como **chave** para achar rapidamente o valor na coleção. A chave deve ser única.

**Stacks** são uma boa escolha quando queremos implementar um comportamente de last-in, first-out (LIFO), último a entrar primeiro a sair. Com a stack, voce só tem uma direção para acessar ou remover um item no topo da stack. Voce nao pode por exemplo, acessar diretamente o segundo item da stack.

**Queues** são uma boa escolha quando queremos implementar um comportament de first-in, first-out (FIFO), primeiro a entrar primeiro a sair.

**Sets** são uma boa escolha quando queremos realizar operações entre duas coleções.


## Trabalhando com spans, indexes e ranges

Um dos objetivos da Microsoft com o .NET Core 2.1 foi melhorar a performance e os recursos utilizadoss. E a chave para isso foi a feature **Span<T>**.

Quando manipulamos coleções de objetos, você vai frequentemente criar novas coleçoes de outras já existentes passando parte de seus objetos. Isso não é eficiente porque vai duplicar os objetos criados na memória.
Se você precisar trabalhar com subconjuntos de coleções, ao invés de replicar o subconjunto em uma nova coleção, span é como uma janela em um subconjunto da coleção original. Isso é mais eficiente em termos de uso de memória e melhora a perfomance. Mas antes de falar sobre span, precisamos conhecer indexes e ranges.

## Identificando posições com tipo Index

C# 8.0 introduz duas features para identificar indices de itens dentro de uma coleção e range de itens usando dois indíces. 

Voce aprendeu que para acessar um item de uma List, ou um caractere de uma string utilizamos numeros inteiros, assim:
```C#
int index = 3;
Person p = peoples[index]; // quarta pessoa da lista de pessoa

char letter = name[index]; // quarta letra do nome 
```

O tipo de valor Index é uma forma mais formal de identificar uma posição, e suporta contagem a partir do final, como mostrado no seguinte código:
```C#
// duas maneira de definir o mesmo indice, 3 a partir do começo
var i1 = new Index(value: 3); //  contando a partir do começo
Index i2 = 3; // usando casting implicito para int

// duas maneira de definir o mesmo indice, 5 a parti do final
var i3 = new Index(value: 5, fromEnd: true);
var i4 = ^5; // usando caret operator do c# 8.0
```

Nos precisamos definir explicitamente o tipo Index na segunda sentença, por que se nao o compilar iria trata-lo como um int. Na quarta sentença o caret operator foi o suficiente para que o compilador entendesse nosso significado.


## Identificando range com o tipo Range

O tipo Range utilizando o tipo Index para indicar o começo e o fim da range, como mostrado no codigo a seguir:
```C#
Range r1 = new Range(start: new Index(3), end: new Index(7));
Range r2 = new Range(start: 3, end: 7); // Usando conversao implicita de int
Range r3 = 3..7; // Usando syntaxe c# 8.0
Range r4 = Range.StartAt(3); // Do indice 3 até o último
Range r5 = 3..; // Do indice 3 até o ultimo
Range r6 = Range.EndAt(3); //  Do indice 0 ate o 3
Range r7 = ..3; // Do indice 0 até o 3
```


## Trabalhando com recursos de Rede

As vezes precisamos trabalhar com recursos de rede, e o .NET tem suporte para isso, como por exemplo, trabalhar com servidores DNS, endereços de IP, servidores FTP, servidos HTTP, etc.


## Trabalhando com tipos e atributos

**Reflection** é um recurso de programação que permite que o código se entenda e se manipule. Um assembly é composto de até quatro partes:
* **Assembly metadata e manifest:** Nome, assembly, e versão do arquivo, assemblies referenciados e assim por diante.
* **Type metadata**: Informações sobre tipos, seus membros e assim por diante.
* **IL Code**: Implementação dos métodos, propriedade, construtores e assim por diante.
* **Embedded Resources (opcional)**: Imagens, strings, Javascript e assim por diante.

Os metadados compreendem itens de informação sobre seu código. Os metadados é aplicado  no seu código usando atributos.

Atributos podem ser aplicados em multiplos níveis: para assemblies, para tipos, e para seus membros, como mostrado no seguinte código:
```C#
// atributo nível assembly
[assembly: AssemblyTitle("Working with Reflection")]

// atributo nível tipos
[Serializable]
public class Person

// atributo nível membro
[Obsolete("Deprecated: use Run instead.")]
public void Walk()
{
    // ...
}
```


## Controle de versão de assemblies

Numeros de versao no .NET são a combinação de tres numeros, com mais dois opicionais. Se voce seguir as regras semanticas de versionamento:
* **Major**: A mudança quebra.
* **Minor**: Ininterrupto, incluindo novas features e correção de bugs.
* **Patch**: Ininterrupto correçao de bugs

Opicionais:
* **Prerelease**: Versoes previews não suportadas.
* **Build number**: Builds noturnos.

Referencia: https://semver.org/


## Internacionalizando seu código

Internacionalizar é o processo de habilitar que seu código rode de acordo com a região do usuário. Isso é dividido em duas partes: **globalization** e **localization**.

Globalization é sobre escrever seu código para acomodar multiplas combinações de linguagens e regiões. A combinação de ambos é conhecido como cultura. É importante saber disso pois, o formato de por exemplo Data e Moeda é diferente em Quebec e Paris, mesmo que ambos utilizem a linguagem Francesa.

Existe a Organização Internacional para Padronização (ISO) para a combinação das diferentes culturas. Por exemplo, no código **da-DK**, **da** indica a linguagem Danish e **DK** indica a região Denmark, entre outras.

ISO não é um acronimo. ISO é uma referencia ao Greek word isos (o que significa igual).

Localization é sobre customizar a interface do usuário para suportar a linguagem dele, por exemplo, mudar o label de um botao de Close (en) para Fechar (br).