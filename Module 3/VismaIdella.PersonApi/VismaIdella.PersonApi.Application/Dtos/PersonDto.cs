﻿using System.Collections.Generic;

namespace VismaIdella.PersonApi.Application.Dtos
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public IEnumerable<TodoListLightDto> Lists { get; set; }
    }
}
