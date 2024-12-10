DROP DATABASE IF EXISTS RUCalendarDB;
CREATE DATABASE RUCalendarDB;
USE RUCalendarDB;

-- Criação da tabela de usuários
CREATE TABLE users (
    user_id INT AUTO_INCREMENT PRIMARY KEY,  -- Identificador único do usuário
    user_code INT NOT NULL UNIQUE,           -- Código numérico do usuário (somente números)
    password_hash VARCHAR(255) NOT NULL,     -- Hash da senha para segurança
    full_name VARCHAR(100) NOT NULL,         -- Nome completo do usuário
    email VARCHAR(100) UNIQUE,               -- E-mail opcional, mas único se informado
    is_admin BOOLEAN NOT NULL DEFAULT 0,     -- Indica se é administrador (1 para sim, 0 para não)
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,  -- Data de criação do registro
    last_login TIMESTAMP NULL                -- Data do último login (opcional)
);

-- Inserção de usuários de exemplo
INSERT INTO users (user_code, password_hash, full_name, email, is_admin) 
VALUES (1, SHA2('1', 256), 'System Administrator', 'admin@example.com', 1);
INSERT INTO users (user_code, password_hash, full_name, email, is_admin) 
VALUES (2, SHA2('2', 256), 'Regular User', 'user@example.com', 0);

-- Criação da tabela de menus
CREATE TABLE menus (
    menu_id INT AUTO_INCREMENT PRIMARY KEY,  -- Identificador único do cardápio
    menu_date DATE NOT NULL,                 -- Data do cardápio
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP -- Registro da data de criação
);

-- Criação da tabela de refeições
CREATE TABLE meals (
    meal_id INT AUTO_INCREMENT PRIMARY KEY,  -- Identificador único da refeição
    menu_id INT NOT NULL,                    -- ID do cardápio (chave estrangeira)
    meal_type ENUM('Café da manhã', 'Almoço', 'Jantar') NOT NULL, -- Tipo de refeição
    FOREIGN KEY (menu_id) REFERENCES menus(menu_id) ON DELETE CASCADE
);

-- Criação da tabela de ingredientes
CREATE TABLE ingredients (
    ingredient_id INT AUTO_INCREMENT PRIMARY KEY, -- Identificador único do ingrediente
    meal_id INT NOT NULL,                         -- ID da refeição (chave estrangeira)
    ingredient_name VARCHAR(100) NOT NULL,        -- Nome do ingrediente
    FOREIGN KEY (meal_id) REFERENCES meals(meal_id) ON DELETE CASCADE
);

-- Inserção dos menus
INSERT INTO menus (menu_date) VALUES 
('2024-12-10'),
('2024-12-11'),
('2024-12-12'),
('2024-12-13'),
('2024-12-14'),
('2024-12-15'),
('2024-12-16');

-- Inserção das refeições para cada menu
INSERT INTO meals (menu_id, meal_type) VALUES 
(1, 'Café da manhã'), (1, 'Almoço'), (1, 'Jantar'),
(2, 'Café da manhã'), (2, 'Almoço'), (2, 'Jantar'),
(3, 'Café da manhã'), (3, 'Almoço'), (3, 'Jantar'),
(4, 'Café da manhã'), (4, 'Almoço'), (4, 'Jantar'),
(5, 'Café da manhã'), (5, 'Almoço'), (5, 'Jantar'),
(6, 'Café da manhã'), (6, 'Almoço'), (6, 'Jantar'),
(7, 'Café da manhã'), (7, 'Almoço'), (7, 'Jantar');

-- Inserção dos ingredientes para cada refeição
-- Para o menu de 2024-12-10 (menu_id = 1)
INSERT INTO ingredients (meal_id, ingredient_name) VALUES 
(1, 'Café'), (1, 'Leite'), (1, 'Pão'), (1, 'Manteiga'), (1, 'Queijo'),
(2, 'Arroz'), (2, 'Feijão'), (2, 'Frango'), (2, 'Salada'), (2, 'Suco'),
(3, 'Sopa'), (3, 'Pão'), (3, 'Queijo'), (3, 'Manteiga'), (3, 'Leite');

-- Para o menu de 2024-12-11 (menu_id = 2)
INSERT INTO ingredients (meal_id, ingredient_name) VALUES 
(4, 'Café'), (4, 'Leite'), (4, 'Pão'), (4, 'Manteiga'), (4, 'Queijo'),
(5, 'Arroz'), (5, 'Feijão'), (5, 'Frango'), (5, 'Salada'), (5, 'Suco'),
(6, 'Sopa'), (6, 'Pão'), (6, 'Queijo'), (6, 'Manteiga'), (6, 'Leite');

-- Para o menu de 2024-12-12 (menu_id = 3)
INSERT INTO ingredients (meal_id, ingredient_name) VALUES 
(7, 'Café'), (7, 'Leite'), (7, 'Pão'), (7, 'Manteiga'), (7, 'Queijo'),
(8, 'Arroz'), (8, 'Feijão'), (8, 'Peixe'), (8, 'Legumes'), (8, 'Chá'),
(9, 'Ensopado'), (9, 'Pão'), (9, 'Queijo'), (9, 'Manteiga'), (9, 'Suco');

-- Para o menu de 2024-12-13 (menu_id = 4)
INSERT INTO ingredients (meal_id, ingredient_name) VALUES 
(10, 'Chá'), (10, 'Leite'), (10, 'Bolo'), (10, 'Manteiga'), (10, 'Geléia'),
(11, 'Macarrão'), (11, 'Molho de Tomate'), (11, 'Carne de Boi'), (11, 'Legumes'), (11, 'Suco'),
(12, 'Pizza'), (12, 'Palitinhos de Pão'), (12, 'Queijo'), (12, 'Manteiga'), (12, 'Sorvete');

-- Ingredientes para o menu de 2024-12-14 (menu_id = 5)
INSERT INTO ingredients (meal_id, ingredient_name) VALUES 
(13, 'Café'), (13, 'Leite'), (13, 'Pão'), (13, 'Manteiga'), (13, 'Queijo'),
(14, 'Arroz'), (14, 'Feijão'), (14, 'Frango'), (14, 'Salada'), (14, 'Suco'),
(15, 'Sopa'), (15, 'Pão'), (15, 'Queijo'), (15, 'Manteiga'), (15, 'Leite');

-- Ingredientes para o menu de 2024-12-15 (menu_id = 6)
INSERT INTO ingredients (meal_id, ingredient_name) VALUES 
(16, 'Café'), (16, 'Leite'), (16, 'Pão'), (16, 'Manteiga'), (16, 'Queijo'),
(17, 'Arroz'), (17, 'Feijão'), (17, 'Peixe'), (17, 'Salada'), (17, 'Chá'),
(18, 'Ensopado'), (18, 'Pão'), (18, 'Queijo'), (18, 'Manteiga'), (18, 'Suco');

-- Ingredientes para o menu de 2024-12-16 (menu_id = 7)
INSERT INTO ingredients (meal_id, ingredient_name) VALUES 
(19, 'Chá'), (19, 'Leite'), (19, 'Bolo'), (19, 'Manteiga'), (19, 'Geléia'),
(20, 'Macarrão'), (20, 'Molho de Tomate'), (20, 'Carne de Boi'), (20, 'Legumes'), (20, 'Suco'),
(21, 'Pizza'), (21, 'Palitinhos de Pão'), (21, 'Queijo'), (21, 'Manteiga'), (21, 'Sorvete');

CREATE USER 'admin_user'@'localhost' IDENTIFIED BY 'password123';

GRANT INSERT ON RUCalendarDB.users TO 'admin_user'@'localhost';
GRANT INSERT ON RUCalendarDB.menus TO 'admin_user'@'localhost';
GRANT INSERT ON RUCalendarDB.meals TO 'admin_user'@'localhost';
GRANT INSERT ON RUCalendarDB.ingredients TO 'admin_user'@'localhost';

-- Revogar permissões adicionais para garantir que o usuário só possa inserir
REVOKE SELECT, UPDATE, DELETE ON RUCalendarDB.* FROM 'admin_user'@'localhost';
FLUSH PRIVILEGES;



