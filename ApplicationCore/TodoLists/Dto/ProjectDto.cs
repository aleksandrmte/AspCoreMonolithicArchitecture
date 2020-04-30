using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Common.Mappings;
using AutoMapper;
using Domain.Entities.TodoAggregate;

namespace ApplicationCore.TodoLists.Dto
{
    public class ProjectDto: IMapFrom<Project>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Project, ProjectDto>();
        }
    }
}
