using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace ConstructionLine.CodingChallenge
{
    public class Size
    {
        public Guid Id { get; }

        public string Name { get; }

        private Size(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public static readonly Size Small = new Size(Guid.NewGuid(), "Small");
        public static readonly Size Medium = new Size(Guid.NewGuid(), "Medium");
        public static readonly Size Large = new Size(Guid.NewGuid(), "Large");

        public static readonly ImmutableList<Size> All =
            ImmutableList.Create<Size>(new Size[]
            {
                Small,
                Medium,
                Large
            });

        public override string ToString()
        {
            return $"Id={Id} Name={Name}";
        }
    }
}