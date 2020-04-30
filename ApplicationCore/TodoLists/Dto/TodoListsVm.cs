using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.TodoLists.Dto
{
    public class TodoListsVm
    {
        public IList<TodoListDto> Lists { get; set; }
    }
}
