CREATE TABLE [Clientes] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] nvarchar(100) NOT NULL,
    [Email] nvarchar(150) NOT NULL,
    [Direccion] nvarchar(200) NOT NULL,
    CONSTRAINT [PK_Clientes] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Productos] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] nvarchar(100) NOT NULL,
    [Descripcion] nvarchar(500) NOT NULL,
    [Precio] decimal(18,2) NOT NULL,
    [Stock] int NOT NULL,
    CONSTRAINT [PK_Productos] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Usuarios] (
    [Id] int NOT NULL IDENTITY,
    [Email] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [NombreCompleto] nvarchar(max) NOT NULL,
    [Rol] nvarchar(max) NOT NULL,
    [Activo] bit NOT NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Pedidos] (
    [Id] int NOT NULL IDENTITY,
    [FechaPedido] datetime2 NOT NULL,
    [IdCliente] int NOT NULL,
    [Estado] nvarchar(max) NOT NULL,
    [MontoTotal] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_Pedidos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Pedidos_Clientes_IdCliente] FOREIGN KEY ([IdCliente]) REFERENCES [Clientes] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [DetallePedidos] (
    [Id] int NOT NULL IDENTITY,
    [IdPedido] int NOT NULL,
    [IdProducto] int NOT NULL,
    [Cantidad] int NOT NULL,
    [PrecioUnitario] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_DetallePedidos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_DetallePedidos_Pedidos_IdPedido] FOREIGN KEY ([IdPedido]) REFERENCES [Pedidos] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_DetallePedidos_Productos_IdProducto] FOREIGN KEY ([IdProducto]) REFERENCES [Productos] ([Id]) ON DELETE CASCADE
);
GO


IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Activo', N'Email', N'NombreCompleto', N'Password', N'Rol') AND [object_id] = OBJECT_ID(N'[Usuarios]'))
    SET IDENTITY_INSERT [Usuarios] ON;
INSERT INTO [Usuarios] ([Id], [Activo], [Email], [NombreCompleto], [Password], [Rol])
VALUES (1, CAST(1 AS bit), N'admin@artesanias.com', N'Administrador del Sistema', N'AQAAAAIAAYagAAAAEKX8/3F5vGJBqVfJ4xMQqZN3KzJLR1YMh3XnQpH4vZK9T7wP8qW5xN2jL3kV6mE9wA==', N'Administrador'),
(2, CAST(1 AS bit), N'usuario@artesanias.com', N'Usuario de Prueba', N'AQAAAAIAAYagAAAAEGN5wR8tY3mL4zP9sVxN2jK1hW6oD5qT8eR7yU3iO4pA6sB9cM1fX2gV5nH7kJ8lZ0==', N'Usuario');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Activo', N'Email', N'NombreCompleto', N'Password', N'Rol') AND [object_id] = OBJECT_ID(N'[Usuarios]'))
    SET IDENTITY_INSERT [Usuarios] OFF;
GO


CREATE INDEX [IX_DetallePedidos_IdPedido] ON [DetallePedidos] ([IdPedido]);
GO


CREATE INDEX [IX_DetallePedidos_IdProducto] ON [DetallePedidos] ([IdProducto]);
GO


CREATE INDEX [IX_Pedidos_IdCliente] ON [Pedidos] ([IdCliente]);
GO


