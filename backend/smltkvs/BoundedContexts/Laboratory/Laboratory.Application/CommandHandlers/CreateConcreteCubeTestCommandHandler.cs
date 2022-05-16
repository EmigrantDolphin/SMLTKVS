using Infrastructure.OneOf.Types;
using Laboratory.Application.Commands;
using Laboratory.Domain.Aggregates;
using Laboratory.Domain.Entities.ConcreteCube;
using Laboratory.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;

namespace Laboratory.Application.CommandHandlers;

public class CreateConcreteCubeTestCommandHandler : IRequestHandler<CreateConcreteCubeTestCommand, OneOf<Success, BadRequest>>
{
    private readonly ILaboratoryContext _context;

    public CreateConcreteCubeTestCommandHandler(ILaboratoryContext context)
    {
        _context = context;
    }
    
    public async Task<OneOf<Success, BadRequest>> Handle(CreateConcreteCubeTestCommand request, CancellationToken cancellationToken)
    {
        var concreteCubeStrengthTestData = request.TestData.Select(x =>
            new ConcreteCubeStrengthTestData(
                x.Comment,
                x.DestructivePower,
                x.CrushingStrength,
                CrossSectionalDimensions.ToDomain(x.ValueA, x.ValueB)
            )
        ).ToList();

        var count = await _context.ConcreteCubeStrengthTests.CountAsync(cancellationToken);

        var concreteCubeStrengthTest = new ConcreteCubeStrengthTest(
            $"Nr. {count}",
            request.ClientCompanyId,
            request.ClientConstructionSiteId,
            request.EmployeeCompanyId,
            request.TestExecutionDate,
            request.TestSamplesReceivedDate,
            request.TestSamplesDeliveredBy,
            request.TestSamplesReceivedComment,
            request.TestSamplesReceivedCount,
            request.TestExecutedByUserId,
            request.ProtocolCreatedByUserId,
            request.TestType,
            request.ConcreteType,
            request.AcceptedSampleCount,
            request.RejectedSampleCount,
            request.AverageCrushForce,
            request.StandardUncertainty,
            request.ExtendedUncertainty,
            request.StandardDeviation,
            request.CharacteristicStrength,
            request.ConcreteRating,
            concreteCubeStrengthTestData);

        _context.ConcreteCubeStrengthTests.Add(concreteCubeStrengthTest);
        await _context.SaveChangesAsync();

        return new Success();
    }
}