using System.Drawing.Imaging;
using System.Web;


namespace ShayanDB_BLL
{
    public class CaptchaResult
    {
        public string _captchaText;
        public CaptchaResult(string captchaText, HttpContext context)
        {
            _captchaText = captchaText;

            Captcha c = new Captcha();
            c.Text = _captchaText;
            c.Width = 150;
            c.Height = 40;
            c.FamilyName = "Arial";

            context.Response.Clear();
            context.Response.ContentType = "image/jpeg";
            c.Image.Save(context.Response.OutputStream, ImageFormat.Jpeg);
            c.Dispose();
        }
    }
}
