using MailKit.Net.Smtp;
using MailKit.Security;
using PharmaFinder.Core.DTO;
using PharmaFinder.Core.Service;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using PharmaFinder.Api.Settings;
using DinkToPdf;
using DinkToPdf.Contracts;
using System.Text;
using PharmaFinder.Core.Data;
using System.Collections.Generic;

namespace PharmaFinder.Infra.Service
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfiguration _emailConfig;
        private readonly IConverter _pdfConverter;

        public EmailService(IOptions<EmailConfiguration> emailConfig, IConverter pdfConverter)
        {
            _emailConfig = emailConfig.Value;
            _pdfConverter = pdfConverter;

        }
        public void SendEmail(SendEmailDto emailDto)
        {
            var email = new MimeMessage
            {
                Subject = emailDto.Subject,
                To = { MailboxAddress.Parse(emailDto.To) },
                Body = new TextPart(TextFormat.Html)
                {
                    Text = emailDto.Html
                },
                From = { MailboxAddress.Parse(_emailConfig.From) }
            };
            using (var smtp = new SmtpClient())
            {
                smtp.Connect(_emailConfig.Host, _emailConfig.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_emailConfig.From, _emailConfig.Password);
                var response = smtp.Send(email);
                smtp.Disconnect(true);
            }
        }
        public void SendInvoice(SendEmailDto emailDto, List<PharmaMedResult> items, InvoiceDTO invoiceDTO)
        {
            var email = new MimeMessage
            {
                Subject = emailDto.Subject,
                To = { MailboxAddress.Parse(emailDto.To) },
                Body = new TextPart(TextFormat.Html)
                {
                    Text = emailDto.PlainText
                },
                From = { MailboxAddress.Parse(_emailConfig.From) }
            };

            var builder = new BodyBuilder();
            builder.HtmlBody = emailDto.PlainText;
            byte[] pdfAttachment;
            if (items.Count == 0)
            {
                pdfAttachment = GeneratePdf2FromHtml(invoiceDTO);

            }
            else
            {
                pdfAttachment = GeneratePdfFromHtml(items, invoiceDTO);


            }
            if (pdfAttachment != null)
            {
                builder.Attachments.Add("Invoice.pdf", pdfAttachment);
            }


            email.Body = builder.ToMessageBody();
            using (var smtp = new SmtpClient())
            {
                smtp.Connect(_emailConfig.Host, _emailConfig.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_emailConfig.From, _emailConfig.Password);
                var response = smtp.Send(email);
                smtp.Disconnect(true);
            }
        }

        public byte[] GeneratePdfFromHtml(List<PharmaMedResult> items, InvoiceDTO invoiceDTO)
        {
            StringBuilder htmlContent = new StringBuilder();
            htmlContent.Append($@"<html>
<head>
    <meta charset=""utf-8"" />
    <title>PharmaFinder Invoice</title>

    <style>
        body {{
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
        }}

        .invoice-box {{
            max-width: 800px;
            margin: auto;
            padding: 30px;
            background-color: #fff;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.15);
        }}

        .invoice-box img {{
            max-width: 200px;
            height: auto;
            display: block;
            margin: auto;
            margin-bottom: 20px;
        }}

        .invoice-box table {{
            width: 100%;
            line-height: 1.5;
            border-collapse: collapse;
        }}

        .invoice-box table td {{
            padding: 10px;
            vertical-align: top;
            border: 1px solid #dddddd;
            text-align: left;
        }}

        .invoice-box table tr.heading td {{
            background: #f4f4f4;
            font-weight: bold;
            text-align: center;
        }}

        .invoice-box table tr.details td {{
            text-align: center;
        }}

        .invoice-box table tr.item td {{
            text-align: center;
        }}

        .invoice-box table tr.total td {{
            background: #f4f4f4;
            font-weight: bold;
            text-align: center;
        }}

        .company-info,
        .your-info {{
            width: 50%;
        }}

        @media only screen and (max-width: 600px) {{
            .invoice-box table tr.top table td {{
                width: 100%;
                display: block;
                text-align: center;
            }}

            .invoice-box table tr.information table td {{
                width: 100%;
                display: block;
                text-align: center;
            }}

            .company-info,
            .your-info {{
                width: 100%;
            }}
        }}
    </style>
</head>

<body>
    <div class=""invoice-box"">
        <img src=""https://i.ibb.co/hgkftBt/Pharma-Finder.png"" />

        <table>
            <tr class=""top"">
                <td colspan=""2"">
                    <table>
                        <tr>
                            <td class=""company-info"">
                                <h3>Company Information</h3>
                                <p>
                                    PharmaFinder, Inc.<br />
                                    King Abdullah II St<br />
                                    +962-79-6217882
                                </p>
                            </td>
                            <td class=""your-info"">
                                <h3>Your Information</h3>
                                <p>
                                    {invoiceDTO.Username}<br />
                                    {invoiceDTO.Email}
                                </p>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>

            <tr class=""details"">
                <td colspan=""2"">Invoice #: {invoiceDTO.Orderid} | Due: {invoiceDTO.Orderdate}</td>
            </tr>

           

            <tr class=""heading"">
                <td>Pharmacy Name</td>
                <td>Item</td>
                <td>Quantity</td>
                <td>Price</td>
                <td>Total</td>
            </tr>


");
            foreach (var item in items)
            {
                htmlContent.Append($@"<tr class=""item"">
					<td>{item.Pharmacyname}</td>
					<td>{item.Medicinename}</td>
					<td>{item.Quantity}</td>
					<td>${item.Medicineprice}</td>
					<td>${item.Medicineprice * item.Quantity}</td>

				</tr>");

            }

            htmlContent.Append($@"<tr class=""total"">
                <td colspan=""4"">Total:</td>
                <td><strong>${invoiceDTO.Orderprice}</strong></td>
            </tr>
        </table>
    </div>
</body>
</html>");

            var pdf = _pdfConverter.Convert(new HtmlToPdfDocument()
            {
                GlobalSettings = {
            PaperSize = PaperKind.A4,
            Orientation = Orientation.Landscape
        },
                Objects = {
            new ObjectSettings() {
                HtmlContent =htmlContent.ToString()

            }
        }
            });

            return pdf;
        }
    
        public byte[] GeneratePdf2FromHtml( InvoiceDTO invoiceDTO)
        {
            StringBuilder htmlContent = new StringBuilder();
            htmlContent.Append($@"<html>
<head>
    <meta charset=""utf-8"" />
    <title>PharmaFinder Invoice</title>

    <style>
        body {{
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
        }}

        .invoice-box {{
            max-width: 800px;
            margin: auto;
            padding: 30px;
            background-color: #fff;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.15);
        }}

        .invoice-box img {{
            max-width: 200px;
            height: auto;
            display: block;
            margin: auto;
            margin-bottom: 20px;
        }}

        .invoice-box table {{
            width: 100%;
            line-height: 1.5;
            border-collapse: collapse;
        }}

        .invoice-box table td {{
            padding: 10px;
            vertical-align: top;
            border: 1px solid #dddddd;
            text-align: left;
        }}

        .invoice-box table tr.heading td {{
            background: #f4f4f4;
            font-weight: bold;
            text-align: center;
        }}

        .invoice-box table tr.details td {{
            text-align: center;
        }}

        .invoice-box table tr.item td {{
            text-align: center;
        }}

        .invoice-box table tr.total td {{
            background: #f4f4f4;
            font-weight: bold;
            text-align: center;
        }}

        .company-info,
        .your-info {{
            width: 50%;
        }}

        @media only screen and (max-width: 600px) {{
            .invoice-box table tr.top table td {{
                width: 100%;
                display: block;
                text-align: center;
            }}

            .invoice-box table tr.information table td {{
                width: 100%;
                display: block;
                text-align: center;
            }}

            .company-info,
            .your-info {{
                width: 100%;
            }}
        }}
    </style>
</head>

<body>
    <div class=""invoice-box"">
        <img src=""https://i.ibb.co/hgkftBt/Pharma-Finder.png"" />

        <table>
            <tr class=""top"">
                <td colspan=""2"">
                    <table>
                        <tr>
                            <td class=""company-info"">
                                <h3>Company Information</h3>
                                <p>
                                    PharmaFinder, Inc.<br />
                                    King Abdullah II St<br />
                                    +962-79-6217882
                                </p>
                            </td>
                            <td class=""your-info"">
                                <h3>Your Information</h3>
                                <p>
                                    {invoiceDTO.Username}<br />
                                    {invoiceDTO.Email}
                                </p>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>

            <tr class=""details"">
                <td colspan=""2"">Invoice #: {invoiceDTO.Orderid} | Due: {invoiceDTO.Orderdate}</td>
            </tr>

            <tr class=""heading"">
                <td colspan=""5"">Payment Method: PayPal</td>
            </tr>

            <tr class=""details"">
                <td colspan=""2"">Order Total: ${invoiceDTO.Orderprice}</td>
            </tr>");

            htmlContent.Append($@"
        </table>
    </div>
</body>
</html>");


            var pdf = _pdfConverter.Convert(new HtmlToPdfDocument()
            {
                GlobalSettings = {
            PaperSize = PaperKind.A4,
            Orientation = Orientation.Landscape
        },
                Objects = {
            new ObjectSettings() {
                HtmlContent =htmlContent.ToString()

            }
        }
            });

            return pdf;
        }
    
    }
}



