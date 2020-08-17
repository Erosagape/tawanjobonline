CREATE FUNCTION [dbo].[GetDataSplit](@data nvarchar(MAX),@split nvarchar(max),@idx integer)
RETURNS  nvarchar(MAX)
AS
BEGIN
DECLARE @findidx as integer= CHARINDEX(@split,@data);
DECLARE @findstr as nvarchar(MAX);

IF (@findidx<=0 )
BEGIN
	SET @data=@data +@split;
	SET @findidx= CHARINDEX(@split,@data);
END

BEGIN
	IF (@idx=0) 
	BEGIN
		SET @findstr=SUBSTRING(@data,1,@findidx-1);
	END
	ELSE
	BEGIN
		SET @findstr=SUBSTRING(@data,@findidx+1,LEN(@data));
	END
END
RETURN @findstr;
END
GO


