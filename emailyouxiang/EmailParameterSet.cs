public class EmailParameterSet
{
    /// <summary>
    /// 收件人的邮件地址 
    /// </summary>
    public string ConsigneeAddress { get; set; }

    /// <summary>
    /// 收件人的名称
    /// </summary>
    public string ConsigneeName { get; set; }

    /// <summary>
    /// 收件人标题
    /// </summary>
    public string ConsigneeHand { get; set; }

    /// <summary>
    /// 收件人的主题
    /// </summary>
    public string ConsigneeTheme { get; set; }

    /// <summary>
    /// 发件邮件服务器的Smtp设置
    /// </summary>
    public string SendSetSmtp { get; set; }

    /// <summary>
    /// 发件人的邮件
    /// </summary>
    public string SendEmail { get; set; }

    /// <summary>
    /// 发件人的邮件密码
    /// </summary>
    public string SendPwd { get; set; }
    /// <summary>
    /// 发件内容
    /// </summary>
    public string SendContent { get; set; }
}