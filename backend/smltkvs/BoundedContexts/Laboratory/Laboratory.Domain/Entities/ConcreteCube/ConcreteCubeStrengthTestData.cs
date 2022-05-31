using Laboratory.Domain.Enums;

namespace Laboratory.Domain.Entities.ConcreteCube;

public class ConcreteCubeStrengthTestData
{
    public Guid ConcreteCubeStrengthTestDataId { get; private set; }
    public string Comment { get; private set; }
    public decimal DestructivePower { get; private set; }
    public decimal CrushingStrength { get; private set; }
    public List<CrossSectionalDimensions> Dimensions { get; private set; }

    public ConcreteCubeStrengthTestData()
    {
        // For EFCore
    }

    public ConcreteCubeStrengthTestData(
        string comment,
        decimal destructivePower,
        decimal crushingStrength,
        List<CrossSectionalDimensions> dimensions
    )
    {
        ConcreteCubeStrengthTestDataId = Guid.NewGuid();
        Comment = comment;
        DestructivePower = destructivePower;
        CrushingStrength = crushingStrength;
        Dimensions = dimensions;
    }

    public void Update(string comment, decimal destructivePower, decimal crushingStrength, decimal[] valuesA,
        decimal[] valuesB)
    {
        Comment = comment;
        DestructivePower = destructivePower;
        CrushingStrength = crushingStrength;
        var aDimensions = Dimensions.Where(x => x.Dimension == CubeDimension.A).ToList();
        var bDimensions = Dimensions.Where(x => x.Dimension == CubeDimension.B).ToList();

        for (int i = 0; i < aDimensions.Count; i++)
        {
            aDimensions[i].Update(valuesA[i]); 
            bDimensions[i].Update(valuesB[i]); 
        }
    }
}