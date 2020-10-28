# Capítulo 6 - Implementando Interfaces e Classes derivadas

Este capitulo abordará sobre derivar novos tipos de outros utilizando OOP. Você vai aprender sobre a definição de operadores e funções locais para executar açoes simples, delegates e eventos para trocar informaçoes entre diferentes tipos, implementar interfaces para geração de funcionalidades em comum, genericas, a difereça entre tipo referência e valor, herdar de classes bases para criar classes derivadas com o intuito de reutilizar funcionalidades, sobrescrever um tipo membro, utilizar o polimorfismo, criar metodos de extensao, e casting entre classes em hierarquia de herança.


## Operadores em métodos

Um operador é um método que executa um função específica, mas utilizar o operador ao invés do método pode fazer com que a sintaxe seja mais concisa.

É possível implementar métodos e chama-los com a syntaxe de operadores, utilizando a palavra chave **operator**. Exemplo:

```C#
public class Person 
{
    public string Name; 

    // Método de "Procriar", ele vai ser chamado com sintaxe de operador
    public static Person operator * (Person p1, Person p2)
    {
        return Person.Procreate(p1, p2);
    }

    public Person Procreate(Person p1, Person p1)
    {
        return new Person { Name = "New Person Beby"};
    }
}

// Chamando o método com sintaxe de operador
var person1 = new Person { Name = "Person1"};
var person2= new Person { Name = "Person2"};

// Vai chamar o método estático "operator *"
var baby = person1 * person2;
```

## Implementando Funcionalidade usando Funções locais

Funções locais são equivalente a variáveis locais. Em outras palavras, ele só a função só vai estar acessível no escopo em que foi definida.

Função locais podem ser definidar em qualquer lugar dentro de um método, no topo, em baixo ou em qualquer lugar do meio. Exemplo de uma função que calcular o Fatorial de um número, utilizando função local:
```C#
public static int Factorial(int number)
{
    if(number < 0)
        throw new ArgumentException($"{nameof(number)} não pode ser menor que 0");
    
    return localFactorial(number);

    // Função local
    int localFactorial(int localNumber) 
    {
        if(localNumber < 1) 
            return 1;
        
        return localNumber * localFactorial(localNumber - 1);
    }
}
```


## Provocando e manipulando Eventos

**Metodos** são frequentemente descritos como ações que podem ser executadas em voce mesmo, ou em objetos relacionados. Por exemplo, *List* pode adicionar novos itens a voce mesmo ou esvaziar, e *File* pode criar ou deletar arquivos do sistema de arquivos.

**Eventos** são descritos como ações que acontecem com um objeto. Por exemplo, em uma interface de usuário o Botão têm o evento de Click, o click é algo que acontece com o botão. Outro modo de se pensar em eventos é que os eventos fornecem uma maneira de se trocar mensagens entre dois objetos.

Eventos são construidos com **delegates**.


## Chamando métodos utilizando delegates

O modo mais comum, e que provavelmente já utilizou ou executou, é chamando o método através de o operador "." para acessar o método. Por exemplo, Console.WriteLine, chama o tipo Console para acessar o método WriteLine.

Um outro modo de executar funções é utilizando **delegates**. Caso você já tenha utilizado outras linguagens de progração que suportam funções ponteiros, voce pode pensar que delegate e um tipo de função segura de ponteiros. Em outras palavras, o delegate contém o **endereço de memória** do método que corresponde à mesma assinatura do delegate para que possa ser chamado de forma segura com os tipos de parametros corretos. 

Por exemplo, imagine que você tem um método dentro de uma classe, esse método têm como parametro uma string e retorna um tipo int:
```C#
public class MinhaClasse 
{ 
    public int MinhaFuncao(string input)
    {
        return input.Length;
    }
}
```

Voce pode chamar o método a partir de uma instancia de classe, minhaClasse, assim: ``` int x = minhaClasse.MinhaFuncao("Dog");```

Como alternativa ao exemplo anterior, posso criar um delegate com uma assinatura correspondente para chamar o método de forma indireta. Note que o nome dos parametros não correspondem. Apenas o tipo do parametro e retorno são correspondentes entre si. Exemplo: 
```C#
delegate int DelegateComAssinaturaCorrespondete(string s);
```` 

Agora, é possível criar uma instancia do delegate, apontar para o método e, chamar o delegate (que vai chamar o método), conforme mostrado no código a seguir: 
```C#
// criar uma instancia do delegate e apontando para o método
var d = new DelegateComAssinaturaCorrespondete(minhaClasse.MeuMetodo);

int y = d("Dog");
```

Uma grande vantagem de se utilizar um delegate é a **flexibilidade**.

Por exemplo, imagine que precisamos criar uma fila de métodos que serão chamados em ordem, devemos utilizar delegates para isso. Ação de enfileiramento que precisam ser executadas são comuns em serviçoes para fornecer escalabilidade.

Outro exemplo é que isso permite que multiplas ações sejam executadas paralelamente.

Mas o **mais importante** a se saber sobre delegates é que eles permitem a implementação de **eventos** para mandar mensagens entre diferentes objetos que não precisem ter conhecimento da existência um do outro.


## Definindo e manipulando delegates

A Microsoft tem dois delegates predefinidos para usar com eventos. A assinatura deles são simples, e flexível, como mostrado no seguinte código:
```C#
public delegate void EventHandler(object sender, EventArgs e);
public delegate void EventHandler<TEventArgs>(object sender, EventArgs e);
```

**Boas práticas**: Quando necessário criar seus próprios eventos do seu próprio tipo, você deve usar um desses eventos já predefinidos.

Delegate são multicast, ou seja, você pode atribuit multiplos delegates a um único campo delegate. Para adicionarmos mais de um delegate a um campo utilizamos o operador "+=". E quando o delegate é chamado, todos os delegate atribuidos a ele tambem sao chamados, voce nao tem controle da ordem em que eles sao chamados.


## Definindo e manipulando Eventos

Agora voce que voce viu como implementam delegates, a funcionalidade mais importante de eventos: a capacidade de definir uma assinatura para um metodo que pode ser implementado por um trecho de codigo totalmente diferente e, em seguida, chamar esse metodo e quaisquer outros que estejam ligado ao campo delegate.

Ao atribuir um método a um campo delegate, **nao** devemos utilizar o operador simples, assim: 
```C#
p1.Shoult = Harry_Shoult;
```

Se o campo Shoult já estiver com uma  referencia para um ou mais métodos, voce vai substituir tudo o que esta nele pelo o que for atribuido. Para manter a integridade do campo delegate, sempre queremos que os programadores que vao ligar com o campo use os operador "+=" ou "-=" para atribuir ou remover os metodos, para forçar isso adicione o palavra reservada **event** na declaração do campo delegate. Isso só vai importar caso o seu campo delegate permitir que mais de um método seja atribuido a ele.


## Implementando Interfaces

Interfaces sao uma forma de conectar dois tipos diferentes para fazer coisas novas. Ele é como se fosse um T de tomadas (Benjamim), onde juntam duas tomadas diferentes em um conector apenas.


## Gerenciando memoria com tipos de referencia e valor

Existem duas categorias de memoria: memoria **stack** e memoria **heap**. Com os sistemas operacionais modernos, a stack e head podem ocupar qualquer local físico ou virtual da memoria.

Memoria stack é mais rápida para trabalhar (ela é gerenciado diretamente pela CPU e tambem por que usa o mecanismo de first-in, first-out (FIFO), e é mais provável que tenha dados em seu cache L1 ou L2) porém é limitado em tamanho, enquanto a memoria head é lenta porém muito mais abundante. Por exemplo, no Linux, podemos ver o tamanho da memoria stack com o comando **ulimit -a**, onde no meu caso o tamanho da stack éde apenas 8192 kbytes e "other memories" é "unlimited". É por isso que muitas vezes é fácil nos depararmos com uma "stack overflow".

No C# existem duas palavras chaves para criamos nossos tipos de objetos: **class** e **struct**. Ambos podem ter os mesmos membros, como campos e métodos. A diferença entre eles é em como a memória é alocada.

Quando definimos um tipo usando **class**, voce define um **tipo referência**. Isso siginifica que o objeto é alocado na **head**, e apenas o endereço de memória do objeto é armazenado na stack.

**[Referência](https://adamsitnik.com/Value-Types-vs-Reference-Types/)**

Quando você define um tipo usando struct, você define um tipo valor. Isso significa que a memória alocada para o objeto é armazenado na stack.

Se um struct usa tipos de campos que **não são** do tipo structm então esses campos serão armazenados no heap, o que significa que os dados para aquele objeto são armazenados na stack e no head!

Esses são os tipo struct mais comuns:
* **Numbers:** byte, sbyte, short, ushort, int, uint, long, ulong, float, double and decimal.
* **Miscellaneaous:** char and bool.
* **System.Drawing:** Color, Point and Rectangle.

Todos os outros tipos são tipo class, incluindo string.

Além da diferença de onde os dados são armazenados, outra grande diferença é que você não pode herdar de uma struct.

**Boas práticas:** Se o total de bytes do tipo que você criar tiver 16 bytes ou menos, e seu tipo nao poder ser derivado, a Microsoft recomando que você use struct para criar seu tipo. Se seu tipo tiver mais de 16 bytes, ou se esse tipo vai ser derivado por outro, então use class.

## Layout de Memória

Toda instancia de um tipo referência têm dois campo extras que são usados internamente pelo CLR.

**ObjectHeader** é um bitmask, onde é usado pelo CLR para armazenar alguma informações adicionais. Por exemplo: se você bloquear uma instância de objeto, está informação é armazenada no ObjectHeader.

**MethodTable** é um ponteiro para a tabela de métodos, que é um conjunto de metadados sobre determinado tipo. Se você chamar um método virtual, então a CLR pula para a tabela de métodos e obtém o endereço da implementação atual e realiza a chamada real. 

O tamanho de ambos os campos ocultos são iguais ao do tamanho de um ponteiro. Portanto, para arquitetura de 32 bites, temos 8 bytes de overhead e para 64 bits temos 16  bytes.

Tipo valor não têm nenhum informação adicional no membro overhead. O que você ve é o que você vai obter. É por isso que eles são mais limitados em termos de features. Você nao pode derivar de uma struct, lock.


## CPU Cache

s


## Liberando recursos não gerenciados

Construtores podem ser usados para inicializar campos e um tipo pode ter vários construtores. Imagine que um construtor aloca um recurso não gerenciado; ou seja, qualquer coisa que não seja controlada pelo .NET, como um arquivo ou mutex sob a construção do SO. O recurso não gerenciado deve ser liberado manualmente porque o .NET não pode fazer isso por nós.

Cada  tipo pode ter um único **finalizer** que vai ser chamado pelo .NET runtime quando o recurso precisa ser liberado. O finalizer tem o mesmo nome do construtor; ou seja, o nome tipo, porém com o prefixo "~", como mostrado no seguinte código:
```C#
public class Animal
{
    public Animal()
    {
        // aloca qualquer recurso nao gerenciado
    }

    ~Animal() // finalizer ou desconstrutor
    {
        // desaloca qualquer recurso nao gerenciado
    }
}
```

O desconstrutor libera recursos; ou seja destrói um objeto. 

Um método de desconstrução retorna um objeto dividido em suas partes constituentes e usa a sintaxe de desconstrução C#, por exemplo, quando trabalhamos com tuplas.

O código anterior é um exemplo do mínimo que você deve saber quando trabalho com recursos não gerenciados. Mas o problema em fornecer apenas um finalizador é que o GC requer dois GC para completar a liberaçao do recurso.

Apesar de opicional, recomenda-se também fornecer um método que permita a um desenvolvedor que usa seu tipo liberar recursos explicitamente para que o GC possa liberar recursos não gerenciados, como um arquivo, imediatamente e deterministicamente e, em seguida, liberar a parte da memória gerenciada do objeto em uma única coleção.

Existe um mecanismo padrão para de fazer isso, que é implementando a interface IDisposable, como mostrado no código seguinte:
```C#
public class Animal : IDisposable
{
    public Animal()
    {
        // aloca o recurso nao gerenciado
    }

    ~Animal() // finalizer
    {
        if(disposed) return;

        Dispose(false);
    }

    bool disposed = false; // tem algum recurso que precisa ser liberado?

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if(disposed) return;
        
        // desaloca um recurso nao gerenciado
        if(disposing)
        {
            // desaloca qualquer outro recurso gerenciado

        }

        disposed = true;
    }
}
```

No código temos dois método Dispose, o public e o private:
- public vai ser chamado por um desenvolvedor usando o seu tipo.
- private tem um  parametro bool que é usado internamente na implementaçao desalocando os recursos. Ele precisa verificar o parametro disposing e o sinalizador disposed por se o finalizer já estiver sido executado, então apenas um recurso não gerenciado precisa ser desalocado.


## Garantindo que o Disposed seja chamado

Quando alguém usa um  tipo que implementa IDisposable, ele podem garantir que o método publico Dispose seja chamado utilizando a palavra reservada using, como mostrado no código a seguir:
```C#
using(var a = new Animal())
{
    // Código que usa a instancia do animal
}
```

O compilador converte seu código em algo parecido com isso, garantindo que se um exceçao for lançada o método Dispose será chamado:
```C#
var a = new Animal();
try 
{
    
}
finally
{
    if(a != null) a.Dispose();
}
```

## Sobrescrevendo métodos

Para sobrescrever um método, na classe base o método em questão deve ter em sua assinatura a palavra **virtual.** E no método que irá sobrescrever deve ser assinado com a palavra chave **override.**

Voce pode previnir que sua classe seja herdada aplicando a palavra chave **sealed** na sua definição.


## Entendo o Polimorfismo

Voce tem agora suas maneiras de mudar o comportamento de um método herdado. Nós podemos ocultar usando a palavra reservada **new**, ou sobreescreve-lo.

Ambos os jeitos podem acessar os membros da classe base utilizando a palavra reservada **base**, mas qual a diferença entre elas?

Tudo vai depender do tipo que contém a referência para o objeto. Por exemplo, uma variavel de um tipo Person pode armazenar uma referencia de uma classe Person, or qualquer tipo que herde de Person.

Nao entendi Polimorfismo.

