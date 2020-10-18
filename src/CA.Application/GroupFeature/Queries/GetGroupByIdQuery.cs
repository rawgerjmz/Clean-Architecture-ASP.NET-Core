﻿using AutoMapper;
using CA.Application.GroupFeature.ViewModel;
using CA.Domain.Contract;
using CA.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CA.Application.GroupFeature.Queries
{
    public class GetGroupByIdQuery : IRequest<GroupViewModel>
    {
        public Guid GroupId { get; set; }
        public GetGroupByIdQuery(Guid id)
        {
            GroupId = id;
        }
    }

    public class GetGroupByIdHandler : IRequestHandler<GetGroupByIdQuery, GroupViewModel>
    {
        private readonly IGenericRepository<Group, Guid> _genericRepository;
        private readonly IMapper _mapper;

        public GetGroupByIdHandler(IGenericRepository<Group, Guid> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<GroupViewModel> Handle(GetGroupByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = _genericRepository.GetById(request.GroupId);
            if (entity == null)
            {
                //throw new NotFoundException(nameof(Group), request.Id);
            }
            return _mapper.Map<GroupViewModel>(entity);
        }
    }
}
