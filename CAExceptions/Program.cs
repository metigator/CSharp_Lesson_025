using System;

namespace CAExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            var delivery = new Delivery { Id = 1, CustomerName = "Issam A.", Address = "123 Street" };
            var service = new DeliveryService();
            try
            {
                service.Start(delivery);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine(delivery);
            Console.ReadKey();
        } 
    }
}
