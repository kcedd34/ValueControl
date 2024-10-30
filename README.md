# Pré-requisitos
.NET SDK 6.0+
Entity Framework Core CLI (para migrações)
Editor de código (Visual Studio ou Visual Studio Code)
Ferramenta de teste opcional(Postman ou curl)

# Este projeto atende aos requisitos de arquitetura descritos:

# 1. Escalabilidade
Design Modular com Serviços Separados: O projeto foi desenhado com serviços independentes para controle de lançamentos e consolidação de saldo diário. Isso permite que cada serviço escale de forma independente conforme a carga de trabalho aumenta.
Possibilidade de Dimensionamento Horizontal: Usando uma arquitetura baseada em serviços, o projeto permite que instâncias adicionais do serviço de controle de lançamentos ou do serviço de consolidação de saldo sejam escaladas horizontalmente. Esse dimensionamento pode ser feito por meio de containers, como Docker, e orquestradores de containers, como Kubernetes.
Estratégias de Cache: Para otimizar a performance, o projeto pode incluir cache de dados para evitar consultas repetitivas, especialmente para o serviço de consolidação de saldo diário. Usar uma solução de cache, como Redis, ajudaria a suportar uma maior carga de trabalho sem degradação do desempenho.
# 2. Resiliência
Padrão de Arquitetura para Recuperação de Falhas: A arquitetura desacoplada permite que, se o serviço de consolidação falhar, o serviço de controle de lançamentos continue operando. Esse design resiliente reduz o impacto de falhas isoladas.
Monitoramento Proativo: Embora não implementado diretamente no código, a arquitetura permite a integração com ferramentas de monitoramento (por exemplo, Prometheus ou Azure Application Insights) para acompanhar métricas de saúde e gerar alertas.
Redundância e Failover: Em um ambiente de produção, o projeto pode incluir múltiplas instâncias dos serviços com balanceamento de carga para aumentar a resiliência. Em caso de falha, o balanceador de carga redireciona o tráfego para instâncias ativas.
# 3. Segurança
Autenticação e Autorização: O projeto pode ser facilmente expandido para incluir autenticação JWT (JSON Web Token) para verificar a identidade dos usuários e permitir somente o acesso autorizado a determinadas funcionalidades.
Proteção de Dados Sensíveis: A arquitetura suporta a implementação de criptografia para dados sensíveis. Em uma solução de produção, criptografia em repouso (no banco de dados) e em trânsito (TLS) pode ser aplicada.
Regras de Segurança para API: Usar técnicas como Rate Limiting e IP Whitelisting ajudam a proteger o sistema contra ataques de negação de serviço e acesso não autorizado.
# 4. Padrões Arquiteturais
Arquitetura Baseada em Serviços: A escolha de uma arquitetura de serviços desacoplados (Service-Oriented Architecture, ou SOA) permite que cada componente evolua e seja mantido de forma independente. Alternativamente, essa estrutura poderia ser escalada para microsserviços em um ambiente distribuído.
Padrão Repository e Service: O uso do padrão Repository separa a lógica de acesso a dados da lógica de negócios, promovendo uma arquitetura limpa e facilitando a manutenção. O padrão Service encapsula a lógica de negócio e promove reusabilidade e clareza.
# 5. Integração
Comunicação e Protocolos: A comunicação entre serviços pode ser feita por HTTP/REST, usando JSON como formato de troca de dados. Esse formato é padronizado, fácil de consumir e interoperável com outras tecnologias.
Camada de Integração para Expansão: A arquitetura permite a integração com sistemas externos, como CRMs ou ferramentas de relatórios, com o uso de APIs e padrões de integração baseados em eventos, caso necessário.
# 6. Requisitos Não-Funcionais
Desempenho e Disponibilidade: A separação de responsabilidades e a utilização de práticas como caching permitem que o sistema atenda a um alto volume de transações sem perder desempenho. O balanceamento de carga e a redundância garantem alta disponibilidade.
Confiabilidade: A aplicação foi projetada para que cada serviço funcione de forma independente, aumentando a confiabilidade em caso de falhas isoladas. A utilização de técnicas de recuperação, como retry policies e circuit breakers, pode ser adicionada para garantir ainda mais resiliência.

# Diagrama de arquitettura
![Diagrama de arquitettura](https://github.com/kcedd34/ValueControl/blob/main/projectValueControl.png)
