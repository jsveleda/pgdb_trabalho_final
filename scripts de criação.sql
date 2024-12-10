DROP DATABASE IF EXISTS RUCalendarDB;
CREATE DATABASE RUCalendarDB;
USE RUCalendarDB;

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

-- Inserção de exemplo: Usuário administrador
INSERT INTO users (user_code, password_hash, full_name, email, is_admin) 
VALUES (1, SHA2('1', 256), 'System Administrator', 'admin@example.com', 1);

-- UPDATE users SET password_hash = SHA2('12345', 256) WHERE user_code = 12345;

INSERT INTO users (user_code, password_hash, full_name, email, is_admin) 
VALUES (2, SHA2('2', 256), 'Regular User', 'user@example.com', 0);

CREATE TABLE menus (
    menu_id INT AUTO_INCREMENT PRIMARY KEY,  -- Identificador único do cardápio
    menu_date DATE NOT NULL,                 -- Data do cardápio
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP -- Registro da data de criação
);

CREATE TABLE meals (
    meal_id INT AUTO_INCREMENT PRIMARY KEY,  -- Identificador único da refeição
    menu_id INT NOT NULL,                    -- ID do cardápio (chave estrangeira)
    meal_type ENUM('Breakfast', 'Lunch', 'Dinner') NOT NULL, -- Tipo de refeição
    FOREIGN KEY (menu_id) REFERENCES menus(menu_id) ON DELETE CASCADE
);

CREATE TABLE ingredients (
    ingredient_id INT AUTO_INCREMENT PRIMARY KEY, -- Identificador único do ingrediente
    meal_id INT NOT NULL,                         -- ID da refeição (chave estrangeira)
    ingredient_name VARCHAR(100) NOT NULL,        -- Nome do ingrediente
    FOREIGN KEY (meal_id) REFERENCES meals(meal_id) ON DELETE CASCADE
);

INSERT INTO menus (menu_date) VALUES ('2024-12-10');
SELECT LAST_INSERT_ID() AS menu_id;

INSERT INTO meals (menu_id, meal_type) VALUES 
(1, 'Breakfast'),
(1, 'Lunch'),
(1, 'Dinner');

INSERT INTO ingredients (meal_id, ingredient_name) VALUES 
(1, 'Coffee'),
(1, 'Milk'),
(1, 'Bread'),
(1, 'Butter'),
(1, 'Cheese'),
(2, 'Rice'),
(2, 'Beans'),
(2, 'Chicken'),
(2, 'Salad'),
(2, 'Juice'),
(3, 'Soup'),
(3, 'Bread'),
(3, 'Cheese'),
(3, 'Butter'),
(3, 'Milk');

SELECT m.menu_date, ml.meal_type, i.ingredient_name
FROM menus m
JOIN meals ml ON m.menu_id = ml.menu_id
JOIN ingredients i ON ml.meal_id = i.meal_id
WHERE m.menu_date = '2024-12-10'
ORDER BY ml.meal_type, i.ingredient_name;

SELECT i.ingredient_name
FROM meals ml
JOIN ingredients i ON ml.meal_id = i.meal_id
WHERE ml.meal_type = 'Lunch' AND ml.menu_id = 1;

