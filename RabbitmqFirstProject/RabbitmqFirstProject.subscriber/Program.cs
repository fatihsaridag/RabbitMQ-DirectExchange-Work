using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.IO;
using System.Text;
using System.Threading;

namespace RabbitmqFirstProject.subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
         
            var factory = new ConnectionFactory(); 
            factory.Uri = new Uri("amqps://eznbdupx:Qf4h0Avxf0yEipy5VaR1D7UHRfIL0Gfn@gerbil.rmq.cloudamqp.com/eznbdupx");  
            using var connection = factory.CreateConnection(); 
            var channel = connection.CreateModel();

            //Kuyrugumuz zaten var oldugundan tekrar oluşturmaya gerek yok . 

        


            channel.BasicQos(0, 1, false);                                       // Birer birer alsın diyoruz.  
            var consumer = new EventingBasicConsumer(channel);

            var queueName = "direct-queue-Critical";                             // Bu Subscriberın Critical ile ilgilenmesini istiyoruz.

            channel.BasicConsume(queueName, false,consumer);                   // Yukarıdaki random kuyruk ismini tüketmesini istiyoruz
            Console.WriteLine("Loglar dinleniyor..");                            // Bu yazıyı almaya çalışalım.
            consumer.Received += (object sender, BasicDeliverEventArgs e) => {  
            var message = Encoding.UTF8.GetString(e.Body.ToArray());
            Thread.Sleep(1500);   
            Console.WriteLine("Gelen mesaj : " + message);
            //File.AppendAllText("log-critical.txt", message +"\n");
            channel.BasicAck(e.DeliveryTag, false); 
            };
            Console.ReadLine();
        }
    }
}
