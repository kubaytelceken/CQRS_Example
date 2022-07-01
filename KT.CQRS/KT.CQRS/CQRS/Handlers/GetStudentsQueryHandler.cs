using KT.CQRS.CQRS.Queries;
using KT.CQRS.CQRS.Results;
using KT.CQRS.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KT.CQRS.CQRS.Handlers
{
    public class GetStudentsQueryHandler :  IRequestHandler<GetStudentsQuery, IEnumerable<GetStudentsQueryResult>>
    {
        private readonly StudentContext _context;

        public GetStudentsQueryHandler(StudentContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetStudentsQueryResult>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Students.Select(x => new GetStudentsQueryResult
            {
                Name = x.Name,
                Surname = x.Surname,
                Age = x.Age
            }).AsNoTracking().ToListAsync();
        }
    }
}
