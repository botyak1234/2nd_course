using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApp1
{

    class Program
    {
        static void Print(List<Client> clients)
        {
            if (clients.Count == 0)
            {
                Console.WriteLine("Список объектов пуст.");
            }
            else
            {
                Console.WriteLine("Список объектов:");
                foreach (Client client in clients)
                {
                    Console.WriteLine(client.ToString());
                }
            }
        }


        //    static List<Client> ReadClientsFromFile(string fileIn)
        //{
        //    using (StreamReader In = new StreamReader(fileIn))
        //    {
        //        try
        //        {
        //            var clientsList = new List<Client>();

        //            using (StreamReader reader = new StreamReader(fileIn))
        //            {
        //                string line;
        //                while ((line = reader.ReadLine()) != null)
        //                {

        //                    string[] data = line.Split(',');


        //                    switch (data[0])
        //                    {
        //                        case nameof(Depositor):
        //                            clientsList.Add(new Depositor(

        //                                data[1],
        //                                DateTime.Parse(data[2]),
        //                                double.Parse(data[3]),
        //                                double.Parse(data[4]))
        //                            );
        //                            break;
        //                        case nameof(Creditor):
        //                            clientsList.Add(new Creditor
        //                            (
        //                                data[1],
        //                                DateTime.Parse(data[2]),
        //                                double.Parse(data[3]),
        //                                double.Parse(data[4]),
        //                                double.Parse(data[5])
        //                            ));
        //                            break;
        //                        case nameof(Organization):
        //                            clientsList.Add(new Organization
        //                            (
        //                                data[1],
        //                                DateTime.Parse(data[2]),
        //                                data[3],
        //                                double.Parse(data[4])
        //                            ));
        //                            break;
        //                        default:

        //                            break;
        //                    }
        //                }
        //            }

        //            return clientsList;
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine($"Не удалось прочитать файл: {ex.Message}");
        //            return null;
        //        }
        //    }
        //}


        static void Main()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            string fileIn = "C:\\Users\\Пользователь\\source\\repos\\help\\help\\help_in.txt";
            string fileOut = "C:\\Users\\Пользователь\\source\\repos\\help\\help\\help_out.txt";
            
                List<Client> clients = new List<Client>{ };
                
               
                
                using (FileStream f = new FileStream("C:\\Users\\Пользователь\\source\\repos\\help\\help\\help_in.dat",
                FileMode.OpenOrCreate))
                {
                    if (f.Length != 0)
                    {
                        clients = (List<Client>)formatter.Deserialize(f);
                    }
                }


                clients.Add(new Organization("HELP", DateTime.Parse("2023-01-10"), "0", 0));
            clients.Add(new Creditor("Smith", DateTime.Parse("2023-01-5"), 0, 0, 0));
                if (clients.Count== 0)
                {
                    Console.WriteLine("Список пуст");
                }
                else 
                { 
                    
                    Console.WriteLine("Полная информация");
                     Print(clients);


                     DateTime targetDate = new DateTime(2023, 2, 1);
                    Console.WriteLine($"Клиенты с {targetDate}:");
                    foreach (Client client in clients)
                    {
                        if (client.IsMatch(targetDate))
                        {
                            Console.WriteLine(client.ToString());
                        }
                    }

                    clients.Sort();
                    Console.WriteLine("Отсортированная информация");
                    foreach (Client client in clients)
                    {
                        Console.WriteLine(client.ToString());
                    }
                    using (FileStream f = new FileStream("C:\\Users\\Пользователь\\source\\repos\\help\\help\\help_in.dat",
                FileMode.OpenOrCreate))
                    {
                        formatter.Serialize(f, clients);
                    }
                }
        }
    }
}




