# Bem vindo ao C#

Neste capítulo tem como objetivo configurar o ambiente de desenvolvimento e entender a similaridade entre .NET Core, .NET Framework e .NET Standard, também vamos criar uma simples aplicação com C# e .NET Core utilizando o Visual Studio Code.


## Entendendo o .NET Framework

.NET Framework é uma plataforma de desenvolvimento que inclui o **CLR (Common Language Runtime)**, que é responsável por gerenciar a execução do código, e o **BCL (Base Class Library)**, que fornece uma rica biblioteca de classes para o desenvolvimento de aplicações. Originalmente a Micrsoft o projetou para que ele funcione em multiplas plataformas, mas houve um esforço maior para que ele funcione melhor no Windows.

Desde o .NET Framework 4.5.2 ele é um componente do Windows. .NET Framework está instalado em mais de um bilão de computadores ao redor do mundo, isso faz com que seja muito arriscado fazer qualquer tipo de mudanças nele, então as mudanças são as mínimas possíveis. Até correções de bugs são atualizadas com pouca frequência.

***Basicamente:** Falando de maneira prática, .NET Framework suporta apenas Windows e é uma plataforma legada. Não crie novas aplicaçoes usando isso.*


## Entendendo o .NET Core

Hoje nós vivemos em um mundo verdadeiramente multiplataforma, pouca importa qual sistema operacional utilizamos. Por causa disso a Microsoft têm trabalhado no desacoplamento do .NET do Windows. Enquanto eles reescrevem o .NET Framework para uma versão multiplataform de verdade, eles também têm a possibilidade de refatorar e remover partes principais que nao são consideredas essenciais.

Um novo produto foi produzido, o .NET Core, que inclui implementações para funcionar multiplataform do CLR, conhecido como CoreCLR e uma bibliotera simplificada de classes conhecida como CoreFX.

O .NET Core é menor que o .NET Framework, isso se deu devido ao fato da Microsoft ter como objetivo componetizar o .NET Core em pacoted NuGet, para que a aplicação tenha menos dependências desnecessárias,

## Entendendo o .NET Standard

A situação do .NET em 2019 é que eles tinham três forks da plataforma controlada pela Microsoft, que são:
  * .NET Core: multiplataforma e para novos aplicativos,
  * .NET Framework: para aplicaçoes legadas.
  * Xamarim: para aplicações mobiles.

Cada uns desses forks têm seus pontos fortes e fracos, porque foram projetados para diferences cenários, isso é ruim por que os devs precisam aprender essas três plataformas, cada um com suas peculiaridades e limitações.

Por causa disso a Microsoft definiu o **.NET Standard:** uma especificação para um conjuntos de APIs que toda plataforma .NET pode implementar para indicar o nível de compatibilidade que ele têm. Por exemplo, o suporte básico é indicado se a plataforma for compatível com o padrão .NET Standard 1.4.

Com o .NET Standard 2.0 e posterior, a Microsoft fez com que as três plataformas convergirem em um padrão, o que torna mais fácil para os devs compatilharem códigos em qualquer plataforma.

***.NET Standard é apenas um padrão.***

Você nao precisa instalar o .NET Standard para o utilizar, assim voce não precisa instalar HTML5 para utilizar HTML5. Para utilizar o HTML5 você só precisa de um navegador que implemente o padrão HTML5, nessa mesma linha de raciocínio, você só precisa de uma plataforma do .NET que implemente o .NET Standard para poder utiliza-lo.


## Entendendo IL (Intermediate Language)

O compilador C# (nomead Roslyn) que é utilizado pela ferramente dotnet CLI converte seu código fonte C# em código IL e armazena a IL em um assembly (DLL ou EXE). Código IL são como instruções em lingugem assembly, onde são executadas pela maquina virtual do .NET Core, a CoreCLR.

Em tempo de execução, o CoreCLR carrega o código assembly, o compilador junt-in-time (JIT) o compila em instruções de CPU nativas, e em seguida, é executado pela CPU da sua máquina. O benefício desses três passos do processo de compilação é que a Microsoft criou o CLR para o Linux e MacOS. O mesmo código IL roda em toda plataforma.