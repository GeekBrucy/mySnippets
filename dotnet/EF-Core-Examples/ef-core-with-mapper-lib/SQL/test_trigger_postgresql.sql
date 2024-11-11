-- Create the function
CREATE OR REPLACE FUNCTION trigger_delete_if_isdeleted_true()
RETURNS TRIGGER AS $$
BEGIN
  IF NEW."IsDeleted" = TRUE THEN
    EXECUTE format('DELETE FROM %I WHERE "Id" = $1', TG_TABLE_NAME) USING NEW."Id";
  END IF;
  RETURN NEW;
END;
$$ LANGUAGE plpgsql;

-- Create triggers for each table
CREATE TRIGGER trigger_library_delete
AFTER UPDATE ON "Libraries"
FOR EACH ROW
WHEN (NEW."IsDeleted" = TRUE)
EXECUTE FUNCTION trigger_delete_if_isdeleted_true();

CREATE TRIGGER trigger_book_delete
AFTER UPDATE ON "Books"
FOR EACH ROW
WHEN (NEW."IsDeleted" = TRUE)
EXECUTE FUNCTION trigger_delete_if_isdeleted_true();

CREATE TRIGGER trigger_chapter_delete
AFTER UPDATE ON "Chapters"
FOR EACH ROW
WHEN (NEW."IsDeleted" = TRUE)
EXECUTE FUNCTION trigger_delete_if_isdeleted_true();


CREATE OR REPLACE FUNCTION prevent_delete()
RETURNS TRIGGER AS $$
BEGIN
  -- Check if the DELETE is a direct SQL execution and not part of a function or internal operation
  IF pg_trigger_depth() = 1 THEN
    RAISE EXCEPTION 'Direct DELETE statements are not allowed. Use UPDATE to set IsDeleted to TRUE instead.';
  END IF;
  RETURN OLD; -- Allow the DELETE operation for other cases
END;
$$ LANGUAGE plpgsql;


-- Apply the trigger to the Library table
CREATE TRIGGER prevent_library_delete
BEFORE DELETE ON "Libraries"
FOR EACH ROW
EXECUTE FUNCTION prevent_delete();

-- Apply the trigger to the Book table
CREATE TRIGGER prevent_book_delete
BEFORE DELETE ON "Books"
FOR EACH ROW
EXECUTE FUNCTION prevent_delete();

-- Apply the trigger to the Chapter table
CREATE TRIGGER prevent_chapter_delete
BEFORE DELETE ON "Chapters"
FOR EACH ROW
EXECUTE FUNCTION prevent_delete();
