using KT.CQRS.CQRS.Commands;
using KT.CQRS.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KT.CQRS.CQRS.Handlers
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand>
    {
        private readonly StudentContext _context;

        public CreateStudentCommandHandler(StudentContext context)
        {
            _context = context;
        }


        public async Task<Unit> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            _context.Students.Add(new Student
            {
                Age = request.Age,
                Name = request.Name,
                Surname = request.Surname
            });
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
