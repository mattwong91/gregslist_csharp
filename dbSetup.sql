CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS houses(
        id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
        bedrooms INT NOT NULL,
        bathrooms INT NOT NULL,
        price INT NOT NULL,
        description VARCHAR(500)
    )

INSERT INTO
    houses(
        bedrooms,
        bathrooms,
        price,
        description
    )
VALUES (
        3,
        2,
        635000,
        "Old house in Livermore"
    );

INSERT INTO
    houses(
        bedrooms,
        bathrooms,
        price,
        description
    )
VALUES (5, 4, 849000, "Eagle house");

SELECT * FROM houses;