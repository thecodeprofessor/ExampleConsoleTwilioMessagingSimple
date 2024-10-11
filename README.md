# Twilio Messaging Integration Example

This program demonstrates how to use the Twilio API to send and receive SMS messages via a Twilio phone number. The program includes methods to send messages, retrieve received messages, and optionally delete messages after they are received.

## Features

- Send SMS messages to any phone number.
- Retrieve and display received SMS messages.
- Optionally delete received messages from Twilio's servers after retrieval.

## Prerequisites

Before running the program, ensure you have completed the following steps:

1. **Twilio Account Setup:**
   - Follow the instructions provided on your course's Moodle page to set up your student Twilio account.
   - Note down your **Account SID**, **Auth Token**, and **Twilio phone number**, as you'll need them for the program.

2. **NuGet Package:**
   - Install the **Twilio API Client Library** by running the following command in the **Package Manager Console**:
     ```
     Install-Package Twilio
     ```

## Setup Instructions

1. **Twilio API Configuration:**
   - Replace the placeholder values in the code with your actual `twilioAccountId`, `twilioAuthToken`, and `twilioPhoneNumber`.

2. **Project Directory Structure:**
   - Ensure your `Program.cs` file is located in the `src` directory of your solution.

3. **Running the Program:**
   - The program initializes the Twilio client using your account credentials.
   - It sends an SMS message to the specified phone number and retrieves up to 10 received SMS messages for your Twilio number.

## Usage

### Initialize Twilio Client and Send an SMS Message:
```csharp
TwilioClient.Init(twilioAccountId, twilioAuthToken);
SendTextMessage("phone_number_here", "Hello World");

## License
This program is for educational purposes and is provided as-is. Ensure that you follow best practices for securing sensitive information such as API credentials.
