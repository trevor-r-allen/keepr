-- CREATE TABLE profiles
-- (
-- id VARCHAR(255) NOT NULL,
-- name VARCHAR(255),
-- email VARCHAR(255) NOT NULL,
-- picture VARCHAR(255),

-- PRIMARY KEY (id)
-- );

-- CREATE TABLE keeps
-- (
--   id INT NOT NULL AUTO_INCREMENT,
--   creatorId VARCHAR(255) NOT NULL,
--   name VARCHAR(255) NOT NULL,
--   description VARCHAR(255) NOT NULL,
--   img VARCHAR(255) NOT NULL,
--   views INT DEFAULT 0,
--   Shares INT DEFAULT 0,
--   keeps INT DEFAULT 0,

--   PRIMARY KEY (id),

--   FOREIGN KEY (creatorId)
--     REFERENCES profiles (id)
--     ON DELETE CASCADE
-- );

-- CREATE TABLE vaults
-- (
--   id INT NOT NULL AUTO_INCREMENT,
--   creatorId VARCHAR(255) NOT NULL,
--   name VARCHAR(255) NOT NULL,
--   description VARCHAR(255) NOT NULL,
--   isPrivate TINYINT NOT NULL DEFAULT 0,

--   PRIMARY KEY (id),

--   FOREIGN KEY (creatorId)
--     REFERENCES profiles (id)
--     ON DELETE CASCADE
-- )

