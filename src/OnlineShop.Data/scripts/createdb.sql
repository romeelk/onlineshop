CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;
CREATE TABLE "Categories" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Categories" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL,
    "Description" TEXT NULL,
    "CreatedAt" TEXT NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    "ModifiedAt" TEXT NOT NULL
);

CREATE TABLE "Products" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Products" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL,
    "Price" DECIMAL(10,2) NOT NULL,
    "Description" TEXT NULL,
    "CreatedAt" TEXT NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    "ModifiedAt" TEXT NOT NULL,
    "CategoryId" INTEGER NOT NULL,
    CONSTRAINT "FK_Products_Categories_CategoryId" FOREIGN KEY ("CategoryId") REFERENCES "Categories" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_Products_CategoryId" ON "Products" ("CategoryId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250917141619_InitialCreate', '9.0.9');

COMMIT;