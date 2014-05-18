using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MemoKu.POS.Domain.Aggregate;
using MemoKu.POS.Domain.Repositories;

namespace MemoKu.POS.Domain.Services
{
    public class AutoNumberGenerator
    {
        private IAutoNumberRepository autoNumberRepository;
        private static readonly object _synch = new object();

        public AutoNumberGenerator(IAutoNumberRepository autoNumberRepository)
        {
            this.autoNumberRepository = autoNumberRepository;
        }

        public string Generate(string organizationId, string clientId, DateTime transactionDate)
        {
            lock (_synch)
            {
                AutoNumber autoNumber = autoNumberRepository.Get(transactionDate);
                if (Object.ReferenceEquals(autoNumber, null))
                {
                    autoNumber = new AutoNumber(organizationId, clientId, transactionDate);
                    autoNumberRepository.Insert(autoNumber);
                }
                autoNumber.Next();
                autoNumberRepository.Update(autoNumber);

                return autoNumber.ToString();
            }
        }
    }
}
