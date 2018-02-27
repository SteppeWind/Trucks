using System;
using System.Collections.Generic;
using System.Text;

namespace Trucks.Domain
{
    public interface ISizeEntityBase : IEntityBase
    {
        double Length { get; set; }
        double Width { get; set; }
        double Height { get; set; }
        double Volume { get; }
    }

    public abstract class SizeEntityBase : EntityBase, ISizeEntityBase
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public double Volume => Length * Width * Height;
    }
}