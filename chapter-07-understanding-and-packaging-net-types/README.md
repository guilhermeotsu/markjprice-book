# Capítulo 7 - Entendendo e empacontando os tipo .NET

Este capítulo abordará em como o .NET Core implementa os tipos definidos no .NET Standard. Ao decorrer deste capítulo, você vai aprender como palavras chaves do C# são relacionadas aos tipos .NET, e sobre o relacionamento entre namespaces e assemblies. Voce vai se familiarizar em como empacotar e publciar suas aplicaçoes .NET Core e biblioteras para serem utilizadas em multiplas plataformas, como utilizar bibliotecas existentes escritas em .NET Framework nas biblioteras .NET Standard, e a possibilidade de portar suas base de código .NET Framework para .NET Core.

Este capítulo abordará os seguintes tópicos:

* Introdução ao .NET Core 3.0
* Entendendo os compontentes do .NET Core 
* Publicar suas aplicaçoes para deploy
* Descompilar assemblies
* Empacotar suas libs para o Nuget
* Portar .NET Framework para Core


## Introdução ao .NET Core 3.0

Atualmente o .NET Core 3.0 implementa o .NET Stardard 2.1, enquanto o .NET Framework 4.8 implementa o .NET Standard 2.0,  isso significa que o .NET Core têm mais APIs do que o .NET Framework.


## Entendendo sobre .NET Core components

O núcleo do .NET é composto por diveras partes, que são:

* Compilador da Liguagem: Onde basicamente transforma seu código escrito em C#, F# ou VB em **linguagem intermediária (IL)** armazenado em assemblies. Com o C# 6.0 e posteriores, a Microsoft trocou para um compilador open source reescrito chamado Roslyn que também é usado pelo VB.

* Common Language Runtime (CLR): Esse runtime carrega assemblies, compila o código IL armazenadao neles em instruçoes de código nativo para a CPU executar o código em uma ambiente que gerencia recursos, como threads e memória.

* Base Class Libraries (BCL) de assemblies no Nuget package (CoreFX): Estes são conjuntos pré-construidos de tipos empacotados e distribuídos usando Nuget para executar tarefas comuns ao construir aplicativos.


## Entendendo assemblies, packages e namespaces

O assembly é onde o tipo é armazenado no sistema de arquivos. Assemblies são o mecanismo para fazer o deploy do código. Por exemplo, o assembly System.Data.dll contém tipos para gerenciar dados. Para usar tipos em outros assemblies, ele deve ser referenciado.

Assemblies são frequentemente distribuidos pelo **Nuget Package**, onde pode conter multiplos assemblies e outros recursos.

O **namespace** é o endereço de um tipo. Namespaces são um mecanismo para identificar exclusivamente um tipo que requer um endereço completo em vez de um nome curto. Por exemplo, um IActionFilter do namespace System.Web.Mvc é diferente do IActionFilter do namespace System.Web.Http.Filters.


## Entendendo assemblies dependentes

Se um assembly é compilado como uma biblioteca de classe e prove tipos para que outros assemblies o utilizem, então ele tem uma extensao .dll (dynamic link library), e ele não pode ser executado sozinho.

Da mesma forma, se um assembly é compilado como uma aplicação, ele vai ter uma extensão de arquivo .exe (executável) e ele pode ser executado sozinho. 

Qualquer assembly pode ser referencia a uma ou mais biblioteca de classe, porém não pode ter uma dependencia circular. Então o assembly A nãoo pode referencia o assembly B, se o assembly B já estiver referenciando o assembly A.


## Relacionando palavras chaves do C# para tipos do .NET

Uma das perguntas mais comuns de novos programadores de C# é: Qual a diferença entre string e String?

Uma responsa curta seria: nenhuma. Uma resposta longa é que todo tipo do C# são alias para um tipo .NET em um assembly de biblioteca de classes.

Quando você usa uma palavra chaves string o compilador transform isso em um tipo System.String. Quando voce usa o tipo int, o compilador transform isso em um tipo System.Int32.


## Descompilando Assemblies

Para descompilar o projeto, vamos utilizar uma extensão do VSCode chamada de **ILSpy.NET Decompiler**.


## Publicando pacotes no NuGet

Para publicar seus pacotes, voce deve editar seu arquivo .csproj e adicionar os seguintes campos:

* PackageId deve ser globalmente unico.
* PackageLicenseExpressions deve ter o valor do seguinte link: https://spdx.org/licenses/  ou voce deve especificar uma licença customizada.