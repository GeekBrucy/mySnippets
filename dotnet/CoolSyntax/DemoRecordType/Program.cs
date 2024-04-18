using DemoRecordType;

Dog d1 = new Dog(1, "Test");
Dog d2 = new Dog(1, "Test");

Console.WriteLine(d1.ToString()); // DemoRecordType.Dog
Console.WriteLine(d1 == d2); // return false
Console.WriteLine(d1.Equals(d2)); // return false

Console.WriteLine(new string('-', 20));
////////////////////////////////////////////////

Person p1 = new Person(1, "TTT", 18);
Person p2 = new Person(1, "TTT", 18);
Person p3 = new Person(1, "bbb", 18);

Console.WriteLine(p1.ToString()); // Person { Id = 1, Name = TTT, Age = 18 }
Console.WriteLine(p2 == p3); // return false
Console.WriteLine(p1 == p2); // return true
Console.WriteLine(ReferenceEquals(p1, p2)); // return false
Console.WriteLine(new string('-', 20));
/////////////////////////////////////////////////

Student s1 = new Student(1, "bbb");
Student s2 = new Student(1, "bbb");
s1.NickName = "Test";
s2.NickName = "Test2";
Console.WriteLine(s1 == s2); // return false
s2.NickName = "Test";
Console.WriteLine(s1 == s2); // return true
Console.WriteLine(s1.ToString()); // Student { Id = 1, Name = bbb, NickName = Test }
Console.WriteLine(new string('-', 20));
/////////////////////////////////////////////////
Cat c1 = new Cat();
c1.Name = "Test";
c1.Id = 1;
Console.WriteLine(c1); // Cat { Id = 1, Name = Test }
Console.WriteLine(new string('-', 20));
/////////////////////////////////////////////////

Person p4 = new Person(3, "ttt", 18);
Person p5 = p4;
Person p6 = new Person(p4.Id, p4.Name, p4.Age);
Console.WriteLine(ReferenceEquals(p4, p5)); // true
Console.WriteLine(ReferenceEquals(p4, p6)); // false
Person p7 = p4 with { }; // create snapshot of p4
Console.WriteLine(p7.ToString()); // Person { Id = 3, Name = ttt, Age = 18 }
Console.WriteLine(p7 == p4); // true
Console.WriteLine(Object.ReferenceEquals(p7, p4)); // false
Person p8 = p4 with { Age = 20 };