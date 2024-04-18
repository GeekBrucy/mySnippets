using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoRecordType;

public record Student(int Id, string Name)
{
  public string NickName { get; set; }

  public Student(int id, string name, string nickName) : this(id, name)
  {
    NickName = nickName;
  }
}
