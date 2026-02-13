using Domain.Entities;
using Domain.Entities.Common;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.Notices.Queries.GetAllNotices
{
    public class GetAllNoticesQuery : IRequest<List<Notice>>
    {
    }
}
