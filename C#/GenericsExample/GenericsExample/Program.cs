
using GenericsExample;

Box<int> box=new Box<int>();
box.Content = 10;
Console.WriteLine(box.Log());

Box<string> box2 = new Box<string>();
box2.Content = "Hello";
Console.WriteLine(box2.Log());

Box<bool> box3 = new Box<bool>();
box3.Content = true;
Console.WriteLine(box3.Log());

