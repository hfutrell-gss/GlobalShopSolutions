using Modeling.Application.Cqrs.Queries;

namespace Modeling.Application.Tests.Unit.Queries.TestApplication;

public sealed record ThingQuery(int ThingToGet) : Query<ThingQueryResult>;