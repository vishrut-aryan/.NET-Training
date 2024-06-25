using System;
using System.Buffers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SmtpServer;
using SmtpServer.Protocol;
using SmtpServer.Storage;

namespace BasicSmtpServer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection()
                .AddSingleton<IMessageStore, SampleMessageStore>()
                .BuildServiceProvider();

            var options = new SmtpServerOptionsBuilder()
                .ServerName("localhost")
                .Port(25, 587)
                .Build();

            var smtpServer = new SmtpServer.SmtpServer(options, services);

            await smtpServer.StartAsync(CancellationToken.None);

            Console.WriteLine("SMTP server is running...");
            Console.WriteLine("Press any key to shutdown the server.");
            Console.ReadKey();
        }
    }

    public class SampleMessageStore : MessageStore
    {
        public override async Task<SmtpResponse> SaveAsync(
            ISessionContext context,
            IMessageTransaction transaction,
            ReadOnlySequence<byte> buffer,
            CancellationToken cancellationToken)
        {
            var message = Encoding.UTF8.GetString(buffer.ToArray());

            Console.WriteLine($"Received message from: {transaction.From}");
            Console.WriteLine($"To: {string.Join(", ", transaction.To)}");
            Console.WriteLine($"Message: {message}");

            await Task.CompletedTask;
            return SmtpResponse.Ok;
        }
    }
}
