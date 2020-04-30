﻿using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Common.Mappings;
using AutoMapper;
using Domain.Entities.TodoAggregate;

namespace ApplicationCore.TodoLists.Dto
{
    public class TodoListDto : IMapFrom<TodoList>
    {
        public TodoListDto()
        {
            Items = new List<TodoItemDto>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public IList<TodoItemDto> Items { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TodoList, TodoListDto>();
        }
    }
}