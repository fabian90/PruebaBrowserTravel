﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Biblioteca.Commons.Mapper
{
    public static class DtoMapperExtension
    {
        public static T MapTo<T>(this object value)
        {
            return  JsonSerializer.Deserialize<T>(
                JsonSerializer.Serialize(value)
            );
        }
    }
}
