using Infrastructure.OneOf.Types;
using Laboratory.Application.Commands;
using Laboratory.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;

namespace Laboratory.Application.CommandHandlers;

public class UpdateConcreteCubeTestCommandHandler : IRequestHandler<UpdateConcreteCubeTestCommand, OneOf<Success, BadRequest>>
{
    private readonly ILaboratoryContext _context;

    public UpdateConcreteCubeTestCommandHandler(ILaboratoryContext context)
    {
        _context = context;
    }
    
    public async Task<OneOf<Success, BadRequest>> Handle(UpdateConcreteCubeTestCommand request, CancellationToken cancellationToken)
    {
        var concreteCubeTest =
            await _context.ConcreteCubeStrengthTests
                .Include(x => x.TestData)
                    .ThenInclude(x => x.Dimensions)
                .SingleOrDefaultAsync(x => x.ConcreteCubeStrengthTestId == request.ConcreteCubeTestId, cancellationToken);

        if (concreteCubeTest is null)
        {
            return new BadRequest("Testas neegzistuoja");
        }

        for (int i = 0; i < concreteCubeTest.TestData.Count; i++)
        {
            var requestData = request.TestData[i];
            concreteCubeTest.TestData[i].Update(
                requestData.Comment,
                requestData.DestructivePower,
                requestData.CrushingStrength,
                requestData.ValueA,
                requestData.ValueB);
        }

        concreteCubeTest.Update(
            request.TestExecutionDate,
            request.TestSamplesReceivedDate,
            request.TestSamplesDeliveredBy,
            request.TestSamplesReceivedComment,
            request.TestSamplesReceivedCount,
            request.ConcreteType,
            request.AcceptedSampleCount,
            request.RejectedSampleCount,
            request.AverageCrushForce,
            request.StandardUncertainty,
            request.ExtendedUncertainty,
            request.StandardDeviation,
            request.CharacteristicStrength,
            request.ConcreteRating);

        await _context.SaveChangesAsync();

        return new Success();
    }
}
