# Controle de fluxo e conversão de tipos

Esse capítulo abordará sobre como escrever códigos que vá performar sobre simples operaçoes em variáveis, tomar decisoes, repetir blocos de códigos, converter valores de variáveis ou expressoes de um tipo para outro, também será abordado sobre como tratar exceções, e verificar overflows em variáveis numéricas.

## XOR
Operador lógico **XOR**. Retorna verdade quando qualquer um dos operadores, mas não ambos, forem true. Ou seja, um deles precisa ser true mas não ambos. Exemplo:

| A | B |  XOR |
|---|:---:|:------:| 
| V | V |  F   |  true ^ true = false
|---|---|------|
| F | V |  V   |  false ^ true = true
|---|---|------|
| V | F |  V   |  true ^ false = true
|---|---|------|
| F | F |  F   |  false ^ false = false
|---|---|------|

Não é muito utilizado mas existe

## & e && ou (| e ||)

Dá para utilizar ambos os modos, o "&" é chamados de short-circuiting. Ele executa a operação indepedente do resultado da primeira, já o "&&" vai executar a primeira, se for false, nao vai executar a segunda, já que qualquer valor nao vai importar pois o resultado vai ser false.

*Evite usar o short-circuiting*.


## Patter matching 

Uma feature introduzida no C# 7.0 e posteriores. A expressao if pode ser usada com a palavra reservada **is** combinando com a declaraçao de variaveis locais mantendo seu código mais seguro.
```C#
object o = "3";
int j = 4;

if(o is int i) // Valida se a variavel o é um inteiro, no caso nao é
```

## switch case

Utilizado quando voce tem uma variável que pode assumir varios valores e para cada valor deve ser aplicado um processamento de dados diferente. Voce pode utilizar a palavra reservada **goto** para retornar para um case específico ou label. Exemplo
```C#
int x = 0;
switch(x) {
  case 1: 
    // Do something
    break;
  case 2:
    goto case 1;
  case 3:
  case 4:
    goto case 2;
}
```

Não faz sentido nenhum esse exemplo mas é apenas uma demonstraçao de como utlizar a sintaxe **goto**.


## Convertendo tipos

Quando estiver desenvolvendo você vai precisar converter diferentes tpos de dados entre si, sejam para necessidade de fazer calculos, ou como os dados estão sendo armazenados. Por exemplo, com o Console.ReadLine() que captura o input do usuário, o valor que ele retorna é uma string, mas muitas vezes precisamos converte-los em números, datas, etc, para realizar um tarefa.

Existem dois tipos de conversao de dados, os **implícitos** e os **explícitos**:
  * Implícitos: acontece automaticamente, e isso é seguro, isso significa que voce nao perdera nenhum informaçao.
  * Explícitos: é feita de forma manual delo dev porque isso **poderá** resultar na perde da alguma informaçao, como por exemplo, na precisão de um número. 

  
  ### Arredondamento de valores
  
  Dentro do C# temos a classe Convert, que tem uma série de métodos para fazer a conversão de valores explícitos, mas ao invés de lidar com a perda de valores na conversao convencional a class Convert arredonda os valores numericos, para cima ou para baixo.

  **Regras para arredondamento do Convert:**
  * Sempre arredonda para baixo se o valor decimal for menor que .5
  * Sempre arredonda para cima se o valor decimal for maior que .5
  * Quando a parte decimal for .5, vai arredondar para cima quando a parte nao decimal for ímpar, e para baixo quando for par.

  É possível controlar o arredondamento disso com o método Round da classe Math

## Capturando Exceçoes

Durante o desenvolvimento de algoritmos, nos deparamos com exceçoes lançadas pelo compilador, toda as exceçoes herdam de Exception, ela e o tipo mais generico de exceçao, mas se queremos tratar exceçao de uma forma menos generica, temos outras classes que a implementam.


## Clausula checked e unchecked

Por padrao variaveis do tipo inteiro nao lançam exceçoes caso voce tente atribuir um valor que ela nao suporta, exemplo: 

```C#
int x = int.MaxValue - 1;

x++;
x++;
x++;
```

Isso nao vai lançar exceçao, mas muitas vezes queremos que lance para podemos tratar, entao utilizamos o **checked**.

```C#
int x = int.MaxValue + 10;
```
Vai lançar um OverflowException, que pode ser tratado com o try{}catch(){}.

Para desabilitar a checagem do compile-time, utilizamos a clausula **unchecked**, permitindo que voce escreve algo como, ```C# int x = int.MaxValue + 10;```.