using System;
using System.Net;
using System.Net.Mail;
using System.Text;


namespace emailyouxiang
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Execute();


        }
         static void Execute()
        {
            EmailParameterSet model = new EmailParameterSet();
            model.SendEmail = "gamecc666@163.com";
            model.SendPwd = "gamecc666";//密码
            model.SendSetSmtp = "smtp.163.com";//发送的SMTP服务地址 ，每个邮箱的是不一样的。。根据发件人的邮箱来定
            model.ConsigneeAddress = "18151827879@163.com";
            model.ConsigneeTheme = "主题";
            model.ConsigneeHand = "标题";
            model.ConsigneeName = "hello";
            model.SendContent = "htpp://www.baidu.com";
            if (MailSend(model) == true)
            {
                Console.WriteLine("==========发送成功！");
            }
            else
            {
                Console.WriteLine("==========发送失败!");
            }
        }

        static bool MailSend(EmailParameterSet EPSModel)
        {
            try
            {
                //确定smtp服务器端的地址，实列化一个客户端smtp 
                System.Net.Mail.SmtpClient sendSmtpClient = new System.Net.Mail.SmtpClient(EPSModel.SendSetSmtp);//发件人的邮件服务器地址
                //构造一个发件的人的地址
                System.Net.Mail.MailAddress sendMailAddress = new MailAddress(EPSModel.SendEmail, EPSModel.ConsigneeHand, Encoding.UTF8);//发件人的邮件地址和收件人的标题、编码

                //构造一个收件的人的地址
                System.Net.Mail.MailAddress consigneeMailAddress = new MailAddress(EPSModel.ConsigneeAddress, EPSModel.ConsigneeName, Encoding.UTF8);//收件人的邮件地址和收件人的名称 和编码

                //构造一个Email对象
                System.Net.Mail.MailMessage mailMessage = new MailMessage(sendMailAddress, consigneeMailAddress);//发件地址和收件地址
                mailMessage.Subject = EPSModel.ConsigneeTheme;//邮件的主题
                mailMessage.BodyEncoding = Encoding.UTF8;//编码
                mailMessage.SubjectEncoding = Encoding.UTF8;//编码
                mailMessage.Body = EPSModel.SendContent;//发件内容
                mailMessage.IsBodyHtml = false;//获取或者设置指定邮件正文是否为html

                //设置邮件信息 (指定如何处理待发的电子邮件)
                sendSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定如何发邮件 是以网络来发
                sendSmtpClient.EnableSsl = false;//服务器支持安全接连，安全则为true

                sendSmtpClient.UseDefaultCredentials = false;//是否随着请求一起发

                //用户登录信息
                NetworkCredential myCredential = new NetworkCredential(EPSModel.SendEmail, EPSModel.SendPwd);
                sendSmtpClient.Credentials = myCredential;//登录
                sendSmtpClient.Send(mailMessage);//发邮件
                Console.Write("=====11111111===");
                return true;//发送成功
            }
            catch (Exception ex)
            {
                Console.Write("========错误信息：{0}", ex.ToString());
                return false;//发送失败
            }
        }
    }
}
