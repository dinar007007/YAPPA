using System;
using System.Collections.Generic;
using System.Text;
using YAAPA.Models;

namespace YAAPA.Services
{
    public class Storage
    {
        public IEnumerable<Tomato> GetItems() => new[]
        {
            new Tomato
            {
                Complete = true,
                Description = "First"
            },
            new Tomato
            {
                Complete = false,
                Description = "Second"
            },
            new Tomato
            {
                Complete = true,
                Description = "Third"
            },
            new Tomato
            {
                Complete = true,
                Description = "Fourth"
            }
        };
    }
}
