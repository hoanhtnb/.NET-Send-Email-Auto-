//=======================================================
//Bla bla bla
//1. Validate Email Address befor Send
//2. Config Port or Host
//3. Create Class object send 
//4. Bla bla
//=======================================================		

  private void sendMail4User()
        {
            try
            {
                string body = string.Empty;
                string emailto = string.Empty;
                string strWhere = string.Empty;
                strWhere = "ACCTNO ='" + txtAccountNo.Text + "'";
                emailto = GetContractInfo(strWhere);
                if (emailto != string.Empty)
                {
                    //StreamReader sr = new StreamReader("~/TemplateMail/EMailTemplate.htm");
                    StreamReader sr = new StreamReader(Application.StartupPath + "\\TemplateMail\\EmailTemplate.htm");
                    //Application
                    body = sr.ReadToEnd();
                    sr.Close();

                    body = body.Replace("{FULL_NAME}", txtFullName.Text);
                    body = body.Replace("{UserName}", txtInvestName.Text.Trim());
                    body = body.Replace("{PassWord}", txtPassword.Text.Trim());

                    using (MailMessage mailMessage = new MailMessage())
                    {
                        mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["UserName"]);
                        mailMessage.Subject = ConfigurationManager.AppSettings["Subject"];
                        mailMessage.Body = body;
                        mailMessage.IsBodyHtml = true;
                        mailMessage.To.Add(new MailAddress(emailto));
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = ConfigurationManager.AppSettings["Host"];
                        smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
                        System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                        NetworkCred.UserName = ConfigurationManager.AppSettings["UserName"];
                        NetworkCred.Password = ConfigurationManager.AppSettings["Password"];
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
                        smtp.Send(mailMessage);
                    }
                }
                else
                {
                    Message.Show("Không gửi được Mail do địa chỉ Email không tồn tại trong hệ thống");
                }
            }

            catch (Exception ex)
            {
                Message.Show(ex.Message);
            }
        }
//=======================================================
//https://github.com/hoanhtnb
//Twitter: @hoangtronghoan
//Facebook: facebook.com/ht.hoan
//=======================================================		
		
		