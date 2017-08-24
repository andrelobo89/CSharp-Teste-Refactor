# CSharp - Teste Refactor
Refactor de um projeto existente.

<b>Instruções</b>

Para atender o requisito N° 1, é necessário executar o arquivo "CriarRegKey.reg" para criar a chave de configuração do diretório que as notas fiscais serão salvas.

<hr>

<b>Objetivo do programa:</b>

O objetivo do programa consiste em gerar uma nota fiscal fazendo a persistência no banco de dados e em arquivo XML. 
A nota fiscal consiste em Nome do cliente, Estado de Origem, Estado Destino e itens (produtos) da nota fiscal. 

<hr>

<b>Descrição das alterações:</b>

Abaixo uma breve descrição de como foi implementado cada item do documento de requisitos:

<ul>
    <li><b>1.</b>	Foi criado um método para geração de arquivo XML, utilizando a serialização de objetos para XML. O diretório onde são salvos os arquivos XML é definido nos registros do Windows, visando mais segurança, fazendo com que apenas o time de infra estrutura tenha acesso para alterar.</li>
    <li><b>2.</b>	Foram implementados dois métodos no Data Layer (Repository), um para cada chamada de procedure. Os mesmos são executados pela Domain Layer.</li>
    <li><b>3.</b>	Para atender esta solicitação foi alterada a model de Itens da nota fiscal, alterado a Domain Layer e Data Layer para receber as novas propriedades.</li>
    <li><b>4.</b>	Criado apenas a Stored Procedure. Segue anexo o arquivo .Sql no projeto.</li>
    <li><b>5.</b>	Este requisito foi ignorado, pois no sistema já constava CFOP 6.006 para o estado de origem SP e destino RO.</li>
    <li><b>6.</b>	Alterados os campos Estado de Origem e destinos de campo texto para campo de seleção, garantindo que o usuário não possa informar dados inválidos. Alterado a ordem (TabIndex) de sequência dos campos. Adicionado validação dos campos com mensagens amigáveis. Ao salvar com sucesso os campos são limpos, ao salvar e ocorrer um erro, os dados são mantidos e é exibido uma mensagem.</li>
    <li><b>7.</b>	Utilizado conceitos SOLID (básico) para aplicar esta solução.</li>
    <li><b>8.</b>	Foi alterada a estrutura da solução separando em projetos bem definidos e com responsabilidades únicas. Abaixo segue um diagrama resumido de como está a restruturação da solução.</li>
    <li><b>9.</b>	Foi criado um teste unitário executando o único método da camada Application Service. Testando este método garante a funcionalidade de toda a estrutura.</li>
</ul>

<hr>

<b>Estrutura da solução (resumida):</b>

<img align="center" src="https://s28.postimg.org/jy3lovbzh/diagrama_imposto.jpg" alt="Estrutura do projeto">

<hr>

<b>Dúvidas? Estou a disposição!</b>

E-mail: lobo.andre89@gmail.com
