ALTER DATABASE CHARACTER SET utf8mb4;


CREATE TABLE `enderecos` (
    `id` int NOT NULL AUTO_INCREMENT,
    `logradouro` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `cep` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `bairro` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `numero` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `complemento` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `cidade` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    `estado` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
    CONSTRAINT `PK_clientes` PRIMARY KEY (`id`)
) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;


CREATE TABLE `clientes` (
    `id` int NOT NULL AUTO_INCREMENT,
    `nome` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
    `observacao` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
    `endereco_id` int NOT NULL,
    CONSTRAINT `PK_clientes` PRIMARY KEY (`id`),
    CONSTRAINT `FK_clientes_enderecos_endereco_id` FOREIGN KEY (`endereco_id`) REFERENCES `enderecos` (`id`) ON DELETE CASCADE
) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;


INSERT INTO `enderecos` (`id`, `bairro`, `cep`, `cidade`, `complemento`, `estado`, `logradouro`, `numero`)
VALUES (1, 'Santa Clara', '019187-091', 'São Paulo', 'Casa 10', 'SP', 'Rua Antonia Aparecida', '345');


INSERT INTO `clientes` (`id`, `endereco_id`, `nome`, `observacao`)
VALUES (1, 1, 'Raphael', 'Pedidos devem ser entregues em determinado local');


CREATE INDEX `IX_clientes_endereco_id` ON `clientes` (`endereco_id`);


CREATE INDEX `IX_PK_enderecoid` ON `enderecos` (`id`);


