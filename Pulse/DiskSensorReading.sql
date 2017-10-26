CREATE PROCEDURE [Sensors].[ReadDiskSpace]
AS
    BEGIN
        SET NOCOUNT ON;

        SELECT DISTINCT
            GETDATE() AS Timestamp
          , [Volume_Mount_Point] AS Volume
		, [Logical_Volume_Name] AS Label
          , [Total_Bytes] / (1024 * 1024 * 1024) AS TotalSpace
          , [Available_Bytes] / (1024 * 1024 * 1024) AS AvailableSpace
        FROM
            [Sys].[Master_Files] AS [F]
            CROSS APPLY [Sys].[Dm_Os_Volume_Stats]([F].[Database_Id], [F].File_Id)
        GROUP BY
            [Volume_Mount_Point]
          , [Total_Bytes]
          , [Available_Bytes]
          , [Logical_Volume_Name];
	   RETURN;
    END;
GO

