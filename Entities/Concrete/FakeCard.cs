using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class FakeCard : IEntity
    {
        public int CardId { get; set; }
        public string CardOwner { get; set; }
        public string CardNumber { get; set; }
        public string CardSecurityNumber { get; set; }
        public decimal CardBalance { get; set; }
    }
}
