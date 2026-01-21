using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestC_
{
    // You just swap 'class' for 'record'
    public record UserRecord(string Name, string? Bio = null);
}