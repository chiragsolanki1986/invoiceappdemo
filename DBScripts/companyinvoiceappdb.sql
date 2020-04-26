CREATE TABLE [Companies] (
    [CompanyCode] nvarchar(450) NOT NULL,
    [CompanyName] nvarchar(30) NOT NULL,
    [AddressLine1] nvarchar(max) NOT NULL,
    [AddressLine2] nvarchar(max) NULL,
    [AddressLine3] nvarchar(max) NULL,
    [ZipCode] nvarchar(max) NULL,
    [ContactEmailId] nvarchar(max) NULL,
    CONSTRAINT [PK_Companies] PRIMARY KEY ([CompanyCode])
);
GO


CREATE TABLE [Invoices] (
    [Id] uniqueidentifier NOT NULL,
    [CompanyCode] nvarchar(450) NULL,
    [InvoiceNumber] nvarchar(max) NULL,
    [InvoiceDate] datetime2 NOT NULL,
    [Remarks] nvarchar(max) NULL,
    [Discount] float NOT NULL,
    [TaxRate] float NOT NULL,
    [ShippingCharges] float NOT NULL,
    [SubTotal] float NOT NULL,
    [SubTotalLessDiscount] float NOT NULL,
    [TotalTax] float NOT NULL,
    [BalanceDue] float NOT NULL,
    CONSTRAINT [PK_Invoices] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Invoices_Companies_CompanyCode] FOREIGN KEY ([CompanyCode]) REFERENCES [Companies] ([CompanyCode]) ON DELETE NO ACTION
);
GO


CREATE TABLE [CustomerDetails] (
    [Id] uniqueidentifier NOT NULL,
    [InvoiceId] uniqueidentifier NOT NULL,
    [CustomerContactName] nvarchar(max) NULL,
    [CustomerCompanyName] nvarchar(max) NULL,
    [CustomerAddress] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [CustomerEmail] nvarchar(max) NULL,
    [CompanyCode] nvarchar(450) NULL,
    CONSTRAINT [PK_CustomerDetails] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_CustomerDetails_Companies_CompanyCode] FOREIGN KEY ([CompanyCode]) REFERENCES [Companies] ([CompanyCode]) ON DELETE NO ACTION,
    CONSTRAINT [FK_CustomerDetails_Invoices_InvoiceId] FOREIGN KEY ([InvoiceId]) REFERENCES [Invoices] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [InvoiceLineITem] (
    [Id] uniqueidentifier NOT NULL,
    [InvoiceId] uniqueidentifier NOT NULL,
    [Desccription] nvarchar(max) NULL,
    [Quantity] int NOT NULL,
    [UnitPrice] float NOT NULL,
    [Total] float NOT NULL,
    CONSTRAINT [PK_InvoiceLineITem] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_InvoiceLineITem_Invoices_InvoiceId] FOREIGN KEY ([InvoiceId]) REFERENCES [Invoices] ([Id]) ON DELETE CASCADE
);
GO


CREATE TABLE [ShippingDetails] (
    [Id] uniqueidentifier NOT NULL,
    [InvoiceId] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NULL,
    [ShipCompanyName] nvarchar(max) NULL,
    [ShippingAddress] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    CONSTRAINT [PK_ShippingDetails] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ShippingDetails_Invoices_InvoiceId] FOREIGN KEY ([InvoiceId]) REFERENCES [Invoices] ([Id]) ON DELETE CASCADE
);
GO


CREATE INDEX [IX_CustomerDetails_CompanyCode] ON [CustomerDetails] ([CompanyCode]);
GO


CREATE UNIQUE INDEX [IX_CustomerDetails_InvoiceId] ON [CustomerDetails] ([InvoiceId]);
GO


CREATE INDEX [IX_InvoiceLineITem_InvoiceId] ON [InvoiceLineITem] ([InvoiceId]);
GO


CREATE INDEX [IX_Invoices_CompanyCode] ON [Invoices] ([CompanyCode]);
GO


CREATE UNIQUE INDEX [IX_ShippingDetails_InvoiceId] ON [ShippingDetails] ([InvoiceId]);
GO


