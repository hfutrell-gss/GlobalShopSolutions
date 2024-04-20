using Modeling.Application.Cqrs.Commands;

namespace Modeling.Application.Tests.Unit.Commands.TestApplication;

public sealed record AddValueCommand(int Value) : Command<AddValueResult>;