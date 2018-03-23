
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/12/2018 13:30:34
-- Generated from EDMX file: C:\Users\Maria\Desktop\Куросовая\Cinema\Cinema\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Cinema];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CinemaSet'
CREATE TABLE [dbo].[CinemaSet] (
    [Adress] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [Deleted] bit  NOT NULL,
    [ID] smallint IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'FilmSet'
CREATE TABLE [dbo].[FilmSet] (
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Year] smallint  NOT NULL,
    [length] time  NOT NULL,
    [AgeLimit] nvarchar(max)  NOT NULL,
    [Producer] nvarchar(max)  NOT NULL,
    [ID] smallint IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'SessionSet'
CREATE TABLE [dbo].[SessionSet] (
    [Date] datetime  NOT NULL,
    [Price] smallint  NOT NULL,
    [Time] datetime  NOT NULL,
    [ID] smallint IDENTITY(1,1) NOT NULL,
    [Film_ID] smallint  NOT NULL,
    [Hall_ID] smallint  NOT NULL
);
GO

-- Creating table 'HallSet'
CREATE TABLE [dbo].[HallSet] (
    [Num] tinyint  NOT NULL,
    [Type] int  NOT NULL,
    [AmountOfRow] tinyint  NOT NULL,
    [AmountOfSeats] tinyint  NOT NULL,
    [Deleted] bit  NOT NULL,
    [ID] smallint IDENTITY(1,1) NOT NULL,
    [Cinema_ID] smallint  NOT NULL
);
GO

-- Creating table 'СashierSet'
CREATE TABLE [dbo].[СashierSet] (
    [Login] nvarchar(max)  NOT NULL,
    [FIO] nvarchar(max)  NOT NULL,
    [Password] smallint  NOT NULL,
    [ID] smallint IDENTITY(1,1) NOT NULL,
    [Cinema_ID] smallint  NOT NULL
);
GO

-- Creating table 'SeatSet'
CREATE TABLE [dbo].[SeatSet] (
    [NumberOfRow] tinyint  NOT NULL,
    [NumberOfSeat] tinyint  NOT NULL,
    [State] int  NOT NULL,
    [ID] bigint IDENTITY(1,1) NOT NULL,
    [Session_ID] smallint  NOT NULL
);
GO

-- Creating table 'TicketSet'
CREATE TABLE [dbo].[TicketSet] (
    [Number] bigint IDENTITY(1,1) NOT NULL,
    [Seat_ID] bigint  NOT NULL
);
GO

-- Creating table 'BookingSet'
CREATE TABLE [dbo].[BookingSet] (
    [Number] bigint IDENTITY(1,1) NOT NULL,
    [Seat_ID] bigint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'CinemaSet'
ALTER TABLE [dbo].[CinemaSet]
ADD CONSTRAINT [PK_CinemaSet]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'FilmSet'
ALTER TABLE [dbo].[FilmSet]
ADD CONSTRAINT [PK_FilmSet]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'SessionSet'
ALTER TABLE [dbo].[SessionSet]
ADD CONSTRAINT [PK_SessionSet]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'HallSet'
ALTER TABLE [dbo].[HallSet]
ADD CONSTRAINT [PK_HallSet]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'СashierSet'
ALTER TABLE [dbo].[СashierSet]
ADD CONSTRAINT [PK_СashierSet]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'SeatSet'
ALTER TABLE [dbo].[SeatSet]
ADD CONSTRAINT [PK_SeatSet]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Number] in table 'TicketSet'
ALTER TABLE [dbo].[TicketSet]
ADD CONSTRAINT [PK_TicketSet]
    PRIMARY KEY CLUSTERED ([Number] ASC);
GO

-- Creating primary key on [Number] in table 'BookingSet'
ALTER TABLE [dbo].[BookingSet]
ADD CONSTRAINT [PK_BookingSet]
    PRIMARY KEY CLUSTERED ([Number] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Cinema_ID] in table 'HallSet'
ALTER TABLE [dbo].[HallSet]
ADD CONSTRAINT [FK_CinemaHall]
    FOREIGN KEY ([Cinema_ID])
    REFERENCES [dbo].[CinemaSet]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CinemaHall'
CREATE INDEX [IX_FK_CinemaHall]
ON [dbo].[HallSet]
    ([Cinema_ID]);
GO

-- Creating foreign key on [Cinema_ID] in table 'СashierSet'
ALTER TABLE [dbo].[СashierSet]
ADD CONSTRAINT [FK_CinemaСashier]
    FOREIGN KEY ([Cinema_ID])
    REFERENCES [dbo].[CinemaSet]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CinemaСashier'
CREATE INDEX [IX_FK_CinemaСashier]
ON [dbo].[СashierSet]
    ([Cinema_ID]);
GO

-- Creating foreign key on [Film_ID] in table 'SessionSet'
ALTER TABLE [dbo].[SessionSet]
ADD CONSTRAINT [FK_FilmSession]
    FOREIGN KEY ([Film_ID])
    REFERENCES [dbo].[FilmSet]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FilmSession'
CREATE INDEX [IX_FK_FilmSession]
ON [dbo].[SessionSet]
    ([Film_ID]);
GO

-- Creating foreign key on [Session_ID] in table 'SeatSet'
ALTER TABLE [dbo].[SeatSet]
ADD CONSTRAINT [FK_SessionSeat]
    FOREIGN KEY ([Session_ID])
    REFERENCES [dbo].[SessionSet]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SessionSeat'
CREATE INDEX [IX_FK_SessionSeat]
ON [dbo].[SeatSet]
    ([Session_ID]);
GO

-- Creating foreign key on [Seat_ID] in table 'TicketSet'
ALTER TABLE [dbo].[TicketSet]
ADD CONSTRAINT [FK_SeatTicket]
    FOREIGN KEY ([Seat_ID])
    REFERENCES [dbo].[SeatSet]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SeatTicket'
CREATE INDEX [IX_FK_SeatTicket]
ON [dbo].[TicketSet]
    ([Seat_ID]);
GO

-- Creating foreign key on [Seat_ID] in table 'BookingSet'
ALTER TABLE [dbo].[BookingSet]
ADD CONSTRAINT [FK_SeatBooking]
    FOREIGN KEY ([Seat_ID])
    REFERENCES [dbo].[SeatSet]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SeatBooking'
CREATE INDEX [IX_FK_SeatBooking]
ON [dbo].[BookingSet]
    ([Seat_ID]);
GO

-- Creating foreign key on [Hall_ID] in table 'SessionSet'
ALTER TABLE [dbo].[SessionSet]
ADD CONSTRAINT [FK_HallSession]
    FOREIGN KEY ([Hall_ID])
    REFERENCES [dbo].[HallSet]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HallSession'
CREATE INDEX [IX_FK_HallSession]
ON [dbo].[SessionSet]
    ([Hall_ID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------