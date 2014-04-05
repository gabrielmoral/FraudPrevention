using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FraudPrevention
{
    public class EmailChecker
    {
        private const char POINT = '.';
        private const char AT = '@';
        private const char PLUS = '+';

        private string email;
        private string fraudEmail;

        public EmailChecker(string email, string fraudEmail)
        {
            this.email = email;
            this.fraudEmail = fraudEmail;
        }

        public bool IsSameEmail()
        {
            this.RemoveAt();
            this.ReplacePoints();
            this.ConvertToLower();
            this.RemovePlus();

            return this.email.Equals(this.fraudEmail);
        }

        private void RemovePlus()
        {
            this.email = this.RemoveRightPartEmail(this.email, PLUS);
            this.fraudEmail = this.RemoveRightPartEmail(this.fraudEmail, PLUS);
        }

        private void ConvertToLower()
        {
            this.email = this.email.ToLower();
            this.fraudEmail = this.fraudEmail.ToLower();
        }

        private void ReplacePoints()
        {
            this.email = this.email.Replace(POINT.ToString(), string.Empty);
            this.fraudEmail = this.fraudEmail.Replace(POINT.ToString(), string.Empty);
        }

        private void RemoveAt()
        {
            this.email = this.RemoveRightPartEmail(this.email, AT);
            this.fraudEmail = this.RemoveRightPartEmail(this.fraudEmail, AT);
        }

        private string RemoveRightPartEmail(string email, char separatorChar)
        {
            return email.Split(separatorChar).First();
        }
    }
}