using RabbitMQ.Client;
using System;
using System.Linq;
using System.Text;

namespace RabbitmqFirstProject.publisher
{
    class Program
    {


        public enum LogNames
        {
            Critical = 1,
            Error = 2,
            Warning = 3,
            Info = 4
        }


        static void Main(string[] args)
        {
            //RabbitMq ya bağlanmamız için connection factory isminde bir nesne örneğği alalım
            var factory = new ConnectionFactory();
            //Uri yımızı belirticez. CloudAmqp deki instancedan urli alıyoruz. Gerçek seneryoda bunları appsetting.json içeçrisinde tutuyoruz.
            factory.Uri = new Uri("amqps://eznbdupx:Qf4h0Avxf0yEipy5VaR1D7UHRfIL0Gfn@gerbil.rmq.cloudamqp.com/eznbdupx");

            //factory üzerinden bir bağlantı açıyoruz.
            using var connection = factory.CreateConnection();
            //Artık bir bağlantımız var ve bu bağlantı  üzerinden kanal oluşturuyoruz onun üzerinden bağlanıcaz.
            var channel = connection.CreateModel(); //Bu kanal üzerinden rabbitMq ile haberleşebiliriz.
            //1.param : Exchange ismi , 2.param : restart atınca uygulama fiziksel olarak kaydedilsin , 3.param : Exchange tipi ? 
            channel.ExchangeDeclare("logs-direct",durable:true, type:ExchangeType.Direct);                                                        
           

            Enum.GetNames(typeof(LogNames)).ToList().ForEach(x =>       // Enumları liste olarak getir ve bunları foreach ile dön.
            {
                var routeKey = $"route-{x}";
                var queueName = $"direct-queue-{x}";                    //Kuyruğun ismini oluşturduk
                channel.QueueDeclare(queueName,true,false,false);       //Kuyruğu oluşturdukk
                channel.QueueBind(queueName,"logs-direct",routeKey,null);        // Bind ettik.
            });


            Enumerable.Range(1, 50).ToList().ForEach(x =>
             {
                 LogNames log = (LogNames)new Random().Next(1, 5);      //Bana 1-5 araası random değer ver ve bunu logNameye çevir.

                 string message = $"log-type : {log}";  
                 var messageBody = Encoding.UTF8.GetBytes(message);
                 var routeKey = $"route-{log}";
                 channel.BasicPublish("logs-direct", routeKey, null, messageBody);  
                 Console.WriteLine($"Log Gönderilmiştir : {message}");
             });

           
               
        }
    }
}
