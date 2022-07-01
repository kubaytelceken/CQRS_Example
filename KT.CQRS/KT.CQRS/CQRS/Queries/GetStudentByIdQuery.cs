using KT.CQRS.CQRS.Results;
using MediatR;

namespace KT.CQRS.CQRS.Queries
{
    public class GetStudentByIdQuery : IRequest<GetStudentByIdQueryResult>
    {
        public int Id { get; set; }

        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
