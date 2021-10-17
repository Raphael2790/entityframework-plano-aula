ALTER DATABASE CHARACTER SET utf8mb4;


CREATE TABLE `Categoria` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Descricao` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
    CONSTRAINT `PK_Categoria` PRIMARY KEY (`Id`)
) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;


CREATE TABLE `produtos` (
    `id` int NOT NULL AUTO_INCREMENT,
    `nome` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `url_imagem` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
    `descricao` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
    `valor` double NOT NULL,
    `CategoriaId` int NULL,
    CONSTRAINT `PK_produtos` PRIMARY KEY (`id`),
    CONSTRAINT `FK_produtos_Categoria_CategoriaId` FOREIGN KEY (`CategoriaId`) REFERENCES `Categoria` (`Id`) ON DELETE RESTRICT
) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;


CREATE INDEX `IX_produtos_CategoriaId` ON `produtos` (`CategoriaId`);


