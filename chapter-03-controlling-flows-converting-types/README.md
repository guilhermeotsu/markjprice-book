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
