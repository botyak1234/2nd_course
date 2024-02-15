using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
namespace ConsoleApp1
{
    
    class Program
    {
        //BinaryFormatter formatter = new BinaryFormatter();

        static Client[] ReadClientsFromFile(string fileIn)
        {
            using (StreamReader In = new StreamReader(fileIn))
            {
                try
                {
                    var clientsList = new List<Client>();

                    using (StreamReader reader = new StreamReader(fileIn))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {

                            string[] data = line.Split(',');


                            switch (data[0])
                            {
                                case nameof(Depositor):
                                    clientsList.Add(new Depositor(

                                        data[1],
                                        DateTime.Parse(data[2]),
                                        double.Parse(data[3]),
                                        double.Parse(data[4]))
                                    );
                                    break;
                                case nameof(Creditor):
                                    clientsList.Add(new Creditor
                                    (
                                        data[1],
                                        DateTime.Parse(data[2]),
                                        double.Parse(data[3]),
                                        double.Parse(data[4]),
                                        double.Parse(data[5])
                                    ));
                                    break;
                                case nameof(Organization):
                                    clientsList.Add(new Organization
                                    (
                                        data[1],
                                        DateTime.Parse(data[2]),
                                        data[3],
                                        double.Parse(data[4])
                                    ));
                                    break;
                                default:
                                    Console.WriteLine($"Неизвестный клиент: {data[0]}");
                                    break;
                            }
                        }
                    }

                    return clientsList.ToArray();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Не удалось прочитать файл: {ex.Message}");
                    return null;
                }
            }
        }


        static void Main(string[] args)
        {
            
            string fileIn = "C:\\Users\\Danil\\source\\repos\\ConsoleApp1\\ConsoleApp1\\help_in.txt";
            string fileOut = "C:\\Users\\Danil\\source\\repos\\ConsoleApp1\\ConsoleApp1\\help_out.txt";
            using (StreamWriter Out = new StreamWriter(fileOut))
            {
                Client[] clients = ReadClientsFromFile(fileIn);

                if (clients != null)
                {

                    Out.WriteLine("Полная информация");
                    foreach (Client client in clients)
                    {
                        client.DisplayInfo(Out);
                    }


                    DateTime targetDate = new DateTime(2023, 2, 1);
                    Out.WriteLine($"Клиенты с {targetDate}:");
                    foreach (Client client in clients)
                    {
                        if (client.IsMatch(targetDate))
                        {
                            client.DisplayInfo(Out);
                        }
                    }

                    Array.Sort(clients);
                    Out.WriteLine("Отсортированная информация");
                    foreach (Client client in clients)
                    {
                        client.DisplayInfo(Out);
                    }
                }
            }
        }
    }
}
