CREATE TABLE IF NOT EXISTS accounts (
    id VARCHAR(255) NOT NULL PRIMARY KEY COMMENT 'primary key',
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name VARCHAR(255) COMMENT 'User Name',
    email VARCHAR(255) UNIQUE COMMENT 'User Email',
    picture VARCHAR(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';

CREATE TABLE recipes (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    title VARCHAR(255),
    instructions VARCHAR(1000),
    img VARCHAR(1000) NOT NULL,
    category ENUM(
        'Breakfast',
        'Lunch',
        'Dinner',
        'Dessert',
        'Snack'
    ) NOT NULL,
    creator_id VARCHAR(255) NOT NULL,
    FOREIGN KEY (creator_id) REFERENCES accounts (id) ON DELETE CASCADE
)

CREATE TABLE ingredients (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name VARCHAR(255) NOT NULL,
    quantity VARCHAR(100) NOT NULL,
    recipe_id INT NOT NULL,
    FOREIGN KEY (recipe_id) REFERENCES recipes (id) ON DELETE CASCADE
)

DROP TABLE recipes;

INSERT INTO
    ingredients (name, quantity, recipe_id)
VALUES ('Spaghetti', '200g', 2);

INSERT INTO
    recipes (
        creator_id,
        title,
        instructions,
        img,
        category
    )
VALUES (
        '68c3475a4b1978145b8fda91',
        'Spaghetti Carbonara',
        '1. Cook spaghetti. 2. Fry pancetta. 3. Mix eggs and cheese. 4. Combine all with pepper.',
        'https://images.unsplash.com/photo-1551892374-ecf8754cf8b0?ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8c3BhZ2hldHRpfGVufDB8fDB8fHww&auto=format&fit=crop&q=60&w=900',
        'Dinner'
    );

SELECT recipes.*, accounts.*
FROM recipes
    JOIN accounts ON recipes.creator_id = accounts.id
WHERE
    recipes.id = 2;

SELECT recipes.*, ingredients.*
FROM recipes
    JOIN ingredients ON recipes.id = ingredients.recipe_id
WHERE
    recipes.id = 2;