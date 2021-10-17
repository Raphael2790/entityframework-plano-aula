ALTER DATABASE CHARACTER SET utf8mb4;


CREATE TABLE `Categorias` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Descricao` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
    CONSTRAINT `PK_Categorias` PRIMARY KEY (`Id`)
) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;


CREATE TABLE `Enderecos` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Logradouro` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
    `Cep` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
    `Bairro` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
    `Numero` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
    `Complemento` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
    `Cidade` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
    `Estado` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
    CONSTRAINT `PK_Enderecos` PRIMARY KEY (`Id`)
) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;


CREATE TABLE `Fornecedores` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Nome` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
    `DocumentoIdentificacao` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
    `TipoFornecedor` int NOT NULL,
    `Ativo` tinyint(1) NOT NULL,
    `EnderecoId` int NULL,
    CONSTRAINT `PK_Fornecedores` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Fornecedores_Enderecos_EnderecoId` FOREIGN KEY (`EnderecoId`) REFERENCES `Enderecos` (`Id`) ON DELETE RESTRICT
) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;


CREATE TABLE `produtos` (
    `id` int NOT NULL AUTO_INCREMENT,
    `nome` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `url_imagem` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
    `descricao` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
    `valor` double NOT NULL,
    `CategoriaId` int NULL,
    `FornecedorId` int NULL,
    CONSTRAINT `PK_produtos` PRIMARY KEY (`id`),
    CONSTRAINT `FK_produtos_Categorias_CategoriaId` FOREIGN KEY (`CategoriaId`) REFERENCES `Categorias` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_produtos_Fornecedores_FornecedorId` FOREIGN KEY (`FornecedorId`) REFERENCES `Fornecedores` (`Id`) ON DELETE RESTRICT
) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;


CREATE INDEX `IX_Fornecedores_EnderecoId` ON `Fornecedores` (`EnderecoId`);


CREATE INDEX `IX_produtos_CategoriaId` ON `produtos` (`CategoriaId`);


CREATE INDEX `IX_produtos_FornecedorId` ON `produtos` (`FornecedorId`);


