USE [ToDoListTracker]
GO
/****** Object:  Trigger [dbo].[UpdateAchievement]    Script Date: 10/10/2024 4:49:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TRIGGER [dbo].[UpdateAchievement] ON [dbo].[Tracker]
AFTER INSERT, Delete, Update
NOT FOR REPLICATION
AS
BEGIN
	IF OBJECT_ID(N'Achievement', 'U') IS NOT NULL

		DECLARE @result Decimal(5, 2)

		SET @result =
		(
			SELECT ISNULL(   NULLIF(
							 (
								 SELECT CASE
											WHEN SUM(t.Planned) = 0 THEN
												0.0
											ELSE
												CAST((SUM(t.Completed) / SUM(t.Planned)) * 100 AS DECIMAL(5, 2))
										END
								 FROM Tracker t
							 ), 0.0),
							 0.0
						 )
		)

		IF EXISTS (SELECT TOP 1 * FROM Achievement)
		BEGIN
			UPDATE Achievement SET Result=@result WHERE Id=1
		END
		ELSE
		BEGIN
			INSERT INTO Achievement (Result)
			VALUES (@result)
		END
END