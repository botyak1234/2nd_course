int a = int.Parse(Console.ReadLine());
Console.WriteLine("Номинал купюры = {0}\n", a);
int b = int.Parse(Console.ReadLine());
Console.WriteLine("Количество купюр = {0}\n", b);
double c = a*b;
Console.WriteLine("Сумма денег = {0:N}", c);

Console.WriteLine("Press any key to continue");
