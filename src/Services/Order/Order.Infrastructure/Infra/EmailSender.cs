using Order.Application.Contracts.Infra;
using Order.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Infra
{
    public class EmailSender : IEmailSender
    {
        public Task<bool> Send(Email email)
        {
            throw new NotImplementedException();
        }
    }
}
