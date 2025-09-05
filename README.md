# InsuranceProposal
Sistema que valida proposta de seguros

Aplicação toda tanto em Windows quanto Linux

Possue serviço de mensageria " Kafka "

Configuração da Aplicação:

Banco de Dados SQL Server:
Scripts:
CREATE TABLE [dbo].[Insurances](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[TaxNumber] [varchar](60) NOT NULL,
	[BirthDate] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
	[Type] [int] NOT NULL,
	[InsuranceValue] [decimal](15, 2) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[CreationUserId] [bigint] NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUserId] [bigint] NULL,
	[DeletionDate] [datetime] NULL,
	[DeletionUserId] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC 
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/**********/

CREATE TABLE [dbo].ProposalHiring (
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[InsurancesId] bigint not null,
	[Name] [varchar](100) NOT NULL,
	[TaxNumber] [varchar](60) NOT NULL,
	[BirthDate] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
	[InsuranceValue] [decimal](15, 2) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[CreationUserId] [bigint] NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUserId] [bigint] NULL,
	[DeletionDate] [datetime] NULL,
	[DeletionUserId] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


Com tabelas criadas, basta fornecer as credencias de banco no AppSettings, exemplo: "InsuranceApi.con": "Server=sqlserver,1433;Database=LjSolution;TrustServerCertificate=True;"

Build:
Na compilação, escolha a opção pelo IISExpress para compilação no Windows

Na Pagina do Swagger tera todos os metódos solicitados, seguindo o processo descrito, onde se cria uma proposta e onde pode alterar o status do mesmo quando quiser

Documentação:
Enuns:
InsuranceStatus
    {
        Approved = 0,
        Rejected = 1,
        Analysis = 2
    }

InsuranceType
    {
        Life = 0,
        Vehicle = 1,
        Residence = 2
    }

ProposalHiringStatus
    {
        InProgress = 0,
        Completed = 1,
        Cancelled = 2
    }
GO

