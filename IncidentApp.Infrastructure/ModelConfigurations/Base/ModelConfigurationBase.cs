﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncidentApp.Infrastructure.ModelConfigurations.Base;

public abstract class ModelConfigurationBase<T> : IEntityTypeConfiguration<T> where T : class
{
    public void Configure(EntityTypeBuilder<T> builder)
    {
        builder.ToTable(GetTableName());

        AddBaseConfiguration(builder);
    }

    protected abstract void AddBaseConfiguration(EntityTypeBuilder<T> builder);

    protected virtual string GetTableName() => typeof(T).Name;
}