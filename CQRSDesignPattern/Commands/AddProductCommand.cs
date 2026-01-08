using CQRSDesignPattern.Db;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDesignPattern.Commands
{
    public class AddProductCommand : IRequest
    {
        public string Name { get; set; }
    }
}
