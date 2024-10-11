// Before You Begin
// Instructions for Setting Up Twilio:
// 1. Follow the instructions provided on your course Moodle page to set up your student Twilio account.
//    Make sure to note down your Account SID, Auth Token, and Twilio phone number, as you'll need them later.
// 2. Open your project in Visual Studio.
// 3. Go to the "Tools" menu at the top of the screen.
// 4. Select "NuGet Package Manager" > "Package Manager Console."
// 5. In the "Package Manager Console" window that opens, type the following command and press Enter:
//    Install-Package Twilio
// 6. Wait for the installation to complete. You should see messages indicating that the package has been installed successfully.
// 7. Enter your Twilio details: twilioAccountId, twilioAuthToken, twilioPhoneNumber
// 8. Update `Main`:
//    - Initialize with `TwilioClient.Init(twilioAccountId, twilioAuthToken);`
//    - Replace `SendMessage("phone_number_here", "Hello World");` with your own number
//    - Use `ReceiveMessages(delete: true)` to check messages


using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using System.Collections.Generic;

// Create an alias for the MessageResource class
using Message = Twilio.Rest.Api.V2010.Account.MessageResource;

namespace ExampleConsoleTwilioMessagingSimple
{
    internal class Program
    {
        // Twilio Account Information (replace with your actual account information)
        public static string twilioAccountId = "twilio_account_id_here";
        public static string twilioAuthToken = "twilio_auth_token_here";
        public static string twilioPhoneNumber = "twilio_phone_number_here";

        static void Main(string[] args)
        {
            //Initialize the Twilio client.
            TwilioClient.Init(twilioAccountId, twilioAuthToken);

            //Send a "Hello World" message to a specified phone number in the format of +1XXXXXXXXX.
            //SendTextMessage("phone_number_here", "Hello World");

            //Check for recieved messages and display them.
            //var messages = ReceiveTextMessages(delete: true);
            //foreach (var message in messages)
            //{
            //    Console.WriteLine($"Received message from {message.From}: {message.Body}");
            //}
        }

        // Method to send a message
        public static void SendTextMessage(string recipientNumber, string messageBody)
        {
            var sentMessage = Message.Create(
                to: new PhoneNumber(recipientNumber),
                from: new PhoneNumber(twilioPhoneNumber),
                body: messageBody
            );

            //OPTIONAL: You can display a confirmation that the message has been sent.
            //Console.WriteLine($"Message sent with ID: {sentMessage.Sid}");
        }

        // Method to receive messages
        public static List<Message> ReceiveTextMessages(bool delete)
        {
            var messages = Message.Read(to: new PhoneNumber(twilioPhoneNumber), limit: 10);

            var receivedMessages = new List<Message>();
            foreach (var message in messages.Where(m => m.Direction == Message.DirectionEnum.Inbound && m.Status == Message.StatusEnum.Received))
            {
                receivedMessages.Add(message);

                if (delete)
                {
                    Message.Delete(message.Sid);

                    //OPTIONAL: You can display a message indicating the message has been deleted.
                    //Console.WriteLine($"Message from {message.From} with the body {message.Body} has been deleted.");
                }
            }

            return receivedMessages;
        }
    }
}