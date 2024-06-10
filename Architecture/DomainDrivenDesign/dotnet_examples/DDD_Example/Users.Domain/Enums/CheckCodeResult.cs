namespace Users.Domain.Enums;

public enum CheckCodeResult
{
  Ok,
  PhoneNumberNotFound,
  Lockout,
  CodeError
}
