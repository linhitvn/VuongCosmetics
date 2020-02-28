using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;

/// <summary>
/// Summary description for MailSender
/// </summary>
public class MailSender
{
    string myEmail;
    string myPassword;
    string myName; 

	public MailSender(string fromMailAddress, string fromMailPassword, string fromMailName)
	{
        myEmail = fromMailAddress;
        myPassword = fromMailPassword;
        myName = fromMailName;
	}

    public void sendMail(string toMailAddress, string subject, string body)
    {
        MailAddress from = new MailAddress(myEmail, myName);
        MailAddress to = new MailAddress(toMailAddress, "MuthuVijayan");
        MailMessage message = new MailMessage(from, to);

        message.Subject = subject;
        message.Body = body;

        var client = new SmtpClient("smtp.gmail.com", 587)
        {
            Credentials = new NetworkCredential(myEmail, myPassword),
            EnableSsl = true
        };
        client.Send(myEmail, toMailAddress, subject, body);
    }
}