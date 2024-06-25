using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;

namespace EmailSender
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<string> emailAddresses = new List<string>
            {
                "vishrut.aryan.btech2020@sitpune.edu.in",
                "aryan.vishrut@gmail.com",
                "vish.dragonrider@gmail.com"
                // Add more email addresses as needed
            };

            List<Task> emailSendingTasks = new List<Task>();

            foreach (var email in emailAddresses)
            {
                emailSendingTasks.Add(SendEmailAsync(email));
            }

            await Task.WhenAll(emailSendingTasks);

            Console.WriteLine("All emails have been sent.");
            Console.ReadLine();
        }

        static async Task SendEmailAsync(string emailAddress)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Vishrut Aryan", "aryan.vishrut@gmail.com"));
            message.To.Add(new MailboxAddress("", emailAddress));
            message.Subject = "Test Email";

            message.Body = new TextPart("plain")
            {
                Text = @"Hello,

                This is a test email sent using MailKit."
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    // Replace with your actual SMTP server details
                    string smtpServer = "smtp.gmail.com"; // e.g., smtp.gmail.com
                    int smtpPort = 587; // e.g., 587 for TLS, 465 for SSL
                    string smtpUser = "aryan.vishrut@gmail.com";
                    string smtpPass = "C32onvection41$";

                    Console.WriteLine($"Connecting to SMTP server {smtpServer} on port {smtpPort}...");
                    await client.ConnectAsync(smtpServer, smtpPort, MailKit.Security.SecureSocketOptions.StartTls);
                    Console.WriteLine("Connected to SMTP server.");

                    Console.WriteLine("Authenticating...");
                    await client.AuthenticateAsync(smtpUser, smtpPass);
                    Console.WriteLine("Authenticated.");

                    Console.WriteLine($"Sending email to {emailAddress}...");
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);

                    Console.WriteLine($"Email sent to {emailAddress}");
                }
                catch (SmtpCommandException ex)
                {
                    Console.WriteLine($"SMTP command error while sending email to {emailAddress}: {ex.Message}");
                    Console.WriteLine($"\tStatusCode: {ex.StatusCode}");
                    Console.WriteLine($"\tErrorCode: {ex.ErrorCode}");
                }
                catch (SmtpProtocolException ex)
                {
                    Console.WriteLine($"SMTP protocol error while sending email to {emailAddress}: {ex.Message}");
                }
                catch (SocketException ex)
                {
                    Console.WriteLine($"Socket error while connecting to SMTP server: {ex.Message}");
                    Console.WriteLine($"\tSocketErrorCode: {ex.SocketErrorCode}");
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"IO error while sending email to {emailAddress}: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General error while sending email to {emailAddress}: {ex.Message}");
                }
                finally { Console.ReadLine(); }
            }
        }

        static void VerifyDnsResolution(string smtpServer)
        {
            try
            {
                Console.WriteLine($"Resolving DNS for {smtpServer}...");
                var addresses = Dns.GetHostAddresses(smtpServer);
                foreach (var address in addresses)
                {
                    Console.WriteLine($"DNS resolved: {address}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DNS resolution failed for {smtpServer}: {ex.Message}");
            }
            finally { Console.ReadLine(); }
        }
    }
}
