﻿using AutoMapper;
using CA.Application.GroupFeature.Commands;
using CA.Application.GroupFeature.ViewModel;
using CA.Domain.Contract;
using CA.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CA.Application.GroupFeature.EventHandlers
{
    public class UpdateGroupCommandHandler : IRequestHandler<UpdateGroupCommand, GroupViewModel>
    {
        private readonly IGenericRepository<Group, Guid> _genericRepository;
        private readonly IMapper _mapper;
        public UpdateGroupCommandHandler(IGenericRepository<Group, Guid> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        public async Task<GroupViewModel> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
        {
            var entity = new Group
            {
                Id = request.Id,
                Description = request.Description,
                Name = request.Name
            };

            _genericRepository.Update(entity);
            _genericRepository.Save();

            return _mapper.Map<GroupViewModel>(entity);
        }


    }
}