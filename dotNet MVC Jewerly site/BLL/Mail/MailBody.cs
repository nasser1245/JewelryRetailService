using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HProtest_BLL.Mail
{
    public class MailBody
    {
        #region template
        static string MailTemplate = @"
                <!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>
                <head>
                <meta content='text/html; charset=utf-8' http-equiv='Content-Type' />
                <title>تارنمای موعظه نقادانه - حزب الله</title>
                </head>
                <body>
                <div style='width:100%;height:100%;background-color:#E7F4FF;font:10pt tahoma'>
                    <div style='width: 600px; height: 500px; direction: rtl; margin: 0px auto; background: #ddd; padding: 0px; border:solid 2px #A7A7A7; position: relative;'>
                        <div style='background:url(http://hezbollahmoezeh.net/images/mail_header.jpg) no-repeat right'>
                            <div style='width: 100%; height: 145px;background:#fff'>
                                <div style='float:left;height:60px;margin-left:20px;font-family:Arial;font-weight:bolder;font-size:20pt'>
                                    <a href='http://hezbollahmoezeh.net' style='text-decoration:none;color:#50c1da;'>Hezbollahlaw.com</a></div>
                            </div>
                        </div>
                        <div style='text-align:justify;'>

                            <div style='clear:both;height:20px'>
                            </div>
                            <div style='line-height:25px;'>
                                #BodyText#
                            </div>
                        </div>
                        <div style='clear:both;height:20px'>
                        </div>

                    </div>
				</div>
                <body>
                ";
        #endregion


        #region AcCodeLink body
        public static string AcCodeLink = MailTemplate.Replace("#BodyText#", @"
         <div class='round borderd' style='width:500px;margin:10px auto;position:relative;line-height:30px'>
            <table>
                <tr>
                    <td>
                        لطفا برای تغییر رمز عبور روی لینک زیر کلیک کنید:
                    </td>
                </tr>
                <tr>
                    <td>
                        <a  href='#link#'>#link#</a>
                        
                   </td>
                </tr>
            </table>
        </div>
        ");
        #endregion

        #region vCard Body

        public static string vCard = MailTemplate.Replace("#BodyText#", @"
                <div class='round borderd' style='width:500px;margin:10px auto;position:relative;line-height:30px'>
                    <table cellspacing='10px' width='100%'>
                        <tr>
                            <td>نام:</td>
                            <td colspan='2'>#name#</td>
                            <td rowspan='2' align='left'><img alt='' width='100px' src='#image#' /></td>
                        </tr>
                        <tr>
                            <td>نام خانوادگی:</td>
                            <td colspan='2'>#lastname#</td>
                        </tr>
                        <tr><td>پست الکترونیکی:</td>#mail#</td></tr>
                        <tr>
                            <td>نام کاربری:</td><td>#username#</td>
                            <td>رمز عبور:</td><td>[محافظت شده]</td>
                        </tr>
                    </table>
                </div>
                ");
        #endregion

        #region Message Body
        public static string Message = @"
                                        <div style='text-align:right;margin-top:15px;'>سلام به شما کاربر عزیز</div>
                                        "+
                                         MailTemplate
                                         +@"
                                        <div style='width:100%;text-align:right;'>موفق و پیروز باشید<br /></div>
                                        ";
        #endregion

        #region Err Body
        public static string Err = MailTemplate;
        #endregion


        public static string GetMailBody(HProtest_BLL.Mail.Mail.BodyType type, System.Collections.ArrayList attr)
        {
            switch (type)
            {
                case Mail.BodyType.Message:
                    return Message;
                case Mail.BodyType.Err:
                    return Err;
                case Mail.BodyType.vCard:
                    return vCard.Replace("#name#", attr[0].ToString()).Replace("#lastname#", attr[1].ToString()).Replace("#image#", attr[2].ToString()).Replace("#mail#", attr[3].ToString()).Replace("#username#", attr[4].ToString());
                case Mail.BodyType.AcCodeLink:
                    return AcCodeLink.Replace("#link#", attr[0].ToString());
                
                default:
                    return MailTemplate;
            }
        }
    }
}
