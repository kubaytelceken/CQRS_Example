using KT.CQRS.CQRS.Results;
using MediatR;
using System.Collections.Generic;

namespace KT.CQRS.CQRS.Queries
{
    public class GetStudentsQuery : IRequest<IEnumerable<GetStudentsQueryResult>>
    {
    }
}
