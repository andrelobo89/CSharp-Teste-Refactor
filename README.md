# CSharp - Teste Refactor
Refatoração de um projeto existente.

<b>Objetivo do programa:</b>

O objetivo da tela consiste em gerar uma nota fiscal com persistência no banco de dados e em arquivo XML. A nota fiscal consiste em Nome do cliente, Estado de Origem, Estado Destino e os itens da nota fiscal. 

<b>Descrição das alterações:</b>

Abaixo uma breve descrição de como foi implementado cada item do documento de requisitos:

<ul>
    <li>1.	Foi criado um método para geração de arquivo XML, utilizando a serialização de objetos para XML. O diretório onde são salvos os arquivos XML é definido no registro do Windows, visando mais segurança fazendo com que apenas o time de infra estrutura tenha acesso para alterar.</li>
    <li>2.	Foram implementados dois métodos no Data Layer (Repository), um para cada chamada de procedure. Os mesmos são executados pela Domain Layer.</li>
    <li>3.	Para atender esta solicitação foi alterada a model de Itens da nota fiscal, alterado a Domain Layer e Data Layer para receber as novas propriedades.</li>
    <li>4.	Criado apenas a Stored Procedure. Segue anexo o arquivo .Sql no projeto.</li>
    <li>5.	Este requisito foi ignorado, pois no sistema já constava CFOP 6.006 para o estado de origem SP e destino RO.</li>
    <li>6.	Alterados os campos Estado de Origem e destinos de campo texto para campo de seleção, garantindo que o usuário não possa informar dados inválidos. Alterado a ordem (TabIndex) de sequência dos campos. Adicionado validação dos campos com mensagens amigáveis. Ao salvar com sucesso os campos são limpos, ao salvar e ocorrer um erro, os dados são mantidos e é exibido uma mensagem.</li>
    <li>7.	Em breve</li>
    <li>8.	Foi alterada a estrutura da solução separando em projetos bem definidos e com responsabilidades únicas. Abaixo segue um diagrama resumido de como foi reestruturado a solução.</li>
    <li>9.	Foi criado um teste unitário executando o único método na camada Application Service. Testando este método garante a funcionalidade de toda a estrutura.</li>
</ul>

<b>Estrutura da solução (resumida):</b>

<center>![alt text](https://s27.postimg.org/4z782rwpf/diagrama_imposto.jpg)</center>
