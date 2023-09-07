double a = double.Parse(Console.ReadLine());
Console.WriteLine("Введите сумму вклада = {0}\n", a);
double b = double.Parse(Console.ReadLine());
Console.WriteLine("Введите процент по вкладу = {0}\n", b);
double c = a + a*b/100;
Console.WriteLine("Через год сумма на вкладе = {0:N}р", c);

Console.WriteLine("Press any key to continue");