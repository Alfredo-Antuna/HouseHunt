CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (

    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,

    "ProductVersion" TEXT NOT NULL

);
CREATE TABLE IF NOT EXISTS "Owners" (

    "Id" TEXT NOT NULL CONSTRAINT "PK_Owners" PRIMARY KEY,

    "Name" TEXT NULL

);
CREATE TABLE IF NOT EXISTS "Propertys" (

    "Id" TEXT NOT NULL CONSTRAINT "PK_Propertys" PRIMARY KEY,

    "OwnerId" TEXT NULL,

    "Name" TEXT NULL,

    "City" TEXT NULL,

    "State" TEXT NULL,

    "Zipcode" INTEGER NOT NULL,

    CONSTRAINT "FK_Propertys_Owners_OwnerId" FOREIGN KEY ("OwnerId") REFERENCES "Owners" ("Id") ON DELETE RESTRICT

);
CREATE TABLE IF NOT EXISTS "Reservations" (

    "Id" TEXT NOT NULL CONSTRAINT "PK_Reservations" PRIMARY KEY,

    "PropertyId" TEXT NULL,

    "StartDate" TEXT NOT NULL,

    "EndDate" TEXT NOT NULL,

    CONSTRAINT "FK_Reservations_Propertys_PropertyId" FOREIGN KEY ("PropertyId") REFERENCES "Propertys" ("Id") ON DELETE RESTRICT

);
CREATE INDEX "IX_Propertys_OwnerId" ON "Propertys" ("OwnerId");
CREATE INDEX "IX_Reservations_PropertyId" ON "Reservations" ("PropertyId");
