﻿using Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Query;

namespace Shop.Query.Categories.DTOs
{
    public class CategoryDto : BaseDto
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public SeoData SeoData { get; set; }
        public List<ChildCategoryDto> Childs { get; set; }
    }
}
