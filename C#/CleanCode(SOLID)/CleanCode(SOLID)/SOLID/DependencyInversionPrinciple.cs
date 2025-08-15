using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode_SOLID_.SOLID;

/*
// used to reduce high level and low level coupling between classes
// low level Module
public class EmailService
{
    public void SendEmail(string to, string subject, string body)
    {
        Console.WriteLine($"Sending email to {to} with subject {subject}");
    }
}

// high level module
public class Notification
{
    // hardcoded
    private readonly EmailService _emailService;
    public Notification()
    {
        // create an instance of low level module
        // this is a violation 
        _emailService = new EmailService();
    }

    public void Send(string message)
    {
        Console.WriteLine("Message Sent: " + message);
    }

}
*/




// solution for the violation
public interface IEmailService
{
    public void SendEmail(string to, string subject, string body);
}

public class EmailService : IEmailService
{
    public void SendEmail(string to, string subject, string body)
    {
        Console.WriteLine($"Sending email to {to} with subject {subject}");
    }
}

public class Notification
{
    private readonly IEmailService _emailService;
    public Notification(IEmailService emailService)
    {
        _emailService = emailService;
    }

    public void Send(string message)
    {
        _emailService.SendEmail("user@example.com", "Notification", message);
    }
}