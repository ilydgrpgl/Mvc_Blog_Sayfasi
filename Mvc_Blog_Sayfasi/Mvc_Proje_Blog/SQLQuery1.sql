CREATE TRIGGER Puanlamalar
ON Comments
AFTER INSERT
AS
BEGIN
    DECLARE @BlogID INT
    DECLARE @BlogRating INT 

    SELECT @BlogID = BlogID, @BlogRating = BlogRating FROM inserted 

    UPDATE Blogs 
    SET BlogRating = (
        SELECT SUM(BlogRating) / COUNT(*) 
        FROM Comments 
        WHERE BlogID = @BlogID
    )
    WHERE BlogID = @BlogID
END

--update Blogs set BlogRating =(
--select sum(BlogRating)/(select COUNT (*) from Comments where BlogID=7)
--from Comments where BlogID=7) where BlogId=7
