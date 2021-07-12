using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAExceptions
{
    public class DeliveryService
    {
        private readonly static Random random = new Random();
        public void Start(Delivery delivery)
        {
            try
            {
                Process(delivery);
                Ship(delivery);
                Transit(delivery);
                Deliver(delivery);
            }
            catch (AccidentException ex)
            {
                // inform the user
                // log the exception
                // Ducking (rethrowing)
                throw;
                //Console.WriteLine($"There was an accident at {ex.Location} preventing us from delivering your parcel: {ex.Message}");
                //delivery.DeliveryStatus = DeliveryStatus.UNKNOWN;
            }
            catch (Exception ex)
            {
                throw;
                //Console.WriteLine($"Deliver Fails due to: {ex.Message}");
                //delivery.DeliveryStatus = DeliveryStatus.UNKNOWN;
            }
            finally
            { 
                Console.WriteLine("End");
            }
        }

        private void Process(Delivery delivery)
        {
            FakeIt("Processing");
            if(random.Next(1, 10) == 1)
            {
                throw new InvalidOperationException("unable to process the item");
            }
            delivery.DeliveryStatus = DeliveryStatus.PROCESSED;
        }
        private void Ship(Delivery delivery)
        {
            FakeIt("Shipping");
            if (random.Next(1, 10) == 1)
            {
                throw new InvalidOperationException("Parcel is damaged during the loading process");
            }
            delivery.DeliveryStatus = DeliveryStatus.SHIPPED;
        }
        private void Transit(Delivery delivery)
        {
            FakeIt("On Its way");
            if (random.Next(1, 5) == 1)
            {
                throw new AccidentException("354 some another street", "ACCIDENT !!!");
            }
            delivery.DeliveryStatus = DeliveryStatus.INTRANSIT;
        }
        private void Deliver(Delivery delivery)
        {
            FakeIt("Delivering");
            if (random.Next(1, 5) == 1)
            {
                throw new InvalidAddressException($"'{delivery.Address}' is invalid !!!");
            }
            delivery.DeliveryStatus = DeliveryStatus.DELIVERED;
        }

        private void FakeIt(string title)
        {
            Console.Write(title);
            System.Threading.Thread.Sleep(300);
            Console.Write(".");
            System.Threading.Thread.Sleep(300);
            Console.Write(".");
            System.Threading.Thread.Sleep(300);
            Console.Write(".");
            System.Threading.Thread.Sleep(300);
            Console.Write(".");
            System.Threading.Thread.Sleep(300);
            Console.Write(".");
            System.Threading.Thread.Sleep(300);
            Console.WriteLine(".");
        }
    }
}
