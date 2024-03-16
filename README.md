# Cloud Storage

---

Projeto desenvolvido durante a aula 02 do canal [Rockseat](https://www.youtube.com/watch?v=pIM0xkSDg7M&t=1601s).

Ministrada por: [Welisson Arley](https://www.linkedin.com/in/welissonarley/).

Acompanhada por: [Mayk Brito](https://www.linkedin.com/in/maykbrito/), que coordenava a live e o chat enquanto Welisson ministrava a aula.

Nesse encontro, colocamos a mão na massa e criamos uma API para upload de arquivos no Google Drive. Em uma única aula, aprendemos como as APIs funcionam e como podem ser usadas para integrar diferentes sistemas e serviços. Além disso, praticamos e aprimoramos habilidades de programação em C#/.NET e aprendemos a navegar e utilizar uma API de terceiros para realizar operações úteis, como o upload de arquivos.

Utilizamos algumas bibliotecas, como:

- FileTypeChecker: para validar se a foto enviada era realmente uma foto. Caso mudássemos a extensão de um PDF para PNG, ele notaria a conversão e não permitiria a subida da falsa foto para o drive em questão.

- Google.Apis.Drive.v3: para acesso ao Google Drive e configurações de ClientId, ClientSecret que geramos no [site da Google](https://console.cloud.google.com/).

- Swagger: para testar a API.
