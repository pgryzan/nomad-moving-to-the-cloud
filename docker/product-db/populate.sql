USE [master]
GO
CREATE DATABASE [products]
GO
USE [products]
GO
CREATE TABLE coffees (
    id INT IDENTITY PRIMARY KEY, 
    name VARCHAR (255) NOT NULL,
    teaser VARCHAR(255) NULL,
    description TEXT NULL,
    price INT NOT NULL,
    image TEXT,
    created_at DATETIME NOT NULL, 
    updated_at DATETIME NOT NULL, 
    deleted_at DATETIME
);
CREATE TABLE ingredients (
    id INT PRIMARY KEY, 
    name VARCHAR (255) NOT NULL,  
    created_at DATETIME NOT NULL, 
    updated_at DATETIME NOT NULL, 
    deleted_at DATETIME
);
CREATE TABLE coffee_ingredients (
    id INT IDENTITY PRIMARY KEY, 
    coffee_id INT NOT NULL, 
    ingredient_id INT NOT NULL, 
    quantity INT NOT NULL, 
    unit VARCHAR (50) NOT NULL, 
    created_at DATETIME NOT NULL, 
    updated_at DATETIME NOT NULL, 
    deleted_at DATETIME,
    CONSTRAINT cunique_coffee_ingredient UNIQUE (coffee_id,ingredient_id)
);
CREATE TABLE users (
    id INT IDENTITY PRIMARY KEY, 
    username VARCHAR (255) NOT NULL UNIQUE,
    password TEXT NOT NULL,
    created_at DATETIME NOT NULL, 
    updated_at DATETIME NOT NULL, 
    deleted_at DATETIME
);
CREATE TABLE orders (
    id INT IDENTITY PRIMARY KEY, 
    user_id INT NOT NULL, 
    created_at DATETIME NOT NULL, 
    updated_at DATETIME NOT NULL, 
    deleted_at DATETIME
);
CREATE TABLE order_items (
    id INT IDENTITY PRIMARY KEY, 
    order_id INT NOT NULL, 
    coffee_id INT NOT NULL, 
    quantity INT NOT NULL, 
    created_at DATETIME NOT NULL, 
    updated_at DATETIME NOT NULL, 
    deleted_at DATETIME
);

INSERT INTO ingredients (id, name, created_at, updated_at) VALUES (1, 'Espresso', GETDATE(), GETDATE());
INSERT INTO ingredients (id, name, created_at, updated_at) VALUES (2, 'Semi Skimmed Milk', GETDATE(), GETDATE());
INSERT INTO ingredients (id, name, created_at, updated_at) VALUES (3, 'Hot Water', GETDATE(), GETDATE());
INSERT INTO ingredients (id, name, created_at, updated_at) VALUES (4, 'Pumpkin Spice', GETDATE(), GETDATE());
INSERT INTO ingredients (id, name, created_at, updated_at) VALUES (5, 'Steamed Milk', GETDATE(), GETDATE());

INSERT INTO coffees (name, teaser, description, price, image, created_at, updated_at) VALUES ('Packer Spiced Latte', 'Packed with goodness to spice up your images', '', 350, '/packer.png', GETDATE(), GETDATE());
INSERT INTO coffee_ingredients (coffee_id, ingredient_id, quantity, unit, created_at, updated_at) VALUES (1,1, 40, 'ml', GETDATE(), GETDATE());
INSERT INTO coffee_ingredients (coffee_id, ingredient_id, quantity, unit, created_at, updated_at) VALUES (1,2, 300, 'ml', GETDATE(), GETDATE());
INSERT INTO coffee_ingredients (coffee_id, ingredient_id, quantity, unit, created_at, updated_at) VALUES (1,4, 5, 'g', GETDATE(), GETDATE());

INSERT INTO coffees (name, teaser, description, price, image, created_at, updated_at) VALUES ('Vaulatte', 'Nothing gives you a safe and secure feeling like a Vaulatte', '', 200, '/vault.png', GETDATE(), GETDATE());
INSERT INTO coffee_ingredients (coffee_id, ingredient_id, quantity, unit, created_at, updated_at) VALUES (2,1, 40, 'ml', GETDATE(), GETDATE());
INSERT INTO coffee_ingredients (coffee_id, ingredient_id, quantity, unit, created_at, updated_at) VALUES (2,2, 300, 'ml', GETDATE(), GETDATE());

INSERT INTO coffees (name, teaser, description, price, image, created_at, updated_at) VALUES ('Nomadicano', 'Drink one today and you will want to schedule another', '', 150, '/nomad.png', GETDATE(), GETDATE());
INSERT INTO coffee_ingredients (coffee_id, ingredient_id, quantity, unit, created_at, updated_at) VALUES (3,1, 20, 'ml', GETDATE(), GETDATE());
INSERT INTO coffee_ingredients (coffee_id, ingredient_id, quantity, unit, created_at, updated_at) VALUES (3,3, 100, 'ml', GETDATE(), GETDATE());

INSERT INTO coffees (name, teaser, description, price, image, created_at, updated_at) VALUES ('Terraspresso', 'Nothing kickstarts your day like a provision of Terraspresso', '', 150, '/terraform.png', GETDATE(), GETDATE());
INSERT INTO coffee_ingredients (coffee_id, ingredient_id, quantity, unit, created_at, updated_at) VALUES (4,1, 20, 'ml', GETDATE(), GETDATE());

INSERT INTO coffees (name, teaser, description, price, image, created_at, updated_at) VALUES ('Vagrante espresso', 'Stdin is not a tty', '', 200, '/vagrant.png', GETDATE(), GETDATE());
INSERT INTO coffee_ingredients (coffee_id, ingredient_id, quantity, unit, created_at, updated_at) VALUES (5,1, 40, 'ml', GETDATE(), GETDATE());

INSERT INTO coffees (name, teaser, description, price, image, created_at, updated_at) VALUES ('Connectaccino', 'Discover the wonders of our meshy service', '', 250, '/consul.png', GETDATE(), GETDATE());
INSERT INTO coffee_ingredients (coffee_id, ingredient_id, quantity, unit, created_at, updated_at) VALUES (6,1, 40, 'ml', GETDATE(), GETDATE());
INSERT INTO coffee_ingredients (coffee_id, ingredient_id, quantity, unit, created_at, updated_at) VALUES (6,5, 300, 'ml', GETDATE(), GETDATE());