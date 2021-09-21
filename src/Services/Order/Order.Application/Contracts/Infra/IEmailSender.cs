using Order.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Contracts.Infra
{
    public interface IEmailSender
    {
        Task<bool> Send(Email email);
    }
}
