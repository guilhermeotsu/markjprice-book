# Entendendo o vocabulário de proteção de dados

Existem muitas tecnicas para proteger seus dados, vamos explicar 6 delas:

* **Encryption and decryption**: basicamente converte um text puro em um texto criptografado, e vice-versa.
* **Hashes**: é uma maneira para gerar valores hash seguros para armazenar senhas, pode ser usado para detectar alteraçoes maliciosas ou dados corrompidos.
* **Signatures**: essa tecnica é utilizada para validar a assinatura aplicada na data;
* **Autenticação**: validar se um usuário pode ter acesso ao sistema.
* **Autorizaçao**: validar se o usuário que tem acesso ao sistema pode desempenhas determinada funçao.


## Encrypting and decrypting data

No .NET Core existem diferentes algoritmos que voce pode utilizar para  encriptar seus dados.

Alguns algoritmos sao implementos pelo sistema operacional, que tem o sufixo **CryptoServiceProvider**, e a outros sao implementados pelo proprio .NET Core, que tem o sufixo **Managed**.

Alguns algoritmos usam chaves simetricas, e outros usam chaves assimetricas. O principal algoritmo para encriptar chaves assimetricas é o **RSA**.

**Boas práticas**: use o Advances Encryption Standard (AES), baseado no algoritmo Rijndael para encriptamento simetrico. Escolha RSA para encriptamento assimetrico. Nao confunda RSA com DSA. Digital Signature Algorithm (DSA) nao pode encriptar dados. Ele apenas gera hashes e assinaturas.


## Assinatura de dados

Para provar que recebemos dados de um lugar que confiamos, devemos assinar esses dados. Na verdade você nao assina os próprios dados, em vez disso, você assina um hash de dados.

Vamos utilizar algoritmo SHA256 para gerar a hash dos dados, combinando com o algoritmo RSA para assinar esses dados.

Poderíamos utilizar também o algoritmo DSA para gerar e assinar seus dados. DSA é mais rapido que o RSA para gerar e assinar, porém é mais lento na hora de validar a assinatura. Asssinaturas sao geradas uma unica vez, porém validações são feitas muitas vezes, então é melhor termos uma validação rápido do que uma geração.


## Gerando numeros aleatorio

O C# fornece uma classe especifica para essa finalidade a **Random** nela voce pode gerar numeros aleatorios, pode ser utilizado para fazer Seeds ou algo assim. Porem nao use essa classe para gerar numeros para Criptograifa, o numero gerado por essa classe pode se repetir e consequentemente quebrar a seguranca da sua aplicacao.

Para um verdadeira geracao de numeros aleatorios voce deve usar umm tipo derivao de **RandomNumberGerenator**, como por exemplo o **RNGCryptoServiceProvider**.


## Autenticacao e atorizacao

Autenticacao: verificar se o usuario pode acessar o sistema com base em suas credenciais, que podem ser usuario e senha, digital, etc.

Autorizacao: verificar se o usuario autenticado pode acessar determinada funcionalidade do sistema, podendo ser individual ou em grupo. Exemplo: uma pessoa do setor de logistica pode acessar o sistema mas nao pode ver a folha de pagamento dos funcionario, e vice-versa. Uma boa prática de autorizacao é basear em roles e entao adicionar os usuarios a essa role, tratando assim de uma maneira mais generica e evitando ter que fazer validacoes para cada usuario.

Existem diversos mecanismos para fazer autenticacao e autorizacao, mas todos eles implementar um par de interfaces: **IIdentity** e **IPrincipal**.

IIdentity representa um usuário, que tem uma propriedade **Name**, o nome do usuario e o **IsAuthenticated**, que representa se o usuario é anonimo ou é conhecido. A classe mais comum que implementa essa interface é a **GenericIdentity**, que herda de **ClaimsIdentity**.

Cada **ClaimsIdentity** tem uma propriedade **Claim**. O objeto **Claim** tem uma propriedade **Type** que indica se o claim é para seu nome, sua associacao em uma funcao ou grupo, sua data de nascimento e assim por diante.

IPrincipa é utilizado para asasociar uma identidade a uma funcao e/ou grupo que sao membros, entao ele pode ser utilizado para fins de autorizacao. A thread em execucao no seu código tem uma propriedade **CurrentPrincipal** que pode ser qualquer objeto que implemente IPrincipal, e será verificado qndo for necessário permissao para realizar uma acao segura.

A classe mais comum que implementa essa interface é a **GenericPrincipal**, que herda de ClaimsPrincipal.

https://docs.microsoft.com/en-us/dotnet/standard/security/principal-and-identity-objects