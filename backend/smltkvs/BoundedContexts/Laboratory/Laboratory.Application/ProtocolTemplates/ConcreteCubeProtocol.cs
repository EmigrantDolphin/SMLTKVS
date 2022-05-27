using System.Text;
using Laboratory.Domain.Aggregates;
using Laboratory.Domain.Enums;

namespace Laboratory.Application.ProtocolTemplates;

public static class ConcreteCubeProtocol
{
	public static string GetFile(ConcreteCubeStrengthTest data, Company executingUserCompany, string testExecutedByUserName = "")
	{
		var template = data.TestType == TestType.Initial
			? ConcreteCubeInitialProtocolTemplate.Template
			: ConcreteCubePermanentProtocolTemplate.Template;
		
		var builder = new StringBuilder(template);
		
		builder.Replace("___protocolNumber___", data.TestProtocolNumber);
		builder.Replace("___companyName___", data.ClientCompany.Name);
		builder.Replace("___companyAddress___", data.ClientCompany.Address);
		builder.Replace("___companyCode___", data.ClientCompany.CompanyCode);
		builder.Replace("___employeeCompanyName___", executingUserCompany.Name);
		builder.Replace("___employeeCompanyAddress___", executingUserCompany.Address);
		builder.Replace("___employeeCompanyCode___", executingUserCompany.CompanyCode);
		builder.Replace("___testExecutionDate___", data.TestExecutionDate.ToString("yyyy/MM/dd"));
		builder.Replace("___testSamplesReceivedDate___", data.TestSamplesReceivedDate.ToString("yyyy/MM/dd"));
		builder.Replace("___testSamplesReceivedCount___", data.TestSamplesReceivedCount.ToString());
		builder.Replace("___testSamplesDeliveredBy___", data.TestSamplesDeliveredBy);
		builder.Replace("___testExecutedByUserName___", testExecutedByUserName);
		builder.Replace("___testType___", data.TestType == TestType.Initial ? "Pradinis" : "Nuolatinis");
		builder.Replace("___concreteType___", data.ConcreteType == ConcreteType.Light ? "Lengvasis" : "Sunkusis arba normalusis");
		builder.Replace("___testSamplesReceivedComment___", data.TestSamplesReceivedComment);
		builder.Replace("___acceptedSampleCount___", data.AcceptedSampleCount.ToString());
		builder.Replace("___rejectedSampleCount___", data.RejectedSampleCount.ToString());
		builder.Replace("___averageCrushForce___", data.AverageCrushForce.ToString("F"));
		if (data.StandardUncertainty is not null)
		{
			builder.Replace("___standardUncertainty___", data.StandardUncertainty.Value.ToString("F"));
		}
		else
		{
			builder.Replace("___standardUncertainty___", "-");
		}

		if (data.ExtendedUncertainty is not null)
		{
			builder.Replace("___extendedUncertainty___", data.ExtendedUncertainty.Value.ToString("F"));
		}
		else
		{
			builder.Replace("___extendedUncertainty___", "-");
		}

		if (data.StandardDeviation is not null)
		{
			builder.Replace("___standardDeviation___", data.StandardDeviation.Value.ToString("F"));
		}
		else
		{
			builder.Replace("___standardDeviation___", "-");
		}
		builder.Replace("___characteristicStrength___", data.CharacteristicStrength.ToString("F"));
		builder.Replace("___concreteRating___", data.ConcreteRating);
		for (int i = 0; i < data.TestData.Count; i++)
		{
			var valuesA = data.TestData[i].Dimensions.Where(x => x.Dimension == CubeDimension.A).Select(x => x.Value).ToArray();
			var valuesB = data.TestData[i].Dimensions.Where(x => x.Dimension == CubeDimension.B).Select(x => x.Value).ToArray();

			for (int j = 0; j < valuesA.Length; j++)
			{
				builder.Replace($"___testData[{i}]valueA[{j}]___", valuesA[j].ToString("F"));
				builder.Replace($"___testData[{i}]valueB[{j}]___", valuesB[j].ToString("F"));
			}
			builder.Replace($"___testData[{i}]destructivePower___", data.TestData[i].DestructivePower.ToString("F"));
			builder.Replace($"___testData[{i}]crushingStrength___", data.TestData[i].CrushingStrength.ToString("F"));
			builder.Replace($"___testData[{i}]comment___", data.TestData[i].Comment);
		}

		return builder.ToString();
	}
}