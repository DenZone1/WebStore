using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Domain.Entites.Base.Interfaces;

public interface InamedEntity : IEntity
{
    string Name { get; set; }
}