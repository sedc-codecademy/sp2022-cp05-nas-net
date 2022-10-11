<<<<<<< HEAD
﻿using NewsAggregator.Domain.Entities;
using NewsAggregator.InterfaceModels.Models.Category;
using NewsAggregator.InterfaceModels.Models.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.Mappers
{
    public static class CategoryMappper
    {
        public static CategoryDto ToCategoryDto(this Category model)
        {
            return new CategoryDto
            {
                Id = model.Id,
                Name = model.Name
            };
        }
    }
}
=======
﻿using NewsAggregator.Domain.Entities;
using NewsAggregator.InterfaceModels.Models.Category;
using NewsAggregator.InterfaceModels.Models.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.Mappers
{
    public static class CategoryMappper
    {
        public static CategoryDto ToCategoryDto(this Category model)
        {
            return new CategoryDto
            {
                Id = model.Id,
                Name = model.Name
            };
        }
    }
}
>>>>>>> 5aee1f0008efc821c2ec559e2a78de6380c7377c
