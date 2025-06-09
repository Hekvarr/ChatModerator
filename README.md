# Descrição do Projeto

Este projeto tem como objetivo o estudo das Azure Functions, com foco nas funções que utilizam os seguintes triggers: Queue, HTTP e Timer.

A aplicação consiste em um sistema de moderação de chat, cujas principais funcionalidades são:

- QueueFunction (RabbitMQ): banir temporariamente usuários que enviarem mensagens ofensivas, com o auxílio da API pública PurgoMalum;
- HTTPFunction: banir permanentemente usuários de forma manual; e
- TimerFunction: reabilitar automaticamente o acesso de usuários que foram banidos temporariamente.
