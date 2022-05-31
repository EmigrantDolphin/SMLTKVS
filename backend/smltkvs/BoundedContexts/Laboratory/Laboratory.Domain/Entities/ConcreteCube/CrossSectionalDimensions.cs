using Laboratory.Domain.Enums;

namespace Laboratory.Domain.Entities.ConcreteCube;

public class CrossSectionalDimensions
{
    public Guid CrossSectionalDimensionsId { get; private set; }
    public CubeDimension Dimension { get; private set; }
    public decimal Value { get; private set; }

    public CrossSectionalDimensions()
    {
        // For EFCore
    }

    private CrossSectionalDimensions(CubeDimension dimension, decimal value)
    {
        CrossSectionalDimensionsId = Guid.NewGuid();
        Dimension = dimension;
        Value = value;
    }

    public static List<CrossSectionalDimensions> ToDomain(decimal[] valueA, decimal[] valueB)
    {
        var aDimension = valueA.Select(x => new CrossSectionalDimensions(CubeDimension.A, x)).ToList();
        var bDimension = valueB.Select(x => new CrossSectionalDimensions(CubeDimension.B, x)).ToList();

        return aDimension.Concat(bDimension).ToList();
    }

    public void Update(decimal value) => Value = value;
}