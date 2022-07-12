USE VentaGamer
GO

SELECT * FROM Facturas

SELECT MontoFinal_Fa FROM Facturas WHERE Fecha_Fa BETWEEN '2022/07/02 00:00:00' AND '2022/07/02 23:59:59'

SELECT SUM(Cantidad_DF) AS TotalProductosVendidos FROM DetalleFacturas INNER JOIN Facturas ON IdFactura_DF = IdFactura_Fa WHERE Fecha_Fa BETWEEN '2022/07/02' AND '2022/07/02'