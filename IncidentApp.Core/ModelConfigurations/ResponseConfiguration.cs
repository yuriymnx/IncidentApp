using IncidentApp.Domain;
using IncidentApp.Infrastructure.ModelConfigurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncidentApp.Infrastructure.ModelConfigurations;

public class ResponseConfiguration : IdentityModelConfigurationBase<Response>
{
    protected override void AddCustomConfiguration(EntityTypeBuilder<Response> builder)
    {
        builder.Property(response => response.Answer)
            .IsRequired()
            .HasMaxLength(500);

        builder.HasOne(response => response.Question)
            .WithMany(question => question.Responses)
            .HasForeignKey(response => response.QuestionId);
    }
}